using System.Collections.Generic;
using Serilog;
using WOEmu6.Core.Network;

namespace WOEmu6.Core.Packets.Client
{
    /// <summary>
    /// 
    /// </summary>
    public class SteamLoginRequest : IIncomingPacket
    {
        public byte Opcode => 0xCC;
        
        public bool AllowAnonymous => true;
        
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
        
        internal ClientSession Session { get; private set; }

        public void Read(PacketReader reader)
        {
            SteamId = reader.ReadBytePrefixedString();
            AuthTicket = reader.ReadLong();
            var ticketArrayLength = reader.ReadInt();
            var tickets = new List<byte>();
            for (var i = 0; i < ticketArrayLength; i++)
                tickets.Add(reader.ReadByte());
            Tickets = tickets.ToArray();
            TokenLength = reader.ReadLong();
        }

        public void Handle(ClientSession session)
        {
            Log.Debug("Starting authentication for Steam user {steamId}...", SteamId);
            Session = session;
            ServerContext.Instance.Value.SteamAuthenticator.StartAuthentication(this);
        }
    }
}