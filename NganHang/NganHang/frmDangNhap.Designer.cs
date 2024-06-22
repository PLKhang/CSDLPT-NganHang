namespace NganHang
{
    partial class frmDangNhap
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
            this.labChiNhanh = new System.Windows.Forms.Label();
            this.labTk = new System.Windows.Forms.Label();
            this.labMk = new System.Windows.Forms.Label();
            this.cmbChiNhanh = new System.Windows.Forms.ComboBox();
            this.txtTk = new System.Windows.Forms.TextBox();
            this.txtMk = new System.Windows.Forms.TextBox();
            this.btnDN = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labChiNhanh
            // 
            this.labChiNhanh.AutoSize = true;
            this.labChiNhanh.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labChiNhanh.Location = new System.Drawing.Point(158, 64);
            this.labChiNhanh.Name = "labChiNhanh";
            this.labChiNhanh.Size = new System.Drawing.Size(93, 22);
            this.labChiNhanh.TabIndex = 0;
            this.labChiNhanh.Text = "Chi Nhánh";
            // 
            // labTk
            // 
            this.labTk.AutoSize = true;
            this.labTk.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTk.Location = new System.Drawing.Point(158, 142);
            this.labTk.Name = "labTk";
            this.labTk.Size = new System.Drawing.Size(93, 22);
            this.labTk.TabIndex = 1;
            this.labTk.Text = "Tài Khoản";
            // 
            // labMk
            // 
            this.labMk.AutoSize = true;
            this.labMk.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labMk.Location = new System.Drawing.Point(158, 219);
            this.labMk.Name = "labMk";
            this.labMk.Size = new System.Drawing.Size(87, 22);
            this.labMk.TabIndex = 2;
            this.labMk.Text = "Mật Khẩu";
            // 
            // cmbChiNhanh
            // 
            this.cmbChiNhanh.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbChiNhanh.FormattingEnabled = true;
            this.cmbChiNhanh.Location = new System.Drawing.Point(257, 58);
            this.cmbChiNhanh.Name = "cmbChiNhanh";
            this.cmbChiNhanh.Size = new System.Drawing.Size(314, 34);
            this.cmbChiNhanh.TabIndex = 3;
            this.cmbChiNhanh.SelectedIndexChanged += new System.EventHandler(this.cmbChiNhanh_SelectedIndexChanged);
            // 
            // txtTk
            // 
            this.txtTk.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTk.Location = new System.Drawing.Point(257, 136);
            this.txtTk.Name = "txtTk";
            this.txtTk.Size = new System.Drawing.Size(220, 34);
            this.txtTk.TabIndex = 4;
            // 
            // txtMk
            // 
            this.txtMk.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMk.Location = new System.Drawing.Point(257, 213);
            this.txtMk.Name = "txtMk";
            this.txtMk.PasswordChar = '*';
            this.txtMk.Size = new System.Drawing.Size(220, 34);
            this.txtMk.TabIndex = 5;
            // 
            // btnDN
            // 
            this.btnDN.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDN.Location = new System.Drawing.Point(257, 283);
            this.btnDN.Name = "btnDN";
            this.btnDN.Size = new System.Drawing.Size(145, 39);
            this.btnDN.TabIndex = 6;
            this.btnDN.Text = "Đăng Nhập";
            this.btnDN.UseVisualStyleBackColor = true;
            this.btnDN.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Location = new System.Drawing.Point(447, 283);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(132, 39);
            this.btnThoat.TabIndex = 7;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.TextChanged += new System.EventHandler(this.btnThoat_Click);
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // frmDangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 389);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnDN);
            this.Controls.Add(this.txtMk);
            this.Controls.Add(this.txtTk);
            this.Controls.Add(this.cmbChiNhanh);
            this.Controls.Add(this.labMk);
            this.Controls.Add(this.labTk);
            this.Controls.Add(this.labChiNhanh);
            this.Name = "frmDangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng Nhập";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDangNhap_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labChiNhanh;
        private System.Windows.Forms.Label labTk;
        private System.Windows.Forms.Label labMk;
        private System.Windows.Forms.ComboBox cmbChiNhanh;
        private System.Windows.Forms.TextBox txtTk;
        private System.Windows.Forms.TextBox txtMk;
        private System.Windows.Forms.Button btnDN;
        private System.Windows.Forms.Button btnThoat;
    }
}