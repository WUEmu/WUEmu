using WO.Core;
using WOEmu6.Core.Objects;

namespace WOEmu6.Core.Packets.Server
{
    public class RemoveTileEffectPacket : IOutgoingPacket
    {
        public RemoveTileEffectPacket(Tile tile)
        {
            Tile = tile;
        }

        public byte Opcode => -5 & 0xFF;
        
        public Tile Tile { get; }
        
        public void Write(ServerContext context, PacketWriter writer)
        {
            writer.WriteShort(Tile.X);
            writer.WriteShort(Tile.Y);
            writer.WriteByte(Tile.Layer);
        }
    }
}