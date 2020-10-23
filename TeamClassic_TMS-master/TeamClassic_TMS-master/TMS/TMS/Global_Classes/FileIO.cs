using System.IO;
using System.Text;

namespace TMS
{
    /// \class FileIO
    ///
    /// \brief This class provides basic file IO functions.
    /// 
    /// The purpose of this class is to provide basic file IO methods.
    /// Methods are providing for opening files (in read, and write mode),
    /// writing to files, closing files, and parsing file streams.
    ///
    public static class FileIO
    {
        /****************************************************************/
        /*                         Private members                      */
        /****************************************************************/
        ///
        /// \brief This method checks whether a character is a special character
        /// 
        /// \details <b>Details</b>
        /// This method checks whether a character is a special character. Special
        /// characters include: '\\n', '\t', and '\r'.
        ///
        /// \param character - <b>char</b> - The character that's being checked
        /// 
        /// \return isSpecial - <b>bool</b> - true if <i>char character</i> is a special
        ///     character and false if it isn't
        ///
        private static bool CheckSpecialChar(char character)
        {
            bool isSpecial = false;

            if (character == '\t' || character == '\n' || character == '\r')
            {
                isSpecial = true;
            }

            return isSpecial;
        }


        /****************************************************************/
        /*                         Public members                       */
        /****************************************************************/
        ///
        /// \brief This method opens a file for appending
        /// 
        /// \details <b>Details</b>
        /// The purpose of this method is to open a file for appending.
        /// If the file does not exist, the file is created.
        ///
        /// \param filename - <b>string</b> - The name of the file being opened
        /// 
        /// \return <b>FileStream</b> - The FileStream that was opened for appending
        ///
        public static FileStream OpenAppendFile(string filename)
        {
            return new FileStream(filename, FileMode.Append, FileAccess.Write);
        }


        ///
        /// \brief This method writes a message to a file.
        /// 
        /// \details <b>Details</b>
        /// The purpose of this method is to write a message to a 
        /// file using a opened FileStream. The FileStream must be 
        /// opened for writing.
        ///
        /// \param stream - <b>FileStream</b> - The FileStream that's being written to
        /// \param message - <b>string</b> - The message that's being written 
        /// 
        ///  \return - <b>void</b> - Does not return anything
        ///     
        public static void WriteToFile(FileStream stream, string message)
        {
            stream.Write(Encoding.ASCII.GetBytes(message), 0, message.Length);
        }


        ///
        /// \brief This method parses a string from an opened FileStream.
        /// 
        /// \details <b>Details</b>
        /// The purpose of this method is to parse a string from a FileStream.
        /// The FileStream must be opened for reading. All characters are parsed
        /// up until the first <i>char delim</i> is found.
        ///
        /// \param stream - <b>FileStream</b> - The FileStream that's being written to
        /// \param delim - <b>char</b> - The delimiter that's being used to parse. All characters
        ///                              to the left of the delimiter are parsed.
        /// 
        /// \return fileContents - <b>string</b> - The string that was parsed from the file
        /// 
        public static string ParseByChar(FileStream stream, char delim)
        {
            string fileContents = "";

            stream.Position = 0; // Reset the stream position to 0

            // Loop through the entire FileStream
            while (stream.Position != stream.Length)
            {
                char character = (char)stream.ReadByte();
                if (character == delim)
                {
                    break;
                }
                else
                {
                    fileContents += character;                    
                }
            }

            return fileContents;
        }


        ///
        /// \brief This method parses a string from an opened FileStream.
        /// 
        /// \details <b>Details</b>
        /// The purpose of this method is to parse a string from a FileStream.
        /// The FileStream must be opened for reading. All characters are parsed
        /// up until the specified <i>int numDelim</i> are found. The entire file stream will 
        /// be parsed if <i>int numDelim</i> is not reached.
        ///
        /// \param stream - <b>FileStream</b> - The FileStream that's being written to
        /// \param delim - <b>char</b> - The delimiter that's being used to parse. All characters
        ///                              to the left of the delimiter are parsed.
        /// \param numDelim - <b>int</b> - The number of delimiters that need to be found before the parsing is finished
        /// 
        /// \return fileContents - <b>string</b> - The string that was parsed from the file
        /// 
        public static string ParseByChar(FileStream stream, char delim, int numDelim)
        {
            string fileContents = "";

            stream.Position = 0; // Reset the stream position to 0

            int delimCount = 0;
            while (stream.Position != stream.Length) // Loop through the entire FileStream
            {
                char character = (char)stream.ReadByte();

                // Stop looping once the specified number of delimiters are found
                if (delimCount == numDelim)
                {
                    break;
                }
                else if (character == delim) 
                {
                    // Count the number of delimiters found
                    delimCount++;

                    // Extract the character if it's special (e.g. '\n')
                    if (CheckSpecialChar(character) == true)
                    {
                        fileContents += character;
                    }
                }
                else
                {
                    // Extract the character
                    fileContents += character;
                }
            }

            return fileContents;
        }


        ///
        /// \brief This method closes a file
        /// 
        /// \details <b>Details</b>
        /// The purpose of this method is to close an open FileStream. 
        ///     
        /// After the FileStream is closed, it is set to null. This allows for 
        /// checking if an attempt was made to close an unopened FileStream. 
        /// If this occurs, an event is logged indicating that an attempt was made
        /// close /p fileName when it was not opened.
        ///
        /// \param stream - <b>ref FileStream</b> - A reference to the FileStream that's being closed
        /// \param fileName - <b>string</b> - The name of the file that's being closed. This is used
        ///                                   so that logs can be written using the /p fileName.
        /// 
        /// \return - <b>void</b> - Does not return anything
        /// 
        public static void CloseFile(ref FileStream stream, string fileName)
        {
            if (stream != null)
            {
                stream.Close();
                stream = null;
            }
            else
            {
                // Log a message indicating that an attempt was made to close an unopened FileStream
                Logger.Log("An attempt was made to close " + fileName + " but it was not open.\n", "None");
            }
        }


        ///
        /// \brief Validates a folder path on the file system
        /// 
        /// \details <b>Details</b>
        ///     Validates whether a folder path is a valid folder
        ///     path on the file system. A valid folder path is
        ///     any existing folder that has security permissions.
        ///
        /// \param path - <b>string</b> - The path that's being validated
        /// 
        /// \return <b>bool</b> - true if the folder path is valid
        ///     and false if it isn't
        ///
        public static bool ValidatePath(string path)
        {
            return Directory.Exists(path);
        }


        ///
        /// \brief Generates a file name with a specified file extension
        /// 
        /// \details <b>Details</b>
        ///     Generates a file name with a file extension specified by <i>string extension</i>.
        ///     The file name generated is a date in the format yyyy-MM-dd with the file extension
        ///     appended to it.
        ///
        /// \param extension - <b>string</b> - The file extension for the file name that's being generated
        /// 
        /// \return fileName - <b>string</b> - The file name that was generated
        ///
        static string GenerateFileName(string extension)
        {
            string fileName = "";

            return fileName;
        }


        ///
        /// \brief This method is an overriden GenerateFileName() method
        /// 
        /// \details <b>Details</b>
		///		This method is an overridden GenerateFileName() method. It takes one additional
		/// 	parameter <i>string prefix</i>.
		///
        ///     Generates a file name with a file extension specified by <i>string extension</i>.
        ///     The file name is a date in the format yyyy-MM-dd with the file extension
        ///     appended to it. The characters specified by <i>string prefix</i> and placed to the left
        ///     the date in the file name.
        ///
        /// \param extension - <b>string</b> - The file extension for the file name that's being generated
        /// \param prefix - <b>string</b> - The string that's placed to the left of the date.
        /// 
        /// \return fileName - <b>string</b> - The file name that was generated
        ///
        static string GenerateFileName(string extension, string prefix)
        {
            string fileName = "";

            return fileName;        
		}


        ///
        /// \brief Generates a file name with a specified file extension
        /// 
        /// \details <b>Details</b>
		///		This method is an overridden GenerateFileName() method. It takes two additional
		/// 	parameter <i>string prefix</i>, and <i>string suffix</i>.
		/// 	
        ///     Generates a file name with a file extension specified by <i>string extension</i>.
        ///     The file name is a date in the format yyyy-MM-dd with the file extension
        ///     appended to it. The characters specified by <i>string prefix</i> are placed before
        ///     the date in the file name. The characters specified by <i>string suffix</i> are placed 
        ///     to the right of the date in the file name.
        ///
        /// \param extension - <b>string</b> - The file extension for the file name that's being generated
        /// \param prefix - <b>string</b> - The string that's placed to the left of the date
		/// \param suffix - <b>string</b> - The string that's placed to the right of the date
        /// 
        /// \return fileName - <b>string</b> - The file name that was generated
        ///
        static string GenerateFileName(string extension, string prefix, string suffix)
        {
            string fileName = "";

            return fileName;        
		}
    }
}
