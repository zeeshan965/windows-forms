using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TodoLIstApp.DataBase;

namespace TodoLIstApp
{
    public partial class SignUpForm : Form
    {
        public SignUpForm()
        {
            InitializeComponent();
            InitializeErrorLabels();
        }

        private void SignUpForm_Load(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {


        }

        private void BtnSignUp_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //reset errors
            lblErrorEmail.Text = "";
            lblErrorPassword.Text = "";
            lblErrorName.Text = "";
            lblErrorConfirmPassword.Text = "";



            if (ValidateFormData())
            {
                // Successful login logic here
                //MessageBox.Show("Login successful!");
                string name = txtName.Text.Trim();

                string email = txtEmail.Text.Trim();//txtLoginEmail.Text.Trim();
                string password = txtPassword.Text.Trim();//txtLoginPassword.Text;
                string ConfirmPassword = txtConfirmPassword.Text.Trim();
                string hashedPassword = SecurityUtils.HashPassword(ConfirmPassword);
                bool status = register(name, email, hashedPassword);

                if(status)
                {
                    this.Hide();
                    loginForm loginForm = new loginForm();
                    loginForm.Show();

                }
            }
            

        }



        private bool ValidateFormData()
        {
            bool valid = true;
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();
            string confirmPassword = txtConfirmPassword.Text.Trim();
            string name = txtName.Text.Trim();

            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("-----------------------------------------");
            Debug.WriteLine(email);
            Debug.WriteLine(name);
            Debug.WriteLine(password);
            Debug.WriteLine(confirmPassword);

            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("-----------------------------------------");

            // Check if the email is not empty and matches the specified regex pattern
            string emailRegexPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            // Check if the password is not empty and meets the specified criteria
            string passwordRegexPattern = @"^(?=.*[A-Za-z])(?=.*\d).{8,}$";

            if (string.IsNullOrWhiteSpace(name))
            {
                lblErrorName.Text = "Please enter valid name";
                valid = false;
            }

            if (string.IsNullOrWhiteSpace(email) || !Regex.IsMatch(email, emailRegexPattern))
            {
                lblErrorEmail.Text = "Please enter a valid email address.";
                valid = false;
            }

            if (string.IsNullOrWhiteSpace(password) || !Regex.IsMatch(password, passwordRegexPattern))
            {
                lblErrorPassword.Text = "Please enter a valid password (at least 8 characters, including at least one alphabet and one number).";
                valid = false;
            }

            if (string.IsNullOrWhiteSpace(password) || confirmPassword != password)
            {
                lblErrorConfirmPassword.Text = "Please enter same password";
                valid = false;
            }

            return valid;

        }


        private bool register(string name, string email, string password)
        {
            try
            {
                using (MySqlConnection connection = DatabaseHelper.GetOpenConnection())
                {
                    // Assuming your Users table has columns: Name, Email, Password
                    string query = "INSERT INTO users (name, email, password) VALUES (@Name, @Email, @Password)"; 

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@Password", password);

                        int rowsAffected = command.ExecuteNonQuery();
                        connection.Close();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle database error
                MessageBox.Show("Database error: " + ex.Message);
                return false;

            }
        


        }


        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void lnkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            loginForm loginForm = new loginForm();
            loginForm.Show();
        }

        private void lblName_Click(object sender, EventArgs e)
        {

        }
    }
}




