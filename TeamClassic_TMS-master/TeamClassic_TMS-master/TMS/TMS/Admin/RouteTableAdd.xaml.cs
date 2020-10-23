using System;
using System.Windows;
using System.Windows.Controls;
using MySql.Data.MySqlClient;

namespace TMS
{
    public partial class RouteTableAdd : Page
    {
        public RouteTableAdd()
        {
            InitializeComponent();
        }

        private void Click_AddRoute(object sender, RoutedEventArgs e)
        {
            //get the info from all the textboxes
            string newDestination = Destination.Text;
            string newKilometers = Kilometers.Text;
            string newTime = TimeHours.Text;
            string newWest = West.Text;
            string newEast = East.Text;


            //Query to update carrier in CarrierData table
            string insertNewRoute = "INSERT INTO Route (AdminId, Destination, Kilometers, TimeInHours, West, East) VALUES" +
                                    "(@AdminId, @Destination, @Kilometers, @TimeInHours, @West, @East)";

            try
            {
                //Setup connection string and connect to database
                MySqlConnection connectToDatabase = new MySql.Data.MySqlClient.MySqlConnection("host=127.0.0.1;user=root;password=Conestoga1;database=tms;");
                connectToDatabase.Open();

                MySqlCommand insertNewRouteCommand = new MySqlCommand(insertNewRoute, connectToDatabase);

                //Add values to the query
                insertNewRouteCommand.Parameters.Add("@AdminId", MySqlDbType.Int32).Value = 1;
                insertNewRouteCommand.Parameters.Add("@Destination", MySqlDbType.String).Value = newDestination;
                insertNewRouteCommand.Parameters.Add("@Kilometers", MySqlDbType.String).Value = newKilometers;
                insertNewRouteCommand.Parameters.Add("@TimeInHours", MySqlDbType.String).Value = newTime;
                insertNewRouteCommand.Parameters.Add("@West", MySqlDbType.String).Value = newWest;
                insertNewRouteCommand.Parameters.Add("@East", MySqlDbType.String).Value = newEast;

                //Execute Query
                insertNewRouteCommand.ExecuteNonQuery();

                //Disconnect from database
                connectToDatabase.Close();
            }
            catch (MySqlException addRoute_e)
            {
                Logger.Log("An error occurred while adding a route.", addRoute_e.Message);
            }
            //validate all of the information

            //if valid add the route to the database

            // go to the route table main page
            this.NavigationService.Navigate(new Uri("Admin\\RouteTableMain.xaml", UriKind.Relative));
        }
    }
}
