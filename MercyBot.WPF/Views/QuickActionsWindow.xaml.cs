using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using MercyBot.Configurations;
using MercyBot.Configurations.Language;
using MercyBot.Core.Accounts;
using MercyBot.Core.Enums;
using MercyBot.Server.Messages;
using Microsoft.Win32;

namespace MercyBot.Views
{
    public partial class QuickActionsWindow
    {

        // Constructor
        public QuickActionsWindow()
        {
            InitializeComponent();

            DataContext = MercyBotMain.Instance;
        }


        private void BtnSelectAll_OnClick(object sender, RoutedEventArgs e)
        {
            LbAccounts.SelectAll();
        }

        private void BtnUnselectAll_OnClick(object sender, RoutedEventArgs e)
        {
            LbAccounts.UnselectAll();
        }

        private void BtnConnecAllAccounts_OnClick(object sender, RoutedEventArgs e)
        {
            foreach (Account account in LbAccounts.SelectedItems)
            {
                try
                {
                    if (account.State == AccountStates.DISCONNECTED)
                    {
                        // We don't need to await this
                        Task.Run(account.Connect);
                    }
                }
                catch { }
            }
        }

        private void BtnDisconnecAllAccounts_OnClick(object sender, RoutedEventArgs e)
        {
            foreach (Account account in LbAccounts.SelectedItems)
            {
                try
                {
                    if (account.Network.Connected)
                    {
                        // We don't need to await this
                        Task.Run(() => account.Network.Disconnect("CLIENT_CLOSING"));
                    }
                }
                catch { }
            }
        }

        private void BtnLoadScriptOnAllAccounts_OnClick(object sender, RoutedEventArgs e)
        {
            if (LbAccounts.SelectedItems.Count == 0)
                return;

            try
            {
                var ofd = new OpenFileDialog
                {
                    Filter = "Lua file (.lua) | *.lua"
                };

                var result = ofd.ShowDialog();
                if (result.HasValue && result.Value)
                {
                    MercyBotMain.Instance.Server.SendMessage(new QuickActionRequestMessage(LbAccounts.SelectedItems.Cast<Account>().Select(a => a.AccountConfig.Username).ToArray(), 0, 
                        new[]{ ofd.FileName, File.ReadAllText(ofd.FileName) }));
                }
            }
            catch { }
        }

        private void BtnStartScriptOnAllAccounts_OnClick(object sender, RoutedEventArgs e)
        {
            if (LbAccounts.SelectedItems.Count == 0)
                return;

            MercyBotMain.Instance.Server.SendMessage(new QuickActionRequestMessage(LbAccounts.SelectedItems.Cast<Account>().Select(a => a.AccountConfig.Username).ToArray(), 1, new string[0]));
        }

        private void BtnStopScriptOnAllAccounts_OnClick(object sender, RoutedEventArgs e)
        {
            foreach (Account account in LbAccounts.SelectedItems)
            {
                account.Scripts.StopScript();
            }
        }

    }
}
