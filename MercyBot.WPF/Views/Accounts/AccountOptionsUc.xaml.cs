using MahApps.Metro.Controls.Dialogs;
using MercyBot.Core.Accounts;
using MercyBot.Core.Accounts.Configurations;
using MercyBot.Protocol.Data;
using MercyBot.Server.Messages;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using MercyBot.Configurations.Language;

namespace MercyBot.Views.Accounts
{
    public partial class AccountOptionsUc : UserControl
    {

        // Properties
        private Account Account => MercyBotMain.Instance.SelectedAccount;


        // Constructor
        public AccountOptionsUc()
        {
            InitializeComponent();
        }


        private void BtnDeleteSpellToBoost_Click(object sender, RoutedEventArgs e)
        {
            if (lvSpellsToBoost.SelectedItem == null)
                return;

            Account.Configuration.SpellsToBoost.Remove(lvSpellsToBoost.SelectedItem as SpellToBoostEntry);
            Account.Configuration.Save();
        }

        private async void BtnAddSpellToBoost_Click(object sender, RoutedEventArgs e)
        {
            var spell = DataManager.Get<Spells>((int)nudSpellId.Value);
            var window = Window.GetWindow(this) as MahApps.Metro.Controls.MetroWindow;

            if (spell == null)
            {
                await window.ShowMessageAsync(LanguageManager.Translate("249"), LanguageManager.Translate("372"));
                return;
            }

            if (Account.Configuration.SpellsToBoost.FirstOrDefault(s => s.Id == spell.Id) != null)
            {
                await window.ShowMessageAsync(LanguageManager.Translate("249"), LanguageManager.Translate("373"));
                return;
            }

            Account.Configuration.SpellsToBoost.Add(new SpellToBoostEntry(spell.Id, spell.NameId, (byte)nudSpellLevel.Value));
            Account.Configuration.Save();
        }

        private void BtnDeleteAuthorizedTradeFrom_Click(object sender, RoutedEventArgs e)
        {
            if (lbAuthorizedTradesFrom.SelectedItem == null)
                return;

            Account.Configuration.AuthorizedTradesFrom.Remove((int)lbAuthorizedTradesFrom.SelectedItem);
            Account.Configuration.Save();
        }

        private async void BtnAddAuthorizedTradeFrom_Click(object sender, RoutedEventArgs e)
        {
            int characterId = (int) nudCharacterId.Value;

            if (Account.Configuration.AuthorizedTradesFrom.Contains(characterId))
            {
                var window = Window.GetWindow(this) as MahApps.Metro.Controls.MetroWindow;
                await window.ShowMessageAsync(LanguageManager.Translate("249"), "Personnage déjà ajouté.");
                return;
            }

            MercyBotMain.Instance.Server.SendMessage(new AddAuthorizedTradeFromRequestMessage(Account.AccountConfig.Username, characterId));
        }

    }
}
