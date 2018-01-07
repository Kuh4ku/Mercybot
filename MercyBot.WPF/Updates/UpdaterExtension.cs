using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MercyBot.Configurations.Language;

namespace MercyBot.Updates
{
    public static class UpdaterExtension
    {

        public static async Task<bool> ShowUpdatesAsync(this MetroWindow window, Dictionary<string, string> filesUpToDate)
        {
            var controller = await window.ShowProgressAsync(LanguageManager.Translate("485"), LanguageManager.Translate("486"));
            await Task.Delay(1000);

            var updater = new Updater("https://mercybot.net/updater/files/");
            int filesToDownload = 0;
            int currentFile = 0;
            var tcs = new TaskCompletionSource<bool>();

            updater.UpdateStarted += (ftd) => filesToDownload = ftd;
            updater.FileDownloadStarted += (fileName) =>
            {
                currentFile++;
                controller.SetTitle($"{LanguageManager.Translate("487")} ({currentFile}/{filesToDownload})");
                controller.SetMessage($"{LanguageManager.Translate("488")} '{fileName}'..");
            };

            updater.FileDownloadProgress += (progess) => controller.SetProgress((double)progess / 100);
            updater.UpdateFailed += async () =>
            {
                controller.SetTitle(LanguageManager.Translate("249"));
                controller.SetMessage(LanguageManager.Translate("489"));
                await Task.Delay(5000);
                Environment.Exit(0);
                tcs.SetResult(true);
            };

            updater.UpdateFinished += async () =>
            {
                controller.SetMessage(LanguageManager.Translate("490"));
                await Task.Delay(5000);
                Process.Start("Mercy Bot.exe");
                Environment.Exit(0);
                tcs.SetResult(true);
            };

            // If there is an update, wait until it's done
            if (updater.CheckForUpdates(filesUpToDate))
                return (await tcs.Task);

            controller.SetMessage(LanguageManager.Translate("491"));
            await Task.Delay(1000);
            await controller.CloseAsync();
            return false;
        }

    }
}