using System.Windows.Controls;
using MercyBot.Configurations;

namespace MercyBot.Views.Planner
{
    public partial class PlannerWindow
    {

        // Constructor
        public PlannerWindow()
        {
            InitializeComponent();

            DataContext = GlobalConfiguration.Instance;
        }

        private void LbPlanification_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LbAccounts.SelectedItem == null || LbPlanification.SelectedIndex == -1)
                return;

            var account = LbAccounts.SelectedItem as AccountConfiguration;
            var index = LbPlanification.SelectedIndex;
            account.Planification[index] = !account.Planification[index];
            GlobalConfiguration.Instance.Save();
        }

    }
}