using GalaSoft.MvvmLight;
using MercyBot.Core.Enums;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;

namespace MercyBot.Core.Accounts.Configurations
{
    public class Configuration : ViewModelBase, IDisposable
    {

        // Fields
        public const string ConfigurationsPath = "Parameters";
        private bool _loaded;
        private Account _account;
        private bool _showGeneralMessages;
        private bool _showPartyMessages;
        private bool _showGuildMessages;
        private bool _showAllianceMessages;
        private bool _showSaleMessages;
        private bool _showSeekMessages;
        private bool _showNoobMessages;
        private bool _autoRegenAccepted;
        private bool _acceptAchivements;
        private BoostableStats _statToBoost;
        private bool _ignoreNonAuthorizedTrades;
        private bool _disconnectUponFightsLimit;
        private bool _autoMount;


        // Properties
        public bool ShowGeneralMessages
        {
            get => _showGeneralMessages;
            set
            {
                Set(ref _showGeneralMessages, value);
                Save();
            }
        }
        public bool ShowPartyMessages
        {
            get => _showPartyMessages;
            set
            {
                Set(ref _showPartyMessages, value);
                Save();
            }
        }
        public bool ShowGuildMessages
        {
            get => _showGuildMessages;
            set
            {
                Set(ref _showGuildMessages, value);
                Save();
            }
        }
        public bool ShowAllianceMessages
        {
            get => _showAllianceMessages;
            set
            {
                Set(ref _showAllianceMessages, value);
                Save();
            }
        }
        public bool ShowSaleMessages
        {
            get => _showSaleMessages;
            set
            {
                Set(ref _showSaleMessages, value);
                Save();
            }
        }
        public bool ShowSeekMessages
        {
            get => _showSeekMessages;
            set
            {
                Set(ref _showSeekMessages, value);
                Save();
            }
        }
        public bool ShowNoobMessages
        {
            get => _showNoobMessages;
            set
            {
                Set(ref _showNoobMessages, value);
                Save();
            }
        }
        public bool AutoRegenAccepted
        {
            get => _autoRegenAccepted;
            set
            {
                Set(ref _autoRegenAccepted, value);
                Save();
            }
        }
        public bool AcceptAchievements
        {
            get => _acceptAchivements;
            set
            {
                Set(ref _acceptAchivements, value);
                Save();
            }
        }
        public BoostableStats StatToBoost
        {
            get => _statToBoost;
            set
            {
                Set(ref _statToBoost, value);
                Save();
            }
        }
        public ObservableCollection<SpellToBoostEntry> SpellsToBoost { get; private set; }
        public ObservableCollection<int> AuthorizedTradesFrom { get; private set; }
        public bool IgnoreNonAuthorizedTrades
        {
            get => _ignoreNonAuthorizedTrades;
            set
            {
                Set(ref _ignoreNonAuthorizedTrades, value);
                Save();
            }
        }
        public bool DisconnectUponFightsLimit
        {
            get => _disconnectUponFightsLimit;
            set
            {
                Set(ref _disconnectUponFightsLimit, value);
                Save();
            }
        }
        public bool AutoMount
        {
            get => _autoMount;
            set
            {
                Set(ref _autoMount, value);
                Save();
            }
        }

        private string ConfigFilePath => Path.Combine(ConfigurationsPath, $"{_account.AccountConfig.Username}_{_account.Game.Character.Name}.config");


        // Constructor
        public Configuration(Account account)
        {
            _account = account;

            ShowGeneralMessages = true;
            ShowPartyMessages = true;
            ShowGuildMessages = true;
            ShowAllianceMessages = true;
            ShowSaleMessages = true;
            ShowSeekMessages = true;
            ShowNoobMessages = true;
            AutoRegenAccepted = true;
            AcceptAchievements = true;
            StatToBoost = BoostableStats.NONE;
            SpellsToBoost = new ObservableCollection<SpellToBoostEntry>();
            AuthorizedTradesFrom = new ObservableCollection<int>();
            IgnoreNonAuthorizedTrades = false;
            DisconnectUponFightsLimit = false;
            AutoMount = true;
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
                        ShowGeneralMessages = br.ReadBoolean();
                        ShowPartyMessages = br.ReadBoolean();
                        ShowGuildMessages = br.ReadBoolean();
                        ShowAllianceMessages = br.ReadBoolean();
                        ShowSaleMessages = br.ReadBoolean();
                        ShowSeekMessages = br.ReadBoolean();
                        ShowNoobMessages = br.ReadBoolean();
                        AutoRegenAccepted = br.ReadBoolean();
                        AcceptAchievements = br.ReadBoolean();
                        StatToBoost = (BoostableStats)br.ReadByte();

                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            SpellsToBoost.Clear();
                            byte count = br.ReadByte();
                            for (int i = 0; i < count; i++)
                            {
                                SpellsToBoost.Add(new SpellToBoostEntry(br.ReadInt32(), br.ReadString(), br.ReadByte()));
                            }

                            AuthorizedTradesFrom.Clear();
                            count = br.ReadByte();
                            for (int i = 0; i < count; i++)
                            {
                                AuthorizedTradesFrom.Add(br.ReadInt32());
                            }
                        });

                        IgnoreNonAuthorizedTrades = br.ReadBoolean();
                        DisconnectUponFightsLimit = br.ReadBoolean();
                        AutoMount = br.ReadBoolean();
                    }
                }
                catch {}
            }

            _loaded = true;
        }

        public void Save()
        {
            // Avoid saving while we're just loading
            if (!_loaded)
                return;

            // Ensure that the directory is created
            Directory.CreateDirectory(ConfigurationsPath);

            try
            {
                using (BinaryWriter bw = new BinaryWriter(File.Open(ConfigFilePath, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite)))
                {
                    bw.Write(ShowGeneralMessages);
                    bw.Write(ShowPartyMessages);
                    bw.Write(ShowGuildMessages);
                    bw.Write(ShowAllianceMessages);
                    bw.Write(ShowSaleMessages);
                    bw.Write(ShowSeekMessages);
                    bw.Write(ShowNoobMessages);
                    bw.Write(AutoRegenAccepted);
                    bw.Write(AcceptAchievements);
                    bw.Write((byte)StatToBoost);

                    bw.Write((byte)SpellsToBoost.Count);
                    foreach (var spellToBoost in SpellsToBoost)
                    {
                        bw.Write(spellToBoost.Id);
                        bw.Write(spellToBoost.Name);
                        bw.Write(spellToBoost.Level);
                    }

                    bw.Write((byte)AuthorizedTradesFrom.Count);
                    foreach (var atf in AuthorizedTradesFrom)
                    {
                        bw.Write(atf);
                    }

                    bw.Write(IgnoreNonAuthorizedTrades);
                    bw.Write(DisconnectUponFightsLimit);
                    bw.Write(AutoMount);
                }
            }
            catch {}
        }

        #region IDisposable Support

        private bool _disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                _account = null;
                SpellsToBoost = null;
                AuthorizedTradesFrom = null;

                _disposedValue = true;
            }
        }
        
        public void Dispose()
            => Dispose(true);

        #endregion

    }

}
