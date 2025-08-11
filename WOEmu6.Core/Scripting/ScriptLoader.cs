using System.IO;
using IronPython.Modules;
using NLua;
using Serilog;

namespace WOEmu6.Core.Scripting
{
    public class ScriptLoader
    {
        private readonly World world;
        private readonly Lua lua;

        public ScriptLoader(ServerContext serverContext)
        {
            this.world = serverContext.World;
            this.lua = serverContext.Lua;
        }

        public void Initialize()
        {
            LoadCreatures();
            // LoadSkills();
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