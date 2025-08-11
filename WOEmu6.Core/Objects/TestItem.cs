namespace WOEmu6.Core.Objects
{
    public class TestItem : Item
    {
        public TestItem(string model, float size = 1.0f)
        {
            Id = new WurmId(ObjectType.Item, 0, 234);
            Model = model;
            SizeModifier = size;
        }

        public override string Name => "My Test Item";

        public override string HoverText => "HOvering";
        
        public override string Model { get; }

        public override float SizeModifier { get; }

        public override string Description => "A test item";
    }
}