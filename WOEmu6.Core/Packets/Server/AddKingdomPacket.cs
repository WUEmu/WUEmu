using WOEmu6.Core.Network;
using WOEmu6.Core.Objects;

namespace WOEmu6.Core.Packets.Server
{
    public class AddKingdomPacket : IOutgoingPacket
    {
        public AddKingdomPacket(Kingdom kingdom)
        {
            Kingdom = kingdom;
        }

        public byte Opcode => 39;

        public Kingdom Kingdom { get; } 

        public void Write(ServerContext context, PacketWriter writer)
        {
            writer.WriteByte(Kingdom.Id);
            writer.WriteBytePrefixedString(Kingdom.Name);
            writer.WriteBytePrefixedString(Kingdom.Suffix);
        }
    }
}