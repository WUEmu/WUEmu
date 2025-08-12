using System;
using MoonSharp.Interpreter;

namespace WOEmu6.Core.Timers
{
    [MoonSharpUserData]
    public class ScriptTimer : TimerBase
    {
        private readonly Closure _handler;

        public ScriptTimer(string name, int seconds, Closure handler)
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
