using WOEmu6.Core.Objects;

namespace WOEmu6.Core.Scripting
{
    public class ScriptedSkill : Skill
    {
        public ScriptedSkill(Skill parent, string name, float value, float maxValue, byte affinities = 0) : base(parent, name, value, maxValue, affinities)
        {
        }
    }
}