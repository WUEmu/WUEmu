using System.IO;
using NLua;

namespace WOEmu6.Core.Scripting
{
    public class ScriptLoader
    {
        private readonly Lua lua;
        private readonly string scriptRoot;

        public ScriptLoader(Lua lua, string scriptRoot)
        {
            this.lua = lua;
            this.scriptRoot = scriptRoot;
        }

        public void Initialize()
        {
            // LoadSkills();
        }

        private void LoadSkills()
        {
            var skillPath = Path.Combine(scriptRoot, "skills");
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