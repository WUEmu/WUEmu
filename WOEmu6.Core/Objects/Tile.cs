using System;
using System.Collections.Generic;
using WOEmu6.Core.Packets;
using WOEmu6.Core.Packets.Server;
using WOEmu6.Core.Utilities;

namespace WOEmu6.Core.Objects
{
    public class Tile : ObjectBase
    {
        public short X { get; }
        public short Y { get; }
        private int encodedValue;

        public Tile(int encodedValue, short x, short y)
        {
            X = x;
            Y = y;
            this.encodedValue = encodedValue;
            Id = new WurmId(ObjectType.Tile, 0, 0); // todo: encode properly
        }

        public TileType TileType
        {
            get => (TileType)(encodedValue >> 24);
            set => encodedValue = (((byte)value) << 24) | (encodedValue & 0xFFFFFF);
        }

        public short Height
        {
            get => (short)(encodedValue & 0xFFFF);
            set => encodedValue = (int)(((encodedValue & 0xFFFF0000) | (value)));
        }
        
        public static implicit operator int(Tile v) => v.encodedValue;

        public void CommitChanges() => ServerContext.Instance.Value.World.TopLayer.SetTile(X, Y, encodedValue);

        public override IList<ContextMenuEntry> GetContextMenu(ClientSession session)
        {
            return new List<ContextMenuEntry>
            {
                new ContextMenuEntry(1, "Make Dirt"),
                new ContextMenuEntry(2, "Make Cobblestone"),
                new ContextMenuEntry(3, "Raise"),
                new ContextMenuEntry(4, "Lower"),
                new ContextMenuEntry(5, "Flatten Around"),
                new ContextMenuEntry(6, "Make structure"),
                new ContextMenuEntry(7, "Add to build plan")
            };
        }

        public override void OnMenuItemClick(ClientSession session, short itemId)
        {
            var world = ServerContext.Instance.Value.World;
            session.Player.SetStatusText($"Clicking menu item {itemId:X}");
            
            switch (itemId)
            {
                case 1:
                    TileType = TileType.Dirt;
                    CommitChanges();
                    session.Send(new TileStripPacket((short)X, (short)Y, 1, 1 ));
                    break;
            
                case 2:
                    TileType = TileType.Cobblestone;
                    CommitChanges();
                    session.Send(new TileStripPacket((short)X, (short)Y, 1, 1 ));
                    break;
            
                case 3:
                    Height += 10;
                    CommitChanges();
                    session.Send(new TileStripPacket((short)X, (short)Y, 1, 1 ));
                    break;
            
                case 5:
                {
                    for (var x = -10; x < 10; x++)
                    {
                        for (var y = -10; y < 10; y++)
                        {
                            var xTarget = X + x;
                            var yTarget = Y + y;
                            var tile = world.TopLayer.GetTileValue((short)xTarget, (short)yTarget);
                            tile.Height = Height;
                            tile.CommitChanges();
                        }
                    }
            
                    session.Send(new TileStripPacket((short)(X - 10), (short)(Y - 10), 20, 20));
                    break;
                }

                case 6:
                {
                    session.Send(new AddStructurePacket(new Structure(StructureType.House, "My House", new Position2D<short>(X, Y), 0)));
                    break;
                }

                case 7:
                {
                    session.Send(new StructureBuildPlanPacket(new WurmId(ObjectType.Structure, 0, 1), 0, new List<Position2D<short>>
                    {
                        new Position2D<short>((short)X, (short)Y)
                    }));
                    break;
                }
            }
        }

        protected override ObjectType Type => ObjectType.Tile;

        public override string ToString() => $"Tile({TileType}, {X}, {Y})";
    }
}