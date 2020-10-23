using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using MySql.Data.MySqlClient;

namespace TMS
{
    public partial class ContractMarketMain : Page
    {
        List<Contract> potentialContracts;

        public ContractMarketMain()
        {
            InitializeComponent();
        }


        private void Click_InitiateContact(object sender, RoutedEventArgs e)
        {
            // Query to select contracts from marketplace
            string displayContracts = "SELECT * FROM Contract";

            // Setup connection string
            MySqlConnection connectToMarketplace = DAL.OpenDatabaseConnection(DAL.ConnectionString_cmp);

            // Setup query into mysql command and execute the query
            MySqlCommand displayTheContracts = new MySqlCommand(displayContracts, connectToMarketplace);
            MySqlDataReader reader = displayTheContracts.ExecuteReader();

            // List to hold new contracts
            potentialContracts = new List<Contract>();

            try
            {
                // Loop reading all records
                while (reader.Read())
                {
                    Contract newContract = new Contract();
                    // Read values from database row by row
                    newContract.ClientName = reader.GetString("Client_Name");
                    newContract.JobType = reader.GetString("Job_Type");
                    newContract.Quantity = reader.GetString("Quantity");
                    newContract.Origin = reader.GetString("Origin");
                    newContract.Destination = reader.GetString("Destination");
                    newContract.VanType = reader.GetString("Van_Type");
                    
                    // Add new contracts to the list
                    potentialContracts.Add(newContract);
                }
            }
            catch (MySqlException getContracts_e)
            {
                Logger.Log("An error has occurred while getting retrieving contracts from the\n" +
                    "Contract Marketplace (CMP) database.", getContracts_e.Message);
            }
            finally
            {
                // Always call Close when done reading.
                reader.Close();
            }

            // Disconnect from database
            connectToMarketplace.Close();

            // Add to the datagrid
            PotentialContracts_DG.ItemsSource = potentialContracts;
        }


        private void Click_AddContract(object sender, RoutedEventArgs e)
        {
            if (PotentialContracts_DG.SelectedIndex == -1)
            {
                Messenger.DisplayMessage("Sorry, you need to select contract to add!", "Buyer");
                return;
            }

            // Get selected contract from data grid to create a new order
            Contract newContract = (Contract)PotentialContracts_DG.SelectedItem;

            PotentialContracts_DG.SelectedIndex = -1;

            // Remove this customer from our list
            var Contract = potentialContracts.Find(i => (i.ClientName == newContract.ClientName) && (i.Origin == newContract.Origin) && (i.Destination == newContract.Destination));
            potentialContracts.Remove(Contract);

            Order newOrder = new Order();

            //find out order count to set new id
            int orderCount = getOrderCount();
            newOrder.OrderID = orderCount + 1;

            newOrder.OrderStatus = "INITIATED";
            newOrder.JobType = newContract.JobType;
            newOrder.VanType = newContract.VanType;
            newOrder.Quantity = Convert.ToInt32(newContract.Quantity);

            // Get city name and id for new order
            List<City> allCities = new List<City>();
            City tempCity = new City();
            allCities = tempCity.getAllCities();

            var OriginCity = allCities.Find(i => i.CityName == Contract.Origin);
            newOrder.StartingCityID = OriginCity.CityID;
            newOrder.Origin = OriginCity.CityName;

            var DestinationCity = allCities.Find(i => i.CityName == Contract.Destination);
            newOrder.EndingCityID = DestinationCity.CityID;
            newOrder.Destination = DestinationCity.CityName;

            // Add the Order to the database
            newOrder.AddToDB(newOrder);

            PotentialContracts_DG.ItemsSource = null;

            PotentialContracts_DG.ItemsSource = potentialContracts;
        }


        private void Click_ReviewContract(object sender, RoutedEventArgs e)
        {
            if (PotentialContracts_DG.SelectedIndex == -1)
            {
                Messenger.DisplayMessage("Sorry, you need to select a contract to review!", "Buyer");
                return;
            }

            // get selected contract from potential/exisiting contract list box and get its info from database
            Contract newContract = (Contract)PotentialContracts_DG.SelectedItem;
            
            //use that information to send to the next page            
            ReviewContract reviewContract = new ReviewContract(newContract);

            //go to the the review customer to see the information about this contract
            this.NavigationService.Navigate(reviewContract);            
        }


        public int getOrderCount()
        {
            // Get all of the products from database and load them into Products_LB
            MySqlConnection connectToPOSDB = new MySql.Data.MySqlClient.MySqlConnection("host=127.0.0.1;user=root;password=Conestoga1;database=tms;");

            //Connect to database
            connectToPOSDB.Open();

            //get the number of rows in orderline to set new order line
            string getCountQuery = "SELECT COUNT(*) FROM Orders";

            //Setup query into mysql command
            MySqlCommand displayTheCount = new MySqlCommand(getCountQuery, connectToPOSDB);

            //Start reading the database
            MySqlDataReader reader = displayTheCount.ExecuteReader();

            int OLCount = 2;

            try
            {
                while (reader.Read())
                {
                    //Read values from database row by row
                    var Count_T = reader.GetString("COUNT(*)");
                    OLCount = Convert.ToInt32(Count_T);
                }

                // Always call Close when done reading.
                reader.Close();
            }
            catch (MySqlException orderCount_e)
            {
                Logger.Log("An error has occured while getitng the number of the Order count.", orderCount_e.Message);
            }

            connectToPOSDB.Close();

            return OLCount;
        }
    }
}
