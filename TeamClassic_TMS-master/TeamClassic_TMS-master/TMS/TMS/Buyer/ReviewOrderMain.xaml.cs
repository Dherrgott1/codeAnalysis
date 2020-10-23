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
using MySql.Data.MySqlClient;

namespace TMS
{
    /// <summary>
    /// Interaction logic for ReviewOrderMain.xaml
    /// </summary>
    public partial class ReviewOrderMain : Page
    {

        List<Order> orders;
        List<City> allCities;

        public ReviewOrderMain()
        {
            InitializeComponent();

            orders = new List<Order>();
            City tempCity = new City();
            allCities = tempCity.getAllCities();


            // get all of the existing customers from the database
            string requestConfirmedOrders = "SELECT * FROM Orders WHERE OrderStatus = " + "'" + "Confirmed" + "'";

            MySqlConnection connectToDatabase = new MySql.Data.MySqlClient.MySqlConnection("host=127.0.0.1;user=root;password=Conestoga1;database=tms;");


            connectToDatabase.Open();


            MySqlCommand displayTheOrders = new MySqlCommand(requestConfirmedOrders, connectToDatabase);
            MySqlDataReader reader = displayTheOrders.ExecuteReader();


            try
            {
                //Read the information in the database and display in textboxes
                while (reader.Read())
                {
                    //Read columns in database row by row
                    var OrderID_T = reader.GetInt32("OrderID");
                    var StartingCityID_T = reader.GetInt32("StartingCityID");
                    var EndingCityID_T = reader.GetInt32("EndingCityID");
                    var CarrierId_T = reader.GetInt32("CarrierID");
                    var JobType_T = reader.GetString("JobType");
                    var FTLRate_T = reader.GetDouble("FTLRate");
                    var LTLRate_T = reader.GetDouble("LTLRate");
                    var OrderStartDate_T = reader.GetString("OrderStartDate");
                    var OrderCompleteDate_T = reader.GetString("OrderCompleteDate");
                    var TotalCost_T = reader.GetDouble("TotalCost");
                    var OrderStatus_T = reader.GetString("OrderStatus");
                    var VanType_T = reader.GetString("VanType");
                    var Quantity_T = reader.GetInt32("Quantity");
                                       



                    orders.Add(new Order()
                    {
                        OrderID = OrderID_T,
                        StartingCityID = StartingCityID_T,
                        EndingCityID = EndingCityID_T,
                        CarrierID = CarrierId_T,
                        JobType = JobType_T,
                        FTLRate = FTLRate_T,
                        LTLRate = LTLRate_T,
                        OrderStartDate = OrderStartDate_T,
                        OrderCompleteDate = OrderCompleteDate_T,
                        TotalCost = TotalCost_T,
                        OrderStatus = OrderStatus_T,
                        VanType = VanType_T,
                        Quantity = Quantity_T
                        
                    });

                    var OriginCity = allCities.Find(i => i.CityID == StartingCityID_T);
                    var OriginCityName = OriginCity.CityName;
                    var DestinationCity = allCities.Find(i => i.CityID == EndingCityID_T);
                    var DestinationCityName = DestinationCity.CityName;

                    String orderToDisplay = "OrderId: " + OrderID_T + " " + "CarrierId: " + CarrierId_T + " " + "Origin: " + OriginCityName + " " +
                                            "Destination: " + DestinationCityName + " " + "Total Amount: " + TotalCost_T;

                    CompletedOrders.Items.Add(orderToDisplay);
                    
                }
            }
            finally
            {
                // Always call Close when done reading.
                reader.Close();
            }


            connectToDatabase.Close();
                                                                    
        }

        private void Click_ReviewOrder(object sender, RoutedEventArgs e)
        {
            // get the order that was selected in the CompletedOrders listbox

            // get that info from the database

            // send that info to the next page

            //go to the the review order to see the information about this completed order
            this.NavigationService.Navigate(new Uri("Buyer\\ReviewOrderForm.xaml", UriKind.Relative));
        }
    }
}
