using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS
{
    /// \class Order
    ///
    /// \brief This class models orders within the TMS.
    /// 
    /// The purpose of this class is the model orders within the
    /// TMS. Orders are created using this class. A list of all 
    /// possible destinations cities are provided through 
    /// <i>string[] \ref destinationCities</i>, which can be used 
    /// to display all relevant cities. 
    ///
    class Order
    {
        /****************************************************************/
        /*                         Private members                      */
        /****************************************************************/
        private bool completionStatus_m; //!< Indicates whether the Order is complete
        private string[] allStops_m; //!< Indicates all stops that need to be made to complete the Order
        private string departingCity_m; //!< The city that the Order is leaving from
        private string destinationCity_m; //!< Indicates the final destination for the Order


        /****************************************************************/
        /*                         Public members                       */
        /****************************************************************/
        public readonly string[] destinationCities = //!< Contains a list of all destination cities 
        {
            "Windsor",
            "London",
            "Hamilton",
            "Toronto",
            "Oshawa",
            "Belleville",
            "Kingston",
            "Ottawa"
        };


        ///
        /// \brief This method is the constructor for the Order class
        /// 
        /// \details <b>Details</b>
        /// This method is the constructor for the Order class. It takes no parameters.
        /// It's purpose is to initialize <i>bool \ref completionStatus_m</i> to false,
        /// which indicates that the Order is not complete.
        ///
        /// \param none - This method has no parameters.
        /// 
        /// \return This method is a constructor, therefore it doesn't return anything
        ///
        public Order()
        {
            this.completionStatus_m = false; // Indicate the Order is not complete

            allStops_m = null;
            departingCity_m = null;
            destinationCity_m = null;
        }


        ///
        /// \brief This method is the accessor/mutator for <i>bool \ref completionStatus_m</i>.
        /// 
        /// \details <b>Details</b>
        /// This method is the accessor/mutator for the <i>bool \ref completionStatus_m</i>
        /// data member. It allows getting the value of <i>bool \ref completionStatus_m</i>,
        /// and setting the value of <i>bool \ref completionStatus_m</i>.
        ///
        /// \param value - <b>bool</b> - The value that's being set to <i>bool \ref completionStatus_m</i>.
        /// 
        /// \return completionStatus_m - <b>bool</b> - The value of <i>bool \ref completionStatus_m</i>.
        ///
        public bool CompletionStatus_m
        {
            get { return this.completionStatus_m; }

            set
            {
                this.completionStatus_m = value;
            }
        }


        ///
        /// \brief This method is the accessor/mutator for <i>string[] \ref allStops_m</i>.
        /// 
        /// \details <b>Details</b>
        /// This method is the accessor/mutator for the <i>string[] \ref allStops_m</i>
        /// data member. It allows getting the value of <i>string[] \ref allStops_m</i>,
        /// and setting the value of <i>string[] \ref allStops_m</i>.
        ///
        /// \param value - <b>bool</b> - The value that's being set to <i>string[] \ref allStops_m</i>.
        /// 
        /// \return completetionStatus_m - <b>bool</b> - The value of <i>string[] \ref allStops_m</i>.
        ///
        public string[] AllStops_m
        {
            get { return this.allStops_m; }

            set
            {
                this.allStops_m = value;
            }
        }


        ///
        /// \brief This method is the accessor/mutator for <i>string \ref departingCity_m</i>.
        /// 
        /// \details <b>Details</b>
        /// This method is the accessor/mutator for the <i>string \ref departingCity_m</i>
        /// data member. It allows getting the value of <i>string \ref departingCity_m</i>,
        /// and setting the value of <i>string \ref departingCity_m</i>.
        ///
        /// \param value - <b>bool</b> - The value that's being set to <i>string \ref departingCity_m</i>.
        /// 
        /// \return completetionStatus_m - <b>bool</b> - The value of <i>string \ref departingCity_m</i>.
        ///
        public string DepartingCity_m
        {
            get { return this.departingCity_m; }

            set
            {
                this.departingCity_m = value;
            }
        }


        ///
        /// \brief This method is the accessor/mutator for <i>string \ref destinationCity_m</i>.
        /// 
        /// \details <b>Details</b>
        ///     This method is the accessor/mutator for the <i>string \ref destinationCity_m</i>
        ///     data member. It allows getting the value of <i>string \ref destinationCity_m</i>,
        ///     and setting the value of <i>string \ref destinationCity_m</i>.
        ///
        /// \param value - <b>bool</b> - The value that's being set to <i>string \ref destinationCity_m</i>.
        /// 
        /// \return completetionStatus_m - <b>bool</b> - The value of <i>string \ref destinationCity_m</i>.
        ///
        public string DestinationCity_m
        {
            get { return this.destinationCity_m; }

            set
            {
                this.destinationCity_m = value;
            }
        }


        ///
        /// \brief Validates whether <i>string finalDestination</i> is a valid <i>readonly string[] \ref destinationCities</i>
        /// 
        /// \details <b>Details</b>
        ///     Checks whether a city (either a departing city, or a destination city) is a valid city within the TMS system.
        ///     The data member <i>readonly string[] \ref destinationCities</i> is used to check whether the city is valid.
        ///
        /// \param cityName <b>string</b> - The city that's being checked
        /// 
        /// \return validCity - <b>bool</b> - true if <i>string cityName</i> is valid, and false if it isn't
        ///
        public bool ValidateCity(string cityName)
        {
            bool validCity = false;

            return validCity;
        }


        ///
        /// \brief This generates an Order for the TMS.
        /// 
        /// \details <b>Details</b>
        ///     This method generates an Order for the TMS. It takes the final destination
        ///     specified by <i>string finalDestination</i> and departing city specified by
        ///     <i>string departingCity</i>. The stops that are needed for
        ///     the order are found by calling FindStops(). After finding the stops
        ///     the order is complete
        ///
        /// \param departingCity <b>string</b> - The departing city for the Order
        /// \param destinationCity <b>string</b> - The final destination for the Order
        /// 
        /// \return orderStatus - <b>bool</b> - Indicates whether the Order was generated successfully
        ///
        public static void GenerateOrder(string departingCity, string destinationCity)
        {
            // Find the stops that need that need to be made for the order
        }


        ///
        /// \brief Finds all stops that are made for an Order
        /// 
        /// \details <b>Details</b>
        ///     This method finds the stops that are needed to complete an order
        ///     when given a departing city and destination city. The departing city
        ///     is specified by <i>string departingCity</i> and the destination city
        ///     is specified by <i>string destinationCity</i>. The stops are temporarily
        ///     stored in a List<string> inside the function. They are then assigned to
        ///     <i>string[] \ref allStops_m</i>.
        ///
        /// \param departingCity <b>string</b> - The departing city for the Order
        /// \param destinationCity <b>string</b> - The final destination for the Order
        /// 
        /// \return stopStatus - <b>bool</b> - true if the stops were found successfully, 
        ///     and false if they weren't
        ///
        public bool FindStops(string departingCity, string destinationCity)
        {
            bool stopStatus = false;

            // NOTE: This is all test code
            // It tests creating a List<string> of stops and then assigning
            // it to the string[] allStops data member
            List<string> stopTest = new List<string>();

            stopTest.Add("stop_1");            
            stopTest.Add("stop_2");            
            stopTest.Add("stop_3");            
            stopTest.Add("stop_4");            
            stopTest.Add("stop_5");            
            stopTest.Add("stop_6");            
            stopTest.Add("stop_7");

            string[] stops = new string[stopTest.Count];
            int index = 0;
            foreach (string stop in stopTest)
            {
                stops[index] = stop;
                index++;
            }
            AllStops_m = stops;

            return stopStatus;
        }
    }
}
