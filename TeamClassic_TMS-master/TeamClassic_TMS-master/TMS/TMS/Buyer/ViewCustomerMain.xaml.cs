using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using MySql.Data.MySqlClient;

namespace TMS
{
    public partial class ViewCustomerMain : Page
    {
        List<Customer> existingCustomers;
        List<Customer> newCustomers;


        public ViewCustomerMain()
        {
            InitializeComponent();

            existingCustomers = Customer.GetExistingCustomers(ExistingCustomers_LB);
            newCustomers = Customer.GetNewCustomers(PotentialsCustomers_LB);
        }


        private void Click_AddCustomer(object sender, RoutedEventArgs e)
        {
            // Check if a Customer was selected from the ListBox
            if (PotentialsCustomers_LB.SelectedItem != null)
            {
                // Get selected customer from potential customer list box and remove it from list box
                string potentialCustomer = PotentialsCustomers_LB.SelectedItem.ToString();
                PotentialsCustomers_LB.Items.Remove(PotentialsCustomers_LB.SelectedItem);
               
                // Parse the Customer name and city
                string[] tokens = potentialCustomer.Split('-');
                string custName = tokens[0].Trim();
                string custCity = tokens[1].Trim();

                // Add the new Customer into the ExistingCustomer listbox
                ExistingCustomers_LB.Items.Add(potentialCustomer);
                
                // Connect to the datbase create the query string
                string insertCustQuery = "INSERT INTO Customer (CustomerName, CustomerCity) VALUES " +
                            "(@CustomerName, @CustomerCity)";
                MySqlConnection insertConnection = DAL.OpenDatabaseConnection(DAL.ConnectionString_tms);
                MySqlCommand command = new MySqlCommand(insertCustQuery, insertConnection);

                command.Parameters.Add("@CustomerName", MySqlDbType.String).Value = custName;
                command.Parameters.Add("@CustomerCity", MySqlDbType.String).Value = custCity;
                // Add the query to add the new Customer into the database
                command.ExecuteNonQuery();

                // Reload the view customer main page to show the updated list boxes
                ViewCustomerMain reloadPage = new ViewCustomerMain();
                this.NavigationService.Navigate(reloadPage);
            }
            else
            {
                Messenger.DisplayMessage("You must select a customer to add.", UIManager.WindowTitleList[UIManager.kBuyer_TitleIndex]);
            }
        }


        private void Click_ReviewCustomer(object sender, RoutedEventArgs e)
        {
            // Check if a Customer was selected from the ListBox
            if (ExistingCustomers_LB.SelectedItem != null)
            {
                // get selected customer from potential/exisiting customer list box and get its info from database
                string customerToReview = ExistingCustomers_LB.SelectedItem.ToString();
                string[] tokens = customerToReview.Split('-');
                customerToReview = tokens[0].Trim();
                //use that information to send to the next page

                var customerFromList = existingCustomers.Find(i => i.CustomerName == customerToReview);

                if (customerFromList == null)
                {
                    // go to the update carrier page
                    this.NavigationService.Navigate(new Uri("Buyer\\ViewCustomerMain.xaml", UriKind.Relative));
                }
                else
                {
                    ReviewCustomer newPage = new ReviewCustomer(customerFromList);
                    this.NavigationService.Navigate(newPage);
                }
            }
            else
            {
                Messenger.DisplayMessage("You must select a customer to review.", UIManager.WindowTitleList[UIManager.kBuyer_TitleIndex]);
            }
        }
    }
}
