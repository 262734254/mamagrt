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
    /// MessageBox ��ժҪ˵��
    /// </summary>
    public class MessageBox : System.Web.UI.UserControl
    {
        public MessageBox()
        {
       
        }

        /// <summary>
        /// ��ʾ��Ϣ��ʾ�Ի���
        /// </summary>
        /// <param name="page">��ǰҳ��ָ�룬һ��Ϊthis</param>
        /// <param name="msg">��ʾ��Ϣ</param>
        public static void Show(System.Web.UI.Page page, string msg)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>alert('" + msg.ToString() + "');</script>");
        }

        /// <summary>
        /// ��ʾ����
        /// </summary>
        /// <param name="page">��ǰҳ��ָ�룬һ��Ϊthis</param>
        /// <param name="msg">������Ϣ</param>
        public static void ShowFunction(System.Web.UI.Page page, string function)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "function", "<script language='javascript' defer>" + function.ToString() + "</script>");
        }

        /// <summary>
        /// �ؼ���� ��Ϣȷ����ʾ��
        /// </summary>
        /// <param name="page">��ǰҳ�滷��,һ��Ϊthis</param>
        /// <param name="msg">Ҫ��ʾ����Ϣ</param>
        /// <param name="trueDoSomething">�����ȷ����Ҫ������(JavaScript�ű�)</param>
        /// <param name="falseDoSomething">�����ȡ����Ҫ������(JavaScript�ű�)</param>
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
        /// ��ʾ��Ϣ��ʾ�Ի��򣬲�����ҳ����ת�����������
        /// </summary>
        /// <param name="page">��ǰҳ��ָ�룬һ��Ϊthis</param>
        /// <param name="msg">��ʾ��Ϣ</param>
        /// <param name="url">��ת��Ŀ��URL</param>
        public static void ShowAndRedirect(System.Web.UI.Page page, string msg, string url)
        {
            ShowAndRedirect(page, msg, url, false);
        }
        /// <summary>
        /// ��ʾ��Ϣ��ʾ�Ի��򣬲�����ҳ����ת
        /// </summary>
        /// <param name="page">��ǰҳ��ָ�룬һ��Ϊthis</param>
        /// <param name="msg">��ʾ��Ϣ</param>
        /// <param name="url">��ת��Ŀ��URL</param>
        /// <param name="openPage">�Ƿ��������</param>
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
        /// ��ʾ��Ϣȷ����ʾ��
        /// </summary>
        /// <param name="page">��ǰҳ��ָ�룬һ��Ϊthis</param>
        /// <param name="msg">��ʾ��Ϣ</param>
        /// <param name="hiddenfield_name">���ر��ؼ���</param>
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
        /// ����Զ���ű���Ϣ
        /// </summary>
        /// <param name="page">��ǰҳ��ָ�룬һ��Ϊthis</param>
        /// <param name="script">����ű�</param>
        public static void ResponseScript(System.Web.UI.Page page, string script)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>" + script + "</script>");
        }

        /// <summary>
        /// ҳ������
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
        /// ������Ϣ��ת������һҳ
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
        /// ��ʾһ���������ڣ���ˢ��ת����һҳ
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
        /// ��ʾһ���������ڣ���ˢ��ת����һҳ
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

    
     
        #region ��Ϣ��ʾ���ж��Ƿ񷵻�ǰҳ
        /// <summary>
        /// ��Ϣ��ʾ���ж��Ƿ񷵻�ǰҳ
        /// </summary>
        /// <param name="txt">��Ϣ��ʾ����</param>
        /// <param name="bl">����ֵ</param>
        public static void Go(string txt, bool bl)
        {
            if (bl)
            {
                System.Web.HttpContext.Current.Response.Write("<script type='text/javascript'>alert('" + txt + "');history.go(-1);</script>");
            }
        }

        #endregion
        #region ��Ϣ��ʾ��ǰ��ָ��Url

        /// <summary>
        /// ��Ϣ��ʾ��ǰ��ָ��Url
        /// </summary>
        /// <param name="txt">��Ϣ����</param>
        /// <param name="url">ָ��ǰ����Url</param>
        public static void Go(string txt, string url)
        {
            System.Web.HttpContext.Current.Response.Write("<script type='text/javascript'>alert('" + txt + "');location.href='" + url + "';</script>");
        }

          #endregion
    }
}
