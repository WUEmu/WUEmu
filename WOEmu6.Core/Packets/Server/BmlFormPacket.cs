using WO.Core;
using WOEmu6.Core.BML;

namespace WOEmu6.Core.Packets.Server
{
    public class BmlFormPacket : IOutgoingPacket
    {
        public BmlForm Form { get; }

        public BmlFormPacket(BmlForm form)
        {
            Form = form;
        }
        
        public byte Opcode => 106;
        
        public void Write(ServerContext context, PacketWriter writer)
        {
            writer.PushByte(1); // part no. for text longer than the max short length for the packet.
            writer.PushShort(Form.Id);
            writer.WriteBytePrefixedString(Form.Title);
            writer.PushShort(Form.Width);
            writer.PushShort(Form.Height);
            writer.PushFloat(Form.X);
            writer.PushFloat(Form.Y);
            writer.PushByte((byte)(Form.Resizable ? 1 : 0));
            writer.PushByte((byte)(Form.Closeable ? 1 : 0));
            writer.PushByte(Form.R);
            writer.PushByte(Form.G);
            writer.PushByte(Form.B);
            writer.PushByte(1); // max parts
            writer.WriteShortPrefixedString(Form.Contents);
        }
    }
}