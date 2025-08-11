using WO.Core;
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
            Id = reader.PopLong();
            ParentId = reader.PopLong();
            var x = reader.PopFloat();
            var y = reader.PopFloat();
            var z = reader.PopFloat();
            Position = new Position3D<float>(x, y, z);
            Rotation = reader.PopFloat();
        }

        public void Handle(ClientSession client)
        {
            client.Send(new AddItemPacket(new TestItem("model.furniture.table.square.small"), Position.X, Position.Y, Position.Z, true, Rotation));
        }
    }
}
