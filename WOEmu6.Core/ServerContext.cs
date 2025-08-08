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

            TopLayer = new MeshFileReader("top_layer.map");
            TopLayer.Load();

            Flags = new MeshFileReader("flags.map");
            Flags.Load();
        }
        
        public MeshFileReader TopLayer { get; }
        
        public MeshFileReader Flags { get; }
        
        public IncomingPacketFactory IncomingPacketFactory { get; }
        
        public CommandRepository Commands { get; }
        
        public WurmIdGenerator WurmIdGenerator { get; }
    }
}