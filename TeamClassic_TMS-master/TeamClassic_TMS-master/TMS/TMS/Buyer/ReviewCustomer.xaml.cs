using System;
using System.Windows;
using System.Windows.Controls;

namespace TMS
{
    public partial class ReviewCustomer : Page
    {
        private Customer selectedCustomer;


        public ReviewCustomer(Customer newCustomer)
        {
            InitializeComponent();

            // Load the customer that was selected into the form
            selectedCustomer = newCustomer;
            this.Loaded += new RoutedEventHandler(CustomerDataReview_Loaded);
        }


        private void CustomerDataReview_Loaded(object sender, RoutedEventArgs e)
        {
            // Get contents from the last page
            CustomerID_TB.Text = Convert.ToString(selectedCustomer.CustomerID);
            CustomerName_TB.Text = selectedCustomer.CustomerName;
            CustomerCity_TB.Text = selectedCustomer.CustomerCity;
            CustomerProvince_TB.Text = selectedCustomer.CustomerProvince;
        }


        private void Click_Done(object sender, RoutedEventArgs e)
        {
            // Return to ViewCustomerMain
            this.NavigationService.Navigate(new Uri("Buyer\\ViewCustomerMain.xaml", UriKind.Relative));
        }
    }
}
