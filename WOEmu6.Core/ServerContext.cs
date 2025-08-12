using System;
using WOEmu6.Core.Commands;
using WOEmu6.Core.Objects;
using WOEmu6.Core.Packets.Client;
using WOEmu6.Core.Scripting;

namespace WOEmu6.Core
{
    public class ServerContext
    {
        public static readonly Lazy<ServerContext> Instance = new Lazy<ServerContext>(() => new ServerContext());
        
        private ServerContext()
        {
            IncomingPacketFactory = new IncomingPacketFactory();
            Commands = new CommandRepository();
            WurmIdGenerator = new WurmIdGenerator(5_000);
            // World = new World(1436.0f, 2344.0f);
            // World = new World(1600.0f, 2000.0f);
            World = new World("default");
            ScriptLoader = new ScriptLoader(this);
            ScriptWorld = new ScriptWorld(World);
        }
        
        public IncomingPacketFactory IncomingPacketFactory { get; }
        
        public CommandRepository Commands { get; }
        
        public WurmIdGenerator WurmIdGenerator { get; }
        
        public World World { get; }
        
        public ScriptLoader ScriptLoader { get; }
        
        public ScriptWorld ScriptWorld { get; }
    }
}