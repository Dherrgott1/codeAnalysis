using System.Windows;

namespace TMS
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Initialize the DAL (Data Access Layer) class
            DAL.Initialize();

            // Get the directory that the log files are being saved in
            Logger.GetLogDirectory();          

            // Create the UIManager (this is only done once) and go to the Select Role page
            UIManager uiManager_m = new UIManager(this, PageDisplayFrame);
            uiManager_m.SelectRolePage();
        }
    }
}
