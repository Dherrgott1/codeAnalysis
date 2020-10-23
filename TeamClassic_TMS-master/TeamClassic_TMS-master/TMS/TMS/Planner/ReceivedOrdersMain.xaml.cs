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
    /// Interaction logic for ConfirmOrderMain.xaml
    /// </summary>
    public partial class ReceivedOrdersMain : Page
    {
        List<Order> initiatedOrder;

        public ReceivedOrdersMain()
        {
            InitializeComponent();

            Order tempOrder = new Order();

            //load all of the received orders from the buyer into the ReceivedOrders_LB
            initiatedOrder = tempOrder.getInitiatedOrders();

            InitiatedOrders_DG.ItemsSource = initiatedOrder;
        }

        private void Click_SelectOrder(object sender, RoutedEventArgs e)
        {
            //get selection from the ReceivedOrders_LB

            //send to next page to be loaded into the form

            // go to the ConirmOrderForm to allow planner to add trips
            this.NavigationService.Navigate(new Uri("Planner\\ReceivedOrdersForm.xaml", UriKind.Relative));
        }
    }
}
