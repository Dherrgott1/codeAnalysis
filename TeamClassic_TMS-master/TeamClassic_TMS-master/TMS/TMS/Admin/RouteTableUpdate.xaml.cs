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
    /// Interaction logic for RouteTableUpdate.xaml
    /// </summary>
    public partial class RouteTableUpdate : Page
    {

        RouteTable selectedCarrierTemp;
        string routeIdToUpdate;

        public RouteTableUpdate()
        {
            InitializeComponent();

            //get the info from database from slection from last page to fill the text boxes

            //fill the text boxes
        }


        public RouteTableUpdate(RouteTable route) : this()
        {
            selectedCarrierTemp = route;
            this.Loaded += new RoutedEventHandler(RouteUpdated_Click);
        }



        private void RouteUpdated_Click(object sender, RoutedEventArgs e)
        {
            //get contents from the last page
            RouteTable selectedCarrier = selectedCarrierTemp;

            routeIdToUpdate = selectedCarrier.RouteId;
            Destination.Text = selectedCarrier.Destination;
            Kilometers.Text = Convert.ToString(selectedCarrier.Kilometers);
            TimeHours.Text = Convert.ToString(selectedCarrier.TimeHours);
            West.Text = Convert.ToString(selectedCarrier.West);
            East.Text = Convert.ToString(selectedCarrier.East);
            
        }






        private void Click_UpdateRoute(object sender, RoutedEventArgs e)
        {
            //get the info from all of the text boxes
            //validate the information
           
            
            //if valid update the database with new information


            //Query to update carrier in CarrierData table
            string updateRouteTable = "UPDATE Route SET Destination = @Destination, Kilometers = @Kilometers, TimeInHours = @TimeInHours, West = @West, East = @East WHERE RouteId = @RouteId";

            try
            {
                //Setup connection string
                MySqlConnection connectToDatabase = DAL.OpenDatabaseConnection(DAL.ConnectionString_tms);

                MySqlCommand updateRoute = new MySqlCommand(updateRouteTable, connectToDatabase);
                //Add values to the query
                updateRoute.Parameters.Add("@RouteId", MySqlDbType.String).Value = routeIdToUpdate;
                updateRoute.Parameters.Add("@Destination", MySqlDbType.String).Value = Destination.Text;
                updateRoute.Parameters.Add("@Kilometers", MySqlDbType.String).Value = Kilometers.Text;
                updateRoute.Parameters.Add("@TimeInHours", MySqlDbType.String).Value = TimeHours.Text;
                updateRoute.Parameters.Add("@West", MySqlDbType.String).Value = West.Text;
                updateRoute.Parameters.Add("@East", MySqlDbType.String).Value = East.Text;

                //Execute Query
                updateRoute.ExecuteNonQuery();

                //Disconnect from database
                connectToDatabase.Close();
            }
            catch (MySqlException updateRoute_e)
            {
                Logger.Log("An exception occurred while the Carrier Route Table", updateRoute_e.Message);
            }

            // go to the route table main page
            this.NavigationService.Navigate(new Uri("Admin\\RouteTableMain.xaml", UriKind.Relative));
        }
    }
}
