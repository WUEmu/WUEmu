namespace WOEmu6.Core.Objects
{
    public abstract class Item : ObjectBase
    {
        protected Item(WurmId id)
        {
            Id = id;
        }

        protected Item() : this(ServerContext.Instance.Value.WurmIdGenerator.NewWurmId(ObjectType.Item))
        {
        }
        
        public string Name { get; set; }
        
        public string CustomName { get; set; } 
        
        public string HoverText { get; set; }
        
        public string Model { get; set; }

        public byte Material { get; set; } = 38;
        
        public short Icon { get; set; }
        
        public string Description { get; set; }
 
        public float SizeModifier { get; set; } = 1.0f;

        public byte Rarity { get; set; } = 0;

        public float Quality { get; set; } = 0;
        
        public float Damage { get; set; } = 0;

        protected override ObjectType Type => ObjectType.Item;
    }
}
