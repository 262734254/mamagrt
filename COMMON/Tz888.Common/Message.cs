using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace Tz888.Common
{
    /// <summary>
    /// 页面跳转类

    /// </summary>
    public abstract class Message
    {
        public Message()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        /// <summary>
        /// 提示信息并返回

        /// </summary>
        /// <param name="word">提示信息</param>
        public static void back(string word)
        {
            System.Web.HttpContext.Current.Response.Write("<script language='javascript'>");
            System.Web.HttpContext.Current.Response.Write("alert('" + word + "');");
            System.Web.HttpContext.Current.Response.Write("history.back();");
            System.Web.HttpContext.Current.Response.Write("</script>");
        }

        /// <summary>
        /// 刷新左则框架
        /// </summary>
        /// <param name="word">框架名</param>
        public static void ShowAndReLoad(string word, string rurl)
        {
            System.Web.HttpContext.Current.Response.Write("<script language='javascript'>");
            System.Web.HttpContext.Current.Response.Write("alert('" + word + "');");
            System.Web.HttpContext.Current.Response.Write("self.location='" + System.Web.HttpContext.Current.Request.UrlReferrer.ToString() + "';parent.leftFrame.location.href='" + rurl + "';");
            System.Web.HttpContext.Current.Response.Write("</script>");
        }
        /// <summary>
        /// 刷新左则框架
        /// </summary>
        /// <param name="word">框架名</param>
        public static void ShowAndReLoad(string word, string url, string rurl)
        {
            System.Web.HttpContext.Current.Response.Write("<script language='javascript'>");
            System.Web.HttpContext.Current.Response.Write("alert('" + word + "');");
            System.Web.HttpContext.Current.Response.Write("self.location='" + url + "';parent.leftFrame.location.href='" + rurl + "';");
            System.Web.HttpContext.Current.Response.Write("</script>");
        }
        /// <summary>
        /// 提示信息并跳转
        /// </summary>
        /// <param name="word">提示信息</param>
        /// <param name="url">跳转页面</param>
        public static void Show(string word, string url)
        {
            System.Web.HttpContext.Current.Response.Write("<script language='javascript'>");
            System.Web.HttpContext.Current.Response.Write("alert('" + word + "');");
            System.Web.HttpContext.Current.Response.Write("self.location='" + url + "';");
            System.Web.HttpContext.Current.Response.Write("</script>");
        }
        /// <summary>
        /// 提示信息并跳转至上次请求页面
        /// </summary>
        /// <param name="word">提示信息</param>
        public static void Show(string word)
        {
            System.Web.HttpContext.Current.Response.Write("<script language='javascript'>");
            System.Web.HttpContext.Current.Response.Write("alert('" + word + "');");
            System.Web.HttpContext.Current.Response.Write("self.location='" + System.Web.HttpContext.Current.Request.UrlReferrer.ToString() + "';");
            System.Web.HttpContext.Current.Response.Write("</script>");
        }

        /// <summary>
        /// 提示信息并从父窗口跳转

        /// </summary>
        /// <param name="word">提示信息</param>
        /// <param name="url">跳转页面</param>
        public static void to_parent(string word, string url)
        {
            System.Web.HttpContext.Current.Response.Write("<script language='javascript'>");
            System.Web.HttpContext.Current.Response.Write("alert('" + word + "');");
            System.Web.HttpContext.Current.Response.Write("parent.location='" + url + "';");
            System.Web.HttpContext.Current.Response.Write("</script>");
        }

        /// <summary>
        /// 从父窗口跳转
        /// <param name="url">跳转页面</param>
        public static void to_parent(string url)
        {
            System.Web.HttpContext.Current.Response.Write("<script language='javascript'>");
            System.Web.HttpContext.Current.Response.Write("parent.location='" + url + "';");
            System.Web.HttpContext.Current.Response.Write("</script>");
        }

        /******************取字符串**************************/

        /// <summary>
        /// 截断字符串
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="num">长度</param>
        /// <returns>结果</returns>
        public static string getNumstring(string str, int num)
        {
            string nstr = "";
            //byte[] mybyte = System.Text.Encoding.Default.GetBytes(str);   //认为中文长度为2
            int len = str.Length;
            if (len > num)
            {
                nstr = str.Substring(0, num);
            }
            else
            {
                nstr = str;
            }
            return nstr;
        }
    }
}