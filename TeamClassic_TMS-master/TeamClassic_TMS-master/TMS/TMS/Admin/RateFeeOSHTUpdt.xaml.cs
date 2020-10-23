using System;
using System.Windows;
using System.Windows.Controls;
using MySql.Data.MySqlClient;

namespace TMS
{
    /// <summary>
    /// Interaction logic for RateFeeOSHTUpdt.xaml
    /// </summary>
    public partial class RateFeeOSHTUpdt : Page
    {
        public RateFeeOSHTUpdt()
        {
            InitializeComponent();

            // Get the FTL and LTL rates from the OSHT part of the database
            // Display carrier based on carrier ID from previous page, query.
            string displayCarrier = "SELECT * FROM RateFee LIMIT 1";

            MySqlConnection connectToDatabase = new MySql.Data.MySqlClient.MySqlConnection("host=127.0.0.1;user=root;password=Conestoga1;database=tms;");
            connectToDatabase.Open();

            MySqlCommand displayTheCarrier = new MySqlCommand(displayCarrier, connectToDatabase);
            MySqlDataReader reader = displayTheCarrier.ExecuteReader();

            try
            {
                //Read the information in the database and display in textboxes
                while (reader.Read())
                {
                    // Read columns in database row by row
                    var fTLRate = reader.GetString("FTLMarkup");
                    var lTLRate = reader.GetString("LTLMarkup");

                    FTLRate.Text = fTLRate;
                    LTLRate.Text = lTLRate;
                }
            }
            catch (MySqlException oshtUpdate_e)
            {
                Logger.Log("An error occurred while loading the current OSHT Rate/Fee table.", oshtUpdate_e.Message);
            }
            finally
            {
                // Always call Close when done reading.
                reader.Close();
            }

            connectToDatabase.Close();
        }


        private void Click_UpdateRateFee(object sender, RoutedEventArgs e)
        {            
            // Query to update carrier in CarrierData table
            string updateCarrierRates = "UPDATE RateFee SET FTLMarkup = @FTLMarkup, LTLMarkup = @LTLMarkup;";

            try
            {
                //Setup connection string and connect to database
                MySqlConnection connectToDatabase = new MySql.Data.MySqlClient.MySqlConnection("host=127.0.0.1;user=root;password=Conestoga1;database=tms;");
                connectToDatabase.Open();

                //Add values to the query            
                MySqlCommand updateRates = new MySqlCommand(updateCarrierRates, connectToDatabase);
                updateRates.Parameters.Add("@FTLMarkup", MySqlDbType.Double).Value = FTLRate.Text;
                updateRates.Parameters.Add("@LTLMarkup", MySqlDbType.Double).Value = LTLRate.Text;

                // Execute Query
                updateRates.ExecuteNonQuery();

                // Disconnect from database
                connectToDatabase.Close();
            }
            catch (MySqlException updateOSHTRateFee_e)
            {
                Logger.Log("An error occurred while updating the OSHT Rate/Fee table.", updateOSHTRateFee_e.Message);
            }

            // Go to the main rate fee table page if successful
            this.NavigationService.Navigate(new Uri("Admin\\RateFeeTable.xaml", UriKind.Relative));
        }
    }
}
