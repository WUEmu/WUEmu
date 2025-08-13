
using WOEmu6.Core.Network;

namespace WOEmu6.Core.Packets.Server
{
    public class StartMovingPacket : IOutgoingPacket
    {
        public byte Opcode => -28 & 0xFF;
        
        public void Write(ServerContext context, PacketWriter writer)
        {
        }
    }
}
