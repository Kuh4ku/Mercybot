using System.Collections.Generic;
using MercyBot.Core.Accounts.Extensions.Fights.Configuration;
using MercyBot.Core.Accounts.Extensions.Fights.Configuration.Enums;
using MercyBot.Protocol.Enums;

namespace MercyBot.Core.Accounts.Extensions.CharacterCreator
{
    public static class TutorialHelper
    {

        public static uint QuestTutorialId = 489;

        public static int TutorialMapIdFirst = 81002496;
        public static int TutorialMapIdSecondBeforeFight = 81003520;
        public static int TutorialMapIdSecondAfterFight = 81003522;
        public static int TutorialMapIdThirdBeforeFight = 81004544;
        public static int TutorialMapIdThirdAfterFight = 81004546;

        public static int FirstEquipItem = 10785;
        public static int[] SecondEquipItems = { 10784, 10794, 10797, 10799, 10800 };

        public static Dictionary<BreedEnum, List<Spell>> BaseSpells = new Dictionary<BreedEnum, List<Spell>>()
        {
            { BreedEnum.Feca, new List<Spell> { new Spell(3, "??", SpellTargets.ENNEMY, 1, 2, 100, 100, SpellResistances.EARTH, 100, 0, true, false, false, false) } },
            { BreedEnum.Osamodas, new List<Spell> { new Spell(21, "??", SpellTargets.ENNEMY, 1, 1, 100, 100, SpellResistances.EARTH, 100, 0, true, false, false, false) } },
            { BreedEnum.Enutrof, new List<Spell> { new Spell(43, "??", SpellTargets.ENNEMY, 1, 1, 100, 100, SpellResistances.EARTH, 100, 0, true, false, false, false) } },
            { BreedEnum.Sram, new List<Spell> { new Spell(61, "??", SpellTargets.ENNEMY, 1, 2, 100, 100, SpellResistances.EARTH, 100, 0, true, false, false, false) } },
            { BreedEnum.Xelor, new List<Spell> { new Spell(83, "??", SpellTargets.ENNEMY, 1, 1, 100, 100, SpellResistances.EARTH, 100, 0, true, false, false, false) } },
            { BreedEnum.Ecaflip, new List<Spell> { new Spell(102, "??", SpellTargets.ENNEMY, 1, 2, 100, 100, SpellResistances.EARTH, 100, 0, true, false, false, false) } },
            { BreedEnum.Eniripsa, new List<Spell> { new Spell(125, "??", SpellTargets.ENNEMY, 1, 2, 100, 100, SpellResistances.EARTH, 100, 0, true, false, false, false) } },
            { BreedEnum.Iop, new List<Spell> { new Spell(141, "??", SpellTargets.ENNEMY, 1, 2, 100, 100, SpellResistances.EARTH, 100, 0, true, false, false, false) } },
            { BreedEnum.Cra, new List<Spell> { new Spell(161, "??", SpellTargets.ENNEMY, 1, 1, 100, 100, SpellResistances.EARTH, 100, 0, true, false, false, false) } },
            { BreedEnum.Sadida, new List<Spell> { new Spell(183, "??", SpellTargets.ENNEMY, 1, 2, 100, 100, SpellResistances.EARTH, 100, 0, true, false, false, false) } },
            { BreedEnum.Sacrieur, new List<Spell> { new Spell(432, "??", SpellTargets.ENNEMY, 1, 2, 100, 100, SpellResistances.EARTH, 100, 0, true, false, false, false) } },
            { BreedEnum.Pandawa, new List<Spell>
            {
                new Spell(686, "??", SpellTargets.SELF, 5, 1, 100, 100, SpellResistances.EARTH, 100, 0, true, false, false, false),
                new Spell(692, "??", SpellTargets.ENNEMY, 1, 2, 100, 100, SpellResistances.EARTH, 100, 0, true, false, false, false)
            } },
            { BreedEnum.Roublard, new List<Spell> { new Spell(2808, "??", SpellTargets.ENNEMY, 1, 1, 100, 100, SpellResistances.EARTH, 100, 0, true, false, false, false) } },
            { BreedEnum.Zobal, new List<Spell> { new Spell(2881, "??", SpellTargets.ENNEMY, 1, 1, 100, 100, SpellResistances.EARTH, 100, 0, true, false, false, false) } },
            { BreedEnum.Steamer, new List<Spell> { new Spell(3210, "??", SpellTargets.ENNEMY, 1, 2, 100, 100, SpellResistances.EARTH, 100, 0, true, false, false, false) } },
        };

    }
}
