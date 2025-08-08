using WO.Core;

namespace WOEmu6.Core.Packets.Server
{
    public class StartDrumRollPacket : IOutgoingPacket
    {
        public byte Opcode => 0x38;
        
        public void Write(ServerContext context, PacketWriter writer)
        {
        }
    }
}
