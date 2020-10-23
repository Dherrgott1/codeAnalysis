//
// FILE			:	Route.cs
// PROJECT		:	SENG2020 - Milestone 3
// PROGRAMMER	:	Julian Lichty
// DESCRIPTION	:	This file contains the DOXegen comment skeleton for the route class
//


//Using Statements
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Enter Namespace
namespace TMS
{
    /// \class Route
    ///
    /// \brief This is a class that is used to hold the Route Information
    ///
    /// The purpose of this class is to store the Route ID, Destination, 
    /// Distance (Kilometers), Time (in Hours), West and East  
    ///
    public class Route
    {
        /****************************************************************/
        /*                        Private members                       */
        /****************************************************************/
        public struct RouteData
        {
            private static int routeID_m;           //!< The Identification code for the specific route
            private static string destination_m;    //!< The final destination of the trip route
            private static int kilometers_m;        //!< The distance of the route measured in kilometers
            private static double timeInHours_m;    //!< The length of the route measured in hours
            private static string west_m;           //!< The distance west
            private static string east_m;           //!< The distance east 


            ///
            /// \brief The constructor for the RouteData struct
            /// 
            ///  
            ///  \details <b>Details</b>    
            ///  This method is the constructor for the RouteData struct. It takes values of all variables
            ///  within the struct.
            ///  
            ///  \param newRouteID_m - <b>int</b> - The value being assigned to <i>int \ref routeID_m</i>
            ///  \param newDestination_m - <b>string</b> - The value being assigned to <i>int \ref destination_m</i>
            ///  \param newKilometers_m - <b>int</b> - The value being assigned to <i>int \ref kilometers_m</i>
            ///  \param newTimeInHours_m - <b>double</b> - The value being assigned to <i>int \ref timeInHours_m</i>
            ///  \param newWest_m - <b>string</b> - The value being assigned to <i>int \ref west_m</i>
            ///  \param newEast_m - <b>string</b> - The value being assigned to <i>int \ref east_m</i>
            ///  
            ///  \return This is a constructor, therefore nothing is returned.
            ///  
            public RouteData(int newRouteID_m, string newDestination_m, int newKilometers_m, double newTimeInHours_m, string newWest_m, string newEast_m)
            {
                routeID_m = newRouteID_m;
                destination_m = newDestination_m;
                kilometers_m = newKilometers_m;
                timeInHours_m = newTimeInHours_m;
                west_m = newWest_m;
                east_m = newEast_m;
            }
        }



        /****************************************************************/
        /*                         Public members                       */
        /****************************************************************/
        ///
        /// \brief This method validates the route information being added into the TMS Database
        /// 
        ///  
        ///  \details <b>Details</b>    
        ///  This method takes the route information that is being added to the system, and validates it. 
        ///  
        ///  \param newRouteData - <b>struct RouteData</b> - Struct containing Route ID, Destination, Kilometers, Time (in Hours), West and East  
        ///  
        ///  \return True / False - <b>bool</b> - Return true if validation is successful, false if failed. 
        ///   
        public bool ValidateRoute(RouteData newRouteData)
        {

            return true;

        }


        ///
        /// \brief This method updates the route information in the TMS Database
        /// 
        ///  
        ///  \details <b>Details</b>    
        ///  This method takes the route data and updates the current Route information in the TMS Database 
        ///  
        ///  \param newRouteData - <b>struct RouteData</b> - Struct containing Route ID, Destination, Kilometers, Time (in Hours), West and East  
        ///  
        ///  \return - <b>void</b> - Does not return anything
        ///  
        public void UpdateRoute(RouteData newRouteData)
        {

            

        }


        ///
        /// \brief This method adds a Route into the system
        /// 
        ///  
        ///  \details <b>Details</b>    
        ///  This method takes the route information that is entered by the user, and calls the ValidateRoute function
        ///  to validate the data. If the data is valid, it is added into the TMS System. 
        ///  
        ///  \param newRouteData - <b>struct RouteData</b> - Struct containing Route ID, Destination, Kilometers, Time (in Hours), West and East  
        ///  
        ///  \return - <b>void</b> - Does not return anything
        ///
        public void AddRoute(RouteData newRouteData)
        {

         

        }


        ///
        /// \brief This method deletes a Route from the system
        /// 
        ///  
        ///  \details <b>Details</b>    
        ///  This method takes the Route ID entered by the user, the ID is then compared to a list of current Route IDs.
        ///  If there is a match, the Route is deleted from the TMS System
        ///  
        ///  \param newRouteData - <b>struct RouteData</b> - Struct containing Route ID, Destination, Kilometers, Time (in Hours), West and East  
        ///  
        ///  \return - <b>void</b> - Does not return anything
        ///
        public void DeleteRoute(RouteData newRouteData)
        {

         

        }
    }
}
