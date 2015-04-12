using Microsoft.SharePoint.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SharePointDataImportAndExport
{
    public partial class MainForm : System.Windows.Forms.Form
    {
        GetInfoFromSharePoint _getInfo;
        Web _web;
        ClientContext _context;
        string _selectListTitle; //selected list title;
        Thread _runing; //tip message thread;
        public MainForm()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void btnLoadLists_Click(object sender, EventArgs e)
        {
            this.btnConnect.Enabled = false;
            this.btnLoadLists.Enabled = false;
            Thread t = new Thread(getList);
            t.Start();
            _runing = new Thread(displayRuning);
            _runing.Start("正在处理中...");
        }

        private void btnLoadField_Click(object sender, EventArgs e)
        {
            string listTitle = lbxLists.SelectedItem.ToString();
            if (string.IsNullOrEmpty(listTitle))
            {
                MessageBox.Show("Please selected list!");
            }
            else
            {
                bool hidden = this.cbxHidden.Checked;
                GetInfoFromSharePoint getInfo = new GetInfoFromSharePoint();
                string siteUrl = this.tbxUrl.Text.Trim();
                string domain = this.tbxDomain.Text.Trim();
                string userName = this.tbxUserName.Text.Trim();
                string passWord = this.tbxPassWord.Text.Trim();
                var spContext = new ClientContext(siteUrl);
                var credential = new NetworkCredential(userName, passWord, domain);
                spContext.Credentials = credential;
                ArrayList fieldArr = getInfo.getListFields(spContext, hidden, listTitle);
                foreach (var item in fieldArr)
                {
                    this.cklbFields.Items.Add(item);
                }
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            this.btnConnect.Enabled = false;
            this.btnLoadLists.Enabled = false;
            Thread t = new Thread(getList);
            t.Start();
            _runing = new Thread(displayRuning);
            _runing.Start("正在处理中...");
        }

        public void getList()
        {

            bool hidden = this.cbxHidden.Checked;
            string siteUrl = this.tbxUrl.Text.Trim();
            if (string.IsNullOrEmpty(siteUrl))
            {
                MessageBox.Show("Please write siteUrl!");
            }
            else
            {
                _getInfo = new GetInfoFromSharePoint();
                //  string siteUrl = this.tbxUrl.Text.Trim();
                string domain = this.tbxDomain.Text.Trim();
                string userName = this.tbxUserName.Text.Trim();
                string passWord = this.tbxPassWord.Text.Trim();

                try
                {
                    if (_web == null || _context == null)
                    {
                        ArrayList wc = _getInfo.getWeb(siteUrl, userName, passWord, domain);
                        _web = (Web)wc[0];
                        _context = (ClientContext)wc[1];
                    }

                    _context.Load(_web.Lists,
             lists => lists.Include(list => list.Title, // For each list, retrieve Title and Id. 
                                    list => list.Id,
                                    list => list.Hidden,
                                    list => list.Fields));
                    // Execute query. 
                    _context.ExecuteQuery();
                    foreach (var item in _web.Lists)
                    {
                        if (hidden)
                        {
                            this.lbxLists.Items.Add(item.Title);
                        }
                        else
                        {
                            if (!item.Hidden)
                            {
                                this.lbxLists.Items.Add(item.Title);
                            }
                        }

                    }
                    // MessageBox.Show("Connect success!");
                    this.lblRuning.Text = "Connect success!";
                }
                catch (Exception ee)
                {
                    // MessageBox.Show(ee.Message, "Connect Fail");
                    this.btnConnect.Enabled = true;
                    this.lblRuning.Text = "Connect Fail!." + ee.Message;
                }

            }
            _runing.Abort();

            Thread.Sleep(5000);
            this.lblRuning.Text = "";
            this.btnLoadLists.Enabled = true;
        }

        /// <summary>
        /// Tip message
        /// </summary>
        /// <param name="obj">string</param>
        public void displayRuning(object obj)
        {
            this.lblRuning.Text = obj.ToString();

            while (true)
            {
                Thread.Sleep(1000);
                lblRuning.Visible = false;
                Thread.Sleep(1000);
                lblRuning.Visible = true; 
            }

        }

        private void lbxLists_DoubleClick(object sender, EventArgs e)
        {
            _selectListTitle = this.lbxLists.SelectedItem.ToString();
            if (!string.IsNullOrEmpty(_selectListTitle))
            {
                _runing = new Thread(displayRuning);
                _runing.Start("Loading fields for selected list \"" + _selectListTitle + "\"");
                Thread getField = new Thread(getListFields);
                getField.Start(_selectListTitle);
            }
        }
        public void getListFields(object obj)
        {
            if (_getInfo != null)
            {
                ArrayList fieldArr = _getInfo.getListFields(_context, this.cbxHidden.Checked, obj.ToString());
                this.cklbFields.Items.Clear();
                int p=0;
                int initPointY = this.cklbFields.Location.Y;
                int initPointX = this.cklbFields.Location.X;
                foreach (var item in fieldArr)
                {
                    int y = initPointY + 20;
                    this.cklbFields.Items.Add(item);
                    
                    ComboBox cbx = new ComboBox();
                    cbx.Name = "cbxSourceField" + p;
                    p++;
                    cbx.Location = new Point(180, y+1);
                    cbx.Enabled = false;
                    this.panelField.Controls.Add(cbx);
                    //控件高度 随字段数量增长
                    cklbFields.Height += 21; 
                    if (cklbFields.Height>panelField.Height)
                    {
                        panelField.Height += 21;
                        this.FindForm().Height += 21;
                    }

                }
            }
            _runing.Abort();
            Thread.Sleep(5000);
            this.lblRuning.Text = "";
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            DialogResult openFileResult = openFileDialogExcel.ShowDialog();
            
        }

        private void openFileDialogExcel_FileOk(object sender, CancelEventArgs e)
        {
            tbxFilePath.Text = openFileDialogExcel.FileName;
            if (!string.IsNullOrEmpty(tbxFilePath.Text.Trim()))
            {
                this.btnGetExcelData.Enabled = true;
            }
        }

        private void btnGetExcelData_Click(object sender, EventArgs e)
        {
            excelHelper eh = new excelHelper();
            DataSet ds = eh.LoadDataFromExcel(tbxFilePath.Text);
            DataTable excelDataTable = ds.Tables[0];
            this.dgvData.DataSource = excelDataTable;
            int t = 0;// 再次加载前清空 历史数据
            for (int i = 0; i < excelDataTable.Columns.Count; i++)
            {
                string item = excelDataTable.Rows[1][i].ToString();
                foreach (Control c in panelField.Controls)
                {
                    if (c is ComboBox)
                    {
                        if (t == 0)
                        {
                            ((ComboBox)c).Items.Clear();
                        }
                        ((ComboBox)c).Items.Add(item);
                    }
                }
                t = 2;
            }
            
        }
    }
}
