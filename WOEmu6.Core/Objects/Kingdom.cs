using MoonSharp.Interpreter;

namespace WOEmu6.Core.Objects
{
    [MoonSharpUserData]
    public class Kingdom
    {
        public Kingdom(byte id, string name, string suffix = "default")
        {
            Id = id;
            Name = name;
            Suffix = suffix;
        }
        
        public byte Id { get; }
        
        public string Name { get; }
        
        public string Suffix { get; }
        
    }
}
