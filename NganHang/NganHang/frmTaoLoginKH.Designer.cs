namespace NganHang
{
    partial class frmTaoLoginKH
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
            System.Windows.Forms.Label cMNDLabel;
            System.Windows.Forms.Label hOTENLabel;
            this.DS = new NganHang.DS();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLoginNameKH = new System.Windows.Forms.TextBox();
            this.btLuu = new DevExpress.XtraEditors.SimpleButton();
            this.txtPassKHConfir = new DevExpress.XtraEditors.TextEdit();
            this.txtPassKH = new DevExpress.XtraEditors.TextEdit();
            this.btThoat = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.hOTENTextBox = new System.Windows.Forms.TextBox();
            this.v_EX_LoginNameKHBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cMNDComboBox = new System.Windows.Forms.ComboBox();
            this.v_EX_LoginNameKHTableAdapter = new NganHang.DSTableAdapters.V_EX_LoginNameKHTableAdapter();
            this.tableAdapterManager = new NganHang.DSTableAdapters.TableAdapterManager();
            cMNDLabel = new System.Windows.Forms.Label();
            hOTENLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassKHConfir.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassKH.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.v_EX_LoginNameKHBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // cMNDLabel
            // 
            cMNDLabel.AutoSize = true;
            cMNDLabel.Location = new System.Drawing.Point(71, 41);
            cMNDLabel.Name = "cMNDLabel";
            cMNDLabel.Size = new System.Drawing.Size(47, 16);
            cMNDLabel.TabIndex = 0;
            cMNDLabel.Text = "CMND";
            // 
            // hOTENLabel
            // 
            hOTENLabel.AutoSize = true;
            hOTENLabel.Location = new System.Drawing.Point(71, 100);
            hOTENLabel.Name = "hOTENLabel";
            hOTENLabel.Size = new System.Drawing.Size(52, 16);
            hOTENLabel.TabIndex = 2;
            hOTENLabel.Text = "Họ Tên";
            // 
            // DS
            // 
            this.DS.DataSetName = "DS";
            this.DS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtLoginNameKH);
            this.panel1.Controls.Add(this.btLuu);
            this.panel1.Controls.Add(this.txtPassKHConfir);
            this.panel1.Controls.Add(this.txtPassKH);
            this.panel1.Controls.Add(this.btThoat);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(hOTENLabel);
            this.panel1.Controls.Add(this.hOTENTextBox);
            this.panel1.Controls.Add(cMNDLabel);
            this.panel1.Controls.Add(this.cMNDComboBox);
            this.panel1.Location = new System.Drawing.Point(107, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(627, 358);
            this.panel1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(167, 16);
            this.label4.TabIndex = 59;
            this.label4.Text = "Tạo Tài Khoản Đăng Nhập";
            // 
            // txtLoginNameKH
            // 
            this.txtLoginNameKH.Location = new System.Drawing.Point(269, 139);
            this.txtLoginNameKH.Name = "txtLoginNameKH";
            this.txtLoginNameKH.Size = new System.Drawing.Size(312, 22);
            this.txtLoginNameKH.TabIndex = 58;
            // 
            // btLuu
            // 
            this.btLuu.Location = new System.Drawing.Point(308, 272);
            this.btLuu.Margin = new System.Windows.Forms.Padding(5);
            this.btLuu.Name = "btLuu";
            this.btLuu.Size = new System.Drawing.Size(116, 44);
            this.btLuu.TabIndex = 57;
            this.btLuu.Text = "Lưu";
            this.btLuu.Click += new System.EventHandler(this.btLuu_Click);
            // 
            // txtPassKHConfir
            // 
            this.txtPassKHConfir.Location = new System.Drawing.Point(269, 228);
            this.txtPassKHConfir.Margin = new System.Windows.Forms.Padding(5);
            this.txtPassKHConfir.Name = "txtPassKHConfir";
            this.txtPassKHConfir.Properties.UseSystemPasswordChar = true;
            this.txtPassKHConfir.Size = new System.Drawing.Size(312, 22);
            this.txtPassKHConfir.TabIndex = 56;
            // 
            // txtPassKH
            // 
            this.txtPassKH.Location = new System.Drawing.Point(269, 185);
            this.txtPassKH.Margin = new System.Windows.Forms.Padding(5);
            this.txtPassKH.Name = "txtPassKH";
            this.txtPassKH.Properties.UseSystemPasswordChar = true;
            this.txtPassKH.Size = new System.Drawing.Size(312, 22);
            this.txtPassKH.TabIndex = 55;
            // 
            // btThoat
            // 
            this.btThoat.Location = new System.Drawing.Point(466, 270);
            this.btThoat.Margin = new System.Windows.Forms.Padding(5);
            this.btThoat.Name = "btThoat";
            this.btThoat.Size = new System.Drawing.Size(115, 46);
            this.btThoat.TabIndex = 54;
            this.btThoat.Text = "Thoát";
            this.btThoat.Click += new System.EventHandler(this.btThoat_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 233);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 16);
            this.label1.TabIndex = 53;
            this.label1.Text = "Nhập lại mật khẩu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(72, 189);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 16);
            this.label3.TabIndex = 52;
            this.label3.Text = "Mật Khẩu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 146);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 51;
            this.label2.Text = "Tên tài khoản";
            // 
            // hOTENTextBox
            // 
            this.hOTENTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.v_EX_LoginNameKHBindingSource, "HOTEN", true));
            this.hOTENTextBox.Enabled = false;
            this.hOTENTextBox.Location = new System.Drawing.Point(269, 94);
            this.hOTENTextBox.Name = "hOTENTextBox";
            this.hOTENTextBox.Size = new System.Drawing.Size(312, 22);
            this.hOTENTextBox.TabIndex = 3;
            // 
            // v_EX_LoginNameKHBindingSource
            // 
            this.v_EX_LoginNameKHBindingSource.DataMember = "V_EX_LoginNameKH";
            this.v_EX_LoginNameKHBindingSource.DataSource = this.DS;
            // 
            // cMNDComboBox
            // 
            this.cMNDComboBox.DataSource = this.v_EX_LoginNameKHBindingSource;
            this.cMNDComboBox.DisplayMember = "CMND";
            this.cMNDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cMNDComboBox.FormattingEnabled = true;
            this.cMNDComboBox.Location = new System.Drawing.Point(269, 38);
            this.cMNDComboBox.Name = "cMNDComboBox";
            this.cMNDComboBox.Size = new System.Drawing.Size(312, 24);
            this.cMNDComboBox.TabIndex = 1;
            this.cMNDComboBox.ValueMember = "CMND";
            // 
            // v_EX_LoginNameKHTableAdapter
            // 
            this.v_EX_LoginNameKHTableAdapter.ClearBeforeFill = true;
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
            // frmTaoLoginKH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 453);
            this.Controls.Add(this.panel1);
            this.Name = "frmTaoLoginKH";
            this.Text = "Tạo Tài Khoản Đăng Nhập Khách Hàng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmTaoLoginKH_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassKHConfir.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassKH.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.v_EX_LoginNameKHBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DS DS;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.BindingSource v_EX_LoginNameKHBindingSource;
        private DSTableAdapters.V_EX_LoginNameKHTableAdapter v_EX_LoginNameKHTableAdapter;
        private DSTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.TextBox hOTENTextBox;
        private System.Windows.Forms.ComboBox cMNDComboBox;
        private System.Windows.Forms.TextBox txtLoginNameKH;
        private DevExpress.XtraEditors.SimpleButton btLuu;
        private DevExpress.XtraEditors.TextEdit txtPassKHConfir;
        private DevExpress.XtraEditors.TextEdit txtPassKH;
        private DevExpress.XtraEditors.SimpleButton btThoat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
    }
}