using MercyBot.Protocol.Data;
using MercyBot.Protocol.Types;

namespace MercyBot.Core.Accounts.InGame.Fights.Fighters
{
    public class FightMonsterEntry : FighterEntry
    {

        // Properties
        public int CreatureGenericId { get; private set; }
        public string Name { get; private set; }
        public short Level { get; private set; }
        public bool IsBoss { get; private set; }
        public bool IsMiniBoss { get; private set; }
        public bool IsQuestMonster { get; private set; }


        // Constructor
        public FightMonsterEntry(GameFightMonsterInformations infos1, GameFightFighterInformations infos2) : base(infos2)
        {
            CreatureGenericId = (int)infos1.CreatureGenericId;

            var m = DataManager.Get<Monsters>(CreatureGenericId);
            Name = m.NameId;
            IsBoss = m.IsBoss;
            IsMiniBoss = m.IsMiniBoss;
            IsQuestMonster = m.IsQuestMonster;
            Level = (short)m.Grades[(int)infos1.CreatureGrade - 1].level;
        }

    }
}
