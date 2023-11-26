namespace TodoLIstApp.categories.updateCategory
{
    partial class UpdateCategoryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        private Label lblTitle;
        private TextBox txtTitle;
        private Button btnUpdate;

        private Label lblErrorTitle;
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

            lblTitle = new Label();
            txtTitle = new TextBox();
            btnUpdate = new Button();

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

            btnUpdate.Location = new Point(122, 70);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 4;
            btnUpdate.Text = "Update ";
            btnUpdate.Click += btnUpdate_Click;

            FormClosing += new FormClosingEventHandler(updateForm_FormClosing);

            Controls.Add(lblTitle);
            Controls.Add(txtTitle);
            Controls.Add(btnUpdate);
            StartPosition = FormStartPosition.CenterScreen;

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Name = "UpdateCategoryForm";
            Text = "UpdateCategoryForm";
            Load += UpdateCategoryForm_Load;
            ResumeLayout(false);
        }

        private void InitializeErrorLabels()
        {
            // Create error labels for email and password
            lblErrorTitle = new Label();
            lblErrorTitle.ForeColor = Color.Red;
            lblErrorTitle.Location = new Point(120, 43);
            lblErrorTitle.AutoSize = true;
            Controls.Add(lblErrorTitle);
        }

        #endregion
    }
}