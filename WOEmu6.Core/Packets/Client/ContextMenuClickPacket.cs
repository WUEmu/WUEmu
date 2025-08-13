using System.Collections.Generic;
using WOEmu6.Core.Network;
using WOEmu6.Core.Packets.Server;

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
            var count = reader.ReadShort();
            Subject = reader.ReadLong();

            var target = new List<long>();
            for (var i = 0; i < count; i++)
                target.Add(reader.ReadLong());
            Targets = target;

            EntryId = reader.ReadShort();
        }

        public void Handle(ClientSession client)
        {
            var world = ServerContext.Instance.Value.World;
            foreach (var target in Targets)
            {
                var obj = world.Objects.GetObject(target);
                if (EntryId == 1)
                    client.Send(new ServerMessagePacket(":Event", obj.Description));
                else if (EntryId == 9001)
                {
                    client.Send(new ServerMessagePacket("DeveloperTools", ""));
                    client.Send(new ServerMessagePacket("DeveloperTools", obj.Id.ToString()));
                    client.Send(new ServerMessagePacket("DeveloperTools", obj.ToString()));
                }
                else
                    obj.OnMenuItemClick(client, EntryId);
            }
        }
    }
}