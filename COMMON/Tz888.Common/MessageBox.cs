using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;

namespace Tz888.Common
{
    /// <summary>
    /// MessageBox 的摘要说明
    /// </summary>
    public class MessageBox : System.Web.UI.UserControl
    {
        public MessageBox()
        {
       
        }

        /// <summary>
        /// 显示消息提示对话框
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="msg">提示信息</param>
        public static void Show(System.Web.UI.Page page, string msg)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>alert('" + msg.ToString() + "');</script>");
        }

        /// <summary>
        /// 显示方法
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="msg">方法信息</param>
        public static void ShowFunction(System.Web.UI.Page page, string function)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "function", "<script language='javascript' defer>" + function.ToString() + "</script>");
        }

        /// <summary>
        /// 控件点击 消息确认提示框
        /// </summary>
        /// <param name="page">当前页面环境,一般为this</param>
        /// <param name="msg">要显示的信息</param>
        /// <param name="trueDoSomething">如果点确定后要做的事(JavaScript脚本)</param>
        /// <param name="falseDoSomething">如果点取消后要做的事(JavaScript脚本)</param>
        public static void ShowConfirm(System.Web.UI.Page page, string msg, string trueDoSomething, string falseDoSomething)
        {
            StringBuilder Builder = new StringBuilder();
            Builder.Append("<SCRIPT language='JavaScript' defer>");
            Builder.Append("if(confirm ('" + msg + "')){");
            Builder.Append("" + trueDoSomething + "}");
            Builder.Append("else{");
            Builder.Append("" + falseDoSomething + "}");
            Builder.Append("</SCRIPT>");

            page.ClientScript.RegisterStartupScript(page.GetType(), "message", Builder.ToString());
        }


                                                                      
        /// <summary>
        /// 显示消息提示对话框，并进行页面跳转，不跳出框架
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="msg">提示信息</param>
        /// <param name="url">跳转的目标URL</param>
        public static void ShowAndRedirect(System.Web.UI.Page page, string msg, string url)
        {
            ShowAndRedirect(page, msg, url, false);
        }
        /// <summary>
        /// 显示消息提示对话框，并进行页面跳转
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="msg">提示信息</param>
        /// <param name="url">跳转的目标URL</param>
        /// <param name="openPage">是否跳出框架</param>
        public static void ShowAndRedirect(System.Web.UI.Page page, string msg, string url, bool openPage)
        {
            StringBuilder Builder = new StringBuilder();
            Builder.Append("<script language='javascript' defer>");
            Builder.AppendFormat("alert('{0}');", msg);
            if (openPage)
                Builder.AppendFormat("top.location.href='{0}'", url);
            else
                Builder.AppendFormat("location.href='{0}'", url);
            Builder.Append("</script>");
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", Builder.ToString());

        }
        
        /// <summary>
        /// 显示消息确认提示框
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="msg">提示信息</param>
        /// <param name="hiddenfield_name">隐藏表单控件名</param>
        public static void confirm(System.Web.UI.Page page, string msg, string hiddenfield_name)
        {
            string sMsg = msg.Replace("\n", "\\n");
            sMsg = msg.Replace("\"", "'");

            StringBuilder sb = new StringBuilder();

            sb.Append(@"<INPUT type=hidden value='0' name='" +
              hiddenfield_name + "'>");

            sb.Append(@"<script language='javascript' defer>");

            sb.Append(@" if(confirm( """ + sMsg + @""" ))");
            sb.Append(@" { ");
            sb.Append("document.forms[0]." + hiddenfield_name + ".value='1';"
              + "document.forms[0].submit(); }");
            sb.Append(@" else { ");
            sb.Append("document.forms[0]." + hiddenfield_name + ".value='0'; }");

            sb.Append(@"</script>");

            page.ClientScript.RegisterStartupScript(page.GetType(), "message", sb.ToString());
        }
        /// <summary>
        /// 输出自定义脚本信息
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="script">输出脚本</param>
        public static void ResponseScript(System.Web.UI.Page page, string script)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>" + script + "</script>");
        }

        /// <summary>
        /// 页面重载
        /// </summary>
        public static void Location()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<script language=\"javascript\"> \n");
            sb.Append("window.location.href=window.location.href;");
            sb.Append("</script>");
            System.Web.HttpContext.Current.Response.Write(sb.ToString());

        }
        /// <summary>
        /// 弹出消息框，转向另外一页
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="url"></param>
        public static void ShowAndHref(string msg,string url)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<script language=\"javascript\"> \n");
            sb.Append("alert('" + msg + "');window.location.href='" + url + "'");
            sb.Append("</script>");
            System.Web.HttpContext.Current.Response.Write(sb.ToString());
        }
        /// <summary>
        /// 显示一个弹出窗口，并刷新转向上一页
        /// </summary>
        /// <param name="str"></param>
        public static void ShowPre(string str)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<script language=\"javascript\" defer> \n");
            sb.Append("alert(\"" + str.Trim() + "\"); \n");
            sb.Append("var p=document.referrer; \n");
            sb.Append("window.location.href=p;\n");
            sb.Append("</script>");
            System.Web.HttpContext.Current.Response.Write(sb.ToString());
        }

        /// <summary>
        /// 显示一个弹出窗口，不刷新转向上一页
        /// </summary>
        /// <param name="str"></param>
        public static void ShowBack(string str)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<script language=\"javascript\" defer> \n");
            sb.Append("alert(\"" + str.Trim() + "\"); \n");
            sb.Append("history.back();\n");
            sb.Append("</script>");
            System.Web.HttpContext.Current.Response.Write(sb.ToString());
        }

    
     
        #region 信息提示并判断是否返回前页
        /// <summary>
        /// 信息提示并判断是否返回前页
        /// </summary>
        /// <param name="txt">信息提示内容</param>
        /// <param name="bl">布尔值</param>
        public static void Go(string txt, bool bl)
        {
            if (bl)
            {
                System.Web.HttpContext.Current.Response.Write("<script type='text/javascript'>alert('" + txt + "');history.go(-1);</script>");
            }
        }

        #endregion
        #region 信息提示并前往指定Url

        /// <summary>
        /// 信息提示并前往指定Url
        /// </summary>
        /// <param name="txt">信息内容</param>
        /// <param name="url">指定前往的Url</param>
        public static void Go(string txt, string url)
        {
            System.Web.HttpContext.Current.Response.Write("<script type='text/javascript'>alert('" + txt + "');location.href='" + url + "';</script>");
        }

          #endregion
    }
}
