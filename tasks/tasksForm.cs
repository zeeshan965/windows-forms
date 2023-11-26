using MySql.Data.MySqlClient;
using System.Data;
using System.Diagnostics;
using TodoLIstApp.categories;
using TodoLIstApp.DataBase;
using TodoLIstApp.tasks.add;
using TodoLIstApp.tasks.update;

namespace TodoLIstApp.tasks
{
    public partial class tasksForm : Form
    {
        private readonly DataTable tasksDataTable;
        private readonly DataGridView dataGridViewTasks;

        public tasksForm()
        {
            InitializeComponent();
            tasksDataTable = new DataTable();

            // Create a DataGridView and set its properties
            dataGridViewTasks = new DataGridView
            {
                Name = "dataGridViewTasks",
                Dock = DockStyle.Fill,
                AutoGenerateColumns = false,
                DataSource = tasksDataTable
            };

            // Manually add columns to the DataGridView
            dataGridViewTasks.Columns.AddRange(
                new DataGridViewTextBoxColumn { DataPropertyName = "id", HeaderText = "ID", Width = 50 },
                new DataGridViewTextBoxColumn { DataPropertyName = "name", HeaderText = "Category", Width = 100 },
                new DataGridViewTextBoxColumn { DataPropertyName = "title", HeaderText = "Title", Width = 180 },
                new DataGridViewTextBoxColumn { DataPropertyName = "description", HeaderText = "Description", Width = 400 },
                new DataGridViewTextBoxColumn { DataPropertyName = "created_at", HeaderText = "Created At" },
                // Add a single "Actions" column with buttons
                new DataGridViewButtonColumn
                {
                    HeaderText = "Update Task",
                    Text = "Update",
                    UseColumnTextForButtonValue = true,
                    Name = "update-task",
                    FlatStyle = FlatStyle.Popup,
                    ToolTipText = "Update task!",
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
                    Name = "delete-task",
                    FlatStyle = FlatStyle.Popup,
                    ToolTipText = "Delete task!",
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
            dataGridViewTasks.CellContentClick += DataGridViewTasks_CellContentClick;


            // Add the DataGridView to the form's controls
            Controls.Add(dataGridViewTasks);
        }

        private void tasksForm_Load(object sender, EventArgs e)
        {
            // Load tasks from the database
            LoadTasks();
        }

        private void DataGridViewTasks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var columnName = dataGridViewTasks.Columns[e.ColumnIndex].Name;

                if (columnName == "update-task")
                {
                    DataGridViewRow selectedRow = dataGridViewTasks.Rows[e.RowIndex];
                    Debug.WriteLine("********************************");
                    Debug.WriteLine("********************************");

                    // Access the task ID from the "update-task" button cell's Tag
                    if (selectedRow.Cells["update-task"].Tag != null)
                    {
                        int taskId = Convert.ToInt32(selectedRow.Cells["update-task"].Tag);
                        Debug.WriteLine($"Task ID: {taskId}");

                        // Open the UpdateTaskForm for the selected task
                        UpdateTaskForm updateTaskForm = new UpdateTaskForm(taskId);
                        updateTaskForm.FormClosedEvent += UpdateTaskForm_FormClosedEvent;
                        updateTaskForm.Show();
                    }

                    Debug.WriteLine("********************************");
                    Debug.WriteLine("********************************");

                    //MessageBox.Show("Update button clicked for row " + e.RowIndex);
                }
                else if (columnName == "delete-task")
                {
                    DataGridViewRow selectedRow = dataGridViewTasks.Rows[e.RowIndex];
                    int taskId = Convert.ToInt32(selectedRow.Cells["update-task"].Tag);
                    // Prompt the user for confirmation
                    DialogResult result = MessageBox.Show("Are you sure you want to delete this task?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        // User confirmed, proceed with task deletion
                        DeleteTask(taskId);
                    }
                }
            }
        }

        private void DeleteTask(int taskId)
        {
            try
            {
                using (MySqlConnection connection = DatabaseHelper.GetOpenConnection())
                {
                    string query = "DELETE FROM tasks WHERE id = @taskId";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@taskId", taskId);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Task deleted successfully.");
                            // Refresh the task listings after deletion
                            LoadTasks();
                        }
                        else
                        {
                            MessageBox.Show("Task deletion failed.");
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

        private void UpdateTaskForm_FormClosedEvent(object sender, EventArgs e)
        {
            // Refresh the task listings when UpdateTaskForm is closed
            LoadTasks();
        }

        private void LoadTasks()
        {
            try
            {
                using (MySqlConnection connection = DatabaseHelper.GetOpenConnection())
                {
                    string query = "select t.id, c.name, t.title, t.description, t.created_at from tasks as t " +
                        "inner join categories as c on c.id = t.category_id;";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            tasksDataTable.Clear(); // Clear existing data
                            adapter.Fill(tasksDataTable);

                            for (int i = 0; i < tasksDataTable.Rows.Count; i++)
                            {
                                DataGridViewRow row = dataGridViewTasks.Rows[i];

                                // Get the DataRowView associated with the current row
                                if (row.DataBoundItem is DataRowView dataRowView)
                                {
                                    // Access the "id" column from the DataRowView
                                    if (dataRowView.Row["id"] != DBNull.Value)
                                    {
                                        int taskId = Convert.ToInt32(dataRowView.Row["id"]);
                                        Debug.WriteLine(taskId);
                                        // Set the task ID as the Tag for the "Update Task" button cell
                                        row.Cells["update-task"].Tag = taskId;
                                        row.Cells["delete-task"].Tag = taskId;
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

        private void BtnAddTask_Click(object sender, EventArgs e)
        {
            AddTaskForm addTaskForm = new AddTaskForm();
            addTaskForm.FormClosed += CreateTaskForm_FormClosed;
            addTaskForm.Show();
        }

        private void CreateTaskForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Refresh the task listings when the CreateTaskForm is closed
            LoadTasks();
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
            CategoryForm categoryForm = new CategoryForm();
            categoryForm.Show();
        }
    }
}
