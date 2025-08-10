using WO.Core;

namespace WOEmu6.Core.Packets.Server
{
    public class OpenTradeWindowPacket : IOutgoingPacket
    {
        public OpenTradeWindowPacket(string otherPartyName, bool isInitiatedByThisPlayer)
        {
            OtherPartyName = otherPartyName;
            IsInitiatedByThisPlayer = isInitiatedByThisPlayer;
        }

        public byte Opcode => 119;
        
        public string OtherPartyName { get; }
        
        public bool IsInitiatedByThisPlayer { get; }
        
        public void Write(ServerContext context, PacketWriter writer)
        {
            writer.WriteBytePrefixedString(OtherPartyName);
            writer.PushLong(IsInitiatedByThisPlayer ? 1L : 0L);
            writer.PushLong(0);
            writer.PushLong(0);
            writer.PushLong(0);
        }
    }
}