using MercyBot.Server;
using MercyBot.Server.Messages;
using System.Windows;
using MercyBot.Server.Enums;
using MercyBot.WPF.Views;
using MercyBot.Configurations;
using System.Windows.Controls;
using MercyBot.Configurations.Language;

namespace MercyBot.Views
{
    public partial class LoginWindow
    {

        // Constructor
        public LoginWindow()
        {
            InitializeComponent();

            // Check if there is a username saved
            if (!string.IsNullOrEmpty(GlobalConfiguration.Instance.Username))
            {
                txtUsername.Text = GlobalConfiguration.Instance.Username;
                cbRememberUsername.IsChecked = true;
                txtPassword.Focus();
            }
            // Otherwise just focus the username textbox
            else
            {
                txtUsername.Focus();
            }

            MercyBotMain.Instance.Server.LoginAccepted += Server_LoginAccepted;
            MercyBotMain.Instance.Server.RegisterMessage<LoginRefusedMessage>(HandleLoginRefusedMessage);
        }


        private void Server_LoginAccepted()
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                var mainWindow = new MainWindow();
                mainWindow.Closed += (s, e) => Close();
                mainWindow.Show();
                Hide();

                GlobalConfiguration.Instance.Username = cbRememberUsername.IsChecked.Value ? txtUsername.Text : "";
                GlobalConfiguration.Instance.Save();
            });
        }

        private void BtnConnect_Click(object sender, RoutedEventArgs e)
        {
            SetAlert("", Visibility.Hidden);

            if (MercyBotMain.Instance.Server.State != ServerConnectionStates.CONNECTED ||
                MercyBotMain.Instance.Server.LoggedIn)
                return;

            if (txtUsername.Text.Length < 4 || txtPassword.Password.Length < 4)
                return;

            MercyBotMain.Instance.Server.SendMessage(new LoginRequestMessage(txtUsername.Text, txtPassword.Password));
            btnConnect.IsEnabled = false;
            txtUsername.IsEnabled = false;
            txtPassword.IsEnabled = false;
        }

        private void HandleLoginRefusedMessage(LoginRefusedMessage message)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                string msg = "";

                switch ((LoginResults)message.Reason)
                {
                    case LoginResults.UNAUTHORIZED:
                        msg = LanguageManager.Translate("401");                        break;
                    case LoginResults.NOT_FOUND:
                        msg = LanguageManager.Translate("402");                        break;
                    case LoginResults.AWAITING_ACTIVATION:
                        msg = LanguageManager.Translate("403");                        break;
                    case LoginResults.BANNED:
                        msg = LanguageManager.Translate("404");                        break;
                    case LoginResults.WRONG_PASSWORD:
                        msg = LanguageManager.Translate("405");                        break;
                    case LoginResults.TOO_MANY_INSTANCES:
                        msg = LanguageManager.Translate("400");                        break;
                }

                SetAlert(msg, Visibility.Visible);
                btnConnect.IsEnabled = true;
                txtUsername.IsEnabled = true;
                txtPassword.IsEnabled = true;
            });
        }

        private void UsernameOrPassword_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                btnConnect.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                e.Handled = true;
            }
        }

        private void SetAlert(string text, Visibility visibility)
        {
            tbAlert.Text = text;
            spAlert.Visibility = visibility;
        }

    }
}
