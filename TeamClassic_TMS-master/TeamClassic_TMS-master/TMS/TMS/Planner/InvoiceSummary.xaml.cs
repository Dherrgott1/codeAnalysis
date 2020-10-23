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

namespace TMS
{
    /// <summary>
    /// Interaction logic for InvoiceSummary.xaml
    /// </summary>
    public partial class InvoiceSummary : Page
    {
        public InvoiceSummary()
        {
            InitializeComponent();
        }

        private void Click_AllTime(object sender, RoutedEventArgs e)
        {
            // Get the Invoice info from every file in invoice folder

            //load all of the info into the table
        }

        private void Click_Past2Weeks(object sender, RoutedEventArgs e)
        {

        }
    }
}
