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
    /// RegexInfo�ṹ,�����洢��xml�ļ��ж�ȡ�������� 
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
    /// ����URL��д
    /// </summary>
    public class UrlRewriter : IHttpHandler   //ʵ��IHttpHandler�ӿ� 
    {
        private List<RegexInfo> _regex_list = new List<RegexInfo>();
        /// <summary>
        /// ���캯��
        /// </summary>
        public UrlRewriter()
        {           
            DataSet ds = new DataSet();
            //��ȡurl��д�����ļ�,��д��RegexInfo�ṹ��ʵ���� 
            ds.ReadXml(System.Web.HttpContext.Current.Server.MapPath("~/AppConfig/setting/Regexs.xml"));
            foreach (DataRow r in ds.Tables["regex"].Rows)
                _regex_list.Add(new RegexInfo(((string)r["b"]).Trim(), ((string)r["a"]).Trim()));
            ds.Reset();
        }
        /// <summary>
        /// �滻��дURL
        /// </summary>
        /// <param name="context">HttpContext����</param>
        public void ProcessRequest(HttpContext context)
        {
            string path = context.Request.Path.ToLower();   //��ȡ��ǰ���ʵ���д�������URL 
            foreach (RegexInfo r in _regex_list)
                path = Regex.Replace(path, r._before, r._after);      //ƥ�������ʵ��URL 
            context.Server.Execute(path);
        }

        // ��д IsReusable ����. 
        public bool IsReusable
        {
            get { return true; }
        }
    }
}
