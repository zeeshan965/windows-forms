namespace TodoLIstApp
{
    partial class loginForm
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

        #region Windows Form Designer generated code

        private Label lblLoginEmail;
        private TextBox txtLoginEmail;
        private Label lblLoginPassword;
        private TextBox txtLoginPassword;
        private Button btnLogin;
        private LinkLabel lnkSignUp;

        private Label lblErrorEmail;
        private Label lblErrorPassword;

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblLoginEmail = new Label();
            txtLoginEmail = new TextBox();
            lblLoginPassword = new Label();
            txtLoginPassword = new TextBox();
            btnLogin = new Button();
            lnkSignUp = new LinkLabel();
            SuspendLayout();
            // 
            // lblLoginEmail
            // 
            lblLoginEmail.Location = new Point(20, 20);
            lblLoginEmail.Name = "lblLoginEmail";
            lblLoginEmail.Size = new Size(100, 23);
            lblLoginEmail.TabIndex = 0;
            lblLoginEmail.Text = "Email:";
            // 
            // txtLoginEmail
            // 
            txtLoginEmail.Location = new Point(122, 20);
            txtLoginEmail.Name = "txtLoginEmail";
            txtLoginEmail.Size = new Size(200, 23);
            txtLoginEmail.TabIndex = 1;
            txtLoginEmail.TextChanged += txtLoginEmail_TextChanged;
            // 
            // lblLoginPassword
            // 
            lblLoginPassword.Location = new Point(20, 60);
            lblLoginPassword.Name = "lblLoginPassword";
            lblLoginPassword.Size = new Size(100, 23);
            lblLoginPassword.TabIndex = 2;
            lblLoginPassword.Text = "Password:";
            // 
            // txtLoginPassword
            // 
            txtLoginPassword.Location = new Point(120, 60);
            txtLoginPassword.Name = "txtLoginPassword";
            txtLoginPassword.PasswordChar = '*';
            txtLoginPassword.Size = new Size(200, 23);
            txtLoginPassword.TabIndex = 3;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(120, 100);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(75, 23);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Login";
            btnLogin.Click += btnLogin_Click;
            // 
            // lnkSignUp
            // 
            lnkSignUp.Location = new Point(120, 140);
            lnkSignUp.Name = "lnkSignUp";
            lnkSignUp.Size = new Size(144, 23);
            lnkSignUp.TabIndex = 5;
            lnkSignUp.TabStop = true;
            lnkSignUp.Text = "Don't have an account? Sign Up";
            lnkSignUp.LinkClicked += lnkSignUp_LinkClicked;
            // 
            // loginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblLoginEmail);
            Controls.Add(txtLoginEmail);
            Controls.Add(lblLoginPassword);
            Controls.Add(txtLoginPassword);
            Controls.Add(btnLogin);
            Controls.Add(lnkSignUp);
            Name = "loginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "loginForm";
            Load += loginForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private void InitializeErrorLabels()
        {
            // Create error labels for email and password
            lblErrorEmail = new Label();
            lblErrorEmail.ForeColor = Color.Red;
            lblErrorEmail.Location = new Point(120, 43);
            lblErrorEmail.AutoSize = true;
            Controls.Add(lblErrorEmail);

            lblErrorPassword = new Label();
            lblErrorPassword.ForeColor = Color.Red;
            lblErrorPassword.Location = new Point(120, 83);
            lblErrorPassword.AutoSize = true;
            Controls.Add(lblErrorPassword);
        }

        #endregion
    }
}