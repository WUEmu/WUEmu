using System;
using WO.Core;

namespace WOEmu6.Core.Packets.Server
{
    public class TileStripPacket : IOutgoingPacket
    {
        public short X { get; }
        public short Y { get; }
        public short W { get; }
        public short H { get; }
        public bool WithWater { get; }
        public bool WithExtraData { get; }

        public TileStripPacket(short x, short y, short w, short h, bool withWater = false, bool withExtraData = true)
        {
            if (w * h > 13_100)
                throw new ArgumentException("Can not send tile block bigger than 13100 units, because it does not fit in one packet.");
            
            X = x;
            Y = y;
            W = w;
            H = h;
            WithWater = withWater;
            WithExtraData = withExtraData;
        }

        public byte Opcode => 73;

        public void Write(ServerContext context, PacketWriter writer)
        {
            writer.PushByte((byte)(WithWater ? 1 : 0));
            writer.PushByte((byte)(WithExtraData ? 1 : 0));
            writer.PushShort(Y);
            writer.PushShort(W);
            writer.PushShort(H);
            writer.PushShort(X);

            var mesh = context.World.TopLayer;
            var flagsMesh = context.World.Flags;
            for (var x = 0; x < W; x++)
            {
                for (var y = 0; y < H; y++)
                {
                    var tempTileX = X + x;
                    var tempTileY = Y + y;
                    if (tempTileX < 0 || tempTileX >= 1 << mesh.MeshSize || tempTileY < 0 ||
                        tempTileY >= 1 << mesh.MeshSize)
                    {
                        tempTileY = tempTileX = 0;
                    }
                    
                    writer.PushInt(mesh.Data[tempTileX | tempTileY << mesh.MeshSize]);
                    if (WithExtraData)
                        writer.PushByte((byte)(flagsMesh.GetTile(tempTileX, tempTileY) & 0xFF));
                }
            }
        }
    }
}