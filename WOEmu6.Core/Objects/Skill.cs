namespace WOEmu6.Core.Objects
{
    public class Skill : ObjectBase
    {
        public Skill(Skill parent, string name, float value, float maxValue, byte affinities = 0)
        {
            Parent = parent;
            Name = name;
            Value = value;
            MaxValue = maxValue;
            Affinities = affinities;
        }
        
        public Skill Parent { get; }
        
        public string Name { get; }
        
        public float Value { get; }
        
        public float MaxValue { get; }
        
        public byte Affinities { get; }

        protected override ObjectType Type => ObjectType.Skill;
    }
}