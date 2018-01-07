using System;
using System.Linq;
using System.Threading.Tasks;
using MercyBot.Configurations.Language;
using MercyBot.Core.Accounts.InGame.Managers.Interactives;
using MercyBot.Core.Accounts.InGame.Map;
using MercyBot.Protocol.Messages;
using MercyBot.Utility.Extensions;

namespace MercyBot.Core.Accounts.InGame.Managers.Teleportables
{
    public class TeleportablesManager : IDisposable
    {

        // Fields
        private Account _account;
        private Teleportables _teleportable;
        private uint _destinationMapId;


        // Events
        public event Action<bool> UseFinished;


        // Constructor
        public TeleportablesManager(Account account, InteractivesManager interactives, MapGame map)
        {
            _account = account;

            _teleportable = Teleportables.NONE;
            _account.Network.RegisterMessage<ZaapListMessage>(HandleZaapListMessage);
            _account.Network.RegisterMessage<TeleportDestinationsListMessage>(HandleTeleportDestinationsListMessage);
            map.MapChanged += Map_MapChanged;
            interactives.UseFinished += Interactives_UseFinished;
        }


        public bool SaveZaap()
        {
            if (_account.IsBusy)
            {
                _account.Logger.LogWarning("TeleportablesManager", "Account is busy.");
                return false;
            }

            if (_account.Game.Map.Zaap == null)
            {
                _account.Logger.LogWarning("TeleportablesManager", LanguageManager.Translate("537"));
                return false;
            }

            return _account.Game.Managers.Interactives.MoveToUseInteractive(_account.Game.Map.Zaap.Element, _account.Game.Map.Zaap.CellId,
                (int)_account.Game.Map.Zaap.Element.EnabledSkills.FirstOrDefault(s => s.Id == 44).InstanceUID);
        }

        public bool UseZaap(uint destinationMapId)
        {
            if (_account.IsBusy)
            {
                _account.Logger.LogWarning("TeleportablesManager", "Account is busy.");
                return false;
            }

            if (_account.Game.Map.Zaap == null)
            {
                _account.Logger.LogWarning("TeleportablesManager", LanguageManager.Translate("537"));
                return false;
            }

            if (!_account.Game.Managers.Interactives.MoveToUseInteractive(_account.Game.Map.Zaap.Element, _account.Game.Map.Zaap.CellId, -1))
                return false;

            _teleportable = Teleportables.ZAAP;
            _destinationMapId = destinationMapId;
            return true;
        }

        public bool UseZaapi(uint destinationMapId)
        {
            if (_account.IsBusy)
            {
                _account.Logger.LogWarning("TeleportablesManager", "Account is busy.");
                return false;
            }

            if (_account.Game.Map.Zaapi == null)
            {
                _account.Logger.LogWarning("TeleportablesManager", LanguageManager.Translate("538"));
                return false;
            }

            if (!_account.Game.Managers.Interactives.MoveToUseInteractive(_account.Game.Map.Zaapi.Element, _account.Game.Map.Zaapi.CellId, -1))
                return false;

            _teleportable = Teleportables.ZAAPI;
            _destinationMapId = destinationMapId;
            return true;
        }

        public void Cancel()
        {
            _teleportable = Teleportables.NONE;
            _destinationMapId = 0;
        }

        private void Interactives_UseFinished(bool success)
        {
            if (_teleportable == Teleportables.NONE || _destinationMapId == 0)
                return;

            if (!success)
            {
                _account.Logger.LogWarning("TeleportablesManager", LanguageManager.Translate("540", _teleportable.ToString().ToLower()));
                OnUseFinished(false);
            }
        }

        private Task HandleZaapListMessage(Account account, ZaapListMessage message)
            => Task.Run(async () =>
            {
                await Task.Delay(1000);

                if (_teleportable != Teleportables.ZAAP || _destinationMapId == 0)
                    return;

                if (!message.MapIds.Contains(_destinationMapId))
                {
                    _account.Logger.LogWarning("TeleportablesManager", LanguageManager.Translate("541", _destinationMapId, _teleportable.ToString().ToLower()));
                    OnUseFinished(false);
                    return;
                }

                _account.Logger.LogDebug("TeleportablesManager", LanguageManager.Translate("542", _destinationMapId));
                await _account.Network.SendMessageAsync(new TeleportRequestMessage((uint)_teleportable, _destinationMapId));
            });

        public Task HandleTeleportDestinationsListMessage(Account account, TeleportDestinationsListMessage message)
            => Task.Run(async () =>
            {
                await Task.Delay(1000);

                if (_teleportable != Teleportables.ZAAPI || _destinationMapId == 0)
                    return;

                if (!message.MapIds.Contains(_destinationMapId))
                {
                    _account.Logger.LogWarning("TeleportablesManager", LanguageManager.Translate("541", _destinationMapId, _teleportable.ToString().ToLower()));
                    OnUseFinished(false);
                    return;
                }

                _account.Logger.LogDebug("TeleportablesManager", LanguageManager.Translate("542", _destinationMapId));
                await _account.Network.SendMessageAsync(new TeleportRequestMessage((uint)_teleportable, _destinationMapId));
            });

        private void Map_MapChanged()
        {
            if (_teleportable == Teleportables.NONE || _destinationMapId == 0)
                return;

            _account.Logger.LogInfo("TeleportablesManager", LanguageManager.Translate("543", _teleportable.ToString().PureCapitalize()));
            OnUseFinished(true);
        }

        private void OnUseFinished(bool success)
        {
            Cancel();
            UseFinished?.Invoke(success);
        }

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

        public void Dispose() => Dispose(true);

        #endregion

    }
}
