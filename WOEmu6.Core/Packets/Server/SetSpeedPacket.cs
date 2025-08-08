using WO.Core;

namespace WOEmu6.Core.Packets.Server
{
    public class SetSpeedPacket : IOutgoingPacket
    {
        public float Speed { get; }

        public SetSpeedPacket(float speed)
        {
            Speed = speed;
        }
        
        public byte Opcode => 32;
        
        public void Write(PacketWriter writer)
        {
            writer.PushFloat(Speed);
        }
    }
}