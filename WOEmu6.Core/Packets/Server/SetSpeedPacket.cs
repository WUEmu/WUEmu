using WO.Core;
using WOEmu6.Core.Network;

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
        
        public void Write(ServerContext context, PacketWriter writer)
        {
            writer.WriteFloat(Speed);
        }
    }
}