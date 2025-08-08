using System.Collections.Generic;
using WO.Core;

namespace WOEmu6.Core.Packets.Client
{
    public class ContextMenuClickPacket : IIncomingPacket
    {
        public byte Opcode => 0x61;

        public IReadOnlyList<long> Targets { get; private set; }
        
        public short EntryId { get; private set; }
        
        public long Subject { get; private set; }

        public void Read(PacketReader reader)
        {
            var count = reader.PopShort();
            Subject = reader.PopLong();

            var target = new List<long>();
            for (var i = 0; i < count; i++)
                target.Add(reader.PopLong());
            Targets = target;
            
            EntryId = reader.PopShort();
        }

        public void Handle(ClientSession client)
        {
            var world = ServerContext.Instance.Value.World;
            foreach (var target in Targets)
            {
                var obj = world.Objects.GetObject(target);
                obj.OnMenuItemClick(client, EntryId);
            }
        }
    }
}