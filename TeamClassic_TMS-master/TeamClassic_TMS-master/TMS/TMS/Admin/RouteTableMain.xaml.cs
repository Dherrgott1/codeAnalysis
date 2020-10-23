using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using MySql.Data.MySqlClient;

namespace TMS
{
    public partial class RouteTableMain : Page
    {
        List<RouteTable> routes;


        public RouteTableMain()
        {
            InitializeComponent();
            routes = new List<RouteTable>();

            // Get all of the Route information from the database
            string displayRoute = "SELECT * FROM Route";
            MySqlConnection connectToDatabase = DAL.OpenDatabaseConnection(DAL.ConnectionString_tms);
            MySqlCommand displayTheCarrier = new MySqlCommand(displayRoute, connectToDatabase);
            MySqlDataReader reader = displayTheCarrier.ExecuteReader();

            try
            {
                //Read the information in the database and display in textboxes
                while (reader.Read())
                {
                    //Read columns in database row by row
                    var routeId = reader.GetString("RouteId");
                    var destination = reader.GetString("Destination");
                    var kiloMeters = reader.GetString("Kilometers");
                    var timeHours = reader.GetString("TimeInHours");
                    var west = reader.GetString("West");
                    var east = reader.GetString("East");
                    
                    routes.Add(new RouteTable() { RouteId = routeId, Destination = destination, Kilometers = kiloMeters, TimeHours = timeHours, West = west, East = east });

                    RouteTable_DG.ItemsSource = routes;
                }
            }
            catch (MySqlException routeLoad_e)
            {
                Logger.Log("An error has occurred while loading Route data from the TMS database.", routeLoad_e.Message);
            }
            finally
            {
                // Always call Close when done reading.
                reader.Close();
            }
          
            // Load the route detsination name into the RouteTable_ComboB
            for (int i = 0; i < routes.Count; i++)
            {
                RouteTable_ComboB.Items.Add(routes[i].RouteId + "  " + routes[i].Destination);
            }

            connectToDatabase.Close();
        }


        private void Click_AddRouteTable(object sender, RoutedEventArgs e)
        {
            // Go to the add route table page
            this.NavigationService.Navigate(new Uri("Admin\\RouteTableAdd.xaml", UriKind.Relative));
        }


        private void Click_UpdateRouteTable(object sender, RoutedEventArgs e)
        {
            if (RouteTable_ComboB.SelectedItem != null)
            {
                // Get the carrier chosen in the RouteData_ComboB
                string selectedRoute = RouteTable_ComboB.SelectedItem.ToString();
                string[] chosenRoute = selectedRoute.Split();

                //get all of the info for this carrier from the list to send to the next page
                var Route = routes.Find(i => i.RouteId == chosenRoute[0]);

                if (Route == null)
                {
                    // Go to the update carrier page
                    this.NavigationService.Navigate(new Uri("Admin\\CarrierDataMain.xaml", UriKind.Relative));
                }
                else
                {
                    RouteTableUpdate newPage = new RouteTableUpdate(Route);
                    this.NavigationService.Navigate(newPage);
                }
            }
        }


        private void Click_DeleteRouteTable(object sender, RoutedEventArgs e)
        {
            if (RouteTable_ComboB.SelectedItem != null)
            {
                // Get the selection from the RouteTable_ComboB combo box
                string selectedRoute = RouteTable_ComboB.SelectedItem.ToString();
                string[] chosenRoute = selectedRoute.Split();

                string deleteRoute = "DELETE FROM Route WHERE RouteId = " + "'" + chosenRoute[0] + "'";

                // Delete Carrier from table command
                // string deleteCarrierData = "DELETE FROM CarrierData WHERE CarrierID = " + "'" + carrierIdentity + "'";
                MySqlConnection connectToDatabase = DAL.OpenDatabaseConnection(DAL.ConnectionString_tms);
                try
                {
                    MySqlCommand deleteRouteFromTable = new MySqlCommand(deleteRoute, connectToDatabase);

                    // Perform delete queries
                    deleteRouteFromTable.ExecuteNonQuery();

                    // Disconnect from database
                    connectToDatabase.Close();
                }
                catch (MySqlException deleteRoute_e)
                {
                    Logger.Log("An error occurred while attempting to delete a Route.", deleteRoute_e.Message);
                }
            }

            // Refresh Page
            this.NavigationService.Refresh();         
        }
    }
}
