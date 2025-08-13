using WO.Core;
using WOEmu6.Core.Network;

namespace WOEmu6.Core.Packets.Server
{
    public class AddKingdomPacket : IOutgoingPacket
    {
        public AddKingdomPacket(byte id, string name, string suffix = "default")
        {
            Id = id;
            Name = name;
            Suffix = suffix;
        }

        public byte Opcode => 39;
        
        public byte Id { get; }
        
        public string Name { get; }
        
        public string Suffix { get; }
        
        public void Write(ServerContext context, PacketWriter writer)
        {
            writer.WriteByte(Id);
            writer.WriteBytePrefixedString(Name);
            writer.WriteBytePrefixedString(Suffix);
        }
    }
}