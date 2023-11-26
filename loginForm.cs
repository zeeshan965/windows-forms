using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using TodoLIstApp.DataBase;
using TodoLIstApp.tasks;

namespace TodoLIstApp
{
    public partial class loginForm : Form
    {


        public loginForm()
        {
            InitializeComponent();//parent method call
            InitializeErrorLabels(); //intialize error labels
        }

        private void loginForm_Load(object sender, EventArgs e)
        {



        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Reset error labels
            lblErrorEmail.Text = "";
            lblErrorPassword.Text = "";

            // Perform email and password validation
            if (ValidateFormData())
            {
                // Successful login logic here
                //MessageBox.Show("Login successful!");
                string email = txtLoginEmail.Text.Trim();
                string password = txtLoginPassword.Text;
                ProcessLogin(email, password);
            }
        }

        private bool ValidateFormData()
        {
            bool valid = true;
            string email = txtLoginEmail.Text.Trim();
            string password = txtLoginPassword.Text;

            // Check if the email is not empty and matches the specified regex pattern
            string emailRegexPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            // Check if the password is not empty and meets the specified criteria
            string passwordRegexPattern = @"^(?=.*[A-Za-z])(?=.*\d).{8,}$";

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

            return valid;
        }

        private bool ProcessLogin(string email, string password)
        {
            try

            {
                using (MySqlConnection connection = DatabaseHelper.GetOpenConnection())
                {
                    // Assuming your Users table has columns: Name, Email, Password
                    string query = "SELECT * FROM users WHERE email = @Email";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Email", email);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // User found, now check the password
                                string storedPassword = reader["password"].ToString();

                                // Compare the stored hashed password with the input password
                                if (VerifyPassword(password, storedPassword))
                                {
                                    MessageBox.Show("Login successful!");

                                    // Close the current login form
                                    this.Hide();

                                    // Open the home screen form
                                    tasksForm taskForm = new tasksForm();
                                    taskForm.Show();

                                    return true;
                                }
                                else
                                {
                                    MessageBox.Show("Invalid password. Please try again.");
                                    return false;
                                }
                            }
                            else
                            {
                                MessageBox.Show("User not found. Please check your email address.");
                                return false;
                            }
                        }
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

        private bool VerifyPassword(string inputPassword, string storedHashedPassword)
        {
            // Verify the input password against the stored hashed password
            // You need to implement the same hashing algorithm used during registration


            string hashedInputPassword = SecurityUtils.HashPassword(inputPassword);
            return hashedInputPassword == storedHashedPassword;
        }

        private void lnkSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            SignUpForm signUpForm = new SignUpForm();
            signUpForm.Show();
        }

        private void txtLoginEmail_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
