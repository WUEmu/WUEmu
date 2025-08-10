using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using Serilog;
using WO.Core;
using WOEmu6.Core.Network;
using WOEmu6.Core.Packets.Server;

namespace WOEmu6.Core.Packets
{
    public class ClientSession
    {
        private ServerContext serverContext;
        private readonly TcpClient client;
        private readonly Stream stream;
        private readonly Encryption encryption;

        public ClientSession(TcpClient client)
        {
            this.client = client;
            this.stream = client.GetStream();
            encryption = new Encryption();
            serverContext = ServerContext.Instance.Value;
        }

        public Player Player { get; set; }

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
                // User disconnected.
                Log.Information("User disconnected.");
            }
        }

        public void Send(IOutgoingPacket packet)
        {
            // Console.WriteLine($"Writing packet {packet.GetType().Name} {packet.Opcode} (signed={(sbyte)packet.Opcode})");
            
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