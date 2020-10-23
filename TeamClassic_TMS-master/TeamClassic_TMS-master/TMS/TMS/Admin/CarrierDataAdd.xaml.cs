using System;
using System.Windows;
using System.Windows.Controls;
using MySql.Data.MySqlClient;

namespace TMS
{
    public partial class CarrierDataAdd : Page
    {
        public CarrierDataAdd()
        {
            InitializeComponent();
        }

        private void Click_AddCarrier(object sender, RoutedEventArgs e)
        {
            //allow user to select a directory

            //Query to insert carrier into CarrerData
            string insertCarrier = "INSERT INTO CarrierData (CarrierID, AdminID, CarrierName, DepotCity, FTLAvailability, LTLAvailability, FTLRate, LTLRate, ReeferCharge) VALUES" +
                                   "(@CarrierID, @AdminID, @CarrierName, @DepotCity, @FTLAvailability, @LTLAvailability, @FTLRate, @LTLRate, @ReeferCharge)";


            try
            {
                //Setup Connection String
                MySqlConnection connectToDatabase = new MySql.Data.MySqlClient.MySqlConnection("host=127.0.0.1;user=root;password=Conestoga1;database=tms;");

                //Connect to Database
                connectToDatabase.Open();

                MySqlCommand insertNewCarrier = new MySqlCommand(insertCarrier, connectToDatabase);

                //Adding values to the query string to be added
                insertNewCarrier.Parameters.Add("@CarrierID", MySqlDbType.Int32).Value = CarrierID.Text;
                insertNewCarrier.Parameters.Add("@AdminID", MySqlDbType.Int32).Value = "1";
                insertNewCarrier.Parameters.Add("@CarrierName", MySqlDbType.MediumText).Value = CarrierName.Text;
                insertNewCarrier.Parameters.Add("@DepotCity", MySqlDbType.MediumText).Value = DepotCity.Text;
                insertNewCarrier.Parameters.Add("@FTLAvailability", MySqlDbType.Int32).Value = FTLAvail.Text;
                insertNewCarrier.Parameters.Add("@LTLAvailability", MySqlDbType.Int32).Value = LTLAvail.Text;
                insertNewCarrier.Parameters.Add("@FTLRate", MySqlDbType.Double).Value = FTLRate.Text;
                insertNewCarrier.Parameters.Add("@LTLRate", MySqlDbType.Double).Value = LTLRate.Text;
                insertNewCarrier.Parameters.Add("@ReeferCharge", MySqlDbType.Double).Value = ReeferCharge.Text;

                //Execute Query
                insertNewCarrier.ExecuteNonQuery();

                //Disconnect From Database
                connectToDatabase.Close();
            }
            catch (MySqlException addCarrier_e)
            {
                Logger.Log("\n", addCarrier_e.Message);
            }

            //Return to CarrierDataMain page
            this.NavigationService.Navigate(new Uri("Admin\\CarrierDataMain.xaml", UriKind.Relative));

        }
    }
}
