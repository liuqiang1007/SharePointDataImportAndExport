using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint.Client;
using System.Net;
using System.Collections;
using System.Globalization;

namespace SharePointDataImportAndExport
{
    /// <summary>
    /// get info from SharePoint site
    /// </summary>
    class GetInfoFromSharePoint
    {
        /// <summary>
        /// Lists rrturn in an array
        /// </summary>
        /// <param name="siteurl"></param>
        /// <param name="domain"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="hidden">true return contain hidden list</param>
        /// <returns></returns>
        public ArrayList getLists(ClientContext spContext, bool hidden)
        {
            ArrayList listArr = new ArrayList();

            var web = spContext.Web;
            var lists = spContext.LoadQuery(web.Lists);
            spContext.ExecuteQuery();
            if (lists != null)
            {
                foreach (List item in lists)
                {
                    //hidden =true, add hide list to listArr
                    if (hidden)
                    {
                        listArr.Add(item.Title);
                    }
                    else
                    {
                        if (!item.Hidden)
                        {
                            listArr.Add(item.Title);
                        }
                    }
                }
            }
            return listArr;
        }

    }
}
