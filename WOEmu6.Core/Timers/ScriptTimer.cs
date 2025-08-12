using System;
using NLua;

namespace WOEmu6.Core.Timers
{
    public class ScriptTimer : TimerBase
    {
        private readonly LuaFunction _handler;

        public ScriptTimer(string name, int seconds, LuaFunction handler)
        {
            _handler = handler;
            Name = name;
            Description = string.Empty;
            Interval = TimeSpan.FromSeconds(seconds);
        }
        
        public override string Name { get; }
        
        public override string Description { get; }
        
        public override TimeSpan Interval { get; }
        
        public override void Run()
        {
            _handler.Call();
        }
    }
}
