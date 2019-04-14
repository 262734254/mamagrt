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
using System.Data.SqlClient;
public partial class MyHome_HomeList : System.Web.UI.Page
{
    #region 实例化对象
    HomeLinkManager manger = new HomeLinkManager(); //实例化主页列表对象
    HomeTypeManager TypeManager = new HomeTypeManager();//实例化类型对象 
    Tz888.BLL.MyHome.HomeTypeManager type = new Tz888.BLL.MyHome.HomeTypeManager();
    #endregion
   
    protected void Page_Load(object sender, EventArgs e)
    {

        if (string.IsNullOrEmpty(Page.User.Identity.Name))
        {
            Response.Redirect("/login.aspx?url=" + Page.Request.Url.ToString());
        }
        if (!IsPostBack)
        {
          
            TypeBind();//绑定类型信息
            BindType();//加载时绑定DropDownList
            PageBind();//网站管理页面绑定
        }
    }
    #region 修改网站管理页面信息
    ///// <summary>
    ///// 修改
    ///// </summary>
    ///// <param name="sender"></param>
    ///// <param name="e"></param>
    //protected void lkUpdate_Click(object sender, EventArgs e)
    //{
    //    LinkButton lk = (LinkButton)sender;
    //    int id = Convert.ToInt32(lk.CommandArgument);
    //    Response.Redirect("~/MyHome/UpdateMyHome.aspx?id=" + id);
    //    //Response.Write("<script>window.showModalDialog('UpdateMyHome.aspx?id=" + id + "','','dialogWidth:300px;dialogHeight:300px;scroll:no;status:no');</script>");


    //}
    #endregion

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
        string LoginName =Page.User.Identity.Name;
        DataTable ds = manger.GetAllhome(LoginName);
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

    #region 绑定类型分页事件
    /// <summary> 
    /// 绑定类型分页事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void AspNetPager2_PageChanged(object sender, EventArgs e)
    {
        TypeBind();
    }
    #endregion

    #region 状态显示
    /// <summary>类型显示
    /// 类型显示
    /// </summary>
    /// <param name="o"></param>
    /// <returns></returns>
    public string HomeState(object o)
    {
        string result = "";
        int i = (int)o;
        switch (i)
        {
            case 0:
                result = "<font color='red'>禁用</font>";
                break;
            case 1:
                result = "<font color='green'>启用</font>";
                break;

        }
        return result;
    }
    #endregion

    #region 绑定类型信息
    /// <summary>
    /// 绑定类型信息
    /// </summary>
    public void TypeBind()
    {
        AspNetPager2.PageSize = 6;
        string LoginName =Page.User.Identity.Name;
        DataTable ds = TypeManager.GetAlTypeId(LoginName);
        DataView dv = ds.DefaultView;

        PagedDataSource pds = new PagedDataSource();
        AspNetPager2.RecordCount = dv.Count;
        pds.DataSource = dv;
        pds.AllowPaging = true;
        pds.CurrentPageIndex = AspNetPager2.CurrentPageIndex - 1;
        pds.PageSize = AspNetPager2.PageSize;
        Repeater2.DataSource = pds;
         Repeater2.DataBind();

    }
    #endregion

    #region 修改类型
    ///// <summary>
    ///// 修改
    ///// </summary>
    ///// <param name="sender"></param>
    ///// <param name="e"></param>
    //protected void lknUpdateType_Click(object sender, EventArgs e)
    //{
    //    LinkButton lk = (LinkButton)sender;
    //    int id = Convert.ToInt32(lk.CommandArgument);
    //    Response.Redirect("~/MyHome/UpdateHomeType.aspx?id=" + id);
    //    //Response.Write("<script>window.showModalDialog('UpdateMyHome.aspx?id=" + id + "','','dialogWidth:300px;dialogHeight:300px;scroll:no;status:no');</script>");

    //}
    #endregion

    #region 删除类型事件
    /// <summary>
    /// 删除事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LnkdelteType_Command(object sender, CommandEventArgs e)
    {
        int Id = Convert.ToInt32(e.CommandArgument);
        TypeManager.deleteHomeType(Id);
        if (Id > 0)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('删除成功！');", true);
            TypeBind();
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('删除失败！');", true);
        }
    }
    #endregion

    #region 类型信息下拉列表绑定

    /// <summary>
    ///类型信息绑定
    /// </summary>
    public void BindType()
    {
        string LoginName = Page.User.Identity.Name;
        this.ddlType.DataSource = type.GetHomeTypeList(LoginName);
        this.ddlType.DataTextField = "TypeName";
        this.ddlType.DataValueField = "TID";
        this.DataBind();
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

    #region 查询总记录数
    public int GetAllNumber(string typeName, string LoginName)
    {

        string sql = "select count(lid)  from HomeLink where Nid in(select Tid From HomeType where Typename= @typeName and LoginName= @LoginName)";
        SqlParameter[] para = new SqlParameter[] 
          {
             new SqlParameter("@typeName",typeName),
             new SqlParameter("@LoginName",LoginName)

          };
        int num = Convert.ToInt32(Tz888.DBUtility.DbHelperSQL.GetSingle(sql.ToString(), para));
        return num;

    }
    #endregion

    #region 添加主页信息
    protected void btnAdHomelist_Click(object sender, EventArgs e)
    {
        MyHomeLink home = new MyHomeLink();
        home.LName = txtName.Text; //网站名称
        home.Linkwww = txtlink.Text.ToString();//连接地址
        home.PassWord = txtPass.Text;//密码
        home.UserName = txtNumber.Text;//帐号
        home.WSort = Convert.ToInt32(txtsorct.Text);//排序
        home.LoginName = Page.User.Identity.Name.Trim();
        home.CreateTimes = DateTime.Now;//创建时间
        home.Typeid.TID = Convert.ToInt32(ddlType.SelectedValue); //类型
        home.LoginID = 1;
        home.WDoc = txtDOC.Text;//备注
        if (rdostate.SelectedValue == "启用")
        {
            home.States = 1;
        }
        else
        {
            home.States = 0;
        }
        int num = manger.InsertHomeLink(home);
        if (num > 0)
        {

            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('添加成功！');", true);
            PageBind();
        }
        else
        {
            Response.Write("<script>alert('添加失败！');</script>");
        }
    } 
    #endregion

    #region 新建分类事件
    protected void btnType_Click(object sender, EventArgs e)
    {
        
        MyHomeType type = new MyHomeType();
        type.TypeName = txtType.Text;
        type.Datatimes = DateTime.Now;
        type.LoginID = 1;
        type.LoginName = Page.User.Identity.Name.Trim();
        type.sort = Convert.ToInt32(txtTypeSort.Text);

        int num = TypeManager.InsertHomeType(type);

        if (num > 0)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('添加成功！');", true);
            TypeBind();
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('添加失败，或者数量已超过6条');", true);
        }
    } 
    #endregion
}
