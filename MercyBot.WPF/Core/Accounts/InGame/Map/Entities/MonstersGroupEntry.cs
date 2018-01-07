using MercyBot.Protocol.Types;
using System.Collections.Generic;
using System.Linq;

namespace MercyBot.Core.Accounts.InGame.Map.Entities
{
    public class MonstersGroupEntry : MovableEntity
    {

        // Properties
        public int Id { get; private set; }
        public MonsterEntry Leader { get; private set; }
        public List<MonsterEntry> Followers { get; private set; }

        public int MonstersCount => Followers.Count + 1;
        public int TotalLevel => Leader.Level + Followers.Sum(f => f.Level);


        // Constructor
        public MonstersGroupEntry(GameRolePlayGroupMonsterInformations infos)
        {
            Id = infos.ContextualId;
            CellId = (short)infos.Disposition.CellId;
            Followers = new List<MonsterEntry>(infos.StaticInfos.Underlings.Count);

            Leader = new MonsterEntry(infos.StaticInfos.MainCreatureLightInfos);
            infos.StaticInfos.Underlings.ForEach(u => Followers.Add(new MonsterEntry(u)));
        }


        public bool ContainsMonster(int gid)
        {
            if (Leader.GenericId == gid)
                return true;

            for (int i = 0; i < Followers.Count; i++)
            {
                if (Followers[i].GenericId == gid)
                    return true;
            }

            return false;
        }

    }
}
