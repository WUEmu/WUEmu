using WOEmu6.Core.Network;
using WOEmu6.Core.Packets.Server;
using WOEmu6.Core.Utilities;

namespace WOEmu6.Core.Packets.Client
{
    public class FishingPacket : IIncomingPacket
    {
        public byte Opcode => -64 & 0xFF;

        public byte SubCommand { get; private set; }

        public Position2D<float> Position { get; private set; }

        public void Read(PacketReader reader)
        {
            SubCommand = reader.ReadByte();
            if (SubCommand == 9 || SubCommand == 26)
            {
                var x = reader.ReadFloat();
                var y = reader.ReadFloat();
                Position = new Position2D<float>(x, y);
            }
        }

        public void Handle(ClientSession client)
        {
            if (SubCommand == 9)
            {
                client.Send(new FishingCastedPacket(-1, Position, FishingFloatType.Twig));
            }
        }
    }
}