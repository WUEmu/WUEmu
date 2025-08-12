namespace WOEmu6.Core.Zones
{
    public class ZoneId
    {
        public ZoneId(uint id)
        {
            Value = id;
            X = (short)(id & 0xFFFF);
            Y = (short)((id >> 16) & 0xFFFF);
        }

        public ZoneId(short x, short y)
        {
            X = (short)(x / Zone.ZoneSize);
            Y = (short)(y / Zone.ZoneSize);
            Value = ((uint)((Y << 16) & 0xFFFF0000) | (uint)(X & 0xFFFF));
        }

        /// <summary>
        /// Create ZoneID based on spatial coordinate.
        /// </summary>
        /// <param name="x">The X coordinate</param>
        /// <param name="y">The Y coordinate</param>
        public ZoneId(float x, float y) : this((short)(x / 4), (short)(y/4))
        {
        }
        
        public short X { get; }
        
        public short Y { get; }
        
        public uint Value { get; }

        public static bool operator ==(ZoneId left, ZoneId right) => left?.Value == right?.Value;
        
        public static bool operator !=(ZoneId left, ZoneId right) => left?.Value != right?.Value;

        public override string ToString() => $"ZoneId({X},{Y},{Value:X8})";

        public override int GetHashCode() => Value.GetHashCode();

        public override bool Equals(object obj)
        {
            if (obj is ZoneId otherId)
                return otherId.Value == Value;
            return false;
        }
    }
}
