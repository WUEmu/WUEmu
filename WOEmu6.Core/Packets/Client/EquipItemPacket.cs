using System.Collections.Generic;
using Serilog;
using WO.Core;
using WOEmu6.Core.Network;
using WOEmu6.Core.Objects;

namespace WOEmu6.Core.Packets.Client
{
    public class EquipItemPacket : IIncomingPacket
    {
        public byte Opcode => -32 & 0xFF;
        
        public List<WurmId> Sources { get; private set; }
        
        public void Read(PacketReader reader)
        {
            var count = reader.ReadShort();
            Sources = new List<WurmId>();
            for (var i = 0; i < count; i++)
                Sources.Add(reader.ReadLong());
        }

        public void Handle(ClientSession client)
        {
            Log.Debug("equip:");
            foreach (var id in Sources)
                Log.Debug("Id: {id}", id);
        }
    }
}