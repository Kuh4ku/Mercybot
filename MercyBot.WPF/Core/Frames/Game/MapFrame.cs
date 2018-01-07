using MercyBot.Core.Accounts;
using MercyBot.Core.Enums;
using MercyBot.Protocol.Messages;
using System.Linq;
using System.Threading.Tasks;

namespace MercyBot.Core.Frames.Game
{
    public static class MapFrame
    {

        public static Task HandleCurrentMapMessage(Account account, CurrentMapMessage message)
            => Task.Run(async () =>
            {
                if (account.State != AccountStates.RECAPTCHA)
                {
                    account.State = AccountStates.NONE;
                }

                await account.Network.SendMessageAsync(new MapInformationsRequestMessage(message.MapId)).ConfigureAwait(false);
            });

        public static Task HandleMapComplementaryInformationsDataMessage(Account account, MapComplementaryInformationsDataMessage message)
            => Task.Factory.StartNew(async () => await account.Game.Map.Update(message).ConfigureAwait(false), TaskCreationOptions.LongRunning);

        public static Task HandleMapComplementaryInformationsDataInHouseMessage(Account account, MapComplementaryInformationsDataInHouseMessage message)
            => Task.Run(async () => await HandleMapComplementaryInformationsDataMessage(account, message).ConfigureAwait(false));

        public static Task HandleMapComplementaryInformationsWithCoordsMessage(Account account, MapComplementaryInformationsWithCoordsMessage message)
            => Task.Run(async () => await HandleMapComplementaryInformationsDataMessage(account, message).ConfigureAwait(false));

        public static Task HandleStatedMapUpdateMessage(Account account, StatedMapUpdateMessage message)
            => Task.Run(() => account.Game.Map.Update(message));

        public static Task HandleInteractiveMapUpdateMessage(Account account, InteractiveMapUpdateMessage message)
            => Task.Run(() => account.Game.Map.Update(message));

        public static Task HandleStatedElementUpdatedMessage(Account account, StatedElementUpdatedMessage message)
            => Task.Run(() => account.Game.Map.Update(message));

        public static Task HandleInteractiveElementUpdatedMessage(Account account, InteractiveElementUpdatedMessage message)
            => Task.Run(() => account.Game.Map.Update(message));

        public static Task HandleGameMapMovementMessage(Account account, GameMapMovementMessage message)
            => Task.Run(() =>
            {
                if (account.State == AccountStates.FIGHTING)
                    return;

                account.Game.Map.Update(message);
                account.Game.Managers.Movements.Update(message);
                account.Extensions.CharacterCreation.Update(message);
            });

        public static Task HandleGameContextRemoveElementMessage(Account account, GameContextRemoveElementMessage message)
            => Task.Run(() => account.Game.Map.Update(message));

        public static Task HandleTeleportOnSameMapmessage(Account account, TeleportOnSameMapMessage message)
            => Task.Run(() => account.Game.Map.Players.FirstOrDefault(p => p.Id == message.TargetId)?.Update(message));

        public static Task HandleGameContextRemoveMultipleElementsMessage(Account account, GameContextRemoveMultipleElementsMessage message)
            => Task.Run(() => account.Game.Map.Update(message));

        public static Task HandleGameRolePlayShowActorMessage(Account account, GameRolePlayShowActorMessage message)
            => Task.Run(() => account.Game.Map.Update(message));

        public static Task HandleGameMapNoMovementMessage(Account account, GameMapNoMovementMessage message)
            => Task.Run(async () =>
            {
                if (account.State == AccountStates.FIGHTING || account.State == AccountStates.RECAPTCHA)
                    return;

                account.State = AccountStates.NONE;
                await account.Game.Managers.Movements.Update(message);
            });

    }
}
