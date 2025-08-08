using System.Collections.Generic;
using WO.Core;
using WOEmu6.Core.Packets.Server;

namespace WOEmu6.Core.Packets.Client
{
    /// <summary>
    /// 
    /// </summary>
    public class SteamLoginRequest : IIncomingPacket
    {
        public byte Opcode => 0xCC;
        
        /// <summary>
        /// Steam ID of the player logging in.
        /// </summary>
        public string SteamId { get; private set; }
        
        /// <summary>
        /// Unknown
        /// </summary>
        public long AuthTicket { get; private set; }
        
        public byte[] Tickets { get; private set; }
        
        public long TokenLength { get; private set; }

        public void Read(PacketReader reader)
        {
            SteamId = reader.ReadBytePrefixedString();
            AuthTicket = reader.PopLong();
            var ticketArrayLength = reader.PopInt();
            var tickets = new List<byte>();
            for (var i = 0; i < ticketArrayLength; i++)
                tickets.Add(reader.ReadByte());
            Tickets = tickets.ToArray();
            TokenLength = reader.PopLong();
        }

        public void Handle(ClientSession session)
        {
            var response = new SteamLoginResponsePacket(true);
            session.Send(response);
        }
    }
}