using WO.Core;

namespace WOEmu6.Core.Packets.Server
{
    public class MapInfoPacket : IOutgoingPacket
    {
        public byte Opcode => 0xAD;
        public void Write(ServerContext context, PacketWriter writer)
        {
            writer.WriteBytePrefixedString("Adventure");
            writer.PushByte(0);
        }
    }
}