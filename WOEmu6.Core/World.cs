using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Serilog;
using WOEmu6.Core.File;
using WOEmu6.Core.Objects;
using WOEmu6.Core.Timers;

namespace WOEmu6.Core
{
    public class World
    {
        public string basePath;
        private WorldConfiguration configuration;
        private List<WorldTimer> timers;
        private object timerLock = new object();

        // TODO: this must be zoned in the future
        public Dictionary<long, Creature> creatures;
        public object creaturesLock = new object();

        public List<Player> players;
        public object playerLock = new object();
        
        public World(string name = "default") //float spawnX, float spawnY)
        {
            Log.Information("Loading world {world}", name);

            creatures = new Dictionary<long, Creature>();
            players = new List<Player>();
            
            basePath = Path.Combine("worlds", name);
            using (var fs = System.IO.File.Open(Path.Combine(basePath, "world.json"), FileMode.Open))
            {
                var reader = new StreamReader(fs);
                var contents = reader.ReadToEnd();
                configuration = JsonSerializer.Deserialize<WorldConfiguration>(contents);
            }
            
            SpawnX = configuration.SpawnX;
            SpawnY = configuration.SpawnY;

            timers = new List<WorldTimer>();
            TopLayer = configuration.SurfaceMeshFile != null ? new FileMesh(this, Path.Combine(basePath, configuration.SurfaceMeshFile)) : new ZoneTestMesh();
            CaveLayer = configuration.CaveMeshFile != null ? new FileMesh(this, Path.Combine(basePath, configuration.CaveMeshFile)) : new EmptyMesh();
            Flags = configuration.FlagMeshFile != null ? new FileMesh(this, Path.Combine(basePath, configuration.FlagMeshFile)) : new EmptyMesh();
            
            Objects = new ObjectGateway();
        }

        public float SpawnX { get; }
        
        public float SpawnY { get; }
        
        public IMesh CaveLayer { get; }
        
        public IMesh TopLayer { get; }
        
        public IMesh Flags { get; }
        
        public ObjectGateway Objects { get; }

        public void RegisterTimer(WorldTimer timer, bool startImmediately = true)
        {
            Log.Debug("Registered world timer {timer}, runs every {interval}", timer.Name, timer.Interval);
            
            lock (timerLock)
            {
                timers.Add(timer);
            }
            
            if (startImmediately)
                timer.Start();
        }
    }
}
