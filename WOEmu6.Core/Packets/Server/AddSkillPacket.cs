using WO.Core;
using WOEmu6.Core.Network;
using WOEmu6.Core.Objects;

namespace WOEmu6.Core.Packets.Server
{
    public class AddSkillPacket : IOutgoingPacket
    {
        public AddSkillPacket(Skill skill)
        {
            Skill = skill;
        }

        public byte Opcode => 0x7C;
        
        public Skill Skill { get; }
        
        public void Write(ServerContext context, PacketWriter writer)
        {
            writer.WriteLong(Skill.Id);
            if (Skill.Parent == null)
                writer.WriteLong(0L);
            else
                writer.WriteLong(Skill.Parent.Id);
            writer.WriteBytePrefixedString(Skill.Name);
            writer.WriteFloat(Skill.Value);
            writer.WriteFloat(Skill.MaxValue);
            writer.WriteByte(Skill.Affinities);
        }
    }
}