using System.Collections.Generic;
using MoonSharp.Interpreter;
using WOEmu6.Core.Packets.Server;
using WOEmu6.Core.Timers;

namespace WOEmu6.Core.Scripting
{
    [MoonSharpUserData]
    public class ScriptWorld
    {
        private readonly World _world;
        private readonly List<ScriptTimer> timers;

        public ScriptWorld(World world)
        {
            _world = world;
            timers = new List<ScriptTimer>();
        }

        public void SendMessage(string channel, string text) =>
            _world.BroadcastPacketToAllPlayers(new ServerMessagePacket(channel, text));
        
        public ScriptTimer TimerNew(string name, int seconds, Closure handler, bool runOnce = false)
        {
            var timer = new ScriptTimer(name, seconds, handler);
            timers.Add(timer);
            timer.RunOnce = runOnce;
            timer.Start();
            return timer;
        }

        public void TimerStop(ScriptTimer timer)
        {
            timers.Remove(timer);
            timer.Stop();
        }
    }
}
