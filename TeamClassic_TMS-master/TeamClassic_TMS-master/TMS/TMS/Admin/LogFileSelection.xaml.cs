using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using System;

namespace TMS
{
    public partial class LogFileSelection : Page
    {
        List<string> logFileList;

        public LogFileSelection()
        {
            InitializeComponent();

            logFileList = Logger.GetLogList();

            // Load all logs into the ListBox
            foreach (string log in logFileList)
            {
                LogFileListBox.Items.Add(log);
            }      
        }

        private void Click_SelectLogFile(object sender, RoutedEventArgs e)
        {           
            if (LogFileListBox.SelectedItem != null)
            {
                //Get string from selected item in list box
                string selectedLogFile = LogFileListBox.SelectedItem.ToString();

                try
                {
                    // Read the contents of the log file   
                    string logFileText = Logger.ReadAllLog(Logger.LogPath_m + "\\" + selectedLogFile);

                    // Send the log file contents and go to the ViewLogFile pages
                    ViewLogFile timeToView = new ViewLogFile(logFileText);
                    this.NavigationService.Navigate(timeToView);
                }
                catch (Exception readLog_e)
                {
                    Logger.Log("An error occured while reading from a log file.", readLog_e.Message);
                }
            }
        }
    }
}
