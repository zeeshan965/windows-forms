using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using TodoLIstApp.DataBase;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace TodoLIstApp.tasks.update
{
    public partial class UpdateTaskForm : Form
    {
        private readonly int taskId;
        public event EventHandler FormClosedEvent;

        public UpdateTaskForm(int taskId)
        {
            InitializeComponent();
            InitializeErrorLabels();

            this.taskId = taskId;

            // Load and display the task details in the form
            LoadTaskDetails();

        }

        private void LoadTaskDetails()
        {
            try
            {
                using (MySqlConnection connection = DatabaseHelper.GetOpenConnection())
                {
                    // Assuming you have a stored procedure or query to get task details by ID
                    string query = "SELECT * FROM tasks WHERE id = @taskId";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@taskId", taskId);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Debug.WriteLine(reader["description"].ToString());
                                // Populate the form fields with task details
                                txtTitle.Text = reader["title"].ToString();
                                txtDescription.Text = reader["description"].ToString();
                                // Add other fields as needed
                            }
                            else
                            {
                                MessageBox.Show("Task not found.");
                                Close(); // Close the form if the task is not found
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
            }
        }

        private void UpdateTaskForm_Load(object sender, EventArgs e)
        {

        }

        private void txtTilte_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Reset error labels
            lblErrorTitle.Text = "";
            // Perform validation and then update
            if (ValidateFormData())
            {
                // Successful login logic here
                //MessageBox.Show("Login successful!");
                string title = txtTitle.Text.Trim();
                string description = txtDescription.Text.Trim();
                
                ProcessLogin(title, description);
            }
        }

        private void ProcessLogin(string title, string description)
        {
            try
            {
                using (MySqlConnection connection = DatabaseHelper.GetOpenConnection())
                {
                    string query = "UPDATE tasks SET title = @title, description = @description WHERE id = @taskId";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@title", title);
                        command.Parameters.AddWithValue("@description", description);
                        command.Parameters.AddWithValue("@taskId", taskId);

                        int rowsAffected = command.ExecuteNonQuery();
                        connection.Close();
                        if(rowsAffected > 0) {
                            MessageBox.Show("Task updated successfully.");
                            Close(); // Close the form after successful update
                        }
                        else {
                            MessageBox.Show("Task update failed.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle database error
                MessageBox.Show("Database error: " + ex.Message);
            }
        }
        
        private bool ValidateFormData()
        {
            bool valid = true;
            string title = txtTitle.Text.Trim();
            if (string.IsNullOrWhiteSpace(title))
            {
                lblErrorTitle.Text = "Please enter some task";
                valid = false;
            }
            return valid;
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void lblDescription_Click(object sender, EventArgs e)
        {

        }
        
        private void updateTaskForm_FormClosing(object sender, EventArgs e)
        {
            // Notify the main form about the closing
            FormClosedEvent?.Invoke(this, EventArgs.Empty);
        }
    }
}
