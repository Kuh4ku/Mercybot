using MercyBot.Core.Accounts;
using MercyBot.Core.Enums;
using MercyBot.Server.Enums;
using MercyBot.Server.Messages;
using Microsoft.Win32;
using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using MercyBot.Configurations.Language;
using ExtensionsEnum = MercyBot.Protocol.Server.Enums.Extensions;

namespace MercyBot.Views.Accounts
{
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public partial class AccountUc : UserControl
    {

        // Properties
        private Account Account => MercyBotMain.Instance.SelectedAccount;


        // Constructor
        public AccountUc()
        {
            InitializeComponent();

            DataContextChanged += AccountUc_DataContextChanged;
            tcMain.SelectionChanged += TcMain_SelectionChanged;

            Task.Run(async () =>
            {
                await Task.Delay(2000);
                LoadFunctionalities();
            });
        }


        private void AccountUc_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            tcMain.SelectedIndex = 0;
        }

        private async void ConnectDisconnect_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // If the bot is connect, disconnect it
                if (Account.Network.Connected)
                {
                    await Account.Network.Disconnect("CLIENT_CLOSING");
                    Account.PlanificationTimer.Stop();
                }
                // Otherwise connect it
                else if (Account.State == AccountStates.DISCONNECTED)
                {
                    await Account.Connect();
                }
            }
            catch { }
        }

        private void LoadScript_Click(object sender, object e)
        {
            try
            {
                var ofd = new OpenFileDialog();
                ofd.Filter = "Lua file (.lua) | *.lua";

                var result = ofd.ShowDialog();
                if (result.HasValue && result.Value)
                {
                    MercyBotMain.Instance.Server.SendMessage(new LoadScriptRequestMessage(Account.AccountConfig.Username, ofd.FileName, File.ReadAllText(ofd.FileName)));
                }
            }
            catch (Exception ex)
            {
                Account.Logger.LogError(LanguageManager.Translate("165"), ex.ToString());
            }
        }

        private void StartScript_Click(object sender, RoutedEventArgs e)
        {
            MercyBotMain.Instance.Server.SendMessage(new StartScriptRequestMessage(Account.AccountConfig.Username));
        }

        private void StopScript_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Account.Scripts.StopScript();
            }
            catch (Exception ex)
            {
                Account.Logger.LogError("", ex.ToString());
            }
        }

        private async void Remove_Click(object sender, RoutedEventArgs e)
        {
            await MercyBotMain.Instance.RemoveSelectedAccount();
        }

        #region Functionalities

        private void LoadFunctionalities()
        {
            if (!MercyBotMain.Instance.Server.LoggedIn || !MercyBotMain.Instance.Server.IsSubscribedToTouch)
                return;

            MercyBotMain.Instance.Server.RegisterMessage<ShowFunctionalityMessage>(HandleShowFunctionalityMessage);
            MercyBotMain.Instance.Server.SendMessage(new ShowFunctionalitiesRequestMessage());
        }

        private void HandleShowFunctionalityMessage(ShowFunctionalityMessage message)
        {
            switch (message.Functionality)
            {
                case Functionalities.STATISTICS:
                    Application.Current.Dispatcher.Invoke(() => AddUserControlToTab(new AccountStatisticsUc(), 8));
                    break;
                case Functionalities.HDV:
                    Application.Current.Dispatcher.Invoke(() => AddUserControlToTab(new AccountBidUc(), 6));
                    break;
                case Functionalities.FLOOD:
                    Application.Current.Dispatcher.Invoke(() => AddUserControlToTab(new AccountFloodUc(), 4));
                    break;
            }
        }

        private void TcMain_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                switch (tcMain.SelectedIndex)
                {
                    // Flood & Statistics only need IsSubscribedToTouch
                    case 4:
                    case 8:
                        if (!MercyBotMain.Instance.Server.IsSubscribedToTouch && !((tcMain.Items[tcMain.SelectedIndex] as TabItem).Content is TextBlock))
                        {
                            SetUnauthorizedTabText(tcMain.SelectedIndex);
                        }
                        break;
                    // Bid needs IsSubscribedToTouch & HasExtension
                    case 6:
                        if ((!MercyBotMain.Instance.Server.IsSubscribedToTouch || !MercyBotMain.Instance.Server.HasExtension(ExtensionsEnum.HDV))
                            && !((tcMain.Items[tcMain.SelectedIndex] as TabItem).Content is TextBlock))
                        {
                            SetUnauthorizedTabText(tcMain.SelectedIndex);
                        }
                        break;
                }
            }
            catch { }
        }

        private void AddUserControlToTab(UserControl uc, int tabIndex)
        {
            uc.SetBinding(DataContextProperty, new Binding("SelectedAccount")
            {
                Source = MercyBotMain.Instance
            });
            (tcMain.Items[tabIndex] as TabItem).Content = uc;
        }

        private void SetUnauthorizedTabText(int index)
        {
            (tcMain.Items[index] as TabItem).Content = new TextBlock()
            {
                Text = LanguageManager.Translate("406"),
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                FontSize = 16
            };
        }

        #endregion

    }
}
