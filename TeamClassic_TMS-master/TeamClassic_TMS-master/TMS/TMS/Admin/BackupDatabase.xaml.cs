using System;
using System.Windows;
using System.Windows.Controls;
using MySql.Data.MySqlClient;

namespace TMS
{
    public partial class BackupDatabase : Page
    {
        public BackupDatabase()
        {
            InitializeComponent();

            string backUpLogDateDisplay = DateTime.Now.ToString();
            backUpLogDateDisplay = backUpLogDateDisplay.Replace(" ", "");
            backUpLogDateDisplay = backUpLogDateDisplay.Replace(":", "_");
            backUpLogDateDisplay = backUpLogDateDisplay.Insert(10, "-");
            backUpLogDateDisplay = backUpLogDateDisplay.Insert(19, "-");

            //Display carrier based on carrier ID from previous page, command.
            string getBackUpDirectory = "SELECT * FROM BackUpFileInformation";

            //Setup connection string
            MySqlConnection connectToDatabase = new MySql.Data.MySqlClient.MySqlConnection("host=127.0.0.1;user=root;password=Conestoga1;database=tms;");

            //Connect to database
            connectToDatabase.Open();

            //Setup query into mysql command
            MySqlCommand BackUpFile = new MySqlCommand(getBackUpDirectory, connectToDatabase);

            //Start reading database
            MySqlDataReader reader = BackUpFile.ExecuteReader();
            try
            {
                //Read the information in the database and display in textboxes
                while (reader.Read())
                {
                    var backUpFileName = reader.GetString("BackUpFileName");
                    var backUpDirectory = reader.GetString("BackUpDirectory");
                    BackupName.Text = backUpLogDateDisplay + "-" + backUpFileName;
                    BackupDirectory.Items.Add(backUpDirectory);
                }
            }
            catch (MySqlException backupDB_e)
            {
                Logger.Log("Error occurred initiating the BackupDatabase page.", backupDB_e.Message);
            }
            finally
            {
                // Always call Close when done reading.
                reader.Close();
            }

            connectToDatabase.Close();

        }

        private void Click_BackupDatabase(object sender, RoutedEventArgs e)
        {
            if (BackupDirectory.SelectedItem != null)
            {
                //get the contents from the form on the page
                string backUpFileName = BackupName.Text;
                string DateAndTime = DateTime.Now.ToString();

                string backUpPath = BackupDirectory.SelectedItem.ToString();
                string backUpDescription = BackupDescr.Text;
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();

                //Dump Database info to a backup file 
                startInfo.WorkingDirectory = "C:/Program Files/MySQL/MySQL Server 8.0/bin/";
                startInfo.FileName = "mysqldump.exe";
                startInfo.Arguments = "/C mysqldump -uroot -pConestoga1 --routines --triggers --result-file=" + backUpPath + "/" + backUpFileName + " " + "TMS";
                process.StartInfo = startInfo;
                process.Start();

                //Adding Back Up Entry to Database BackUpLogs
                string getBackUpDirectory = "INSERT INTO BackUpFileLog (BackUpDirectory, BackUpFileName, BackUpDescription, BackUpDate, AdminID) VALUES " +
                                            "(@BackUpDirectory, @BackUpFileName, @BackUpDescription, @BackUpDate, @AdminID)";

                //Setup connection string
                try
                {
                    //Connect to database
                    MySqlConnection connectToDatabase = new MySql.Data.MySqlClient.MySqlConnection("host=127.0.0.1;user=root;password=Conestoga1;database=tms;");
                    connectToDatabase.Open();

                    //Setup query into mysql command
                    MySqlCommand BackUpFile = new MySqlCommand(getBackUpDirectory, connectToDatabase);
                    BackUpFile.Parameters.Add("@BackUpDirectory", MySqlDbType.String).Value = backUpPath;
                    BackUpFile.Parameters.Add("@BackUpFileName", MySqlDbType.String).Value = backUpFileName;
                    BackUpFile.Parameters.Add("@BackUpDescription", MySqlDbType.String).Value = backUpDescription;
                    BackUpFile.Parameters.Add("@BackUpDate", MySqlDbType.String).Value = DateAndTime;
                    BackUpFile.Parameters.Add("@AdminID", MySqlDbType.Int32).Value = 1;

                    // Execute the query
                    BackUpFile.ExecuteNonQuery();     

                    // Disconnect from the database
                    connectToDatabase.Close();

                    // Display a success message and then refresh the page
                    Messenger.DisplayMessage("Database backed up successfully!", "Admin");
                    this.NavigationService.Refresh();

                }
                catch (MySqlException backupDB_e)
                {
                    Logger.Log("An error occurred while attempting execute the query to backup the TMS database.", backupDB_e.Message);
                }
            }
            else
            {
                Messenger.DisplayMessage("You must select a Backup Directory.");
            }
        }
    }
}
