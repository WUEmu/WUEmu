using System.Threading.Tasks;
using WOEmu6.Core.Commands;
using WOEmu6.Core.File;
using WOEmu6.Core.Objects;
using WOEmu6.Core.Packets.Client;

namespace WOEmu6.Core
{
    public class ServerContext
    {
        public ServerContext()
        {
            IncomingPacketFactory = new IncomingPacketFactory();
            Commands = new CommandRepository();
            WurmIdGenerator = new WurmIdGenerator(5_000);

            // var maps = new[] { "top_layer.map", "map_cave.map", "flags.map" };
            // var result = Parallel.ForEach(maps, map =>
            // {
                // var mesh = new MeshFileReader(map);
                // mesh.Load();
            // });

            TopLayer = new MeshFileReader("top_layer.map");
            TopLayer.Load();
            
            CaveLayer = new MeshFileReader("map_cave.map");
            CaveLayer.Load();
            
            Flags = new MeshFileReader("flags.map");
            Flags.Load();

            Objects = new ObjectGateway(this);
        }
        
        public MeshFileReader CaveLayer { get; }
        
        public MeshFileReader TopLayer { get; }
        
        public MeshFileReader Flags { get; }
        
        public IncomingPacketFactory IncomingPacketFactory { get; }
        
        public CommandRepository Commands { get; }
        
        public ObjectGateway Objects { get; }
        
        public WurmIdGenerator WurmIdGenerator { get; }
    }
}