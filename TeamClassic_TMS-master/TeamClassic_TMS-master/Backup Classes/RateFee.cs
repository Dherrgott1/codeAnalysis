using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS
{   
    
    /// \class RateFee
    ///
    /// \brief This is a class that is used to Update the Rate Fee Table Information
    ///
    /// The purpose of this class is to update the Rate Fee Table that is stored in the 
    /// TMS database, the information is validated before being updated.
    ///
    class RateFee
    {
        ///
        /// \brief This method updates the Rate / Fee Table with relevent information in the TMS Database
        /// 
        ///  
        ///  \details <b>Details</b>    
        ///  This method takes the FTL / LTL Rate or both and validates them to make sure they are valid. If so
        ///  the information is updated in the RateFee table in the TMS System
        ///  
        ///  \param ftlRate - <b>double</b> - The Full Truck Load Rate
        ///  \param ltlRate - <b>double</b> - The Less Than Full Truck Load Rate
        ///  
        ///  \return - <b>void</b> - Does not return anything
        /// 
        public void UpdateRF(double ftlRate, double ltlRate)
        {

        }





        ///
        /// \brief This method validates the Rate Fee being entered
        /// 
        ///  
        ///  \details <b>Details</b>    
        ///  This method takes the FTL / LTL Rate or both and validates them to make sure they are valid.
        ///  
        ///  \param ftlRate - <b>double</b> - The Full Truck Load Rate
        ///  \param ltlRate - <b>double</b> - The Less Than Full Truck Load Rate
        ///  
        ///  \return True / False - <b>bool</b> - Return true if validation is successful, false if failed.
        /// 
        public bool ValidateRF(double ftlRate, double ltlRate)
        {
            return true;
        }

    }
}
