using System;
using WOEmu6.Core.Network;

namespace WOEmu6.Core.Packets.Server
{
    public class CaveTileChunkPacket : IOutgoingPacket
    {
        public CaveTileChunkPacket(short x, short y, short w, short h, bool withWater = false, bool withExtraData = true)
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
        
        public byte Opcode => 0x66;
        
        public short X { get; }
        public short Y { get; }
        public short W { get; }
        public short H { get; }
        public bool WithWater { get; }
        public bool WithExtraData { get; }
        
        public void Write(ServerContext context, PacketWriter writer)
        {
            throw new System.NotImplementedException();
        }
    }
}