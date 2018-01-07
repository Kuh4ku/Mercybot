using MercyBot.Protocol.Types;

namespace MercyBot.Core.Accounts.InGame.Character.Jobs.Skills
{
    public class CollectSkillEntry
    {

        // Properties
        public uint Id { get; private set; }
        public int InteractiveId { get; private set; }
        public string Name { get; private set; }
        public int ParentJobId { get; private set; }


        // Constructor
        public CollectSkillEntry(SkillActionDescriptionCollect skill, Protocol.Data.Skills skillData)
        {
            Id = skill.SkillId;
            InteractiveId = skillData.InteractiveId;
            Name = skillData.NameId;
            ParentJobId = skillData.ParentJobId;
        }

    }
}
