using WO.Core;
using WOEmu6.Core.Objects;
using WOEmu6.Core.Utilities;

namespace WOEmu6.Core.Packets.Server
{
    public class AddTileEffectPacket : IOutgoingPacket
    {
        public AddTileEffectPacket(Tile tile, TileEffectType effectType, short effectHeight, bool loop)
        {
            Tile = tile;
            EffectHeight = effectHeight;
            Loop = loop;
            EffectType = effectType;
        }

        public byte Opcode => -4 & 0xFF;
        
        public Tile Tile { get; }
        
        public TileEffectType EffectType { get; }
        
        public short EffectHeight { get; }
        
        public bool Loop { get; }
        
        public void Write(ServerContext context, PacketWriter writer)
        {
            writer.WriteShort(Tile.X);
            writer.WriteShort(Tile.Y);
            writer.WriteByte(Tile.Layer);
            writer.WriteByte((byte)EffectType);
            writer.WriteShort(EffectHeight);
            writer.WriteBoolean(Loop);
            writer.WriteByte((byte)0); // Unused
        }
    }
}