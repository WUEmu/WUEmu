using WOEmu6.Core.Network;

namespace WOEmu6.Core.Packets.Server
{
    public class RemoveChatUserPacket : IOutgoingPacket
    {
        public RemoveChatUserPacket(string userName, string channel = ":Local")
        {
            Channel = channel;
            UserName = userName;
        }

        public byte Opcode => 114;

        public string Channel { get; }

        public string UserName { get; }

        public void Write(ServerContext context, PacketWriter writer)
        {
            writer.WriteBytePrefixedString(Channel);
            writer.WriteBytePrefixedString(UserName);
        }
    }
}