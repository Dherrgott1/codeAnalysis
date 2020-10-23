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
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public UIManager uiManager_m; //!< Contains methods and properties for managing the UI

        public AdminPage(UIManager ui)
        {
            InitializeComponent();
            uiManager_m = ui;

            uiManager_m.CreateAdminPage(this, AdminPanel);
        }

        public void SelectRole_Click(object sender, RoutedEventArgs e)
        {
            uiManager_m.SelectRolePage();
        }

        public void SelectConfigSetting_Click(object sender, RoutedEventArgs e)
        {
            // Grey out the button

            // Go to the Config Settings page
            AdminFrame.NavigationService.Navigate(new Uri("Admin\\GenConfig.xaml", UriKind.Relative));                        
        }

        public void SelectViewLogFile_Click(object sender, RoutedEventArgs e)
        {
            // Grey out the button

            // Go to the Config Settings page
            AdminFrame.NavigationService.Navigate(new Uri("Admin\\LogFileSelection.xaml", UriKind.Relative));
        }

        public void SelectRateFeeTable_Click(object sender, RoutedEventArgs e)
        {
            // Grey out the button

            // Go to the Config Settings page
            AdminFrame.NavigationService.Navigate(new Uri("Admin\\RateFeeTable.xaml", UriKind.Relative));
        }

        public void SelectCarrierData_Click(object sender, RoutedEventArgs e)
        {
            // Grey out the button

            // Go to the Config Settings page
            AdminFrame.NavigationService.Navigate(new Uri("Admin\\CarrierDataMain.xaml", UriKind.Relative));
        }

        public void SelectRouteTable_Click(object sender, RoutedEventArgs e)
        {
            // Grey out the button

            // Go to the Config Settings page
            AdminFrame.NavigationService.Navigate(new Uri("Admin\\RouteTableMain.xaml", UriKind.Relative));
        }

        public void SelectBackupDb_Click(object sender, RoutedEventArgs e)
        {
            // Grey out the button

            // Go to the Config Settings page
            AdminFrame.NavigationService.Navigate(new Uri("Admin\\BackupDatabase.xaml", UriKind.Relative));
        }
    }
}
