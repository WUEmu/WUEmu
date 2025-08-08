namespace WOEmu6.Core.Objects
{
    public abstract class Item : ObjectBase
    {
        public abstract string Name { get; }
        
        public abstract string HoverText { get; }
        
        public abstract string Model { get; }

        public virtual byte Material { get; } = 0;
        
        public abstract string Description { get; }

        public virtual float SizeModifier { get; } = 1.0f;

        public virtual byte Rarity { get; } = 0;

        public virtual float Quality { get; } = 0;
        
        public virtual float Damage { get; } = 0;

        protected override ObjectType Type => ObjectType.Item;
    }
}
