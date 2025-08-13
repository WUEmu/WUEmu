using WOEmu6.Core.Network;

namespace WOEmu6.Core.Packets.Client
{
    public class PlayerMove : IIncomingPacket
    {
        public byte Opcode => 36;

        public bool AllowAnonymous => false;
        
        public float X { get; private set; }
        public float Y { get; private set; }
        public float Z { get; private set; }
        public float Rotation { get; private set; }
        public byte Layer { get; private set; }

        public void Read(PacketReader reader)
        {
            X = reader.ReadFloat();
            Y = reader.ReadFloat();
            Z = reader.ReadFloat();
            Rotation = reader.ReadFloat();
            var bm = reader.ReadByte();
            Layer = reader.ReadByte();
        }

        public void Handle(ClientSession client)
        {
            if (client.Player == null)
                return;

            client.Player.Move(X, Y, Z, Rotation);
        }
    }
}