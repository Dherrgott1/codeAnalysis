using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Windows.Controls;

namespace TMS
{
    public class Customer
    {
        private const int kCityIndex = 3;
        private const int kProvinceIndex = 4;

        public int CustomerID { get; set; }

        public string CustomerName { get; set; }

        public string CustomerAddress { get; set; }

        public string CustomerCity { get; set; }

        public string CustomerProvince { get; set; }

        public string CustomerPostalCode { get; set; }

        public string CustomerPhone { get; set; }


        // Gets a List<Customer> of existing customers from the Contract Markplace and returns it.
        public static List<Customer> GetExistingCustomers(ListBox existingCustomersBox)
        {
            // Connect to the TMS database
            MySqlConnection dbConnection = DAL.OpenDatabaseConnection(DAL.ConnectionString_tms);

            // Get all of the existing customers from the database
            string requestCustomers = "SELECT * FROM Customer";
            MySqlCommand displayTheCustomers = new MySqlCommand(requestCustomers, dbConnection);
            MySqlDataReader reader = displayTheCustomers.ExecuteReader();

            // Add all Customers to a List
            int custCounter = 0;
            List<Customer> existingCustomerList = new List<Customer>();
            try
            {
                // Read the information in the database and display in textboxes
                while (reader.Read())
                {
                    // Read columns in database row by row
                    var theCustomerName = reader.GetString("CustomerName");
                    var theCustomerId = reader.GetInt32("CustomerId");
                    var theCustomerProvince = "";
                    if (reader.IsDBNull(kProvinceIndex) == false)
                    {
                        theCustomerProvince = reader.GetString("CustomerProvince");
                    }
                    var theCustomerCity = "";
                    if (reader.IsDBNull(kCityIndex) == false)
                    {
                        theCustomerCity = reader.GetString("CustomerCity");
                    }

                    existingCustomerList.Add(new Customer()
                    {
                        CustomerID = theCustomerId,
                        CustomerName = theCustomerName,
                        CustomerProvince = theCustomerProvince,
                        CustomerCity = theCustomerCity
                    });

                    existingCustomersBox.Items.Add(existingCustomerList[custCounter].CustomerName + " - " + existingCustomerList[custCounter].CustomerCity);
                    custCounter++;
                }
            }
            finally
            {
                // Always call Close when done reading.
                reader.Close();
            }

            // Close the database connection
            dbConnection.Close();

            return existingCustomerList;
        }


        // Gets a List<Customer> of potential customers from the Contract Markplace and returns it.
        public static List<Customer> GetNewCustomers(ListBox newCustomersBox)
        {
            // Connect to the TMS database
            MySqlConnection dbConnection = DAL.OpenDatabaseConnection(DAL.ConnectionString_cmp);

            // Get all of the existing customers from the database
            string requestCustomers = "SELECT Client_Name, Origin FROM Contract;";
            MySqlCommand displayTheCustomers = new MySqlCommand(requestCustomers, dbConnection);
            MySqlDataReader reader = displayTheCustomers.ExecuteReader();

            // Add all Customers to a List
            int custCounter = 0;
            List<Customer> newCustomerList = new List<Customer>();
            try
            {
                // Read the information from the database and display it in 'ListBox newCustomersBox'
                while (reader.Read())
                {
                    // Get the Customer name and city of origin
                    var theCustomerName = reader.GetString("Client_Name");
                    var theCustomerCity = reader.GetString("Origin");

                    newCustomerList.Add(new Customer()
                    {
                        CustomerName = theCustomerName,
                        CustomerCity = theCustomerCity
                    });

                    // If the Customer doesn't already exist, add them to the Potential Customer list box
                    if (CheckExistingCustomer(theCustomerName, theCustomerCity) == false)
                    {
                        newCustomersBox.Items.Add(newCustomerList[custCounter].CustomerName + " - " + newCustomerList[custCounter].CustomerCity);
                    }
                    custCounter++;
                }
            }
            finally
            {
                // Make sure the reader is closed if an exception is thrown
                reader.Close();
            }

            // Close the database connection
            dbConnection.Close();

            return newCustomerList;
        }


        // Checks if the new Customer retrieved from the Contract Marketplace already exists in the TMS database
        // Returns true if the Customer already exists, and false if they don't
        public static bool CheckExistingCustomer(string newCustName, string newCustCity)
        {
            bool custExist = false;

            // Connect to the TMS database
            MySqlConnection tmsConnection = DAL.OpenDatabaseConnection(DAL.ConnectionString_tms);
            // Get all of the existing customers from the database
            string existingCustQuery = "SELECT CustomerName, CustomerCity FROM Customer;";
            MySqlCommand existingCustomersCommand = new MySqlCommand(existingCustQuery, tmsConnection);
            MySqlDataReader existingCustReader = existingCustomersCommand.ExecuteReader();            
            
            try
            {
                // Loop reading all existing Customer data that was retrieved
                while (existingCustReader.Read())
                {
                    // Check if the Customer already exists
                    if ( (newCustName == existingCustReader.GetString("CustomerName")) &&
                         (newCustCity == existingCustReader.GetString("CustomerCity")) )
                    {
                        custExist = true;
                    }
                }
            }
            finally
            {
                // Make sure the reader is closed if an exception is thrown
                existingCustReader.Close();
            }

            // Close the connection to the TMS database
            tmsConnection.Close();

            return custExist;
        }
    }
}