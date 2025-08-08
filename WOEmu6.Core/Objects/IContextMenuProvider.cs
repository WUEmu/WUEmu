using System.Collections.Generic;
using WOEmu6.Core.Packets;
using WOEmu6.Core.Packets.Server;

namespace WOEmu6.Core.Objects
{
    public interface IContextMenuProvider
    {
        IList<ContextMenuEntry> GetContextMenu(ClientSession session);
    }
}
