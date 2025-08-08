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

        public TileStripPacket(short x, short y, short w, short h, bool withWater = false, bool withExtraData = false)
        {
            X = x;
            Y = y;
            W = w;
            H = h;
            WithWater = withWater;
            WithExtraData = withExtraData;
        }

        public byte Opcode => 73;

        public void Write(PacketWriter writer)
        {
            writer.PushByte((byte)(WithWater ? 1 : 0));
            writer.PushByte((byte)(WithExtraData ? 1 : 0));
            writer.PushShort(Y);
            writer.PushShort(W);
            writer.PushShort(H);
            writer.PushShort(X);

            for (int i = 0; i < W * H; i++)
                writer.PushInt(10);
        }
    }
}