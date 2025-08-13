using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading;
using Serilog;
using WOEmu6.Core.Network;
using WOEmu6.Core.Packets.Client;
using WOEmu6.Core.Packets.Server;
using WOEmu6.Core.Threading;

namespace WOEmu6.Core
{
    public enum ProtocolState
    {
        ReadPacketLength,
        ReadPayload
    }

    public class ClientSession : IThread
    {
        private readonly ServerContext serverContext;
        private readonly Socket socket;
        private readonly Encryption encryption;

        private ProtocolState protocolState;
        private byte[] receiveBuffer;

        private Queue<IOutgoingPacket> outQueue;
        private readonly object outQueueLock = new object();
        private Queue<IIncomingPacket> inQueue;
        private readonly object inQueueLock = new object();
        private readonly AutoResetEvent evt;

        public ClientSession(Socket socket)
        {
            this.socket = socket;
            protocolState = ProtocolState.ReadPacketLength;
            encryption = new Encryption();
            serverContext = ServerContext.Instance.Value;
            evt = new AutoResetEvent(false);

            inQueue = new Queue<IIncomingPacket>();
            outQueue = new Queue<IOutgoingPacket>();
        }

        public Player Player { get; set; }

        public string Name => "Client Session";

        public void StartRead()
        {
            receiveBuffer = new byte[2];
            socket.BeginReceive(receiveBuffer, 0, 2, SocketFlags.None, EndReceive, null);
        }

        private void EndReceive(IAsyncResult result)
        {
            var read = socket.EndReceive(result);
            if (read <= 0)
            {
                Log.Information("User disconnected.");
                if (Player != null)
                {
                    Player.CurrentZone.RemovePlayer(Player);
                    serverContext.World.PlayerDisconnected(Player);
                }
            }

            encryption.Decrypt(receiveBuffer);
            if (protocolState == ProtocolState.ReadPacketLength)
            {
                var lenPacketReader = new PacketReader(receiveBuffer);
                var len = lenPacketReader.ReadShort();
                receiveBuffer = new byte[len];
                protocolState = ProtocolState.ReadPayload;
            }
            else if (protocolState == ProtocolState.ReadPayload)
            {
                var reader = new PacketReader(receiveBuffer);
                var opcode = reader.ReadByte();
                var packet = serverContext.IncomingPacketFactory.Get(opcode);
                if (packet == null)
                    Log.Warning("Unimplemented opcode {opcode} ({opcodeSigned})", opcode, (sbyte)opcode);
                else
                {
                    packet.Read(reader);
                    inQueue.Enqueue(packet);
                }

                receiveBuffer = new byte[2];
                protocolState = ProtocolState.ReadPacketLength;
                evt.Set();
            }
            else
                throw new NotSupportedException("Unsupported protocol state");

            socket.BeginReceive(receiveBuffer, 0, receiveBuffer.Length, SocketFlags.None, EndReceive, null);
        }

        public void Run(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                if (!evt.WaitOne(1000))
                {
                    if (cancellationToken.IsCancellationRequested)
                        return;
                }
                else
                {
                    try
                    {
                        // TODO: probably some room for optimizations here trying to handle outgoing and incoming packets in the same thread?
                        IOutgoingPacket[] outHandle;
                        lock (outQueueLock)
                        {
                            outHandle = outQueue.ToArray();
                            outQueue = new Queue<IOutgoingPacket>();
                        }

                        foreach (var packet in outHandle)
                        {
                            var writer = new PacketWriter();
                            writer.WriteByte(packet.Opcode);
                            packet.Write(serverContext, writer);
                            var bytes = writer.Finish();
                            encryption.Encrypt(bytes, 0, bytes.Length);
                            socket.Send(bytes);
                        }

                        IIncomingPacket[] toHandle;
                        lock (inQueueLock)
                        {
                            toHandle = inQueue.ToArray();
                            inQueue = new Queue<IIncomingPacket>();
                        }

                        foreach (var packet in toHandle)
                        {
                            try
                            {
                                packet.Handle(this);
                            }
                            catch (Exception ex)
                            {
                                Log.Error(ex, "Error for player {player}", Player?.Name ?? "unknown");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Log.Error(ex, "Error trying to read the inQueue");
                    }
                }
            }
        }

        public void Send(IOutgoingPacket packet)
        {
            lock (outQueueLock)
                outQueue.Enqueue(packet);
            evt.Set();
        }
    }
}