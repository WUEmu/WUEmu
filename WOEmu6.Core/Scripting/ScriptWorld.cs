using System.Collections.Generic;
using System.Net;
using MoonSharp.Interpreter;
using Serilog;
using WOEmu6.Core.Packets.Server;
using WOEmu6.Core.Timers;

namespace WOEmu6.Core.Scripting
{
    [MoonSharpUserData]
    public class ScriptWorld
    {
        private readonly Script script;
        private readonly Table scriptObject; 
        private readonly World _world;
        private readonly List<ScriptTimer> timers;

        public ScriptWorld(World world, ScriptLoader loader)
        {
            _world = world;
            script = new Script();
            scriptObject = new Table(script);
            script.Globals["World"] = scriptObject;
            script.Options.DebugPrint = str => Log.Information("[WORLD] <{str}>", str);
            script.Options.ScriptLoader = new MoonSharpScriptLoader(loader);
            script.DoFile("world");
            timers = new List<ScriptTimer>();

            world.OnPlayerJoined += (sender, player) =>
            {
                var fn = scriptObject.Get("OnPlayerJoined").Function;
                fn.Call(this, player);
            };


            world.OnPlayerChat += (sender, message) =>
            {
                var fn = scriptObject.Get("OnPlayerChat").Function;
                fn.Call(this, message);
            };
        }

        public void SendMessage(string channel, string text, float r = 1.0f, float g = 1.0f, float b = 1.0f) =>
            _world.BroadcastPacketToAllPlayers(new ServerMessagePacket(channel, text, (byte)(r * 255), (byte)(g * 255), (byte)(b * 255)));
        
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
