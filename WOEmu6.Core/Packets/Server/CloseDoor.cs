using WO.Core;
using WOEmu6.Core.Network;
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
            writer.WriteLong(StructureId);
            var wallCoords = Wall.Id.ToTileCoordinate();
            writer.WriteShort(wallCoords.Item1);
            writer.WriteShort(wallCoords.Item2);
            writer.WriteByte((byte)(Wall.Id.ToDirection() == BorderDirection.Horizontal ? 0 : 1));
            writer.WriteShort(0); //height
            writer.WriteByte((byte)0); //layer
        }
    }
}