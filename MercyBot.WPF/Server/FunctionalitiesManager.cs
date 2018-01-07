using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using MahApps.Metro.Controls.Dialogs;
using MercyBot.Core.Accounts;
using MercyBot.Core.Groups;
using MercyBot.Server.Enums;
using MercyBot.Server.Messages;
using MercyBot.Configurations;
using MercyBot.Configurations.Language;
using MercyBot.WPF.Views;
using MoonSharp.Interpreter;

namespace MercyBot.Server
{
    public static class FunctionalitiesManager
    {

        public static void Initialize()
        {
            MercyBotMain.Instance.Server.RegisterMessage<SetProxyMessage>(HandleSetProxyMessage);
            MercyBotMain.Instance.Server.RegisterMessage<AddAuthorizedTradeFromMessage>(HandleAddAuthorizedTradeFromMessage);
            MercyBotMain.Instance.Server.RegisterMessage<LoadScriptMessage>(HandleLoadScriptMessage);
            MercyBotMain.Instance.Server.RegisterMessage<StartScriptMessage>(HandleStartScriptMessage);
            MercyBotMain.Instance.Server.RegisterMessage<StartBidExtensionMessage>(HandleStartBidExtensionMessage);
            MercyBotMain.Instance.Server.RegisterMessage<StartFloodExtensionMessage>(HandleStartFloodExtensionMessage);
            MercyBotMain.Instance.Server.RegisterMessage<InvalidOperationMessage>(HandleInvalidOperationMessage);
            MercyBotMain.Instance.Server.RegisterMessage<QuickActionMessage>(HandleQuickActionMessage);
        }

        private static void HandleSetProxyMessage(SetProxyMessage message)
        {
            var account = GlobalConfiguration.Instance.Accounts.FirstOrDefault(a => a.Username == message.Account);

            if (account == null)
                return;

            account.SetProxy(message.IpAddress, message.Port, message.Username, message.Password);
            GlobalConfiguration.Instance.Save();
        }

        private static void HandleAddAuthorizedTradeFromMessage(AddAuthorizedTradeFromMessage message)
        {
            var account = GetConnectedAccount(message.Account);

            if (account == null)
                return;

            Application.Current.Dispatcher.Invoke(() => account.Configuration.AuthorizedTradesFrom.Add(message.CharacterId));
            account.Configuration.Save();
        }

        private static void HandleLoadScriptMessage(LoadScriptMessage message)
        {
            var account = GetConnectedAccount(message.Account);

            if (account == null)
                return;

            try
            {
                account.Scripts.FromFile(message.Path);
            }
            catch (SyntaxErrorException ex)
            {
                account.Logger.LogError("Scripts", ex.DecoratedMessage);
            }
            catch (Exception ex)
            {
                account.Logger.LogError(LanguageManager.Translate("165"), ex.ToString());
            }
        }

        private static void HandleStartScriptMessage(StartScriptMessage message)
        {
            var account = GetConnectedAccount(message.Account);

            if (account == null)
                return;

            try
            {
                account.Scripts.StartScript();
            }
            catch (Exception ex)
            {
                account.Logger.LogError(LanguageManager.Translate("165"), ex.ToString());
            }
        }

        private static void HandleStartBidExtensionMessage(StartBidExtensionMessage message)
        {
            var account = GetConnectedAccount(message.Account);

            if (account == null)
                return;

            try
            {
                account.Extensions.Bid.Start();
            }
            catch (Exception ex)
            {
                account.Logger.LogError(LanguageManager.Translate("34"), ex.ToString());
            }
        }

        private static void HandleStartFloodExtensionMessage(StartFloodExtensionMessage message)
        {
            var account = GetConnectedAccount(message.Account);

            if (account == null)
                return;

            try
            {
                account.Extensions.Flood.Start();
            }
            catch (Exception ex)
            {
                account.Logger.LogError("Flood", ex.ToString());
            }
        }

        private static void HandleInvalidOperationMessage(InvalidOperationMessage message)
        {
            Application.Current.Dispatcher.Invoke(async () =>
            {
                switch (message.Operation)
                {
                    case InvalidOperations.MAX_ACCOUNTS_REACHED:
                        await MainWindow.Instance.ShowMessageAsync(LanguageManager.Translate("249"), LanguageManager.Translate("399"));
                        break;
                    case InvalidOperations.UNAUTHORIZED_PROX_SET:
                        await MainWindow.Instance.ShowMessageAsync(LanguageManager.Translate("249"), LanguageManager.Translate("407"));
                        break;
                    case InvalidOperations.UNAUTHORIZED_EXCHANGES:
                        await MainWindow.Instance.ShowMessageAsync(LanguageManager.Translate("249"), LanguageManager.Translate("408"));
                        break;
                    case InvalidOperations.UNAUTHORIZED_OPEN_BANGS:
                        await MainWindow.Instance.ShowMessageAsync(LanguageManager.Translate("249"), LanguageManager.Translate("409"));
                        break;
                    case InvalidOperations.UNAUTHORIZED_AUTO_DELETE:
                        await MainWindow.Instance.ShowMessageAsync(LanguageManager.Translate("249"), LanguageManager.Translate("410"));
                        break;
                    case InvalidOperations.UNAUTHORIZED_PHENIX_FUNCTION:
                        await MainWindow.Instance.ShowMessageAsync(LanguageManager.Translate("249"), LanguageManager.Translate("411"));
                        break;
                    case InvalidOperations.UNAUTHORIZED_BID:
                        await MainWindow.Instance.ShowMessageAsync(LanguageManager.Translate("249"), LanguageManager.Translate("412"));
                        break;
                    case InvalidOperations.MAX_LEVEL_REACHED:
                        await MainWindow.Instance.ShowMessageAsync(LanguageManager.Translate("249"), LanguageManager.Translate("413"));
                        break;
                    case InvalidOperations.UNAUTHORIZED_GROUPS:
                        await MainWindow.Instance.ShowMessageAsync(LanguageManager.Translate("249"), LanguageManager.Translate("414"));
                        break;
                }
            });
        }

        private static void HandleQuickActionMessage(QuickActionMessage message)
        {
            if (message.Accounts.Length == 0)
                return;

            switch (message.Action)
            {
                case 0 when message.Parameters.Length == 1: // Load a script

                    foreach (var account in GetConnectAccounts(message.Accounts))
                    {
                        try
                        {
                            account.Scripts.FromFile(message.Parameters[0]);
                        }
                        catch (SyntaxErrorException ex)
                        {
                            account.Logger.LogError("Scripts", ex.DecoratedMessage);
                        }
                        catch (Exception ex)
                        {
                            account.Logger.LogError(LanguageManager.Translate("165"), ex.ToString());
                        }
                    }

                    break;
                case 1: // Start the scrpit

                    foreach (var account in GetConnectAccounts(message.Accounts))
                    {
                        try
                        {
                            account.Scripts.StartScript();
                        }
                        catch (Exception ex)
                        {
                            account.Logger.LogError(LanguageManager.Translate("165"), ex.ToString());
                        }
                    }

                    break;
            }
        }

        // This function will only be used by quick actions, so no need to look into the groups' members
        private static IEnumerable<Account> GetConnectAccounts(string[] usernames)
            => MercyBotMain.Instance.ConnectedAccounts.Where(a => usernames.Contains(a.AccountConfig.Username));

        private static Account GetConnectedAccount(string username)
        {
            foreach (var entity in MercyBotMain.Instance.Entities.ToArray())
            {
                if (entity is Account account && account.AccountConfig.Username == username)
                    return account;

                if (entity is Group group)
                {
                    if (group.Chief.AccountConfig.Username == username)
                        return group.Chief;

                    for (int i = 0; i < group.Members.Count; i++)
                    {
                        if (group.Members[i].AccountConfig.Username == username)
                            return group.Members[i];
                    }
                }
            }

            return null;
        }

    }
}
