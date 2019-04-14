using System;
using System.IO;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

namespace Tz888.Common
{
    /// <summary>
    /// RegexInfo结构,用来存储从xml文件中读取到的数据 
    /// </summary>
    public struct RegexInfo
    {
        public string _before;
        public string _after;
        public RegexInfo(string before, string after)
        {
            _before = before.ToLower();
            _after = after.ToLower();
        }
    }
    /// <summary>
    /// 进行URL重写
    /// </summary>
    public class UrlRewriter : IHttpHandler   //实现IHttpHandler接口 
    {
        private List<RegexInfo> _regex_list = new List<RegexInfo>();
        /// <summary>
        /// 构造函数
        /// </summary>
        public UrlRewriter()
        {           
            DataSet ds = new DataSet();
            //读取url重写规则文件,并写入RegexInfo结构的实例中 
            ds.ReadXml(System.Web.HttpContext.Current.Server.MapPath("~/AppConfig/setting/Regexs.xml"));
            foreach (DataRow r in ds.Tables["regex"].Rows)
                _regex_list.Add(new RegexInfo(((string)r["b"]).Trim(), ((string)r["a"]).Trim()));
            ds.Reset();
        }
        /// <summary>
        /// 替换重写URL
        /// </summary>
        /// <param name="context">HttpContext对象</param>
        public void ProcessRequest(HttpContext context)
        {
            string path = context.Request.Path.ToLower();   //获取当前访问的重写过的虚假URL 
            foreach (RegexInfo r in _regex_list)
                path = Regex.Replace(path, r._before, r._after);      //匹配出其真实的URL 
            context.Server.Execute(path);
        }

        // 重写 IsReusable 属性. 
        public bool IsReusable
        {
            get { return true; }
        }
    }
}
