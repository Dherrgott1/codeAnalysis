using System;
using System.Windows;
using System.Windows.Controls;
using MySql.Data.MySqlClient;

namespace TMS
{
    public partial class RateFeeCustUpdt : Page
    {
        private RateFee selectedCarrierTemp; //!< The Carrier that was selected


        // Constructor which loads the RateFeeCustUpdt page
        public RateFeeCustUpdt()
        {
            InitializeComponent();
        }


        // Constructor which loads information from the previous page
        public RateFeeCustUpdt(RateFee carrier) : this()
        {
            // Load all of the information from selected carrier from last page into the form elements
            selectedCarrierTemp = carrier;
            this.Loaded += new RoutedEventHandler(CarrierDataUpdate_Loaded);
        }



        private void CarrierDataUpdate_Loaded(object sender, RoutedEventArgs e)
        {
            // Get contents from the last page
            RateFee selectedCarrier = selectedCarrierTemp;
                        
            CarrierName.Text = selectedCarrier.CarrierName;
            FTLRate.Text = Convert.ToString(selectedCarrier.FTLRate);
            LTLRate.Text = Convert.ToString(selectedCarrier.LTLRate);
            ReeferCharge.Text = Convert.ToString(selectedCarrier.ReeferCharge);

        }



        private void Click_UpdateRateFee(object sender, RoutedEventArgs e)
        {
            // Query to update carrier in CarrierData table
            string updateCarrierRates = "UPDATE CarrierData SET FTLRate = @FTLRate, LTLRate = @LTLRate, ReeferCharge = @ReeferCharge WHERE CarrierName = @CarrierName";

            try
            {
                //Setup connection string
                MySqlConnection connectToDatabase = new MySql.Data.MySqlClient.MySqlConnection("host=127.0.0.1;user=root;password=Conestoga1;database=tms;");

                //Connect to database
                connectToDatabase.Open();

                MySqlCommand updateRates = new MySqlCommand(updateCarrierRates, connectToDatabase);

                //Add values to the query from the form
                updateRates.Parameters.Add("@CarrierName", MySqlDbType.MediumText).Value = CarrierName.Text;
                updateRates.Parameters.Add("@FTLRate", MySqlDbType.Double).Value = FTLRate.Text;
                updateRates.Parameters.Add("@LTLRate", MySqlDbType.Double).Value = LTLRate.Text;
                updateRates.Parameters.Add("@ReeferCharge", MySqlDbType.Double).Value = ReeferCharge.Text;

                //Execute Query
                updateRates.ExecuteNonQuery();

                //Disconnect from database
                connectToDatabase.Close();
            }
            catch (MySqlException updateRateFee_e)
            {
                Logger.Log("An error occurred while updating a Carrier Rate/Fee table.", updateRateFee_e.Message);
            }

            // go to the main rate fee table page if successful
            this.NavigationService.Navigate(new Uri("Admin\\RateFeeTable.xaml", UriKind.Relative));
        }
    }
}
