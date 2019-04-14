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
using System.Collections.Generic;
using Tz888.SQLServerDAL.MyHome;
using Tz888.Model.MyHome;
using Tz888.BLL.MyHome;
using Tz888.Pager;
using System.Text;
using System.Drawing;
using System.IO;
using Tz888.DBUtility;

public partial class MyHome_Default : System.Web.UI.Page
{
    #region 实例化对象
    HomeLinkManager manger = new HomeLinkManager(); //实例化主页列表对象
    HomeTypeManager TypeManager = new HomeTypeManager();//实例化类型对象 
    public static int Id;
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Page.User.Identity.Name))
        {
            Response.Redirect("/login.aspx?url=" + Page.Request.Url.ToString());
        }
        if (!IsPostBack)
        {
          
            if (Request.QueryString["Nid"] == null)
            {
                Response.Redirect("HomeList.aspx");
            }
            Id = int.Parse(Request.Params["Nid"].ToString());
            int id = Convert.ToInt32(Request.QueryString["Nid"]);
            PageBind();//网站管理页面绑定
        }
    }
    #region 获取类别
    /// <summary>
    /// 显示类别
    /// </summary>
    /// <param name="Id">Id</param>
    /// <returns></returns>
    public string ShowUserName(string UserId)
    {
        HomeTypeManager mbll = new HomeTypeManager();
        MyHomeType model = new MyHomeType();
        model = mbll.GetAllTypeById(Convert.ToInt32(UserId));
        string strTemp = string.Empty;
        if (model != null)
            strTemp = model.TypeName;
        return strTemp;
    }
    #endregion

    #region 修改网站管理页面信息
    /// <summary>
    /// 修改
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lkUpdate_Click(object sender, EventArgs e)
    {
        LinkButton lk = (LinkButton)sender;
        int id = Convert.ToInt32(lk.CommandArgument);
        Response.Redirect("~/MyHome/UpdateMyHome.aspx?id=" + id);
        //Response.Write("<script>window.showModalDialog('UpdateMyHome.aspx?id=" + id + "','','dialogWidth:300px;dialogHeight:300px;scroll:no;status:no');</script>");


    }
      #endregion

    #region 根据ID删除管理事件
    /// <summary>
    /// 删除记录
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton1_Command(object sender, CommandEventArgs e)
    {
        int Id = Convert.ToInt32(e.CommandArgument);
        manger.deleteMyHome(Id);
        if (Id > 0)
        {

            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('删除成功！');", true);
            PageBind();
        }

        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('删除失败！');", true);
        }
    }
    #endregion

    #region 网站管理页面数据绑定
    /// <summary>
    /// 页面数据绑定
    /// </summary>
    public void PageBind()
    {
        int id = Convert.ToInt32(Request.QueryString["Nid"]);
        string LoginName = Page.User.Identity.Name;
        DataTable ds = manger.GetAllhome(id, LoginName);
        DataView dv = ds.DefaultView;
        PagedDataSource pds = new PagedDataSource();
        AspNetPager1.PageSize = 10;
        AspNetPager1.RecordCount = dv.Count;
        pds.DataSource = dv;
        pds.AllowPaging = true;
        pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
        pds.PageSize = AspNetPager1.PageSize;
        Repeater1.DataSource = pds;
        Repeater1.DataBind();

        #region 存储过程分页错误代码
        //PageBase pb = new PageBase();

        //pb.TblName = "HomeLink";
        //pb.FldName = "LID";
        //pb.ProcedureName = "pagination";
        //pb.PageSize = pageSize;
        //if (cuttentPage == 0)
        //    cuttentPage = pb.PageIndex;
        //pb.PageIndex = cuttentPage;
        //int count = 0;
        //pb.DoCount = 1;
        //manger.GetList(pb, ref count); //获取总条数

        //pb.DoCount = 0;
        //List<MyHomeLink> modelList = new List<MyHomeLink>();
        ////数据绑定
        //Repeater1.DataSource = modelList;
        //Repeater1.DataBind();

        ////数据分页
        //MTCPager1.PageSize = pageSize;

        //MTCPager1.RecordCount = count;
        //MTCPager1.PageIndex = cuttentPage;
        //if (count <= pb.PageSize)
        //    MTCPager1.Visible = false;
        //else
        //    MTCPager1.Visible = true; 
        #endregion

    }


    #endregion

    #region 绑定管理主页分页事件
    /// <summary> 
    /// 分页事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        PageBind();
    }
    #endregion

    #region 获取地址长度
    /// <summary>
    /// 获取文地址的长度
    /// </summary>
    /// <param name="title">标题</param>
    /// <param name="n">大小</param>
    /// <returns></returns>
    public string GetTitle(string title, int n)
    {

        string str = "";
        if (title != "")
        {
            str = title.Length > n ? title.ToString().Substring(0, n) + ".." : title;
        }
        return str;

    }
    #endregion
}
