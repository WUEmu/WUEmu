using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using Serilog;
using WO.Core;
using WOEmu6.Core.Network;
using WOEmu6.Core.Packets.Client;
using WOEmu6.Core.Packets.Server;
using WOEmu6.Core.Threading;

namespace WOEmu6.Core
{
    public class ClientSession : IThread
    {
        private readonly ServerContext serverContext;
        private readonly TcpClient client;
        private readonly Stream stream;
        private readonly Encryption encryption;

        private Queue<IOutgoingPacket> outQueue;
        private Queue<IIncomingPacket> inQueue;

        public ClientSession(TcpClient client)
        {
            this.client = client;
            this.stream = client.GetStream();
            encryption = new Encryption();
            serverContext = ServerContext.Instance.Value;

            inQueue = new Queue<IIncomingPacket>();
            outQueue = new Queue<IOutgoingPacket>();
        }

        public Player Player { get; set; }

        public string Name => "Client Session";

        public void Run()
        {
            try
            {
                while (true)
                {
                    var p0 = new byte[2];
                    stream.ReadExactly(p0, 0, 2);
                    encryption.Decrypt(p0);
                    var lenPacketReader = new PacketReader(p0);
                    var len = lenPacketReader.PopShort();

                    var p1 = new byte[len];
                    stream.ReadExactly(p1, 0, len);
                    encryption.Decrypt(p1);

                    var reader = new PacketReader(p1);
                    var opcode = reader.ReadByte();
                    var packet = serverContext.IncomingPacketFactory.Get(opcode);
                    if (packet == null)
                    {
                        Log.Warning("Unimplemented opcode {opcode} ({opcodeSigned})", opcode, (sbyte)opcode);
                        continue;
                    }

                    packet.Read(reader);
                    try
                    {
                        packet.Handle(this);
                    }
                    catch (Exception ex)
                    {
                        Log.Error(ex, "Error for player {player}", Player?.Name);
                    }
                }
            }
            catch (IOException ex)
            {
                Log.Information("User disconnected.");
                if (Player != null)
                {
                    Player.CurrentZone.RemovePlayer(Player);
                    serverContext.World.PlayerDisconnected(Player);
                }
            }
        }

        public void Send(IOutgoingPacket packet)
        {
            var writer = new PacketWriter();
            writer.WriteByte(packet.Opcode);
            packet.Write(serverContext, writer);
            var bytes = writer.Finish();
            encryption.Encrypt(bytes, 0, bytes.Length);
            stream.Write(bytes);
            stream.Flush();
        }
    }
}