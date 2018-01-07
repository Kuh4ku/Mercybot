using GalaSoft.MvvmLight;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using MercyBot.Configurations.Language;

namespace MercyBot.Core.Accounts.Extensions.Flood
{
    public class FloodConfiguration : ViewModelBase, IDisposable
    {

        // Fields
        private const string configurationsPath = @"Parameters\Flood";
        private Account _account;
        private bool _loaded;
        private short _seekChannelInterval;
        private short _salesChannelInterval;
        private short _generalChannelInterval;


        // Properties
        public ObservableCollection<FloodSentence> Sentences { get; private set; }
        public short SeekChannelInterval
        {
            get => _seekChannelInterval;
            set
            {
                Set(ref _seekChannelInterval, value);
                Save();
            }
        }
        public short SalesChannelInterval
        {
            get => _salesChannelInterval;
            set
            {
                Set(ref _salesChannelInterval, value);
                Save();
            }
        }
        public short GeneralChannelInterval
        {
            get => _generalChannelInterval;
            set
            {
                Set(ref _generalChannelInterval, value);
                Save();
            }
        }

        private string ConfigFilePath => Path.Combine(configurationsPath, LanguageManager.Translate("68", _account.AccountConfig.Username, _account.Game.Character.Name));


        // Constructor
        public FloodConfiguration(Account account)
        {
            _account = account;
            _seekChannelInterval = 60;
            _salesChannelInterval = 120;
            _generalChannelInterval = 30;

            Sentences = new ObservableCollection<FloodSentence>();
        }


        public void Load()
        {
            _loaded = false;

            if (File.Exists(ConfigFilePath))
            {
                using (BinaryReader br = new BinaryReader(File.Open(ConfigFilePath, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite)))
                {
                    SeekChannelInterval = br.ReadInt16();
                    SalesChannelInterval = br.ReadInt16();
                    GeneralChannelInterval = br.ReadInt16();

                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        Sentences.Clear();
                        int count = br.ReadByte();
                        for (int i = 0; i < count; i++)
                            Sentences.Add(FloodSentence.Load(br));
                    });
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
            Directory.CreateDirectory(configurationsPath);

            using (BinaryWriter bw = new BinaryWriter(File.Open(ConfigFilePath, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite)))
            {
                bw.Write(SeekChannelInterval);
                bw.Write(SalesChannelInterval);
                bw.Write(GeneralChannelInterval);

                bw.Write((byte)Sentences.Count);
                for (int i = 0; i < Sentences.Count; i++)
                    Sentences[i].Save(bw);
            }
        }

        #region IDisposable Support

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                _account = null;

                disposedValue = true;
            }
        }

        ~FloodConfiguration() => Dispose(false);

        public void Dispose() => Dispose(true);

        #endregion

    }
}
