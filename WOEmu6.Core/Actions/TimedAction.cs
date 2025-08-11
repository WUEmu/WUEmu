using System;
using WOEmu6.Core.Objects;
using WOEmu6.Core.Packets;
using WOEmu6.Core.Packets.Server;
using WOEmu6.Core.Timers;

namespace WOEmu6.Core.Actions
{
    /// <summary>
    /// A player action that has a time to finish.
    /// </summary>
    public abstract class TimedAction<TTarget> : PlayerAction<TTarget>
        where TTarget : ObjectBase
    {
        private ActionTimer<TTarget> actionTimer;
        
        public abstract TimeSpan GetDuration(ClientSession client, TTarget target);
        
        public override void Execute(ClientSession client, TTarget target)
        {
            actionTimer = new ActionTimer<TTarget>(client, this, target);
            var duration = GetDuration(client, target);
            var actionText = GetActionText(client, target);
            client.Send(new SendActionPacket(-1, actionText, (short)duration.TotalSeconds));
            client.Player.RegisterTimer(actionTimer);
        }

        public abstract void OnTimerFinished(ClientSession client, TTarget target);
    }
}
