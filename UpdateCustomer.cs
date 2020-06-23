using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gavin_Fahey_C969_PA
{
    public partial class UpdateCustomer : Form
    {
        CurrentUser cu = new CurrentUser();
        bool errorCount = false;
        public UpdateCustomer()
        {
            InitializeComponent();
        }

        private void UpdateCustomer_Load(object sender, EventArgs e)
        {

        }        

        private void updateCustCreateBtn_Click(object sender, EventArgs e)
        {
            string ct = DateTime.Now.ToString("u");
            string username = CurrentUser.getCurrentUsername();

            NameValidationCheck();
            PhoneValidationCheck();
            AddressValidationCheck();
            CityValidationCheck();
            ZipValidationCheck();
            CountryValidationCheck();            

            /*if(!errorCount)
            {
                MySqlConnection c = new MySqlConnection(cu.sqlConnectionString);
                c.Open();
                MySqlCommand cmd = new MySqlCommand($"SELECT * FROM customer WHERE customerId = {Convert.ToInt32(updateCustSearchText.Text)}", c);
                MySqlDataReader reader = cmd.ExecuteReader();

                if(reader.Read())
                {
                    MessageBox.Show(reader[0] + "\n" + reader[1] + "\n" + reader[2] + "\n" + reader[3] + "\n" + reader[4] + "\n" + reader[5] + "\n");
                } else
                {
                    updateCustSearchErr.Text = "Can't find Customer ID";
                    updateCustSearchErr.Visible = true;
                    errorCount = true;
                }
            }*/
        }

        private void updateCustCancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void NameValidationCheck()
        {
            if (String.IsNullOrEmpty(updateCustNameText.Text) || String.IsNullOrWhiteSpace(updateCustNameText.Text))
            {
                updateCustNameErr.Text = "Name Required";
                updateCustNameErr.Visible = true;
                errorCount = true;
            }
            else if (updateCustNameText.Text.Any(Char.IsDigit) || updateCustNameText.Text.Any(Char.IsSymbol) || updateCustNameText.Text.Any(Char.IsPunctuation))
            {
                updateCustNameErr.Text = "Only letters";
                updateCustNameErr.Visible = true;
                errorCount = true;
            }
            else
            {
                updateCustNameErr.Visible = false;
                errorCount = false;
            }
        }
        public void PhoneValidationCheck()
        {
            if (String.IsNullOrEmpty(updateCustPhoneText.Text) || String.IsNullOrWhiteSpace(updateCustPhoneText.Text))
            {
                updateCustPhoneErr.Text = "Phone Required";
                updateCustPhoneErr.Visible = true;
                errorCount = true;
            }
            else if (updateCustPhoneText.Text.Any(Char.IsLetter) || updateCustPhoneText.Text.Any(Char.IsSymbol) || updateCustPhoneText.Text.Any(Char.IsPunctuation))
            {
                updateCustPhoneErr.Text = "Only numbers";
                updateCustPhoneErr.Visible = true;
                errorCount = true;
            }
            else
            {
                updateCustPhoneErr.Visible = false;
                errorCount = false;
            }
        }
        public void AddressValidationCheck()
        {
            if (String.IsNullOrEmpty(updateCustAddressText.Text) || String.IsNullOrWhiteSpace(updateCustAddressText.Text))
            {
                updateCustAddressErr.Text = "Address Required";
                updateCustAddressErr.Visible = true;
                errorCount = true;
            }
            else if (updateCustAddressText.Text.Any(Char.IsPunctuation) || updateCustAddressText.Text.Any(Char.IsSymbol))
            {
                updateCustAddressErr.Text = "Only numbers and letters";
                updateCustAddressErr.Visible = true;
                errorCount = true;
            }
            else
            {
                updateCustAddressErr.Visible = false;
                errorCount = false;
            }
        }
        public void CityValidationCheck()
        {
            if (String.IsNullOrEmpty(updateCustCityText.Text) || String.IsNullOrWhiteSpace(updateCustCityText.Text))
            {
                updateCustCityErr.Text = "City Required";
                updateCustCityErr.Visible = true;
                errorCount = true;
            }
            else if (updateCustCityText.Text.Any(Char.IsDigit) || updateCustCityText.Text.Any(Char.IsSymbol) || updateCustCityText.Text.Any(Char.IsPunctuation))
            {
                updateCustCityErr.Text = "Only letters";
                updateCustCityErr.Visible = true;
                errorCount = true;
            }
            else
            {
                updateCustCityErr.Visible = false;
                errorCount = false;
            }
        }
        public void ZipValidationCheck()
        {
            if (String.IsNullOrEmpty(updateCustZipText.Text) || String.IsNullOrWhiteSpace(updateCustZipText.Text))
            {
                updateCustZipErr.Text = "Zip Code Required";
                updateCustZipErr.Visible = true;
                errorCount = true;
            }
            else if (updateCustZipText.Text.Any(Char.IsLetter) || updateCustZipText.Text.Any(Char.IsSymbol) || updateCustZipText.Text.Any(Char.IsPunctuation))
            {
                updateCustZipErr.Text = "Only numbers";
                updateCustZipErr.Visible = true;
                errorCount = true;
            }
            else
            {
                if (updateCustZipText.Text.Length < 11)
                {
                    updateCustZipErr.Visible = false;
                    errorCount = false;
                }
                else
                {
                    updateCustZipErr.Text = "Invalid Zip Code";
                    updateCustZipErr.Visible = true;
                    errorCount = true;
                }
            }
        }
        public void CountryValidationCheck()
        {
            if (String.IsNullOrEmpty(updateCustCountryText.Text) || String.IsNullOrWhiteSpace(updateCustCountryText.Text))
            {
                updateCustCountryErr.Text = "Country Required";
                updateCustCountryErr.Visible = true;
                errorCount = true;
            }
            else if (updateCustCountryText.Text.Any(Char.IsDigit) || updateCustCountryText.Text.Any(Char.IsSymbol) || updateCustCountryText.Text.Any(Char.IsPunctuation))
            {
                updateCustCountryErr.Text = "Only letters";
                updateCustCountryErr.Visible = true;
                errorCount = true;
            }
            else
            {
                try
                {
                    RegionInfo countryCode = new RegionInfo(updateCustCountryText.Text);
                    updateCustCountryErr.Visible = false;
                    errorCount = false;
                }
                catch
                {
                    updateCustCountryErr.Visible = true;
                    updateCustCountryErr.Text = "Enter 2 letter country code";
                    errorCount = true;
                }
            }
        }
        public void SearchValidationCheck()
        {
            if (String.IsNullOrEmpty(updateCustSearchText.Text) || String.IsNullOrWhiteSpace(updateCustSearchText.Text))
            {
                updateCustSearchErr.Text = "Search Required";
                updateCustSearchErr.Visible = true;
                errorCount = true;
            }
            else if (updateCustSearchErr.Text.Any(Char.IsLetter) || updateCustSearchErr.Text.Any(Char.IsSymbol) || updateCustSearchErr.Text.Any(Char.IsPunctuation))
            {
                updateCustSearchErr.Text = "Invalid ID";
                updateCustSearchErr.Visible = true;
                errorCount = true;
            }
            else
            {
                updateCustSearchErr.Visible = false;
                errorCount = false;
            }
        }

        private void updateCustSearchBtn_Click(object sender, EventArgs e)
        {
            SearchValidationCheck();
            //Search database to popualte fields with the correct customer info
            int addressID = 0;
            int cityID = 0;
            int countryID = 0;

            try
            {
                updateCustSearchErr.Visible = false;
                errorCount = false;
                using (MySqlConnection c = new MySqlConnection(cu.sqlConnectionString))
                {
                    c.Open();
                    MySqlDataReader reader;

                    using (MySqlCommand customerCmd = new MySqlCommand($"SELECT * FROM customer WHERE customerId = {Convert.ToInt32(updateCustSearchText.Text)}", c))
                    {
                        reader = customerCmd.ExecuteReader();

                        if (reader.Read())
                        {
                            updateCustNameText.Text = reader[1].ToString();

                            addressID = Convert.ToInt32(reader[2]);
                        }

                        reader.Close();
                        reader.Dispose();
                    }
                    using (MySqlCommand addressCmd = new MySqlCommand($"SELECT * FROM address WHERE addressId = {addressID}", c))
                    {
                        reader = addressCmd.ExecuteReader();
                        if (reader.Read())
                        {
                            updateCustAddressText.Text = reader[1].ToString();
                            updateCustZipText.Text = reader[4].ToString();
                            updateCustPhoneText.Text = reader[5].ToString();

                            cityID = Convert.ToInt32(reader[3]);
                        }

                        reader.Close();
                        reader.Dispose();
                    }
                    using (MySqlCommand cityCmd = new MySqlCommand($"SELECT * FROM city WHERE cityId = {cityID}", c))
                    {
                        reader = cityCmd.ExecuteReader();
                        if (reader.Read())
                        {
                            updateCustCityText.Text = reader[1].ToString();

                            countryID = Convert.ToInt32(reader[2]);
                        }

                        reader.Close();
                        reader.Dispose();
                    }
                    using (MySqlCommand countryCmd = new MySqlCommand($"SELECT * FROM country WHERE countryId = {countryID}", c))
                    {
                        reader = countryCmd.ExecuteReader();
                        if (reader.Read())
                        {
                            updateCustCountryText.Text = reader[1].ToString();
                        }

                        reader.Close();
                        reader.Dispose();
                    }
                    c.Close();

                }
            } catch
            {
                updateCustSearchErr.Text = "Customer ID not found";
                updateCustSearchErr.Visible = true;
                errorCount = true;
            }
            
        }
    }
}
