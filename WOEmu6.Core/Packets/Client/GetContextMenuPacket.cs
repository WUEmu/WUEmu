using System;
using System.Collections.Generic;
using WO.Core;
using WOEmu6.Core.Objects;
using WOEmu6.Core.Packets.Server;

namespace WOEmu6.Core.Packets.Client
{
    public class GetContextMenuPacket : IIncomingPacket
    {
        public byte Opcode => 0x7E;
        
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
                new ContextMenuEntry(1, "Make Dirt"),
                new ContextMenuEntry(2, "Make Cobblestone"),
                new ContextMenuEntry(3, "Raise"),
                new ContextMenuEntry(4, "Lower"),
                new ContextMenuEntry(5, "Flatten Around")
            };
            
            client.Send(new ContextMenuPacket(RequestId, menuItems, "This is a test"));
        }
    }
}