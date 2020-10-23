using System;
using System.Windows;
using System.Windows.Controls;

namespace TMS
{
    /// \class RateFeeTable
    /// 
    /// \brief This Page allows the user to navigate between updating the Customer 
    /// and OSHT Rate/Fee table(s)
    /// 
    /// This class contains event handlers that navigate between the RateFeeCustSelect.xaml
    /// and RateFeeOSHTUpdt.xaml pages.
    ///
    public partial class RateFeeTable : Page
    {
        ///
        /// \brief Constructor for the RateFeeTable page
        /// 
        /// \details <b>Details</b>
        /// The only purpose of this constructor is to load the RateFeeTable page.
        ///
        /// \param none - This method has no parameters.
        /// 
        /// \return <b>none</b> - This method is a constructor and therefore doesn't return anything.
        /// 
        public RateFeeTable()
        {
            InitializeComponent();
        }


        ///
        /// \brief Event handler for the "Update Customer Rate/Fee" button
        /// 
        /// \details <b>Details</b>
        /// This event handler navigates to the RateFeeCustSelect.xaml page.
        ///
        /// \param sender - <b>object</b> - The object that triggered the event
        /// \param e - <b>RoutedEventArgs</b> - The arguments that were passed to the event
        /// 
        /// \return <b>none</b> - This method doesn't return anything.
        /// 
        private void SelectUpdateCustRate_Click(object sender, RoutedEventArgs e)
        {
            // go to the customer selection page
            this.NavigationService.Navigate(new Uri("Admin\\RateFeeCustSelect.xaml", UriKind.Relative));
        }


        ///
        /// \brief Event handler for the "Update OSHT Rate/Fee" button
        /// 
        /// \details <b>Details</b>
        /// This event handler navigates to the RateFeeOSHTUpdt.xaml page.
        ///
        /// \param sender - <b>object</b> - The object that triggered the event
        /// \param e - <b>RoutedEventArgs</b> - The arguments that were passed to the event
        /// 
        /// \return <b>none</b> - This method doesn't return anything.
        /// 
        private void SelectUpdateOSHTRate_Click(object sender, RoutedEventArgs e)
        {
            //go to the OSHT update rate fee page
            this.NavigationService.Navigate(new Uri("Admin\\RateFeeOSHTUpdt.xaml", UriKind.Relative));
        }
    }
}
