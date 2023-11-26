
using MySql.Data.MySqlClient;
using System.Xml.Linq;
using TodoLIstApp.DataBase;

namespace TodoLIstApp.categories.addCategory
{
    public partial class AddCategoryForm : Form
    {
        public event EventHandler FormClosedEvent;

        public AddCategoryForm()
        {
            InitializeComponent();
            InitializeErrorLabels();
        }

        private void AddCategoryForm_Load(object sender, EventArgs e)
        {

        }

        private void updateForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormClosedEvent?.Invoke(this, EventArgs.Empty);
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            // Reset error labels
            lblErrorName.Text = "";
            // Perform validation and then update
            if (ValidateFormData())
            {
                string name = txtName.Text.Trim();
                ProcessForm(name);
            }
        }

        private void ProcessForm(string name)
        {
            try
            {
                using (MySqlConnection connection = DatabaseHelper.GetOpenConnection())
                {
                    string query = "INSERT into categories (name) VALUES (@name)";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@name", name);

                        int rowsAffected = command.ExecuteNonQuery();
                        connection.Close();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("category saved successfully.");
                            Close(); // Close the form after successful update
                        }
                        else
                        {
                            MessageBox.Show("category save failed.");
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
            string title = txtName.Text.Trim();
            if (string.IsNullOrWhiteSpace(title))
            {
                lblErrorName.Text = "Please enter name for category";
                valid = false;
            }
            return valid;
        }

        private void lblName_Click(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
