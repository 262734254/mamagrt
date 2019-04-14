using System;
using System.Collections;
using System.Configuration;
using System.Data;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;


public partial class PayManage_ServiesRCList : System.Web.UI.Page
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        bool isTof = Page.User.IsInRole("GT1002");

        if (isTof)
        {
            Page.MasterPageFile = "/indexTof.master";
        }
        else
        {
            Page.MasterPageFile = "/MasterPage.master";
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (string.IsNullOrEmpty(Page.User.Identity.Name))
            {
                Response.Redirect("~/Login.aspx?ReturnUrl=" + Server.UrlEncode(Request.RawUrl));
            }
            if (Page.User.Identity.Name != null && Page.User.Identity.Name.Trim() != "")
            {
            Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
            DataTable dt = dal.GetList("LoginInfoTab", "ManageTypeID", "LoginID", 1, 1, 0, 1, "LoginName='"+Page.User.Identity.Name.ToString()+"' ");

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    string managetype = dt.Rows[0]["ManageTypeID"].ToString();
                    
                    manage(managetype);
                    
                }
            }
                //toBind(Page.User.Identity.Name.Trim());
                if (!string.IsNullOrEmpty(Request.QueryString["Servies"]))
                {
                    ServiesBind(Request.QueryString["Servies"]);
                }
                else { ServiesBind(); }
            }
        }
    }
    //判断用户类型2006人才类型 2005机构类型
    private void manage(string managetype)
    {
        int type = int.Parse(managetype);

        if (type == 2006)
        {
           
            Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
            DataTable dt = dal.GetList("SS_ProfessionalServices", "*", "PSID", 1, 1, 0, 1, "LoginName='"+Page.User.Identity.Name.ToString()+"'");
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    this.Name.Text = dt.Rows[0]["RealName"].ToString();
                    if (!string.IsNullOrEmpty(dt.Rows[0]["Regdate"].ToString()))
                    {
                        this.date.Text = getDate(dt.Rows[0]["Regdate"].ToString());
                    }
                    if(!string.IsNullOrEmpty(dt.Rows[0]["IsChekUp"].ToString()))
                    {
                        this.state.Text = getState(dt.Rows[0]["IsChekUp"].ToString());
                    }
                    Literal2.Text = " <a href=\"ServiesRCList.aspx?Servies=" + dt.Rows[0]["ServiceBigtype"].ToString() + "\" > 智能匹配|</a>";
                    Literal3.Text = "<a href=\"../Register/RegServiesProfessional.aspx?alt=1&PSID=" + dt.Rows[0]["PSID"].ToString() + "\"> 修改</a>";
                    Literal4.Text =dt.Rows[0]["IsChekUp"].ToString()=="1"? "<a href='http://Union.topfo.com/ServiceProsession.aspx?Psid="+dt.Rows[0]["PSID"].ToString()+"&Structid="+dt.Rows[0]["TalentType"].ToString()+"'>查看</a>":"";
                }
            }


        }
        else if (type == 2007)
        {
            Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
            DataTable dt = dal.GetList("SS_Agency_Services", "*", "OrganID", 1, 1, 0, 1, "LoginName='"+Page.User.Identity.Name.ToString()+"'");
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    this.Name.Text = dt.Rows[0]["OrganName"].ToString();
                    if (!string.IsNullOrEmpty(dt.Rows[0]["Regdate"].ToString()))
                    {
                        this.date.Text = getDate(dt.Rows[0]["Regdate"].ToString());
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["IsChekUp"].ToString()))
                    {
                        this.state.Text = getState(dt.Rows[0]["IsChekUp"].ToString());
                    }
                    Literal2.Text = " <a href=\"ServiesRCList.aspx?Servies=" + dt.Rows[0]["ServiceBigtype"].ToString() + "\" > 智能匹配</a>";
                    Literal3.Text = "|<a href=\"../Register/RegServiesStruct.aspx?alt=1&OrganID=" + dt.Rows[0]["OrganID"].ToString() + "\">| 修改</a>";
                   
                }

            }

        }
    }
    //protected void toBind(string name)
    //{
    //    Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
    //    DataTable dt = dal.GetList("SS_ProfessionalServices", "*", "PSID", 1, 1, 0, 1, "LoginName='"+name+"'");
    //    RC.DataSource = dt;
    //    RC.DataBind();
    //}
    protected void ServiesBind()
    {
        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        DataTable dt = dal.GetList("ReleaseTabViw", "InfoID,ServiesBID,ServiesMID,Title,CreateDate,Price,AuditStatus,AuditStatus", "CreateDate ", 5, 1, 0, 1, "AuditStatus=1 and UserName!='"+Page.User.Identity.Name.ToString()+"'");
        ServiesList.DataSource = dt;
        ServiesList.DataBind();
        Literal1.Text = "最新五条";
    }
    protected void ServiesBind(string Servies)
    {
        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        DataTable dt = dal.GetList("ReleaseTabViw", "InfoID,ServiesBID,ServiesMID,Title,CreateDate,Price,AuditStatus,AuditStatus", "CreateDate ", 5, 1, 0, 1, "AuditStatus=1 and UserName!='" + Page.User.Identity.Name.ToString() + "'  and ServiesBID like  '%" + Servies + "%'");
        ServiesList.DataSource = dt;
        //Tz888.BLL.Union dal = new Tz888.BLL.Union();
        //DataTable dt = dal.GetList("ServiesBID,ServiesMID,CompanyName,CreateDate,Price,AuditStatus,BID,AuditStatus", "BusinesProcessTab", "where AuditStatus=1 and ServiesBID like  '%" + Servies + "%' order by CreateDate desc", 5);
        ServiesList.DataSource = dt;
        ServiesList.DataBind();
        Literal1.Text = "与'" + getsetServiesBigName(Servies) + "'匹配的";

    }

    protected string getState(string StateID)
    {
        string str = "";
        if (StateID == "0")
        {
            str = "未审核";
        }
        else if (StateID == "1")
        {
            str = "审核通过";
        }
        else { str = "审核失败"; }
        return str;
    }

    protected string getDate(string time)
    {
        if (!string.IsNullOrEmpty(time))
        {
            return DateTime.Parse(time).ToString("yyyy-MM-dd");
        }
        else { return ""; }
    }
    protected string getsetServiesBigName(string StructID)
    {
        string str = "";
        if (!string.IsNullOrEmpty(StructID))
        {
            Tz888.BLL.Union dal = new Tz888.BLL.Union();
            DataTable dt = dal.GetList("ServiesBName", "setServiesBigTab", "where ServiesBID=" + StructID, 5);
            if (dt.Rows.Count > 0)
            {
                str = dt.Rows[0]["ServiesBName"].ToString();
            }
        }
        return str;
    }
    protected string getServiesSmallName(string StructID)
    {
        string str = "";
        if (!string.IsNullOrEmpty(StructID))
        {
            Tz888.BLL.Union dal = new Tz888.BLL.Union();
            DataTable dt = dal.GetList("ServiesMName", "setServiesSmallTab", "where ServiesMID=" + StructID, 5);
            if (dt.Rows.Count > 0)
            {
                str = dt.Rows[0]["ServiesMName"].ToString();
            }
        }
        return str;
    }
}
