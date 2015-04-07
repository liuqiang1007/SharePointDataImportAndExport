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
using System.Windows.Forms;

namespace SharePointDataImportAndExport
{
    public partial class Main : System.Windows.Forms.Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void btnLoadLists_Click(object sender, EventArgs e)
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

            ArrayList lists = getInfo.getLists(spContext, hidden);
            if (lists!=null&&lists.Count>0)
            {
                foreach (var item in lists)
                {
                    this.lbxLists.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("Get lists Field.");
            }
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
    }
}
