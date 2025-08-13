using System;
using WO.Core;
using WOEmu6.Core.Network;
using WOEmu6.Core.Objects;

namespace WOEmu6.Core.Packets.Server
{
    public class RemoveCreaturePacket : IOutgoingPacket
    {
        public RemoveCreaturePacket(WurmId id)
        {
            if (id.Type != ObjectType.Creature)
                throw new ArgumentException("Id is not a creature type!");
            Id = id;
        }

        public byte Opcode => 14;
        
        public WurmId Id { get; }
        
        public void Write(ServerContext context, PacketWriter writer)
        {
            writer.WriteLong(Id);
        }
    }
}