using System.Text;
using MercyBot.Core.Accounts;
using MercyBot.Core.Accounts.Extensions.Fights.Configuration;
using MercyBot.Core.Accounts.Extensions.Fights.Configuration.Enums;
using MercyBot.Core.Accounts.InGame.Character;
using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.Controls.Dialogs;
using MercyBot.Configurations.Language;
using MercyBot.WPF.Views;

namespace MercyBot.Views.Accounts
{
    public partial class AccountFightsUc : UserControl
    {

        // Properties
        private Account Account => MercyBotMain.Instance.SelectedAccount;


        // Constructor
        public AccountFightsUc()
        {
            InitializeComponent();
        }


        private void BtnMoveUp_Click(object sender, RoutedEventArgs e)
        {
            if (lvSpells.SelectedItem == null || lvSpells.SelectedIndex == 0)
                return;
            
            var temp = Account.Extensions.Fights.Configuration.Spells[lvSpells.SelectedIndex - 1];
            Account.Extensions.Fights.Configuration.Spells[lvSpells.SelectedIndex - 1] = Account.Extensions.Fights.Configuration.Spells[lvSpells.SelectedIndex];
            Account.Extensions.Fights.Configuration.Spells[lvSpells.SelectedIndex] = temp;
            Account.Extensions.Fights.Configuration.Save();
        }

        private void BtnMoveDown_Click(object sender, RoutedEventArgs e)
        {
            if (lvSpells.SelectedItem == null || lvSpells.SelectedIndex == lvSpells.Items.Count - 1)
                return;

            var temp = Account.Extensions.Fights.Configuration.Spells[lvSpells.SelectedIndex + 1];
            Account.Extensions.Fights.Configuration.Spells[lvSpells.SelectedIndex + 1] = Account.Extensions.Fights.Configuration.Spells[lvSpells.SelectedIndex];
            Account.Extensions.Fights.Configuration.Spells[lvSpells.SelectedIndex] = temp;
            Account.Extensions.Fights.Configuration.Save();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lvSpells.SelectedItem == null)
                return;

            var spell = lvSpells.SelectedItem as Spell;
            Account.Extensions.Fights.Configuration.Spells.Remove(spell);
            Account.Extensions.Fights.Configuration.Save();
        }

        private async void btnInfos_Click(object sender, RoutedEventArgs e)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Sort: Le sort à lancer.");
            sb.AppendLine("Cible: Ennemi, allié, sois-même ou case vide.");
            sb.AppendLine("Tours: Le nombre de tours à attendre après chaque relance (1 = lancer tous les tours).");
            sb.AppendLine("Relances: Le nombre de relances par tour.");
            sb.AppendLine("Vie de la cible: Lance le sort sur la cible seulement si ses points de vie sont inferieurs ou égaux à ce nombre, en pourcentage.");
            sb.AppendLine("Vie du personnage: Lance le sort sur la cible seulement si nos points de vie sont inferieurs ou égaux à ce nombre, en pourcentage.");
            sb.AppendLine("Résistance: Lance le sort uniquement si la resistance choisie de la cible est inférieure ou égale à la valeur (en pourcentage).");
            sb.AppendLine("Corps à corps: Lance le sort uniquement si notre personnage est en corps à corps avec un ennemi (ou plusieurs).");
            sb.AppendLine("Toucher le plus d'ennemis possible: Si ce sort est une attaque en zone, cocher cette case permet donc de toucher le plus d'ennemis possible.");
            sb.AppendLine("Ne pas se toucher: Pour tous sorts de zones, indique si on permet de toucher son personnage ou pas.");
            sb.AppendLine("Ne pas toucher ses alliés: Pour tous sorts de zones, indique si on permet de toucher nos alliés ou pas.");

            await MainWindow.Instance.ShowMessageAsync(LanguageManager.Translate("472"), sb.ToString());
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!(cmbSpell.SelectedItem is SpellEntry spell))
                return;

            Account.Extensions.Fights.Configuration.Spells.Add(new Spell(spell.Id, spell.Name, (SpellTargets)cmbTarget.SelectedIndex, (byte)nudTurns.Value, (byte)nudRelaunchs.Value, (byte)nudTargetHp.Value,
                (byte)nudCharacterHp.Value, (SpellResistances)cmbResistance.SelectedIndex, (byte)nudResistanceValue.Value, (byte)nudDistanceToClosestMonster.Value, cbHandToHand.IsChecked.Value, cbAOE.IsChecked.Value, 
                cbCarefulAOE.IsChecked.Value, cbAvoidAllies.IsChecked.Value));
            Account.Extensions.Fights.Configuration.Save();
        }

    }
}
