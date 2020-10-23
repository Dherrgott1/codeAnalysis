using System.Windows;
using System.Windows.Controls;

namespace TMS
{
    /// \class UIManager
    /// 
    /// \brief Provides methods that are used to create the User Interface for TMS
    /// 
    /// This class provides methods that can be used to create parts of the User Interface 
    /// for TMS. Methods are provided for creating each main page (AdminPage, BuyerPage,
    /// and PlannerPage): CreateAdminPage(), CreateBuyerPage(), and CreatePlannerPage().
    /// There are also methods to navigate between the main pages: SelectRolePage(), ChangeToAdminPage(),
    /// ChangeToBuyerPage(), and ChangeToPlannerPage().
    ///
    public class UIManager
    {
        // Constants
        public static int kAdmin_TitleIndex = 0;
        public static int kBuyer_TitleIndex = 1;
        public static int kPlanner_TitleIndex = 2;
        public static int kRoleSelection_TitleIndex = 3;
        public static readonly string[] WindowTitleList = //!< A list of valid Window Titles
        {
            "Admin",
            "Buyer",
            "Planner",
            "Role Selection"
        };


        private MainWindow appWindow_m; //!< The MainWindow of the application
        private Frame displayFrame_m; //!< The frame being used to change Pages


        ///
        /// \brief Constructor for the UIManager class
        /// 
        /// \details <b>Details</b>
        /// The constructor for the UIManager class takes the 
        /// MainWindow object that the UIManager class is interacting with.
        /// The parameter 'Frame newDisplayFrame' is the Frame that all
        /// main pages are displayed in. Main pages include: RolePage, AdminPage,
        /// BuyerPage, and PlannerPage.
        ///
        /// \param newAppWindow - <b>MainWindow</b> - The MainWindow instance for the program
        /// \param newDisplayFrame - <b>Frame</b> - The Frame that all main pages are being displayed in
        /// 
        /// \return This method is a constructor and therefore doesn't return anything
        /// 
        public UIManager(MainWindow newAppWindow, Frame newDisplayFrame)
        {
            // Assign all parameters to their corresponding data member
            appWindow_m = newAppWindow;
            displayFrame_m = newDisplayFrame; 
        }


        ///
        /// \brief This method is the accessor/mutator for <i>Frame \ref displayFrame_m</i>.
        /// 
        /// \details <b>Details</b>
        /// This method is the accessor/mutator for the <i>Frame \ref displayFrame_m</i>
        /// data member. It allows getting the value of <i>Frame \ref displayFrame_m</i>,
        /// and setting the value of <i>Frame \ref displayFrame_m</i>.
        ///
        /// \param value - <b>Frame</b> - The value that's being set to <i>Frame \ref displayFrame_m</i>.
        /// 
        /// \return displayFrame_m - <b>Frame</b> - The value of <i>Frame \ref displayFrame_m</i>.
        ///
        public Frame DisplayFrame_m
        {
            get { return displayFrame_m; }

            set
            {
                displayFrame_m = value;
            }
        }


        ///
        /// \brief This method is the accessor/mutator for <i>MainWindow \ref appWindow_m</i>.
        /// 
        /// \details <b>Details</b>
        /// This method is the accessor/mutator for the <i>MainWindow \ref appWindow_m</i>
        /// data member. It allows getting the value of <i>MainWindow \ref appWindow_m</i>,
        /// and setting the value of <i>MainWindow \ref appWindow_m</i>.
        ///
        /// \param value - <b>MainWindow</b> - The value that's being set to <i>MainWindow \ref appWindow_m</i>.
        /// 
        /// \return appWindow_m - <b>MainWindow</b> - The value of <i>MainWindow \ref appWindow_m</i>.
        ///
        public MainWindow AppWindow_m
        {
            get { return appWindow_m; }

            set
            {
                appWindow_m = value;
            }
        }


        ///
        /// \brief Changes to <i>Frame \ref displayFrame_m</i> to display RolePage.xaml
        /// 
        /// \details <b>Details</b>
        /// This method can be called to change to the SelectRole.xaml page.
        /// The SelectRole.xaml page will be displayed within <i>Frame \ref displayFrame_m</i>
        /// and the MainWindow Title will be changed to "Role Selection".
        ///
        /// \param none - This method has no parameters.
        /// 
        /// \return <b>void</b> - This method doesn't return anything.
        /// 
        public void SelectRolePage()
        {
            DisplayFrame_m.Content = new RolePage(this);
            SetWindowTitle("Role Selection");
        }


        ///
        /// \brief Changes to <i>Frame \ref displayFrame_m</i> to display AdminPage.xaml
        /// 
        /// \details <b>Details</b>
        /// This method can be called to change to the AdminPage.xaml page.
        /// The AdminPage.xaml page will be displayed within <i>Frame \ref displayFrame_m</i>
        /// and the MainWindow Title will be changed to "Admin".
        ///
        /// \param none - This method has no parameters.
        /// 
        /// \return <b>void</b> - This method doesn't return anything.
        /// 
        public void ChangeToAdminPage()
        {
            DisplayFrame_m.Content = new AdminPage(this);
            SetWindowTitle("Admin");
        }


        ///
        /// \brief Changes to <i>Frame \ref displayFrame_m</i> to display BuyerPage.xaml
        /// 
        /// \details <b>Details</b>
        /// This method can be called to change to the BuyerPage.xaml page.
        /// The BuyerPage.xaml page will be displayed within <i>Frame \ref displayFrame_m</i>
        /// and the MainWindow Title will be changed to "Buyer".
        ///
        /// \param none - This method has no parameters.
        /// 
        /// \return <b>void</b> - This method doesn't return anything.
        /// 
        public void ChangeToBuyerPage()
        {
            DisplayFrame_m.Content = new BuyerPage(this);
            SetWindowTitle("Buyer");
        }


        ///
        /// \brief Changes to <i>Frame \ref displayFrame_m</i> to display PlannerPage.xaml
        /// 
        /// \details <b>Details</b>
        /// This method can be called to change to the PlannerPage.xaml page.
        /// The PlannerPage.xaml page will be displayed within <i>Frame \ref displayFrame_m</i>
        /// and the MainWindow Title will be changed to "Planner".
        ///
        /// \param none - This method has no parameters.
        /// 
        /// \return <b>void</b> - This method doesn't return anything.
        /// 
        public void ChangeToPlannerPage()
        {
            DisplayFrame_m.Content = new PlannerPage(this);
            SetWindowTitle("Planner");
        }


        ///
        /// \brief Changes the title of the <i>MainWindow \ref appWindow_m</i>
        /// 
        /// \details <b>Details</b>
        /// This method can be used to change the Title of the MainWindow
        /// object that's been assigned to <i>MainWindow \ref appWindow_m</i>. Validation
        /// is performed on the Title before assigning it the to MainWindow.
        /// The list of valid Titles is stored in <i>readonly string[] \ref WindowTitleList</i>.
        ///
        /// \param windowTitle - <b>string</b> - The new title for the Window
        /// 
        /// \return titleStatus - <b>bool</b> - true if the Title was changed and false if it wasn't 
        /// 
        public bool SetWindowTitle(string windowTitle)
        {
            bool titleStatus = false; // Whether the Title was changed successfully

            // Check whether the Title is valid before assigning it
            if (ValidateWindowTitle(windowTitle) == true)
            {
                AppWindow_m.Title = windowTitle; // Assign the new Title
            }

            return titleStatus;
        }


        ///
        /// \brief Checks whether a Window Title is valid
        /// 
        /// \details <b>Details</b>
        /// This method loops through all valid Window Titles stored in 
        /// <i>readonly string[] \ref WindowTitleList</i> and checks if it matches
        /// the Title specifed by 'string newTitle'.
        ///
        /// \param newTitle - <b>string</b> - The Title that's being checked 
        /// 
        /// \return titleStatus - <b>bool</b> - true if the Title is valid and false if it isn't
        /// 
        public bool ValidateWindowTitle(string newTitle)
        {
            bool titleStatus = false;

            // Loop checking the list of valid window titles
            foreach (string title in WindowTitleList)
            {
                // If the newTitle matches a WindowTitleList item, the newTitle is valid
                if (title == newTitle)
                {
                    titleStatus = true;
                }
            }

            return titleStatus;
        }


        ///
        /// \brief Creates a button with predefined properties to be used in the StackPanel
        /// 
        /// \details 
        /// This method creates a button with predefined properties for the StackPanel.
        /// The Content is specified by <i>string btnContent</i>. All other 
        /// attributes are the same. The Click event handler is not assigned in this
        /// function; this must be assigned to the Button that's returned.
        /// 
        /// \param btnContent - <b>string</b> - The Content property of the Button
        /// 
        /// \return newButton - <b>Button</b> - The Button that was created
        /// 
        public Button CreatePanelButton(string btnContent)
        {
            Button newButton = new Button();

            newButton.Name = RemoveWhitespace(btnContent);
            newButton.Content = btnContent;
            newButton.FontSize = 12;

            newButton.Height = 40;
            newButton.Width = 150;

            newButton.HorizontalAlignment = HorizontalAlignment.Left;
            newButton.VerticalAlignment = VerticalAlignment.Top;

            Thickness margin = newButton.Margin;
            margin.Left = 40;
            margin.Right = 0;
            margin.Top = 0;
            margin.Bottom = 15;
            newButton.Margin = margin;

            return newButton;
        }


        ///
        /// \brief Removes all whitespace from a string.
        /// 
        /// \details <b>Details</b>
        /// The method removes all whitespace from the string specified
        /// by <i>string str</i>. The string without whitespace is then returned.
        ///
        /// \param str - <b>string</b> - The string that's having its whitespace removed
        /// 
        /// \return newStr - <b>string</b> - The new string that was created that doesn't have
        ///     whitespace.
        /// 
        private string RemoveWhitespace(string str)
        {
            string newStr = "";

            foreach (char character in str)
            {
                if (character != ' ')
                {
                    newStr += character;
                }
            }

            return newStr;
        }


        ///
        /// \brief Adds Buttons to the StackPanel that's in AdminPage.xaml
        /// 
        /// \details <b>Details</b>
        /// This method creates and then adds Buttons to the StackPanel
        /// for the AdminPage.
        ///
        /// \param page - <b>AdminPage</b> - The AdminPage that contains all 
        ///     event handlers for the Admin buttons.
        /// \param panel - <b>StackPanel</b> - The StackPanel that the Buttons 
        ///     are being displayed in.
        /// 
        /// \return <b>void</b> - This method doesn't return anything.
        /// 
        public void CreateAdminPage(AdminPage page, StackPanel panel)
        {
            // Create the buttons
            Button selectRoleBtn = CreatePanelButton("Select Role");

            Thickness margin = selectRoleBtn.Margin;
            margin.Top = 15;
            selectRoleBtn.Margin = margin;

            selectRoleBtn.Click += page.SelectRole_Click;

            Button genConfigBtn = CreatePanelButton("Config Settings");
            genConfigBtn.Click += page.SelectConfigSetting_Click;

            Button viewLogFileBtn = CreatePanelButton("View Log Files");
            viewLogFileBtn.Click += page.SelectViewLogFile_Click;

            Button rateFeeBtn = CreatePanelButton("Rate Fee Table");
            rateFeeBtn.Click += page.SelectRateFeeTable_Click;

            Button carrierDataBtn = CreatePanelButton("Carrier Data");
            carrierDataBtn.Click += page.SelectCarrierData_Click;

            Button routeTableBtn = CreatePanelButton("Route Table");
            routeTableBtn.Click += page.SelectRouteTable_Click;

            Button backupDbBtn = CreatePanelButton("Backup Database");
            backupDbBtn.Click += page.SelectBackupDb_Click;          

            // Add the buttons to the StackPanel
            panel.Children.Add(selectRoleBtn);
            panel.Children.Add(genConfigBtn);
            panel.Children.Add(viewLogFileBtn);
            panel.Children.Add(rateFeeBtn);
            panel.Children.Add(carrierDataBtn);
            panel.Children.Add(routeTableBtn);
            panel.Children.Add(backupDbBtn);
        }


        ///
        /// \brief Adds Buttons to the StackPanel that's in BuyerPage.xaml
        /// 
        /// \details <b>Details</b>
        /// This method creates and then adds Buttons to the StackPanel
        /// for the BuyerPage.
        ///
        /// \param page - <b>BuyerPage</b> - The BuyerPage that contains all 
        ///     event handlers for the Buyer buttons.
        /// \param panel - <b>StackPanel</b> - The StackPanel that the Buttons 
        ///     are being displayed in.
        /// 
        /// \return <b>void</b> - This method doesn't return anything.
        /// 
        public void CreateBuyerPage(BuyerPage page, StackPanel panel)
        {
            // Create the buttons
            Button selectRoleBtn = CreatePanelButton("Select Role");

            Thickness margin = selectRoleBtn.Margin;
            margin.Top = 15;
            selectRoleBtn.Margin = margin;

            selectRoleBtn.Click += page.SelectRole_Click;

            Button viewCustomersBtn = CreatePanelButton("View Customers");
            viewCustomersBtn.Click += page.SelectViewCustomers_Click;

            Button contractMktplcBtn = CreatePanelButton("Contract Marketplace");
            contractMktplcBtn.Click += page.SelectContractMktplc_Click;

            Button reviewOrderBtn = CreatePanelButton("Review Order");
            reviewOrderBtn.Click += page.SelectReviewOrder_Click;

            // Add the buttons to the StackPanel
            panel.Children.Add(selectRoleBtn);
            panel.Children.Add(viewCustomersBtn);
            panel.Children.Add(contractMktplcBtn);
            panel.Children.Add(reviewOrderBtn);
        }


        ///
        /// \brief Adds Buttons to the StackPanel that's in PlannerPage.xaml
        /// 
        /// \details <b>Details</b>
        /// This method creates and then adds Buttons to the StackPanel
        /// for the PlannerPage.
        ///
        /// \param page - <b>PlannerPage</b> - The PlannerPage that contains all 
        ///     event handlers for the Planner buttons.
        /// \param panel - <b>StackPanel</b> - The StackPanel that the Buttons 
        ///     are being displayed in.
        /// 
        /// \return <b>void</b> - This method doesn't return anything.
        /// 
        public void CreatePlannerPage(PlannerPage page, StackPanel panel)
        {
            // Create the buttons
            Button selectRoleBtn = CreatePanelButton("Select Role");

            Thickness margin = selectRoleBtn.Margin;
            margin.Top = 15;
            selectRoleBtn.Margin = margin;
            selectRoleBtn.Click += page.SelectRole_Click;

            Button receivedOrderBtn = CreatePanelButton("Received Orders");
            receivedOrderBtn.Click += page.SelectReceivedOrders_Click;

            Button orderSummaryBtn = CreatePanelButton("Orders Summary");
            orderSummaryBtn.Click += page.SelectOrderSummary_Click;

            Button invoiceSummaryBtn = CreatePanelButton("Invoice Summary");
            invoiceSummaryBtn.Click += page.SelectInvoiceSummary_Click;

            Button closeDayBtn = CreatePanelButton("Close Day");
            closeDayBtn.Click += page.SelectCloseDay_Click;

            // Add the buttons to the StackPanel
            panel.Children.Add(selectRoleBtn);
            panel.Children.Add(receivedOrderBtn);
            panel.Children.Add(orderSummaryBtn);
            panel.Children.Add(invoiceSummaryBtn);
            panel.Children.Add(closeDayBtn);
        }
    }
}
