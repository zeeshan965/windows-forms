using MySql.Data.MySqlClient;
using TodoLIstApp.DataBase;
using TodoLIstApp.RolesListing;

namespace TodoLIstApp.tasks.add
{
    public partial class AddTaskForm : Form
    {
        private List<Category> categories;

        public event EventHandler FormClosedEvent;

        public AddTaskForm()
        {
            InitializeComponent();
            InitializeErrorLabels();
        }

        private void AddTaskForm_Load(object sender, EventArgs e)
        {
            LoadCategories();
        }

        private void LoadCategories()
        {
            try
            {
                using (MySqlConnection connection = DatabaseHelper.GetOpenConnection())
                {
                    string query = "SELECT id, name FROM categories";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            categories = new List<Category>();
                            while (reader.Read())
                            {
                                Category category = new Category
                                {
                                    Id = reader.GetInt32("id"),
                                    Name = reader.GetString("name")
                                };
                                categories.Add(category);
                            }
                        }
                    }
                }

                // Populate the dropdown with roles
                cmbRoles.DataSource = categories;
                cmbRoles.DisplayMember = "Name";
                cmbRoles.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
            }
        }

        private void txtTilte_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCreate_Click(object sender, EventArgs e)
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
                int categoryId = (int)cmbRoles.SelectedValue;

                ProcessForm(title, description, categoryId);
            }
        }

        private void ProcessForm(string title, string description, int categoryId)
        {
            try
            {
                using (MySqlConnection connection = DatabaseHelper.GetOpenConnection())
                {
                    string query = "INSERT into tasks (title, description, category_id) " +
                        "VALUES (@title, @description, @category_id)";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@title", title);
                        command.Parameters.AddWithValue("@description", description);
                        command.Parameters.AddWithValue("@category_id", categoryId);

                        int rowsAffected = command.ExecuteNonQuery();
                        connection.Close();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Task created successfully.");
                            Close(); // Close the form after successful update
                        }
                        else
                        {
                            MessageBox.Show("Task creation failed.");
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

        private void createTaskForm_FormClosing(object sender, EventArgs e)
        {
            // Notify the main form about the closing
            FormClosedEvent?.Invoke(this, EventArgs.Empty);
        }
    }
}
