using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gavin_Fahey_C969_PA
{
    public partial class loginForm : Form
    {
        //login error message declared and used for both english and other language solutions.
        public string errorMsgBox = "Username and Password do not match.";
        public string errorMsgBoxCaption = "Unsuccessful Login";

        CurrentUser cu = new CurrentUser();

        public loginForm()
        {
            InitializeComponent();

            //check if user system is using German language
            //change login form text if so.
            if (CultureInfo.CurrentUICulture.Name == "de-DE")
            {
                loginMainLabel.Text = "Melden Sie sich unten an";
                usernameLabel.Text = "Nutzername";
                passwordLabel.Text = "Passwort";
                loginBtn.Text = "Anmeldung";
                cancelBtn.Text = "Stornieren";
                errorMsgBox = "Benutzername und Passwort stimmen nicht überein.";
                errorMsgBoxCaption = "Anmeldung fehlgeschlagen";
            }
        }

        public int UserExistsCheck(string username, string pass)
        {
            
            //Connect to SQL DB, search for user that matches username and password used
            MySqlConnection c = new MySqlConnection(cu.sqlConnectionString);
            c.Open();
            MySqlCommand cmd = new MySqlCommand($"SELECT userId FROM user WHERE userName = '{username}' AND password = '{pass}'", c);
            MySqlDataReader reader = cmd.ExecuteReader();

            //if user is found use CurrentUser class to set user info and return user info to be used
            if (reader.HasRows)
            {
                reader.Read();
                cu.setCurrentUserID(Convert.ToInt32(reader[0]));
                CurrentUser.setCurrentUsername(username);
                reader.Close();
                c.Close();
                return cu.getCurrentUserID();
            }
            return -1;
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            //checking if user exists if so successfully login or provide error
            if(UserExistsCheck(usernameText.Text, passwordText.Text) != -1)
            {
                Main m = new Main();                  
                Hide();

                //log user login data and write to file
                File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "userlog.txt", "User: " + CurrentUser.getCurrentUsername() + ", logged in at " + DateTime.Now.ToString("f") + Environment.NewLine);

                m.ShowDialog();
                Close();
            } else
            {
                MessageBox.Show(errorMsgBox, errorMsgBoxCaption);
                passwordText.Text = "";
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void loginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
