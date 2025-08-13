using WOEmu6.Core.Network;
using WOEmu6.Core.Objects;

namespace WOEmu6.Core.Packets.Client
{
    public class ClientMessagePacket : IIncomingPacket
    {
        public byte Opcode => 0x63;
        
        public bool AllowAnonymous => false;

        public string Channel { get; private set; }

        public string Text { get; private set; }

        public void Read(PacketReader reader)
        {
            Text = reader.ReadBytePrefixedString();
            Channel = reader.ReadBytePrefixedString();
        }

        public void Handle(ClientSession client)
        {
            client.Player.World.PlayerChat(new ChatMessage(client.Player, Channel, Text));
        }
    }
}