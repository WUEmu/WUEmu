using WO.Core;
using WOEmu6.Core.Objects;

namespace WOEmu6.Core.Packets.Server
{
    public class AddStructureWallPacket : IOutgoingPacket
    {
        public AddStructureWallPacket(Structure structure, StructureWall wall) : this(structure.Id, wall)
        {
        }
        
        public AddStructureWallPacket(WurmId structureId, StructureWall wall)
        {
            StructureId = structureId;
            Wall = wall;
        }

        public byte Opcode => 49;
        
        public WurmId StructureId { get; }
        public StructureWall Wall { get; }

        public void Write(ServerContext context, PacketWriter writer)
        {
            writer.PushLong(StructureId);

            var wallCoords = Wall.Id.ToTileCoordinate();
            writer.PushShort(wallCoords.Item2);
            writer.PushShort(wallCoords.Item1);
            writer.PushByte((byte)(Wall.Id.ToDirection() == BorderDirection.Horizontal ? 0 : 1));
            writer.PushByte((byte)(Wall.IsFinished ? Wall.WallType : WallType.Plan));
            writer.WriteBytePrefixedString(Wall.Material);
            writer.PushByte(0); // colored
            writer.PushShort(0); // height (???)
            writer.PushByte(0); //layer
            writer.PushByte(0); // wall orientation (??????)
            
        }
    }
}