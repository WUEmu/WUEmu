using WOEmu6.Core.Network;
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
            writer.WriteLong(Id);
            writer.WriteFloat(TargetPosition.Y);
            writer.WriteFloat(TargetPosition.X);
            writer.WriteByte(Rotation);
        }
    }
}