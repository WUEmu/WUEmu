using WOEmu6.Core.Packets;
using WOEmu6.Core.Scripting;

namespace WOEmu6.Core.Commands
{
    public class ReloadCommand : IChatCommand
    {
        public bool Execute(ClientSession client, string[] arguments)
        {
            var loader = new ScriptLoader(ServerContext.Instance.Value);
            // loader.Initialize();
            return true;
        }
    }
}