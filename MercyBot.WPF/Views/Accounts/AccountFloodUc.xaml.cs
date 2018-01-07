using MercyBot.Core.Accounts;
using MercyBot.Core.Accounts.Extensions.Flood;
using MercyBot.Protocol.Enums;
using MercyBot.Server.Messages;
using System.Windows;
using System.Windows.Controls;

namespace MercyBot.Views.Accounts
{
    public partial class AccountFloodUc : UserControl
    {

        // Properties
        private Account Account => MercyBotMain.Instance.SelectedAccount;


        // Constructor
        public AccountFloodUc()
        {
            InitializeComponent();
        }


        private void CmbChannel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (spPrivateChannelOptions == null)
                return;

            if (cmbChannel.SelectedIndex == 3)
            {
                spPrivateChannelOptions.Visibility = Visibility.Visible;
            }
            else
            {
                spPrivateChannelOptions.Visibility = Visibility.Collapsed;
            }
        }

        private void TsActivate_IsCheckedChanged(object sender, System.EventArgs e)
        {
            if (tsActivate.IsChecked.Value)
            {
                MercyBotMain.Instance.Server.SendMessage(new StartFloodExtensionRequestMessage(Account.AccountConfig.Username));
            }
            else
            {
                Account.Extensions.Flood.Stop();
            }
        }

        private void BtnAddSentence_Click(object sender, RoutedEventArgs e)
        {
            if (txtSentence.Text.Length == 0 || cmbChannel.SelectedItem == null)
                return;

            Account.Extensions.Flood.Configuration.Sentences.Add(new FloodSentence(txtSentence.Text, GetSentenceChannel(cmbChannel.SelectedIndex), cbOnPlayerJoined.IsChecked.Value, cbOnPlayerLeft.IsChecked.Value));
            Account.Extensions.Flood.Configuration.Save();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var sentence = lvSentences.SelectedItem as FloodSentence;

            if (sentence == null)
                return;

            Account.Extensions.Flood.Configuration.Sentences.Remove(sentence);
            Account.Extensions.Flood.Configuration.Save();
        }

        private static ChatActivableChannelsEnum GetSentenceChannel(int index)
        {
            switch (index)
            {
                case 0:
                    return ChatActivableChannelsEnum.CHANNEL_GLOBAL;
                case 1:
                    return ChatActivableChannelsEnum.CHANNEL_SEEK;
                case 2:
                    return ChatActivableChannelsEnum.CHANNEL_SALES;
                default:
                    return ChatActivableChannelsEnum.PSEUDO_CHANNEL_PRIVATE;
            }
        }

    }
}
