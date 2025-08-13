using System;
using System.Collections.Generic;
using WO.Core;
using WOEmu6.Core.Network;

namespace WOEmu6.Core.Packets.Server
{
    public class FarTileChunkPacket : IOutgoingPacket
    {
        public FarTileChunkPacket(short x, short y, short w, short h)
        {
            if (w * h > 13_100)
                throw new ArgumentException("Can not send tile block bigger than 13100 units, because it does not fit in one packet.");
            
            X = x;
            Y = y;
            W = w;
            H = h;
        }
        
        public byte Opcode => 103;
        
        public short X { get; }
        public short Y { get; }
        public short W { get; }
        public short H { get; }
        
        public void Write(ServerContext context, PacketWriter writer)
        {
            writer.WriteShort(X);
            writer.WriteShort(Y);
            writer.WriteShort(W);
            writer.WriteShort(H);
            
            var mesh = context.World.TopLayer;
            var types = new List<byte>();
            
            for (short x = 0; x < W; x++)
            {
                for (short y = 0; y < H; y++)
                {
                    short tempTileX = (short)(X + x);
                    short tempTileY = (short)(Y + y);
                    if (tempTileX < 0 || tempTileX >= 1 << mesh.MeshSize || tempTileY < 0 ||
                        tempTileY >= 1 << mesh.MeshSize)
                    {
                        tempTileY = tempTileX = 0;
                    }

                    var tile = mesh.GetTileValue(tempTileX, tempTileY);
                    writer.WriteShort(tile.Height);
                    types.Add((byte)tile.TileType);
                }
            }

            foreach (var type in types)
                writer.WriteByte(type);
        }
    }
}