using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS
{
    /// \class Address
    ///
    /// \brief This is a class that is used to represent the Address of the Employeee
    ///
    /// The purpose of this class is to store the Street Address, City, Province, and Postal Code
    /// of the employee.
    ///    public class Address
    {

        /****************************************************************/
        /*                         Private members                      */
        /****************************************************************/

        private string streetAddress_m;  //!< String representing the address
        private string city_m; //!< String representing the City 
        private string province_m; //!< String representing the Province
        private string postalCode_m; //!< String representing the Postal Code





        /****************************************************************/
        /*                         Public members                       */
        /****************************************************************/

        ///
        /// \brief This method is the accessor/mutator for <i>string \ref streetAddress_m</i>.
        /// 
        /// \details <b>Details</b>
        /// This method is the accessor/mutator for the <i>string \ref streetAddress_m</i>
        /// data member. It allows getting the value of <i>string \ref streetAddress_m</i>,
        /// and setting the value of <i>string \ref streetAddress_m</i>.
        ///
        /// \param value - <b>string</b> - The value that's being set to <i>string \ref streetAddress_m</i>.
        /// 
        /// \return streetAddress_m - <b>string</b> - The value of <i>string \ref streetAddress_m</i>.
        ///
        public string StreetAddress_m
        {
            get { return streetAddress_m; }

            set
            {
                streetAddress_m = value;
            }
        }




        ///
        /// \brief This method is the accessor/mutator for <i>string \ref city_m</i>.
        /// 
        /// \details <b>Details</b>
        /// This method is the accessor/mutator for the <i>string \ref city_m</i>
        /// data member. It allows getting the value of <i>string \ref city_m</i>,
        /// and setting the value of <i>string \ref city_m</i>.
        ///
        /// \param value - <b>string</b> - The value that's being set to <i>string \ref city_m</i>.
        /// 
        /// \return city_m - <b>string</b> - The value of <i>string \ref city_m</i>.
        ///
        public string City_m
        {
            get { return city_m; }

            set
            {
                city_m = value;
            }
        }




        ///
        /// \brief This method is the accessor/mutator for <i>string \ref province_m</i>.
        /// 
        /// \details <b>Details</b>
        /// This method is the accessor/mutator for the <i>string \ref province_m</i>
        /// data member. It allows getting the value of <i>string \ref province_m</i>,
        /// and setting the value of <i>string \ref province_m</i>.
        ///
        /// \param value - <b>string</b> - The value that's being set to <i>string \ref province_m</i>.
        /// 
        /// \return province_m - <b>string</b> - The value of <i>string \ref province_m</i>.
        ///
        public string Province_m
        {
            get { return province_m; }

            set
            {
                province_m = value;
            }
        }

        


        ///
        /// \brief This method is the accessor/mutator for <i>string \ref postalCode_m</i>.
        /// 
        /// \details <b>Details</b>
        /// This method is the accessor/mutator for the <i>string \ref postalCode_m</i>
        /// data member. It allows getting the value of <i>string \ref postalCode_m</i>,
        /// and setting the value of <i>string \ref postalCode_m</i>.
        ///
        /// \param value - <b>string</b> - The value that's being set to <i>string \ref postalCode_m</i>.
        /// 
        /// \return postalCode_m - <b>string</b> - The value of <i>string \ref postalCode_m</i>.
        ///
        public string PostalCode_m
        {
            get { return postalCode_m; }

            set
            {
                postalCode_m = value;
            }

        }

    }
}
