using GalaSoft.MvvmLight;
using MercyBot.Configurations.Language;
using MercyBot.Protocol.Messages;
using MercyBot.Protocol.Types;

namespace MercyBot.Core.Accounts.InGame.Character
{
    public class CharacterStats : ViewModelBase
    {

        // Fields
        private uint _lifePoints;
        private uint _maxLifePoints;
        private uint _energyPoints;
        private uint _maxEnergyPoints;
        private double _experience;
        private double _experienceLevelFloor;
        private double _experienceNextLevelFloor;
        private uint _statsPoints;
        private uint _spellsPoints;
        private CharacterBaseCharacteristic _actionPoints;
        private CharacterBaseCharacteristic _mouvementPoints;
        private CharacterBaseCharacteristic _initiative;
        private CharacterBaseCharacteristic _prospecting;
        private CharacterBaseCharacteristic _range;
        private CharacterBaseCharacteristic _summonableCreaturesBoost;
        private CharacterBaseCharacteristic _vitality;
        private CharacterBaseCharacteristic _wisdom;
        private CharacterBaseCharacteristic _strength;
        private CharacterBaseCharacteristic _intelligence;
        private CharacterBaseCharacteristic _chance;
        private CharacterBaseCharacteristic _agility;


        // Properties
        public uint LifePoints
        {
            get => _lifePoints;
            set
            {
                if (Set(ref _lifePoints, value))
                    RaisePropertyChanged("LifePercent");
            }
        }
        public uint MaxLifePoints
        {
            get => _maxLifePoints;
            set
            {
                if (Set(ref _maxLifePoints, value))
                    RaisePropertyChanged("LifePercent");
            }
        }
        public uint EnergyPoints
        {
            get => _energyPoints;
            set
            {
                if (Set(ref _energyPoints, value))
                    RaisePropertyChanged("EnergyPercent");
            }
        }
        public uint MaxEnergyPoints
        {
            get => _maxEnergyPoints;
            set
            {
                if (Set(ref _maxEnergyPoints, value))
                    RaisePropertyChanged("EnergyPercent");
            }
        }
        public uint StatsPoints
        {
            get => _statsPoints;
            set => Set(ref _statsPoints, value);
        }
        public uint SpellsPoints
        {
            get => _spellsPoints;
            set => Set(ref _spellsPoints, value);
        }
        public CharacterBaseCharacteristic ActionPoints
        {
            get => _actionPoints;
            set => Set(ref _actionPoints, value);
        }
        public CharacterBaseCharacteristic MouvementPoints
        {
            get => _mouvementPoints;
            set => Set(ref _mouvementPoints, value);
        }
        public CharacterBaseCharacteristic Initiative
        {
            get => _initiative;
            set => Set(ref _initiative, value);
        }
        public CharacterBaseCharacteristic Prospecting
        {
            get => _prospecting;
            set => Set(ref _prospecting, value);
        }
        public CharacterBaseCharacteristic Range
        {
            get => _range;
            set => Set(ref _range, value);
        }
        public CharacterBaseCharacteristic SummonableCreaturesBoost
        {
            get => _summonableCreaturesBoost;
            set => Set(ref _summonableCreaturesBoost, value);
        }
        public CharacterBaseCharacteristic Vitality
        {
            get => _vitality;
            set => Set(ref _vitality, value);
        }
        public CharacterBaseCharacteristic Wisdom
        {
            get => _wisdom;
            set => Set(ref _wisdom, value);
        }
        public CharacterBaseCharacteristic Strength
        {
            get => _strength;
            set => Set(ref _strength, value);
        }
        public CharacterBaseCharacteristic Intelligence
        {
            get => _intelligence;
            set => Set(ref _intelligence, value);
        }
        public CharacterBaseCharacteristic Chance
        {
            get => _chance;
            set => Set(ref _chance, value);
        }
        public CharacterBaseCharacteristic Agility
        {
            get => _agility;
            set => Set(ref _agility, value);
        }

        public int LifePercent => MaxLifePoints == 0 ? 0 : (int)(((double)LifePoints / MaxLifePoints) * 100);
        public int EnergyPercent => MaxEnergyPoints == 0 ? 0 : (int)(((double)EnergyPoints / MaxEnergyPoints) * 100);
        public int ExperiencePercent => _experienceNextLevelFloor == 0 ? 0 : (int)((_experience - _experienceLevelFloor) / (_experienceNextLevelFloor - _experienceLevelFloor) * 100);


        #region Updates

        public void Update(CharacterStatsListMessage message)
        {
            LifePoints = message.Stats.LifePoints;
            MaxLifePoints = message.Stats.MaxLifePoints;
            EnergyPoints = message.Stats.EnergyPoints;
            MaxEnergyPoints = message.Stats.MaxEnergyPoints;
            _experience = message.Stats.Experience;
            _experienceLevelFloor = message.Stats.ExperienceLevelFloor;
            _experienceNextLevelFloor = message.Stats.ExperienceNextLevelFloor;
            StatsPoints = message.Stats.StatsPoints;
            SpellsPoints = message.Stats.SpellsPoints;
            ActionPoints = message.Stats.ActionPoints;
            MouvementPoints = message.Stats.MovementPoints;
            Initiative = message.Stats.Initiative;
            Prospecting = message.Stats.Prospecting;
            Range = message.Stats.Range;
            SummonableCreaturesBoost = message.Stats.SummonableCreaturesBoost;
            Vitality = message.Stats.Vitality;
            Wisdom = message.Stats.Wisdom;
            Strength = message.Stats.Strength;
            Intelligence = message.Stats.Intelligence;
            Chance = message.Stats.Chance;
            Agility = message.Stats.Agility;

            RaisePropertyChanged(LanguageManager.Translate("115"));
        }

        public void Update(CharacterExperienceGainMessage message)
        {
            _experience += message.ExperienceCharacter;
            RaisePropertyChanged(LanguageManager.Translate("115"));
        }

        public void Update(LifePointsRegenEndMessage message)
        {
            LifePoints = message.LifePoints;
            MaxLifePoints = message.MaxLifePoints;
        }

        public void Update(UpdateLifePointsMessage message)
        {
            LifePoints = message.LifePoints;
            MaxLifePoints = message.MaxLifePoints;
        }

        #endregion

    }
}
