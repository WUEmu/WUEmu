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

    public class Position3D<TCoordinate> : Position2D<TCoordinate>
    {
        public Position3D(TCoordinate x, TCoordinate y, TCoordinate z) 
            : base(x, y)
        {
            Z = z;
        }

        public TCoordinate Z { get; }
    }
}