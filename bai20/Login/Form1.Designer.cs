namespace bai20
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox tbUsername;
        private TextBox tbPassword;
        private Button btnLogin;
        private Button btnExit;
        private Label lblUsername;
        private Label lblPassword;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            tbUsername = new TextBox();
            tbPassword = new TextBox();
            btnLogin = new Button();
            btnExit = new Button();
            lblUsername = new Label();
            lblPassword = new Label();
            SuspendLayout();
            // 
            // tbUsername
            // 
            tbUsername.Location = new Point(120, 50);
            tbUsername.Name = "tbUsername";
            tbUsername.Size = new Size(200, 27);
            tbUsername.TabIndex = 0;
            tbUsername.TextChanged += tbUsername_TextChanged;
            // 
            // tbPassword
            // 
            tbPassword.Location = new Point(120, 100);
            tbPassword.Name = "tbPassword";
            tbPassword.Size = new Size(200, 27);
            tbPassword.TabIndex = 1;
            tbPassword.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(120, 150);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(75, 30);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "Đăng nhập";
            btnLogin.Click += btnLogin_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(245, 150);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(75, 30);
            btnExit.TabIndex = 3;
            btnExit.Text = "Thoát";
            btnExit.Click += btnExit_Click;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(30, 50);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(110, 20);
            lblUsername.TabIndex = 4;
            lblUsername.Text = "Tên đăng nhập:";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(30, 100);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(73, 20);
            lblPassword.TabIndex = 5;
            lblPassword.Text = "Mật khẩu:";
            // 
            // LoginForm
            // 
            ClientSize = new Size(380, 230);
            Controls.Add(lblPassword);
            Controls.Add(lblUsername);
            Controls.Add(btnExit);
            Controls.Add(btnLogin);
            Controls.Add(tbPassword);
            Controls.Add(tbUsername);
            Name = "LoginForm";
            Text = "Đăng Nhập";
            Load += LoginForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
