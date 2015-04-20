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
        ArrayList _fieldArr = new ArrayList();//列表字段数组
        Thread _runing; //tip message thread;
        public MainForm()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }
        /// <summary>
        /// Load lists
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoadLists_Click(object sender, EventArgs e)
        {
            this.btnConnect.Enabled = false;
            this.btnLoadLists.Enabled = false;
            Thread t = new Thread(getList);
            t.Start();
            _runing = new Thread(displayRuning);
            _runing.Start("正在处理中...");
        }
        /// <summary>
        /// Load Field
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            _runing.Start("正在处理中");
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
        /// 消息提示 Tip message
        /// </summary>
        /// <param name="obj">string</param>
        public void displayRuning(object obj)
        {
            this.lblRuning.Text = obj.ToString();

            while (true)
            {
                Thread.Sleep(500);
                lblRuning.Text+=".";
                Thread.Sleep(500);
                lblRuning.Text += ".";
                Thread.Sleep(500);
                lblRuning.Text+=".";
                Thread.Sleep(500);
                lblRuning.Text=obj.ToString();
            }
        }

        /// <summary>
        /// Load Click List Fields
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbxLists_DoubleClick(object sender, EventArgs e)
        {
            _selectListTitle = this.lbxLists.SelectedItem.ToString();
            if (!string.IsNullOrEmpty(_selectListTitle))
            {
                _runing = new Thread(displayRuning);
                _runing.Start("Loading fields for selected list \"" + _selectListTitle + "\"");
                //移除控件
                Thread t = new Thread(removeCbx);
                t.Start();
                Thread.Sleep(1000); 
              //  Thread getField = new Thread(getListFields);
               // getField.Start(_selectListTitle);
                t.Abort();
                getListFields(_selectListTitle);
               // Thread getfield = new Thread(getListFields);
               // getfield.Start(_selectListTitle);
            }
        }
        public void getListFields(object obj)
        {                       
            //CheckedListBox cklb = new CheckedListBox();
            //cklb.Name = "cklbFields";
            //cklb.Location = new Point(10,10);
            //cklb.Height = 50;
            //panelField.Controls.Add(cklb);
            //this.cklbFields.Height = 50;
            if (_getInfo != null)
            {
                _fieldArr = _getInfo.getListFields(_context, this.cbxHidden.Checked, obj.ToString());
                this.cklbFields.Items.Clear();
                int p=0;
                int initPointY =10;
                int height = this.cklbFields.Height;
                foreach (var item in _fieldArr)
                {
                    FieldProperty fp = (FieldProperty)item;
                    int y = initPointY;
                    this.cklbFields.Items.Add(fp.title);
                    
                    ComboBox cbxS = new ComboBox();
                    cbxS.Name = "cbxSourceField" + p;
                    p++;
                    cbxS.Location = new Point(150, y);
                    cbxS.Height = 23;
                    cbxS.Enabled = false;
                    this.panelField.Controls.Add(cbxS);
                    initPointY += 22;
                   height += 20;
                }
                cklbFields.Height = height;
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

        /// <summary>
        /// 获取excel数据 get Excel Data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetExcelData_Click(object sender, EventArgs e)
        {
            excelHelper eh = new excelHelper();
            DataSet ds = eh.LoadDataFromExcel(tbxFilePath.Text);
            DataTable excelDataTable = ds.Tables[0];
            this.dgvData.DataSource = excelDataTable;
            int t = 0;// 再次加载前清空 历史数据
            for (int i = 0; i < excelDataTable.Columns.Count; i++)
            {
                string item = excelDataTable.Rows[0][i].ToString();
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
            if (excelDataTable.Rows.Count<2)
            {
                MessageBox.Show("数据无效，至少2行(第一行表头，第二行数据)");
                this.btnImport.Enabled = false;
            }
            else
            {
                this.btnImport.Enabled = true;
            }
            
        }

        
        private void cklbFields_MouseClick(object sender, MouseEventArgs e)
        {
            //checked 后启用对应的combox
            string idStr = "";
            foreach (int indexChecked in cklbFields.CheckedIndices)
            {
                idStr +="cbxSourceField"+ indexChecked.ToString() + ";";
            }
            foreach (Control c in panelField.Controls)
            {
                if (c is ComboBox)
                {
                    
                    if (idStr.Split(';').Contains(c.Name))
                    {
                        c.Enabled = true;
                    }
                    else
                    {
                        c.Enabled = false;
                    }
                }
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            //验证字段是否对应上 目标字段→源字段

            //循环fieldList 选择项集合，检查对应Combox Selected项是否为空
            string errorMsg = "";
            #region 验证
            foreach (int item in this.cklbFields.CheckedIndices)
            {
                string selectedIndex = item.ToString();
                Control col = this.panelField.Controls.Find("cbxSourceField" + selectedIndex, true)[0];
                ComboBox cbx = col as ComboBox;
                if (string.IsNullOrEmpty(cbx.SelectedText))
                {
                    errorMsg += "第" + item + "项未选择对应源字段;/\n";
                }
            }
            if (this.cklbFields.SelectedItems.Count < 1)
            {
                errorMsg += "请选择目标字段";
            }
            if (this.dgvData.Rows.Count < 2)
            {
                errorMsg += "请导入有效数据";
            } 
            #endregion
            if (!string.IsNullOrEmpty(errorMsg))
            {
                MessageBox.Show(errorMsg);
            }
            else
            {
                //导入操作
                //传入 目标字段集合 与 源excel数据集合，如果目标字段为outlook需要传入对于的列表ID及字段名称
                //_fieldArr 全局变量 所有当前列表字段集合
                ArrayList importToFieldArray = new ArrayList();
                foreach (int item in this.cklbFields.CheckedIndices)
                {
                    importToFieldArray.Add(_fieldArr[item]);
                }
                MessageBox.Show("importToFieldArray add done");
            }
        }

        public void removeCbx()
        {
            for (int i = 0; i < panelField.Controls.Count; i++)
            {
                if (panelField.Controls[i] is ComboBox)
                {
                    Controls.Remove(panelField.Controls[i]);
                }
            }
        }
    }
}
