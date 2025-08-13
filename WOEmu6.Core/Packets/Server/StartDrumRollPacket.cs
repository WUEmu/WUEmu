using WO.Core;
using WOEmu6.Core.Network;

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
