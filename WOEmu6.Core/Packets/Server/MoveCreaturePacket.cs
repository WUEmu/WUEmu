using WO.Core;
using WOEmu6.Core.Objects;
using WOEmu6.Core.Utilities;

namespace WOEmu6.Core.Packets.Server
{
    public class MoveCreaturePacket : IOutgoingPacket
    {
        public MoveCreaturePacket(WurmId id, Position2D<float> targetPosition, byte rotation)
        {
            Id = id;
            TargetPosition = targetPosition;
            Rotation = rotation;
        }

        public byte Opcode => 36;
        
        public WurmId Id { get; }
        
        public Position2D<float> TargetPosition { get; }
        
        public byte Rotation { get; }
        
        public void Write(ServerContext context, PacketWriter writer)
        {
            writer.PushLong(Id);
            writer.PushFloat(TargetPosition.Y);
            writer.PushFloat(TargetPosition.X);
            writer.WriteByte(Rotation);
        }
    }
}