using WO.Core;

namespace WOEmu6.Core.Packets.Server
{
    public class MapInfoPacket : IOutgoingPacket
    {
        public byte Opcode => -45 & 0xFF;
        
        public void Write(ServerContext context, PacketWriter writer)
        {
            writer.WriteBytePrefixedString("Adventure");
            writer.WriteByte((byte)0);
        }
    }
}