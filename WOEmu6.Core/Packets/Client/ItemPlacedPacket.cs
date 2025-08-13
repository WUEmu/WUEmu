using WOEmu6.Core.Network;
using WOEmu6.Core.Objects;
using WOEmu6.Core.Packets.Server;
using WOEmu6.Core.Utilities;

namespace WOEmu6.Core.Packets.Client
{
    public class ItemPlacedPacket : IIncomingPacket
    {
        public byte Opcode => -63 & 0xFF;

        public WurmId Id { get; private set; }

        public WurmId ParentId { get; private set; }

        public Position3D<float> Position { get; private set; }

        public float Rotation { get; private set; }

        public void Read(PacketReader reader)
        {
            Id = reader.ReadLong();
            ParentId = reader.ReadLong();
            var x = reader.ReadFloat();
            var y = reader.ReadFloat();
            var z = reader.ReadFloat();
            Position = new Position3D<float>(x, y, z);
            Rotation = reader.ReadFloat();
        }

        public void Handle(ClientSession client)
        {
            // client.Send(new AddItemPacket(new TestItem("model.furniture.table.square.small"), Position.X, Position.Y, Position.Z, true, Rotation));
        }
    }
}