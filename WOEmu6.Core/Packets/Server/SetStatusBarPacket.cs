using WO.Core;

namespace WOEmu6.Core.Packets.Server
{
    public class SetStatusBarPacket : IOutgoingPacket
    {
        public SetStatusBarPacket(string text)
        {
            Text = text;
        }

        public byte Opcode => -18 & 0xFF;
        
        public string Text { get; }
        
        public void Write(ServerContext context, PacketWriter writer)
        {
            writer.WriteBytePrefixedString(Text);
        }
    }
}