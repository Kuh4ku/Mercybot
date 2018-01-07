using GalaSoft.MvvmLight;
using MercyBot.Core.Accounts.InGame.Map.Entities;
using MercyBot.Protocol.Enums;
using MercyBot.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace MercyBot.Core.Accounts.Extensions.Flood
{
    public class FloodExtension : ViewModelBase, IDisposable
    {

        // Fields
        private static string[] _smileys = new[] { ":p", ":D", ":)", ":]", ":')", ":'D", ":3", "^^", ":'p", "x)", ";)" };
        private Account _account;
        private Timer _seekChannelTimer;
        private Timer _salesChannelTimer;
        private Timer _generalChannelTimer;
        private bool _running;


        // Properties
        public FloodConfiguration Configuration { get; private set; }

        private bool Running => _running && MercyBotMain.Instance.Server.IsSubscribedToTouch;


        // Constructor
        public FloodExtension(Account account)
        {
            _account = account;
            Configuration = new FloodConfiguration(account);

            _seekChannelTimer = new Timer(SeekChannel_Callback, null, Timeout.Infinite, Timeout.Infinite);
            _salesChannelTimer = new Timer(SalesChannel_Callback, null, Timeout.Infinite, Timeout.Infinite);
            _generalChannelTimer = new Timer(GeneralChannel_Callback, null, Timeout.Infinite, Timeout.Infinite);

            _account.Game.Map.PlayerJoined += Map_PlayerJoined;
            _account.Game.Map.PlayerLeft += Map_PlayerLeft;
        }


        public void Start()
        {
            if (_running)
                return;

            _seekChannelTimer.Change(0, Configuration.SeekChannelInterval * 1000);
            _salesChannelTimer.Change(0, Configuration.SalesChannelInterval * 1000);
            _generalChannelTimer.Change(0, Configuration.GeneralChannelInterval * 1000);
            _running = true;
        }

        public void Stop()
        {
            if (!_running)
                return;

            _seekChannelTimer.Change(Timeout.Infinite, Timeout.Infinite);
            _salesChannelTimer.Change(Timeout.Infinite, Timeout.Infinite);
            _generalChannelTimer.Change(Timeout.Infinite, Timeout.Infinite);
            _running = false;
        }

        private async void SeekChannel_Callback(object state)
        {
            if (!Running)
                return;

            var seekChannelSentences = GetSentences(ChatActivableChannelsEnum.CHANNEL_SEEK);
            
            if (seekChannelSentences.Count > 0)
            {
                var sentence = seekChannelSentences[Randomize.GetRandomInt(0, seekChannelSentences.Count)];
                await _account.Game.Chat.SendMessage(SetAttributes(sentence.Content), sentence.Channel);
            }
        }

        private async void SalesChannel_Callback(object state)
        {
            if (!Running)
                return;

            var salesChannelSentences = GetSentences(ChatActivableChannelsEnum.CHANNEL_SALES);
            
            if (salesChannelSentences.Count > 0)
            {
                var sentence = salesChannelSentences[Randomize.GetRandomInt(0, salesChannelSentences.Count)];
                await _account.Game.Chat.SendMessage(SetAttributes(sentence.Content), sentence.Channel);
            }
        }

        private async void GeneralChannel_Callback(object state)
        {
            if (!Running)
                return;

            var generalChannelSentences = GetSentences(ChatActivableChannelsEnum.CHANNEL_GLOBAL);

            if (generalChannelSentences.Count > 0)
            {
                var sentence = generalChannelSentences[Randomize.GetRandomInt(0, generalChannelSentences.Count)];
                await _account.Game.Chat.SendMessage(SetAttributes(sentence.Content), sentence.Channel);
            }
        }

        private async void Map_PlayerJoined(PlayerEntry player)
        {
            if (!Running)
                return;

            var privateChannelSentences = GetPrivateSentences(true, false);

            if (privateChannelSentences.Count > 0)
            {
                var sentence = privateChannelSentences[Randomize.GetRandomInt(0, privateChannelSentences.Count)];
                await _account.Game.Chat.SendMessageTo(SetAttributes(sentence.Content), player.Name);
            }
        }

        private async void Map_PlayerLeft(PlayerEntry player)
        {
            if (!Running)
                return;

            var privateChannelSentences = GetPrivateSentences(false, true);

            if (privateChannelSentences.Count > 0)
            {
                var sentence = privateChannelSentences[Randomize.GetRandomInt(0, privateChannelSentences.Count)];
                await _account.Game.Chat.SendMessageTo(SetAttributes(sentence.Content), player.Name);
            }
        }

        private string SetAttributes(string content, PlayerEntry player = null)
        {
            content = content.Replace("%nbr%", GetRandomNumber());
            content = content.Replace("%smiley%", GetRandomSmiley());

            if (player != null)
            {
                content = content.Replace("%name%", player.Name);
                content = content.Replace("%level%", player.Level.ToString());
            }

            return content;
        }

        private List<FloodSentence> GetSentences(ChatActivableChannelsEnum channel)
            => Configuration.Sentences.Where(s => s.Channel == channel).ToList();

        private List<FloodSentence> GetPrivateSentences(bool onPlayerJoined, bool onPlayerLeft)
            => Configuration.Sentences.Where(s =>
            {
                if (onPlayerJoined && !s.OnPlayerJoined)
                    return false;

                if (onPlayerLeft && !s.OnPlayerLeft)
                    return false;

                return true;
            }).ToList();

        private string GetRandomNumber()
            => $"{Randomize.GetRandomInt(0, 10)}{Randomize.GetRandomInt(0, 10)}{Randomize.GetRandomInt(0, 10)}";

        private string GetRandomSmiley()
            => _smileys[Randomize.GetRandomInt(0, _smileys.Length)];

        #region IDisposable Support

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Configuration.Dispose();
                    _seekChannelTimer.Dispose();
                    _salesChannelTimer.Dispose();
                    _generalChannelTimer.Dispose();
                }

                Configuration = null;
                _seekChannelTimer = null;
                _salesChannelTimer = null;
                _generalChannelTimer = null;
                _account = null;

                disposedValue = true;
            }
        }

        ~FloodExtension()
            => Dispose(false);

        public void Dispose()
            => Dispose(true);

        #endregion

    }
}
