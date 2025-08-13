using WO.Core;
using WOEmu6.Core.Network;
using WOEmu6.Core.Objects;

namespace WOEmu6.Core.Packets.Server
{
    public class AddChatUserPacket : IOutgoingPacket
    {
        public AddChatUserPacket(WurmId id, string userName, string channel = ":Local")
        {
            Id = id;
            UserName = userName;
            Channel = channel;
        }

        public byte Opcode => -13 & 0xFF;
        
        public string Channel { get; }

        public WurmId Id { get; }
        
        public string UserName { get; }
        
        public void Write(ServerContext context, PacketWriter writer)
        {
            writer.WriteBytePrefixedString(Channel);
            writer.WriteBytePrefixedString(UserName);
            writer.WriteLong(Id);
        }
    }
}