using WO.Core;
using WOEmu6.Core.Objects;

namespace WOEmu6.Core.Packets.Server
{
    public class AddStructurePacket : IOutgoingPacket
    {
        public AddStructurePacket(Structure structure)
        {
            Structure = structure;
        }

        public byte Opcode => 112;
        
        public Structure Structure { get; }
        
        public void Write(ServerContext context, PacketWriter writer)
        {
            writer.PushLong(Structure.Id);
            writer.PushByte((byte)Structure.StructureType);
            writer.WriteBytePrefixedString(Structure.Name);
            writer.PushShort(Structure.Position.X);
            writer.PushShort(Structure.Position.Y);
            writer.PushByte(Structure.Layer);
        }
    }
}