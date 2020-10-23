using System;
using System.IO;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace TMS
{
    /// \class Logger
    /// 
    /// \brief This is a static class that's used to log events for the TMS System.
    /// 
    /// This purpose of this class is to provide Logging compabilities
    /// for the TMS System. The log files are saved to the user's "AppData\Roaming"
    /// folder.
    ///
    public static class Logger
    {
        /****************************************************************/
        /*                         Private members                      */
        /****************************************************************/
        private const string kDefaultLogFolder = "logs"; 	//!< The default name of the folder where logs are saved
        private const string kLogPrefix = "tms_log_"; 		//!< The prefix for the log file name
        private const string kFileExtension = ".txt"; 		//!< The file extension of the log file
        private const string kDateFormat = "yyyy-MM-dd";    //!< The format of the date for <i>string \ref logName_m</i>.<br>
                                                            //!< <b>Note:</b> "MM" must be capitilized
        
        private static string appDataPath_m;                //!< The absolute path to the folder that the program is running in
        private static string logName_m; 	                //!< The name of the log file
        private static string logFolder_m; 	                //!< The name of the folder that the logs are stored in
        private static string logPath_m; 	                //!< The absolute path to the log file (including the log file name)


        /****************************************************************/
        /*                         Public members                       */
        /****************************************************************/
        ///
        /// \brief This method is the constructor for the Logger class
        /// 
        /// \details <b>Details</b>
        /// This is the constructor for the Logger class. It gets the absolute
        /// path to the user's "AppData\Roaming" folder. This path is stored in 
        /// <i>string \ref appDataPath_m</i>, which is used to save the log file 
        /// to the user's "AppData\Roaming" folder.
        ///
        /// \param none - This method has no parameters.
        /// 
		/// \return This method is a constructor, therefore it doesn't return anything
        ///
        static Logger()
        {            
            // Get the name of the log folder and log file
            logName_m = kLogPrefix + GetCurrentDate() + kFileExtension;

            logPath_m = "";
            // Get the path to AppData folder, and then create absolute path for the log file (includes log file name)
            appDataPath_m = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                                         TmsInfo.kAppAbbrev);
            logFolder_m = kDefaultLogFolder;
            logPath_m = appDataPath_m + "\\" + logFolder_m;
        }


        ///
        /// \brief Gets the current date
        /// 
        /// \details <b>Details</b>
        /// This method gets the current date in the format specified
        /// by <i>string \ref kDateFormat</i>.
        ///
        /// \param none - This method has no parameters.
        /// 
        /// \return <b>string</b> - The current date in format specified
        ///     by <i>string \ref kDateFormat</i> is returned as a string.
        ///
        public static string GetCurrentDate()
        {
            return DateTime.Now.ToString(kDateFormat);
        }


        ///
        /// \brief This method is the accessor/mutator for <i>string \ref appDataPath_m</i>.
        /// 
        /// \details <b>Details</b>
        /// This method is the accessor/mutator for the <i>string \ref appDataPath_m</i>
        /// data member. It allows getting the value of <i>string \ref appDataPath_m</i>,
        /// and setting the value of <i>string \ref appDataPath_m</i>.
        ///
        /// \param value - <b>string</b> - The value that's being set to <i>string \ref appDataPath_m</i>.
        /// 
        /// \return appDataPath_m - <b>string</b> - The value of <i>string \ref appDataPath_m</i>.
        ///
        public static string AppDataPath_m
        {
            get { return appDataPath_m; }

            set
            {
                appDataPath_m = value;
            }
        }


        ///
        /// \brief This method is the accessor/mutator for <i>string \ref logName_m</i>.
        /// 
        /// \details <b>Details</b>
        /// This method is the accessor/mutator for the <i>string \ref logName_m</i>.
        /// data member. It allows getting the value of <i>string \ref logName_m</i>.,
        /// and setting the value of <i>string \ref logName_m</i>.
        ///
        /// \param value - <b>string</b> - The value that's being set to <i>string \ref logName_m</i>.
        /// 
        /// \return logName_m - <b>string</b> - The value of <i>string \ref logName_m</i>.
        ///
        public static string LogName_m
        {
            get { return logName_m; } 
            
            set
            {
                logName_m = value;
            }
        }


        ///
        /// \brief This method is the accessor/mutator for <i>string \ref logFolder_m</i>.
        /// 
        /// \details <b>Details</b>
        /// This method is the accessor/mutator for the <i>string \ref logFolder_m</i>.
        /// data member. It allows getting the value of <i>string \ref logFolder_m</i>.,
        /// and setting the value of <i>string \ref logFolder_m</i>.
        ///
        /// \param value - <b>string</b> - The value that's being set to <i>string \ref logFolder_m</i>.
        /// 
        /// \return logFolder_m - <b>string</b> - The value of <i>string \ref logFolder_m</i>.
        ///
        public static string LogFolder_m
        {
            get { return logFolder_m; }

            set { logFolder_m = value; }
        }


        ///
        /// \brief This method is the accessor/mutator for <i>string \ref logPath_m</i>.
        /// 
        /// \details <b>Details</b>
        /// This method is the accessor/mutator for the <i>string \ref logPath_m</i>.
        /// data member. It allows getting the value of <i>string \ref logPath_m</i>.,
        /// and setting the value of <i>string \ref logPath_m</i>.
        ///
        /// \param value - <b>string</b> - The value that's being set to <i>string \ref logPath_m</i>.
        /// 
        /// \return logPath_m - <b>string</b> - The value of <i>string \ref logPath_m</i>.
        ///
        public static string LogPath_m
        {
            get { return logPath_m; }

            set { logPath_m = value; }
        }


        ///
        /// \brief This method is an overloaded Log() method.
        /// 
        /// \details <b>Details</b>
        ///     The purpose of this method is to log events that does
        ///     not not occur as the result of an exception. 
        ///     
        ///     A log contains the date/time and a description of the event that's being logged.
        ///     
        /// \param logDescription - <b>string</b> - The description of the event that's being logged.
        ///     You must include '\\n' if you want newlines in your description.
        /// 
        /// \return <b>void</b> - This method does not return anything
        ///B
        public static void Log(string briefDescription)
        {
            // Create the entire log entry
            string logEntry = DateTime.Now +
                            "\nDESCRIPTION: " + briefDescription +
                            "\n\n";

            Directory.CreateDirectory(Path.Combine(AppDataPath_m, LogFolder_m)); // Create the folder

            // Write the log entry to the text file and close the file
            FileStream logStream = FileIO.OpenAppendFile(LogPath_m + "\\" + LogName_m);
            FileIO.WriteToFile(logStream, logEntry);
            logStream.Close();
        }


        ///
        /// \brief This method is an overloaded Log() method which takes an Exception Message.
        /// 
        /// \details <b>Details</b>
        ///     The purpose of this method is to log events that occur 
        ///     on the current date. The text file name is specified by 
        ///     the <i>string \ref logName_m</i> data member. 
        ///     
        ///     A log contains the date/time, a description of the event that's being logged, and
        ///     the exception Message.
        ///     
        /// \param logDescription - <b>string</b> - The description of the event that's being logged.
        ///     You must include '\\n' if you want newlines in your description.
        /// \param exceptionMsg - <b>string</b> - The exception message that's being displayed
        /// 
        /// \return <b>void</b> - This method does not return anything
        ///
        public static void Log(string briefDescription, string exceptionMsg)
        {
            // Create the entire log entry
            string logEntry = DateTime.Now +
                            "\nDESCRIPTION: " + briefDescription +
                            "\nEXCEPTION DUMP: \n" +
                            exceptionMsg +
                            "\n\n";

            Directory.CreateDirectory(Path.Combine(AppDataPath_m, LogFolder_m)); // Create the folder

            // Write the log entry to the text file and close the file
            FileStream logStream = FileIO.OpenAppendFile(LogPath_m + "\\" + LogName_m);
            FileIO.WriteToFile(logStream, logEntry);
            logStream.Close();
        }


        ///
        /// \brief This method displays a log file
        /// 
        /// \details <b>Details</b>
        /// This method reads all contents from a log file and 
        /// returns it as a string.
        ///
        /// \param logName - <b>string</b> - The name of the log that's
        ///     being opened
        /// 
        /// \return <b>string</b> - The contents of the log file as a string
        ///
        public static string ReadAllLog(string logName)
        {
            string logContents = null;

            try
            {
                logContents = File.ReadAllText(logName);
            }
            catch (Exception readLogFile_e)
            {
                Log("An error has occurred while attempting to read from a log file\n" +
                    "called " + logName + ".", readLogFile_e.Message);
            }

            return logContents;
        }


        ///
        /// \brief This method returns a List<string> of all log files
        /// 
        /// \details <b>Details</b>
        ///     The purpose of this method is to obtain a list of all
        ///     log files. The files are retrieved with an absolute path
        ///     attached to them. The paths are removed being they're added
        ///     to <i>List<string> logList</i> and returned.
        ///
        /// \param none - This method has no parameters.
        /// 
        /// \return logList - <b>List<string></b> - The list of log files
        ///     that were found in <i>string \ref logPath_m</i>
        ///
        public static List<string> GetLogList()
        {
            List<string> logList = new List<string>();

            // Get the absolute path to the log files in the log directory
            if (Directory.Exists(LogPath_m) == true)
            {
                string[] fullPaths = Directory.GetFiles(LogPath_m);

                // Parse the file names                
                for (int index = 0; index < fullPaths.Length; index++)
                {
                    logList.Add(Path.GetFileName(fullPaths[index]));
                }
            }
            else
            {
                // Log an event indicating that the log list was not retrieved because
                // the path was not found
            }

            return logList;
        }


        ///
        /// \brief Changes the directory that the log files are saved to
        /// 
        /// \details <b>Details</b>
        ///     This method changes that directory the log files are saved to.
        ///     The directory being changed to is specified through <i>string path</i>.
        ///
        /// \param path - <b>string</b> - The absolute path to the directory that's being changed to
        /// 
        /// \return wasChanged - <b>string</b> - true if the directory was changed successfully and false
        ///     if it wasn't
        ///
        public static bool ChangeLogDirectory(string path)
        {
            bool wasChanged = false;

            LogPath_m = path;

            // Replace all \ characters with a / to create the query string
            path = path.Replace("\\", "/");
            string updateDirectory = "UPDATE GenConfigOptions " +
                                     "SET LogDirectory = '" + path + "' " + 
                                     "WHERE AdminID = 1;";
            try
            {
                DAL.ModifyTableData(DAL.ConnectionString_tms, updateDirectory);
            }
            catch (MySqlException  logDirUpdate_e)
            {
                Log("An error occurred while changing the log directory within the TMS database.", logDirUpdate_e.Message);
            }

            return wasChanged;
        }


        ///
        /// \brief Gets the current directory that the log files are being saved to
        /// 
        /// \details <b>Details</b>
        /// This method gets the absolute path to the directory that the log files
        /// are saved in from the TMS database. The path is then saved in
        /// <i>string \ref logPath_m</i>.
        ///
        /// \param none - This method has no parameters.
        /// 
        /// \return <b>void</b> - This method doesn't return anything.
        ///
        public static void GetLogDirectory()
        {
            // Create the query string
            string query = "SELECT LogDirectory " +
                           "FROM GenConfigOptions " +
                           "WHERE AdminID = 1;";
         
            // Check if the LogDirectory has been set in the database and retrieve it if it has
            string path = null;            
            path = DAL.GetFirstTableCell(DAL.GetTable(DAL.ConnectionString_tms, query, "GenConfigOptions"));
            
            // Check if there is a path saved already and get the default if there isn't
            if (path == "")
            {
                logPath_m = GetDefaultPath();
            }
            else
            {
                // Save the log path in the Logger class
                logPath_m = path.Replace("/", "\\");
            }
        }


        ///
        /// \brief Gets the default folder path for saving log files
        /// 
        /// \details <b>Details</b>
        /// This methods finds the path to the user's "AppData\Roaming"
        /// folder, and appends the default log folder name to it. It's then
        /// saved to <i>string \ref logPath_m</i>.
        ///
        /// \param none - This method takes no parameters.
        /// 
        /// \return <b>void</b> - This method doesn't return anything.
        /// 
        public static string GetDefaultPath()
        {
            // Get the path to AppData folder, and then create absolute path for the log file (includes log file name)
            appDataPath_m = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                                         TmsInfo.kAppAbbrev);
            logFolder_m = kDefaultLogFolder;
            return appDataPath_m + "\\" + logFolder_m;
        }
    }
}
