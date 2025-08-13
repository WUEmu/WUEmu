using WO.Core;
using WOEmu6.Core.Network;
using WOEmu6.Core.Objects;

namespace WOEmu6.Core.Packets.Server
{
    public class RemoveStructurePacket : IOutgoingPacket
    {
        public RemoveStructurePacket(WurmId structureId)
        {
            StructureId = structureId;
        }

        public byte Opcode => 48;
        
        public WurmId StructureId { get; } 
        
        public void Write(ServerContext context, PacketWriter writer)
        {
            writer.WriteLong(StructureId);
        }
    }
}