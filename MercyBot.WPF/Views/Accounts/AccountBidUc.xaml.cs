using MahApps.Metro.Controls.Dialogs;
using MercyBot.Core.Accounts;
using MercyBot.Core.Accounts.Extensions.Bid;
using MercyBot.Protocol.Data;
using MercyBot.Server.Messages;
using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;
using MercyBot.Configurations.Language;

namespace MercyBot.Views.Accounts
{
    public partial class AccountBidUc : UserControl
    {

        // Properties
        private Account Account => MercyBotMain.Instance.SelectedAccount;


        // Constructor
        public AccountBidUc()
        {
            InitializeComponent();
        }


        private async void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            var obj = DataManager.Get<Items>((int)nudGID.Value.Value);

            if (obj == null)
            {
                var window = Window.GetWindow(this) as MahApps.Metro.Controls.MetroWindow;
                await window.ShowMessageAsync(LanguageManager.Translate("249"), "Objet introuvable.");
                return;
            }

            int lot = cmbLot.SelectedIndex == 0 ? 1 : cmbLot.SelectedIndex == 1 ? 10 : 100;
            Account.Extensions.Bid.Configuration.ObjectsToSell.Add(new ObjectToSellEntry(obj.NameId, (uint)obj.Id, (uint)lot, (uint)nudQuantity.Value.Value, (uint)nudMinPrice.Value.Value, (uint)nudBasePrice.Value.Value));
            Account.Extensions.Bid.Configuration.Save();
        }

        private void BtnSelectPath_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var ofd = new OpenFileDialog();
                ofd.Filter = "Lua file (.lua) | *.lua";

                var result = ofd.ShowDialog();
                if (result.HasValue && result.Value)
                {
                    Account.Extensions.Bid.Configuration.ScriptPath = ofd.FileName;
                }
            }
            catch (Exception ex)
            {
                Account.Logger.LogError("", ex.ToString());
            }
        }

        private void BtnEnable_Click(object sender, RoutedEventArgs e)
        {
            MercyBotMain.Instance.Server.SendMessage(new StartBidExtensionRequestMessage(Account.AccountConfig.Username));
        }

        private void BtnDisable_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Account.Extensions.Bid.Stop();
            }
            catch (Exception ex)
            {
                Account.Logger.LogError("", ex.ToString());
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lvObjects.SelectedItem == null)
                return;

            Account.Extensions.Bid.Configuration.ObjectsToSell.Remove(lvObjects.SelectedItem as ObjectToSellEntry);
            Account.Extensions.Bid.Configuration.Save();
        }

    }
}
