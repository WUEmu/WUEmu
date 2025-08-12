using System.Collections.Generic;
using System.IO;
using NLua;
using Serilog;
using WOEmu6.Core.Timers;

namespace WOEmu6.Core.Scripting
{
    public class ScriptLoader
    {
        private readonly World world;
        private readonly Lua lua;
        // TODO: move to script host class
        private readonly List<ScriptTimer> timers;

        public ScriptLoader(ServerContext serverContext)
        {
            this.world = serverContext.World;
            this.lua = serverContext.Lua;
            timers = new List<ScriptTimer>();
        }

        public void Initialize()
        {
            lua.RegisterFunction("TimerNew", this, typeof(ScriptLoader).GetMethod("TimerNew"));
            lua["World"] = new ScriptWorld(world);
            
            LoadCreatures();
            // LoadSkills();
        }

        public void TimerNew(string name, int seconds, LuaFunction handler)
        {
            var timer = new ScriptTimer(name, seconds, handler);
            timers.Add(timer);
            timer.Start();
        }
        

        private void LoadConstants()
        {
            
        }

        private void LoadCreatures()
        {
            var basePath = Path.Combine(world.basePath, "scripts", "creatures");
            var scriptsDirectory = new DirectoryInfo(basePath);
            var scripts = scriptsDirectory.GetFiles("*.lua");

            foreach (var script in scripts)
            {
                lua.State.NewTable();
                lua.State.SetGlobal("Creature");
                lua.DoFile(script.FullName);
                // lua.State.GetGlobal("Creature");
                lua.State.GetGlobal("Creature");
                lua.State.PushString("name");
                lua.State.GetTable(-2);
                var name = lua.State.ToString(-1);
                lua.State.Pop(1);
                lua.State.SetGlobal(name);
                lua.State.PushNil();
                lua.State.SetGlobal("Creature");
                
                Log.Information("Loaded Creature: {creatureType}", name);
            }
        }

        private void LoadSkills()
        {
            var skillPath = Path.Combine(world.basePath, "scripts", "skills");
            var scriptsPath = new DirectoryInfo(skillPath);
            var scripts = scriptsPath.GetFiles("*.lua");

            foreach (var script in scripts)
            {
                //lua["Skill"] = null;
                lua.DoFile(script.FullName);
            }
        }
    }
}