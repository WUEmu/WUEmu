using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.FileSystemGlobbing;
using Microsoft.Extensions.FileSystemGlobbing.Abstractions;
using MoonSharp.Interpreter;
using Serilog;

namespace WOEmu6.Core.Scripting
{
    public class ScriptLoader
    {
        private readonly World world;
        private readonly string basePath;
        private readonly Dictionary<string, string> scripts;
        
        public ScriptLoader(ServerContext serverContext)
        {
            this.world = serverContext.World;
            basePath = Path.Combine(world.basePath, "scripts");
            scripts = new Dictionary<string, string>();
            UserData.RegisterAssembly(typeof(ScriptLoader).Assembly);
            CollectScripts();
        }

        public string GetPath(string scriptName)
        {
            if (!scripts.TryGetValue(scriptName, out var path))
            {
                Log.Error("Could not find script {name}", scriptName);
                return null;
            }

            return path;
        }
        
        private void CollectScripts()
        {
            scripts.Add("world", Path.Combine(basePath, "world.lua"));
            
            var matcher = new Matcher();
            matcher.AddInclude("**/**/main.lua");
            var files = matcher.Execute(new DirectoryInfoWrapper(new DirectoryInfo(basePath)));
            
            foreach (var script in files.Files)
            {
                var fullPath = Path.Combine(basePath, script.Path);
                var s = new Script();
                try
                {
                    s.DoFile(fullPath);
                }
                catch (ScriptRuntimeException)
                {
                }
                var ns = s.Globals.Get("Namespace").String;
                var scriptName = s.Globals.Get("Name").String;
                if (ns == null || scriptName == null)
                {
                    Log.Error("Script {path} does not contain a Namespace or Name global.", script.Path);
                    continue;
                }
                
                var fullName = $"{ns}.{scriptName}";
                scripts.Add(fullName, fullPath);
                Log.Debug("Collected script: {fullName}", fullName);
            }
        }
    }
}