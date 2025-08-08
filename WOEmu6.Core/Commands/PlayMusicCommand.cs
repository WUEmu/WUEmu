using System;
using WOEmu6.Core.Packets;
using WOEmu6.Core.Packets.Server;

namespace WOEmu6.Core.Commands
{
    public class PlayMusicCommand : IChatCommand
    {
        public bool Execute(ServerContext context, ClientSession client, string[] arguments)
        {
            if (arguments.Length != 1)
                return false;
            
            Console.WriteLine($"Playing music: {arguments[0]}");
            client.Send(new PlayMusicPacket(arguments[0], client.Player.X, client.Player.Y, client.Player.Z, 1, 1, 1));
            return true;
        }
    }
}