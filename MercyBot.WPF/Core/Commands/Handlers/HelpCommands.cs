using System.Linq;
using MercyBot.Core.Accounts;
using System.Threading.Tasks;
using MercyBot.Configurations.Language;
using MercyBot.Protocol.Messages;

namespace MercyBot.Core.Commands.Handlers
{
    public class HelpCommands
    {

        [Command("mapId")]
        public static Task MapIdCommand(Account account)
            => Task.Run(() =>
            {
                account.Logger.LogInfo(LanguageManager.Translate("199"), LanguageManager.Translate("200", account.Game.Map.Id));
            });

        [Command("cellId")]
        public static Task CellIdCommand(Account account)
            => Task.Run(() =>
            {
                account.Logger.LogInfo(LanguageManager.Translate("199"), LanguageManager.Translate("202", account.Game.Map.PlayedCharacter.CellId));
            });

        [Command("entities")]
        public static Task EntitiesCommand(Account account)
            => Task.Run(() =>
            {
                if (!account.Game.Map.Players.Any())
                    account.Logger.LogInfo(LanguageManager.Translate("199"), "Il n'y pas de joueurs sur cette map.");
                else
                {
                    account.Logger.LogInfo(LanguageManager.Translate("199"), "Joueurs : ");
                    foreach (var p in account.Game.Map.Players)
                        account.Logger.LogInfo(LanguageManager.Translate("199"), $"   [{p.Id}] {p.Name} sur la cellule: {p.CellId}");
                }

                if (!account.Game.Map.MonstersGroups.Any())
                    account.Logger.LogInfo(LanguageManager.Translate("199"), "Il n'y pas de monstres sur cette map.");
                else
                {
                    account.Logger.LogInfo(LanguageManager.Translate("199"), "Monstres : ");
                    foreach (var m in account.Game.Map.MonstersGroups)
                        account.Logger.LogInfo(LanguageManager.Translate("199"), $"   [{m.Id}] {m.Leader.Name} | " +
                                                                  $"{m.MonstersCount} monstres de niveau {m.TotalLevel} sur la cellule: {m.CellId}");
                }

                if (!account.Game.Map.Npcs.Any())
                    account.Logger.LogInfo(LanguageManager.Translate("199"), "Il n'y pas de PNJ sur cette map.");
                else
                {
                    account.Logger.LogInfo(LanguageManager.Translate("199"), "PNJ : ");
                    foreach (var n in account.Game.Map.Npcs)
                        account.Logger.LogInfo(LanguageManager.Translate("199"), $"   [{n.Id}] ({n.NpcId}) {n.Name} sur la cellule: {n.CellId}");
                }
            });

        [Command("interactives")]
        public static Task InteractivesCommand(Account account)
            => Task.Run(() =>
            {
                if (!account.Game.Map.Interactives.Any())
                {
                    account.Logger.LogInfo(LanguageManager.Translate("199"), "Il n'y pas d'�l�ments interactifs sur cette map.");
                    return;
                }

                account.Logger.LogInfo(LanguageManager.Translate("199"), "Interactifs : ");
                foreach (var i in account.Game.Map.Interactives)
                    account.Logger.LogInfo(LanguageManager.Translate("199"), $"   [{i.Id}] {i.Name}");
            });

        [Command("player")]
        public static Task PlayerCommand(Account account, [Remainer]string player)
            => Task.Run(() =>
            {
                foreach (var p in account.Game.Map.Players)
                {
                    if (!string.Equals(player.ToLower(), p.Name.ToLower())) continue;
                    account.Logger.LogInfo(LanguageManager.Translate("199"), $"L'ID du joueur {p.Name} est {p.Id}");
                    return;
                }
                account.Logger.LogError(LanguageManager.Translate("199"), "Le joueur n'a pas �t� trouv�.");
            });

        [Command("joinFriend")]
        public static Task JoinFriendCommand(Account account, [Remainer]string player)
            => Task.Run(() => account.Network.SendMessage(new FriendJoinRequestMessage(player)));

        [Command("useZaap")]
        public static Task UseZaapCommand(Account account, string destinationMapId)
            => Task.Run(() =>
            {
                if (uint.TryParse(destinationMapId, out uint mapId))
                    account.Game.Managers.Teleportables.UseZaap(mapId);
            });

        [Command("useZaapi")]
        public static Task UseZaapiCommand(Account account, string destinationMapId)
            => Task.Run(() =>
            {
                if (uint.TryParse(destinationMapId, out uint mapId))
                    account.Game.Managers.Teleportables.UseZaapi(mapId);
            });

    }
}
