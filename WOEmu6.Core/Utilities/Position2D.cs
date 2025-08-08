namespace WOEmu6.Core.Utilities
{
    public class Position2D<TCoordinate>
    {
        public Position2D(TCoordinate x, TCoordinate y)
        {
            X = x;
            Y = y;
        }
        
        public TCoordinate X { get; }
        
        public TCoordinate Y { get; }
    }
}