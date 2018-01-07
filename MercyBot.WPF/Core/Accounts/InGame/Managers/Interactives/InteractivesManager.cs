using MercyBot.Core.Accounts.InGame.Managers.Movements;
using MercyBot.Core.Accounts.InGame.Map.Interactives;
using MercyBot.Protocol.Messages;
using System;
using System.Linq;
using System.Threading.Tasks;
using MercyBot.Configurations.Language;

namespace MercyBot.Core.Accounts.InGame.Managers.Interactives
{
    public class InteractivesManager : IDisposable
    {

        // Fields
        private Account _account;
        private InteractiveElementEntry _interactiveToUse;
        private int _skillInstanceUid;
        private string _lockCode;


        // Events
        public event Action<bool> UseFinished;


        // Constructor
        public InteractivesManager(Account account, MovementsManager movements)
        {
            _account = account;

            movements.MovementFinished += Movements_MovementFinished;
            _account.Network.RegisterMessage<InteractiveUsedMessage>(HandleInteractiveUsedMessage);
            _account.Network.RegisterMessage<InteractiveUseErrorMessage>(HandleInteractiveUseErrorMessage);
            _account.Network.RegisterMessage<LockableShowCodeDialogMessage>(HandleLockableShowCodeDialogMessage);
            _account.Network.RegisterMessage<LockableCodeResultMessage>(HandleLockableCodeResultMessage);
            _account.Network.RegisterMessage<LockableStateUpdateHouseDoorMessage>(HandleLockableStateUpdateHouseDoorMessage);
            _account.Network.RegisterMessage<LockableStateUpdateStorageMessage>(HandleLockableStateUpdateStorageMessage);
        }


        public InteractiveElementEntry GetElementOnCell(short cellId)
        {
            // Search for a stated element in the cell
            // (not sure if its good to search in stated elements).
            var statedElem = _account.Game.Map.StatedElements.FirstOrDefault(s => s.CellId == cellId);
            if (statedElem != null && statedElem.State == 0)
                return _account.Game.Map.GetInteractiveElement((int)statedElem.Id);

            // Search for a door in the cell
            var door = _account.Game.Map.Doors.FirstOrDefault(d => d.CellId == cellId);
            if (door != null)
                return door.Element;

            // Search for a phenix in the cell
            var phenix = _account.Game.Map.Phenixs.FirstOrDefault(ph => ph.CellId == cellId);
            if (phenix != null)
                return phenix.Element;

            // Search for a locked storage in the cell
            var lockedStorage = _account.Game.Map.LockedStroages.First(ls => ls.CellId == cellId);
            if (lockedStorage != null)
                return lockedStorage.Element;

            _account.Logger.LogWarning("InteractivesManager", LanguageManager.Translate("536", cellId));
            return null;
        }

        public bool UseInteractive(int interactiveId, int skillInstanceUid = -1)
        {
            var interactive = _account.Game.Map.GetInteractiveElement(interactiveId);

            if (interactive == null || !interactive.Usable)
                return false;

            var statedElem = _account.Game.Map.GetStatedElement(interactiveId);

            if (statedElem == null || statedElem.State != 0)
                return false;

            return MoveToUseInteractive(interactive, statedElem.CellId, skillInstanceUid);
        }

        public bool UseInteractive(short interactiveCellId, int skillInstanceUid = -1)
        {
            var interactive = GetElementOnCell(interactiveCellId);
            return interactive != null && MoveToUseInteractive(interactive, interactiveCellId, skillInstanceUid);
        }

        public bool UseLockedDoor(short doorCellId, string lockCode)
        {
            if (lockCode.Length <= 0 || lockCode.Length > 8)
            {
                _account.Logger.LogWarning("InteractivesManager", LanguageManager.Translate("561"));
                return false;
            }

            var interactive = GetElementOnCell(doorCellId);
            return interactive != null && MoveToUseInteractive(interactive, doorCellId, -1, lockCode);
        }

        public bool UseLockedStorage(short elementCellId, string lockCode)
        {
            if (lockCode.Length <= 0 || lockCode.Length > 8)
            {
                _account.Logger.LogWarning("InteractivesManager", LanguageManager.Translate("561"));
                return false;
            }

            var interactive = GetElementOnCell(elementCellId);
            return interactive != null && MoveToUseInteractive(interactive, elementCellId, -1, lockCode);
        }

        public void CancelUse()
            => _interactiveToUse = null;

        public bool MoveToUseInteractive(InteractiveElementEntry interactive, short interactiveCellId, int skillInstanceUid, string lockCode = null)
        {
            if (_account.IsBusy || _interactiveToUse != null)
                return false;

            if (interactive == null || !interactive.Usable)
                return false;

            _interactiveToUse = interactive;
            _skillInstanceUid = skillInstanceUid;
            _lockCode = lockCode;

            switch (_account.Game.Managers.Movements.MoveToCell(interactiveCellId, true))
            {
                case MovementRequestResults.MOVED:
                    _account.Logger.LogDebug(LanguageManager.Translate("128"), LanguageManager.Translate("129", interactiveCellId, interactive.Id));
                    return true;
                case MovementRequestResults.ALREADY_THERE:
                    UseTheElement();
                    return true;
                default: // FAILED
                    Clear();
                    return false;
            }
        }

        private void Movements_MovementFinished(bool success)
        {
            if (_interactiveToUse == null)
                return;

            if (success)
            {
                UseTheElement();
            }
            else
            {
                OnUseFinished(false);
            }
        }

        private void UseTheElement()
        {
            if (_interactiveToUse == null)
                return;

            // In case the skill is negative (used like an index)
            if (_skillInstanceUid < 0)
            {
                int index = (_skillInstanceUid * -1) - 1;

                // Check if the index is invalid
                if (_interactiveToUse.EnabledSkills.Count <= index)
                {
                    OnUseFinished(false);
                    return;
                }

                _skillInstanceUid = (int)_interactiveToUse.EnabledSkills[index].InstanceUID;
            }

            _account.Logger.LogDebug(LanguageManager.Translate("128"), LanguageManager.Translate("130", _interactiveToUse.Id));
            _account.Network.SendMessage(new InteractiveUseRequestMessage(_interactiveToUse.Id, (uint)_skillInstanceUid));
        }

        private Task HandleInteractiveUsedMessage(Account account, InteractiveUsedMessage message)
            => Task.Run(() =>
            {
                if (_interactiveToUse == null || message.EntityId != account.Game.Character.Id)
                    return;

                account.Logger.LogInfo(LanguageManager.Translate("128"), LanguageManager.Translate("131", _interactiveToUse.Id));

                // Only fire this event when we're not using a locked door
                if (_lockCode == null)
                    OnUseFinished(true);
            });

        private Task HandleInteractiveUseErrorMessage(Account account, InteractiveUseErrorMessage message)
            => Task.Run(() =>
            {
                if (_interactiveToUse == null)
                    return;

                OnUseFinished(false);
            });

        private Task HandleLockableShowCodeDialogMessage(Account account, LockableShowCodeDialogMessage message)
            => Task.Run(async () =>
            {
                await Task.Delay(1000);

                if (_interactiveToUse == null || _lockCode == null)
                    return;

                account.Logger.LogDebug(LanguageManager.Translate("128"), LanguageManager.Translate("562"));
                await account.Network.SendMessageAsync(new LockableUseCodeMessage(_lockCode.PadRight(8, '_')));
            });

        private Task HandleLockableCodeResultMessage(Account account, LockableCodeResultMessage message)
            => Task.Run(() =>
            {
                if (_interactiveToUse == null || _lockCode == null)
                    return;

                if (message.Result != 1)
                    return;

                account.Logger.LogWarning(LanguageManager.Translate("128"), LanguageManager.Translate("563"));
                OnUseFinished(false);
            });

        private Task HandleLockableStateUpdateHouseDoorMessage(Account account, LockableStateUpdateHouseDoorMessage message)
            => Task.Run(() =>
            {
                if (_interactiveToUse == null || _lockCode == null)
                    return;

                if (!message.Locked)
                {
                    account.Logger.LogInfo(LanguageManager.Translate("128"), LanguageManager.Translate("564"));
                    OnUseFinished(true);
                }
            });

        private Task HandleLockableStateUpdateStorageMessage(Account account, LockableStateUpdateStorageMessage message)
            => Task.Run(() =>
            {
                if (_interactiveToUse == null || _lockCode == null)
                    return;

                if (!message.Locked && message.ElementId == _interactiveToUse.Id)
                {
                    account.Logger.LogInfo(LanguageManager.Translate("128"), LanguageManager.Translate("567"));
                    OnUseFinished(true);
                }
            });

        private void OnUseFinished(bool success)
        {
            _interactiveToUse = null;
            _skillInstanceUid = 0;
            _lockCode = null;
            UseFinished?.Invoke(success);
        }

        public void Clear()
        {
            _interactiveToUse = null;
            _skillInstanceUid = 0;
            _lockCode = null;
        }

        #region IDisposable Support

        private bool _disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                _interactiveToUse = null;
                _account = null;

                _disposedValue = true;
            }
        }

        ~InteractivesManager() => Dispose(false);

        public void Dispose() => Dispose(true);

        #endregion

    }
}
