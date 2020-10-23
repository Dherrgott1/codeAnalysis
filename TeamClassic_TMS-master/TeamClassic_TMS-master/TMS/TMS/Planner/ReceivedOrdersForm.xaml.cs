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
    /// Interaction logic for ConfirmOrderForm.xaml
    /// </summary>
    public partial class ReceivedOrdersForm : Page
    {
        public ReceivedOrdersForm()
        {
            InitializeComponent();

            //take all of the cities from the order and load them into TargetedCities_LB

        }

        private void Click_SelectCity(object sender, RoutedEventArgs e)
        {
            //get the selected city from the TargetedCities_LB

            //load all the carriers that are in that city to the 
        }

        private void Click_AddTrip(object sender, RoutedEventArgs e)
        {

        }
    }
}
