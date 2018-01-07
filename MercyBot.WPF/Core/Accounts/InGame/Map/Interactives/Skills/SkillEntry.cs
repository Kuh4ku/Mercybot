using MercyBot.Protocol.Types;

namespace MercyBot.Core.Accounts.InGame.Map.Interactives.Skills
{
    public class SkillEntry
    {

        // Properties
        public int Id { get; private set; }
        public uint InstanceUID { get; private set; }
        public string Name { get; private set; }


        // Constructor
        public SkillEntry(InteractiveElementSkill skill)
        {
            Id = (int)skill.SkillId;
            InstanceUID = skill.SkillInstanceUid;
            Name = skill.Name;
        }

    }
}
