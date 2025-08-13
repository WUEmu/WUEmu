using System.Collections.Generic;
using WO.Core;
using WOEmu6.Core.Network;

namespace WOEmu6.Core.Packets.Server
{
    public class SelectionMenuPacket : IOutgoingPacket
    {
        public SelectionMenuPacket(List<SelectionMenuAction> actions, byte requestId)
        {
            Actions = actions;
            RequestId = requestId;
        }

        public byte Opcode => -23 & 0xFF;
        
        public byte RequestId { get; }
        
        public List<SelectionMenuAction> Actions { get; }
        
        public void Write(ServerContext context, PacketWriter writer)
        {
            writer.WriteByte(0);
            writer.WriteByte(RequestId);
            writer.WriteByte((byte)Actions.Count);
            foreach (var action in Actions)
            {
                writer.WriteShort((short)action);
                writer.WriteByte(0);
            }
        }
    }
}