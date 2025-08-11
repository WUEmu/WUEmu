using System;
using NLua;
using Serilog;
using WOEmu6.Core.Commands;
using WOEmu6.Core.Objects;
using WOEmu6.Core.Packets.Client;

namespace WOEmu6.Core
{
    public class ServerContext
    {
        public static readonly Lazy<ServerContext> Instance = new Lazy<ServerContext>(() => new ServerContext());
        
        private ServerContext()
        {
            Lua = new Lua();
            Lua["print"] = (string str) => Log.Information(str);
            
            IncomingPacketFactory = new IncomingPacketFactory();
            Commands = new CommandRepository();
            WurmIdGenerator = new WurmIdGenerator(5_000);
            // World = new World(1436.0f, 2344.0f);
            // World = new World(1600.0f, 2000.0f);
            World = new World("default");
        }
        
        public Lua Lua { get; }
        
        public IncomingPacketFactory IncomingPacketFactory { get; }
        
        public CommandRepository Commands { get; }
        
        
        public WurmIdGenerator WurmIdGenerator { get; }
        
        public World World { get; }
    }
}