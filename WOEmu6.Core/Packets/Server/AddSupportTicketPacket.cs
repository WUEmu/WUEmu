using System;
using System.Collections.Generic;
using WOEmu6.Core.Network;

namespace WOEmu6.Core.Packets.Server
{
    public class SupportTicketAction
    {
        public SupportTicketAction(int actionId, string caption, string description)
        {
            ActionId = actionId;
            Caption = caption;
            Description = description;
        }

        public int ActionId { get; }

        public string Caption { get; }

        public string Description { get; }
    }

    public class AddSupportTicketPacket : IOutgoingPacket
    {
        public AddSupportTicketPacket(long ticketId, SupportTicketCategory category, string contents, ColorCode color,
            string description, SupportTicketAction[] actions = null)
        {
            TicketId = ticketId;
            Category = category;
            Contents = contents;
            Color = color;
            Description = description;
            Actions = actions ?? Array.Empty<SupportTicketAction>();
        }

        public byte Opcode => 0xDE;

        public long TicketId { get; }

        public SupportTicketCategory Category { get; }

        public string Contents { get; }

        public ColorCode Color { get; }

        public string Description { get; }

        public SupportTicketAction[] Actions { get; }

        public void Write(ServerContext context, PacketWriter writer)
        {
            writer.WriteInt(1);
            writer.WriteLong(TicketId);
            writer.WriteByte((byte)Category);
            writer.WriteBytePrefixedString(Contents);
            writer.WriteByte((byte)Color);
            writer.WriteShortPrefixedString(Description);

            writer.WriteByte((byte)Actions.Length);
            foreach (var action in Actions)
            {
                writer.WriteInt(action.ActionId);
                writer.WriteBytePrefixedString(action.Caption);
                writer.WriteBytePrefixedString(action.Description);
            }
        }
    }
}