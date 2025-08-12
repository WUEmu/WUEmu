using MoonSharp.Interpreter;
using Serilog;
using WOEmu6.Core.BML;
using WOEmu6.Core.Packets.Server;
using WOEmu6.Core.Utilities;

namespace WOEmu6.Core.Scripting
{
    /// <summary>
    /// Wrapper around the Script object that populates everything for WUEmu.
    /// </summary>
    public class GameScript
    {
        public GameScript(string gameObject)
        {
            Script = new Script();
            GameObject = new Table(Script);
            Script.Globals[gameObject] = GameObject;
            Script.Globals["World"] = ServerContext.Instance.Value.ScriptWorld;
            Script.Globals["BmlForm"] = typeof(BmlForm);
            Script.Globals["ItemIcon"] = EnumToLuaTable.Create<ItemIcon>(Script);
            Script.Options.DebugPrint = str => Log.Information("<{str}>", str);
            Script.Options.ScriptLoader = new MoonSharpScriptLoader(ServerContext.Instance.Value.ScriptLoader);
        }
        
        public Script Script { get; }
        
        public Table GameObject { get; }

        public static implicit operator Script(GameScript s) => s.Script;
    }
}