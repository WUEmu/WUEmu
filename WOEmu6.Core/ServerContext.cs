using System;
using NLua;
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
            IncomingPacketFactory = new IncomingPacketFactory();
            Commands = new CommandRepository();
            WurmIdGenerator = new WurmIdGenerator(5_000);
            World = new World(1512.0f, 2148.0f);
        }
        
        public Lua Lua { get; }
        
        public IncomingPacketFactory IncomingPacketFactory { get; }
        
        public CommandRepository Commands { get; }
        
        
        public WurmIdGenerator WurmIdGenerator { get; }
        
        public World World { get; }
    }
}