using WO.Core;
using WOEmu6.Core.Network;
using WOEmu6.Core.Objects;

namespace WOEmu6.Core.Packets.Server
{
    public class SendActionPacket : IOutgoingPacket
    {
        // This can also be a actual creature?? 
        public SendActionPacket(WurmId creatureId, string text, short seconds)
        {
            CreatureId = creatureId;
            Text = text;
            Time = (short)(seconds * 10);
        }

        public SendActionPacket(WurmId creatureId)
        {
            CreatureId = creatureId;
            Text = string.Empty;
            Time = 0;
        }

        public byte Opcode => -12 & 0xFF;
        
        public string Text { get; }
        
        public short Time { get; }
        
        public WurmId CreatureId { get; }
        
        public void Write(ServerContext context, PacketWriter writer)
        {
            writer.WriteBytePrefixedString(Text);
            writer.WriteShort(Time);
            writer.WriteLong(CreatureId);
        }
    }
}