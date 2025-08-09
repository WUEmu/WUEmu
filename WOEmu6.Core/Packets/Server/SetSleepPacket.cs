using WO.Core;

namespace WOEmu6.Core.Packets.Server
{
    public class SetSleepPacket : IOutgoingPacket
    {
        public int SleepBonusSeconds { get; }

        public SetSleepPacket(int sleepBonusSeconds = 0)
        {
            SleepBonusSeconds = sleepBonusSeconds;
        }
        
        public byte Opcode => 1;
        
        public void Write(ServerContext context, PacketWriter writer)
        {
            writer.WriteByte((byte)1);
            writer.PushInt(SleepBonusSeconds);
        }
    }
}