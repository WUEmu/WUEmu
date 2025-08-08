using WO.Core;
using WOEmu6.Core.Objects;

namespace WOEmu6.Core.Packets.Server
{
    public class CloseDoor : IOutgoingPacket
    {
        public CloseDoor(WurmId structureId, StructureWall wall)
        {
            StructureId = structureId;
            Wall = wall;
        }

        public byte Opcode => 127;
        
        public WurmId StructureId { get; }
        
        public StructureWall Wall { get; }
        
        public void Write(ServerContext context, PacketWriter writer)
        {
            writer.PushLong(StructureId);
            var wallCoords = Wall.Id.ToTileCoordinate();
            writer.PushShort(wallCoords.Item1);
            writer.PushShort(wallCoords.Item2);
            writer.PushByte((byte)(Wall.Id.ToDirection() == BorderDirection.Horizontal ? 0 : 1));
            writer.PushShort(0); //height
            writer.PushByte(0); //layer
        }
    }
}