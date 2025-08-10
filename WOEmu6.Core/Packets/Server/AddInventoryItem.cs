using WO.Core;
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
            writer.PushLong(-1L);
            if (ParentId != null)
                writer.PushLong(ParentId);
            else
                writer.PushLong(0L);
            writer.PushLong(Item.Id);
            writer.WriteShort(946);
            writer.WriteBytePrefixedString("Base Name");
            writer.WriteBytePrefixedString("Hover");
            writer.WriteBytePrefixedString("Custom Name");
            writer.PushFloat(1.0f);
            writer.PushFloat(0.1f);
            writer.PushInt(5000);
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