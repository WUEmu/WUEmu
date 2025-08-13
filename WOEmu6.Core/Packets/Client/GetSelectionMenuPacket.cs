using System.Collections.Generic;
using Serilog;
using WO.Core;
using WOEmu6.Core.Network;
using WOEmu6.Core.Objects;
using WOEmu6.Core.Packets.Server;

namespace WOEmu6.Core.Packets.Client
{
    public class GetSelectionMenuPacket : IIncomingPacket
    {
        public byte Opcode => -23 & 0xFF;
        
        public byte RequestId { get; private set; }
        
        public WurmId Target { get; private set; }
        
        public WurmId Source { get; private set; }
        
        public void Read(PacketReader reader)
        {
            RequestId = reader.ReadByte();
            Target = reader.ReadLong();
            Source = reader.ReadLong();
        }

        public void Handle(ClientSession client)
        {
            Log.Debug("Requested selection menu on {target}", Target);
            client.Send(new SelectionMenuPacket(new List<SelectionMenuAction>
            {
                SelectionMenuAction.Open,
                SelectionMenuAction.Close
            }, RequestId));
        }
    }
}