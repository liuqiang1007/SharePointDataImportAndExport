namespace SharePointDataImportAndExport
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxUrl = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxDomain = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxUserName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxPassWord = new System.Windows.Forms.TextBox();
            this.panelField = new System.Windows.Forms.Panel();
            this.cbxSourceField01 = new System.Windows.Forms.ComboBox();
            this.cklbFields = new System.Windows.Forms.CheckedListBox();
            this.btnLoadField = new System.Windows.Forms.Button();
            this.lbxLists = new System.Windows.Forms.ListBox();
            this.btnLoadLists = new System.Windows.Forms.Button();
            this.cbxHidden = new System.Windows.Forms.CheckBox();
            this.lblRuning = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnGetExcelData = new System.Windows.Forms.Button();
            this.tbxFilePath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.openFileDialogExcel = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.panelField.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDisconnect);
            this.groupBox1.Controls.Add(this.btnConnect);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbxUrl);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbxDomain);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbxUserName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbxPassWord);
            this.groupBox1.Location = new System.Drawing.Point(3, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(228, 145);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "loginInfo";
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(27, 119);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(75, 21);
            this.btnDisconnect.TabIndex = 27;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(126, 119);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 21);
            this.btnConnect.TabIndex = 26;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 14;
            this.label1.Text = "SPSiteURL:";
            // 
            // tbxUrl
            // 
            this.tbxUrl.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.tbxUrl.Location = new System.Drawing.Point(77, 16);
            this.tbxUrl.Name = "tbxUrl";
            this.tbxUrl.Size = new System.Drawing.Size(138, 21);
            this.tbxUrl.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 20;
            this.label2.Text = "Domain:";
            // 
            // tbxDomain
            // 
            this.tbxDomain.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.tbxDomain.Location = new System.Drawing.Point(77, 40);
            this.tbxDomain.Name = "tbxDomain";
            this.tbxDomain.Size = new System.Drawing.Size(138, 21);
            this.tbxDomain.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 25;
            this.label4.Text = "PassWord:";
            // 
            // tbxUserName
            // 
            this.tbxUserName.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.tbxUserName.Location = new System.Drawing.Point(77, 66);
            this.tbxUserName.Name = "tbxUserName";
            this.tbxUserName.Size = new System.Drawing.Size(138, 21);
            this.tbxUserName.TabIndex = 3;
            this.tbxUserName.Text = "administrator";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 24;
            this.label3.Text = "UserName:";
            // 
            // tbxPassWord
            // 
            this.tbxPassWord.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.tbxPassWord.Location = new System.Drawing.Point(77, 95);
            this.tbxPassWord.Name = "tbxPassWord";
            this.tbxPassWord.PasswordChar = '*';
            this.tbxPassWord.Size = new System.Drawing.Size(138, 21);
            this.tbxPassWord.TabIndex = 4;
            // 
            // panelField
            // 
            this.panelField.AutoScroll = true;
            this.panelField.Controls.Add(this.cbxSourceField01);
            this.panelField.Controls.Add(this.cklbFields);
            this.panelField.Location = new System.Drawing.Point(234, 66);
            this.panelField.Name = "panelField";
            this.panelField.Size = new System.Drawing.Size(303, 340);
            this.panelField.TabIndex = 2;
            // 
            // cbxSourceField01
            // 
            this.cbxSourceField01.FormattingEnabled = true;
            this.cbxSourceField01.Location = new System.Drawing.Point(180, 18);
            this.cbxSourceField01.Name = "cbxSourceField01";
            this.cbxSourceField01.Size = new System.Drawing.Size(120, 20);
            this.cbxSourceField01.TabIndex = 34;
            // 
            // cklbFields
            // 
            this.cklbFields.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cklbFields.FormattingEnabled = true;
            this.cklbFields.Location = new System.Drawing.Point(10, 10);
            this.cklbFields.Name = "cklbFields";
            this.cklbFields.Size = new System.Drawing.Size(168, 25);
            this.cklbFields.TabIndex = 33;
            this.cklbFields.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cklbFields_MouseClick);
            // 
            // btnLoadField
            // 
            this.btnLoadField.Location = new System.Drawing.Point(253, 31);
            this.btnLoadField.Name = "btnLoadField";
            this.btnLoadField.Size = new System.Drawing.Size(155, 25);
            this.btnLoadField.TabIndex = 7;
            this.btnLoadField.Text = "LoadFieldBySelectedList";
            this.btnLoadField.UseVisualStyleBackColor = true;
            this.btnLoadField.Click += new System.EventHandler(this.btnLoadField_Click);
            // 
            // lbxLists
            // 
            this.lbxLists.FormattingEnabled = true;
            this.lbxLists.ItemHeight = 12;
            this.lbxLists.Location = new System.Drawing.Point(9, 186);
            this.lbxLists.Name = "lbxLists";
            this.lbxLists.Size = new System.Drawing.Size(219, 220);
            this.lbxLists.TabIndex = 32;
            this.lbxLists.DoubleClick += new System.EventHandler(this.lbxLists_DoubleClick);
            // 
            // btnLoadLists
            // 
            this.btnLoadLists.Location = new System.Drawing.Point(126, 158);
            this.btnLoadLists.Name = "btnLoadLists";
            this.btnLoadLists.Size = new System.Drawing.Size(75, 23);
            this.btnLoadLists.TabIndex = 6;
            this.btnLoadLists.Text = "LoadLists";
            this.btnLoadLists.UseVisualStyleBackColor = true;
            this.btnLoadLists.Click += new System.EventHandler(this.btnLoadLists_Click);
            // 
            // cbxHidden
            // 
            this.cbxHidden.AutoSize = true;
            this.cbxHidden.Location = new System.Drawing.Point(31, 161);
            this.cbxHidden.Name = "cbxHidden";
            this.cbxHidden.Size = new System.Drawing.Size(60, 16);
            this.cbxHidden.TabIndex = 5;
            this.cbxHidden.Text = "Hidden";
            this.cbxHidden.UseVisualStyleBackColor = true;
            // 
            // lblRuning
            // 
            this.lblRuning.AutoSize = true;
            this.lblRuning.BackColor = System.Drawing.SystemColors.Info;
            this.lblRuning.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRuning.ForeColor = System.Drawing.Color.Red;
            this.lblRuning.Location = new System.Drawing.Point(240, 16);
            this.lblRuning.Name = "lblRuning";
            this.lblRuning.Size = new System.Drawing.Size(0, 17);
            this.lblRuning.TabIndex = 33;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvData);
            this.groupBox2.Controls.Add(this.btnBrowse);
            this.groupBox2.Controls.Add(this.btnGetExcelData);
            this.groupBox2.Controls.Add(this.tbxFilePath);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(543, 66);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(572, 340);
            this.groupBox2.TabIndex = 34;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "getExcelData";
            // 
            // dgvData
            // 
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Location = new System.Drawing.Point(6, 39);
            this.dgvData.Name = "dgvData";
            this.dgvData.Size = new System.Drawing.Size(560, 301);
            this.dgvData.TabIndex = 4;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(270, 11);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 21);
            this.btnBrowse.TabIndex = 3;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnGetExcelData
            // 
            this.btnGetExcelData.Enabled = false;
            this.btnGetExcelData.Location = new System.Drawing.Point(397, 11);
            this.btnGetExcelData.Name = "btnGetExcelData";
            this.btnGetExcelData.Size = new System.Drawing.Size(75, 21);
            this.btnGetExcelData.TabIndex = 2;
            this.btnGetExcelData.Text = "getData";
            this.btnGetExcelData.UseVisualStyleBackColor = true;
            this.btnGetExcelData.Click += new System.EventHandler(this.btnGetExcelData_Click);
            // 
            // tbxFilePath
            // 
            this.tbxFilePath.BackColor = System.Drawing.SystemColors.Control;
            this.tbxFilePath.Location = new System.Drawing.Point(60, 13);
            this.tbxFilePath.Name = "tbxFilePath";
            this.tbxFilePath.ReadOnly = true;
            this.tbxFilePath.Size = new System.Drawing.Size(204, 21);
            this.tbxFilePath.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "FilePath：";
            // 
            // openFileDialogExcel
            // 
            this.openFileDialogExcel.FileName = "openFileDialogExcel";
            this.openFileDialogExcel.Filter = "Excel File 2003|*.xls|Excel File 2007|*.xlsx";
            this.openFileDialogExcel.Title = "Select Excel File";
            this.openFileDialogExcel.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialogExcel_FileOk);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1127, 420);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnLoadField);
            this.Controls.Add(this.lblRuning);
            this.Controls.Add(this.btnLoadLists);
            this.Controls.Add(this.cbxHidden);
            this.Controls.Add(this.lbxLists);
            this.Controls.Add(this.panelField);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.Text = "SharePointDataImportAndExport";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelField.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxUrl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxDomain;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxUserName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxPassWord;
        private System.Windows.Forms.Panel panelField;
        private System.Windows.Forms.ListBox lbxLists;
        private System.Windows.Forms.Button btnLoadLists;
        private System.Windows.Forms.CheckBox cbxHidden;
        private System.Windows.Forms.Button btnLoadField;
        private System.Windows.Forms.CheckedListBox cklbFields;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label lblRuning;
        private System.Windows.Forms.ComboBox cbxSourceField01;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnGetExcelData;
        private System.Windows.Forms.TextBox tbxFilePath;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.OpenFileDialog openFileDialogExcel;
        private System.Windows.Forms.DataGridView dgvData;
    }
}

