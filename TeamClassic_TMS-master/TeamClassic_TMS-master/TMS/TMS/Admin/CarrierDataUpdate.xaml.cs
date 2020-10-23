using System;
using System.Windows;
using System.Windows.Controls;
using MySql.Data.MySqlClient;

namespace TMS
{
    public partial class CarrierDataUpdate : Page
    {
        CarrierData selectedCarrierTemp;
        public CarrierDataUpdate()
        {
            InitializeComponent();
        }

        public CarrierDataUpdate(CarrierData carrier):this()
        {
            selectedCarrierTemp = carrier;
            this.Loaded += new RoutedEventHandler(CarrierDataUpdate_Loaded);
        }

        private void CarrierDataUpdate_Loaded(object sender, RoutedEventArgs e)
        {
            //get contents from the last page
            CarrierData selectedCarrier = selectedCarrierTemp;

            CarrierID.Text = Convert.ToString(selectedCarrier.CarrierID);
            CarrierName.Text = selectedCarrier.CarrierName;
            DepotCity.Text = selectedCarrier.DepotCity;
            FTLAvail.Text = Convert.ToString(selectedCarrier.FTLAvail);
            LTLAvail.Text = Convert.ToString(selectedCarrier.LTLAvail);
            FTLRate.Text = Convert.ToString(selectedCarrier.FTLRate);
            LTLRate.Text = Convert.ToString(selectedCarrier.LTLRate);
            ReeferCharge.Text = Convert.ToString(selectedCarrier.ReeferCharge);

        }

        private void Click_UpdateCarrier(object sender, RoutedEventArgs e)
        {
            //Query to update carrier in CarrierData table
            string updateCarrier = "UPDATE CarrierData SET CarrierID = @CarrierID, CarrierName = @CarrierName, DepotCity = @DepotCity, FTLAvailability = @FTLAvailability," +
                                    "LTLAvailability = @LTLAvailability, FTLRate = @FTLRate, LTLRate = @LTLRate, ReeferCharge = @ReeferCharge WHERE CarrierID = @CarrierID";


            try
            {
                //Setup connection string
                MySqlConnection connectToDatabase = new MySql.Data.MySqlClient.MySqlConnection("host=127.0.0.1;user=root;password=Conestoga1;database=tms;");

                //Connect to database
                connectToDatabase.Open();


                MySqlCommand insertNewCarrier = new MySqlCommand(updateCarrier, connectToDatabase);

                //Add values to the query
                insertNewCarrier.Parameters.Add("@CarrierID", MySqlDbType.Int32).Value = CarrierID.Text;
                insertNewCarrier.Parameters.Add("@CarrierName", MySqlDbType.MediumText).Value = CarrierName.Text;
                insertNewCarrier.Parameters.Add("@DepotCity", MySqlDbType.MediumText).Value = DepotCity.Text;
                insertNewCarrier.Parameters.Add("@FTLAvailability", MySqlDbType.Int32).Value = FTLAvail.Text;
                insertNewCarrier.Parameters.Add("@LTLAvailability", MySqlDbType.Int32).Value = LTLAvail.Text;
                insertNewCarrier.Parameters.Add("@FTLRate", MySqlDbType.Double).Value = FTLRate.Text;
                insertNewCarrier.Parameters.Add("@LTLRate", MySqlDbType.Double).Value = LTLRate.Text;
                insertNewCarrier.Parameters.Add("@ReeferCharge", MySqlDbType.Double).Value = ReeferCharge.Text;

                //Execute Query
                insertNewCarrier.ExecuteNonQuery();

                //Disconnect from database
                connectToDatabase.Close();
            }
            catch (MySqlException updateCarrier_e)
            {
                Logger.Log("An error occurred while updating a Carrier within the TMS database", updateCarrier_e.Message);
            }
            // reload main page with selection deleted
            this.NavigationService.Navigate(new Uri("Admin\\CarrierDataMain.xaml", UriKind.Relative));
        }
    }
}
