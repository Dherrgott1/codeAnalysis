using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TMS
{
    /// \class Messenger
    /// 
    /// \brief Static class that contains methods that are used for sending messages users
    /// 
    /// The static Messenger class contains methods that are used to message the user
    /// using a MessageBox.
    ///
    public static class Messenger
    {
        ///
        /// \brief Displays a MessageBox with the application name as the title
        /// 
        /// \details <b>Details</b>
        /// This method displays a MessageBox with a message specified by the
        /// <i>string msg</i> parameter. The title of the MessageBox is the
        /// name of the application (specified by <i>TmsInfo.kAppName</i>).
        ///
        /// \param msg - <b>string</b> - The message that's display in the MessageBox
        /// 
        /// \return <b>void</b> - This method doesn't return anything.
        /// 
        public static void DisplayMessage(string msg)
        {
            // Display the message
            MessageBox.Show(msg, TmsInfo.kAppName);
        }


        ///
        /// \brief Overloaded DisplayMessage() method that takes window title as a parameter
        /// 
        /// \details <b>Details</b>
        /// This method displays a MessageBox with a message specified by the
        /// <i>string msg</i> parameter. The title of the MessageBox is specified
        /// by the <i>string windowTitle</i> parameter. The prefix "TMS - " placed
        /// before the window title when the message box is shown.
        ///
        /// \param msg - <b>string</b> - The message that's display in the MessageBox
        /// \param windowTitle - <b>string</b> - The message the window title the MessageBox
        /// 
        /// \return <b>void</b> - This method doesn't return anything.
        /// 
        public static void DisplayMessage(string msg, string windowTitle)
        {
            // Display the message
            MessageBox.Show(msg, TmsInfo.kAppAbbrev + " - " + windowTitle);
        }
    }
}
