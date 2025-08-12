namespace WOEmu6.Core.Commands
{
    public class ScriptCommand : IChatCommand
    {
        public bool Execute(ClientSession client, string[] arguments)
        {
            return true;
        }
    }
}