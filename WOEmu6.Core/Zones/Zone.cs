using System;
using System.Collections.Generic;
using MoonSharp.Interpreter;
using Serilog;
using WOEmu6.Core.Objects;
using WOEmu6.Core.Packets.Server;
using WOEmu6.Core.Utilities;

namespace WOEmu6.Core.Zones
{
    [MoonSharpUserData]
    public class Zone
    {
        private readonly World _world;

        /// <summary>
        /// The width and height (in tiles) of a zone.
        /// </summary>
        internal const int ZoneSize = 100;

        private List<Player> players;
        private object playersLock = new object();

        private ObjectPool objectPool;

        public Zone(ZoneId id, World world)
        {
            _world = world;
            Id = id;
            Origin = new Position2D<int>(id.X * ZoneSize, id.Y * ZoneSize);
            players = new List<Player>();
            objectPool = new ObjectPool();
        }
        
        public ZoneId Id { get; }
        
        public Position2D<int> Origin { get; }

        public int Width => ZoneSize;

        public int Height => ZoneSize;

        public void AddPlayer(Player player)
        {
            lock (playersLock)
                players.Add(player);
            
            Log.Debug("Player {player} enters zone {zone}", player.Name, Id);
            player.SendMessage(":Event", $"You enter zone {Id}");
            
            // TODO: send all stuff that is in this zone
            var creatures = objectPool.GetAllCreatures();
            foreach (var creature in creatures)
                player.Client.Send(new AddCreaturePacket(creature));
        }

        public void RemovePlayer(Player player)
        {
            lock (playersLock)
                players.Remove(player);
            
            Log.Debug("Player {player} leaves zone {zone}", player.Name, Id);
            player.SendMessage(":Event", $"You leave zone {Id}");

            var creatures = objectPool.GetAllCreatures();
            foreach (var creature in creatures)
                player.Client.Send(new RemoveCreaturePacket(creature.Id));
        }

        public void AddCreature(Creature creature)
        {
            objectPool.AddCreature(creature);
            _world.AllObjects.AddCreature(creature);

            Player[] currentPlayers;
            lock (playersLock)
                currentPlayers = players.ToArray();
            
            foreach (var player in currentPlayers)
                player.Client.Send(new AddCreaturePacket(creature));
            
            Log.Information("Creature {name} has been added.", creature.Name);
        }

        public void AddItem(Item item)
        {
            if (item.SpatialPosition == null)
                throw new NotSupportedException("Can not place an item that is not spatial");
            
            objectPool.AddItem(item);
            Player[] currentPlayers;
            lock (playersLock)
                currentPlayers = players.ToArray();
            
            foreach (var player in currentPlayers)
                player.Client.Send(new AddItemPacket(item));
        }

        public void RemoveCreature(Creature creature)
        {
            objectPool.RemoveCreature(creature);
            _world.AllObjects.RemoveCreature(creature);
            
            Player[] currentPlayers;
            lock (playersLock)
                currentPlayers = players.ToArray();
            
            foreach (var player in currentPlayers)
                player.Client.Send(new RemoveCreaturePacket(creature.Id));
        }
        
        public void SetWeather(float clouds, float fog, float rain, float windRotation, float windPower)
        {
            Player[] currentPlayers;
            lock (playersLock)
                currentPlayers = players.ToArray();
            
            var packet = new UpdateWeatherPacket(clouds, fog, rain, windRotation, windPower);
            foreach (var player in currentPlayers)
                player.Client.Send(packet);
        }

        public void CreatureMoved(Creature creature)
        {
            Player[] currentPlayers;
            lock (playersLock)
                currentPlayers = players.ToArray();

            var packet = new MoveCreaturePacket(creature.Id, creature.Position, (byte)(creature.Rotation * 255));
            foreach (var player in currentPlayers)
                player.Client.Send(packet);
        }
    }
}
