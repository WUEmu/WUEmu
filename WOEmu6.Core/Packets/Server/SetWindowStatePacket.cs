
using WOEmu6.Core.Network;

namespace WOEmu6.Core.Packets.Server
{
    public class SetWindowStatePacket : IOutgoingPacket
    {
        public byte Opcode => -66 & 0xFF;
        public void Write(ServerContext context, PacketWriter writer)
        {
            throw new System.NotImplementedException();
        }
    }
}