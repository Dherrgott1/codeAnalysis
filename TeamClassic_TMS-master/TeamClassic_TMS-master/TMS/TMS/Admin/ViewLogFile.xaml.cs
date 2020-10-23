using System.Windows;
using System.Windows.Controls;

namespace TMS
{
    public partial class ViewLogFile : Page
    {
        private string logContents;

        public ViewLogFile(string logText)
        {
            InitializeComponent();
            
            logContents = logText; // Get contents from the last page
            this.Loaded += new RoutedEventHandler(ViewLogFile_Loaded);           
        }

        private void ViewLogFile_Loaded(object sender, RoutedEventArgs e)
        {
            if (logContents != null)
            {
                LogReview_Box.Text = logContents; // Load the log contents into the LogReview_Box textbox
            }
            else
            {
                Logger.Log("A log file could not be read.");
            }
        }
    }
}
