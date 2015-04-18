using Microsoft.SharePoint.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharePointDataImportAndExport
{
    class SPCOMHelper
    {
        public string Text(string text)
        {
            return text;
        }
        /// <summary>
        /// Url字段
        /// </summary>
        /// <param name="url"></param>
        /// <param name="description"></param>
        /// <param name="msg">返回成功或失败(即值在源列表中是否存在) 空则成功，不为空则失败</param>
        /// <returns></returns>
        public FieldUrlValue UrlValue(string url, string description,out string msg)
        {
            msg = "";
            FieldUrlValue uv = new FieldUrlValue();
            try
            {
                uv.Url = url;
                uv.Description = description;
            }
            catch (Exception)
            {
                msg = "Url格式不正确";
            }
            return uv;
        }
        /// <summary>
        /// 查阅项单选 赋值
        /// </summary>
        /// <param name="context">客户端上下文对象</param>
        /// <param name="sourceListId">查阅项字段 源列表ID</param>
        /// <param name="sourceFieldName">查阅项字段 源列表字段</param>
        /// <param name="value">查阅项值</param>
        /// <param name="msg">返回成功或失败(即值在源列表中是否存在) 空则成功，不为空则失败</param>
        /// <returns></returns>
        public FieldLookupValue Lookup(ClientContext context,string sourceListId, string sourceFieldName, string value,out string msg)
        {
            msg = "";
            FieldLookupValue lv = new FieldLookupValue();
            //获取查阅项值 对应的id
            string sourceIDForValue;
            List toList = context.Web.Lists.GetById(new Guid(sourceListId));
            context.Load(toList);
            context.ExecuteQuery();
            CamlQuery cqQuery = new CamlQuery();
            cqQuery.ViewXml = @"<View>  
            <Query> 
               <Where><Eq><FieldRef Name='" + fd + @"' /><Value Type='Text'>" + value + @"</Value></Eq></Where> 
            </Query> 
      </View>";
            ListItemCollection ltcCollection = toList.GetItems(cqQuery);
            context.Load(ltcCollection);
            context.ExecuteQuery();
            if (ltcCollection.Count > 0)
            {
                ListItem im = ltcCollection[0];
                sourceIDForValue = im.Id.ToString(CultureInfo.InvariantCulture);

                lv.LookupId = Convert.ToInt32(sourceIDForValue);
                lv.LookupValue = value;
            }
            else
            {
                //源列表中不存在
                msg = value + " Does not exist in the source list;";
            }
            return lv;
        }
        /// <summary>
        /// 查阅项多选 赋值
        /// </summary>
        /// <param name="context">客户端上下文对象</param>
        /// <param name="sourceListId">查阅项字段 源列表ID</param>
        /// <param name="sourceFieldName">查阅项字段 源列表字段</param>
        /// <param name="value">查阅项值 数组</param>
        /// <param name="msg">返回成功或失败(即值在源列表中是否存在) 空则成功，不为空则失败</param>
        /// <returns></returns>
        public List<FieldLookupValue> lookupArr(ClientContext context, string sourceListId, string sourceFieldName, ArrayList valueArr, out string msg)
        {
            msg = "";
            List<FieldLookupValue> lvList = new List<FieldLookupValue>();
            List toList = context.Web.Lists.GetById(new Guid(sourceListId));
            context.Load(toList);
            context.ExecuteQuery();
            foreach (var value in valueArr)
            {
                FieldLookupValue lv = new FieldLookupValue();
                //获取查阅项值 对应的id
                string sourceIDForValue;               
                CamlQuery cqQuery = new CamlQuery();
                cqQuery.ViewXml = @"<View>  
            <Query> 
               <Where><Eq><FieldRef Name='" + fd + @"' /><Value Type='Text'>" + value + @"</Value></Eq></Where> 
            </Query> 
      </View>";
                ListItemCollection ltcCollection = toList.GetItems(cqQuery);
                context.Load(ltcCollection);
                context.ExecuteQuery();
                if (ltcCollection.Count > 0)
                {
                    ListItem im = ltcCollection[0];
                    sourceIDForValue = im.Id.ToString(CultureInfo.InvariantCulture);

                    lv.LookupId = Convert.ToInt32(sourceIDForValue);
                    lv.LookupValue = value;
                    lvList.Add(lv);
                }
                else
                {
                    //源列表中不存在
                    msg += value + " Does not exist in the source list;";
                } 
            }
            return lvList;
        }

    }
}
