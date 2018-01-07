using System;
using System.Collections.Generic;
using System.IO;
using MahApps.Metro.Controls.Dialogs;
using MercyBot.Server.Messages;
using MercyBot.Configurations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using ColorPickerWPF;
using ColorPickerWPF.Code;
using MercyBot.Configurations.Language;
using MercyBot.Core.Accounts.Configurations;
using MercyBot.Core.Accounts.Extensions.Fights.Configuration;
using MercyBot.Protocol.Data;
using MercyBot.Utility.DofusTouch;
using Microsoft.Win32;

namespace MercyBot.Views
{
    public partial class AccountsManagerWindow
    {

        // Constructor
        public AccountsManagerWindow()
        {
            InitializeComponent();

            DataContext = GlobalConfiguration.Instance;
            TxtSeparator.Text = "|";

            CmbRace.ItemsSource = BreedsUtility.Breeds;
            CmbRace.SelectedIndex = 0;

            LoadConfigurations();
        }


        #region Connect accounts

        private void BtnDeleteAccounts_Click(object sender, RoutedEventArgs e)
        {
            for (int i = LvAccounts.SelectedItems.Count - 1; i >= 0; i--)
            {
                GlobalConfiguration.Instance.RemoveAccount(LvAccounts.SelectedItems[i] as AccountConfiguration);
            }

            GlobalConfiguration.Instance.Save();
        }

        private void BtnConnectAccounts_Click(object sender, RoutedEventArgs e)
        {
            if (!MercyBotMain.Instance.Server.LoggedIn)
                return;

            if (LvAccounts.SelectedItems.Count == 0)
                return;

            MercyBotMain.Instance.Server.SendMessage(new ConnectAccountsRequestMessage(LvAccounts.SelectedItems.Cast<AccountConfiguration>().Select(a => a.Username).ToList()));
            Close();
        }

        private void LvAccounts_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!MercyBotMain.Instance.Server.LoggedIn)
                return;

            if (LvAccounts.SelectedItem == null)
                return;

            MercyBotMain.Instance.Server.SendMessage(new ConnectAccountRequestMessage((LvAccounts.SelectedItem as AccountConfiguration).Username));
            Close();
        }

        private void LvAccounts_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (LvAccounts.SelectedItems.Count > 1 && LvAccounts.SelectedItems.Count < 9)
            {
                GbGroup.Visibility = Visibility.Visible;
                CmbChief.SelectedIndex = 0;
            }
            else
            {
                GbGroup.Visibility = Visibility.Collapsed;
            }
        }

        private async void BtnConnectGroup_Click(object sender, RoutedEventArgs e)
        {
            if (!MercyBotMain.Instance.Server.LoggedIn)
                return;

            if (LvAccounts.SelectedItems.Count < 2 || CmbChief.SelectedItem == null)
                return;

            var chief = CmbChief.SelectedItem as AccountConfiguration;
            var members = LvAccounts.SelectedItems.Cast<AccountConfiguration>().Where(a => a != chief).ToArray();

            // Check if all the accounts are in the same server
            if (!members.All(a => a.Server == chief.Server))
            {
                await this.ShowMessageAsync(LanguageManager.Translate("249"), LanguageManager.Translate("392"));
                return;
            }

            MercyBotMain.Instance.Server.SendMessage(new ConnectGroupRequestMessage(new[] { chief.Username }.Concat(members.Select(m => m.Username)).ToList()));
            Close();
        }

        #endregion

        #region Add accounts

        private async void BtnAddAccount_Click(object sender, RoutedEventArgs e)
        {
            if (TxtUsername.Text.Length < 3 || TxtPassword.Password.Length < 3)
            {
                await this.ShowMessageAsync(LanguageManager.Translate("249"), LanguageManager.Translate("250"));
                return;
            }

            if (GlobalConfiguration.Instance.GetAccount(TxtUsername.Text) != null)
            {
                await this.ShowMessageAsync(LanguageManager.Translate("249"), LanguageManager.Translate("398"));
                return;
            }

            GlobalConfiguration.Instance.AddAccountAndSave(TxtUsername.Text, TxtPassword.Password, CmbServer.Text, TxtCharacter.Text, TxtNickname.Text);

            TxtUsername.Clear();
            TxtPassword.Clear();
            TxtCharacter.Clear();
            TxtNickname.Clear();
        }

        private void TxtSeparator_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            TxtSeparatorPreview.Text = TxtSeparator.Text.Length == 0 ? $"{LanguageManager.Translate("494")}-" : $"{LanguageManager.Translate("494")}{LanguageManager.Translate("495", TxtSeparator.Text)}";
        }

        private async void BtnImportAccounts_OnClick(object sender, RoutedEventArgs e)
        {
            if (TxtSeparator.Text.Length == 0 || TxtFilePath.Text.Length == 0 || !File.Exists(TxtFilePath.Text))
            {
                await this.ShowMessageAsync(LanguageManager.Translate("249"), LanguageManager.Translate("496"));
                return;
            }

            string[] lines = File.ReadAllLines(TxtFilePath.Text);
            var accounts = new List<AccountConfiguration>();

            for (int i = 0; i < lines.Length; i++)
            {
                string[] infos = lines[i].Split(new[] { TxtSeparator.Text }, StringSplitOptions.RemoveEmptyEntries);

                if (infos.Length != 2)
                    continue;

                accounts.Add(new AccountConfiguration(infos[0], infos[1], "-", "", ""));
            }

            if (accounts.Count > 0)
            {
                GlobalConfiguration.Instance.AddAccountsAndSave(accounts);
                await this.ShowMessageAsync(LanguageManager.Translate("492"), LanguageManager.Translate("497", accounts.Count));
            }
            else
            {
                await this.ShowMessageAsync(LanguageManager.Translate("249"), LanguageManager.Translate("498"));
            }
        }

        private void BtnSelectFilePath_OnClick(object sender, RoutedEventArgs e)
        {
            var ofd = new OpenFileDialog();
            var result = ofd.ShowDialog();

            if (!result.HasValue || !result.Value)
                return;

            TxtFilePath.Text = ofd.FileName;
        }

        private async void BtnImportAccountsIncr_OnClick(object sender, RoutedEventArgs e)
        {
            if (TxtUsernameIncr.Text.Length == 0 || TxtPasswordIncr.Password.Length == 0 || NudEndIncr.Value.Value <= NudStartIncr.Value.Value)
            {
                await this.ShowMessageAsync(LanguageManager.Translate("249"), LanguageManager.Translate("496"));
                return;
            }

            int start = (int)NudStartIncr.Value.Value;
            int end = (int)NudEndIncr.Value.Value;
            var accounts = new List<AccountConfiguration>();
            for (int i = start; i <= end; i++)
            {
                accounts.Add(new AccountConfiguration($"{TxtUsernameIncr.Text}{i}", TxtPasswordIncr.Password, "-", "", ""));
            }

            if (accounts.Count <= 0)
                return;

            GlobalConfiguration.Instance.AddAccountsAndSave(accounts);
            await this.ShowMessageAsync(LanguageManager.Translate("492"), LanguageManager.Translate("497", accounts.Count));
        }

        private void TxtUsernameIncr_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            RefreshIncrPreview();
        }

        private void NudIncr_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            RefreshIncrPreview();
        }

        private void RefreshIncrPreview()
        {
            if (TxtIncrPreview == null)
                return;

            TxtIncrPreview.Text = TxtUsernameIncr.Text.Length == 0 ? "-" :
                LanguageManager.Translate("551", TxtUsernameIncr.Text, NudStartIncr.Value.Value, NudEndIncr.Value.Value);
        }

        #endregion

        #region Characters creator

        private void CmbRace_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RefreshBreedInfos();
        }

        private void CmbSex_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RefreshBreedInfos();
        }

        private void ColorRects_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var rect = sender as Rectangle;
            if (ColorPickerWindow.ShowDialog(out Color color, ColorPickerDialogOptions.SimpleView))
            {
                rect.Fill = new SolidColorBrush(color);
            }
        }

        private void BtnRefreshColors_OnClick(object sender, RoutedEventArgs e)
        {
            var breed = CmbRace.SelectedItem as Breeds;

            if (breed == null)
                return;

            SetBreedBaseColors(breed);
        }

        private void BtnSave_OnClick(object sender, RoutedEventArgs e)
        {
            if (LbAccounts.SelectedItems.Count == 0)
                return;

            foreach (AccountConfiguration account in LbAccounts.SelectedItems)
            {
                account.CharacterCreation = GetCharacterCreation();
            }

            GlobalConfiguration.Instance.Save();
        }

        private void BtnSaveAndConnect_OnClick(object sender, RoutedEventArgs e)
        {
            if (LbAccounts.SelectedItems.Count == 0)
                return;

            BtnSave_OnClick(null, null);
            MercyBotMain.Instance.Server.SendMessage(new ConnectAccountsRequestMessage(LbAccounts.SelectedItems.Cast<AccountConfiguration>().Select(a => a.Username).ToList()));
            Close();
        }

        private CharacterCreation GetCharacterCreation()
        {
            if (!CbCreateCharacter.IsChecked.Value)
                return new CharacterCreation();

            return new CharacterCreation()
            {
                Create = true,
                Name = TxtName.Text,
                Server = CmbServerCC.Text,
                Breed = CbRandomBreed.IsChecked.Value ? -1 : (CmbRace.SelectedItem as Breeds).Id,
                Sex = CbRandomSex.IsChecked.Value ? -1 : CmbSex.SelectedIndex,
                Head = CbRandomHead.IsChecked.Value ? -1 : CmbHead.SelectedIndex,
                Colors = new List<int>(5)
                {
                    BreedsUtility.GetIndexedColor(1, (RectColor1.Fill as SolidColorBrush).Color),
                    BreedsUtility.GetIndexedColor(2, (RectColor2.Fill as SolidColorBrush).Color),
                    BreedsUtility.GetIndexedColor(3, (RectColor3.Fill as SolidColorBrush).Color),
                    BreedsUtility.GetIndexedColor(4, (RectColor4.Fill as SolidColorBrush).Color),
                    BreedsUtility.GetIndexedColor(5, (RectColor5.Fill as SolidColorBrush).Color),
                },
                ParametersToCopy = CmbParameters.SelectedIndex == 0 ? "" : CmbParameters.Text,
                FightsConfigurationToCopy = CmbFightsConfigurations.SelectedIndex == 0 ? "" : CmbFightsConfigurations.Text,
                CompleteTutorial = CmbCompleteTutorial.IsChecked.Value
            };
        }

        private void RefreshBreedInfos()
        {
            var breed = CmbRace.SelectedItem as Breeds;

            if (breed == null)
                return;

            // Heads
            CmbHead.ItemsSource = BreedsUtility.GetBreedHeads(breed.Id, CmbSex.SelectedIndex);
            CmbHead.SelectedIndex = 0;

            // Colors
            SetBreedBaseColors(breed);
        }

        private void SetBreedBaseColors(Breeds breed)
        {
            var baseColors = BreedsUtility.GetBreedBaseColors(breed, CmbSex.SelectedIndex);
            RectColor1.Fill = new SolidColorBrush(baseColors[0]);
            RectColor2.Fill = new SolidColorBrush(baseColors[1]);
            RectColor3.Fill = new SolidColorBrush(baseColors[2]);
            RectColor4.Fill = new SolidColorBrush(baseColors[3]);
            RectColor5.Fill = new SolidColorBrush(baseColors[4]);
        }

        private async void CmbCompleteTutorial_OnChecked(object sender, RoutedEventArgs e)
        {
            await this.ShowMessageAsync(LanguageManager.Translate("513"), LanguageManager.Translate("515"));
        }

        #endregion

        #region Configurations copier

        private void BtnCopy_Click(object sender, RoutedEventArgs e)
        {
            //if (LbAccountsCopier.SelectedItems.Count == 0)
            //    return;

            //foreach (AccountConfiguration account in LbAccountsCopier.SelectedItems.Cast<AccountConfiguration>())
            //{
            //    if (CmbParametersCopier.SelectedIndex > 0)
            //    {
            //        File.Copy(Path.Combine(Configuration.ConfigurationsPath, account.CharacterCreation.ParametersToCopy),
            //            Path.Combine(Configuration.ConfigurationsPath, $"{account.Username}_{message.Characters[0].Name}.config"), overwrite: true);
            //    }

            //    if (CmbFightsConfigurationsCopier.SelectedIndex > 0)
            //    {
            //        File.Copy(Path.Combine(FightsConfiguration.ConfigurationsPath, account.CharacterCreation.FightsConfigurationToCopy),
            //            Path.Combine(FightsConfiguration.ConfigurationsPath, $"{account.Username}_{message.Characters[0].Name}.fconfig"), overwrite: true);
            //    }
            //}
        }

        #endregion

        #region Proxies

        private async void BtnTestProxy_Click(object sender, RoutedEventArgs e)
        {
            if (!IPAddress.TryParse(TxtProxyIp.Text, out IPAddress ip) || !ushort.TryParse(TxtProxyPort.Text, out ushort port))
                return;

            using (HttpClient http = new HttpClient(new HttpClientHandler
            {
                Proxy = new WebProxy($"http://{ip}:{port}", false)
                {
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(TxtProxyUsername.Text, TxtProxyPassword.Text)
                },
                PreAuthenticate = true,
                UseDefaultCredentials = false
            })
            { Timeout = new TimeSpan(0, 0, 5) })
            {
                try
                {
                    var response = await http.GetAsync("https://ipv4.icanhazip.com/");
                    response.EnsureSuccessStatusCode();

                    string text = await response.Content.ReadAsStringAsync();

                    // If the ip is valid, the proxy is working
                    if (text.Substring(0, text.Length - 1) == ip.ToString())
                    {
                        await this.ShowMessageAsync(LanguageManager.Translate("357"), LanguageManager.Translate("355"));
                        return;
                    }
                }
                catch { }

                await this.ShowMessageAsync(LanguageManager.Translate("249"), LanguageManager.Translate("356"));
            }
        }

        private void BtnSaveProxy_Click(object sender, RoutedEventArgs e)
        {
            string ip = TxtProxyIp.Text.Length == 0 ? "" : IPAddress.TryParse(TxtProxyIp.Text, out IPAddress ipAddress) ? ipAddress.ToString() : null;
            if (ip == null || !ushort.TryParse(TxtProxyPort.Text, out ushort port))
                return;

            if (!(LbAccountsListProxy.SelectedItem is AccountConfiguration account))
                return;

            MercyBotMain.Instance.Server.SendMessage(new SetProxyRequestMessage(account.Username, ip, port, TxtProxyUsername.Text, TxtProxyPassword.Text));
        }

        #endregion

        private void BtnSelectAll_OnClick(object sender, RoutedEventArgs e)
        {
            int i = Convert.ToInt32((sender as Button).Tag);
            var lb = i == 0 ? LbAccounts : LbAccountsCopier;
            lb.SelectAll();
        }

        private void BtnUnselectAll_OnClick(object sender, RoutedEventArgs e)
        {
            int i = Convert.ToInt32((sender as Button).Tag);
            var lb = i == 0 ? LbAccounts : LbAccountsCopier;
            lb.UnselectAll();
        }

        private void LoadConfigurations()
        {
            CmbParameters.Items.Add(LanguageManager.Translate("463"));
            CmbParametersCopier.Items.Add(LanguageManager.Translate("463"));
            if (Directory.Exists(Configuration.ConfigurationsPath))
            {
                foreach (var file in Directory.GetFiles(Configuration.ConfigurationsPath, "*.config"))
                {
                    CmbParameters.Items.Add(System.IO.Path.GetFileName(file));
                    CmbParametersCopier.Items.Add(System.IO.Path.GetFileName(file));
                }
            }

            CmbFightsConfigurations.Items.Add(LanguageManager.Translate("463"));
            CmbFightsConfigurationsCopier.Items.Add(LanguageManager.Translate("463"));
            if (Directory.Exists(FightsConfiguration.ConfigurationsPath))
            {
                foreach (var file in Directory.GetFiles(FightsConfiguration.ConfigurationsPath, "*.fconfig"))
                {
                    CmbFightsConfigurations.Items.Add(System.IO.Path.GetFileName(file));
                    CmbFightsConfigurationsCopier.Items.Add(System.IO.Path.GetFileName(file));
                }
            }

            CmbParameters.SelectedIndex = 0;
            CmbParametersCopier.SelectedIndex = 0;
            CmbFightsConfigurations.SelectedIndex = 0;
            CmbFightsConfigurationsCopier.SelectedIndex = 0;
        }

    }
}
