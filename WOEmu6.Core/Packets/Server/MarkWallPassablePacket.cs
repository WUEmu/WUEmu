using WO.Core;
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
            writer.PushLong(StructureId);
            var wallCoords = Wall.Id.ToTileCoordinate();
            writer.PushShort(wallCoords.Item1);
            writer.PushShort(wallCoords.Item2);
            writer.PushByte((byte)(Passable ? 1 : 0)); // passable
            writer.PushByte((byte)(Wall.Id.ToDirection() == BorderDirection.Horizontal ? 0 : 1));
            writer.PushShort(0); //height wtf
            writer.PushByte(0); //layer
        }
    }
}