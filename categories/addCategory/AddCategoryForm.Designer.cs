namespace TodoLIstApp.categories.addCategory
{
    partial class AddCategoryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private Label lblName;
        private TextBox txtName;
        private Button btnCreate;
        private Label lblErrorName;

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
            SuspendLayout();
            lblName = new Label();
            txtName = new TextBox();
            btnCreate = new Button();

            lblName.Location = new Point(20, 20);
            lblName.Name = "lblName";
            lblName.Size = new Size(100, 23);
            lblName.TabIndex = 0;
            lblName.Text = "Category Name:";
            lblName.Click += lblName_Click;
            // 
            // txtName
            // 
            txtName.Location = new Point(122, 20);
            txtName.Name = "txtName";
            txtName.Size = new Size(300, 23);
            txtName.TabIndex = 1;
            txtName.TextChanged += txtName_TextChanged;

            btnCreate.Location = new Point(122, 70);
            btnCreate.Name = "btnUpdate";
            btnCreate.Size = new Size(75, 23);
            btnCreate.TabIndex = 4;
            btnCreate.Text = "Create Category";
            btnCreate.Click += btnCreate_Click;

            FormClosing += new FormClosingEventHandler(updateForm_FormClosing);

            Controls.Add(lblName);
            Controls.Add(txtName);
            Controls.Add(btnCreate);
            StartPosition = FormStartPosition.CenterScreen;

            // 
            // AddCategoryForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Name = "AddCategoryForm";
            Text = "AddCategoryForm";
            Load += AddCategoryForm_Load;
            ResumeLayout(false);
        }

        private void InitializeErrorLabels()
        {
            // Create error labels for email and password
            lblErrorName = new Label();
            lblErrorName.ForeColor = Color.Red;
            lblErrorName.Location = new Point(120, 43);
            lblErrorName.AutoSize = true;
            Controls.Add(lblErrorName);
        }

        #endregion
    }
}