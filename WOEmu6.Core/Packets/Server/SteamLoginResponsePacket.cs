using WO.Core;
using WOEmu6.Core.Network;

namespace WOEmu6.Core.Packets.Server
{
    public class SteamLoginResponsePacket : IOutgoingPacket
    {
        public SteamLoginResponsePacket(bool success, string errorMessage = null)
        {
            Success = success;
            ErrorMessage = errorMessage ?? string.Empty;
        }
        
        public bool Success { get; }
        
        public string ErrorMessage { get; }

        public byte Opcode => 0xCC;

        public void Write(ServerContext context, PacketWriter writer)
        {
            writer.WriteByte((byte)(Success ? 1 : 0));
            writer.WriteShortPrefixedString(ErrorMessage);
        }
    }
}