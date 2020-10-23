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
    /// Interaction logic for RolePage.xaml
    /// </summary>
    public partial class RolePage : Page
    {
        public UIManager ui_m;

        public RolePage(UIManager ui)
        {
            InitializeComponent();
            ui_m = ui; // Keep track of the instance of the UI class
        }

        private void AdminBtn_Click(object sender, RoutedEventArgs e)
        {
            ui_m.ChangeToAdminPage();
        }

        private void BuyerBtn_Click(object sender, RoutedEventArgs e)
        {
            ui_m.ChangeToBuyerPage();
        }

        private void PlannerBtn_Click(object sender, RoutedEventArgs e)
        {
            ui_m.ChangeToPlannerPage();
        }
    }
}
