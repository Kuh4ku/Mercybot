using System.Globalization;
using System.Threading;
using MercyBot.Configurations;
using System.Windows;
using MercyBot.Configurations.Language;

namespace MercyBot.WPF
{
    public partial class App
    {

        public static CultureInfo Culture;
        //private static Mutex _mutex;


        protected override void OnStartup(StartupEventArgs e)
        {
            // Singleton application
            //_mutex = new Mutex(true, "Mercy Bot", out bool createdNew);
            //if (!createdNew)
            //{
            //    Current.Shutdown();
            //    return;
            //}

            GlobalConfiguration.Instance.Load();
            if (!LanguageManager.Initialize())
            {
                MessageBox.Show("Failed to initiliaze langs.");
                Current.Shutdown();
                return;
            }

            MercyBotMain.Instance.Server.Start();

            //Culture = new CultureInfo(GlobalConfiguration.Instance.Lang);
            //CultureInfo.CurrentCulture = Culture;
            //CultureInfo.CurrentUICulture = Culture;
            //CultureInfo.DefaultThreadCurrentCulture = Culture;

            base.OnStartup(e);
        }

    }
}
