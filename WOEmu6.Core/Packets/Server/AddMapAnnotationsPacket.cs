using System.Collections.Generic;
using WO.Core;
using WOEmu6.Core.Network;
using WOEmu6.Core.Objects;

namespace WOEmu6.Core.Packets.Server
{
    public class AddMapAnnotationsPacket : IOutgoingPacket
    {
        public AddMapAnnotationsPacket(IList<MapAnnotation> annotations)
        {
            Annotations = annotations;
        }

        public byte Opcode => -43 & 0xFF;
        
        public IList<MapAnnotation> Annotations { get; }
        
        public void Write(ServerContext context, PacketWriter writer)
        {
            writer.WriteByte(0);
            writer.WriteShort((short)Annotations.Count);
            foreach (var annotation in Annotations)
            {
                writer.WriteLong(annotation.Id);
                writer.WriteByte((byte)annotation.Type);
                writer.WriteShortPrefixedString(annotation.Server);
                writer.WriteShort((short)annotation.Position.X);
                writer.WriteShort((short)annotation.Position.Y);
                writer.WriteShortPrefixedString(annotation.Name);
                writer.WriteByte(annotation.Icon);
            }
        }
    }
}