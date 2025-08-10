using System.Collections.Generic;
using WOEmu6.Core.Packets;
using WOEmu6.Core.Packets.Server;
using WOEmu6.Core.Utilities;

namespace WOEmu6.Core.Objects
{
    public class StructureWall : ObjectBase
    {
        public StructureWall(WurmId id)
        {
            Id = id;
        }
        
        public bool IsFinished { get; set; }
        
        public WallType WallType { get; set; }
        
        public string Material { get; set; }
        
        public Color Color { get; set; }
        
        /// <summary>
        /// Height offset from ground. (30 units is 1 floor)
        /// </summary>
        public short Z { get; set; }

        public override IList<ContextMenuEntry> GetContextMenu(ClientSession session)
        {
            return new List<ContextMenuEntry>
            {
                new ContextMenuEntry(1999, "DELETE"),
                
                new ContextMenuEntry(2000, "Create wooden wall"),
                new ContextMenuEntry(2001, "Create wooden door"),
                new ContextMenuEntry(2002, "Create wooden window"),
                new ContextMenuEntry(2003, "Create wooden wide window"),
                new ContextMenuEntry(2004, "Create gold roof"),
                
                new ContextMenuEntry(2050, "Door - Open"),
                new ContextMenuEntry(2051, "Door - Close"),
            };
        }

        public override void OnMenuItemClick(ClientSession session, short itemId)
        {
            switch (itemId)
            {
                case 1999:
                    // session.Send(new RemoveStructureWallPacket(new WurmId(ObjectType.Structure, 0, 1), this));
                    session.Send(new RemoveStructurePacket(new WurmId(ObjectType.Structure, 0, 1)));
                    break;
                
                case 2000:
                    IsFinished = true;
                    WallType = WallType.Solid;
                    Color = Color.Red;
                    Material = "wood";
                    session.Send(new AddStructureWallPacket(new WurmId(ObjectType.Structure, 0 ,1), this));
                    break;
                
                case 2001:
                    IsFinished = true;
                    WallType = WallType.Door;
                    Material = "wood";
                    session.Send(new AddStructureWallPacket(new WurmId(ObjectType.Structure, 0 ,1), this));
                    // session.Send(new MarkWallPassablePacket(new WurmId(ObjectType.Structure, 0, 1), this));
                    break;
                
                case 2002:
                    IsFinished = true;
                    WallType = WallType.Window;
                    Material = "wood";
                    session.Send(new AddStructureWallPacket(new WurmId(ObjectType.Structure, 0 ,1), this));
                    break;
                
                case 2003:
                    IsFinished = true;
                    WallType = WallType.WideWindow;
                    Material = "wood";
                    session.Send(new AddStructureWallPacket(new WurmId(ObjectType.Structure, 0 ,1), this));
                    break;

                case 2004:
                {
                    var coords = Id.ToTileCoordinate();
                    session.Send(new AddStructureFloorPacket(new WurmId(ObjectType.Structure, 0, 1), 
                        new Position2D<short>(coords.Item1, coords.Item2), StructureFloorType.Roof, StructureFloorState.Completed, StructureFloorMaterial.Wood));
                }
                    
                    break;
                
                case 2050:
                    session.Send(new OpenDoor(new WurmId(ObjectType.Structure, 0, 1), this));
                    break;
                
                case 2051:
                    session.Send(new CloseDoor(new WurmId(ObjectType.Structure, 0, 1), this));
                    break;
            }
        }

        protected override ObjectType Type => ObjectType.Wall;
    }
}