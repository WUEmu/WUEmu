using WO.Core;

namespace WOEmu6.Core.Packets.Server
{
    public class ReconnectPacket : IOutgoingPacket
    {
        public ReconnectPacket(string ipAddress, int port, string token)
        {
            IpAddress = ipAddress;
            Port = port;
            Token = token;
        }

        public byte Opcode => 23;
        
        public string IpAddress { get; }
        
        public int Port { get; }
        
        public string Token { get; }
        
        public void Write(ServerContext context, PacketWriter writer)
        {
            writer.WriteBytePrefixedString(IpAddress);
            writer.PushInt(Port);
            writer.WriteBytePrefixedString(Token);
        }
    }
}
