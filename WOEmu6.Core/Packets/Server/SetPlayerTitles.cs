using WO.Core;
using WOEmu6.Core.Network;

namespace WOEmu6.Core.Packets.Server
{
    public class SetPlayerTitles : IOutgoingPacket
    {
        public SetPlayerTitles(string title, string meditationTitle)
        {
            Title = title;
            MeditationTitle = meditationTitle;
        }

        public byte Opcode => -33 & 0xFF;
        
        public string Title { get; }
        
        public string MeditationTitle { get; }
        
        public void Write(ServerContext context, PacketWriter writer)
        {
            writer.WriteShortPrefixedString(Title);
            writer.WriteShortPrefixedString(MeditationTitle);
        }
    }
}