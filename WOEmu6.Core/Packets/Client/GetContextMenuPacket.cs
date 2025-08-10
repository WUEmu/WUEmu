using System;
using System.Collections.Generic;
using Serilog;
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

        public void Handle(ClientSession client)
        {
            var gw = ServerContext.Instance.Value.World.Objects;            
            var obj = gw.GetObject(TargetId);
            if (obj == null)
                return;
            
            var menu = obj.GetContextMenu(client);
            // negative number is the amount of entries under the submenu
            menu.Add(new ContextMenuEntry(-1, "DEVELOPER TOOLS"));
            menu.Add(new ContextMenuEntry(9001, "Get ID info"));
            // menu.Add(new ContextMenuEntry(0, "DEVELOPER TOOLS"));
            
            Log.Debug("Req: {req}, Source: {src}, Target: {target} ({target:X16})", RequestId, SourceId, TargetId, TargetId);
            client.Send(new ContextMenuPacket(RequestId, menu, "This is a test"));
        }
    }
}