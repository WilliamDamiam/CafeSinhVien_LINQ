namespace QuanLyHangHoa
{
    partial class Form1
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.lblMaHang = new System.Windows.Forms.Label();
            this.lblTenHang = new System.Windows.Forms.Label();
            this.txtMaHang = new System.Windows.Forms.TextBox();
            this.txtTenHang = new System.Windows.Forms.TextBox();
            this.lblMaChatLieu = new System.Windows.Forms.Label();
            this.cboMaChatLieu = new System.Windows.Forms.ComboBox();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.lblDonGiaNhap = new System.Windows.Forms.Label();
            this.txtDonGiaNhap = new System.Windows.Forms.TextBox();
            this.lblDonGiaBan = new System.Windows.Forms.Label();
            this.txtDonGiaBan = new System.Windows.Forms.TextBox();
            this.lblHinh = new System.Windows.Forms.Label();
            this.txtHinh = new System.Windows.Forms.TextBox();
            this.btnMoAnh = new System.Windows.Forms.Button();
            this.picHangHoa = new System.Windows.Forms.PictureBox();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.dgvHangHoa = new System.Windows.Forms.DataGridView();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnBoQua = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picHangHoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHangHoa)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDe.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblTieuDe.Location = new System.Drawing.Point(339, 20);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(391, 37);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "DANH MỤC HÀNG HÓA";
            // 
            // lblMaHang
            // 
            this.lblMaHang.AutoSize = true;
            this.lblMaHang.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaHang.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblMaHang.Location = new System.Drawing.Point(36, 80);
            this.lblMaHang.Name = "lblMaHang";
            this.lblMaHang.Size = new System.Drawing.Size(70, 19);
            this.lblMaHang.TabIndex = 1;
            this.lblMaHang.Text = "Mã Hàng";
            // 
            // lblTenHang
            // 
            this.lblTenHang.AutoSize = true;
            this.lblTenHang.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenHang.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblTenHang.Location = new System.Drawing.Point(36, 117);
            this.lblTenHang.Name = "lblTenHang";
            this.lblTenHang.Size = new System.Drawing.Size(73, 19);
            this.lblTenHang.TabIndex = 2;
            this.lblTenHang.Text = "Tên Hàng";
            // 
            // txtMaHang
            // 
            this.txtMaHang.Location = new System.Drawing.Point(161, 77);
            this.txtMaHang.Name = "txtMaHang";
            this.txtMaHang.Size = new System.Drawing.Size(217, 22);
            this.txtMaHang.TabIndex = 3;
            // 
            // txtTenHang
            // 
            this.txtTenHang.Location = new System.Drawing.Point(161, 114);
            this.txtTenHang.Name = "txtTenHang";
            this.txtTenHang.Size = new System.Drawing.Size(217, 22);
            this.txtTenHang.TabIndex = 4;
            // 
            // lblMaChatLieu
            // 
            this.lblMaChatLieu.AutoSize = true;
            this.lblMaChatLieu.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaChatLieu.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblMaChatLieu.Location = new System.Drawing.Point(36, 153);
            this.lblMaChatLieu.Name = "lblMaChatLieu";
            this.lblMaChatLieu.Size = new System.Drawing.Size(101, 19);
            this.lblMaChatLieu.TabIndex = 5;
            this.lblMaChatLieu.Text = "Mã Chất Liệu";
            // 
            // cboMaChatLieu
            // 
            this.cboMaChatLieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMaChatLieu.FormattingEnabled = true;
            this.cboMaChatLieu.Location = new System.Drawing.Point(161, 148);
            this.cboMaChatLieu.Name = "cboMaChatLieu";
            this.cboMaChatLieu.Size = new System.Drawing.Size(217, 24);
            this.cboMaChatLieu.TabIndex = 6;
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoLuong.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblSoLuong.Location = new System.Drawing.Point(36, 194);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(75, 19);
            this.lblSoLuong.TabIndex = 7;
            this.lblSoLuong.Text = "Số Lượng";
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(161, 191);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(217, 22);
            this.txtSoLuong.TabIndex = 8;
            // 
            // lblDonGiaNhap
            // 
            this.lblDonGiaNhap.AutoSize = true;
            this.lblDonGiaNhap.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDonGiaNhap.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblDonGiaNhap.Location = new System.Drawing.Point(36, 235);
            this.lblDonGiaNhap.Name = "lblDonGiaNhap";
            this.lblDonGiaNhap.Size = new System.Drawing.Size(105, 19);
            this.lblDonGiaNhap.TabIndex = 9;
            this.lblDonGiaNhap.Text = "Đơn Giá Nhập";
            // 
            // txtDonGiaNhap
            // 
            this.txtDonGiaNhap.Location = new System.Drawing.Point(161, 234);
            this.txtDonGiaNhap.Name = "txtDonGiaNhap";
            this.txtDonGiaNhap.Size = new System.Drawing.Size(217, 22);
            this.txtDonGiaNhap.TabIndex = 10;
            // 
            // lblDonGiaBan
            // 
            this.lblDonGiaBan.AutoSize = true;
            this.lblDonGiaBan.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDonGiaBan.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblDonGiaBan.Location = new System.Drawing.Point(36, 279);
            this.lblDonGiaBan.Name = "lblDonGiaBan";
            this.lblDonGiaBan.Size = new System.Drawing.Size(96, 19);
            this.lblDonGiaBan.TabIndex = 11;
            this.lblDonGiaBan.Text = "Đơn Giá Bán";
            // 
            // txtDonGiaBan
            // 
            this.txtDonGiaBan.Location = new System.Drawing.Point(161, 278);
            this.txtDonGiaBan.Name = "txtDonGiaBan";
            this.txtDonGiaBan.Size = new System.Drawing.Size(217, 22);
            this.txtDonGiaBan.TabIndex = 12;
            // 
            // lblHinh
            // 
            this.lblHinh.AutoSize = true;
            this.lblHinh.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHinh.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblHinh.Location = new System.Drawing.Point(410, 99);
            this.lblHinh.Name = "lblHinh";
            this.lblHinh.Size = new System.Drawing.Size(36, 19);
            this.lblHinh.TabIndex = 13;
            this.lblHinh.Text = "Ảnh";
            // 
            // txtHinh
            // 
            this.txtHinh.Location = new System.Drawing.Point(468, 77);
            this.txtHinh.Multiline = true;
            this.txtHinh.Name = "txtHinh";
            this.txtHinh.Size = new System.Drawing.Size(229, 74);
            this.txtHinh.TabIndex = 14;
            // 
            // btnMoAnh
            // 
            this.btnMoAnh.Location = new System.Drawing.Point(718, 91);
            this.btnMoAnh.Name = "btnMoAnh";
            this.btnMoAnh.Size = new System.Drawing.Size(75, 37);
            this.btnMoAnh.TabIndex = 15;
            this.btnMoAnh.Text = "Mở";
            this.btnMoAnh.UseVisualStyleBackColor = true;
            this.btnMoAnh.Click += new System.EventHandler(this.btnMoAnh_Click);
            // 
            // picHangHoa
            // 
            this.picHangHoa.Location = new System.Drawing.Point(814, 77);
            this.picHangHoa.Name = "picHangHoa";
            this.picHangHoa.Size = new System.Drawing.Size(241, 221);
            this.picHangHoa.TabIndex = 16;
            this.picHangHoa.TabStop = false;
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGhiChu.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblGhiChu.Location = new System.Drawing.Point(410, 170);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(65, 19);
            this.lblGhiChu.TabIndex = 17;
            this.lblGhiChu.Text = "Ghi Chú";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(468, 201);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(229, 99);
            this.txtGhiChu.TabIndex = 18;
            // 
            // dgvHangHoa
            // 
            this.dgvHangHoa.AllowUserToAddRows = false;
            this.dgvHangHoa.AllowUserToDeleteRows = false;
            this.dgvHangHoa.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHangHoa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHangHoa.Location = new System.Drawing.Point(23, 347);
            this.dgvHangHoa.Name = "dgvHangHoa";
            this.dgvHangHoa.ReadOnly = true;
            this.dgvHangHoa.RowHeadersVisible = false;
            this.dgvHangHoa.RowHeadersWidth = 51;
            this.dgvHangHoa.RowTemplate.Height = 24;
            this.dgvHangHoa.Size = new System.Drawing.Size(1032, 299);
            this.dgvHangHoa.TabIndex = 19;
            this.dgvHangHoa.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHangHoa_CellClick);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(23, 662);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(98, 39);
            this.btnThem.TabIndex = 20;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(161, 662);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(98, 39);
            this.btnXoa.TabIndex = 21;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(303, 662);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(98, 39);
            this.btnSua.TabIndex = 22;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(440, 662);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(98, 39);
            this.btnLuu.TabIndex = 23;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnBoQua
            // 
            this.btnBoQua.Location = new System.Drawing.Point(574, 662);
            this.btnBoQua.Name = "btnBoQua";
            this.btnBoQua.Size = new System.Drawing.Size(98, 39);
            this.btnBoQua.TabIndex = 24;
            this.btnBoQua.Text = "Bỏ Qua";
            this.btnBoQua.UseVisualStyleBackColor = true;
            this.btnBoQua.Click += new System.EventHandler(this.btnBoQua_Click_1);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(709, 662);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(98, 39);
            this.btnTimKiem.TabIndex = 25;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(948, 662);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(98, 39);
            this.btnDong.TabIndex = 26;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 729);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.btnBoQua);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.dgvHangHoa);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.lblGhiChu);
            this.Controls.Add(this.picHangHoa);
            this.Controls.Add(this.btnMoAnh);
            this.Controls.Add(this.txtHinh);
            this.Controls.Add(this.lblHinh);
            this.Controls.Add(this.txtDonGiaBan);
            this.Controls.Add(this.lblDonGiaBan);
            this.Controls.Add(this.txtDonGiaNhap);
            this.Controls.Add(this.lblDonGiaNhap);
            this.Controls.Add(this.txtSoLuong);
            this.Controls.Add(this.lblSoLuong);
            this.Controls.Add(this.cboMaChatLieu);
            this.Controls.Add(this.lblMaChatLieu);
            this.Controls.Add(this.txtTenHang);
            this.Controls.Add(this.txtMaHang);
            this.Controls.Add(this.lblTenHang);
            this.Controls.Add(this.lblMaHang);
            this.Controls.Add(this.lblTieuDe);
            this.Name = "Form1";
            this.Text = "Danh Mục Hàng Hóa";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picHangHoa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHangHoa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblMaHang;
        private System.Windows.Forms.Label lblTenHang;
        private System.Windows.Forms.TextBox txtMaHang;
        private System.Windows.Forms.TextBox txtTenHang;
        private System.Windows.Forms.Label lblMaChatLieu;
        private System.Windows.Forms.ComboBox cboMaChatLieu;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.Label lblDonGiaNhap;
        private System.Windows.Forms.TextBox txtDonGiaNhap;
        private System.Windows.Forms.Label lblDonGiaBan;
        private System.Windows.Forms.TextBox txtDonGiaBan;
        private System.Windows.Forms.Label lblHinh;
        private System.Windows.Forms.TextBox txtHinh;
        private System.Windows.Forms.Button btnMoAnh;
        private System.Windows.Forms.PictureBox picHangHoa;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.DataGridView dgvHangHoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnBoQua;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnDong;
    }
}

