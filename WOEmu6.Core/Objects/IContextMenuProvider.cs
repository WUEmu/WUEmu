using System.Collections.Generic;
using WOEmu6.Core.Packets;

namespace WOEmu6.Core.Objects
{
    public interface IContextMenuProvider
    {
        IEnumerable<string> GetContextMenu(ServerContext context, ClientSession session);
    }
}
