using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Crmf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gavin_Fahey_C969_PA
{
    class CurrentUser
    {
        private int currentUserID;
        private static string currentUsername;
        public string sqlConnectionString = "server=3.227.166.251 ;database=U06kHJ;uid=U06kHJ;pwd=53688792604;";

        public int getCurrentUserID()
        {
            return currentUserID;
        }

        public void setCurrentUserID(int userID)
        {
            currentUserID = userID;
        }

        public static string getCurrentUsername()
        {
            return currentUsername;
        }

        public static void setCurrentUsername(string username)
        {
            currentUsername = username;
        }

        // This function checks to see if the country exists and if it does
        // to assign the current countryID or assign a new one if it doesn't
        // Same for setCity and setAddress and setCustomer
        public string setCountryID(string country)
        {
            int temp = 0;
            string countryID;
            using (MySqlConnection c = new MySqlConnection(sqlConnectionString))
            {
                c.Open();
                MySqlDataReader reader;
                using (MySqlCommand cmd1 = new MySqlCommand($"SELECT * FROM country WHERE country = '{country}'", c))
                {                    
                    reader = cmd1.ExecuteReader();
                    if (reader.Read())
                    {                        
                        countryID = reader[0].ToString();
                        reader.Close();
                        reader.Dispose();
                        c.Close();
                        return countryID;
                    }
                } using (MySqlCommand cmd2 = new MySqlCommand("SELECT * FROM country", c))
                {
                    reader.Close();
                    reader.Dispose();
                    reader = cmd2.ExecuteReader();
                    while (reader.Read())
                    {
                        temp++;                        
                    }
                    countryID = "New ID " + (temp + 1).ToString();
                    c.Close();
                    return countryID;
                }
            }
        }
        public string setCityID(string city)
        {
            int temp = 0;
            string cityID;
            using (MySqlConnection c = new MySqlConnection(sqlConnectionString))
            {
                c.Open();
                MySqlDataReader reader;
                using (MySqlCommand cmd1 = new MySqlCommand($"SELECT * FROM city WHERE city = '{city}'", c))
                {
                    reader = cmd1.ExecuteReader();
                    if (reader.Read())
                    {
                        cityID = reader[0].ToString();
                        reader.Close();
                        reader.Dispose();
                        c.Close();
                        return cityID;
                    }
                }
                using (MySqlCommand cmd2 = new MySqlCommand("SELECT * FROM city", c))
                {
                    reader.Close();
                    reader.Dispose();
                    reader = cmd2.ExecuteReader();
                    while (reader.Read())
                    {
                        temp++;
                    }
                    cityID = "New ID " + (temp + 1).ToString();
                    c.Close();
                    return cityID;
                }
            }
        }
        public string setAddressID()
        {
            int temp = 0;
            string addressID;

            MySqlConnection c = new MySqlConnection(sqlConnectionString);
            c.Open();
            MySqlCommand cmd = new MySqlCommand($"SELECT * FROM address", c);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                temp++;
            }
            addressID = (temp + 1).ToString();
            c.Close();
            return addressID;
        }
        public string setCustomerID()
        {
            int temp = 0;
            string customerID;

            MySqlConnection c = new MySqlConnection(sqlConnectionString);
            c.Open();
            MySqlCommand cmd = new MySqlCommand($"SELECT * FROM customer", c);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                temp++;
            }
            customerID = (temp + 1).ToString();
            c.Close();
            return customerID;
        }
    }
}
