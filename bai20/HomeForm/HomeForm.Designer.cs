namespace bai20
{
    partial class HomeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</summary>
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
            btnManageStudents = new Button();
            btnManageCourses = new Button();
            btnManageTeachers = new Button();
            btnManageClasses = new Button();
            btnManageScores = new Button();
            btnLogout = new Button();
            btnExit = new Button();
            labelTitle = new Label();
            SuspendLayout();
            // 
            // btnManageStudents
            // 
            btnManageStudents.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnManageStudents.Location = new Point(50, 125);
            btnManageStudents.Margin = new Padding(3, 4, 3, 4);
            btnManageStudents.Name = "btnManageStudents";
            btnManageStudents.Size = new Size(200, 62);
            btnManageStudents.TabIndex = 0;
            btnManageStudents.Text = "Quản lý sinh viên";
            btnManageStudents.UseVisualStyleBackColor = true;
            btnManageStudents.Click += btnManageStudents_Click;
            // 
            // btnManageCourses
            // 
            btnManageCourses.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnManageCourses.Location = new Point(50, 200);
            btnManageCourses.Margin = new Padding(3, 4, 3, 4);
            btnManageCourses.Name = "btnManageCourses";
            btnManageCourses.Size = new Size(200, 62);
            btnManageCourses.TabIndex = 1;
            btnManageCourses.Text = "Quản lý khóa học";
            btnManageCourses.UseVisualStyleBackColor = true;
      
            // 
            // btnManageTeachers
            // 
            btnManageTeachers.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnManageTeachers.Location = new Point(50, 275);
            btnManageTeachers.Margin = new Padding(3, 4, 3, 4);
            btnManageTeachers.Name = "btnManageTeachers";
            btnManageTeachers.Size = new Size(200, 62);
            btnManageTeachers.TabIndex = 2;
            btnManageTeachers.Text = "Quản lý giáo viên";
            btnManageTeachers.UseVisualStyleBackColor = true;
            btnManageTeachers.Click += btnManageTeachers_Click;
            // 
            // btnManageClasses
            // 
            btnManageClasses.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnManageClasses.Location = new Point(50, 350);
            btnManageClasses.Margin = new Padding(3, 4, 3, 4);
            btnManageClasses.Name = "btnManageClasses";
            btnManageClasses.Size = new Size(200, 62);
            btnManageClasses.TabIndex = 3;
            btnManageClasses.Text = "Quản lý lớp học";
            btnManageClasses.UseVisualStyleBackColor = true;
            btnManageClasses.Click += btnManageClasses_Click;
            // 
            // btnManageScores
            // 
            btnManageScores.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnManageScores.Location = new Point(50, 425);
            btnManageScores.Margin = new Padding(3, 4, 3, 4);
            btnManageScores.Name = "btnManageScores";
            btnManageScores.Size = new Size(200, 62);
            btnManageScores.TabIndex = 4;
            btnManageScores.Text = "Quản lý điểm số";
            btnManageScores.UseVisualStyleBackColor = true;
            btnManageScores.Click += btnManageScores_Click;
            // 
            // btnLogout
            // 
            btnLogout.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogout.Location = new Point(50, 500);
            btnLogout.Margin = new Padding(3, 4, 3, 4);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(200, 62);
            btnLogout.TabIndex = 5;
            btnLogout.Text = "Đăng xuất";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnExit
            // 
            btnExit.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExit.Location = new Point(50, 575);
            btnExit.Margin = new Padding(3, 4, 3, 4);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(200, 62);
            btnExit.TabIndex = 6;
            btnExit.Text = "Thoát";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTitle.Location = new Point(70, 38);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(151, 31);
            labelTitle.TabIndex = 7;
            labelTitle.Text = "Trang Chủ";
            labelTitle.Click += labelTitle_Click;
            // 
            // HomeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(320, 675);
            Controls.Add(labelTitle);
            Controls.Add(btnExit);
            Controls.Add(btnLogout);
            Controls.Add(btnManageScores);
            Controls.Add(btnManageClasses);
            Controls.Add(btnManageTeachers);
            Controls.Add(btnManageCourses);
            Controls.Add(btnManageStudents);
            Margin = new Padding(3, 4, 3, 4);
            Name = "HomeForm";
            Text = "HomeForm";
            Load += HomeForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnManageStudents;
        private System.Windows.Forms.Button btnManageCourses;
        private System.Windows.Forms.Button btnManageTeachers;
        private System.Windows.Forms.Button btnManageClasses;
        private System.Windows.Forms.Button btnManageScores;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label labelTitle;
    }
}
