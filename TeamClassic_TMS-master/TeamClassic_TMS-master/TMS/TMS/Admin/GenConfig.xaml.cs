using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TMS
{
    /// \class GenConfig
    /// 
    /// \brief This class is the code-behind page for GenConfig.xaml
    /// It contains event handlers for all buttons that are in the page.
    /// This includes the following buttons: "Select Folder", "Update Directory",
    /// and "Update Connecting Settings".
    ///
    public partial class GenConfig : Page
    {
        ///
        /// \brief Constructor for the GenConfig page.
        /// 
        /// \details <b>Details</b>
        /// This method is the constructor for the GenConfig page. It 
        /// It queries the database for all GenConfig options and then
        /// displays them in TextBoxes that are in GenConfig.xaml.
        ///
        /// \param none - This method has no parameters.
        /// 
        /// \return <b>void</b> - This method doesn't return anything.
        /// 
        public GenConfig()
        {
            InitializeComponent();

            //MySqlCommand displayTheCarrier = new MySqlCommand(genConfigQuery, connectToDatabase).ExecuteReader();

            // Open connection to the TMS database and create the query string
            MySqlConnection connectToDatabase = DAL.OpenDatabaseConnection(DAL.ConnectionString_tms);
            string genConfigQuery = "SELECT * FROM GenConfigOptions";
            // Execute the query
            MySqlDataReader reader = new MySqlCommand(genConfigQuery, connectToDatabase).ExecuteReader();

            try
            {
                //Read the information in the database and display in textboxes
                while (reader.Read())
                {
                    var targettingIPAddress = reader.GetString("TargetIPAddress");
                    var CommPorts = reader.GetString("CommPorts");

                    //LogFileDirectory.Text = logDirectory;
                    LogFileDirectory.Text = Logger.LogPath_m;
                    TargetingIP.Text = targettingIPAddress;
                    TargetingPort.Text = CommPorts;
                }
            }
            catch (MySqlException configLoad_e)
            {
                Logger.Log("An error has occurred while loading General Configuration Options from the TMS database.", configLoad_e.Message);
            }
            finally
            {
                // Always call Close when done reading.
                reader.Close();
            }
        }


        ///
        /// \brief Event handler for the "Select Folder" button
        /// 
        /// \details <b>Details</b>
        /// This method is the event handler for the "Select Folder" button
        /// on the GenConfig.xaml page. It opens a FolderBrowserDialog whichs
        /// lets the user select a folder or make a new one.
        ///
        /// \param sender - <b>object</b> - The object that triggered the event
        /// \param e - <b>RoutedEventArgs</b> - The arguments that were passed to the event
        /// 
        /// \return <b>void</b> - This method doesn't return anything.
        /// 
        private void Click_SelectFolder(object sender, RoutedEventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.ShowDialog();
                if (dialog.SelectedPath != null)
                {
                    LogFileDirectory.Text = dialog.SelectedPath;
                }
            }
        }


        ///
        /// \brief Event handler for the "Update Directory" button
        /// 
        /// \details <b>Details</b>
        /// This method is the event handler for the "Update Directory" button
        /// on the GenConfig.xaml page. It checks whether the path specified in the
        /// 'TextBox LogFileDirectory' is a valid folder path on the user's file system.
        /// If the path is valid, the log file diretory is updated in the TMS database
        ///
        /// \param sender - <b>object</b> - The object that triggered the event
        /// \param e - <b>RoutedEventArgs</b> - The arguments that were passed to the event
        /// 
        /// \return <b>void</b> - This method doesn't return anything.
        /// 
        private void Click_UpdateDirectory(object sender, RoutedEventArgs e)
        {
            // Check if the log file directory is valid and change the directory if it is
            string newDirectory = LogFileDirectory.Text;
            if (FileIO.ValidatePath(newDirectory) == true)
            {
                // Change the log directory location in the database and display a user feedback message
                Logger.ChangeLogDirectory(newDirectory);
                Messenger.DisplayMessage("Log file directory has been changed to: " + newDirectory + ".");
            }
            else
            {
                // Display an error message if the file path is invalid
                Messenger.DisplayMessage("Invalid file path specified.", "Admin");
            }

            // Reload the GenConfig page to show the updated values
            this.NavigationService.Refresh();
        }


        ///
        /// \brief Event handler for the "Update Connection Settings" button
        /// 
        /// \details <b>Details</b>
        /// This method is the event handler for the "Update Connection Settings" button
        /// on the GenConfig.xaml page. It updates the TargetIPAddress and CommPorts in the
        /// TMS database.
        ///
        /// \param sender - <b>object</b> - The object that triggered the event
        /// \param e - <b>RoutedEventArgs</b> - The arguments that were passed to the event
        /// 
        /// \return <b>void</b> - This method doesn't return anything.
        /// 
        private void Click_UpdateConnectSettings(object sender, EventArgs e)
        {
            // Get the incoming strings from the text box
            string newIPAddress = TargetingIP.Text;
            string newCommPort = TargetingPort.Text;           

            //Query to update the GenConfigOptions table in the TMS database
            string updateDirectory = "UPDATE GenConfigOptions SET TargetIPAddress = @TargetIPAddress, CommPorts = @CommPorts";

            try
            {
                MySqlConnection connectToDatabase = DAL.OpenDatabaseConnection(DAL.ConnectionString_tms);

                // Create the command and add values to it
                MySqlCommand insertNewConfigSettings = new MySqlCommand(updateDirectory, connectToDatabase);
                insertNewConfigSettings.Parameters.Add("@TargetIPAddress", MySqlDbType.String).Value = newIPAddress;
                insertNewConfigSettings.Parameters.Add("@CommPorts", MySqlDbType.String).Value = newCommPort;

                // Execute the query
                insertNewConfigSettings.ExecuteNonQuery();

                // Disconnect from database
                connectToDatabase.Close();
            }
            catch (MySqlException updateConnection_e)
            {
                Logger.Log("An error occurred while updating the connection settings in the TMS database.", updateConnection_e.Message);
            }

            // Reload the gen config page to show the updated values
            this.NavigationService.Refresh();
        }
    }
}
