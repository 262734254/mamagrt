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

public partial class helper_myPromotion : System.Web.UI.Page
{
    Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
    protected string loginname = ""; //2010-06-14注释
    //protected string loginname = "hellocindy";  //2010-06-14新增
    protected void Page_PreInit(object sender, EventArgs e)
    {
        //bool isTof = Page.User.IsInRole("GT1002");

        //if (isTof)
        //{
        //    Page.MasterPageFile = "/indexTof.master";
        //}
        //else
        //{
        //    Page.MasterPageFile = "/MasterPage.master";
        //}
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        AjaxPro.Utility.RegisterTypeForAjax(typeof(helper_myPromotion));
        //if (Page.User.Identity.Name == null || Page.User.Identity.Name.Trim() == "")
        //{
        //    Response.Redirect("../Login.aspx");
        //}
        loginname = Page.User.Identity.Name; //2010-06-14注释
        loginname = "hellocindy";
        if (!Page.IsPostBack)
        {
            ViewState["CurrPage"] = 1;
            bind();
        }
    }
    [AjaxPro.AjaxMethod]
    public bool PromotionCount()
    {
        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        DataTable dt = dal.GetList("UserParametersTab", "PromotionCount", "parID", 1, 1, 0, 1, "LoginName='" + Page.User.Identity.Name.Trim() + "'");
        if (dt.Rows.Count > 0)
        {
            if (Convert.ToInt32(dt.Rows[0]["PromotionCount"].ToString()) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    public void bind()
    {
        long CurrPage = Convert.ToInt64(ViewState["CurrPage"]);
        long TotalCount = 0;
        //2010-06-15 新增PromotionStatu=1
        string strWhere = "LoginName='" + loginname + "' and AuditingStatus=1 and PromotionStatu=1 and DelStatus=0 and"
                       + "( (DATEADD(Month, ValidateTerm,ValidateStartTime)"
                       + "> GETDATE()) AND (ValidateStartTime <= GETDATE())"
                       + "OR (ValidateTerm = 0))";
        DataTable dt = dal.GetList("MainInfoTab", "InfoID", "InfoID,approvetime,LoginName,Title,HtmlFile", strWhere, "InfoID desc", ref CurrPage, 15, ref TotalCount);
        lblCount.Text = TotalCount.ToString();
        lblPageCount.Text = System.Math.Ceiling(Convert.ToDouble(TotalCount) / Convert.ToDouble(15)).ToString();
        lblCurrPage.Text = CurrPage.ToString();
        txtPage.Value = CurrPage.ToString();
        lblCount.Text = TotalCount.ToString();
        Pager();
        myList.DataSource = dt;
        myList.DataBind();

        DataTable dt1 = dal.GetList("UserParametersTab", "PromotionCount", "parid", 1, 1, 0, 1, "LoginName='" + loginname + "'");
        if (dt1.Rows.Count > 0)
        {
            int c = Convert.ToInt32(dt1.Rows[0].ItemArray[0].ToString());
            if (c > 0)
            {
                lblMsg.Text = "您现在还可以享有" + c.ToString() + "条定向推广服务，我们每天都将通过邮件、站内短信或手机短信方式向您的对口用户发送推广内容";
            }
            else
            {
                if (Page.User.IsInRole("GT1002"))
                {
                    lblMsg.Text = "您的免费定向推广服务已经使用完啦，请您尽快购买定向推广服务，以免贻误商机！";
                }
                else
                {
                    lblMsg.Text = "您现在还不能享有定向推广服务，请您尽快购买定向推广服务，以免贻误商机！";
                }
            }
        }
    }
    //推广方式  2010-06-15
    protected string Getpopularize(object infoid)
    {
        DataTable dt = dal.GetList("SubscribeSetTab", "subscribeType", "ID", 1, 1, 0, 1, "InfoID=" + Convert.ToInt64(infoid));
        string msg = "";
        if (dt.Rows.Count > 0)
        {
            string[] str = dt.Rows[0]["subscribeType"].ToString().Split(new char[] { ',' });

            for (int i = 0; i < str.Length; i++)
            {
                if (str.Length > 0)
                {
                    if (str[i].Equals("1"))
                    {
                        msg += "邮件" + ",";
                    }
                    if (str[i].Equals("2"))
                    {
                        msg += "站内短信" + ",";
                    }
                    if (str[i].Equals("3"))
                    {
                        msg += "手机短信";
                    }
                }
            }
        }
        if (msg == "")
        {
            msg = "<font  color='red'>暂无推广</font>";
        }
        return msg;
    }
    protected string GetTitle(object Title)
    {
        string msg = "";
        string title = Title.ToString();
        if (title.Length > 15)
        {
            msg = title.Substring(0, 11) + "...";
        }
        else
        {
            msg = title;
        }
        return msg;
    }
    //end
    //推广条数
    public string GetCount(object infoid, object flag)
    {
        DataTable dt = dal.GetList("SubscribeSetTab", "SubscribeCount,subscribeType,SubscribeOver", "ID", 1, 1, 0, 1, "InfoID=" + Convert.ToInt64(infoid));
        string m = flag.ToString();
        if (dt.Rows.Count > 0)
        {
            if (m == "1")
            {

                return dt.Rows[0]["SubscribeCount"].ToString();
            }
            if (m == "2")
            {
                return dt.Rows[0]["SubscribeOver"].ToString();
            }
            else
            {
                return "0";
            }
        }
        else
        {
            return "0";
        }
    }
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
    protected void myList_ItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        string msg = "";
        Tz888.BLL.Info.MainInfoBLL bll = new Tz888.BLL.Info.MainInfoBLL();
        long InfoID = Convert.ToInt64(e.CommandArgument);
        switch (e.CommandName)
        {
            case "Delete":
                string ErrorMsg = "";
                if (!bll.UpdatePromotionStatu(InfoID, 0))
                    msg += "[" + InfoID.ToString() + "]删除失败！" + ErrorMsg + "\n";

                if (!string.IsNullOrEmpty(msg))
                    Tz888.Common.MessageBox.Show(this.Page, msg);
                this.bind();
                this.Pager();
                break;
            case "promotion"://推广
                promotions(InfoID);
                this.bind();
                this.Pager();
                break;
            default:
                break;
        }
    }
    private void promotions(long infoid)
    {
        long CurrPage = Convert.ToInt64(ViewState["CurrPage"]);
        long TotalCount = 0;
        int payStatus = 0;//是否支付0为未付，1为支付
        int promotionStatu = 0;//1为己推广，其它为未推
        DataTable dt = dal.GetList("SubscribeSetTab", "ID,LoginName", "ID", 1, 1, 0, 1, "InfoID=" + Convert.ToInt64(infoid));
        int id = (int)dt.Rows[0]["ID"];//主键ID
        //string loginName = dt.Rows[0]["LoginName"].ToString();//登录名
        DataTable dt1 = dal.GetList("SmsConsumeRecOrder_view", "OrderNo", "*", " sid=" + id + " and LoginName='" + loginname + "'", "OrderNo desc", ref CurrPage, 1, ref TotalCount);
        if (dt1 != null && dt1.Rows.Count != 0)
        {
            //smallint
            string orderNo = dt1.Rows[0]["OrderNo"].ToString();
            payStatus = Convert.ToInt16(dt1.Rows[0]["payStatus"]);
            int recId = Convert.ToInt32(dt1.Rows[0]["Recid"]);
            
            if (payStatus == 0)
            {
                try
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Msg", "<script>alert('您还没有支付！');location.href='Promotionset.aspx?InfoID="+infoid+"';</script>", false);
                    #region
                    ////此条信息还未支付
                    //if (orderNo != "")
                    //{
                    //    string order = tzWeb.pay.comm.JiaMi(orderNo.ToString());
                    //    double userpoint = Convert.ToDouble(tzWeb.pay.comm.getUserPoint(loginname));
                    //    double orderpoint = Convert.ToDouble(tzWeb.pay.comm.getOrderPoint(Convert.ToInt64(orderNo)));
                    //    if (userpoint < orderpoint)
                    //    {
                    //        Response.Redirect("http://pay.topfo.com/otherpay.aspx?order_no=" + order, true);
                    //    }
                    //    else
                    //    {
                    //        //ScriptManager.RegisterStartupScript(this, this.GetType(), "Msg", "<script>alert('推广过这条资源1');location.href='Promotionset.aspx';</script>", false);
                    //        Response.Redirect("http://pay.topfo.com/account/accountpay.aspx?order_no=" + order, true);
                    //    }
                    //}
                    //else
                    //{
                    //    Response.Write("<script>alert('之前的订单可能己经丢失');location.href='Promotionset.aspx';</script>");
                    //}
                    #endregion
                }
                catch (Exception e)
                {
                    Response.Write(e.ToString());
                }
            }
            else //payStatus=1
            {
                //此条信息己支付
                promotionStatu = (int)dt1.Rows[0]["promotionStatu"];
                if (promotionStatu == 1)
                {
                    //此条信息己推广
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Msg", "<script>alert('您推广过这条资源');location.href='Promotionset.aspx?InfoID=" + infoid + "';</script>", false);

                }
                else
                {
                    //此条信息未推广交由test.aspx?id=id处理
                    //然后将SmsConsumeRecTab.promotionStatu的值更新为1表示己推广
                    Response.Redirect("test.aspx?id=" + id + "&recId=" + recId);
                }
            }

        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Msg", "<script>alert('暂时没有您匹配的资源')</script>", false);
        }
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
}
