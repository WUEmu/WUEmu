using System.Collections.Generic;
using WO.Core;
using WOEmu6.Core.Objects;
using WOEmu6.Core.Utilities;

namespace WOEmu6.Core.Packets.Server
{
    public class StructureBuildPlanPacket : IOutgoingPacket
    {
        public StructureBuildPlanPacket(WurmId structureId, byte layer, List<Position2D<short>> tileCoordinates)
        {
            StructureId = structureId;
            Layer = layer;
            TileCoordinates = tileCoordinates;
        }

        public byte Opcode => 96;
        
        public WurmId StructureId { get; }
        
        public byte Layer { get; }
        
        public List<Position2D<short>> TileCoordinates { get; }
        
        public void Write(ServerContext context, PacketWriter writer)
        {
            writer.PushLong(StructureId);
            writer.PushByte(Layer);
            writer.PushByte((byte)TileCoordinates.Count);
            foreach (var position in TileCoordinates)
            {
                writer.PushShort(position.X);
                writer.PushShort(position.Y);
            }
        }
    }
}
