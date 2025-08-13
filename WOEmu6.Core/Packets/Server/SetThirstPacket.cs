
using WOEmu6.Core.Network;

namespace WOEmu6.Core.Packets.Server
{
    public class SetThirstPacket : IOutgoingPacket
    {
        public SetThirstPacket(ushort thirst)
        {
            Thirst = thirst;
        }

        public byte Opcode => 105;
        
        public ushort Thirst { get; }
        
        public void Write(ServerContext context, PacketWriter writer)
        {
            writer.WriteShort(Thirst);
        }
    }
}