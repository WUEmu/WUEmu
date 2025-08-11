using System;

namespace WOEmu6.Core.Packets.Client
{
    public class IncomingPacketFactory
    {
        private readonly IIncomingPacket[] packetList;
        
        public IncomingPacketFactory()
        {
            packetList = new IIncomingPacket[255];
            Array.Fill(packetList, null);

            RegisterPacket(new SteamLoginRequest());
            RegisterPacket(new LoginRequest());
            RegisterPacket(new PlayerMove());
            RegisterPacket(new BmlResponsePacket());
            RegisterPacket(new ClientMessagePacket());
            RegisterPacket(new GetContextMenuPacket());
            RegisterPacket(new SupportTicketPacket());
            RegisterPacket(new ContextMenuClickPacket());
            RegisterPacket(new TradeAgreePacket());
            RegisterPacket(new MapAnnotationPacket());
            RegisterPacket(new FishingPacket());
            RegisterPacket(new ItemPlacedPacket());
        }

        public void RegisterPacket(IIncomingPacket packet) => packetList[packet.Opcode] = packet;
        
        public IIncomingPacket Get(byte opcode)
        {
            if (opcode >= packetList.Length)
                return null;

            return packetList[opcode];
        }
    }
}
