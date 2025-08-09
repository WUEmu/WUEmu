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
            writer.WriteByte((byte)1); // part no. for text longer than the max short length for the packet.
            writer.WriteShort(Form.Id);
            writer.WriteBytePrefixedString(Form.Title);
            writer.WriteShort(Form.Width);
            writer.WriteShort(Form.Height);
            writer.PushFloat(Form.X);
            writer.PushFloat(Form.Y);
            writer.WriteByte((byte)(Form.Resizable ? 1 : 0));
            writer.WriteByte((byte)(Form.Closeable ? 1 : 0));
            writer.WriteByte(Form.R);
            writer.WriteByte(Form.G);
            writer.WriteByte(Form.B);
            writer.WriteByte((byte)1); // max parts
            writer.WriteShortPrefixedString(Form.Contents);
        }
    }
}