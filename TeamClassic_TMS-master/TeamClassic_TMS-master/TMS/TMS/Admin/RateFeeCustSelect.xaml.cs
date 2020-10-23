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
    /// Interaction logic for RateFeeCustSelect.xaml
    /// </summary>
    public partial class RateFeeCustSelect : Page
    {
        List<RateFee> rates;

        public RateFeeCustSelect()
        {
            InitializeComponent();

            rates = new List<RateFee>();
            //get all of the customer rate fee information and print it into the RateFee_DataGrid table using RateFee class

            //Display carrier based on carrier ID from previous page, query.
            string displayCarrier = "SELECT DISTINCT CarrierName, FTLRate, LTLRate, ReeferCharge FROM CarrierData";


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
                   
                    var theCarrierName = reader.GetString("CarrierName"); 
                    var ftLRate = reader.GetDouble("FTLRate");
                    var ltLRate = reader.GetDouble("LTLRate");
                    var reefer = reader.GetDouble("ReeferCharge");

                    rates.Add(new RateFee() { CarrierName = theCarrierName, FTLRate = ftLRate, LTLRate = ltLRate, ReeferCharge = reefer });

                    RateFee_DataGrid.ItemsSource = rates;
                }
            }
            catch (MySqlException updateCustRateFee_e)
            {
                Logger.Log("Error loading the RateFeeCustSelect.xaml page.", updateCustRateFee_e.Message);
            }
            finally
            {
                // Always call Close when done reading.
                reader.Close();
            }

            
            //get the number of carriers
            int numberOfCarriers = rates.Count;

            //load the carrier name into the RateFee_ComboB
            for (int i = 0; i < numberOfCarriers; i++)
            {
                RateFee_ComboB.Items.Add(rates[i].CarrierName);
            }
        }

        private void SelectUpdateRate_Click(object sender, RoutedEventArgs e)
        {
            //get the carrier chosen in the CarrierData_ComboB
            string selectedCarrier = RateFee_ComboB.SelectedItem.ToString();           

            //get all of the info for this carrier from the list to send to the next page
            var Carrier = rates.Find(i => i.CarrierName == selectedCarrier);

            if (Carrier == null)
            {
                // go to the update carrier page
                this.NavigationService.Navigate(new Uri("Admin\\CarrierDataMain.xaml", UriKind.Relative));
            }
            else
            {
                RateFeeCustUpdt newPage = new RateFeeCustUpdt(Carrier);
                this.NavigationService.Navigate(newPage);

            }          
        }
    }
}
