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
    /// Interaction logic for ReviewContract.xaml
    /// </summary>
    public partial class ReviewContract : Page
    {

        Contract selectedContract;

        public ReviewContract()
        {
            InitializeComponent();
        }

        

        public ReviewContract(Contract newContract) : this()
        {
            selectedContract = newContract;
            this.Loaded += new RoutedEventHandler(ViewContract_Loaded);
        }


        private void ViewContract_Loaded(object sender, RoutedEventArgs e)
        {

            //get contents from the last page
            Contract newSelectedContract = selectedContract;

            ClientName.Text = newSelectedContract.ClientName;
            JobType.Text = newSelectedContract.JobType;
            Quantity.Text = newSelectedContract.Quantity;
            Origin.Text = newSelectedContract.Origin;
            Destination.Text = newSelectedContract.Destination;
            VanType.Text = newSelectedContract.VanType;


        }





    }
}
