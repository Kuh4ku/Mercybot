using MercyBot.Core.Accounts;
using MercyBot.Protocol.Messages;
using System.Threading.Tasks;

namespace MercyBot.Core.Frames.Game
{
    public static class StorageFrame
    {

        public static Task HandleExchangeStartedWithStorageMessage(Account account, ExchangeStartedWithStorageMessage message)
            => Task.Run(() => account.Game.Storage.Update(message));

        public static Task HandleStorageInventoryContentMessage(Account account, StorageInventoryContentMessage message)
            => Task.Run(() => account.Game.Storage.Update(message));

        public static Task HandleStorageKamasUpdateMessage(Account account, StorageKamasUpdateMessage message)
            => Task.Run(() => account.Game.Storage.Update(message));

        public static Task HandleStorageObjectUpdateMessage(Account account, StorageObjectUpdateMessage message)
            => Task.Run(() => account.Game.Storage.Update(message));

        public static Task HandleStorageObjectRemoveMessage(Account account, StorageObjectRemoveMessage message)
            => Task.Run(() => account.Game.Storage.Update(message));

        public static Task HandleStorageObjectsUpdateMessage(Account account, StorageObjectsUpdateMessage message)
            => Task.Run(() => account.Game.Storage.Update(message));

        public static Task HandleStorageObjectsRemoveMessage(Account account, StorageObjectsRemoveMessage message)
            => Task.Run(() => account.Game.Storage.Update(message));

        public static Task HandleExchangeLeaveMessage(Account account, ExchangeLeaveMessage message)
            => Task.Run(() => account.Game.Storage.Update(message));

    }
}
