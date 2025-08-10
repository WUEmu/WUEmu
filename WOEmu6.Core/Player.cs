using System;
using Serilog;
using WOEmu6.Core.Objects;
using WOEmu6.Core.Packets;
using WOEmu6.Core.Packets.Server;

namespace WOEmu6.Core
{
    public class Player
    {
        private readonly ClientSession client;

        public Player(ClientSession client, string name)
        {
            World = ServerContext.Instance.Value.World;
            this.client = client;
            Name = name;
            X = World.SpawnX;
            Y = World.SpawnY;
            Z = 5.0f;
        }
        
        public WurmId Id { get => -1; }

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
        public void SetStatusText(string text) => client.Send(new SetStatusBarPacket(text));

        public void Move(float x, float y, float z, float rotation)
        {
            X = x;
            Y = y;
            Z = z;
            Rotation = rotation;

            short width = 100;
            short height = 100;
            
            //Console.WriteLine($"Player moved to ({X}, {Y}, {Z})");
            if (TileX % 25 == 0 || TileY % 25 == 0)
            {
                Log.Debug("Sending new tile chunk");
                client.Send(new TileStripPacket( (short)(TileX - (width/2)), (short)(TileY - (width/2)), (short)100, (short)height));
                // top 100x50 far tiles around the player.
                // client.Send(new FarTileChunkPacket((short)(client.Player.TileX - (100/2)), (short)(client.Player.TileY - (100/2) - 50), 100, 50));
                
                // client.Send(new FarTileChunkPacket((short)(TileX - width), (short)(TileY - width), width, height));
                // client.Send(new FarTileChunkPacket((short)(TileX + width), (short)(TileY - width), width, height));
            }
        }
    }
}
