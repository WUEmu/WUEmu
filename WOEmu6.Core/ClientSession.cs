using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using WO.Core;
using WOEmu6.Core.Network;
using WOEmu6.Core.Packets.Server;

namespace WOEmu6.Core.Packets
{
    public class ClientSession
    {
        private readonly ServerContext serverContext;
        private readonly TcpClient client;
        private readonly Stream stream;
        private readonly Encryption encryption; 

        public ClientSession(ServerContext serverContext, TcpClient client)
        {
            this.serverContext = serverContext;
            this.client = client;
            this.stream = client.GetStream();
            encryption = new Encryption();
        }

        public void Run()
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
                    Console.WriteLine($"Unimplemented opcode {opcode}");
                    continue;
                }

                packet.Read(reader);
                packet.Handle(this);
            }
        }

        public void Send(IOutgoingPacket packet)
        {
            var writer = new PacketWriter();
            writer.PushByte(packet.Opcode);
            packet.Write(serverContext, writer);
            var bytes = writer.Finish();
            encryption.Encrypt(bytes, 0, bytes.Length);
            stream.Write(bytes);
            stream.Flush();
        }
    }
}