using MercyBot.Protocol.Types;
using MercyBot.Protocol.Messages;
using MercyBot.Protocol.Data;
using MercyBot.Utility.DofusTouch;
using GalaSoft.MvvmLight;

namespace MercyBot.Core.Accounts.InGame.Character
{
    public class SpellEntry : ViewModelBase
    {
        
        // Properties
        public int Id { get; private set; }
        public byte Level { get; private set; }
        public string Name { get; private set; }
        public int MinPlayerLevel { get; private set; }

        public string IconUrl => $"https://ankama.akamaized.net/games/dofus-tablette/assets/{DTConstants.AssetsVersion}/gfx/spells/sort_{Id}.png";


        // Constructors
        public SpellEntry(SpellItem s, Spells spell)
        {
            Id = s.SpellId;
            Level = (byte)s.SpellLevel;
            Name = spell.NameId;
            SetMinPlayerLevel(spell);
        }

        public SpellEntry(int spellId, uint level)
        {
            var spell = DataManager.Get<Spells>(spellId);

            Id = spellId;
            Level = (byte)level;
            Name = spell.NameId;
            SetMinPlayerLevel(spell);
        }


        #region Updates

        public void Update(SpellUpgradeSuccessMessage message)
        {
            Level = (byte)message.SpellLevel;
            RaisePropertyChanged("Level");

        }

        #endregion

        private void SetMinPlayerLevel(Spells spell)
        {
            var spelllevel = DataManager.Get<SpellLevels>(spell.SpellLevels[Level - 1]);
            MinPlayerLevel = spelllevel.MinPlayerLevel;
        }

    }
}
