using WO.Core;

namespace WOEmu6.Core.Packets.Server
{
    public class TradeConditionsChangedPacket : IOutgoingPacket
    {
        public TradeConditionsChangedPacket(int sequenceNumber)
        {
            SequenceNumber = sequenceNumber;
        }

        public byte Opcode => 91;
        
        public int SequenceNumber { get; }
        
        public void Write(ServerContext context, PacketWriter writer)
        {
            writer.PushInt(SequenceNumber);
        }
    }
}