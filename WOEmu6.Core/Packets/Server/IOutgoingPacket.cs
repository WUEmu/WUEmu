using WOEmu6.Core.Network;

namespace WOEmu6.Core.Packets.Server
{
    public interface IOutgoingPacket
    {
        byte Opcode { get; }

        void Write(ServerContext context, PacketWriter writer);
    }
}