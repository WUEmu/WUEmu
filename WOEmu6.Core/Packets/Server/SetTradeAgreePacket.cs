using WO.Core;

namespace WOEmu6.Core.Packets.Server
{
    public class SetTradeAgreePacket : IOutgoingPacket
    {
        public SetTradeAgreePacket(bool agreed)
        {
            Agreed = agreed;
        }

        public byte Opcode => 42;
        
        public bool Agreed { get; }
        
        public void Write(ServerContext context, PacketWriter writer)
        {
            writer.WriteBoolean(Agreed);
        }
    }
}
