using WOEmu6.Core.Packets;
using WOEmu6.Core.Packets.Server;

namespace WOEmu6.Core.Commands
{
    public class FarTilesCommand : IChatCommand
    {
        public bool Execute(ClientSession client, string[] arguments)
        {
            // /fartiles relX relY w h
            if (arguments.Length != 4)
                return false;

            var tileX = (short)(client.Player.X / 4);
            var tileY = (short)(client.Player.Y / 4);
            client.Send(new FarTileChunkPacket((short)(tileX + short.Parse(arguments[0])), (short)(tileY + short.Parse(arguments[1])), short.Parse(arguments[2]), short.Parse(arguments[3])));
            return true;
        }
    }
}