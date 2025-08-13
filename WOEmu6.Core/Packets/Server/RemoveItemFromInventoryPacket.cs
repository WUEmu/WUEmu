using WOEmu6.Core.Network;
using WOEmu6.Core.Objects;

namespace WOEmu6.Core.Packets.Server
{
    public class RemoveItemFromInventoryPacket : IOutgoingPacket
    {
        public RemoveItemFromInventoryPacket(long windowId, WurmId itemId)
        {
            WindowId = windowId;
            ItemId = itemId;
        }

        public byte Opcode => -10 & 0xFF;
        
        public long WindowId { get; }
        
        public WurmId ItemId { get; }
        
        public void Write(ServerContext context, PacketWriter writer)
        {
            writer.WriteLong(WindowId);
            writer.WriteLong(ItemId);
        }
    }
}