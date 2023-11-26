using MySql.Data.MySqlClient;
using TodoLIstApp.DataBase;

namespace TodoLIstApp.categories.updateCategory
{
    public partial class UpdateCategoryForm : Form
    {
        private readonly int id;
        public event EventHandler FormClosedEvent;
        
		public UpdateCategoryForm(int id)
        {
            InitializeComponent();
            this.id = id;
            InitializeErrorLabels();
            LoadCategoryDetails();

        }

        private void UpdateCategoryForm_Load(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Reset error labels
            lblErrorTitle.Text = "";
            // Perform validation and then update
            if (ValidateFormData())
            {
                string title = txtTitle.Text.Trim();
                ProcessForm(title);
            }
        }

        private void ProcessForm(string title)
        {
            try
            {
                using (MySqlConnection connection = DatabaseHelper.GetOpenConnection())
                {
                    string query = "UPDATE categories SET name = @title WHERE id = @id";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@title", title);
                        command.Parameters.AddWithValue("@id", id);

                        int rowsAffected = command.ExecuteNonQuery();
                        connection.Close();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("updated successfully.");
                            Close(); // Close the form after successful update
                        }
                        else
                        {
                            MessageBox.Show("update failed.");
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
                lblErrorTitle.Text = "Please enter name for category";
                valid = false;
            }
            return valid;
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void txtTilte_TextChanged(object sender, EventArgs e)
        {

        }
        
		private void updateForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormClosedEvent?.Invoke(this, EventArgs.Empty);
        }

        private void LoadCategoryDetails()
        {
            try
            {
                using (MySqlConnection connection = DatabaseHelper.GetOpenConnection())
                {
                    // Assuming you have a stored procedure or query to get categ details by ID
                    string query = "SELECT * FROM categories WHERE id = @categoryId";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@categoryId", id);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtTitle.Text = reader["name"].ToString();
                                
                            }
                            else
                            {
                                MessageBox.Show("category not found.");
                                Close(); // Close the form if the category is not found
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
    }
}
