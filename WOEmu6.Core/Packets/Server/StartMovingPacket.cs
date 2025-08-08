using WO.Core;

namespace WOEmu6.Core.Packets.Server
{
    public class StartMovingPacket : IOutgoingPacket
    {
        public byte Opcode => 0x9C;
        
        public void Write(PacketWriter writer)
        {
        }
    }
}
