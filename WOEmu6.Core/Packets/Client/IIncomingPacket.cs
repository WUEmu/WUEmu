using WOEmu6.Core.Network;

namespace WOEmu6.Core.Packets.Client
{
    public interface IIncomingPacket
    {
        byte Opcode { get; }

        bool AllowAnonymous { get; }

        void Read(PacketReader reader);

        void Handle(ClientSession client);
    }
}