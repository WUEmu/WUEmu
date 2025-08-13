using System;
using WOEmu6.Core.Network;
using WOEmu6.Core.Objects;

namespace WOEmu6.Core.Packets.Server
{
    /// <summary>
    /// Sends a new item to be placed into the world.
    /// </summary>
    public class AddItemPacket : IOutgoingPacket
    {
        public Item Item { get; }
        public bool IsOnSurface { get; }
        public float Rotation { get; }

        public AddItemPacket(Item item, bool isOnSurface = true, float rotation = 0f)
        {
            if (!item.IsSpatial)
                throw new NotSupportedException("Can not use AddItemPacket on non-spatial item!");
            
            Item = item;
            IsOnSurface = isOnSurface;
            Rotation = rotation;
        }

        public byte Opcode
        {
            get
            {
                // TODO: creature (?)
                return 0xF7;
            }
        }

        public void Write(ServerContext context, PacketWriter writer)
        {
            writer.WriteLong(Item.Id);
            writer.WriteFloat(Item.SpatialPosition.X);
            writer.WriteFloat(Item.SpatialPosition.Y);
            writer.WriteFloat(Rotation);
            writer.WriteFloat(Item.SpatialPosition.Z);
            writer.WriteBytePrefixedString(Item.Name);
            writer.WriteBytePrefixedString(Item.HoverText);
            writer.WriteBytePrefixedString(Item.Model);
            writer.WriteByte(0);
            writer.WriteByte(Item.Material);
            writer.WriteBytePrefixedString(Item.Description);
            writer.WriteShort(50); // image number
            writer.WriteByte((byte)1);
            writer.WriteFloat(Item.Quality);
            writer.WriteFloat(Item.Damage);
            writer.WriteFloat(Item.SizeModifier);
            writer.WriteLong(0); // bridge?
            writer.WriteByte(Item.Rarity);
            writer.WriteByte((byte)1); // 1 means able to placed on top something about containers
            writer.WriteBoolean(false); // has extra data
        }
    }
}