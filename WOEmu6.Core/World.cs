using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Serilog;
using WOEmu6.Core.Configuration;
using WOEmu6.Core.File;
using WOEmu6.Core.Objects;
using WOEmu6.Core.Packets.Server;
using WOEmu6.Core.Timers;
using WOEmu6.Core.Zones;
using WUEmu.Persistence;
using WUEmu.Persistence.Entities;

namespace WOEmu6.Core
{
    public class World
    {
        private readonly string _name;
        public readonly string basePath;
        private readonly WorldConfiguration configuration;
        private readonly List<WorldTimer> timers;
        private readonly object timerLock = new object();

        private readonly List<Player> allPlayers;
        private readonly object allPlayersLock = new object();

        public event EventHandler<Player> OnPlayerJoined;
        
        public event EventHandler<Player> OnPlayerLeft;
        
        public event EventHandler<ChatMessage> OnPlayerChat;

        public World(string dataPath, string name = "default") //float spawnX, float spawnY)
        {
            _name = name;
            Log.Information("Loading world {world}", name);

            allPlayers = new List<Player>();
            basePath = Path.Combine(dataPath, "worlds", name);
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
            CaveLayer = configuration.CaveMeshFile != null ? new FileMesh(this, Path.Combine(basePath, "mesh", configuration.CaveMeshFile)) : new EmptyMesh();
            Flags = configuration.FlagMeshFile != null ? new FileMesh(this, Path.Combine(basePath, "mesh", configuration.FlagMeshFile)) : new EmptyMesh();
            
            AllObjects = new ObjectPool();
            Objects = new ObjectGateway(AllObjects);
            ZoneManager = new ZoneManager(this, TopLayer);
            ThinkTimer = new ThinkTimer();
            RegisterTimer(ThinkTimer);
        }
        
        public int WorldId { get; private set; }

        public float SpawnX { get; }
        
        public float SpawnY { get; }
        
        public IMesh CaveLayer { get; }
        
        public IMesh TopLayer { get; }
        
        public IMesh Flags { get; }
        
        public ObjectGateway Objects { get; }
        
        public ZoneManager ZoneManager { get; }
        
        public ObjectPool AllObjects { get; }
        
        public ThinkTimer ThinkTimer { get; }

        public void SetId(WurmDbContext db)
        {
            var existingWorld = db.Worlds.SingleOrDefault(w => w.Name == _name);
            if (existingWorld == null)
            {
                var res = db.Worlds.Add(new WorldData { Name = _name });
                db.SaveChanges(); 
                WorldId = res.Entity.WorldId;
            }
            else
                WorldId = existingWorld.WorldId;
            
            Log.Debug("World has ID {id}", WorldId);
        }

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
            OnPlayerJoined?.Invoke(this, player);
        }

        public void PlayerDisconnected(Player player)
        {
            lock (allPlayersLock)
                allPlayers.Remove(player);
            OnPlayerLeft?.Invoke(this, player);
        }

        public void RegisterItem(Item item)
        {
            AllObjects.AddItem(item);
            Log.Debug("New item registered: {name}, id={id}", item.Name, item.Id);
        }

        public void DeregisterItem(Item item)
        {
            AllObjects.RemoveItem(item);
            Log.Debug("Item deregistered: {name}, id={id}", item.Name, item.Id);
        }

        public Item GetItem(WurmId id) => AllObjects.GetItem(id);

        public void PlayerChat(ChatMessage message)
        {
            if (message.Text.StartsWith("/"))
            {
                var tokens = message.Text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var cmd = ServerContext.Instance.Value.Commands.GetCommand(tokens[0]);
                if (cmd == null)
                    message.Sender.Client.Send(new ServerMessagePacket(":Event", $"Unrecognized command '{message.Text}'.", 255, 0, 0));
                else
                    cmd.Execute(message.Sender.Client, tokens[1..]);
                return;
            }
            
            OnPlayerChat?.Invoke(this, message);
        }
    }
}
