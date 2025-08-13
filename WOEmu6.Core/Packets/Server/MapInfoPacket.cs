using WOEmu6.Core.Network;

namespace WOEmu6.Core.Packets.Server
{
    public class MapInfoPacket : IOutgoingPacket
    {
        public MapInfoPacket(string mapName, byte clusterId = 0)
        {
            MapName = mapName;
            ClusterId = clusterId;
        }

        public byte Opcode => -45 & 0xFF;

        public string MapName { get; }

        public byte ClusterId { get; }

        public void Write(ServerContext context, PacketWriter writer)
        {
            writer.WriteBytePrefixedString(MapName);
            writer.WriteByte(ClusterId);
        }
    }
}