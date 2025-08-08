using WOEmu6.Core.File;
using WOEmu6.Core.Objects;

namespace WOEmu6.Core
{
    public class World
    {
        public World()
        {
            TopLayer = new Mesh("top_layer.map");
            TopLayer.Load();
            
            CaveLayer = new Mesh("map_cave.map");
            CaveLayer.Load();
            
            Flags = new Mesh("flags.map");
            Flags.Load();
            
            Objects = new ObjectGateway();
        }
        
        public Mesh CaveLayer { get; }
        
        public Mesh TopLayer { get; }
        
        public Mesh Flags { get; }
        
        public ObjectGateway Objects { get; }
    }
}
