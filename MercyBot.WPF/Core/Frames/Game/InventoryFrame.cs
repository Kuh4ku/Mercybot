using MercyBot.Core.Accounts;
using MercyBot.Protocol.Messages;
using System.Threading.Tasks;

namespace MercyBot.Core.Frames.Game
{
    public static class InventoryFrame
    {

        public static Task HandleKamasUpdateMessage(Account account, KamasUpdateMessage message)
            => Task.Run(() => account.Game.Character.Inventory.Update(message));

        public static Task HandleInventoryWeightMessage(Account account, InventoryWeightMessage message)
            => Task.Run(() => account.Game.Character.Inventory.Update(message));

        public static Task HandleObjectsQuantityMessage(Account account, ObjectsQuantityMessage message)
            => Task.Run(() => account.Game.Character.Inventory.Update(message));

        public static Task HandleObjectQuantityMessage(Account account, ObjectQuantityMessage message)
            => Task.Run(() => account.Game.Character.Inventory.Update(message));

        public static Task HandleObjectMovementMessage(Account account, ObjectMovementMessage message)
            => Task.Run(() => account.Game.Character.Inventory.Update(message));

        public static Task HandleObjectModifiedMessage(Account account, ObjectModifiedMessage message)
            => Task.Run(() => account.Game.Character.Inventory.Update(message));

        public static Task HandleObjectsDeletedMessage(Account account, ObjectsDeletedMessage message)
            => Task.Run(() => account.Game.Character.Inventory.Update(message));

        public static Task HandleObjectDeletedMessage(Account account, ObjectDeletedMessage message)
            => Task.Run(() => account.Game.Character.Inventory.Update(message));

        public static Task HandleObjectsAddedMessage(Account account, ObjectsAddedMessage message)
            => Task.Run(() => account.Game.Character.Inventory.Update(message));

        public static Task HandleObjectAddedMessage(Account account, ObjectAddedMessage message)
            => Task.Run(() => account.Game.Character.Inventory.Update(message));

        public static Task HandleInventoryContentMessage(Account account, InventoryContentMessage message)
            => Task.Run(() => account.Game.Character.Inventory.Update(message));

        public static Task HandleDisplayNumericalValueMessage(Account account, DisplayNumericalValueMessage message)
            => Task.Run(() => account.Statistics.Update(message));

    }
}
