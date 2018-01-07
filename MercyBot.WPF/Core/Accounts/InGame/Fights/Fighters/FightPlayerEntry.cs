using System;
using MercyBot.Protocol.Types;

namespace MercyBot.Core.Accounts.InGame.Fights.Fighters
{
    public class FightPlayerEntry : FighterEntry
    {
        // Properties
        public string Name { get; private set; }

        public byte Level { get; private set; }


        // Constructor
        public FightPlayerEntry(GameFightFighterInformations infos) : base(infos)
        {
            if (infos is GameFightCharacterInformations a)
            {
                Name = a.Name;
                Level = (byte)a.Level;
            }
            else if (infos is GameFightMutantInformations b)
            {
                Name = b.Name;
                Level = 0; // Todo: Get the monster level
            }
        }
    }
}