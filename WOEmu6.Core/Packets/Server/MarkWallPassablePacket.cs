using WOEmu6.Core.Network;
using WOEmu6.Core.Objects;

namespace WOEmu6.Core.Packets.Server
{
    public class MarkWallPassablePacket : IOutgoingPacket
    {
        public MarkWallPassablePacket(WurmId structureId, StructureWall wall, bool passable)
        {
            StructureId = structureId;
            Wall = wall;
            Passable = passable;
        }

        public byte Opcode => 125;

        public WurmId StructureId { get; }

        public StructureWall Wall { get; }

        public bool Passable { get; }

        public void Write(ServerContext context, PacketWriter writer)
        {
            writer.WriteLong(StructureId);
            var wallCoords = Wall.Id.ToTileCoordinate();
            writer.WriteShort(wallCoords.Item1);
            writer.WriteShort(wallCoords.Item2);
            writer.WriteBoolean(Passable);
            writer.WriteByte((byte)(Wall.Id.ToDirection() == BorderDirection.Horizontal ? 0 : 1));
            writer.WriteShort(Wall.Z);
            writer.WriteByte((byte)0); //layer
        }
    }
}