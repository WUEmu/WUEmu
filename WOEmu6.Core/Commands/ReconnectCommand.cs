using WOEmu6.Core.Packets;
using WOEmu6.Core.Packets.Server;

namespace WOEmu6.Core.Commands
{
    public class ReconnectCommand : IChatCommand
    {
        public bool Execute(ClientSession client, string[] arguments)
        {
            client.Send(new ReconnectPacket("127.0.0.1", 3724, string.Empty));
            return true;
        }
    }
}