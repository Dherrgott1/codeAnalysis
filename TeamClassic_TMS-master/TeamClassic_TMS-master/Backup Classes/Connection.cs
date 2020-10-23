using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS
{
    /// \class Connection
    /// 
    /// \brief This class is used to handle connection through TCP/IP.
    /// 
    /// This class provides methods for keeping track of connection information
    /// and validating that connecting information is correct.
    ///
    class Connection
    {
        private string ipAddress_m; //!< The IP address that's being connected to
        private int port_m; 		//!< The port that's being connected to


        ///
        /// \brief This method is the accessor/mutator for <i>string \ref ipAddress_m</i>.
        /// 
        /// \details <b>Details</b>
        /// This method is the accessor/mutator for the <i>string \ref ipAddress_m</i>
        /// data member. It allows getting the value of <i>string \ref ipAddress_m</i>,
        /// and setting the value of <i>string \ref ipAddress_m</i>.
        ///
        /// \param value - <b>string</b> - The value that's being set to <i>string \ref ipAddress_m</i>.
        /// 
        /// \return ipAddress_m - <b>string</b> - The value of <i>string \ref ipAddress_m</i>.
        ///
        public string IpAddress_m
        {
            get { return this.ipAddress_m; }

            set
            {
                this.ipAddress_m = value;
            }
        }


        ///
        /// \brief This method is the accessor/mutator for <i>int \ref port_m</i>.
        /// 
        /// \details <b>Details</b>
        /// This method is the accessor/mutator for the <i>int \ref port_m</i>
        /// data member. It allows getting the value of <i>int \ref port_m</i>,
        /// and setting the value of <i>int \ref port_m</i>.
        ///
        /// \param value - <b>string</b> - The value that's being set to <i>int \ref port_m</i>.
        /// 
        /// \return ipAddress_m - <b>string</b> - The value of <i>int \ref port_m</i>.
        ///
        public int Port_m
        {
            get { return this.port_m; }

            set
            {
                this.port_m = value;
            }
        }


        ///
        /// \brief Assigns a valid IP address to <i>string \ref ipAddress_m</i>
        /// 
        /// \details <b>Details</b>
        ///     The purpose of this method is to ensure that only a valid IP address
        ///     is assigned to <i>string \ref ipAddress_m</i>. This is done by calling the
        ///     ValidateIpAddress() method, which returns true if an IP address is valid, and
        ///     false if it isn't. A bool is returned (<i>bool assignedStatus</i>) that indicates
        ///     whether the IP address was assigned successfully.
        ///
        /// \param ipAddress - <b>string</b> - The IP address that's being assigned to <i>string \ref ipAddress_m</i>
        /// 
        /// \return assignedStatus - <b>bool</b> - true if the IP address was assigned successfully, and
        ///     false if it wasn't
        ///
        public bool AssignIpAddress(string ipAddress)
        {
            bool assignedStatus = false; // Indicates whether the IP address was assigned successfully
            
            // If the IP address is valid, assign it
            if (ValidateIpAddress(ipAddress) == true)
            {
                this.IpAddress_m = ipAddress;
            }

            return assignedStatus;
        }


        ///
        /// \brief Assigns a valid IP address to <i>int \ref port_m</i>
        /// 
        /// \details <b>Details</b>
        ///     The purpose of this method is to ensure that only a valid port
        ///     is assigned to <i>int \ref port_m</i>. This is done by calling the
        ///     ValidatePort() method, which returns true if a port is valid, and
        ///     false if it isn't. A bool is returned (<i>bool assignedStatus</i>) that indicates
        ///     whether the port was assigned successfully.
        ///
        /// \param port - <b>int</b> - The IP address that's being assigned to <i>int \ref port_m</i>
        /// 
        /// \return assignedStatus - <b>bool</b> - true if the IP address was assigned successfully, and
        ///     false if it wasn't
        ///
        public bool AssignPort(int port)
        {
            bool assignedStatus = false; // Indicates whether the IP address was assigned successfully

            // If the port is valid, assign it
            if (ValidatePort(port) == true)
            {
                this.Port_m = port;
            }

            return assignedStatus;
        }


        ///
        /// \brief Checks whether an IP address is valid
        /// 
        /// \details <b>Details</b>
        ///     This method checks whether an IP address that's being
        ///     assigned to <i>string \ref ipAddress_m</i> is valid.
        ///     A bool is returned which indicates the result of the 
        ///     validation.
        ///
        /// \param ipAddress - <b>string</b> - The IP address that's being checked
        /// 
        /// \return ipAddressStatus - <b>bool</b> - true if <i>string ipAddress</i>
        ///     is valid, and false if it isn't
        ///
       private static bool ValidateIpAddress(string ipAddress)
        {
            bool ipAddressStatus = false;

            return ipAddressStatus;
        }


        ///
        /// \brief Checks whether a port is valid
        /// 
        /// \details <b>Details</b>
        ///     This method checks whether a port that's being
        ///     assigned to <i>int \ref port_m</i> is valid.
        ///     A bool is returned which indicates the result of the 
        ///     validation.
        ///
        /// \param port - <b>int</b> - The port that's being checked
        /// 
        /// \return validPort - <b>bool</b> - true if the <i>int port</i> 
        ///     is valid and false if it isn't
        ///
        private static bool ValidatePort(int port)
        {
            bool portStatus = false;

            return portStatus;
        }
    }
}
