using MercyBot.Core.Accounts;
using MercyBot.Server;
using MercyBot.Configurations;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.Windows;
using MahApps.Metro.Controls.Dialogs;
using GalaSoft.MvvmLight;
using MercyBot.Core;
using MercyBot.Core.Groups;
using MercyBot.Server.Messages;
using System.Linq;
using MercyBot.Configurations.Language;
using MercyBot.WPF.Views;

namespace MercyBot
{
    public class MercyBotMain : ViewModelBase
    {

        #region Singleton

        private static MercyBotMain _instance;

        public static MercyBotMain Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new MercyBotMain();

                return _instance;
            }
        }

        #endregion

        // Fields
        private Account _selectedAccount;


        // Properties
        public ServerManager Server { get; }
        public ObservableCollection<IEntity> Entities { get; }
        public Account SelectedAccount
        {
            get => _selectedAccount;
            set => Set(ref _selectedAccount, value);
        }

        public IEnumerable<Account> ConnectedAccounts => Entities.Select(e =>
        {
            if (e is Account a) return a;
            return (e as Group).Chief;
        });

        // Constructor
        public MercyBotMain()
        {
            Server = new ServerManager();
            Entities = new ObservableCollection<IEntity>();

            // Accounts
            Server.RegisterMessage<ConnectAccountMessage>(HandleConnectAccountMessage);
            Server.RegisterMessage<ConnectAccountsMessage>(HandleConnectAccountsMessage);
            Server.RegisterMessage<ConnectGroupMessage>(HandleConnectGroupMessage);
        }


        public void ConnectAccounts(IEnumerable<AccountConfiguration> accountConfigs)
        {
            Application.Current.Dispatcher.Invoke(async () =>
            {
                foreach (var accountConfig in accountConfigs)
                {
                    try
                    {
                        var account = new Account(accountConfig);
                        Application.Current.Dispatcher.Invoke(() => Entities.Add(account));
                        SelectedAccount = account;

                        Task.Run(account.Connect);
                    }
                    catch (Exception ex)
                    {
                        await MainWindow.Instance.ShowMessageAsync(LanguageManager.Translate("249"), LanguageManager.Translate("1", accountConfig.Username, ex.Message));
                        Server.SendMessage(new RemoveAccountRequestMessage(accountConfig.Username));
                    }
                }
            });
        }

        public void ConnectGroup(AccountConfiguration chief, IEnumerable<AccountConfiguration> members)
        {
            var group = new Group(new Account(chief));
            foreach (var member in members)
            {
                group.AddMember(new Account(member));
            }

            Application.Current.Dispatcher.Invoke(() =>
            {
                Entities.Add(group);
                SelectedAccount = group.Chief;

                group.Connect();
            });
        }

        public async Task RemoveSelectedAccount()
        {
            if (SelectedAccount == null)
                return;

            var account = SelectedAccount;
            int index = -1;

            // Remove the account from the list
            for (int i = Entities.Count - 1; i >= 0; i--)
            {
                if (Entities[i] is Account acc && acc == account)
                {
                    index = i;
                    await DisconnectAccount(account);
                    Entities.RemoveAt(i);
                    break;
                }

                if (Entities[i] is Group group)
                {
                    // In case the user wants to remove the chief, remove the whole group
                    if (group.Chief == account)
                    {
                        await RemoveGroup(group, i);
                        return;
                    }

                    for (int j = group.Members.Count - 1; j >= 0; j--)
                    {
                        if (group.Members[j] != account)
                            continue;

                        index = i;
                        await DisconnectAccount(account);
                        group.Members.RemoveAt(j);
                        break;
                    }
                }
            }

            // Set another account as a SelectedAccount
            RefreshSelectedAccount(index);

            // Send the RemoveAccountRequestMessage and dispose the removed account
            Server.SendMessage(new RemoveAccountRequestMessage(account.AccountConfig.Username));
            account.Dispose();
        }

        private async Task RemoveGroup(Group group, int index)
        {
            // Disconnect the chief
            await DisconnectAccount(group.Chief);

            // Disconnect the members
            for (int i = group.Members.Count - 1; i >= 0; i--)
            {
                await DisconnectAccount(group.Members[i]);
            }

            // Remove the group from Entities
            Entities.RemoveAt(index);

            // Set another account as a SelectedAccount
            RefreshSelectedAccount(index);

            // Send the RemoveAccountsRequestMessage and dispose the removed group
            Server.SendMessage(new RemoveAccountsRequestMessage(group.Members.Select(m => m.AccountConfig.Username)
                .Concat(new[] { group.Chief.AccountConfig.Username }).ToList()));
            group.Dispose();
        }

        private void RefreshSelectedAccount(int index)
        {
            // If there are no accounts left, set it to null
            if (Entities.Count == 0 || index == -1)
            {
                SelectedAccount = null;
            }
            // Otherwise look for another one
            else
            {
                index = index > Entities.Count - 1 ? Entities.Count - 1 : index;

                if (Entities[index] is Group group)
                    SelectedAccount = group.Chief;
                else
                    SelectedAccount = Entities[index] as Account;
            }
        }

        #region Received messages

        private void HandleConnectAccountMessage(ConnectAccountMessage message)
        {
            var accountConfig = GlobalConfiguration.Instance.AccountsList.FirstOrDefault(a => a.Username == message.Username);

            if (accountConfig != null)
            {
                ConnectAccounts(new[] { accountConfig });
            }
        }

        private void HandleConnectAccountsMessage(ConnectAccountsMessage message)
        {
            List<AccountConfiguration> accountsToConnect = new List<AccountConfiguration>();
            foreach (var accountConfig in GlobalConfiguration.Instance.AccountsList)
            {
                if (message.Usernames.Contains(accountConfig.Username))
                {
                    accountsToConnect.Add(accountConfig);
                }
            }

            if (accountsToConnect.Count > 0)
            {
                ConnectAccounts(accountsToConnect);
            }
        }

        private void HandleConnectGroupMessage(ConnectGroupMessage message)
        {
            if (message.Usernames.Count < 2 || message.Usernames.Count > 8)
                return;

            var accountsList = GlobalConfiguration.Instance.AccountsList;
            AccountConfiguration chief = accountsList.FirstOrDefault(a => a.Username == message.Usernames[0]);

            if (chief != null)
            {
                List<AccountConfiguration> members = new List<AccountConfiguration>();

                for (int i = 0; i < accountsList.Count; i++)
                {
                    if (accountsList[i] == chief)
                        continue;

                    if (message.Usernames.Contains(accountsList[i].Username))
                        members.Add(accountsList[i]);
                }

                // Only connect the group if the numbers fit
                if (message.Usernames.Count == members.Count + 1)
                {
                    ConnectGroup(chief, members);
                }
            }
        }

        #endregion

        public static async Task DisconnectAccount(Account account)
        {
            if (account.Network?.Connected == true)
            {
                await account.Network.Disconnect("CLIENT_CLOSING");
                await Task.Delay(400);
            }
        }

    }
}