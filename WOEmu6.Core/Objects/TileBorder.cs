namespace WOEmu6.Core.Objects
{
    public class TileBorder : ObjectBase
    {
        public TileBorder(WurmId id)
        {
            Id = id;
        }
        
        protected override ObjectType Type => ObjectType.TileBorder;

        // public override string ToString() => $"TileBorder()";
    }
}
