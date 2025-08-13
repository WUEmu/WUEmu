using WO.Core;
using WOEmu6.Core.Network;

namespace WOEmu6.Core.Packets.Server
{
    public class TimerPacket : IOutgoingPacket
    {
        public TimerPacket(ushort timeLeft)
        {
            TimeLeft = timeLeft;
        }

        public byte Opcode => 87;
        
        public ushort TimeLeft { get; }
        
        public void Write(ServerContext context, PacketWriter writer)
        {
            writer.WriteShort(TimeLeft);
        }
    }
}