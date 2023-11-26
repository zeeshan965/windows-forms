namespace TodoLIstApp.tasks.add
{
    partial class AddTaskForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private Label lblTitle;
        private TextBox txtTitle;

        private Label lblDescription;
        private TextBox txtDescription;

        private Button btnCreate;
        private Label lblErrorTitle;

        private ComboBox cmbRoles;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitle = new Label();
            txtTitle = new TextBox();
            lblDescription = new Label();
            txtDescription = new TextBox();
            btnCreate = new Button();
            cmbRoles = new ComboBox();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Location = new Point(20, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(100, 23);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Title:";
            lblTitle.Click += lblTitle_Click;
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(122, 20);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(300, 23);
            txtTitle.TabIndex = 1;
            txtTitle.TextChanged += txtTilte_TextChanged;
            // 
            // lblDescription
            // 
            lblDescription.Location = new Point(16, 111);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(100, 23);
            lblDescription.TabIndex = 2;
            lblDescription.Text = "Description:";
            lblDescription.Click += lblDescription_Click;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(122, 75);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.ScrollBars = ScrollBars.Vertical;
            txtDescription.Size = new Size(300, 100);
            txtDescription.TabIndex = 3;
            txtDescription.TextChanged += txtDescription_TextChanged;
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(122, 265);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(75, 23);
            btnCreate.TabIndex = 4;
            btnCreate.Text = "Create Task";
            btnCreate.Click += btnCreate_Click;
            // 
            // cmbRoles
            // 
            cmbRoles.Location = new Point(122, 210);
            cmbRoles.Name = "cmbRoles";
            cmbRoles.Size = new Size(300, 23);
            cmbRoles.TabIndex = 5;
            // 
            // AddTaskForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblTitle);
            Controls.Add(txtTitle);
            Controls.Add(lblDescription);
            Controls.Add(txtDescription);
            Controls.Add(btnCreate);
            Controls.Add(cmbRoles);
            Name = "AddTaskForm";
            Text = "AddTaskForm";
            FormClosing += createTaskForm_FormClosing;
            Load += AddTaskForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private void InitializeErrorLabels()
        {
            lblErrorTitle = new Label();
            lblErrorTitle.ForeColor = Color.Red;
            lblErrorTitle.Location = new Point(120, 43);
            lblErrorTitle.AutoSize = true;
            Controls.Add(lblErrorTitle);
        }

        #endregion
    }
}