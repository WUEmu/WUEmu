namespace WOEmu6.Core.Objects
{
    public class WurmId
    {
        public WurmId(long id)
        {
            Value = id;
            Type = (ObjectType)((byte)(id & 0xFF));
            Origin = (short)((id >> 8) & 0xFFFF);
            Counter = id >> 24;
        }
        
        public long Value { get; }
        
        public ObjectType Type { get; }
        
        public short Origin { get; }
        
        public long Counter { get; }

        public (short, short) ToTileCoordinate() => (
            (short)((Value >> 32) & 0xFFFF),
            (short)((Value >> 16) & 0xFFFF)
        );

        public BorderDirection ToDirection() => (BorderDirection)((byte)((Value >> 8) & 0xF));

        public static implicit operator WurmId(long value) => new WurmId(value); 

        public override string ToString() => $"WurmId({Type}, {Origin}, {Counter:X12})";
    }
}