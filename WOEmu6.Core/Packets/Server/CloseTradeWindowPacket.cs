using WO.Core;
using WOEmu6.Core.Network;

namespace WOEmu6.Core.Packets.Server
{
    public class CloseTradeWindowPacket : IOutgoingPacket
    {
        public byte Opcode => 121;
        public void Write(ServerContext context, PacketWriter writer)
        {
        }
    }
}