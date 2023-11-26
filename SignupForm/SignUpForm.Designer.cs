namespace TodoLIstApp
{
    partial class SignUpForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        private Label lblName;
        private TextBox txtName;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblPassword;
        private TextBox txtPassword;
        private Label lblConfirmPassword;
        private TextBox txtConfirmPassword;
        private Button btnSignUp;
        private LinkLabel lnkLogin;
        private ComboBox cmbRoles;

        private Label lblErrorName;
        private Label lblErrorEmail;
        private Label lblErrorPassword;
        private Label lblErrorConfirmPassword;

        private void InitializeComponent()
        {
            lblName = new Label();
            txtName = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            lblConfirmPassword = new Label();
            txtConfirmPassword = new TextBox();
            btnSignUp = new Button();
            lnkLogin = new LinkLabel();
            cmbRoles = new ComboBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.Location = new Point(26, 20);
            lblName.Name = "lblName";
            lblName.Size = new Size(100, 23);
            lblName.TabIndex = 0;
            lblName.Text = "Name:";
            lblName.Click += lblName_Click;
            // 
            // txtName
            // 
            txtName.Location = new Point(126, 17);
            txtName.Name = "txtName";
            txtName.Size = new Size(200, 23);
            txtName.TabIndex = 1;
            txtName.TextChanged += txtName_TextChanged;
            // 
            // lblEmail
            // 
            lblEmail.Location = new Point(26, 60);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(100, 23);
            lblEmail.TabIndex = 2;
            lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(126, 60);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(200, 23);
            txtEmail.TabIndex = 3;
            // 
            // lblPassword
            // 
            lblPassword.Location = new Point(26, 100);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(100, 23);
            lblPassword.TabIndex = 4;
            lblPassword.Text = "Password:";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(126, 100);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(200, 23);
            txtPassword.TabIndex = 5;
            txtPassword.TextChanged += txtPassword_TextChanged;
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.Location = new Point(26, 140);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(63, 44);
            lblConfirmPassword.TabIndex = 6;
            lblConfirmPassword.Text = "Confirm Password:";
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(126, 137);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.PasswordChar = '*';
            txtConfirmPassword.Size = new Size(200, 23);
            txtConfirmPassword.TabIndex = 7;
            // 
            // btnSignUp
            // 
            btnSignUp.Location = new Point(126, 231);
            btnSignUp.Name = "btnSignUp";
            btnSignUp.Size = new Size(75, 23);
            btnSignUp.TabIndex = 8;
            btnSignUp.Text = "Sign Up";
            btnSignUp.Click += BtnSignUp_Click;
            // 
            // lnkLogin
            // 
            lnkLogin.ImageAlign = ContentAlignment.BottomRight;
            lnkLogin.Location = new Point(26, 269);
            lnkLogin.Name = "lnkLogin";
            lnkLogin.Size = new Size(150, 23);
            lnkLogin.TabIndex = 9;
            lnkLogin.TabStop = true;
            lnkLogin.Text = "Already have an account? Login";
            lnkLogin.LinkClicked += lnkLogin_LinkClicked;
            // 
            // cmbRoles
            // 
            cmbRoles.Location = new Point(126, 181);
            cmbRoles.Name = "cmbRoles";
            cmbRoles.Size = new Size(200, 23);
            cmbRoles.TabIndex = 10;
            cmbRoles.SelectedIndexChanged += cmbRoles_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.Location = new Point(26, 184);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.TabIndex = 11;
            label1.Text = "Role: ";
            label1.Click += label1_Click;
            // 
            // SignUpForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.MenuBar;
            BackgroundImage = Properties.Resources.bgtaskstdo;
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(773, 450);
            Controls.Add(label1);
            Controls.Add(lnkLogin);
            Controls.Add(lblName);
            Controls.Add(txtName);
            Controls.Add(lblEmail);
            Controls.Add(txtEmail);
            Controls.Add(lblPassword);
            Controls.Add(txtPassword);
            Controls.Add(lblConfirmPassword);
            Controls.Add(txtConfirmPassword);
            Controls.Add(btnSignUp);
            Controls.Add(cmbRoles);
            Name = "SignUpForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sign Up";
            Load += SignUpForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private void InitializeErrorLabels()
        {
            // Create error labels for name, email, password, and confirm password
            lblErrorName = new Label();
            lblErrorName.ForeColor = Color.Red;
            lblErrorName.Location = new Point(122, 42);
            lblErrorName.AutoSize = true;
            Controls.Add(lblErrorName);


            lblErrorEmail = new Label();
            lblErrorEmail.ForeColor = Color.Red;
            lblErrorEmail.Location = new Point(122, 85);
            lblErrorEmail.AutoSize = true;
            Controls.Add(lblErrorEmail);

            lblErrorPassword = new Label();
            lblErrorPassword.ForeColor = Color.Red;
            lblErrorPassword.Location = new Point(121, 122);
            lblErrorPassword.AutoSize = true;
            Controls.Add(lblErrorPassword);

            lblErrorConfirmPassword = new Label();
            lblErrorConfirmPassword.ForeColor = Color.Red;
            lblErrorConfirmPassword.Location = new Point(124, 160);
            lblErrorConfirmPassword.AutoSize = true;
            Controls.Add(lblErrorConfirmPassword);
        }

        private Label label1;
    }
}



