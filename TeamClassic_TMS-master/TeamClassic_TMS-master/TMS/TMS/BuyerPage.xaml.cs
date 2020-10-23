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
    /// Interaction logic for BuyerPage.xaml
    /// </summary>
    public partial class BuyerPage : Page
    {
        public UIManager uiManager_m; //!< Contains methods and properties for managing the UI

        public BuyerPage(UIManager ui)
        {
            InitializeComponent();
            uiManager_m = ui;

            uiManager_m.CreateBuyerPage(this, BuyerPanel);
        }

        public void SelectRole_Click(object sender, RoutedEventArgs e)
        {
            uiManager_m.SelectRolePage();
        }

        public void SelectViewCustomers_Click(object sender, RoutedEventArgs e)
        {
            // Grey out the button

            // Go to the Config Settings page
            BuyerFrame.NavigationService.Navigate(new Uri("Buyer\\ViewCustomerMain.xaml", UriKind.Relative));
        }

        public void SelectContractMktplc_Click(object sender, RoutedEventArgs e)
        {
            // Grey out the button

            // Go to the Config Settings page
            BuyerFrame.NavigationService.Navigate(new Uri("Buyer\\ContractMarketMain.xaml", UriKind.Relative));
        }

        public void SelectReviewOrder_Click(object sender, RoutedEventArgs e)
        {
            // Grey out the button

            // Go to the Config Settings page
            BuyerFrame.NavigationService.Navigate(new Uri("Buyer\\ReviewOrderMain.xaml", UriKind.Relative));
        }
    }
}
