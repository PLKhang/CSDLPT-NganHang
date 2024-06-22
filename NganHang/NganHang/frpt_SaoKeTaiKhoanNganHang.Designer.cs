namespace NganHang
{
    partial class frpt_SaoKeTaiKhoanNganHang
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label lblHoTen;
            System.Windows.Forms.Label cMNDLabel;
            this.DS = new NganHang.DS();
            this.btn_Thoat = new System.Windows.Forms.Button();
            this.btn_SaoKe = new System.Windows.Forms.Button();
            this.endDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.startDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bdsKH = new System.Windows.Forms.BindingSource(this.components);
            this.kHACHHANGTableAdapter = new NganHang.DSTableAdapters.KHACHHANGTableAdapter();
            this.tableAdapterManager = new NganHang.DSTableAdapters.TableAdapterManager();
            this.tAIKHOANTableAdapter = new NganHang.DSTableAdapters.TAIKHOANTableAdapter();
            this.cmbCMND = new System.Windows.Forms.ComboBox();
            this.txtHO = new System.Windows.Forms.TextBox();
            this.txtTEN = new System.Windows.Forms.TextBox();
            this.bdsTK = new System.Windows.Forms.BindingSource(this.components);
            this.cmbSOTK = new System.Windows.Forms.ComboBox();
            this.fKTaiKhoanKhachHangBindingSource = new System.Windows.Forms.BindingSource(this.components);
            lblHoTen = new System.Windows.Forms.Label();
            cMNDLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsKH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsTK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKTaiKhoanKhachHangBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHoTen
            // 
            lblHoTen.AutoSize = true;
            lblHoTen.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblHoTen.Location = new System.Drawing.Point(44, 176);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new System.Drawing.Size(53, 17);
            lblHoTen.TabIndex = 21;
            lblHoTen.Text = "Họ Tên";
            // 
            // cMNDLabel
            // 
            cMNDLabel.AutoSize = true;
            cMNDLabel.Location = new System.Drawing.Point(47, 70);
            cMNDLabel.Name = "cMNDLabel";
            cMNDLabel.Size = new System.Drawing.Size(50, 16);
            cMNDLabel.TabIndex = 23;
            cMNDLabel.Text = "CMND:";
            // 
            // DS
            // 
            this.DS.DataSetName = "DS";
            this.DS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btn_Thoat
            // 
            this.btn_Thoat.Location = new System.Drawing.Point(462, 228);
            this.btn_Thoat.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Thoat.Name = "btn_Thoat";
            this.btn_Thoat.Size = new System.Drawing.Size(159, 46);
            this.btn_Thoat.TabIndex = 18;
            this.btn_Thoat.Text = "Thoát";
            this.btn_Thoat.UseVisualStyleBackColor = true;
            this.btn_Thoat.Click += new System.EventHandler(this.btn_Thoat_Click);
            // 
            // btn_SaoKe
            // 
            this.btn_SaoKe.Location = new System.Drawing.Point(295, 228);
            this.btn_SaoKe.Margin = new System.Windows.Forms.Padding(4);
            this.btn_SaoKe.Name = "btn_SaoKe";
            this.btn_SaoKe.Size = new System.Drawing.Size(159, 46);
            this.btn_SaoKe.TabIndex = 17;
            this.btn_SaoKe.Text = "Sao kê";
            this.btn_SaoKe.UseVisualStyleBackColor = true;
            this.btn_SaoKe.Click += new System.EventHandler(this.btn_SaoKe_Click);
            // 
            // endDateTimePicker
            // 
            this.endDateTimePicker.Location = new System.Drawing.Point(588, 132);
            this.endDateTimePicker.Margin = new System.Windows.Forms.Padding(4);
            this.endDateTimePicker.Name = "endDateTimePicker";
            this.endDateTimePicker.Size = new System.Drawing.Size(265, 22);
            this.endDateTimePicker.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(509, 136);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 15;
            this.label3.Text = "Đến ngày";
            // 
            // startDateTimePicker
            // 
            this.startDateTimePicker.Location = new System.Drawing.Point(588, 70);
            this.startDateTimePicker.Margin = new System.Windows.Forms.Padding(4);
            this.startDateTimePicker.Name = "startDateTimePicker";
            this.startDateTimePicker.Size = new System.Drawing.Size(265, 22);
            this.startDateTimePicker.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(509, 74);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "Từ ngày";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 122);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "Số tài khoản";
            // 
            // bdsKH
            // 
            this.bdsKH.DataMember = "KHACHHANG";
            this.bdsKH.DataSource = this.DS;
            // 
            // kHACHHANGTableAdapter
            // 
            this.kHACHHANGTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CHINHANHTableAdapter = null;
            this.tableAdapterManager.GD_CHUYENTIENTableAdapter = null;
            this.tableAdapterManager.GD_GOIRUTTableAdapter = null;
            this.tableAdapterManager.KHACHHANGTableAdapter = this.kHACHHANGTableAdapter;
            this.tableAdapterManager.NHANVIENTableAdapter = null;
            this.tableAdapterManager.TAIKHOANTableAdapter = this.tAIKHOANTableAdapter;
            this.tableAdapterManager.UpdateOrder = NganHang.DSTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // tAIKHOANTableAdapter
            // 
            this.tAIKHOANTableAdapter.ClearBeforeFill = true;
            // 
            // cmbCMND
            // 
            this.cmbCMND.DataSource = this.bdsKH;
            this.cmbCMND.DisplayMember = "CMND";
            this.cmbCMND.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCMND.FormattingEnabled = true;
            this.cmbCMND.Location = new System.Drawing.Point(194, 67);
            this.cmbCMND.Name = "cmbCMND";
            this.cmbCMND.Size = new System.Drawing.Size(192, 24);
            this.cmbCMND.TabIndex = 25;
            this.cmbCMND.ValueMember = "CMND";
            // 
            // txtHO
            // 
            this.txtHO.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsKH, "HO", true));
            this.txtHO.Location = new System.Drawing.Point(194, 171);
            this.txtHO.Name = "txtHO";
            this.txtHO.Size = new System.Drawing.Size(149, 22);
            this.txtHO.TabIndex = 26;
            // 
            // txtTEN
            // 
            this.txtTEN.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsKH, "TEN", true));
            this.txtTEN.Location = new System.Drawing.Point(354, 171);
            this.txtTEN.Name = "txtTEN";
            this.txtTEN.Size = new System.Drawing.Size(100, 22);
            this.txtTEN.TabIndex = 27;
            // 
            // bdsTK
            // 
            this.bdsTK.DataMember = "FK_TaiKhoan_KhachHang";
            this.bdsTK.DataSource = this.bdsKH;
            // 
            // cmbSOTK
            // 
            this.cmbSOTK.DataSource = this.fKTaiKhoanKhachHangBindingSource;
            this.cmbSOTK.DisplayMember = "SOTK";
            this.cmbSOTK.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSOTK.FormattingEnabled = true;
            this.cmbSOTK.Location = new System.Drawing.Point(194, 122);
            this.cmbSOTK.Name = "cmbSOTK";
            this.cmbSOTK.Size = new System.Drawing.Size(198, 24);
            this.cmbSOTK.TabIndex = 28;
            this.cmbSOTK.ValueMember = "SOTK";
            // 
            // fKTaiKhoanKhachHangBindingSource
            // 
            this.fKTaiKhoanKhachHangBindingSource.DataMember = "FK_TaiKhoan_KhachHang";
            this.fKTaiKhoanKhachHangBindingSource.DataSource = this.bdsKH;
            // 
            // frpt_SaoKeTaiKhoanNganHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 332);
            this.Controls.Add(this.cmbSOTK);
            this.Controls.Add(this.txtTEN);
            this.Controls.Add(this.txtHO);
            this.Controls.Add(this.cmbCMND);
            this.Controls.Add(cMNDLabel);
            this.Controls.Add(lblHoTen);
            this.Controls.Add(this.btn_Thoat);
            this.Controls.Add(this.btn_SaoKe);
            this.Controls.Add(this.endDateTimePicker);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.startDateTimePicker);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frpt_SaoKeTaiKhoanNganHang";
            this.Text = "Sao Kê Giao Dịch";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frpt_SaoKeTaiKhoanNganHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsKH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsTK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKTaiKhoanKhachHangBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DS DS;
        private System.Windows.Forms.Button btn_Thoat;
        private System.Windows.Forms.Button btn_SaoKe;
        private System.Windows.Forms.DateTimePicker endDateTimePicker;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker startDateTimePicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource bdsKH;
        private DSTableAdapters.KHACHHANGTableAdapter kHACHHANGTableAdapter;
        private DSTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.ComboBox cmbCMND;
        private System.Windows.Forms.TextBox txtHO;
        private System.Windows.Forms.TextBox txtTEN;
        private DSTableAdapters.TAIKHOANTableAdapter tAIKHOANTableAdapter;
        private System.Windows.Forms.BindingSource bdsTK;
        private System.Windows.Forms.ComboBox cmbSOTK;
        private System.Windows.Forms.BindingSource fKTaiKhoanKhachHangBindingSource;
    }
}