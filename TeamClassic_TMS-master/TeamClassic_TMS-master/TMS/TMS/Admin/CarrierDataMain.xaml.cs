using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using MySql.Data.MySqlClient;

namespace TMS
{
    public partial class CarrierDataMain : Page
    {
        List<CarrierData> rates;

        public CarrierDataMain()
        {
            InitializeComponent();
            rates = new List<CarrierData>();

            //get all of the Carrier Data information and print it into the CarrierData_DataGrid table using CarrierData class

            //Display carrier based on carrier ID from previous page, query.
            string displayCarrier = "SELECT * FROM CarrierData";


            MySqlConnection connectToDatabase = new MySql.Data.MySqlClient.MySqlConnection("host=127.0.0.1;user=root;password=Conestoga1;database=tms;");
            connectToDatabase.Open();
            MySqlCommand displayTheCarrier = new MySqlCommand(displayCarrier, connectToDatabase);
            MySqlDataReader reader = displayTheCarrier.ExecuteReader();

            try
            {
                //Read the information in the database and display in textboxes
                while (reader.Read())
                {
                    //Read columns in database row by row
                    var carrierID = reader.GetInt32("CarrierID");
                    var theCarrierName = reader.GetString("CarrierName");
                    var depotCity = reader.GetString("DepotCity");
                    var fTLAvail = reader.GetInt32("FTLAvailability");
                    var lTLAvail = reader.GetInt32("LTLAvailability");
                    var fTLRate = reader.GetDouble("FTLRate");
                    var lTLRate = reader.GetDouble("LTLRate");
                    var reefer = reader.GetDouble("ReeferCharge");

                    rates.Add(new CarrierData() { CarrierID = carrierID, CarrierName = theCarrierName, DepotCity = depotCity, FTLAvail = fTLAvail,
                                                  LTLAvail = lTLAvail, FTLRate = fTLRate, LTLRate = lTLRate, ReeferCharge = reefer });

                    CarrierData_DataGrid.ItemsSource = rates;
                }
            }
            catch (MySqlException reader_e)
            {
                Logger.Log("Error occurred while reading from the CarrierData table within the TMS database.", reader_e.Message);
            }
            finally
            {
                // Always call Close when done reading.
                reader.Close();
            }
           
            //get the number of carriers
            int numberOfCarriers = rates.Count;

            //load the carrier name into the CarrierData_ComboB
            for (int i = 0; i < numberOfCarriers; i++)
            {
                CarrierData_ComboB.Items.Add(rates[i].CarrierID + " " + rates[i].CarrierName);
            }

        }



        private void SelectAddCarrier_Click(object sender, EventArgs e)
        {
            //allow user to update the connection settings

            //go to the add carrier page
            this.NavigationService.Navigate(new Uri("Admin\\CarrierDataAdd.xaml", UriKind.Relative));
        }




        private void SelectUpdateCarrier_Click(object sender, EventArgs e)
        {
            //get the carrier chosen in the CarrierData_ComboB
            string selectedCarrier = CarrierData_ComboB.SelectedItem.ToString();
            int pos = selectedCarrier.IndexOf(' ');
            selectedCarrier = selectedCarrier.Substring(0, pos);
            int selectedCarrierID = Convert.ToInt32(selectedCarrier);

            //get all of the info for this carrier from the list to send to the next page
            var Carrier = rates.Find(i => i.CarrierID == selectedCarrierID);

            if (Carrier == null)
            {
                // go to the update carrier page
                this.NavigationService.Navigate(new Uri("Admin\\CarrierDataMain.xaml", UriKind.Relative));
            }
            else
            {
                CarrierDataUpdate newPage = new CarrierDataUpdate(Carrier);
                this.NavigationService.Navigate(newPage);                
            }
        }





        private void SelectDeleteCarrier_Click(object sender, RoutedEventArgs e)
        {
            //get the carrier chosen in the CarrierData_ComboB
            if (CarrierData_ComboB.SelectedItem != null)
            {
                string selectedCarrier = CarrierData_ComboB.SelectedItem.ToString();
                int pos = selectedCarrier.IndexOf(' ');
                selectedCarrier = selectedCarrier.Substring(0, pos);
                int selectedCarrierID = Convert.ToInt32(selectedCarrier);

                //get all of the info for this carrier from the list to send to the next page
                var Carrier = rates.Find(i => i.CarrierID == selectedCarrierID);

                if (Carrier == null)
                {
                    // go to the update carrier page
                    this.NavigationService.Navigate(new Uri("Admin\\CarrierDataMain.xaml", UriKind.Relative));
                }
                else
                {
                    string carrierIdentity = Carrier.CarrierID.ToString();

                    //Delete Foreign Key From RateFee table command
                    string deleteCarrierForeignKey = "DELETE FROM RateFee WHERE CarrierID = " + "'" + carrierIdentity + "'";

                    //Delete Carrier from table command
                    string deleteCarrierData = "DELETE FROM CarrierData WHERE CarrierID = " + "'" + carrierIdentity + "'";

                    try
                    {
                        MySqlConnection connectToDatabase = new MySql.Data.MySqlClient.MySqlConnection("host=127.0.0.1;user=root;password=Conestoga1;database=tms;");

                        MySqlCommand deleteForeignKeyCarrier = new MySqlCommand(deleteCarrierForeignKey, connectToDatabase);
                        MySqlCommand deleteCarrierId = new MySqlCommand(deleteCarrierData, connectToDatabase);

                        // Connect to database
                        connectToDatabase.Open();

                        // Perform delete queries
                        deleteForeignKeyCarrier.ExecuteNonQuery();
                        deleteCarrierId.ExecuteNonQuery();

                        // Disconnect from database
                        connectToDatabase.Close();
                    }
                    catch (MySqlException delete_e)
                    {
                        Logger.Log("An error has occurred while attempting to delete a Carrier.", delete_e.Message);
                    }

                    // reload main page with selection deleted
                    this.NavigationService.Refresh();

                }
            }
            else
            {
                Messenger.DisplayMessage("You must select a Carrier from the drop-down list to delete.", "Admin");
            }
        }
    }
}
