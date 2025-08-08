using System;
using WOEmu6.Core.Packets.Server;

namespace WOEmu6.Core.Objects
{
    public class Tile : ObjectBase
    {
        private int encodedValue;
        // public EncodedTile EncodedTile { get; }

        public Tile(int encodedValue)
        {
            this.encodedValue = encodedValue;
        }

        public override WurmId Id
        {
            get => encodedValue;
            protected set => throw new NotSupportedException("Cannot set ID of tile");
        }
        
        public TileType TileType
        {
            get => (TileType)((encodedValue >> 24) >> 24);
            set => encodedValue = (((byte)value) << 24) | (encodedValue & 0xFFFFFF);
        }

        public short Height
        {
            get => (short)(encodedValue & 0xFFFF);
            set => encodedValue = (int)(((encodedValue & 0xFFFF0000) | (value)));
        }
        
        public static implicit operator Tile(int v) => new Tile(v);

        public static implicit operator int(Tile v) => v.encodedValue;

        public void CommitChanges()
        {
            
        }

        protected override ObjectType Type => ObjectType.Tile;
    }
}