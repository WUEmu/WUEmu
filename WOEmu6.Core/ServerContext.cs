using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using WOEmu6.Core.Commands;
using WOEmu6.Core.Configuration;
using WOEmu6.Core.Objects;
using WOEmu6.Core.Packets.Client;
using WOEmu6.Core.Scripting;
using WOEmu6.Core.Threading;
using WOEmu6.Core.Utilities;
using WUEmu.Persistence;

namespace WOEmu6.Core
{
    public class ServerContext
    {
        public static readonly Lazy<ServerContext> Instance = new Lazy<ServerContext>(() => new ServerContext());
        
        private ServerContext()
        {
            var loader = new ConfigFileLoader("server.json");
            Configuration = loader.GetConfig<ServerConfiguration>();
            SteamAuthenticator = new SteamAuthenticator();
            DatabaseFactory = WurmDbContext.CreatePool(Configuration.Database);
            
            Threads = new ThreadManager();
            IncomingPacketFactory = new IncomingPacketFactory();
            Commands = new CommandRepository();
            WurmIdGenerator = new WurmIdGenerator(5_000);
            World = new World(Configuration.DataPath, Configuration.World ?? "default");
            //World.SetId(DatabaseFactory.CreateDbContext());
            ScriptLoader = new ScriptLoader(this);
            ScriptWorld = new ScriptWorld(World, ScriptLoader);
        }
        
        public PooledDbContextFactory<WurmDbContext> DatabaseFactory { get; }
        
        public ServerConfiguration Configuration { get; }
        
        public IncomingPacketFactory IncomingPacketFactory { get; }
        
        public CommandRepository Commands { get; }
        
        public WurmIdGenerator WurmIdGenerator { get; }
        
        public World World { get; }
        
        public ScriptLoader ScriptLoader { get; }
        
        public ScriptWorld ScriptWorld { get; }
        
        public ThreadManager Threads { get; }
        
        public SteamAuthenticator SteamAuthenticator { get; }
    }
}
