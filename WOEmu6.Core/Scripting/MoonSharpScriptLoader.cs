using MoonSharp.Interpreter;
using MoonSharp.Interpreter.Loaders;

namespace WOEmu6.Core.Scripting
{
    public class MoonSharpScriptLoader : IScriptLoader
    {
        private readonly ScriptLoader loader;

        public MoonSharpScriptLoader(ScriptLoader loader)
        {
            this.loader = loader;
        }

        public object LoadFile(string file, Table globalContext)
        {
            var path = loader.GetPath(file);
            if (path == null)
                return null;

            return System.IO.File.ReadAllText(path);
        }

        public string ResolveFileName(string filename, Table globalContext) => filename;

        public string ResolveModuleName(string modname, Table globalContext) => modname;
    }
}