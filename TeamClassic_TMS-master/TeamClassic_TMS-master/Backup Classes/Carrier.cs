using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS
{

    /// \class Carrier
    ///
    /// \brief This is a class that is used to hold the Carrier Information
    ///
    /// The purpose of this class is to store the Carrier Name, FTL Availability, LTL Availability, 
    /// FTL Rate, LTL Rate and Reefer Charge.
    ///
    public class Carrier
    {

        /****************************************************************/
        /*                         Private members                      */
        /****************************************************************/
        public struct CarrierData
        {
            public string name;                        //!< The Name of the carrier
            public int ftlAvailability;                //!< The full truck load Availability
            public int ltlAvailability;                //!< The less then truck load Availability
            public double ftlRate;                     //!< The full truck load rate
            public double ltlRate;                     //!< The less then truck load rate
            public int reeferCharge;                   //!< The reefer charge for a refrigerated truck


            ///
            /// \brief The constructor for the CarrierData struct
            /// 
            ///  
            ///  \details <b>Details</b>    
            ///  This method is the constructor for the CarrierData struct. It takes values of all variables
            ///  within the struct.
            ///  
            ///  \param newName - <b>string</b> - The value being assigned to <i>int \ref name</i>
            ///  \param newFtlAvailability - <b>int</b> - The value being assigned to <i>int \ref ftlAvailability</i>
            ///  \param newLtlAvailability - <b>int</b> - The value being assigned to <i>int \ref ltlAvailability</i>
            ///  \param newFtlRate - <b>double</b> - The value being assigned to <i>int \ref ftlRate</i>
            ///  \param newLtlRate - <b>double</b> - The value being assigned to <i>int \ref ltlRate</i>
            ///  \param newReeferCharge - <b>int</b> - The value being assigned to <i>int \ref reeferCharge</i>
            ///  
            ///  \return This is a constructor, therefore nothing is returned.
            ///  
            public CarrierData(string newName, int newFtlAvailability, int newLtlAvailability, double newFtlRate, double newLtlRate, int newReeferCharge)
            {
                name = newName;                    
                ftlAvailability = newFtlAvailability;
                ltlAvailability = newLtlAvailability;
                ftlRate = newFtlRate;
                ltlRate = newLtlRate;
                reeferCharge = newReeferCharge;
            }

        }



        ///
        /// \brief This method updates the carrier information in the TMS Database
        /// 
        ///  
        ///  \details <b>Details</b>    
        ///  This method takes the carrier data and updates the current Carrier information in the TMS Database
        ///  
        ///  \param newCarrierData - <b>struct CarrierData</b> - Struct containing Carrier Name, FTL Availability, LTL Availability, FTL Rate, LTL Rate and Reefer Charge  
        ///  
        ///  \return - <b>void</b> - Does not return anything
        ///  
        public void UpdateCarrier(CarrierData newCarrierData)
        {
           
            
            
        }




        ///
        /// \brief This method validates the carrier information being added into the TMS Database
        /// 
        ///  
        ///  \details <b>Details</b>    
        ///  This method takes the carrier information that is being added to the system, and validates it. 
        ///  
        ///  \param newCarrierData - <b>struct CarrierData</b> - Struct containing Carrier Name, FTL Availability, LTL Availability, FTL Rate, LTL Rate and Reefer Charge  
        ///  
        ///  \return True / False - <b>bool</b> - Return true if validation is successful, false if failed.
        ///
        public bool ValidateCarrierData(CarrierData newCarrierData)
        {


            return true;
        }





        ///
        /// \brief This method adds a Carrier into the system
        /// 
        ///  
        ///  \details <b>Details</b>    
        ///  This method takes the carrier information that is entered by the user, and calls the ValidateCarrierData function
        ///  to validate the data. If the data is verified and good to go, it is added into the TMS System. 
        ///  
        ///  \param newCarrierData - <b>struct CarrierData</b> - Struct containing Carrier Name, FTL Availability, LTL Availability, FTL Rate, LTL Rate and Reefer Charge  
        ///  
        ///  \return - <b>void</b> - Does not return anything
        ///
        public void AddCarrier(CarrierData newCarrierData)
        {

        }






        ///
        /// \brief This method deletes a Carrier from the system
        /// 
        ///  
        ///  \details <b>Details</b>    
        ///  This method takes the carrier name entered by the user, the name is then compared to a list of current Carrier names.
        ///  If there is a match, the Carrier is deleted from the TMS System
        ///  
        ///  \param name - <b>string</b> - The name of the Carrier that's being deleted
        ///  
        ///  \return - <b>void</b> - Does not return anything
        ///
        public void DeleteCarrier(string name)
        {
            
        }

    }
}
