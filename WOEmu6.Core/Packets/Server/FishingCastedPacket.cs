using WOEmu6.Core.Network;
using WOEmu6.Core.Objects;
using WOEmu6.Core.Utilities;

namespace WOEmu6.Core.Packets.Server
{
    public class FishingCastedPacket : IOutgoingPacket
    {
        public FishingCastedPacket(WurmId id, Position2D<float> position, FishingFloatType f)
        {
            Id = id;
            Position = position;
            Float = f;
        }

        public byte Opcode => -64 & 0xFF;

        public WurmId Id { get; }

        public Position2D<float> Position { get; }

        public FishingFloatType Float { get; }

        public void Write(ServerContext context, PacketWriter writer)
        {
            writer.WriteByte(9);
            writer.WriteLong(Id);
            writer.WriteFloat(Position.X);
            writer.WriteFloat(Position.Y);
            writer.WriteByte((byte)Float);
        }
    }
}