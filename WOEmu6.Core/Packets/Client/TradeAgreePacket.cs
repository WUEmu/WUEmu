using System;

using WOEmu6.Core.Network;
using WOEmu6.Core.Packets.Server;

namespace WOEmu6.Core.Packets.Client
{
    public class TradeAgreePacket : IIncomingPacket
    {
        public byte Opcode => 42;
        
        public bool Agreed { get; private set; }
        
        public int SequenceNumber { get; private set; }
        
        public void Read(PacketReader reader)
        {
            Agreed = reader.ReadBoolean();
            SequenceNumber = reader.ReadInt();
        }

        public void Handle(ClientSession client)
        {
            client.Send(new CloseTradeWindowPacket());
        }
    }
}