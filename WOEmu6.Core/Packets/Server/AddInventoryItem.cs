using WOEmu6.Core.Network;
using WOEmu6.Core.Objects;

namespace WOEmu6.Core.Packets.Server
{
    public class AddInventoryItem : IOutgoingPacket
    {
        public AddInventoryItem(Item item)
        {
            Item = item;
        }

        public byte Opcode => 76;

        public WurmId ParentId { get; }

        public Item Item { get; }

        public void Write(ServerContext context, PacketWriter writer)
        {
            writer.WriteLong(-1L);
            if (ParentId != null)
                writer.WriteLong(ParentId);
            else
                writer.WriteLong(0L);
            writer.WriteLong(Item.Id);
            writer.WriteShort(Item.Icon);
            writer.WriteBytePrefixedString(Item.Name);
            writer.WriteBytePrefixedString(Item.HoverText);
            writer.WriteBytePrefixedString(Item.CustomName);
            writer.WriteFloat(1.0f);
            writer.WriteFloat(0.1f);
            writer.WriteInt(5000);
            writer.WriteBoolean(false);
            writer.WriteBoolean(false);
            writer.WriteBoolean(false);
            writer.WriteShort(0);
            writer.WriteByte(0);
            writer.WriteByte(20);
            writer.WriteByte(0);
            writer.WriteByte(-1);
        }
    }
}