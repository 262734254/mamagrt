using System;
using System.Collections.Generic;
using System.Text;
using Tz888.IDAL.Common;
using Tz888.DALFactory;
using System.Data;

namespace Tz888.BLL.Common
{
    public class CommonFunction
    {
        private readonly ICommonFunction dal = DALFactory.DataAccess.CreateICommon_CommonFunction();

        public CommonFunction()
        {
 
        }
        #region  提示信息函数
        public static void ShowMessage(
            System.Web.UI.Page page,
            string Msg)
        {
            string script = "<script language='javascript'>alert('" + Msg + "');</script>";
            page.RegisterClientScriptBlock("SetList", script);
        }

        public static void ShowMessage(
            System.Web.HttpResponse response,
            string Msg)
        {

            response.Write("<script language='javascript'> \n window.alert('" + Msg + "');\n</script>\n");
        }
        public static void ShowMessage(
            System.Web.UI.Page page,
            string Msg,
            string Url)
        {
            page.Response.Write("<script language='javascript'> \n window.alert('" + Msg + "');location.href='" + Url + "';</script>");
        }

        public static bool SessionLose(
            System.Web.UI.Page page,
            string Url)
        {
            //SESSION丢失
            string returnUrl = Url + "?url=" + page.Request.Url.ToString();

            if (page.Session.Count == 0 ||
                (page.Session["valationNo"] != null &&
                page.Session.Count == 1))
            {
                page.Response.Write("<script>alert('操作已经超时，请重新登陆系统，谢谢！');location.href='" + returnUrl + "';</script>");
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool ExceptSessionLose(
            System.Web.UI.Page page,
            string Url)
        {
            //SESSION丢失
            string returnUrl = Url + "?url=" + page.Request.Url.ToString();

            if (page.Session.Count == 0 ||
                (page.Session["valationNo2"] == null &&
                page.Session.Count == 1))
            {
                page.Response.Write("<script>alert('操作已经超时，请重新登陆系统，谢谢！');location.href='" + returnUrl + "';</script>");
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool CheckSessionLose(
            System.Web.UI.Page page)
        {
            //SESSION丢失
            if (page.Session.Count == 0 ||
                (page.Session["valationNo"] != null &&
                page.Session.Count == 1))
            {
                page.Response.Write("<script>alert('你还没有登录或操作超时！请重新登陆！');</script>");
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CheckSessionLose(
            System.Web.UI.Page page,
            string Url)
        {
            //SESSION丢失
            string returnUrl = Url + "?url=" + page.Request.Url.ToString();
            if (page.Session.Count == 0 ||
                (page.Session["valationNo"] != null &&
                page.Session.Count == 1))
            {
                page.Response.Write("<script>alert('你还没有登录或操作超时！请重新登陆！');location.href='" + returnUrl + "';</script>");
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region-- 查询列表 ---------------
        /// <summary>
        /// 查询列表
        /// </summary>
        /// <param name="SelectCol">选择列</param>		
        /// <param name="Criteria">查询条件</param>
        /// <param name="OrderBy">排序</param>
        /// <param name="CurrentPage">显示的当前页号</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="PageCount">通过该查询条件，返回的查询记录的页数</param>
        /// <returns>查询列表</returns>
        public DataView GetList(
            string SPName,
            string SelectCol,
            string Criteria,
            string OrderBy,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount)
        {
            return (dal.GetListSet(           
                SPName,
                SelectCol,
                Criteria,
                OrderBy,
                ref CurrentPage,
                PageSize,
                ref PageCount));
        }
        #endregion

        #region 通过存储过程返回DataSetContact
        /// <summary>
        /// 通过存储过程返回DataSetContact
        /// </summary>
        /// <param name="spName"></param>
        /// <param name="Key"></param>
        /// <param name="SelectStr"></param>
        /// <param name="Criteria"></param>
        /// <param name="Sort"></param>
        /// <param name="TopNum"></param>
        /// <param name="CurrentPage"></param>
        /// <param name="PageSize"></param>
        /// <param name="TotalCount"></param>
        /// <returns></returns>
        
        public DataSet dsGetDsContactBySp( string spName,
          string InfoID)
        {
            return (dal.dsGetTopFirstNumContactBySP(spName,
                   InfoID));
        }

        #endregion 

        #region-- 查询列表 ---------------
        /// <summary>
        /// 查询列表
        /// </summary>
        /// <param name="SelectCol">选择列</param>		
        /// <param name="Criteria">查询条件</param>
        /// <param name="OrderBy">排序</param>
        /// <param name="CurrentPage">显示的当前页号</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="PageCount">通过该查询条件，返回的查询记录的页数</param>
        /// <returns>查询列表</returns>
        public DataTable GetDTFromTableOrView(
            string TableOrView,
            string Key,
            string SelectStr,
            string Criteria,
            string Sort,
            ref long CurrentPage,
            long PageSize,
            ref long TotalCount)
        {
            return (dal.GetDTFromTableOrView(
                TableOrView,
                Key,
                SelectStr,
                Criteria,                
                Sort,
                ref CurrentPage,
                PageSize,
                ref TotalCount));
        }
        #endregion

        #region 按指定长度截断字符串
        public static string ShortenString(int intLength, string strString)
        {
            if (intLength == 0)
            {
                return strString;
            }
            strString = strString.Replace("&nbsp;", " ");
            if (strString.Length > 0 && strString.Length > intLength)
            {
                if (intLength >= 25)
                {
                    strString = strString.Substring(0, intLength);
                }
                else
                {
                    //					string tmpString = strString.Substring(0,intLength);
                    //					System.Text.Encoding encoder = System.Text.Encoding.Default; 
                    //				
                    //					int byteLength = encoder.GetByteCount(tmpString);
                    //				while(bytes.Length  < intLength * 2 && tmpString.Length < strString.Length)
                    //				{
                    //					byteLength ++;
                    //					byteLength ++;
                    //					tmpString = strString.Substring(0,Convert.ToInt32(byteLength/2));
                    //					 
                    //					bytes = encoder.GetBytes(tmpString);
                    //					
                    //				}
                    //strString = tmpString;

                    string str = "";
                    if (strString.Length > 30)
                    {
                        str = strString.Substring(0, 30);
                    }
                    else
                    {
                        str = strString;
                    }
                    System.Text.Encoding encoder = System.Text.Encoding.Default;
                    byte[] bytes = encoder.GetBytes(str);
                    if (bytes.Length > intLength * 2)
                    {
                        str = encoder.GetString(bytes, 0, intLength * 2);
                    }
                    //					else
                    //					{
                    //						str = encoder.GetString(bytes);
                    //					}
                    strString = str.TrimEnd();
                }


            }
            //strString = strString.Replace( " ", "&nbsp;" );
            return strString;

        }
        #endregion
 

    }
}
