using WO.Core;
using WOEmu6.Core.Network;

namespace WOEmu6.Core.Packets.Server
{
    public class ClearChatPacket : IOutgoingPacket
    {
        public ClearChatPacket(string channel)
        {
            Channel = channel;
        }

        public byte Opcode => -65 & 0xFF;
        
        public string Channel { get; }
        
        public void Write(ServerContext context, PacketWriter writer)
        {
            writer.WriteBytePrefixedString(Channel);
        }
    }
}
