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
    public partial class AddCustomerForm : Form
    {
        CurrentUser cu = new CurrentUser();
        bool errorCount = false;
        public AddCustomerForm()
        {
            InitializeComponent();
        }

        private void addCustCancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void addCustCreateBtn_Click(object sender, EventArgs e)
        {
            string ct = DateTime.Now.ToString("u");
            string username = CurrentUser.getCurrentUsername();

            NameValidationCheck();
            PhoneValidationCheck();
            AddressValidationCheck();
            CityValidationCheck();
            ZipValidationCheck();
            CountryValidationCheck();            

            if (!errorCount)
            {
                //get countryID used to create record
                string countryID = cu.setCountryID(addCustCountryText.Text);
                string cityID = cu.setCityID(addCustCityText.Text);
                string addressID = cu.setAddressID();
                string customerID = cu.setCustomerID();

                MySqlConnection c = new MySqlConnection(cu.sqlConnectionString);
                c.Open();

                if (countryID.Contains("New ID")) 
                {
                    //turn new id into a single int number
                    countryID = countryID.Replace("New ID ", "");
                    
                    //Insert new country record
                    MySqlCommand countryCmd = new MySqlCommand($"INSERT INTO country VALUES ('{Convert.ToInt32(countryID)}', '{addCustCountryText.Text}', '{ct}', '{username}', '{ct}', '{username}')", c);
                    countryCmd.ExecuteNonQuery();
                }

                if (cityID.Contains("New ID"))
                {
                    //turn new id into a single int number
                    cityID = cityID.Replace("New ID ", "");

                    //Insert new city record
                    MySqlCommand cityCmd = new MySqlCommand($"INSERT INTO city VALUES ('{Convert.ToInt32(cityID)}', '{addCustCityText.Text}', '{Convert.ToInt32(countryID)}', '{ct}', '{username}', '{ct}', '{username}')", c);
                    cityCmd.ExecuteNonQuery();
                }

                //Insert new address record
                MySqlCommand addressCmd = new MySqlCommand($"INSERT INTO address VALUES ('{Convert.ToInt32(addressID)}', '{addCustAddressText.Text}', '', '{Convert.ToInt32(cityID)}', '{addCustZipText.Text}', '{addCustPhoneText.Text}', '{ct}', '{username}', '{ct}', '{username}')", c);
                addressCmd.ExecuteNonQuery();

                //Insert new customer record
                MySqlCommand customerCmd = new MySqlCommand($"INSERT INTO customer VALUES ('{Convert.ToInt32(customerID)}', '{addCustNameText.Text}', '{Convert.ToInt32(addressID)}', '{1}', '{ct}', '{username}', '{ct}', '{username}')", c);
                customerCmd.ExecuteNonQuery();

                MessageBox.Show("Successfully created customer record.", "Success");
                Close();
            }
        }

        public void NameValidationCheck()
        {
            if(String.IsNullOrEmpty(addCustNameText.Text) || String.IsNullOrWhiteSpace(addCustNameText.Text))
            {
                addCustNameErr.Text = "Name Required";
                addCustNameErr.Visible = true;
                errorCount = true;
            } else if(addCustNameText.Text.Any(Char.IsDigit) || addCustNameText.Text.Any(Char.IsSymbol) || addCustNameText.Text.Any(Char.IsPunctuation))
            {
                addCustNameErr.Text = "Only letters";
                addCustNameErr.Visible = true;
                errorCount = true;
            } else
            {
                addCustNameErr.Visible = false;
                errorCount = false;
            }
        }
        public void PhoneValidationCheck()
        {
            if (String.IsNullOrEmpty(addCustPhoneText.Text) || String.IsNullOrWhiteSpace(addCustPhoneText.Text))
            {
                addCustPhoneErr.Text = "Phone Required";
                addCustPhoneErr.Visible = true;
                errorCount = true;
            }
            else if (addCustPhoneText.Text.Any(Char.IsLetter) || addCustPhoneText.Text.Any(Char.IsSymbol) || addCustPhoneText.Text.Any(Char.IsPunctuation))
            {
                addCustPhoneErr.Text = "Only numbers";
                addCustPhoneErr.Visible = true;
                errorCount = true;
            }
            else
            {
                addCustPhoneErr.Visible = false;
                errorCount = false;
            }
        }
        public void AddressValidationCheck()
        {
            if (String.IsNullOrEmpty(addCustAddressText.Text) || String.IsNullOrWhiteSpace(addCustAddressText.Text))
            {
                addCustAddressErr.Text = "Address Required";
                addCustAddressErr.Visible = true;
                errorCount = true;
            }
            else if (addCustAddressText.Text.Any(Char.IsPunctuation) || addCustAddressText.Text.Any(Char.IsSymbol))
            {
                addCustAddressErr.Text = "Only numbers and letters";
                addCustAddressErr.Visible = true;
                errorCount = true;
            }
            else
            {
                addCustAddressErr.Visible = false;
                errorCount = false;
            }
        }
        public void CityValidationCheck()
        {
            if (String.IsNullOrEmpty(addCustCityText.Text) || String.IsNullOrWhiteSpace(addCustCityText.Text))
            {
                addCustCityErr.Text = "City Required";
                addCustCityErr.Visible = true;
                errorCount = true;
            }
            else if (addCustCityText.Text.Any(Char.IsDigit) || addCustCityText.Text.Any(Char.IsSymbol) || addCustCityText.Text.Any(Char.IsPunctuation))
            {
                addCustCityErr.Text = "Only letters";
                addCustCityErr.Visible = true;
                errorCount = true;
            }
            else
            {
                addCustCityErr.Visible = false;
                errorCount = false;
            }
        }
        public void ZipValidationCheck()
        {
            if (String.IsNullOrEmpty(addCustZipText.Text) || String.IsNullOrWhiteSpace(addCustZipText.Text))
            {
                addCustZipErr.Text = "Zip Code Required";
                addCustZipErr.Visible = true;
                errorCount = true;
            }
            else if (addCustZipText.Text.Any(Char.IsLetter) || addCustZipText.Text.Any(Char.IsSymbol) || addCustZipText.Text.Any(Char.IsPunctuation))
            {
                addCustZipErr.Text = "Only numbers";
                addCustZipErr.Visible = true;
                errorCount = true;
            }
            else
            {
                if (addCustZipText.Text.Length < 11)
                {
                    addCustZipErr.Visible = false;
                    errorCount = false;
                }
                else
                {
                    addCustZipErr.Text = "Invalid Zip Code";
                    addCustZipErr.Visible = true;
                    errorCount = true;
                }
            }
        }
        public void CountryValidationCheck()
        {
            if (String.IsNullOrEmpty(addCustCountryText.Text) || String.IsNullOrWhiteSpace(addCustCountryText.Text))
            {
                addCustCountryErr.Text = "Country Required";
                addCustCountryErr.Visible = true;
                errorCount = true;
            }
            else if (addCustCountryText.Text.Any(Char.IsDigit) || addCustCountryText.Text.Any(Char.IsSymbol) || addCustCountryText.Text.Any(Char.IsPunctuation))
            {
                addCustCountryErr.Text = "Only letters";
                addCustCountryErr.Visible = true;
                errorCount = true;
            }
            else
            {
                try
                {
                    RegionInfo countryCode = new RegionInfo(addCustCountryText.Text);
                    addCustCountryErr.Visible = false;
                    errorCount = false;
                }
                catch
                {
                    addCustCountryErr.Visible = true;
                    addCustCountryErr.Text = "Enter 2 letter country code";
                    errorCount = true;
                }                
            }
        }
    }
}
