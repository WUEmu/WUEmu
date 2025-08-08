using System;
using System.Collections.Generic;
using WO.Core;
using WOEmu6.Core.Objects;
using WOEmu6.Core.Packets.Server;

namespace WOEmu6.Core.Packets.Client
{
    public class GetContextMenuPacket : IIncomingPacket
    {
        public byte Opcode => 126;
        
        public byte RequestId { get; private set; }
        
        public long TargetId { get; private set; }
        
        public long SourceId { get; private set; }
        
        public void Read(PacketReader reader)
        {
            RequestId = reader.ReadByte();
            TargetId = reader.PopLong();
            SourceId = reader.PopLong();
        }

        public void Handle(ServerContext context, ClientSession client)
        {
            var gw = new ObjectGateway(context);
            gw.GetObject(TargetId);
            Console.WriteLine("Req: {0}, Source: {1}, Target = {2} ({2:X16})", RequestId, SourceId, TargetId);

            var menuItems = new List<ContextMenuEntry>
            {
                new ContextMenuEntry(1, "Hello"),
                new ContextMenuEntry(2, "World")
            };
            
            client.Send(new ContextMenuPacket(RequestId, menuItems, "This is a test"));
            client.Send(new StartDrumRollPacket());
        }
    }
}