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
    /// Interaction logic for OrderSummary.xaml
    /// </summary>
    public partial class OrderSummary : Page
    {
        public OrderSummary()
        {
            InitializeComponent();

            //load all active orders into the ActiveOrders_LB

            //load all of the completed order into the CompletedOrders_LB

        }

        private void Click_ReviewActiveOrder(object sender, RoutedEventArgs e)
        {
            //get the selection from the ACtiveOrder_LB

            //load that information for the next page

            // reload main page with selection deleted
            this.NavigationService.Navigate(new Uri("Planner\\OrderSummaryReview.xaml", UriKind.Relative));
        }

        private void Click_ReviewOrder(object sender, RoutedEventArgs e)
        {

        }

        private void Click_ConfirmOrder(object sender, RoutedEventArgs e)
        {

        }
    }
}
