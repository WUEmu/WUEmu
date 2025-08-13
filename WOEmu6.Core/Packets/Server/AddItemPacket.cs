using WO.Core;
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
        public float X { get; }
        public float Y { get; }
        public float Z { get; }
        public bool IsOnSurface { get; }
        public float Rotation { get; }

        public AddItemPacket(Item item, float x, float y, float z, bool isOnSurface = true, float rotation = 0f)
        {
            Item = item;
            X = x;
            Y = y;
            Z = z;
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
            writer.WriteFloat(X);
            writer.WriteFloat(Y);
            writer.WriteFloat(Rotation);
            writer.WriteFloat(Z);
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