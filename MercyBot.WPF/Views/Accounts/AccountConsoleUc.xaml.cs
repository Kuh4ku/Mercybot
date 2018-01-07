using MercyBot.Core.Accounts;
using MercyBot.Protocol.Enums;
using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MercyBot.Configurations.Language;
using Microsoft.Win32;
using Newtonsoft.Json;

namespace MercyBot.Views.Accounts
{
    public partial class AccountConsoleUc
    {

        // Properties
        private  Account Account => MercyBotMain.Instance.SelectedAccount;


        // Constructor
        public AccountConsoleUc()
        {
            InitializeComponent();
        }


        private void BtnClearLogs_Click(object sender, RoutedEventArgs e)
        {
            Account.Logger.Logs.Clear();
        }

        private async void TxtCommand_KeyDown(object sender, KeyEventArgs e)
        {
            if (TxtCommand.Text.Length == 0 || e.Key != Key.Enter)
                return;

            await Account.Commands.HandleInput(TxtCommand.Text);
            TxtCommand.Clear();
        }

        private void BtnCopyLogs_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(string.Join(Environment.NewLine, Account.Logger.Logs.Select(o => o.ToString())));
        }

        private void BtnChangeStatus_Click(object sender, RoutedEventArgs e)
        {
            var status = (PlayerStatusEnum)Convert.ToInt32((sender as MenuItem).Tag);
            Account.Game.Character.ChangeStatus(status);
        }

        private void BtnReportBug_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var ofd = new SaveFileDialog();
                ofd.Filter = "Mercy Bug (.mbug) | *.mbug";
                ofd.FileName = $"MBT_Bug_{DateTime.Now:dd-MM-yyyy_HH-mm}.mbug";

                var result = ofd.ShowDialog();
                if (result.HasValue && result.Value)
                {
                    using (BinaryWriter bw = new BinaryWriter(File.Open(ofd.FileName, FileMode.Create)))
                    {
                        bw.Write(Account.Game.Character.Level);
                        bw.Write(Account.Game.Character.Inventory.WeightPercent);
                        bw.Write(Account.Game.Map.Id);
                        bw.Write(Account.Game.Map.CurrentPosition);

                        bw.Write(Account.Logger.Logs.Count);
                        foreach (var log in Account.Logger.Logs)
                            bw.Write(log.ToString());

                        bw.Write(Account.Network.Messages.Count);
                        foreach (var msg in Account.Network.Messages)
                        {
                            bw.Write(msg.Time.ToBinary());
                            bw.Write(msg.Sent);
                            bw.Write(msg.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Account.Logger.LogError("", ex.ToString());
            }
        }

    }
}
