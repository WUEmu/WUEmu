using System;
using WOEmu6.Core.Packets;
using WOEmu6.Core.Packets.Server;

namespace WOEmu6.Core
{
    public class Player
    {
        private readonly ClientSession client;

        public Player(ClientSession client, string name)
        {
            this.client = client;
            Name = name;
            // X = 200 * 4;
            // Y = 200 * 4;
            X = 1512.0f;
            Y = 2148.0f;
            Z = 5.0f;
        }
        
        public string Name { get; }
        
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public int TileX => (int)(X / 4);
        public int TileY => (int)(Y / 4);
        
        public float Rotation { get; set; }

        public void Move(float x, float y, float z, float rotation)
        {
            X = x;
            Y = y;
            Z = z;
            Rotation = rotation;

            var width = 100;
            var height = 100;
            
            //Console.WriteLine($"Player moved to ({X}, {Y}, {Z})");
            if (TileX % 25 == 0 || TileY % 25 == 0)
            {
                Console.WriteLine("Sending new tile chunk");
                client.Send(new TileStripPacket( (short)(TileX - (width/2)), (short)(TileY - (width/2)), (short)100, (short)height));
            }
        }
    }
}
