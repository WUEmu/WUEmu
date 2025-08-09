using WO.Core;
using WOEmu6.Core.Objects;

namespace WOEmu6.Core.Packets.Server
{
    public class PlaceItemPacket : IOutgoingPacket
    {
        public Item Item { get; }
        public float X { get; }
        public float Y { get; }
        public float Z { get; }
        public bool IsOnSurface { get; }
        public float Rotation { get; }

        public PlaceItemPacket(Item item, float x, float y, float z, bool isOnSurface = true, float rotation = 0f)
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
            writer.PushLong(Item.Id);
            writer.PushFloat(X);
            writer.PushFloat(Y);
            writer.PushFloat(Rotation);
            writer.PushFloat(Z);
            writer.WriteBytePrefixedString(Item.Name);
            writer.WriteBytePrefixedString(Item.HoverText);
            writer.WriteBytePrefixedString(Item.Model);
            writer.WriteByte((byte)(IsOnSurface ? 1 : 0));
            writer.WriteByte(Item.Material);
            writer.WriteBytePrefixedString(Item.Description);
            writer.WriteShort(0); // image number
            writer.WriteByte((byte)1);
            writer.PushFloat(Item.Quality);
            writer.PushFloat(Item.Damage);
            writer.PushFloat(Item.SizeModifier);
            writer.PushLong(0); // bridge?
            writer.WriteByte(Item.Rarity);
            writer.WriteByte((byte)0); // something about containers
            writer.WriteByte((byte)0); // extra data
        }
    }
}