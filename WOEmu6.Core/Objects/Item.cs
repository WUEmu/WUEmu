namespace WOEmu6.Core.Objects
{
    public abstract class Item
    {
        protected ServerContext Context { get; }
        
        protected Item(ServerContext context)
        {
            Context = context;
        }
        
        public abstract long WurmId { get; }
        
        public abstract string Name { get; }
        
        public abstract string HoverText { get; }
        
        public abstract string Model { get; }

        public virtual byte Material { get; } = 0;
        
        public abstract string Description { get; }

        public virtual float SizeModifier { get; } = 1.0f;

        public virtual byte Rarity { get; } = 0;

        public virtual float Quality { get; } = 0;
        
        public virtual float Damage { get; } = 0;
    }
}
