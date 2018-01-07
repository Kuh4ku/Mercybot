using MercyBot.Core.Accounts;
using MercyBot.Protocol.Messages;
using MercyBot.Server.Messages;
using MercyBot.Utility.DofusTouch;
using System.Linq;
using System.Threading.Tasks;
using MercyBot.Configurations.Language;

namespace MercyBot.Core.Frames.Connection
{
    public static class CharacterSelectionFrame
    {

        public static Task HandleCharactersListMessage(Account account, CharactersListMessage message)
            => Task.Run(async () =>
            {
                account.Game.Server.Update(message);

                if (account.AccountConfig.CharacterCreation.Create)
                {
                    await account.Extensions.CharacterCreation.Update(message);
                    return;
                }

                if (message.Characters.Count > 0)
                {
                    var character = string.IsNullOrEmpty(account.AccountConfig.Character) ?
                                    message.Characters[0] :
                                    message.Characters.FirstOrDefault(c => c.Name == account.AccountConfig.Character);


                    // In case the character the user wants wasn't found
                    if (character == null)
                    {
                        account.Logger.LogError("CharacterSelectionFrame", LanguageManager.Translate("78", account.AccountConfig.Character));
                    }
                    else
                    {
                        account.Logger.LogDebug("CharacterSelectionFrame", LanguageManager.Translate("79", character.Name, character.Level));
                        await account.Network.SendMessageAsync(new CharacterSelectionMessage((int)character.Id));
                    }
                }
                else
                {
                    account.Logger.LogError("CharacterSelectionFrame", LanguageManager.Translate("80"));
                }
            });

        public static Task HandleCharacterNameSuggestionSuccessMessage(Account account, CharacterNameSuggestionSuccessMessage message)
            => Task.Run(() => account.Extensions.CharacterCreation.Update(message));

        public static Task HandleCharacterCreationResultMessage(Account account, CharacterCreationResultMessage message)
            => Task.Run(async () => await account.Extensions.CharacterCreation.Update(message));

        public static Task HandleCharacterSelectedSuccessMessage(Account account, CharacterSelectedSuccessMessage message)
            => Task.Run(async () =>
            {
                account.Game.Character.Update(message);

                await account.Network.SendCallAsync(new kpiStartSessionMessage(account.Login));
                await account.Network.SendCallAsync(new moneyGoultinesAmountRequestMessage());
                await account.Network.SendMessageAsync(new QuestListRequestMessage());
                await account.Network.SendMessageAsync(new FriendsGetListMessage());
                await account.Network.SendMessageAsync(new IgnoredGetListMessage());
                await account.Network.SendMessageAsync(new SpouseGetInformationsMessage());
                await account.Network.SendCallAsync(new bakSoftToHardCurrentRateRequestMessage());
                await account.Network.SendCallAsync(new bakHardToSoftCurrentRateRequestMessage());
                await account.Network.SendCallAsync(new restoreMysteryBoxMessage());
                await account.Network.SendMessageAsync(new ClientKeyMessage(FlashKeyGenerator.GetRandomFlashKey()));
                await account.Network.SendMessageAsync(new GameContextCreateRequestMessage());

                MercyBotMain.Instance.Server.SendMessage(new BotSelectedSuccesMessage(account.AccountConfig.Username, (int)account.Game.Character.Id, account.Game.Character.Name, 
                    account.Game.Server.Name, account.Game.Character.Level));
            });

        public static Task HandleGameContextCreateMessage(Account account, GameContextCreateMessage message)
            => Task.Run(async () =>
            {
                if (!account.FramesData.Initialized && message.Context == 1)
                {
                    await account.Network.SendMessageAsync(new ObjectAveragePricesGetMessage());
                    account.FramesData.Initialized = true;
                }
            });

        public static Task HandleCharacterSelectedForceMessage(Account account, CharacterSelectedForceMessage message)
            => Task.Run(async () => await account.Network.SendMessageAsync(new CharacterSelectedForceReadyMessage()));

    }
}
