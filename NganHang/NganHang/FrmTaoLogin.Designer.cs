namespace NganHang
{
    partial class FrmTaoLogin
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
            System.Windows.Forms.Label mANVLabel;
            System.Windows.Forms.Label hOLabel;
            this.DS = new NganHang.DS();
            this.bdsNV = new System.Windows.Forms.BindingSource(this.components);
            this.nhanVienTableAdapter = new NganHang.DSTableAdapters.NHANVIENTableAdapter();
            this.tableAdapterManager = new NganHang.DSTableAdapters.TableAdapterManager();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLoginName = new System.Windows.Forms.TextBox();
            this.v_EX_LoginNameBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tENTextBox = new System.Windows.Forms.TextBox();
            this.hOTextBox = new System.Windows.Forms.TextBox();
            this.cmbMANV = new System.Windows.Forms.ComboBox();
            this.btLuu = new DevExpress.XtraEditors.SimpleButton();
            this.txtPassConfir = new DevExpress.XtraEditors.TextEdit();
            this.txtPass = new DevExpress.XtraEditors.TextEdit();
            this.btThoat = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.v_EX_LoginNameTableAdapter = new NganHang.DSTableAdapters.V_EX_LoginNameTableAdapter();
            mANVLabel = new System.Windows.Forms.Label();
            hOLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsNV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.v_EX_LoginNameBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassConfir.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPass.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // mANVLabel
            // 
            mANVLabel.AutoSize = true;
            mANVLabel.Font = new System.Drawing.Font("Tahoma", 11F);
            mANVLabel.Location = new System.Drawing.Point(26, 97);
            mANVLabel.Name = "mANVLabel";
            mANVLabel.Size = new System.Drawing.Size(128, 23);
            mANVLabel.TabIndex = 2;
            mANVLabel.Text = "Mã Nhân Viên";
            // 
            // hOLabel
            // 
            hOLabel.AutoSize = true;
            hOLabel.Font = new System.Drawing.Font("Tahoma", 11F);
            hOLabel.Location = new System.Drawing.Point(29, 156);
            hOLabel.Name = "hOLabel";
            hOLabel.Size = new System.Drawing.Size(164, 23);
            hOLabel.TabIndex = 43;
            hOLabel.Text = "Họ Tên Nhân Viên";
            // 
            // DS
            // 
            this.DS.DataSetName = "DS";
            this.DS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bdsNV
            // 
            this.bdsNV.DataMember = "NHANVIEN";
            this.bdsNV.DataSource = this.DS;
            // 
            // nhanVienTableAdapter
            // 
            this.nhanVienTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CHINHANHTableAdapter = null;
            this.tableAdapterManager.GD_CHUYENTIENTableAdapter = null;
            this.tableAdapterManager.GD_GOIRUTTableAdapter = null;
            this.tableAdapterManager.KHACHHANGTableAdapter = null;
            this.tableAdapterManager.NHANVIENTableAdapter = this.nhanVienTableAdapter;
            this.tableAdapterManager.TAIKHOANTableAdapter = null;
            this.tableAdapterManager.TK_KHTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = NganHang.DSTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.panelControl1.Controls.Add(this.label4);
            this.panelControl1.Controls.Add(mANVLabel);
            this.panelControl1.Controls.Add(this.txtLoginName);
            this.panelControl1.Controls.Add(this.tENTextBox);
            this.panelControl1.Controls.Add(this.hOTextBox);
            this.panelControl1.Controls.Add(this.cmbMANV);
            this.panelControl1.Controls.Add(hOLabel);
            this.panelControl1.Controls.Add(this.btLuu);
            this.panelControl1.Controls.Add(this.txtPassConfir);
            this.panelControl1.Controls.Add(this.txtPass);
            this.panelControl1.Controls.Add(this.btThoat);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Controls.Add(this.label3);
            this.panelControl1.Controls.Add(this.label2);
            this.panelControl1.Location = new System.Drawing.Point(187, 47);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(795, 471);
            this.panelControl1.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Aquamarine;
            this.label4.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(245, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(323, 29);
            this.label4.TabIndex = 51;
            this.label4.Text = "Tạo Tài Khoản Đăng Nhập";
            // 
            // txtLoginName
            // 
            this.txtLoginName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.v_EX_LoginNameBindingSource, "MANV", true));
            this.txtLoginName.Enabled = false;
            this.txtLoginName.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txtLoginName.Location = new System.Drawing.Point(226, 209);
            this.txtLoginName.Name = "txtLoginName";
            this.txtLoginName.ReadOnly = true;
            this.txtLoginName.Size = new System.Drawing.Size(507, 30);
            this.txtLoginName.TabIndex = 50;
            // 
            // v_EX_LoginNameBindingSource
            // 
            this.v_EX_LoginNameBindingSource.DataMember = "V_EX_LoginName";
            this.v_EX_LoginNameBindingSource.DataSource = this.DS;
            // 
            // tENTextBox
            // 
            this.tENTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.v_EX_LoginNameBindingSource, "TEN", true));
            this.tENTextBox.Enabled = false;
            this.tENTextBox.Location = new System.Drawing.Point(520, 153);
            this.tENTextBox.Multiline = true;
            this.tENTextBox.Name = "tENTextBox";
            this.tENTextBox.ReadOnly = true;
            this.tENTextBox.Size = new System.Drawing.Size(213, 31);
            this.tENTextBox.TabIndex = 49;
            // 
            // hOTextBox
            // 
            this.hOTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.v_EX_LoginNameBindingSource, "HO", true));
            this.hOTextBox.Enabled = false;
            this.hOTextBox.Location = new System.Drawing.Point(226, 153);
            this.hOTextBox.Multiline = true;
            this.hOTextBox.Name = "hOTextBox";
            this.hOTextBox.ReadOnly = true;
            this.hOTextBox.Size = new System.Drawing.Size(277, 31);
            this.hOTextBox.TabIndex = 48;
            // 
            // cmbMANV
            // 
            this.cmbMANV.DataSource = this.v_EX_LoginNameBindingSource;
            this.cmbMANV.DisplayMember = "MANV";
            this.cmbMANV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMANV.Font = new System.Drawing.Font("Tahoma", 11F);
            this.cmbMANV.FormattingEnabled = true;
            this.cmbMANV.Location = new System.Drawing.Point(226, 97);
            this.cmbMANV.Name = "cmbMANV";
            this.cmbMANV.Size = new System.Drawing.Size(507, 30);
            this.cmbMANV.TabIndex = 47;
            this.cmbMANV.ValueMember = "MANV";
            // 
            // btLuu
            // 
            this.btLuu.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btLuu.Appearance.Options.UseFont = true;
            this.btLuu.Location = new System.Drawing.Point(412, 346);
            this.btLuu.Margin = new System.Windows.Forms.Padding(5);
            this.btLuu.Name = "btLuu";
            this.btLuu.Size = new System.Drawing.Size(156, 56);
            this.btLuu.TabIndex = 43;
            this.btLuu.Text = "Lưu";
            this.btLuu.Click += new System.EventHandler(this.btLuu_Click);
            // 
            // txtPassConfir
            // 
            this.txtPassConfir.Location = new System.Drawing.Point(226, 298);
            this.txtPassConfir.Margin = new System.Windows.Forms.Padding(5);
            this.txtPassConfir.Name = "txtPassConfir";
            this.txtPassConfir.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txtPassConfir.Properties.Appearance.Options.UseFont = true;
            this.txtPassConfir.Properties.UseSystemPasswordChar = true;
            this.txtPassConfir.Size = new System.Drawing.Size(508, 28);
            this.txtPassConfir.TabIndex = 42;
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(226, 255);
            this.txtPass.Margin = new System.Windows.Forms.Padding(5);
            this.txtPass.Name = "txtPass";
            this.txtPass.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txtPass.Properties.Appearance.Options.UseFont = true;
            this.txtPass.Properties.UseSystemPasswordChar = true;
            this.txtPass.Size = new System.Drawing.Size(508, 28);
            this.txtPass.TabIndex = 41;
            // 
            // btThoat
            // 
            this.btThoat.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btThoat.Appearance.Options.UseFont = true;
            this.btThoat.Location = new System.Drawing.Point(578, 346);
            this.btThoat.Margin = new System.Windows.Forms.Padding(5);
            this.btThoat.Name = "btThoat";
            this.btThoat.Size = new System.Drawing.Size(156, 56);
            this.btThoat.TabIndex = 39;
            this.btThoat.Text = "Thoát";
            this.btThoat.Click += new System.EventHandler(this.btThoat_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label1.Location = new System.Drawing.Point(29, 303);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 23);
            this.label1.TabIndex = 38;
            this.label1.Text = "Nhập lại mật khẩu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label3.Location = new System.Drawing.Point(29, 258);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 23);
            this.label3.TabIndex = 37;
            this.label3.Text = "Mật Khẩu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label2.Location = new System.Drawing.Point(29, 212);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 23);
            this.label2.TabIndex = 36;
            this.label2.Text = "Tên tài khoản";
            // 
            // v_EX_LoginNameTableAdapter
            // 
            this.v_EX_LoginNameTableAdapter.ClearBeforeFill = true;
            // 
            // FrmTaoLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1118, 585);
            this.Controls.Add(this.panelControl1);
            this.Name = "FrmTaoLogin";
            this.Text = "Tao Login Cho Nhan Vien";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmTaoLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsNV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.v_EX_LoginNameBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassConfir.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPass.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DS DS;
        private System.Windows.Forms.BindingSource bdsNV;
        private DSTableAdapters.NHANVIENTableAdapter nhanVienTableAdapter;
        private DSTableAdapters.TableAdapterManager tableAdapterManager;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btLuu;
        private DevExpress.XtraEditors.TextEdit txtPassConfir;
        private DevExpress.XtraEditors.TextEdit txtPass;
        private DevExpress.XtraEditors.SimpleButton btThoat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource v_EX_LoginNameBindingSource;
        private DSTableAdapters.V_EX_LoginNameTableAdapter v_EX_LoginNameTableAdapter;
        private System.Windows.Forms.TextBox txtLoginName;
        private System.Windows.Forms.TextBox tENTextBox;
        private System.Windows.Forms.TextBox hOTextBox;
        private System.Windows.Forms.ComboBox cmbMANV;
        private System.Windows.Forms.Label label4;
    }
}