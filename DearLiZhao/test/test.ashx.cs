using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Web.SessionState;
using Newtonsoft.Json;

namespace DearLiZhao.test
{
    /// <summary>
    /// test 的摘要说明
    /// </summary>
    public class test : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            Database db = DatabaseFactory.CreateDatabase("Connstr");
            String userName = context.Request["UserName"];
            string sql = string.Format("select * from article where title='{0}'", userName);
            DataSet ds = db.ExecuteDataSet(CommandType.Text, sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                //大于零代表登陆成功
                int id = (int)ds.Tables[0].Rows[0]["id"];
                context.Response.Write("1");
            }
            else
            {
                context.Response.Write("0");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}