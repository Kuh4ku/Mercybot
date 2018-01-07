using MercyBot.Core.Accounts.InGame.Map.Interactives.Skills;
using MercyBot.Protocol.Types;
using System.Collections.Generic;

namespace MercyBot.Core.Accounts.InGame.Map.Interactives
{
    public class InteractiveElementEntry
    {

        // Properties
        public uint Id { get; private set; }
        public int ElementTypeId { get; private set; }
        public string Name { get; private set; }
        public List<SkillEntry> EnabledSkills { get; private set; }
        public List<SkillEntry> DisabledSkills { get; private set; }

        public bool Usable => EnabledSkills.Count > 0;


        // Constructor
        public InteractiveElementEntry(InteractiveElement elem)
        {
            Id = elem.ElementId;
            ElementTypeId = elem.ElementTypeId;
            Name = elem.Name;

            EnabledSkills = new List<SkillEntry>(elem.EnabledSkills.Count);
            for (int i = 0; i < elem.EnabledSkills.Count; i++)
            {
                EnabledSkills.Add(new SkillEntry(elem.EnabledSkills[i]));
            }

            DisabledSkills = new List<SkillEntry>(elem.DisabledSkills.Count);
            for (int i = 0; i < elem.DisabledSkills.Count; i++)
            {
                DisabledSkills.Add(new SkillEntry(elem.DisabledSkills[i]));
            }
        }

    }
}
