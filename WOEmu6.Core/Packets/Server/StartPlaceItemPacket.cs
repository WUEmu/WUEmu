
using WOEmu6.Core.Network;
using WOEmu6.Core.Objects;

namespace WOEmu6.Core.Packets.Server
{
    public class StartPlaceItemPacket : IOutgoingPacket
    {
        public StartPlaceItemPacket(Item item)
        {
            Item = item;
        }
        
        public byte Opcode => -63 & 0xFF;
        
        public Item Item { get; }
        
        public void Write(ServerContext context, PacketWriter writer)
        {
            writer.WriteLong(Item.Id);
            writer.WriteBytePrefixedString(Item.Name);
            writer.WriteBytePrefixedString(Item.Model);
            writer.WriteByte(Item.Material);
            writer.WriteFloat(Item.SizeModifier);
            writer.WriteByte(Item.Rarity);
        }
    }
}
