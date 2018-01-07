using System.Diagnostics;
using System.Windows.Navigation;
using MercyBot.Configurations;

namespace MercyBot.Views
{
    public partial class OptionsWindow
    {

        // Constructor
        public OptionsWindow()
        {
            InitializeComponent();

            DataContext = GlobalConfiguration.Instance;
        }


        private void AntiCaptcha_OnRequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(e.Uri.AbsoluteUri);
            e.Handled = true;
        }

    }
}
