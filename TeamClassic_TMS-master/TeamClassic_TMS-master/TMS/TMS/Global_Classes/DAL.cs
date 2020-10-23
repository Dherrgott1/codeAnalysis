/*
 * FILE        : DAL.cs
 * PROGRAMMER  : Conor Barr
 * CLASS NAME  : DAL
 * DESCRIPTION : 
 *  The static DAL (Data Access Layer) class provides method for accessing a
 *  mySQL database. 
 *  
 *  Before using the class, the DAL.Initialize() method must be called in order to initialize
 *  'private static string connectionString' (the data member that holds the 
 *  connection string). The DAL.CheckInitialization() method can be used to
 *  check whether the class has been initialized successfully.
 */

using System;
using MySql.Data.MySqlClient; // References -> Add Reference... -> Extensions -> MySql.Data
using System.Data;
using System.Windows.Controls;
using System.Windows.Data;

namespace TMS
{
    public static class DAL
    {
        // Checking if IDs exist
        public const int kId_Exists = 1;
        public const int kId_NotExist = 2;

        // Significant table rows/columns      
        public const int kFirstRow = 0;
        public const int kFirstColumn = 0;

        // Getting a column index
        public const int kCol_NotExist = -1;

        public static string ConnectionString_cmp // The connection string that's being used to connect to the Contract Marketplace database
        {
            get; set;
        }


        public static string ConnectionString_tms
        {
            get; set;
        } // The connection string that's being used to connect to the TMS database


        /*
        * NAME	  : Initialize()
        * PURPOSE : 
        *   Initializes the data members for the DAL class.
        *   The connectionString data member is set through the
        *   ConfigurationManager.ConnectionStrings property. The 
        *   connection string is retrieve from App.config. 
        * INPUTS  : 
        *   none
        * OUTPUTS : 
        *   none
        * RETURNS : 
        *   none
        */
        public static void Initialize()
        {
            // Get the connection string for the Contract Marketplace (CMP) database
            ConnectionString_cmp = "host=159.89.117.198;user=DevOSHT;password=Snodgr4ss!;database=cmp;";
            // Get the connection string for the TMS database
            ConnectionString_tms = "host = 127.0.0.1;user=root;password=Conestoga1;database=tms;";
        }


        /*
        * NAME	  : OpenDatabaseConnection()
        * PURPOSE : 
        *   Connects to the mySQL database, and returns the MySqlConnection
        *   object that opened. The connection is opened using the 
        *   'private static string connectionString' data member.
        * INPUTS  : 
        *   none
        * OUTPUTS : 
        *   none
        * RETURNS : 
        *   MySqlConnection connection: The connection to the mySQL database
        *       that was opened.
        */
        public static MySqlConnection OpenDatabaseConnection(string connectionString)
        {
            MySqlConnection connection = null;
            try
            {
                connection = new MySqlConnection(connectionString);
                // Check if were already connected before attempting to connected
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }                
            }
            catch (MySqlException dbConnect_e)
            {
                Logger.Log("An error occured while opening a mySQL database connection.", dbConnect_e.Message);
            }
            catch (Exception connectString_e)
            {
                Logger.Log("The connection string is not formatted correctly.", connectString_e.Message);
            }

            return connection;
        }


        /*
        * NAME	  : FillDataSet()
        * PURPOSE : 
        *   Fills a DataSet with data matching the given query
        *   and returns it.
        * INPUTS  : 
        *   string queryString: The mySQL query that's being used to fill the DataSet being returned
        *   string tblName: The name of the mySQL table table that's being queried.
        * OUTPUTS : 
        *   none
        * RETURNS : 
        *   DataSet data: The DataSet that was filled from the mySQL table
        */
        private static DataSet FillDataSet(string connectionString, string queryString, string tblName)
        {
            DataSet data = new DataSet(); // Create the DataSet

            using (MySqlConnection connection = OpenDatabaseConnection(connectionString))
            {
                // Create the MySqlDataAdapter
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(queryString, connection);

                // Fill the DataSet from with data from tblName that matches the query
                dataAdapter.Fill(data, tblName);

                connection.Close();
            }

            return data; // Return the filled DataSet
        }


        /*
        * NAME	  : GetTable()
        * PURPOSE : 
        *   Returns data from a mySQL table that matches the given query.
        * INPUTS  : 
        *   string queryString: The mySQL query string being used to get the table data
        *   string tblName: The name of the mySQL table being queried
        * OUTPUTS : 
        *   none
        * RETURNS : 
        *   DataTable: The DataTable that matches the mySQL query specifed by 'string queryString'
        */
        public static DataTable GetTable(string connectionString, string queryString, string tblName)
        {
            DataSet data = FillDataSet(connectionString, queryString, tblName);

            return data.Tables[0];
        }



        /*
        * NAME	  : GetTableRows()
        * PURPOSE : 
        *   Gets all rows in a table and adds them to an array of strings.
        *   Each column of data is delimited by a '\0' character.
        * INPUTS  : 
        *   DataTable table: The table of data that's being loaded into a string array
        * OUTPUTS : 
        *   none
        * RETURNS : 
        *   string[] rowArray: An array of strings containing all rows in a DataTable.
        *       Each row is an element in the array.
        */
        public static string[] GetTableRows(DataTable table)
        {
            // Create an array to hold all rows in 'DataTable table'
            string[] rowArray = new string[table.Rows.Count];

            // Loop through all rows
            for (int rowIndex = 0; rowIndex < table.Rows.Count; rowIndex++)
            {
                // Get a single row of data
                DataRow row = table.Rows[rowIndex];

                // Get all data from the row into a string
                string rowString = "";
                for (int columnIndex = 0; columnIndex < row.ItemArray.Length; columnIndex++)
                {
                    rowString += row.ItemArray[columnIndex].ToString() + "\0";
                }

                // Place the string in the array
                rowArray[rowIndex] = rowString;
            }

            return rowArray;
        }



        /*
        * NAME	  : GetFirstTableCell()
        * PURPOSE : 
        *   Gets the first column of data in the fist row. Use this
        *   method for making queries that return only 1 result.
        * INPUTS  : 
        *   DataTable tbl: The table that the cell is in (use GetTable() to
        *       get the table for this parameter)
        * OUTPUTS : 
        *   none
        * RETURNS : 
        *   string cell: The data in the cell, as a string
        */
        public static string GetFirstTableCell(DataTable table)
        {
            string cell = null;

            // Check if the table exists and only has a single row & column
            if (table != null)
            {
                cell = table.Rows[kFirstRow].ItemArray[kFirstColumn].ToString();
            }

            return cell;
        }


        /*
        * NAME	  : GetTableCell()
        * PURPOSE : 
        *   Gets a single cell of data from a DataTable when given the index of the
        *   row and column of the cell.
        * INPUTS  : 
        *   DataTable tbl: The table that the cell is in (use GetTable() to
        *       get the table for this parameter)
        *   int rowIndex: The index of the row
        *   int colIndex: The index of the column
        * OUTPUTS : 
        *   none
        * RETURNS : 
        *   string cell: The data in the cell, as a string
        */
        public static string GetTableCell(DataTable tbl, int rowIndex, int colIndex)
        {
            string cell = null;

            // Check if the table exists and only has a single row & column
            if (tbl != null)
            {
                cell = tbl.Rows[rowIndex].ItemArray[colIndex].ToString();
            }

            return cell;
        }


        /*
        * NAME	  : GetCount()
        * PURPOSE : 
        *   Gets the current number of records in a mySQL table.
        * INPUTS  : 
        *   string column: The column that's being queried (use the * wildcard
        *       if you want all columns)
        *   string tblName: The name of the mySQL table that's being queried
        * OUTPUTS : 
        *   none
        * RETURNS : 
        *   int: The number of rows in the mySQL table
        */
        public static int GetCount(string connectionString, string column, string tblName)
        {
            string query = "SELECT COUNT(" + column + ")" +

                   " FROM " + tblName + ";";

            return Int32.Parse(GetFirstTableCell(GetTable(connectionString, query, tblName)));
        }


        /*
        * NAME	  : GetCount()
        * PURPOSE : 
        *   Overloaded GetCount() method that has a WHERE clause. Use it to
        *   get the number of records in a table that meet the WHERE condition.
        * INPUTS  : 
        *   string column: The column that's being queried (use the * wildcard
        *       if you want all columns)
        *   string tblName: The name of the mySQL table that's being queried
        *   string whereClause: The WHERE clause. Allows only counting the records
        *       that match this clause.
        * OUTPUTS : 
        *   none
        * RETURNS : 
        *   int: The number of rows in the mySQL table
        */
        public static int GetCount(string connectionString, string column, string tblName, string whereClause)
        {
            string query = "SELECT COUNT(" + column + ")" +
                   " FROM " + tblName +
                   " WHERE " + whereClause + ";";

            return Int32.Parse(GetFirstTableCell(GetTable(connectionString, query, tblName)));
        }


        /*
        * NAME	  : ModifyTableData()
        * PURPOSE : 
        *   This method executes a mySQL statement which inserts, updates, 
        *   or deletes information from a table in a mySQL database.
        * INPUTS  : 
        *   string queryString: The mySQL statement that's inserting, updating,
        *       or deleting.
        * OUTPUTS : 
        *   none
        * RETURNS :     
        *   none
        */
        public static void ModifyTableData(string connectionString, string queryString)
        {
            using (MySqlConnection connection = OpenDatabaseConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(queryString, connection);
                command.ExecuteNonQuery();

                connection.Close();
            }
        }


        /*
        * NAME	  : ModifyTableData()
        * PURPOSE : 
        *   This is an overloaded ModifyTableData() method. It allows
        *   inserting, updating, or deleting from a table using multiple mySQL 
        *   statements. Each mySQL statement should be an element in the 
        *   'string[] queryStrings' array.
        * INPUTS  : 
        *   string[] queryString: The array of mySQL statement that insert, 
        *       update, or delete.
        * OUTPUTS : 
        *   none
        * RETURNS :     
        *   none
        */
        public static void ModifyTableData(string connectionString, string[] queryStrings)
        {
            using (MySqlConnection connection = OpenDatabaseConnection(connectionString))
            {
                foreach (string query in queryStrings)
                {
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }


        /*
        * NAME	  : CheckIDExists()
        * PURPOSE : 
        *   Queries a mySQL database to check whether an ID (primary key) 
        *   exists within a table in a mySQL database. Returns an int 
        *   based on the results of this check.
        * INPUTS  : 
        *   string tblName: The name of the table being queried
        *   string idColumnName:
        *   string id:
        * OUTPUTS : 
        *   none
        * RETURNS : 
        *   int result: 1 (kId_Exists) if the ID is in the table, and 2 (kId_NotExist)
        *       if it doesn't
        */
        public static int CheckIDExists(string connectionString, string tblName, string idColumnName, string id)
        {
            int result = kId_Exists;

            // Create the query string to check whether the ID exists
            string query = "SELECT *" +
                           " FROM " + tblName + 
                           " WHERE " + idColumnName + "=" + id;
            
            using (MySqlConnection connection = OpenDatabaseConnection(connectionString))
            {
                // Execute the SQL query, if null is returned the ID does not exist
                MySqlCommand command = new MySqlCommand(query, connection);
                if (command.ExecuteScalar() == null)
                {
                    result = kId_NotExist;
                }

                connection.Close();
            }

            return result;
        }


        /*
        * NAME	  : FillDataGrid()
        * PURPOSE : 
        *   Fills a DataGrid (UI element) with all data contained within a DataTable object.
        * INPUTS  : 
        *   DataGrid dGrid: The UI element that the data is being displayed in
        *   DataTable dTable: The DataTable object that's filling the table. Use DAL.GetTable() 
        *       to get the DataTable.
        * OUTPUTS : 
        *   none
        * RETURNS : 
        *   none
        */
        public static void FillDataGrid(DataGrid dGrid, DataTable dTable)
        {
            dGrid.SetBinding(ItemsControl.ItemsSourceProperty, new Binding { Source = dTable });
        }


        /*
        * NAME	  : GetSelectedRow_DataGrid()
        * PURPOSE : 
        *   Gets data from all columns in the selected row in a DataGrid.
        *   The data is returned as an array of strings. Each element in the
        *   array is a cell/column of data.
        * INPUTS  : 
        *   DataGrid dataGrid: The DataGrid (UI element) that's being collected into 
        *       an array of strings
        * OUTPUTS : 
        * RETURNS : 
        *   string[] rowData: All data in the row that was selected. Each element in 
        *       the array is a cell/column in the row.
        */
        public static string[] GetSelectedRow_DataGrid(DataGrid uiElement)
        {
            // Get the row that was selected
            DataRowView selectedRow = (DataRowView)uiElement.SelectedItem;

            // Create an array sized to the the number of columns in the DataGrid
            string[] rowData = new string[selectedRow.Row.ItemArray.Length];

            // Store all data in each column in an array of strings and then return it
            for (int i = 0; i < selectedRow.Row.ItemArray.Length; i++)
            {
                rowData[i] += selectedRow.Row.ItemArray[i].ToString() + "\n";
                rowData[i] = rowData[i].Replace("\n", ""); // Remove newline character
            }

            return rowData;
        }


        /*
        * NAME	  : GetColumnHeaders_DataGrid()
        * PURPOSE : 
        *   Gets the names of all Column Headers in a DataGrid. The data is 
        *   returned as an array of strings. Each element in the array is a column of data.
        * INPUTS  : 
        *   DataGrid uiElement: The DataGrid (UI element) that the column Headers are in
        * OUTPUTS : 
        *   none
        * RETURNS : 
        *   string[] headers: The column Headers in an array of strings. Each element
        *       in the array is a Header.
        */
        public static string[] GetColumnHeaders_DataGrid(DataGrid uiElement)
        {
            // Create an array sized to the the number of columns in the DataGrid
            string[] headers = new string[uiElement.Columns.Count];

            // Store all column headers in an array of strings and then return it
            for (int i = 0; i < uiElement.Columns.Count; i++)
            {
                headers[i] = uiElement.Columns[i].Header.ToString();
            }

            return headers;
        }


        /*
        * NAME	  : GetColumnIndex()
        * PURPOSE : 
        *   Gets the index of the specified column in a mySQL table. It does this
        *   by searching for the column and returning the specified index. If the
        *   column does not exist the method returns -1.
        * INPUTS  : 
        *   string colName: The name of the column that's being searched for
        * OUTPUTS : 
        *   none
        * RETURNS : 
        *   int: The index of the column, or -1 if the column does not exist
        */
        public static int GetColumnIndex(MySqlDataReader reader, string colName)
        {
            int colIndex = 0;

            // Loop through all columns held by 'MySqlDataReader reader'
            for (int counter = 0; counter < (reader.FieldCount - 1); counter++)
            {
                // Check whether the column name is a match and stop looping if it is
                if (reader.GetName(counter) == colName)
                {
                    colIndex = counter;
                    break;
                }
            }

            return colIndex;
        }
    }
}
