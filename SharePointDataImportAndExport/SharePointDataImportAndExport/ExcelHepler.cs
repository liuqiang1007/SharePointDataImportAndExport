﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharePointDataImportAndExport
{
    class excelHelper
    {
        //加载Excel   
        public DataSet LoadDataFromExcel(string filePath)
        {
            //连接字符串
            string connstring = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties='Excel 8.0;HDR=NO;IMEX=1';";  // Office 07及以上版本不能出现多余的空格 而且分号注意
            //string connstring = Provider=Microsoft.JET.OLEDB.4.0;Data Source=" + path + ";Extended Properties='Excel 8.0;HDR=NO;IMEX=1';";  
            //Office 07以下版本 因为本人用Office2010 所以没有用到这个连接字符串  可根据自己的情况选择 或者程序判断要用哪一//个连接字符串

            using (OleDbConnection conn = new OleDbConnection(connstring))
            {
                conn.Open();
                DataTable sheetsName = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "Table" });  //得到所有sheet的名字    
                string firstSheetName = sheetsName.Rows[0][2].ToString();   //得到第一个sheet的名字    
                string sql = string.Format(@"SELECT * FROM [{0}]",firstSheetName);  //查询字符串     
                OleDbDataAdapter ada = new OleDbDataAdapter(sql, connstring);
                DataSet set = new DataSet();
                ada.Fill(set);
                return set;
            }
        }
        ///<summary>
        ///读取csv格式的Excel文件的方法 
        ///</ummary>
        ///<param name="path">待读取Excel的全路径</param>
        ///<returns></returns>
        private DataTable ReadExcelWithStream(string path)
        {
            DataTable dt = new DataTable();
            bool isDtHasColumn = false;   //标记DataTable 是否已经生成了列   
            StreamReader reader = new StreamReader(path, System.Text.Encoding.Default);  //数据流   
            while (!reader.EndOfStream)
            {
                string message = reader.ReadLine();
                string[] splitResult = message.Split(',');  //读取一行 以逗号分隔 存入数组            
                DataRow row = dt.NewRow();       
                for (int i = 0; i < splitResult.Length; i++)
                {
                    if (!isDtHasColumn) //如果还没有生成列                  
                    {
                        dt.Columns.Add("column" + i, typeof(string));
                    }
                    row[i] = splitResult[i];
                }
                dt.Rows.Add(row);  //添加行            
                isDtHasColumn = true;  //读取第一行后 就标记已经存在列   再读取以后的行时，就不再生成列     
            }
            return dt;
        }
    }
}