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
    /// 
    class GetInfoFromSharePoint
    {

        /// <summary>
        /// Lists return in an array
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

        /// <summary>
        /// get list array like "title@internalname@fileType"
        /// </summary>
        /// <param name="spcontext"></param>
        /// <param name="hidden">True contain Hidden field</param>
        /// <param name="listTitle"> listTitle</param>
        /// <returns></returns>
        public ArrayList getListFields(ClientContext spcontext, bool hidden, string listTitle)
        {
            ArrayList fieldArr = new ArrayList();
            if (!string.IsNullOrEmpty(listTitle))
            {
                var web = spcontext.Web;
                var listFields = spcontext.LoadQuery(web.Lists.GetByTitle(listTitle).Fields);
                spcontext.ExecuteQuery();
                foreach (var field in listFields)
                {
                    var fieldInfo = field.Title + "@" + field.InternalName + "@" + field.TypeAsString;
                    //如果是Outlook类型，获取 查阅项源list GUID,及源字段内部名称
                    if (field.TypeAsString.Contains("ook"))
                    {
                        FieldLookup flp = field as FieldLookup;
                        if (flp != null)
                        {
                            //源list GUID
                            var listId = flp.LookupList;
                            //源字段 内部名称
                            var listField = flp.LookupField;
                            //显示名称@内部名称@字段类型@查阅项源list GUID@查阅项源字段内部名称
                            fieldInfo += "@" + listId + "@" + listFields;
                        }
                    }

                    //Filter readonly and hidden Fields
                    if (!field.ReadOnlyField)
                    {
                        if (!hidden)
                        {
                            if (!field.Hidden)
                            {
                                fieldArr.Add(fieldInfo);
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else
                        {
                            fieldArr.Add(fieldInfo);
                        }
                    }
                }
            }


            return fieldArr;
        }
        /// <summary>
        /// return Web and context in an array
        /// </summary>
        /// <param name="siteUrl">url</param>
        /// <param name="username">username</param>
        /// <param name="password">pwd</param>
        /// <param name="domain">domain</param>
        /// <returns></returns>
        public ArrayList getWeb(string siteUrl, string username, string password, string domain)
        {
            ArrayList wc = new ArrayList();
            // credentials
            NetworkCredential myCred = new NetworkCredential(username, password, domain);

            // new context
            ClientContext context = new ClientContext(siteUrl);
            context.Credentials = myCred;
            // web ref
            Web web = context.Web;

            // load context
            context.Load(web);
            context.ExecuteQuery();
            wc.Add(web);
            wc.Add(context);
            return wc;
        }
    }
}
