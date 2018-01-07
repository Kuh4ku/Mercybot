using MahApps.Metro.Controls.Dialogs;
using MercyBot.Core.Accounts;
using MercyBot.Core.Accounts.InGame.Character.Inventory;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using MercyBot.Configurations.Language;

namespace MercyBot.Views.Accounts
{
    /// <summary>
    /// Interaction logic for AccountInventoryUc.xaml
    /// </summary>
    public partial class AccountInventoryUc : UserControl
    {

        // Properties
        private Account Account => MercyBotMain.Instance.SelectedAccount;

        public Task ShowMessageAsync { get; private set; }


        // Constructor
        public AccountInventoryUc()
        {
            InitializeComponent();
        }


        private void BtnEquipUnEquip_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var obj = btn.DataContext as ObjectEntry;

            if (btn.Content.ToString() == LanguageManager.Translate("29"))
            {
                Account.Game.Character.Inventory.EquipObject(obj);
            }
            else
            {
                Account.Game.Character.Inventory.UnEquipObject(obj);
            }
        }

        private async void BtnDrop_Click(object sender, RoutedEventArgs e)
        {
            var obj = (sender as Button).DataContext as ObjectEntry;

            uint qtyToDrop = 1;

            if (obj.Quantity != 1)
            {
                var window = Window.GetWindow(this) as MahApps.Metro.Controls.MetroWindow;
                var input = await window.ShowInputAsync(LanguageManager.Translate("320"), LanguageManager.Translate("328", obj.Name));

                if (!uint.TryParse(input, out qtyToDrop) || qtyToDrop < 0)
                    return;
            }

            Account.Game.Character.Inventory.DropObject(obj, qtyToDrop);
        }

        private async void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var obj = (sender as Button).DataContext as ObjectEntry;

            uint qtyToDelete = 1;

            if (obj.Quantity != 1)
            {
                var window = Window.GetWindow(this) as MahApps.Metro.Controls.MetroWindow;
                var input = await window.ShowInputAsync(LanguageManager.Translate("321"), LanguageManager.Translate("329", obj.Name));

                if (!uint.TryParse(input, out qtyToDelete) || qtyToDelete < 0)
                    return;
            }

            Account.Game.Character.Inventory.DeleteObject(obj, qtyToDelete);
        }

        private async void BtnUse_Click(object sender, RoutedEventArgs e)
        {
            var obj = (sender as Button).DataContext as ObjectEntry;

            uint qtyTouse = 1;

            if (obj.Quantity != 1)
            {
                var window = Window.GetWindow(this) as MahApps.Metro.Controls.MetroWindow;
                var input = await window.ShowInputAsync(LanguageManager.Translate("323"), LanguageManager.Translate("330", obj.Name));

                if (!uint.TryParse(input, out qtyTouse) || qtyTouse < 0)
                    return;
            }

            Account.Game.Character.Inventory.UseObject(obj, qtyTouse);
        }

    }
}
