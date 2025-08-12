using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Serilog;
using WOEmu6.Core.File;
using WOEmu6.Core.Objects;
using WOEmu6.Core.Packets.Server;
using WOEmu6.Core.Timers;
using WOEmu6.Core.Zones;

namespace WOEmu6.Core
{
    public class World
    {
        public string basePath;
        private WorldConfiguration configuration;
        private List<WorldTimer> timers;
        private object timerLock = new object();

        private List<Player> allPlayers;
        private object allPlayersLock = new object();

        private Dictionary<WurmId, Item> allItems;
        private object allItemsLock = new object();

        public World(string name = "default") //float spawnX, float spawnY)
        {
            Log.Information("Loading world {world}", name);

            allPlayers = new List<Player>();
            allItems = new Dictionary<WurmId, Item>();
            
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
            TopLayer = new ZoneTestMesh(); //configuration.SurfaceMeshFile != null ? new FileMesh(this, Path.Combine(basePath, configuration.SurfaceMeshFile)) : new ZoneTestMesh();
            CaveLayer = configuration.CaveMeshFile != null ? new FileMesh(this, Path.Combine(basePath, configuration.CaveMeshFile)) : new EmptyMesh();
            Flags = configuration.FlagMeshFile != null ? new FileMesh(this, Path.Combine(basePath, configuration.FlagMeshFile)) : new EmptyMesh();
            
            AllObjects = new ObjectPool();
            Objects = new ObjectGateway(AllObjects);
            ZoneManager = new ZoneManager(this, TopLayer);
        }

        public float SpawnX { get; }
        
        public float SpawnY { get; }
        
        public IMesh CaveLayer { get; }
        
        public IMesh TopLayer { get; }
        
        public IMesh Flags { get; }
        
        public ObjectGateway Objects { get; }
        
        public ZoneManager ZoneManager { get; }
        
        public ObjectPool AllObjects { get; }

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

        public void BroadcastPacketToAllPlayers(IOutgoingPacket packet)
        {
            Player[] currentPlayers;
            lock (allPlayersLock)
                currentPlayers = allPlayers.ToArray();
            
            foreach (var player in currentPlayers)
                player.Client.Send(packet);
        }

        public void PlayerJoined(Player player)
        {
            lock (allPlayersLock)
                allPlayers.Add(player);
        }

        public void PlayerDisconnected(Player player)
        {
            lock (allPlayersLock)
                allPlayers.Remove(player);
        }

        public void RegisterItem(Item item)
        {
            lock (allItemsLock)
            {
                if (!allItems.TryAdd(item.Id, item))
                    return;
            }

            Log.Debug("New item registered: {name}, id={id}", item.Name, item.Id);
        }

        public void DeregisterItem(Item item)
        {
            lock (allItemsLock)
                allItems.Remove(item.Id);
            Log.Debug("Item deregistered: {name}, id={id}", item.Name, item.Id);
        }

        public Item GetItem(WurmId id)
        {
            lock (allItemsLock)
            {
                if (allItems.TryGetValue(id, out var item))
                    return item;
            }

            return null;
        }
    }
}
