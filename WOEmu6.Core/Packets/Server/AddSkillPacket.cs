using WO.Core;
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
            writer.PushLong(Skill.Id);
            if (Skill.Parent == null)
                writer.PushLong(0L);
            else
                writer.PushLong(Skill.Parent.Id);
            writer.WriteBytePrefixedString(Skill.Name);
            writer.PushFloat(Skill.Value);
            writer.PushFloat(Skill.MaxValue);
            writer.WriteByte(Skill.Affinities);
        }
    }
}