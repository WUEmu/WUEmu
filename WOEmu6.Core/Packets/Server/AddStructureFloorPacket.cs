using WO.Core;
using WOEmu6.Core.Objects;
using WOEmu6.Core.Utilities;

namespace WOEmu6.Core.Packets.Server
{
    public class AddStructureFloorPacket : IOutgoingPacket
    {
        public AddStructureFloorPacket(WurmId structureId, Position2D<short> position, StructureFloorType floorType, StructureFloorState state, StructureFloorMaterial material)
        {
            StructureId = structureId;
            Position = position;
            State = state;
            Material = material;
            FloorType = floorType;
        }

        public byte Opcode => 82;
        
        public WurmId StructureId { get; }
        
        public Position2D<short> Position { get; }

        public StructureFloorType FloorType { get; }
        
        public StructureFloorState State { get; }
        
        public StructureFloorMaterial Material { get; }
        
        public void Write(ServerContext context, PacketWriter writer)
        {
            writer.PushLong(StructureId);
            writer.PushShort(Position.X);
            writer.PushShort(Position.Y);
            writer.PushShort(10); // height
            writer.PushByte((byte)FloorType);
            writer.PushByte((byte)Material);
            writer.PushByte((byte)State);
            writer.PushByte(0); // layer
            writer.PushByte(0); // direction... why though??
        }
    }
}