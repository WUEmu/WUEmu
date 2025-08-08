using System;
using WOEmu6.Core.Objects;
using WOEmu6.Core.Packets;
using WOEmu6.Core.Packets.Server;

namespace WOEmu6.Core.Commands
{
    public class SpawnItem : IChatCommand
    {
        public bool Execute(ServerContext context, ClientSession client, string[] arguments)
        {
//            Console.WriteLine("{0:X}", (sbyte)-9);
            if (arguments.Length == 0)
                return false;

            var model = arguments[0];
            var size = 1.0f;
            if (arguments.Length == 2)
                size = float.Parse(arguments[1]);

            client.Send(new PlaceItemPacket(new TestItem(context, model, size), client.Player.X, client.Player.Y, client.Player.Z));
            return true;
        }
    }
}