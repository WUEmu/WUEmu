using WOEmu6.Core.Packets.Server;
using WOEmu6.Core.Utilities;

namespace WOEmu6.Core.Objects
{
    public class MapAnnotation
    {
        public MapAnnotation(long id, MapAnnotationType type, Position2D<int> position, string name, string server, byte icon)
        {
            Id = id;
            Type = type;
            Position = position;
            Name = name;
            Server = server;
            Icon = icon;
        }
        
        public long Id { get; set; }
        
        public MapAnnotationType Type { get; set; }
        
        public string Name { get; set; }
        
        public string Server { get; set; }
        
        public Position2D<int> Position { get; set; }
        
        public byte Icon { get; set; }
    }
}