using System;
using System.Collections.Generic;
using System.Linq;
using Serilog;
using WOEmu6.Core.Objects;

namespace WOEmu6.Core.Timers
{
    public class ThinkTimer : WorldTimer
    {
        private readonly List<IThinkable> thinkables;
        private object thinkablesLock = new object();
        private int frame;

        public ThinkTimer()
        {
            thinkables = new List<IThinkable>();
        }
        
        public override string Name => "Object Think Timer";
        
        public override string Description => "Performs Think() logic";
        
        public override TimeSpan Interval => TimeSpan.FromMilliseconds(250);
        
        public override void Run()
        {
            IThinkable[] todo;
            lock (thinkablesLock)
                todo = thinkables.ToArray();
            
            foreach (var thinkable in todo)
                thinkable.Think(frame);
            frame++;
        }

        public void RegisterThinkable(IThinkable t)
        {
            lock (thinkablesLock)
            {
                thinkables.Add(t);
            }
        }

        public void DeregisterThinkable(IThinkable t)
        {
            lock (thinkablesLock)
            {
                thinkables.Remove(t);
            }
        }
    }
}