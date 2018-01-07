using MercyBot.Protocol.Messages;
using System;
using System.Threading.Tasks;
using MercyBot.Configurations.Language;

namespace MercyBot.Core.Accounts.Extensions.Exchanges
{
    public class RoleplayExtension : IDisposable
    {

        // Fields
        private Account _account;


        // Constructor
        public RoleplayExtension(Account account)
        {
            _account = account;

            _account.Game.Exchange.ExchangeRequested += Exchange_ExchangeRequested;
            _account.Game.Exchange.RemoteReady += Exchange_RemoteReady;
            _account.Network.RegisterMessage<GameRolePlayPlayerFightFriendlyRequestedMessage>(HandleGameRolePlayPlayerFightFriendlyRequestedMessage);
        }


        private void Exchange_ExchangeRequested(int from)
        {
            // If this character isn't authorized to trade us, refuse it
            if (!_account.Configuration.AuthorizedTradesFrom.Contains(from))
            {
                if (_account.Configuration.IgnoreNonAuthorizedTrades)
                {
                    var player = _account.Game.Map.GetPlayer(from);

                    if (player != null)
                    {
                        _account.Network.SendMessage(new IgnoredAddRequestMessage(player.Name, true));
                        _account.Network.SendMessage(new LeaveDialogRequestMessage());
                        _account.Logger.LogWarning(LanguageManager.Translate("117"), LanguageManager.Translate("382"));
                        return;
                    }
                }

                // If the IgnoreNonAuthorizedTrades option is disabled or the player wasn't found on the map (somehow)
                _account.Network.SendMessage(new LeaveDialogRequestMessage());
                _account.Logger.LogWarning(LanguageManager.Translate("117"), LanguageManager.Translate("383"));
            }
            // Otherwise accept it
            else
            {
                _account.Network.SendMessage(new ExchangeAcceptMessage());
                _account.Logger.LogInfo(LanguageManager.Translate("117"), LanguageManager.Translate("384"));
            }
        }

        private void Exchange_RemoteReady()
        {
            _account.Game.Exchange.SendReady();
        }

        private Task HandleGameRolePlayPlayerFightFriendlyRequestedMessage(Account account, GameRolePlayPlayerFightFriendlyRequestedMessage message)
            => Task.Run(async () =>
            {
                if (message.TargetId != account.Game.Character.Id)
                    return;

                await Task.Delay(1000);

                var player = account.Game.Map.GetPlayer((int)message.SourceId);

                if (player != null)
                {
                    await account.Network.SendMessageAsync(new GameRolePlayPlayerFightFriendlyAnswerMessage((int)message.FightId));
                    _account.Network.SendMessage(new IgnoredAddRequestMessage(player.Name, true));
                    _account.Network.SendMessage(new LeaveDialogRequestMessage());
                    account.Logger.LogWarning(LanguageManager.Translate("553"), LanguageManager.Translate("554"));
                }
            });

        #region IDisposable Support

        private bool _disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                _account = null;

                _disposedValue = true;
            }
        }

        public void Dispose()
            => Dispose(true);

        #endregion

    }
}
