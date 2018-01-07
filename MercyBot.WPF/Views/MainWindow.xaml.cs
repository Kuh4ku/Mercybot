using MahApps.Metro.Controls.Dialogs;
using MercyBot.Core.Accounts.Scripts.Managers;
using MercyBot.Core.Commands;
using MercyBot.Core.Frames;
using MercyBot.Protocol.Data;
using MercyBot.Protocol.Data.Maps;
using MercyBot.Protocol.Types;
using MercyBot.Utility;
using MercyBot.Utility.DofusTouch;
using MercyBot.Views;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using MercyBot.Server.Messages;
using MercyBot.Updates;
using MercyBot.Configurations;
using MercyBot.Configurations.Language;
using MercyBot.Views.Planner;
using Application = System.Windows.Application;
using MessageBox = System.Windows.MessageBox;

namespace MercyBot.WPF.Views
{
    public partial class MainWindow
    {

        // Properties
        public static MainWindow Instance { get; private set; }


        // Constructor
        public MainWindow()
        {
            InitializeComponent();

            _notifyIcon = new NotifyIcon();
            _notifyIcon.Icon = Properties.Resources.logo128_3Pk_icon;
            _notifyIcon.DoubleClick += _notifyIcon_DoubleClick;

            DataContext = MercyBotMain.Instance;
            Instance = this;

            MercyBotMain.Instance.Server.RegisterMessage<FilesHashesMessage>(HandleFilesHashesMessage);
        }


        private void HandleFilesHashesMessage(FilesHashesMessage message)
        {
            Application.Current.Dispatcher.Invoke(async () =>
            {
                // Updater
                if (await this.ShowUpdatesAsync(message.FilesHashes))
                {
                    Environment.Exit(0);
                    return;
                }

                // Loading
                try
                {
                    var controller = await this.ShowProgressAsync(LanguageManager.Translate("483"), Randomize.GetRandomLoadingText());

                    await Task.Run(async () =>
                    {
                        Protocol.Messages.MessagesBuilder.Initialize();
                        controller.SetProgress(0.14);
                        await Task.Delay(200);

                        TypesBuilder.Initialize();
                        controller.SetProgress(0.28);
                        await Task.Delay(200);

                        DataManager.Initialize(DTConstants.AssetsVersion, GlobalConfiguration.Instance.Lang);
                        controller.SetProgress(0.42);
                        await Task.Delay(200);

                        MapsManager.Initialize(DTConstants.AssetsVersion);
                        controller.SetProgress(0.56);
                        await Task.Delay(200);

                        FramesManager.Initialize();
                        controller.SetProgress(0.70);
                        await Task.Delay(200);

                        CommandsHandler.Initialize();

                        BreedsUtility.Initialize();
                        controller.SetProgress(1);
                        await Task.Delay(200);

                        LuaScriptManager.Initialize();
                    });

                    await controller.CloseAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            });
        }

        private void MetroWindow_ContentRendered(object sender, EventArgs e)
        {
            MercyBotMain.Instance.Server.SendMessage(new FilesHashesRequestMessage());
        }

        private void BtnAccountsManager_Click(object sender, RoutedEventArgs e)
        {
            var accountsManagerWindow = new AccountsManagerWindow { Owner = this };
            accountsManagerWindow.ShowDialog();
        }

        private void BtnOptions_Click(object sender, RoutedEventArgs e)
        {
            var optionsWindow = new OptionsWindow { Owner = this };
            optionsWindow.ShowDialog();
        }

        private void BtnQuickActions_Click(object sender, RoutedEventArgs e)
        {
            var quickActionsWindow = new QuickActionsWindow { Owner = this };
            quickActionsWindow.ShowDialog();
        }

        private void BtnPlanner_Click(object sender, RoutedEventArgs e)
        {
            var plannerWindow = new PlannerWindow { Owner = this };
            plannerWindow.ShowDialog();
        }

        #region Minize/Restore

        private readonly NotifyIcon _notifyIcon;

        private void BtnMinimize_OnClick(object sender, RoutedEventArgs e)
        {
            _notifyIcon.Visible = true;
            Hide();
            _notifyIcon.ShowBalloonTip(5000, "Mercy Bot", LanguageManager.Translate("482"), ToolTipIcon.Info);
        }

        private void _notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            _notifyIcon.Visible = false;
            Show();
        }

        #endregion

    }
}
