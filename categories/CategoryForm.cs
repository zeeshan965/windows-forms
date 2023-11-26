using MySql.Data.MySqlClient;
using System.Data;
using System.Diagnostics;
using TodoLIstApp.categories.addCategory;
using TodoLIstApp.categories.updateCategory;
using TodoLIstApp.DataBase;
using TodoLIstApp.tasks;

namespace TodoLIstApp.categories
{
    public partial class CategoryForm : Form
    {
        private readonly DataTable categoryDataTable;
        private readonly DataGridView dataGridViewCategories;
        public CategoryForm()
        {
            InitializeComponent();
            categoryDataTable = new DataTable();

            dataGridViewCategories = new DataGridView
            {
                Name = "dataGridViewCategories",
                Dock = DockStyle.Fill,
                AutoGenerateColumns = false,
                DataSource = categoryDataTable
            };

            // Manually add columns to the DataGridView
            dataGridViewCategories.Columns.AddRange(
                new DataGridViewTextBoxColumn { DataPropertyName = "id", HeaderText = "ID" },
                new DataGridViewTextBoxColumn { DataPropertyName = "name", HeaderText = "Category" },
                new DataGridViewTextBoxColumn { DataPropertyName = "created_at", HeaderText = "Created At" },
                // Add a single "Actions" column with buttons


                // Add a single "Actions" column with buttons
                new DataGridViewButtonColumn
                {
                    HeaderText = "Update",
                    Text = "Update",
                    UseColumnTextForButtonValue = true,
                    Name = "update",
                    FlatStyle = FlatStyle.Popup,
                    ToolTipText = "Update!",
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        BackColor = Color.CadetBlue, // Set the background color
                        ForeColor = Color.White, // Set the text color
                        Alignment = DataGridViewContentAlignment.MiddleCenter
                    },
                    Width = 60 // Adjust the width of the button
                },
                new DataGridViewButtonColumn
                {
                    Text = "Delete",
                    UseColumnTextForButtonValue = true,
                    Name = "delete",
                    FlatStyle = FlatStyle.Popup,
                    ToolTipText = "Delete!",
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        BackColor = Color.Red, // Set the background color
                        ForeColor = Color.White, // Set the text color
                        Alignment = DataGridViewContentAlignment.MiddleCenter
                    },
                    Width = 60 // Adjust the width of the button
                }

            );

            // Subscribe to the CellContentClick event to handle button clicks
            dataGridViewCategories.CellContentClick += dataGridViewCategories_CellContentClick;


            // Add the DataGridView to the form's controls
            Controls.Add(dataGridViewCategories);

        }

        private void CategoryForm_Load(object sender, EventArgs e)
        {
            LoadCategories();
        }


        private void dataGridViewCategories_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                var columnName = dataGridViewCategories.Columns[e.ColumnIndex].Name;

                if (columnName == "update")
                {
                    DataGridViewRow selectedRow = dataGridViewCategories.Rows[e.RowIndex];
                    Debug.WriteLine("********************************");
                    Debug.WriteLine("********************************");

                    // Access the  ID from the "update" button cell's Tag
                    if (selectedRow.Cells["update"].Tag != null)
                    {
                        int Id = Convert.ToInt32(selectedRow.Cells["update"].Tag);
                        Debug.WriteLine($" ID: {Id}");

                        // Open the UpdateTaskForm for the selected task
                        UpdateCategoryForm updateCategoryForm = new UpdateCategoryForm(Id);
                        updateCategoryForm.FormClosedEvent += UpdateForm_FormClosedEvent;
                        updateCategoryForm.Show();
                    }

                    Debug.WriteLine("********************************");
                    Debug.WriteLine("********************************");

                    //MessageBox.Show("Update button clicked for row " + e.RowIndex);
                }
                else if (columnName == "delete")
                {
                    DataGridViewRow selectedRow = dataGridViewCategories.Rows[e.RowIndex];
                    int Id = Convert.ToInt32(selectedRow.Cells["delete"].Tag);
                    // Prompt the user for confirmation
                    DialogResult result = MessageBox.Show("Are you sure you want to delete this category?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        // User confirmed, proceed with task deletion
                        DeleteCategory(Id);
                    }
                }
            }

        }

        private void UpdateForm_FormClosedEvent(object sender, EventArgs e)
        {
            // Refresh the task listings when UpdateTaskForm is closed
            LoadCategories();
        }

        private void LoadCategories()
        {
            try
            {
                using (MySqlConnection connection = DatabaseHelper.GetOpenConnection())
                {
                    string query = "select c.id, c.name, c.created_at from categories as c ";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            categoryDataTable.Clear(); // Clear existing data
                            adapter.Fill(categoryDataTable);

                            for (int i = 0; i < categoryDataTable.Rows.Count; i++)
                            {
                                DataGridViewRow row = dataGridViewCategories.Rows[i];

                                // Get the DataRowView associated with the current row
                                if (row.DataBoundItem is DataRowView dataRowView)
                                {
                                    // Access the "id" column from the DataRowView
                                    if (dataRowView.Row["id"] != DBNull.Value)
                                    {
                                        int Id = Convert.ToInt32(dataRowView.Row["id"]);
                                        Debug.WriteLine(Id);
                                        // Set the task ID as the Tag for the "Update Task" button cell
                                        row.Cells["update"].Tag = Id;
                                        row.Cells["delete"].Tag = Id;
                                    }
                                }
                            }


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

        private void DeleteCategory(int Id)
        {
            try
            {
                using (MySqlConnection connection = DatabaseHelper.GetOpenConnection())
                {
                    string query = "DELETE FROM categories WHERE id = @Id";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", Id);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("deleted successfully.");
                            LoadCategories();
                        }
                        else
                        {
                            MessageBox.Show("deletion failed.");
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

        private void BtnAddTask_Click(object sender, EventArgs e)
        {
            AddCategoryForm addCategoryForm = new AddCategoryForm();
            addCategoryForm.FormClosed += CreateForm_FormClosed;
            addCategoryForm.Show();
        }

        private void CreateForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Refresh the task listings when the CreateTaskForm is closed
            LoadCategories();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            loginForm loginPage = new loginForm();
            loginPage.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            tasksForm tasksPage = new tasksForm();
            tasksPage.Show();
        }
    }
}
