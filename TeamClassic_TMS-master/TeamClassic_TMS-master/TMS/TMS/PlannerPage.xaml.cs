using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TMS
{
    /// <summary>
    /// Interaction logic for PlannerPage.xaml
    /// </summary>
    public partial class PlannerPage : Page
    {
        public UIManager uiManager_m; //!< Contains methods and properties for managing the UI

        public PlannerPage(UIManager ui)
        {
            InitializeComponent();
            uiManager_m = ui;

            uiManager_m.CreatePlannerPage(this, PlannerPanel);
        }

        public void SelectRole_Click(object sender, RoutedEventArgs e)
        {
            uiManager_m.SelectRolePage();
        }

        public void SelectReceivedOrders_Click(object sender, RoutedEventArgs e)
        {
            // Grey out the button

            // Go to the Config Settings page
            PlannerFrame.NavigationService.Navigate(new Uri("Planner\\ReceivedOrdersMain.xaml", UriKind.Relative));
        }

        public void SelectOrderSummary_Click(object sender, RoutedEventArgs e)
        {
            // Grey out the button

            // Go to the Config Settings page
            PlannerFrame.NavigationService.Navigate(new Uri("Planner\\OrderSummary.xaml", UriKind.Relative));
        }

        public void SelectInvoiceSummary_Click(object sender, RoutedEventArgs e)
        {
            // Grey out the button

            // Go to the Config Settings page
            PlannerFrame.NavigationService.Navigate(new Uri("Planner\\InvoiceSummary.xaml", UriKind.Relative));
        }

        public void SelectCloseDay_Click(object sender, RoutedEventArgs e)
        {
            // Grey out the button

            // Go to the Config Settings page
            PlannerFrame.NavigationService.Navigate(new Uri("Planner\\CloseDayMain.xaml", UriKind.Relative));
        }
    }
}
