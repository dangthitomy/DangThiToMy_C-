using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace baocao
{
    public partial class Form1 : Form
    {
        private string connectionString = "Data Source=LAPTOP-4MCL9DLR\\SQLEXPRESS;Initial Catalog=SinhVien;User ID=sa;Password=sa";
        private List<SinhVien> sinhVienList = new List<SinhVien>();

        public Form1()
        {
            InitializeComponent();
            this.BackColor = Color.LightGray; // Màu nền của form

            // Thêm các khoa vào ComboBox
            comboBoxMajor.Items.AddRange(new object[]
            {
                "Công nghệ thông tin",
                "Khoa học máy tính",
                "Mạng máy tính",
                "Quản trị kinh doanh",
                "Kỹ thuật phần mềm",
                "Trí tuệ nhân tạo",
                "Khoa học dữ liệu",
                "Hệ thống thông tin",
                "Thiết kế đồ họa",
                "Kinh tế học",
                "Tài chính - Ngân hàng",
                "Kế toán"
            });

            // Thay đổi màu cho các nút
            CustomizeButtons();

            // Thay đổi màu cho DataGridView
            CustomizeDataGridView();
        }

        private void CustomizeButtons()
        {
            buttonAdd.BackColor = Color.LightSkyBlue;
            buttonAdd.ForeColor = Color.White;
            buttonAdd.Font = new Font("Arial", 10, FontStyle.Bold);

            buttonEdit.BackColor = Color.LightGreen;
            buttonEdit.ForeColor = Color.White;
            buttonEdit.Font = new Font("Arial", 10, FontStyle.Bold);

            buttonDelete.BackColor = Color.IndianRed;
            buttonDelete.ForeColor = Color.White;
            buttonDelete.Font = new Font("Arial", 10, FontStyle.Bold);

            buttonExit.BackColor = Color.LightCoral;
            buttonExit.ForeColor = Color.White;
            buttonExit.Font = new Font("Arial", 10, FontStyle.Bold);
        }

        private void CustomizeDataGridView()
        {
            dgvStudents.BackgroundColor = Color.White;
            dgvStudents.DefaultCellStyle.BackColor = Color.LightCyan;
            dgvStudents.DefaultCellStyle.ForeColor = Color.Black;
            dgvStudents.RowHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            dgvStudents.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            dgvStudents.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Chọn cả hàng
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ các điều khiển
            string hoTen = textBoxName.Text.Trim();
            string maSinhVien = textBoxMa.Text.Trim(); // Lấy mã sinh viên
            DateTime ngaySinh = dateTimePickerDOB.Value;
            string gioiTinh = radioButtonMale.Checked ? "Nam" : "Nữ";
            string khoa = comboBoxMajor.SelectedItem?.ToString();

            // Kiểm tra ràng buộc mã sinh viên phải là số
            if (!int.TryParse(maSinhVien, out _))
            {
                MessageBox.Show("Mã sinh viên phải là số.");
                return;
            }

            if (string.IsNullOrWhiteSpace(hoTen) || string.IsNullOrWhiteSpace(maSinhVien) || khoa == null)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                return;
            }

            // Thêm sinh viên vào cơ sở dữ liệu
            AddStudentToDatabase(maSinhVien, hoTen, ngaySinh, gioiTinh, khoa);
            DisplayStudents();

            // Xóa dữ liệu nhập
            ClearInputFields();
        }
        private void UpdateStudentInDatabase(string maSinhVien, string hoTen, DateTime ngaySinh, string gioiTinh, string khoa)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE SinhVien SET HoTen = @HoTen, NgaySinh = @NgaySinh, GioiTinh = @GioiTinh, Khoa = @Khoa WHERE MaSinhVien = @MaSinhVien";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaSinhVien", maSinhVien);
                    command.Parameters.AddWithValue("@HoTen", hoTen);
                    command.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                    command.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                    command.Parameters.AddWithValue("@Khoa", khoa);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Cập nhật sinh viên thành công!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message);
                    }
                }
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dgvStudents.SelectedRows.Count > 0)
            {
                // Lấy thông tin sinh viên đã chọn
                var selectedRow = dgvStudents.SelectedRows[0];
                string maSinhVien = selectedRow.Cells["MaSinhVien"].Value.ToString(); // Lấy mã sinh viên
                string hoTen = selectedRow.Cells["HoTen"].Value.ToString(); // Lấy họ tên
                DateTime ngaySinh = DateTime.Parse(selectedRow.Cells["NgaySinh"].Value.ToString()); // Lấy ngày sinh
                string gioiTinh = selectedRow.Cells["GioiTinh"].Value.ToString(); // Lấy giới tính
                string khoa = selectedRow.Cells["Khoa"].Value.ToString(); // Lấy khoa

                // Điền thông tin vào các điều khiển
                textBoxMa.Text = maSinhVien; // Điền mã sinh viên
                textBoxName.Text = hoTen; // Điền họ tên
                dateTimePickerDOB.Value = ngaySinh; // Điền ngày sinh

                // Đặt radioButton cho giới tính
                radioButtonMale.Checked = (gioiTinh == "Nam");
                radioButtonFemale.Checked = (gioiTinh == "Nữ"); // Giả sử bạn có radioButtonFemale

                // Chọn khoa trong comboBox
                comboBoxMajor.SelectedItem = khoa;

                // Thông báo
                MessageBox.Show("Thông tin sinh viên đã được tải lên để chỉnh sửa.");
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sinh viên để sửa.");
            }
        }



        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dgvStudents.SelectedRows.Count > 0)
            {
                // Lấy sinh viên đã chọn và xóa
                var selectedRow = dgvStudents.SelectedRows[0];
                sinhVienList.RemoveAt(selectedRow.Index);
                dgvStudents.Rows.Remove(selectedRow);

                // Thông báo
                MessageBox.Show("Đã xóa sinh viên thành công.");
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sinh viên để xóa.");
            }
        }

        private void AddStudentToDatabase(string maSinhVien, string hoTen, DateTime ngaySinh, string gioiTinh, string khoa)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO SinhVien (MaSinhVien, HoTen, NgaySinh, GioiTinh, Khoa) VALUES (@MaSinhVien, @HoTen, @NgaySinh, @GioiTinh, @Khoa)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaSinhVien", maSinhVien);
                    command.Parameters.AddWithValue("@HoTen", hoTen);
                    command.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                    command.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                    command.Parameters.AddWithValue("@Khoa", khoa);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Thêm sinh viên thành công!");

                        // Thêm sinh viên mới vào danh sách
                        sinhVienList.Add(new SinhVien(maSinhVien, hoTen, ngaySinh.ToString("dd/MM/yyyy"), gioiTinh, khoa));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message);
                    }
                }
            }
        }

        private void DisplayStudents()
        {
            dgvStudents.Rows.Clear(); // Xóa tất cả hàng cũ
            foreach (var sv in sinhVienList)
            {
                dgvStudents.Rows.Add(sv.MaSinhVien, sv.HoTen, sv.NgaySinh, sv.GioiTinh, sv.Khoa);
            }
        }

        private void ClearInputFields()
        {
            textBoxName.Clear();
            textBoxMa.Clear(); // Xóa mã sinh viên
            dateTimePickerDOB.Value = DateTime.Now;
            radioButtonMale.Checked = true;
            comboBoxMajor.SelectedIndex = -1;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Thêm cột vào DataGridView
            dgvStudents.Columns.Clear(); // Xóa cột cũ nếu cần
            dgvStudents.Columns.Add("MaSinhVien", "Mã Sinh Viên"); // Thêm cột mã sinh viên
            dgvStudents.Columns.Add("HoTen", "Họ Tên");
            dgvStudents.Columns.Add("NgaySinh", "Ngày Sinh");
            dgvStudents.Columns.Add("GioiTinh", "Giới Tính");
            dgvStudents.Columns.Add("Khoa", "Khoa");

            // Hiển thị danh sách sinh viên khi form được tải
            DisplayStudents();
        }

        private void dgvStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Xử lý sự kiện khi nhấn vào một ô trong DataGridView (nếu cần)
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Xử lý sự kiện khi nội dung của textBox1 thay đổi (nếu cần)
        }
    }

    public class SinhVien
    {
        public string MaSinhVien { get; set; } // Thêm mã sinh viên
        public string HoTen { get; set; }
        public string NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string Khoa { get; set; }

        public SinhVien(string maSinhVien, string hoTen, string ngaySinh, string gioiTinh, string khoa)
        {
            MaSinhVien = maSinhVien; // Khởi tạo mã sinh viên
            HoTen = hoTen;
            NgaySinh = ngaySinh;
            GioiTinh = gioiTinh;
            Khoa = khoa;
        }
    }
}
