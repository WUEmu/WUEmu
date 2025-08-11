using System;
using System.Collections.Generic;
using WOEmu6.Core.Actions;
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

        public Tile(short x, short y, short height, TileType type, byte data)
        {
            X = x;
            Y = y;
            Height = height;
            TileType = type;
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
            session.Send(new AddInventoryItem(new TestItem("care")));
            
            var res = new List<ContextMenuEntry>
            {
                new ContextMenuEntry(9234, "Make Dirt"),
                new ContextMenuEntry(2, "Make Cobblestone"),
                new ContextMenuEntry(3, "Raise"),
                new ContextMenuEntry(4, "Lower"),
                new ContextMenuEntry(5, "Flatten Around"),
                new ContextMenuEntry(6, "Make structure"),
                new ContextMenuEntry(7, "Add to build plan"),
                new ContextMenuEntry(8, "[T] Spawn creasture"),
                
                new ContextMenuEntry(200, "[T] Trade Test"),
                
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

            if (Height < 0)
            {
                res.Add(new ContextMenuEntry(199, "Start Fishing"));
            }

            return res;
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
                
                case 200:
                    session.Send(new OpenTradeWindowPacket("Sjebgny", true));
                    session.Send(new SetTradeAgreePacket(true));
                    break;

                case 9234:
                {
                    var action = new TerraformDirt();
                    action.Execute(session, this);
                    break;
                }
            
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

                case 8:
                {
                    var c = new Creature(new WurmId(ObjectType.Creature, 0, 0xbeef));
                    c.Model = "model.creature.quadraped.wolf.worg";
                    c.IsSolid = true;
                    c.Condition = CreatureCondition.Diseased;
                    c.HoverText = "It peers into your soul...";
                    c.Position = new Position3D<float>(session.Player.X, session.Player.Y, session.Player.Z);
                    c.Rotation = session.Player.Rotation;
                    c.Face = 1;
                    c.Kingdom = 1;
                    c.Name = "Jan";
                    session.Send(new AddCreaturePacket(c));
                    session.Send(new AddChatUserPacket(c.Id, "Jan"));
                    break;
                }

                case 199:
                {
                    session.Send(new FishingStartPacket(10, 10, FishingRodType.FineRodWithLine, 0, FishingReelType.Professional, 0, FishingFloatType.Moss, FishingBaitType.Cheese, false));
                    break;
                }
            }
        }

        protected override ObjectType Type => ObjectType.Tile;

        public override string ToString() => $"Tile({TileType}, {X}, {Y})";
    }
}