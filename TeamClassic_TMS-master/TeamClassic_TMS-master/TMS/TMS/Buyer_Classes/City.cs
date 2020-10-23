using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace TMS
{
    internal class City
    {
        public int CityID { get; set; }

        public string CityName { get; set; }


        public List<City> getAllCities()
        {
            List <City> cityList = new List<City>();

            // Set up connection
            MySqlConnection connectToPOSDB = new MySql.Data.MySqlClient.MySqlConnection("host=127.0.0.1;user=root;password=Conestoga1;database=tms;");

            //Connect to database
            connectToPOSDB.Open();

            string getCityQuery = "SELECT * FROM City";

            // Setup query into mysql command
            MySqlCommand getAllCities = new MySqlCommand(getCityQuery, connectToPOSDB);

            //Start reading the database
            MySqlDataReader reader = getAllCities.ExecuteReader();

            try
            {
                while (reader.Read())
                {
                    //Read values from database row by row
                    var CityID_T = reader.GetString("CityID");
                    var CityName_T = reader.GetString("CityName");

                    cityList.Add(new City() { CityID = Convert.ToInt32(CityID_T), CityName = CityName_T });
                }
            }
            finally
            {
                // Always call Close when done reading.
                reader.Close();
            }

            connectToPOSDB.Close();

            return cityList;
        }
    }
}