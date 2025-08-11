using WOEmu6.Core.Objects;
using WOEmu6.Core.Packets;

namespace WOEmu6.Core.Actions
{
    /// <summary>
    /// Base class for all actions that can be performed by a player.
    /// </summary>
    public abstract class PlayerAction<TTarget> 
        where TTarget : ObjectBase
    {
        public abstract short ActionId { get; }
        
        public abstract string GetActionText(ClientSession client, TTarget target);
        
        public abstract void Execute(ClientSession client, TTarget target);
    }
}
