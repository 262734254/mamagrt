using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace Tz888.Common
{
    /// <summary>
    /// ҳ����ת��

    /// </summary>
    public abstract class Message
    {
        public Message()
        {
            //
            // TODO: �ڴ˴���ӹ��캯���߼�
            //
        }
        /// <summary>
        /// ��ʾ��Ϣ������

        /// </summary>
        /// <param name="word">��ʾ��Ϣ</param>
        public static void back(string word)
        {
            System.Web.HttpContext.Current.Response.Write("<script language='javascript'>");
            System.Web.HttpContext.Current.Response.Write("alert('" + word + "');");
            System.Web.HttpContext.Current.Response.Write("history.back();");
            System.Web.HttpContext.Current.Response.Write("</script>");
        }

        /// <summary>
        /// ˢ��������
        /// </summary>
        /// <param name="word">�����</param>
        public static void ShowAndReLoad(string word, string rurl)
        {
            System.Web.HttpContext.Current.Response.Write("<script language='javascript'>");
            System.Web.HttpContext.Current.Response.Write("alert('" + word + "');");
            System.Web.HttpContext.Current.Response.Write("self.location='" + System.Web.HttpContext.Current.Request.UrlReferrer.ToString() + "';parent.leftFrame.location.href='" + rurl + "';");
            System.Web.HttpContext.Current.Response.Write("</script>");
        }
        /// <summary>
        /// ˢ��������
        /// </summary>
        /// <param name="word">�����</param>
        public static void ShowAndReLoad(string word, string url, string rurl)
        {
            System.Web.HttpContext.Current.Response.Write("<script language='javascript'>");
            System.Web.HttpContext.Current.Response.Write("alert('" + word + "');");
            System.Web.HttpContext.Current.Response.Write("self.location='" + url + "';parent.leftFrame.location.href='" + rurl + "';");
            System.Web.HttpContext.Current.Response.Write("</script>");
        }
        /// <summary>
        /// ��ʾ��Ϣ����ת
        /// </summary>
        /// <param name="word">��ʾ��Ϣ</param>
        /// <param name="url">��תҳ��</param>
        public static void Show(string word, string url)
        {
            System.Web.HttpContext.Current.Response.Write("<script language='javascript'>");
            System.Web.HttpContext.Current.Response.Write("alert('" + word + "');");
            System.Web.HttpContext.Current.Response.Write("self.location='" + url + "';");
            System.Web.HttpContext.Current.Response.Write("</script>");
        }
        /// <summary>
        /// ��ʾ��Ϣ����ת���ϴ�����ҳ��
        /// </summary>
        /// <param name="word">��ʾ��Ϣ</param>
        public static void Show(string word)
        {
            System.Web.HttpContext.Current.Response.Write("<script language='javascript'>");
            System.Web.HttpContext.Current.Response.Write("alert('" + word + "');");
            System.Web.HttpContext.Current.Response.Write("self.location='" + System.Web.HttpContext.Current.Request.UrlReferrer.ToString() + "';");
            System.Web.HttpContext.Current.Response.Write("</script>");
        }

        /// <summary>
        /// ��ʾ��Ϣ���Ӹ�������ת

        /// </summary>
        /// <param name="word">��ʾ��Ϣ</param>
        /// <param name="url">��תҳ��</param>
        public static void to_parent(string word, string url)
        {
            System.Web.HttpContext.Current.Response.Write("<script language='javascript'>");
            System.Web.HttpContext.Current.Response.Write("alert('" + word + "');");
            System.Web.HttpContext.Current.Response.Write("parent.location='" + url + "';");
            System.Web.HttpContext.Current.Response.Write("</script>");
        }

        /// <summary>
        /// �Ӹ�������ת
        /// <param name="url">��תҳ��</param>
        public static void to_parent(string url)
        {
            System.Web.HttpContext.Current.Response.Write("<script language='javascript'>");
            System.Web.HttpContext.Current.Response.Write("parent.location='" + url + "';");
            System.Web.HttpContext.Current.Response.Write("</script>");
        }

        /******************ȡ�ַ���**************************/

        /// <summary>
        /// �ض��ַ���
        /// </summary>
        /// <param name="str">�ַ���</param>
        /// <param name="num">����</param>
        /// <returns>���</returns>
        public static string getNumstring(string str, int num)
        {
            string nstr = "";
            //byte[] mybyte = System.Text.Encoding.Default.GetBytes(str);   //��Ϊ���ĳ���Ϊ2
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