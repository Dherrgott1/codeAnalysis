using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace TMS
{
    public class Order
    {
        public int OrderID { get; set; }

        public int StartingCityID { get; set; }

        public int EndingCityID { get; set; }

        public string Origin { get; set; }

        public string Destination { get; set; }

        public int CarrierID { get; set; }

        public string JobType { get; set; }

        public double FTLRate { get; set; }

        public double LTLRate { get; set; }

        public string OrderStartDate { get; set; }

        public string OrderCompleteDate { get; set; }

        public double TotalCost { get; set; }

        public string OrderStatus { get; set; }

        public string VanType { get; set; }

        public int Quantity { get; set; }


        public void AddToDB(Order newOrder)
        {
            // Set up connection
            MySqlConnection connectToPOSDB = new MySql.Data.MySqlClient.MySqlConnection("host=127.0.0.1;user=root;password=Conestoga1;database=tms;");

            //Connect to database
            connectToPOSDB.Open();

            string addNewOrderQuery = "INSERT INTO Orders (OrderID, JobType, StartingCityID, EndingCityID, VanType, OrderStatus, Quantity) " +
                                         "VALUES ('" + newOrder.OrderID + "', '" + newOrder.JobType + "', '" + newOrder.StartingCityID + "', '" + 
                                         newOrder.EndingCityID + "', '" + newOrder.VanType +"', '" + newOrder.OrderStatus
                                         + "', '" + newOrder.Quantity + "'); ";

            // Setup query into mysql command
            MySqlCommand addingOrder = new MySqlCommand(addNewOrderQuery, connectToPOSDB);

            int rowsAffected = addingOrder.ExecuteNonQuery();
            if (rowsAffected <= 0)
            {
                //ERROR?
                //MessageBox.Show("Error Adding Order to the Database.");
            }

            connectToPOSDB.Close();
        }


        public List<Order> getInitiatedOrders()
        {
            List<Order> initiatedOrders = new List<Order>();
            List<City> allCities = new List<City>();
            City tempCity = new City();

            allCities = tempCity.getAllCities();

            // Set up connection
            MySqlConnection connectToPOSDB = new MySql.Data.MySqlClient.MySqlConnection("host=127.0.0.1;user=root;password=Conestoga1;database=tms;");

            //Connect to database
            connectToPOSDB.Open();

            //Query to select contracts from marketplace
            string getOrders = "SELECT * FROM Orders WHERE OrderStatus = 'INITIATED';";

            //Setup query into mysql command
            MySqlCommand displayTheOrders = new MySqlCommand(getOrders, connectToPOSDB);

            //Start reading the database
            MySqlDataReader reader = displayTheOrders.ExecuteReader();

            try
            {
                while (reader.Read())
                {
                    //Read values from database row by row
                    var OrderID_T = reader.GetString("OrderID");
                    var StartingCityID_T = reader.GetString("StartingCityID");
                    var EndingCityID_T = reader.GetString("EndingCityID");
                    var JobType_T = reader.GetString("JobType");
                    var OrderStatus_T = reader.GetString("OrderStatus");
                    var VanType_T = reader.GetString("VanType");
                    var Quantity_T = reader.GetString("Quantity");

                    Order newOrder = new Order();
                    newOrder.OrderID = Convert.ToInt32(OrderID_T);
                    newOrder.StartingCityID = Convert.ToInt32(StartingCityID_T);
                    //get start city name
                    var OriginCity = allCities.Find(i => i.CityID == newOrder.StartingCityID);
                    newOrder.Origin = OriginCity.CityName;

                    newOrder.EndingCityID = Convert.ToInt32(EndingCityID_T);
                    //get end city name
                    var DestinationCity = allCities.Find(i => i.CityID == newOrder.EndingCityID);
                    newOrder.Destination = OriginCity.CityName;

                    newOrder.JobType = JobType_T;
                    newOrder.OrderStatus = OrderStatus_T;
                    newOrder.VanType = VanType_T;
                    newOrder.Quantity = Convert.ToInt32(Quantity);

                    // add new contracts to the list
                    initiatedOrders.Add(newOrder);
                }
            }
            finally
            {
                // Always call Close when done reading.
                reader.Close();
            }

            connectToPOSDB.Close();

            return initiatedOrders;
        }

    }
}