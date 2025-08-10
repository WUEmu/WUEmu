using System.IO;
using System.Text.Json;
using Serilog;
using WOEmu6.Core.File;
using WOEmu6.Core.Objects;

namespace WOEmu6.Core
{
    public class World
    {
        private string basePath;
        private WorldConfiguration configuration;
        
        public World(string name = "default") //float spawnX, float spawnY)
        {
            Log.Information("Loading world {world}", name);
            
            basePath = Path.Combine("worlds", name);
            using (var fs = System.IO.File.Open(Path.Combine(basePath, "world.json"), FileMode.Open))
            {
                var reader = new StreamReader(fs);
                var contents = reader.ReadToEnd();
                configuration = JsonSerializer.Deserialize<WorldConfiguration>(contents);
            }
            
            SpawnX = configuration.SpawnX;
            SpawnY = configuration.SpawnY;
            
            TopLayer = configuration.SurfaceMeshFile != null ? new FileMesh(Path.Combine(basePath, configuration.SurfaceMeshFile)) : new ZoneTestMesh();
            CaveLayer = configuration.CaveMeshFile != null ? new FileMesh(Path.Combine(basePath, configuration.CaveMeshFile)) : new EmptyMesh();
            Flags = configuration.FlagMeshFile != null ? new FileMesh(Path.Combine(basePath, configuration.FlagMeshFile)) : new EmptyMesh();
            
            Objects = new ObjectGateway();
        }

        public float SpawnX { get; }
        
        public float SpawnY { get; }
        
        public IMesh CaveLayer { get; }
        
        public IMesh TopLayer { get; }
        
        public IMesh Flags { get; }
        
        public ObjectGateway Objects { get; }
    }
}
