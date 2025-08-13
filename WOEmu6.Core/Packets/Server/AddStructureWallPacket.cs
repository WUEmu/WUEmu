using WOEmu6.Core.Network;
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
            writer.WriteLong(StructureId);

            var wallCoords = Wall.Id.ToTileCoordinate();
            writer.WriteShort(wallCoords.Item2);
            writer.WriteShort(wallCoords.Item1);
            writer.WriteByte((byte)(Wall.Id.ToDirection() == BorderDirection.Horizontal ? 0 : 1));
            writer.WriteByte((byte)(Wall.IsFinished ? Wall.WallType : WallType.Plan));
            writer.WriteBytePrefixedString(Wall.Material);
            writer.WriteBoolean(Wall.Color != null); // colored
            if (Wall.Color != null)
            {
                writer.WriteByte(Wall.Color.R);
                writer.WriteByte(Wall.Color.G);
                writer.WriteByte(Wall.Color.B);
            }

            writer.WriteShort(Wall.Z);
            writer.WriteByte((byte)0); //layer
            writer.WriteByte((byte)1); // wall orientation (??????)
        }
    }
}