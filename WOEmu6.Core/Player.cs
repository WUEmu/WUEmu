using System;
using System.Collections.Generic;
using MoonSharp.Interpreter;
using Serilog;
using WOEmu6.Core.BML;
using WOEmu6.Core.Objects;
using WOEmu6.Core.Packets;
using WOEmu6.Core.Packets.Server;
using WOEmu6.Core.Scripting;
using WOEmu6.Core.Timers;
using WOEmu6.Core.Zones;

namespace WOEmu6.Core
{
    [MoonSharpUserData]
    public class Player
    {
        private List<PlayerTimer> timers;
        private object timerLock = new object();

        public Player(ClientSession client, string name)
        {
            World = ServerContext.Instance.Value.World;
            this.Client = client;
            Name = name;
            X = World.SpawnX;
            Y = World.SpawnY;
            Z = 5.0f;
            timers = new List<PlayerTimer>();

            CurrentZone = World.ZoneManager.Load((short)(X / 4), (short)(Y / 4));
        }
        
        public WurmId Id { get => -1; }
        
        public ClientSession Client { get; }
        
        public Zone CurrentZone { get; private set; } 

        public World World { get; }
        
        public string Name { get; }
        
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public int TileX => (int)(X / 4);
        public int TileY => (int)(Y / 4);
        
        public float Rotation { get; set; }

        /// <summary>
        /// Sets the status text in the player's GUI in the right panel. 
        /// </summary>
        /// <param name="text">The text to show to the player.</param>
        public void SetStatusText(string text) => Client.Send(new SetStatusBarPacket(text));

        public void Move(float x, float y, float z, float rotation)
        {
            X = x;
            Y = y;
            Z = z;
            Rotation = rotation;

            var zoneId = new ZoneId(x, y);
            if (zoneId != CurrentZone.Id)
                MoveToDifferentZone(zoneId);

            // short width = 100;
            // short height = 100;

            //Console.WriteLine($"Player moved to ({X}, {Y}, {Z})");
            /*if (TileX % 25 == 0 || TileY % 25 == 0)
            {
                // Log.Debug("Sending new tile chunk");
                // client.Send(new TileStripPacket( (short)(TileX - (width/2)), (short)(TileY - (width/2)), (short)100, (short)height));
                // top 100x50 far tiles around the player.
                // client.Send(new FarTileChunkPacket((short)(client.Player.TileX - (100/2)), (short)(client.Player.TileY - (100/2) - 50), 100, 50));

                // client.Send(new FarTileChunkPacket((short)(TileX - width), (short)(TileY - width), width, height));
                // client.Send(new FarTileChunkPacket((short)(TileX + width), (short)(TileY - width), width, height));
            }*/
        }

        public void RegisterTimer(PlayerTimer timer, bool startImmediately = true)
        {
            Log.Debug("Registered player timer {timer}", timer.Name);
            
            lock (timerLock)
            {
                timers.Add(timer);
            }
            
            if (startImmediately)
                timer.Start();
        }

        public void DeregisterTimer(PlayerTimer timer)
        {
            lock (timerLock)
                timers.Remove(timer);
            Log.Debug("Player timer {timer} deregistered", timer.Name);
        }

        public void MoveToDifferentZone(ZoneId newZoneId)
        {
            CurrentZone.RemovePlayer(this);
            var newZone = World.ZoneManager.Load(newZoneId);
            CurrentZone = newZone;
            CurrentZone.AddPlayer(this);
        }

        public void SendMessage(string channel, string message, float r = 1.0f, float g = 1.0f, float b = 1.0f)
        {
            Client.Send(new ServerMessagePacket(channel, message, (byte)(r * 255), (byte)(g * 255), (byte)(b * 255)));
        }

        public void SendForm(BmlForm form)
        {
            Client.Send(new BmlFormPacket(form));
        }

        public void AddItemToInventory(Item item)
        {
            World.RegisterItem(item);
            Client.Send(new AddInventoryItem(item));
        }

        public void RemoveItemFromInventory(Item item) => Client.Send(new RemoveItemFromInventoryPacket(-1, item.Id));

        public void AddItemToInventory(string itemName)
        {
            var item = new ScriptedItem(itemName);
            AddItemToInventory(item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">model.animation.use, use, open, close, shoot, die, give, deny, sprawl, idle, dodge, wounded, meditate</param>
        /// <param name="loop"></param>
        public void PlayAnimation(string name, bool loop) =>
            Client.Send(new AttachAnimationPacket(-1, name, loop, false));

        public void JoinChannel(string channel) => Client.Send(new AddChatUserPacket(-1, Name, channel));
    }
}
