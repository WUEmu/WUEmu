using System;
using WOEmu6.Core.Actions;
using WOEmu6.Core.Objects;
using WOEmu6.Core.Packets;
using WOEmu6.Core.Packets.Server;

namespace WOEmu6.Core.Timers
{
    public class ActionTimer<TTarget> : PlayerTimer
        where TTarget : ObjectBase 
    {
        private readonly TimedAction<TTarget> _action;
        private readonly TTarget _target;

        public ActionTimer(ClientSession client, TimedAction<TTarget> action, TTarget target) 
            : base(client)
        {
            _action = action;
            _target = target;
            RunOnce = true;
        }

        public override string Name => _action.GetType().Name;

        public override string Description => "TODO";
        
        public override TimeSpan Interval => _action.GetDuration(Client, _target);

        protected override void AfterStopped() => Client.Player.DeregisterTimer(this);

        public override void Run()
        {
            Client.Send(new SendActionPacket(-1, string.Empty, 0));
            _action.OnTimerFinished(Client, _target);
        }
    }
}
