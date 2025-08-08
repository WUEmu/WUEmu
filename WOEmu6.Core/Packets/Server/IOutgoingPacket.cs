using WO.Core;

namespace WOEmu6.Core.Packets.Server
{
    public interface IOutgoingPacket
    {
        byte Opcode { get; }
        
        void Write(ServerContext context, PacketWriter writer);
    }
}