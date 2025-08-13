using System;
using WO.Core;
using WOEmu6.Core.Network;
using WOEmu6.Core.Packets.Server;

namespace WOEmu6.Core.Packets.Client
{
    public class ClientMessagePacket : IIncomingPacket
    {
        public byte Opcode => 0x63;
        
        public string Channel { get; private set; }
        
        public string Text { get; private set; }
        
        public void Read(PacketReader reader)
        {
            Text = reader.ReadBytePrefixedString();
            Channel = reader.ReadBytePrefixedString();
        }

        public void Handle(ClientSession client)
        {
            Console.WriteLine("[{0}/{1}] {2}", client.Player.Name, Channel, Text);

            if (Text.StartsWith("/"))
            {
                var tokens = Text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var cmd = ServerContext.Instance.Value.Commands.GetCommand(tokens[0]);
                if (cmd == null)
                    client.Send(new ServerMessagePacket(":Event", $"Unrecognized command '{Text}'.", 255, 0, 0));
                else
                    cmd.Execute(client, tokens[1..]);
            }

            client.Send(new ServerMessagePacket(":Event", $"You said: '{Text}'", 255, 0, 0, MessageType.OnScreenInfo));
            client.Send(new ServerMessagePacket(":Server", $"TEsting"));
        }
    }
}