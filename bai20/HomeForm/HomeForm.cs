using System;
using System.Drawing; // Thêm thư viện này để làm việc với màu sắc
using System.Windows.Forms;

namespace bai20
{
    public partial class HomeForm : Form
    {
        public HomeForm()
        {
            InitializeComponent();

            // Cấu hình màu sắc
            this.BackColor = Color.LightGray; // Nền chính của form

            // Màu sắc cho các nút
            btnManageStudents.BackColor = Color.LightGreen;
            btnManageStudents.ForeColor = Color.DarkGreen;

            btnManageTeachers.BackColor = Color.LightBlue;
            btnManageTeachers.ForeColor = Color.DarkBlue;

            btnManageClasses.BackColor = Color.LightBlue;
            btnManageClasses.ForeColor = Color.DarkBlue;

            btnManageScores.BackColor = Color.LightBlue;
            btnManageScores.ForeColor = Color.DarkBlue;

            btnLogout.BackColor = Color.LightCoral;
            btnLogout.ForeColor = Color.White;

            btnExit.BackColor = Color.LightCoral;
            btnExit.ForeColor = Color.White;

            // Cấu hình màu tiêu đề (nếu có label tiêu đề)
            labelTitle.ForeColor = Color.DarkSlateGray;
            labelTitle.Font = new Font("Arial", 16, FontStyle.Bold);
        }

        private void btnManageStudents_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnManageTeachers_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng quản lý giáo viên đang được phát triển.", "Thông báo");
        }

        private void btnManageClasses_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng quản lý lớp học đang được phát triển.", "Thông báo");
        }

        private void btnManageScores_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng quản lý điểm số đang được phát triển.", "Thông báo");
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                this.Hide();
            }
        }

        private void HomeForm_Load(object sender, EventArgs e)
        {
            // Tùy chỉnh thêm khi form tải
        }

        private void labelTitle_Click(object sender, EventArgs e)
        {
            // Logic cho nhãn tiêu đề
        }
    }
}
