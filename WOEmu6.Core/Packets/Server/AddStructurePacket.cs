using WO.Core;
using WOEmu6.Core.Network;
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
            writer.WriteLong(Structure.Id);
            writer.WriteByte((byte)Structure.StructureType);
            writer.WriteBytePrefixedString(Structure.Name);
            writer.WriteShort(Structure.Position.X);
            writer.WriteShort(Structure.Position.Y);
            writer.WriteByte(Structure.Layer);
        }
    }
}