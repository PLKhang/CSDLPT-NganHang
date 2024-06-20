namespace NganHang
{
    partial class Frpt_DanhSachTaiKhoan_ChiNhanh
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
            System.Windows.Forms.Label hOTENLabel;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            this.label1 = new System.Windows.Forms.Label();
            this.cmbChiNhanh = new System.Windows.Forms.ComboBox();
            this.dS = new NganHang.DS();
            this.bdsHoTenNV = new System.Windows.Forms.BindingSource(this.components);
            this.HOTENNVTableAdapter = new NganHang.DSTableAdapters.HOTENNVTableAdapter();
            this.tableAdapterManager = new NganHang.DSTableAdapters.TableAdapterManager();
            this.cmbHoTen = new System.Windows.Forms.ComboBox();
            this.cmbLoai = new System.Windows.Forms.ComboBox();
            this.cmbBatDau = new System.Windows.Forms.ComboBox();
            this.cmbKetThuc = new System.Windows.Forms.ComboBox();
            this.dtBD = new DevExpress.XtraEditors.DateEdit();
            this.dtKT = new DevExpress.XtraEditors.DateEdit();
            hOTENLabel = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsHoTenNV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtBD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtBD.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtKT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtKT.Properties.CalendarTimeProperties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Chi Nhánh";
            // 
            // cmbChiNhanh
            // 
            this.cmbChiNhanh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChiNhanh.FormattingEnabled = true;
            this.cmbChiNhanh.Location = new System.Drawing.Point(116, 24);
            this.cmbChiNhanh.Name = "cmbChiNhanh";
            this.cmbChiNhanh.Size = new System.Drawing.Size(325, 24);
            this.cmbChiNhanh.TabIndex = 2;
            this.cmbChiNhanh.SelectedIndexChanged += new System.EventHandler(this.cmbChiNhanh_SelectedIndexChanged);
            // 
            // dS
            // 
            this.dS.DataSetName = "DS";
            this.dS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bdsHoTenNV
            // 
            this.bdsHoTenNV.DataMember = "HOTENNV";
            this.bdsHoTenNV.DataSource = this.dS;
            // 
            // HOTENNVTableAdapter
            // 
            this.HOTENNVTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CHINHANHTableAdapter = null;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.GD_CHUYENTIENTableAdapter = null;
            this.tableAdapterManager.GD_GOIRUTTableAdapter = null;
            this.tableAdapterManager.KHACHHANGTableAdapter = null;
            this.tableAdapterManager.NHANVIENTableAdapter = null;
            this.tableAdapterManager.TAIKHOANTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = NganHang.DSTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // hOTENLabel
            // 
            hOTENLabel.AutoSize = true;
            hOTENLabel.Location = new System.Drawing.Point(18, 71);
            hOTENLabel.Name = "hOTENLabel";
            hOTENLabel.Size = new System.Drawing.Size(55, 16);
            hOTENLabel.TabIndex = 4;
            hOTENLabel.Text = "Họ Tên:";
            // 
            // cmbHoTen
            // 
            this.cmbHoTen.DataSource = this.bdsHoTenNV;
            this.cmbHoTen.DisplayMember = "HOTEN";
            this.cmbHoTen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHoTen.FormattingEnabled = true;
            this.cmbHoTen.Location = new System.Drawing.Point(116, 68);
            this.cmbHoTen.Name = "cmbHoTen";
            this.cmbHoTen.Size = new System.Drawing.Size(325, 24);
            this.cmbHoTen.TabIndex = 5;
            this.cmbHoTen.ValueMember = "MANV";
            // 
            // cmbLoai
            // 
            this.cmbLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLoai.FormattingEnabled = true;
            this.cmbLoai.Items.AddRange(new object[] {
            "Chi Nhánh",
            "Tất Cả Chi Nhánh"});
            this.cmbLoai.Location = new System.Drawing.Point(116, 120);
            this.cmbLoai.Name = "cmbLoai";
            this.cmbLoai.Size = new System.Drawing.Size(151, 24);
            this.cmbLoai.TabIndex = 6;
            // 
            // cmbBatDau
            // 
            this.cmbBatDau.FormattingEnabled = true;
            this.cmbBatDau.Location = new System.Drawing.Point(116, 175);
            this.cmbBatDau.Name = "cmbBatDau";
            this.cmbBatDau.Size = new System.Drawing.Size(151, 24);
            this.cmbBatDau.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(18, 128);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(39, 16);
            label2.TabIndex = 8;
            label2.Text = "Loại: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(18, 178);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(65, 16);
            label3.TabIndex = 9;
            label3.Text = "Từ Ngày: ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(18, 227);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(73, 16);
            label4.TabIndex = 10;
            label4.Text = "Đến Ngày: ";
            // 
            // cmbKetThuc
            // 
            this.cmbKetThuc.FormattingEnabled = true;
            this.cmbKetThuc.Location = new System.Drawing.Point(116, 219);
            this.cmbKetThuc.Name = "cmbKetThuc";
            this.cmbKetThuc.Size = new System.Drawing.Size(151, 24);
            this.cmbKetThuc.TabIndex = 11;
            // 
            // dtBD
            // 
            this.dtBD.EditValue = null;
            this.dtBD.Location = new System.Drawing.Point(289, 177);
            this.dtBD.Name = "dtBD";
            this.dtBD.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtBD.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtBD.Size = new System.Drawing.Size(114, 22);
            this.dtBD.TabIndex = 12;
            // 
            // dtKT
            // 
            this.dtKT.EditValue = null;
            this.dtKT.Location = new System.Drawing.Point(289, 219);
            this.dtKT.Name = "dtKT";
            this.dtKT.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtKT.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtKT.Size = new System.Drawing.Size(114, 22);
            this.dtKT.TabIndex = 13;
            // 
            // Frpt_DanhSachTaiKhoan_ChiNhanh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 346);
            this.Controls.Add(this.dtKT);
            this.Controls.Add(this.dtBD);
            this.Controls.Add(this.cmbKetThuc);
            this.Controls.Add(label4);
            this.Controls.Add(label3);
            this.Controls.Add(label2);
            this.Controls.Add(this.cmbBatDau);
            this.Controls.Add(this.cmbLoai);
            this.Controls.Add(hOTENLabel);
            this.Controls.Add(this.cmbHoTen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbChiNhanh);
            this.Name = "Frpt_DanhSachTaiKhoan_ChiNhanh";
            this.Text = "Frpt_DanhSachTaiKhoan_ChiNhanh";
            this.Load += new System.EventHandler(this.Frpt_DanhSachTaiKhoan_ChiNhanh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsHoTenNV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtBD.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtBD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtKT.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtKT.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbChiNhanh;
        private DS dS;
        private System.Windows.Forms.BindingSource bdsHoTenNV;
        private DSTableAdapters.HOTENNVTableAdapter HOTENNVTableAdapter;
        private DSTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.ComboBox cmbHoTen;
        private System.Windows.Forms.ComboBox cmbLoai;
        private System.Windows.Forms.ComboBox cmbBatDau;
        private System.Windows.Forms.ComboBox cmbKetThuc;
        private DevExpress.XtraEditors.DateEdit dtBD;
        private DevExpress.XtraEditors.DateEdit dtKT;
    }
}