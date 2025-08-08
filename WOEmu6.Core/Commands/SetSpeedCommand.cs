using WOEmu6.Core.Packets;
using WOEmu6.Core.Packets.Server;

namespace WOEmu6.Core.Commands
{
    public class SetSpeedCommand : IChatCommand
    {
        public bool Execute(ServerContext context, ClientSession client, string[] arguments)
        {
            if (arguments.Length != 1)
                return false;
            
            var newSpeed = float.Parse(arguments[0]);
            client.Send(new SetSpeedPacket(newSpeed));
            return true;
        }
    }
}