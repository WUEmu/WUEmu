using WO.Core;
using WOEmu6.Core.Objects;

namespace WOEmu6.Core.Packets.Server
{
    public class RemoveStructureWallPacket : IOutgoingPacket
    {
        public RemoveStructureWallPacket(WurmId structureId, StructureWall wall)
        {
            StructureId = structureId;
            Wall = wall;
        }

        public byte Opcode => 54;
        
        public WurmId StructureId { get; }
        
        public StructureWall Wall { get; }
        
        public void Write(ServerContext context, PacketWriter writer)
        {
            writer.PushLong(StructureId);
            var wallCoords = Wall.Id.ToTileCoordinate();
            writer.WriteShort(wallCoords.Item1);
            writer.WriteShort(wallCoords.Item2);
            writer.WriteShort(Wall.Z);
            writer.WriteByte((byte)(Wall.Id.ToDirection() == BorderDirection.Horizontal ? 0 : 1));
            writer.WriteByte(0); // layer
        }
    }
}