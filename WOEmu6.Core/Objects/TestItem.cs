namespace WOEmu6.Core.Objects
{
    public class TestItem : Item
    {
        public TestItem(ServerContext context, string model, float size = 1.0f) : base(context)
        {
            Model = model;
            SizeModifier = size;
            WurmId = context.WurmIdGenerator.NewWurmId(ObjectType.Fence);
        }
        
        public override long WurmId { get; }

        public override string Name => "My Test Item";

        public override string HoverText => "HOvering";
        public override string Model { get; }

        public override float SizeModifier { get; }

        public override string Description => "A test item";
    }
}