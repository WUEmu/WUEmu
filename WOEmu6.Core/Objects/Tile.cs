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
        
        public byte Layer { get; }
        
        private int encodedValue;

        public Tile(int encodedValue, short x, short y)
        {
            X = x;
            Y = y;
            Layer = 0;
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
                new ContextMenuEntry(7, "Add to build plan"),
                
                new ContextMenuEntry(10, "TEST TITLES"),
                
                new ContextMenuEntry(-7, "Tile Effects"),
                new ContextMenuEntry(100, "Fire Pillar"),
                new ContextMenuEntry(101, "Ice Pillar"),
                new ContextMenuEntry(102, "Fungus Trap"),
                new ContextMenuEntry(103, "Lava"),
                new ContextMenuEntry(104, "Snow"),
                new ContextMenuEntry(105, "Tentacles"),
                new ContextMenuEntry(106, "- Remove Effect"),
            };
        }

        public override void OnMenuItemClick(ClientSession session, short itemId)
        {
            var world = ServerContext.Instance.Value.World;
            session.Player.SetStatusText($"Clicking menu item {itemId:X}");

            // session.Send(new SetWeightPacket(0.4f));
            
            switch (itemId)
            {
                case 100:
                    session.Send(new AddTileEffectPacket(this, TileEffectType.FirePillar, 0, true));
                    break;
                
                case 101:
                    session.Send(new AddTileEffectPacket(this, TileEffectType.IcePillar, 0, true));
                    break;
                
                case 102:
                    session.Send(new AddTileEffectPacket(this, TileEffectType.FungusTrap, 0, true));
                    break;
                
                case 103:
                    session.Send(new AddTileEffectPacket(this, TileEffectType.Lava, 0, true));
                    break;
                
                case 104:
                    session.Send(new AddTileEffectPacket(this, TileEffectType.Snow, 0, true));
                    break;
                
                case 105:
                    session.Send(new AddTileEffectPacket(this, TileEffectType.Tentacles, 0, true));
                    break;
                
                case 106:
                    session.Send(new RemoveTileEffectPacket(this));
                    break;
                
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
                
                case 10:
                    session.Send(new SetPlayerTitles("King", "What"));
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