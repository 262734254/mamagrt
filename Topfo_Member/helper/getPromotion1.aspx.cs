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
using Tz888.BLL;

public partial class helper_getPromotion1 : System.Web.UI.Page
{
    protected string loginname = "";
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
        if (Page.User.Identity.Name == null || Page.User.Identity.Name.Trim() == "")
        {
            Response.Redirect("../Login.aspx");
        }
        AjaxPro.Utility.RegisterTypeForAjax(typeof(helper_getPromotion1));
        loginname = Page.User.Identity.Name;
        if (!Page.IsPostBack)
        {
            ViewState["CurrPage"] = 1;
            bind();

        }
    }
    protected string GetTitle(object obj)
    {
        string str = (string)obj;
        string msg = "";
        if (str.Length > 12)
        {
            msg = str.Substring(0, 10) + "...";
        }
        else
        {
            msg = str;
        }
        return msg;
    }

    //获取区域
    protected string GetQu(object obj)
    {
        string str = "";
        long CurrPage = Convert.ToInt64(ViewState["CurrPage"]);
        long TotalCount = 0;
        long infoId = Convert.ToInt64(obj);
        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        DataTable dt = dal.GetList("MerchantInfoTab", "infoId", "industryClassList,countrycode,Provinceid,cityid,countyid", "InfoId='" + infoId + "'", "InfoId desc", ref CurrPage, 1, ref TotalCount);
        if (dt.Rows.Count > 0)
        {
            DataTable dtPro = dal.GetList("setProvincetab", "provinceid", "provinceid,provincename", "provinceid='" + dt.Rows[0]["provinceid"].ToString().Trim() + "'", "provinceid desc", ref CurrPage, 1, ref TotalCount);
            DataTable dtcity = dal.GetList("setcitytab", "cityid", "cityid,cityname", "cityid='" + dt.Rows[0]["cityid"].ToString().Trim() + "'", "cityid desc", ref CurrPage, 1, ref TotalCount);
            if (dtPro.Rows[0]["provincename"].ToString() != "")
            {
                str += dtPro.Rows[0]["ProvinceName"].ToString() + "省&nbsp;";
                if (dtcity.Rows[0]["CityName"].ToString() != "")
                {
                    str += dtcity.Rows[0]["CityName"].ToString() + "市";
                }
            }
            else
            {
                str += "<font color='red'>暂无投资区域</font>";
            }
        }
        else
        {
            str += "<font color='red'>暂无投资区域</font>";
        }
        return str;
    }
    //获取行业
    protected string GetIndustry(object obj)
    {
        string str = "";
        string message = "";
        long CurrPage = Convert.ToInt64(ViewState["CurrPage"]);
        long TotalCount = 0;
        long infoId = Convert.ToInt64(obj);
        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        DataTable dt = dal.GetList("MerchantInfoTab", "infoId", "industryClassList,countrycode,Provinceid,cityid,countyid", "InfoId='" + infoId + "'", "InfoId desc", ref CurrPage, 1, ref TotalCount);
        if (dt.Rows.Count > 0)
        {
            string[] industryClassList = dt.Rows[0]["industryClassList"].ToString().Split(new char[] { ',' });
            for (int i = 0; i < industryClassList.Length; i++)
            {
                DataTable dt1 = dal.GetList("SetIndustryBTab", "sort", "industryBid,industryBname", "industryBid='" + industryClassList[i].Trim() + "'", "sort desc", ref CurrPage, 1, ref TotalCount);
                if (dt1.Rows.Count > 0)
                {
                    str += dt1.Rows[0]["industryBname"].ToString() + ",";
                }
            }
            if (str.Length == 0)
            {
                message = "<font color='red'>暂无行业</font>";
            }
            if (str.EndsWith(","))
            {
                message = str.Substring(0, str.Length - 1);
            }
        }
        else
        {
            message = "<font color='red'>暂无行业</font>";
        }
        return message;
    }
    public void bind()
    {
        loginname = "dragon4";
        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        long CurrPage = Convert.ToInt64(ViewState["CurrPage"]);
        long TotalCount = 0;
        DataTable dt = dal.GetList("SubscribeRecViw", "ID", "*", " PromotionStatu=1 and ReceiveLoginName='" + loginname + "'", "ID desc", ref CurrPage, 15, ref TotalCount);
        lblCount.Text = TotalCount.ToString();
        lblPageCount.Text = System.Math.Ceiling(Convert.ToDouble(TotalCount) / Convert.ToDouble(15)).ToString();
        lblCurrPage.Text = CurrPage.ToString();
        txtPage.Value = CurrPage.ToString();
        lblCount.Text = TotalCount.ToString();
        Pager();
        myList.DataSource = dt;
        myList.DataBind();
    }
    #region 翻页
    public void Pager()
    {
        if (ViewState["CurrPage"].ToString() == lblPageCount.Text)
        {
            NextPage.Enabled = false;
            LastPage.Enabled = false;
            if (lblPageCount.Text != "1")
            {
                FirstPage.Enabled = true;
                PerPage.Enabled = true;
            }
        }
        if (Convert.ToInt32(ViewState["CurrPage"]) < Convert.ToInt32(lblPageCount.Text))
        {

            if (lblPageCount.Text != "1")
            {
                NextPage.Enabled = true;
                LastPage.Enabled = true;
                FirstPage.Enabled = true;
                PerPage.Enabled = true;
            }
        }
        if (ViewState["CurrPage"].ToString() == "1")
        {
            FirstPage.Enabled = false;
            PerPage.Enabled = false;
            if (Convert.ToInt32(lblPageCount.Text) > 1)
            {
                NextPage.Enabled = true;
                LastPage.Enabled = true;
            }
        }
        if (lblCount.Text == "0" || lblCount.Text == "1")
        {
            FirstPage.Enabled = false;
            PerPage.Enabled = false;
            NextPage.Enabled = false;
            LastPage.Enabled = false;
        }
    }
    #endregion
    public string GetTypeName(object str)
    {
        if (str.ToString().Trim() == "Capital")
            return "投资资源";
        if (str.ToString().Trim() == "Project")
            return "融资资源";
        if (str.ToString().Trim() == "Merchant")
            return "招商资源";
        else
            return "";
    }
    public string GetNickName(object name)
    {
        Tz888.BLL.Conn dal = new Conn();
        DataTable dt = dal.GetList("LoginInfoTAB", "NickName", "LoginID", 1, 1, 0, 1, "LoginName='" + name.ToString().Trim() + "'");
        if (dt.Rows.Count > 0)
            return dt.Rows[0]["NickName"].ToString();
        else
            return "";
    }
    //删除推广
    [AjaxPro.AjaxMethod]
    public string DeleteInfo(string InfoArrList)
    {
        SubscribeSet dal = new SubscribeSet();
        string[] s = InfoArrList.Split(',');
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i].ToString() != "")
            {
                bool b = dal.DeleteInfo(Convert.ToInt64(s[i].ToString()));
                return "success";
            }
            else
            {
                return "fail";
            }
        }
        return "success";
    }
    //批量拒收
    [AjaxPro.AjaxMethod]
    public string NoReceive(string InfoArrList)
    {
        SubscribeSet dal = new SubscribeSet();
        string[] s = InfoArrList.Split(',');
        return s.Length.ToString() + InfoArrList;
    }
    //删除所有接收的推广
    [AjaxPro.AjaxMethod]
    public string DeleteAllInfo()
    {

        Tz888.BLL.SubscribeSet dal = new SubscribeSet();
        bool b = dal.DeleteAll(Page.User.Identity.Name);
        if (b)
        {
            return "success";
        }
        else
        {
            return "fail";
        }
    }
    /// <summary>
    /// 拒收 添加到黑名单
    /// </summary>
    /// <param name="sendLoginName"></param>
    /// <returns></returns>
    [AjaxPro.AjaxMethod]
    public string AddBlack(string sendLoginName)
    {
        return sendLoginName.Trim();
    }
    protected void FirstPage_Click(object sender, EventArgs e)
    {
        ViewState["CurrPage"] = 1;
        bind();
    }
    protected void PerPage_Click(object sender, EventArgs e)
    {
        ViewState["CurrPage"] = Convert.ToInt64(ViewState["CurrPage"]) - 1;
        bind();
    }
    protected void NextPage_Click(object sender, EventArgs e)
    {
        ViewState["CurrPage"] = Convert.ToInt64(ViewState["CurrPage"]) + 1;
        bind();
    }
    protected void LastPage_Click(object sender, EventArgs e)
    {
        ViewState["CurrPage"] = lblPageCount.Text;
        bind();
    }
    protected void btnGo_ServerClick(object sender, EventArgs e)
    {
        ViewState["CurrPage"] = txtPage.Value.Trim();
        bind();
    }
    protected void myList_ItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        long InfoID = Convert.ToInt64(e.CommandArgument);
        string msg = "";
        Tz888.BLL.Info.MainInfoBLL bll = new Tz888.BLL.Info.MainInfoBLL();
        switch (e.CommandName)
        {
            case "Delete":
                string ErrorMsg = "";
                if (!bll.UpdatePromotionStatu(InfoID, 0))
                    msg += "[" + InfoID.ToString() + "]删除失败！" + ErrorMsg + "\n";

                if (!string.IsNullOrEmpty(msg))
                    Tz888.Common.MessageBox.Show(this.Page, msg);
                this.bind();
                break;
            default:
                break;
        }
    }

}
