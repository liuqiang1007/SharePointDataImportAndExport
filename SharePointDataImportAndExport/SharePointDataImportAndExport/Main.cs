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
    public partial class Main : System.Windows.Forms.Form
    {
        GetInfoFromSharePoint _getInfo;
        Web _web;
        ClientContext _context;
        string _selectListTitle;
        Thread _runing;
        public Main()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void btnLoadLists_Click(object sender, EventArgs e)
        {
            bool hidden = this.cbxHidden.Checked;
            //_getInfo = new GetInfoFromSharePoint();
            //string siteUrl = this.tbxUrl.Text.Trim();
            //string domain = this.tbxDomain.Text.Trim();
            //string userName = this.tbxUserName.Text.Trim();
            //string passWord = this.tbxPassWord.Text.Trim();


            //  var spContext = new ClientContext(siteUrl);

            // var credential = new NetworkCredential(userName, passWord, domain);
            // spContext.Credentials = credential;
            // ClientRuntimeContext  cc = _web.Context;
            // ArrayList lists = _getInfo.getLists(spContext, hidden);
            //if (lists!=null&&lists.Count>0)
            //{
            //    foreach (var item in lists)
            //    {
            //        if (hidden)
            //        {
            //             this.lbxLists.Items.Add(item.Title);
            //        }
            //        else
            //        {
            //            if (!item.Hidden)
            //            {
            //                 this.lbxLists.Items.Add(item.Title);
            //            }
            //        }

            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Get lists Field.");
            //}
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
            Thread t = new Thread(getList);
            t.Start();
            _runing = new Thread(displayRuning);
            _runing.Start("正在处理中...");
            //bool done = true;
            //while (done)
            //{
            //    if (this.lbxLists.Items.Count > 0 || this.btnConnect.Enabled)
            //    {
            //        runing.Abort();
            //        done = false;
            //    }

            //}
            ////Three minutes Time out    
            //bool tout = t.Join(10000);
            //while (1 > 0)
            //{
            //    if (tout)
            //    {
            //        runing.Abort();
            //        MessageBox.Show("Sorry，Time out!");
            //        this.btnConnect.Enabled = true;
            //        this.lblRuning.Text = "Sorry，Time out!.";
            //        Thread.Sleep(5000);
            //        this.lblRuning.Text = "";
            //        break;
            //    }
            //}

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
        }
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
                foreach (var item in fieldArr)
                {
                    this.cklbFields.Items.Add(item);
                }
            }
            _runing.Abort();
            Thread.Sleep(5000);
            this.lblRuning.Text = "";
        }
    }
}
