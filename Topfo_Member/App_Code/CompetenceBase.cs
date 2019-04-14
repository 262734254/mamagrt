using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// CompetenceBase 的摘要说明
///拓富通会员权限基类
/// </summary>
public class CompetenceBase :Page
{
    Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
    public CompetenceBase()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    #region 获取当前页URL权限
    /// <summary>
    /// 获取当前页URL权限
    /// </summary>
    public string getCompetence()
    {
        string str = HttpContext.Current.Request.Url.ToString();
        string[] str0 = str.Split('?');
        int str1 = str0[0].LastIndexOf('/');
        int str2 = str0[0].Length;
        int str3 = str2 - (str1+1);
        string s = str0[0].Substring(str1+1, str3);
        string ret = "";
        try
        {
            DataRow[] dr = GetMenuCompetence().Select("Murl like '%" + s + "'");  //获取当前页的权限
            if (dr.Length > 0)
            {
                ret = dr[0]["MCode"].ToString();
            }
        }
        catch { }
        return ret;
    }
    #endregion

    #region 获取所有菜单,采用缓存cache
    /// <summary>
    /// 获取所有菜单,采用缓存cache
    /// </summary>
    /// <returns></returns>
    public DataTable GetMenuCompetence()
    {
        DataTable dt = new DataTable();
        try
        {
            if (AppCache.IsExist("MemberMenu"))
            {
                dt = (DataTable)AppCache.Get("MemberMenu");
            }
            else
            {
                dt = dal.GetList("*", "MenuTab", "where MCheck=1 and  MCode like 'M%'  order by Sort ");
                AppCache.AddCache("MemberMenu", dt, 24)
;
            }
        }
        catch
        {
            dt = null;
        }
        return dt;
    }
    #endregion

    #region 获取用户权限,采用缓存cache
    /// <summary>
    /// 获取所有菜单,采用缓存cache
    /// </summary>
    /// <returns></returns>
    public DataRow[] GetMemberCompetence()
    {
        DataRow[] dr = null ;
        DataTable dt = new DataTable();
        try
        {
            if (Session["MemberObj"] != null)
            {
                if (Session["MemberCompetence"] != null)
                {
                    dr = (DataRow[])Session["MemberCompetence"];
                }
                else
                {

                    string[] obj = (string[])Session["MemberObj"];
                    dt = GetMemberCompetenceAll();
                    dr = dt.Select("ManageTypeID='" + obj[1].ToString() + "' and MemberGradeID='" + obj[2].ToString() + "'");
                    //dt = dal.GetList("PCode", "SystemPermissionTab", "where ManageTypeID='" + obj[1].ToString() + "' and MemberGradeID='" + obj[2].ToString() + "'");
                    //AppCache.AddCache("MemberCompetence", dt, 24);
                    Session["MemberCompetence"] = dr;
                    dt.Dispose();
                    dt = null;
                }
            }

        }
        catch
        {
            dr = null;
        }
        return dr;
    }
    /// <summary>
    /// 取出所有权限,放入cache
    /// </summary>
    /// <returns></returns>
    public DataTable GetMemberCompetenceAll()
    {
        DataTable dt = new DataTable();
        try
        {

            if (AppCache.IsExist("MemberCompetenceAll"))
                {
                    dt = (DataTable)AppCache.Get("MemberCompetenceAll");
                }
                else
                {
                    dt = dal.GetList("PCode,ManageTypeID,MemberGradeID", "SystemPermissionTab", "");
                    AppCache.AddCache("MemberCompetenceAll", dt, 24);
                }
        }
        catch
        {
            dt = null;
        }
        return dt;
    }
    #endregion

    /// <summary>
    /// 判断用户是否有当前页URL权限，有则返回TRUE。否则返回FAULSE
    /// </summary>
    public bool JudgeCompetence()
    {  
        string Competence = MemberCompetence;
        bool ret = false;
       
        string comp = getCompetence();
        if (!string.IsNullOrEmpty(comp))
        {
            if (Competence.Contains(comp))
            {
                ret = true;
            }
        }
        return ret;
    }
    /// <summary>
    /// 用户权限
    /// </summary>
    public string MemberCompetence
    {
        get
        {
            string Competence = "";
            DataRow[] dr = GetMemberCompetence();
            if (dr != null)
            {
                if (dr.Length > 0)
                {
                    Competence = dr[0]["PCode"].ToString();
                }
            }
            //if (dt != null && dt.Rows.Count > 0)
            //{
            //    Competence = dt.Rows[0]["PCode"].ToString();
            //}
            return Competence;
        }
    }
}
