using System.Collections.Generic;
using System.Linq;
using WOEmu6.Core.Packets;
using WOEmu6.Core.Packets.Server;

namespace WOEmu6.Core.Objects
{
    public abstract class ObjectBase : IContextMenuProvider
    {
        public WurmId Id { get; protected set; } 
        
        protected abstract ObjectType Type { get; }

        protected void GenerateId()
        {
            // Id = new WurmId(Type, Context.WurmIdGenerator.NewWurmId(Type));
        }

        public virtual IList<ContextMenuEntry> GetContextMenu(ClientSession session) =>
            new List<ContextMenuEntry>();

        public virtual void OnMenuItemClick(ClientSession session, short itemId)
        {
            // placeholder
        }

        public virtual string Description => $"You see a {Type}.";
    }
}
