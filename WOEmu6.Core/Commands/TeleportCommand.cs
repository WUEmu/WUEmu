using System;
using WOEmu6.Core.Packets;
using WOEmu6.Core.Packets.Server;

namespace WOEmu6.Core.Commands
{
    public class TeleportCommand : IChatCommand
    {
        public bool Execute(ServerContext context, ClientSession client, string[] arguments)
        {
            if (arguments.Length != 2)
                return false;
            
            client.Send(new TeleportPacket(float.Parse(arguments[0]), float.Parse(arguments[1]), 10, 0, true, true, true, 4));
            
            // throw new System.NotImplementedException();
            Console.WriteLine($"Going to {arguments[0]} {arguments[1]}");
            return true;
        }
    }
}