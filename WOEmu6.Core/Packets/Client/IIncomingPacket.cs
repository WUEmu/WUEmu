using WO.Core;

namespace WOEmu6.Core.Packets.Client
{
    public interface IIncomingPacket
    {
        byte Opcode { get; }
        
        void Read(PacketReader reader);

        void Handle(ClientSession client);
    }
}
