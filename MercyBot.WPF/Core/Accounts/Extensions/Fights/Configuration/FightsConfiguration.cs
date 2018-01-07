using GalaSoft.MvvmLight;
using MercyBot.Core.Accounts.Extensions.Fights.Configuration.Enums;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using MercyBot.Configurations.Language;

namespace MercyBot.Core.Accounts.Extensions.Fights.Configuration
{
    public class FightsConfiguration : ViewModelBase, IDisposable
    {

        // Fields
        public const string ConfigurationsPath = @"Parameters\Fights";
        private bool _loaded;
        private Account _account;
        private FightStartPlacements _fightStartPlacements;
        private int _monsterToApproach;
        private int _spellToApproach;
        private BlockSpectatorScenarios _blockSpectatorScenario;
        private bool _lockFight;
        private FightTactics _tactic;
        private byte _maxCells;
        private bool _approachWhenNoSpellWasCasted;
        private bool _baseApproachOnAllMonsters;
        private byte _regenStart;
        private byte _regenEnd;
        private bool _ignoreSommonedEnnemies;
        private FightSpeeds _fightsSpeed;


        // Properties
        private string ConfigFilePath => Path.Combine(ConfigurationsPath, LanguageManager.Translate("68", _account.AccountConfig.Username, _account.Game.Character.Name));


        // Properties
        public FightStartPlacements FightStartPlacement
        {
            get => _fightStartPlacements;
            set
            {
                Set(ref _fightStartPlacements, value);
                Save();
            }
        }
        public int MonsterToApproach
        {
            get => _monsterToApproach;
            set
            {
                Set(ref _monsterToApproach, value);
                Save();
            }
        }
        public int SpellToApproach
        {
            get => _spellToApproach;
            set
            {
                Set(ref _spellToApproach, value);
                Save();
            }
        }
        public BlockSpectatorScenarios BlockSpectatorScenario
        {
            get => _blockSpectatorScenario;
            set
            {
                Set(ref _blockSpectatorScenario, value);
                Save();
            }
        }
        public bool LockFight
        {
            get => _lockFight;
            set
            {
                Set(ref _lockFight, value);
                Save();
            }
        }
        public FightTactics Tactic
        {
            get => _tactic;
            set
            {
                Set(ref _tactic, value);
                Save();
            }
        }
        public byte MaxCells
        {
            get => _maxCells;
            set
            {
                Set(ref _maxCells, value);
                Save();
            }
        }
        public bool ApproachWhenNoSpellWasCasted
        {
            get => _approachWhenNoSpellWasCasted;
            set
            {
                Set(ref _approachWhenNoSpellWasCasted, value);
                Save();
            }
        }
        public bool BaseApproachOnAllMonsters
        {
            get => _baseApproachOnAllMonsters;
            set
            {
                Set(ref _baseApproachOnAllMonsters, value);
                Save();
            }
        }
        public byte RegenStart
        {
            get => _regenStart;
            set
            {
                Set(ref _regenStart, value);
                Save();
            }
        }
        public byte RegenEnd
        {
            get => _regenEnd;
            set
            {
                Set(ref _regenEnd, value);
                Save();
            }
        }
        public ObservableCollection<Spell> Spells { get; private set; }
        public bool IgnoreSummonedEnnemies
        {
            get => _ignoreSommonedEnnemies;
            set
            {
                Set(ref _ignoreSommonedEnnemies, value);
                Save();
            }
        }
        public FightSpeeds FightsSpeed
        {
            get => _fightsSpeed;
            set
            {
                Set(ref _fightsSpeed, value);
                Save();
            }
        }


        // Constructor
        public FightsConfiguration(Account account)
        {
            _account = account;
            FightStartPlacement = FightStartPlacements.FAR_FROM_ENNEMIS;
            MonsterToApproach = -1;
            SpellToApproach = -1;
            BlockSpectatorScenario = BlockSpectatorScenarios.NEVER;
            LockFight = false;
            Tactic = FightTactics.FUGITIVE;
            MaxCells = 12;
            ApproachWhenNoSpellWasCasted = false;
            BaseApproachOnAllMonsters = false;
            RegenStart = 0;
            RegenEnd = 100;
            Spells = new ObservableCollection<Spell>();
            FightsSpeed = FightSpeeds.NORMAL;
        }


        public void Load()
        {
            _loaded = false;

            if (File.Exists(ConfigFilePath))
            {
                try
                {
                    using (BinaryReader br = new BinaryReader(File.Open(ConfigFilePath, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite)))
                    {
                        FightStartPlacement = (FightStartPlacements)br.ReadByte();
                        MonsterToApproach = br.ReadInt32();
                        SpellToApproach = br.ReadInt32();
                        BlockSpectatorScenario = (BlockSpectatorScenarios)br.ReadByte();
                        LockFight = br.ReadBoolean();
                        Tactic = (FightTactics)br.ReadByte();
                        MaxCells = br.ReadByte();
                        ApproachWhenNoSpellWasCasted = br.ReadBoolean();
                        BaseApproachOnAllMonsters = br.ReadBoolean();
                        RegenStart = br.ReadByte();
                        RegenEnd = br.ReadByte();

                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            Spells.Clear();
                            byte c = br.ReadByte();
                            for (int i = 0; i < c; i++)
                                Spells.Add(Spell.Load(br));
                        });

                        IgnoreSummonedEnnemies = br.ReadBoolean();
                        FightsSpeed = (FightSpeeds)br.ReadByte();
                    }
                }
                catch
                {
                    Console.WriteLine("Error while loading fights configuration '{0}'.", ConfigFilePath);
                }
            }

            _loaded = true;
        }

        public void Save()
        {
            // Avoid saving when we're loading
            if (!_loaded)
                return;

            // Ensure that the configuration directory is there
            Directory.CreateDirectory(ConfigurationsPath);

            using (BinaryWriter bw = new BinaryWriter(File.Open(ConfigFilePath, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite)))
            {
                bw.Write((byte)FightStartPlacement);
                bw.Write(MonsterToApproach);
                bw.Write(SpellToApproach);
                bw.Write((byte)BlockSpectatorScenario);
                bw.Write(LockFight);
                bw.Write((byte)Tactic);
                bw.Write(MaxCells);
                bw.Write(ApproachWhenNoSpellWasCasted);
                bw.Write(BaseApproachOnAllMonsters);
                bw.Write(RegenStart);
                bw.Write(RegenEnd);

                bw.Write((byte)Spells.Count);
                for (int i = 0; i < Spells.Count; i++)
                    Spells[i].Save(bw);

                bw.Write(IgnoreSummonedEnnemies);
                bw.Write((byte)FightsSpeed);
            }
        }

        #region IDisposable Support

        private bool _disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {

                }

                Spells = null;
                _account = null;

                _disposedValue = true;
            }
        }

        ~FightsConfiguration() => Dispose(false);

        public void Dispose() => Dispose(true);

        #endregion

    }
}