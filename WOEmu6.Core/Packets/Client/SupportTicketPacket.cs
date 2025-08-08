using WO.Core;
using WOEmu6.Core.Packets.Server;

namespace WOEmu6.Core.Packets.Client
{
    public class SupportTicketPacket : IIncomingPacket
    {
        public byte Opcode => 0xDE;
        
        public byte TicketCategory { get; private set; }
        
        public string Contents { get; private set; }
        
        public void Read(PacketReader reader)
        {
            TicketCategory = reader.ReadByte();
            Contents = reader.ReadBytePrefixedString();
        }

        public void Handle(ClientSession client)
        {
            client.Send(new AddSupportTicketPacket(
                0x9023844,
                SupportTicketCategory.Closed,
                Contents,
                ColorCode.NavyBlue,
                "This is a test response"
            ));
        }
    }
}