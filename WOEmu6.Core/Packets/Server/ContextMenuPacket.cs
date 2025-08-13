using System.Collections.Generic;
using WOEmu6.Core.Network;

namespace WOEmu6.Core.Packets.Server
{
    public class ContextMenuEntry
    {
        public short Id { get; }
        public string Caption { get; }

        public ContextMenuEntry(short id, string caption)
        {
            Id = id;
            Caption = caption;
        }
    }

    public class ContextMenuPacket : IOutgoingPacket
    {
        public ContextMenuPacket(byte requestId, IList<ContextMenuEntry> menuItems, string wikiPage = null)
        {
            RequestId = requestId;
            MenuItems = menuItems;
            WikiPage = wikiPage ?? string.Empty;
        }

        public byte Opcode => 0x14;

        public byte RequestId { get; }

        public IList<ContextMenuEntry> MenuItems { get; }

        public string WikiPage { get; }

        public void Write(ServerContext context, PacketWriter writer)
        {
            writer.WriteByte(RequestId);
            writer.WriteByte((byte)MenuItems.Count);
            foreach (var entry in MenuItems)
            {
                writer.WriteShort(entry.Id);
                writer.WriteBytePrefixedString(entry.Caption);
                writer.WriteByte((byte)0); // ?
            }

            writer.WriteBytePrefixedString(WikiPage);
        }
    }
}