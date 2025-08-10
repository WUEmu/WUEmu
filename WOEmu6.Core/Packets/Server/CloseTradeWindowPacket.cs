using WO.Core;

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