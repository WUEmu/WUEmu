using System;
using System.Threading;
using Serilog;

namespace WOEmu6.Core.Timers
{
    public abstract class TimerBase
    {
        protected Timer timer;
        
        public abstract string Name { get; }
        
        public abstract string Description { get; }
        
        public abstract TimeSpan Interval { get; }
        
        public abstract void Run();

        protected virtual void AfterStopped()
        {
        }
        
        public bool RunOnce { get; set; }

        public virtual void Start()
        {
            timer = new Timer((c) =>
            {
                Run();
                if (RunOnce)
                    Stop();
            }, null, Interval, Interval);
        }

        public virtual void Stop()
        {
            timer.Dispose();
            timer = null;
            AfterStopped();
        }
    }
}
