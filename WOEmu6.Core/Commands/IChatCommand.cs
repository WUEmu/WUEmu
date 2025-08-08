using WOEmu6.Core.Packets;

namespace WOEmu6.Core.Commands
{
    public interface IChatCommand
    {
        bool Execute(ClientSession client, string[] arguments);
    }
}
