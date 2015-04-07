namespace SharePointDataImportAndExport
{
    partial class Main
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbxUrl = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxDomain = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxUserName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxPassWord = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbxLists = new System.Windows.Forms.ListBox();
            this.btnLoadLists = new System.Windows.Forms.Button();
            this.cbxHidden = new System.Windows.Forms.CheckBox();
            this.btnLoadField = new System.Windows.Forms.Button();
            this.cklbFields = new System.Windows.Forms.CheckedListBox();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbxUrl);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbxDomain);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbxUserName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbxPassWord);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1127, 52);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "loginInfo";
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
            this.tbxUrl.Location = new System.Drawing.Point(77, 16);
            this.tbxUrl.Name = "tbxUrl";
            this.tbxUrl.Size = new System.Drawing.Size(208, 21);
            this.tbxUrl.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(292, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 20;
            this.label2.Text = "Domain:";
            // 
            // tbxDomain
            // 
            this.tbxDomain.Location = new System.Drawing.Point(340, 17);
            this.tbxDomain.Name = "tbxDomain";
            this.tbxDomain.Size = new System.Drawing.Size(138, 21);
            this.tbxDomain.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(650, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 25;
            this.label4.Text = "PassWord:";
            // 
            // tbxUserName
            // 
            this.tbxUserName.Location = new System.Drawing.Point(535, 18);
            this.tbxUserName.Name = "tbxUserName";
            this.tbxUserName.Size = new System.Drawing.Size(100, 21);
            this.tbxUserName.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(482, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 24;
            this.label3.Text = "UserName:";
            // 
            // tbxPassWord
            // 
            this.tbxPassWord.Location = new System.Drawing.Point(715, 17);
            this.tbxPassWord.Name = "tbxPassWord";
            this.tbxPassWord.PasswordChar = '*';
            this.tbxPassWord.Size = new System.Drawing.Size(100, 21);
            this.tbxPassWord.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbxLists);
            this.panel2.Controls.Add(this.btnLoadLists);
            this.panel2.Controls.Add(this.cbxHidden);
            this.panel2.Controls.Add(this.btnLoadField);
            this.panel2.Controls.Add(this.cklbFields);
            this.panel2.Location = new System.Drawing.Point(12, 58);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(403, 553);
            this.panel2.TabIndex = 2;
            // 
            // lbxLists
            // 
            this.lbxLists.FormattingEnabled = true;
            this.lbxLists.ItemHeight = 12;
            this.lbxLists.Location = new System.Drawing.Point(8, 35);
            this.lbxLists.Name = "lbxLists";
            this.lbxLists.Size = new System.Drawing.Size(122, 508);
            this.lbxLists.TabIndex = 32;
            // 
            // btnLoadLists
            // 
            this.btnLoadLists.Location = new System.Drawing.Point(73, 6);
            this.btnLoadLists.Name = "btnLoadLists";
            this.btnLoadLists.Size = new System.Drawing.Size(108, 23);
            this.btnLoadLists.TabIndex = 6;
            this.btnLoadLists.Text = "LoadLists";
            this.btnLoadLists.UseVisualStyleBackColor = true;
            this.btnLoadLists.Click += new System.EventHandler(this.btnLoadLists_Click);
            // 
            // cbxHidden
            // 
            this.cbxHidden.AutoSize = true;
            this.cbxHidden.Location = new System.Drawing.Point(11, 9);
            this.cbxHidden.Name = "cbxHidden";
            this.cbxHidden.Size = new System.Drawing.Size(60, 16);
            this.cbxHidden.TabIndex = 5;
            this.cbxHidden.Text = "Hidden";
            this.cbxHidden.UseVisualStyleBackColor = true;
            // 
            // btnLoadField
            // 
            this.btnLoadField.Location = new System.Drawing.Point(225, 6);
            this.btnLoadField.Name = "btnLoadField";
            this.btnLoadField.Size = new System.Drawing.Size(155, 23);
            this.btnLoadField.TabIndex = 7;
            this.btnLoadField.Text = "LoadFieldBySelectedList";
            this.btnLoadField.UseVisualStyleBackColor = true;
            this.btnLoadField.Click += new System.EventHandler(this.btnLoadField_Click);
            // 
            // cklbFields
            // 
            this.cklbFields.FormattingEnabled = true;
            this.cklbFields.Location = new System.Drawing.Point(136, 35);
            this.cklbFields.Name = "cklbFields";
            this.cklbFields.Size = new System.Drawing.Size(244, 516);
            this.cklbFields.TabIndex = 33;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1127, 623);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Main";
            this.Text = "SharePointDataImportAndExport";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox lbxLists;
        private System.Windows.Forms.Button btnLoadLists;
        private System.Windows.Forms.CheckBox cbxHidden;
        private System.Windows.Forms.Button btnLoadField;
        private System.Windows.Forms.CheckedListBox cklbFields;
    }
}

