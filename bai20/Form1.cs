using System;
using System.Windows.Forms;
using System.Drawing; 

namespace bai20
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CustomizeUI();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Thêm dữ liệu mẫu vào DataGridView
            dgvEmployees.Rows.Add("001", "Nguyen Van A", "20", "Nam");
            dgvEmployees.Rows.Add("002", "Tran Thi B", "21", "Nữ");
        }


        private void CustomizeUI()
        {

            this.BackColor = Color.LightGray;

            btnAdd.BackColor = Color.Green;
            btnAdd.ForeColor = Color.White;

            btnEdit.BackColor = Color.Orange;
            btnEdit.ForeColor = Color.White;

            btnDelete.BackColor = Color.Red;
            btnDelete.ForeColor = Color.White;

            btnExit.BackColor = Color.DarkGray;
            btnExit.ForeColor = Color.White;


            dgvEmployees.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
            dgvEmployees.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dgvEmployees.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        // Sự kiện khi chọn hàng trong DataGridView
        private void dgvEmployees_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvEmployees.SelectedRows.Count > 0)
            {
                // Lấy dữ liệu từ hàng được chọn
                DataGridViewRow selectedRow = dgvEmployees.SelectedRows[0];
                tbID.Text = selectedRow.Cells["ID"].Value.ToString();
                tbName.Text = selectedRow.Cells["Name"].Value.ToString();
                tbAge.Text = selectedRow.Cells["Age"].Value.ToString();
                string gender = selectedRow.Cells["Gender"].Value.ToString();

                // Cập nhật RadioButton dựa trên giới tính
                rbMale.Checked = (gender == "Nam");
                rbFemale.Checked = (gender == "Nữ");
            }
        }

        // Nút thêm sinh viên mới
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Kiểm tra nhập liệu trước khi thêm
            if (!IsValidInput())
            {
                return; // Dừng nếu nhập liệu không hợp lệ
            }

            string id = tbID.Text;
            string name = tbName.Text;
            string age = tbAge.Text;
            string gender = rbMale.Checked ? "Nam" : "Nữ";

            // Thêm sinh viên mới vào DataGridView
            dgvEmployees.Rows.Add(id, name, age, gender);

            // Hiển thị thông báo thêm thành công
            MessageBox.Show("Thêm sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Xóa các trường sau khi thêm
            ClearInputFields();
        }

        // Nút sửa sinh viên
        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có hàng nào đang được chọn không
            if (dgvEmployees.SelectedRows.Count > 0)
            {
                // Kiểm tra nhập liệu trước khi sửa
                if (!IsValidInput())
                {
                    return; // Dừng nếu nhập liệu không hợp lệ
                }

                // Lấy hàng đang được chọn
                DataGridViewRow selectedRow = dgvEmployees.SelectedRows[0];

                // Cập nhật giá trị của hàng được chọn bằng các giá trị từ các ô nhập liệu
                selectedRow.Cells["ID"].Value = tbID.Text;
                selectedRow.Cells["Name"].Value = tbName.Text;
                selectedRow.Cells["Age"].Value = tbAge.Text;

                // Xác định giới tính dựa trên radio button
                if (rbMale.Checked)
                {
                    selectedRow.Cells["Gender"].Value = "Nam";
                }
                else if (rbFemale.Checked)
                {
                    selectedRow.Cells["Gender"].Value = "Nữ";
                }

                // Hiển thị thông báo cập nhật thành công
                MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Xóa các trường sau khi sửa
                ClearInputFields();
            }
            else
            {
                // Thông báo nếu không có hàng nào được chọn
                MessageBox.Show("Vui lòng chọn một hàng để sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nút xóa sinh viên
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.SelectedRows.Count > 0)
            {
                // Xóa hàng được chọn
                dgvEmployees.Rows.RemoveAt(dgvEmployees.SelectedRows[0].Index);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hàng để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nút thoát chương trình
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Hàm kiểm tra nhập liệu
        private bool IsValidInput()
        {
            // Kiểm tra Mã (phải là số và không được để trống)
            if (string.IsNullOrEmpty(tbID.Text) || !int.TryParse(tbID.Text, out _))
            {
                MessageBox.Show("Mã sinh viên phải là số và không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbID.Focus();
                return false;
            }

            // Kiểm tra Tên (không được để trống)
            if (string.IsNullOrEmpty(tbName.Text))
            {
                MessageBox.Show("Tên sinh viên không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbName.Focus();
                return false;
            }

            // Kiểm tra Tuổi (phải là số và trong khoảng hợp lệ)
            if (string.IsNullOrEmpty(tbAge.Text) || !int.TryParse(tbAge.Text, out int age) || age < 1 || age > 120)
            {
                MessageBox.Show("Tuổi phải là số từ 1 đến 120.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbAge.Focus();
                return false;
            }

            // Kiểm tra Giới tính (phải chọn 1 giới tính)
            if (!rbMale.Checked && !rbFemale.Checked)
            {
                MessageBox.Show("Vui lòng chọn giới tính.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Nếu tất cả trường đều hợp lệ
            return true;
        }

        // Hàm xóa các trường nhập liệu
        private void ClearInputFields()
        {
            tbID.Clear();
            tbName.Clear();
            tbAge.Clear();
            rbMale.Checked = false;
            rbFemale.Checked = false;
        }

        private void dgvEmployees_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
