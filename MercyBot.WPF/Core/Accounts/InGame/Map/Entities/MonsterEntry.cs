using MercyBot.Protocol.Data;
using MercyBot.Protocol.Types;

namespace MercyBot.Core.Accounts.InGame.Map.Entities
{
    public class MonsterEntry
    {

        // Properties
        public int GenericId { get; private set; }
        public byte Grade { get; private set; }
        public string Name { get; private set; }
        public int Level { get; private set; }
        public bool Boss { get; private set; }
        public bool MiniBoss { get; private set; }
        public bool QuestMonster { get; private set; }


        // Constructor
        public MonsterEntry(MonsterInGroupLightInformations infos)
        {
            GenericId = infos.CreatureGenericId;
            Grade = (byte)infos.Grade;

            var m = DataManager.Get<Monsters>(GenericId);
            Name = m.NameId;
            Level = m.Grades[Grade - 1].level;
            Boss = m.IsBoss;
            MiniBoss = m.IsMiniBoss;
            QuestMonster = m.IsQuestMonster;
        }

    }
}
