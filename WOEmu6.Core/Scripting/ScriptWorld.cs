using WOEmu6.Core.Packets.Server;

namespace WOEmu6.Core.Scripting
{
    public class ScriptWorld
    {
        private readonly World _world;

        public ScriptWorld(World world)
        {
            _world = world;
        }
        
        public void SendMessage(string channel, string text)
        {
            var toSend = _world.players.ToArray();
            foreach (var player in toSend)
                player.Client.Send(new ServerMessagePacket(channel, text));
        }
    }
}
