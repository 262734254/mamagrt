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
public partial class helper_ModifyMaching : System.Web.UI.Page
{
    protected DataTable dt;
    protected int ID;
    protected string tag;
    protected void Page_PreInit(object sender, EventArgs e)
    {
        bool isTof = Page.User.IsInRole("GT1002");

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
        //if (Page.User.Identity.Name.Trim() == null || Page.User.Identity.Name.Trim().Trim() == "")
        //{
        //    Response.Redirect("../Login.aspx?ReturnUrl=" + Server.UrlEncode(Request.RawUrl));

        //}
        
        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        HtmlInputCheckBox check = new HtmlInputCheckBox();
        DataTable dt = dal.GetList("UserParametersTab", "*", "parID", 1, 1, 0, 1, "LoginName='" + Page.User.Identity.Name.Trim() + "'");
        //lblNoticeCount.Text = dt.Rows[0]["MobileCount"].ToString();

        this.ViewState["MemberLoginName"] = Page.User.Identity.Name.Trim();
        try
        {
            txtTitle.Text = Session["title"].ToString();  //默认标题   
            tag = Request.QueryString["tag"].ToString();
            ID = Convert.ToInt32(Request.QueryString["id"]);
        }
        catch
        {
            tag = "Add";

        }
        
        setNotice();
        try
        {
            DataSet ds = new DataSet();
            ds = (DataSet)Session["CustomInfo"];
            dt = ds.Tables[0];
            if (!Page.IsPostBack)
            {
                ControlBind(dt);
            }
        }
        catch
        {

        }

        #region 查看用户己订阅的条数
        //string Criteria = "LoginName = '" + Page.User.Identity.Name.Trim() + "'";
        //Tz888.SQLServerDAL.Conn obj = new Tz888.SQLServerDAL.Conn();
        //DataTable dt1 = obj.GetList("CustomInfoTab", "*", "LoginName", 100, 1, 0, 1, Criteria);
        //if (Page.User.IsInRole("GT1001") && dt1.Rows.Count >= 5)
        //{
        //    btnCustom.Enabled = false;
        //    labMessage.Visible = true;
        //    divMessage.InnerHtml = " 感谢您订阅该搜索！符合定制条件的资源和资讯将通过电子邮件、站内短信以及手机短信传送给您。"+
        //       " <br />  <span class='font14 cheng'>抢占先机，时刻把握最新对口需求！ </span>"+
        //        "<br />  <span class='font14 cheng'>追踪信息，时刻把握业界最新脉搏！</span>";
        //}

        if (Page.User.IsInRole("GT1001"))
        {
            Tz888.Common.MessageBox.ShowAndRedirect(this.Page, "对不起，普通会员不能进行此项服务！", "http://member.topfo.com/helper/MatchingInfo.aspx");
            return;
        }
        else
        {
            //divMessage.InnerHtml = "如果您无暇上网，又担心错过了好机会，请立即进行订阅设置。<br/>第一时间抢占先机，万千财富滚滚来！<br/>您是拓富通会员，享有无限数量的免费订阅权限!";
            //labMessage.Visible = false;
        }
        #endregion
    }

    #region 己存在的通知设置
    public void setNotice()
    {
        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        HtmlInputCheckBox check = new HtmlInputCheckBox();
        //DataTable dt = dal.GetList("UserParametersTab", "*", "parID", 1, 1, 0, 1, "LoginName='" + Page.User.Identity.Name.Trim() + "'");
        DataTable dt = dal.GetList("UserParametersTab", "*", "parID", 1, 1, 0, 1, "LoginName='test'");
        if (dt.Rows.Count > 0)
        {
            string dzchk = dt.Rows[0]["SubscribeNotice"].ToString();//定制通知

            string strNotice = "";
            if (dzchk != "")
            {
                this.ViewState["Mobile"] = 0;
                string[] Notice = dzchk.Split('|');

                for (int i = 0; i < Notice.Length; i++)
                {
                    try
                    {
                        switch (Convert.ToInt32(Notice[i]))
                        {
                            case 1:
                                strNotice += "站内短信、";
                                break;
                            case 2:
                                strNotice += "电子邮件、";
                                break;
                            case 3:
                                strNotice += "手机短信、";
                                this.ViewState["Mobile"] = 1;
                                break;
                            default:
                                strNotice += "";
                                break;
                        }
                    }
                    catch { }
                }
                if (strNotice != "")
                {
                    strNotice = "您已选择使用" + strNotice + "的定阅通知";
                    //lbNotice.Text = strNotice + "<br> 请点击此处<a  href='javascript:ShowMessageWin()'><font color='#0000FF'>修改通知接收方式</font></a>";
                }
                else
                {
                    //lbNotice.Text = "您还没有进行定阅通知设置操作" + "<br> 请点击此处<a href='javascript:ShowMessageWin()'><font color='#0000FF'>添加通知接收方式</font></a>"; ;
                }
            }
            else
            {
                //lbNotice.Text = "您还没有进行定阅通知设置操作" + "<br> 请点击此处<a href='javascript:ShowMessageWin()'><font color='#0000FF'>添加通知接收方式</font></a>"; ;
            }

            if (!Page.User.IsInRole("GT1001") && Convert.ToInt32(this.ViewState["Mobile"]) == 1)
            {
                int count = Convert.ToInt32(dt.Rows[0]["MobileCount"]);
                if (count > 0) lbMobile.Text = "<font color='red'> 温馨提示：</font>您现在还可以接收" + count + "条手机短信。<a href='http://member.topfo.com/helper/buysms.aspx' target='_blank'><font color='red'>申请更多手机短信通知</font></a>";
                else lbMobile.Text = " <font color='red'>温馨提示：</font>您的免费短信条数为0条，请您尽快<a href='http://member.topfo.com/helper/buysms.aspx' target='_blank'><font color='#0000FF'>购买短信</font></a>条数，以免贻误商机！";
            }
        }
        else
        {
            //lbNotice.Text = "您还没有进行定阅通知设置操作" + "<br> 请点击此处<a href='javascript:ShowMessageWin()'><font color='#0000FF'>添加通知接收方式</font></a>"; ;
        }

    }
    #endregion

    public void btnCustom_Click(object sender, System.EventArgs e)
    {
        Tz888.Model.CustomInfoModel CustomInfo = (Tz888.Model.CustomInfoModel)Session["customInfo"];
        Tz888.BLL.CustomInfoBLL CustomObj = new Tz888.BLL.CustomInfoBLL();

        //CustomInfo.LoginName = "";//Page.User.Identity.Name.Trim();

        CustomInfo.Accept = true;
        //CustomInfo.CustomCyc = Convert.ToInt32(strCustomCyc);

        //CustomInfo.CustomType = Convert.ToInt32(strCustomType);


        CustomInfo.Title = this.txtTitle.Text;
        CustomInfo.ValidateTerm = Convert.ToInt32(this.rblValidateTerm.SelectedValue.ToString().Trim());
        CustomInfo.ItemCount = Convert.ToInt32(this.ddlItemCount.SelectedValue.ToString().Trim());



        if (tag == "Add")
        {
            int i = CustomObj.Add(CustomInfo);
            Tz888.Common.MessageBox.Show(this.Page, CustomInfo.LoginName.ToString());
            this.Page.Response.Redirect("MatchingInfo.aspx");
            //   Tz888.Common.MessageBox.Show(this.Page, i.ToString());
            return;
        }
        if (tag == "Update")
        {
            CustomObj.Update(CustomInfo);
            this.Page.Response.Redirect("MatchingInfo.aspx");
            // Tz888.Common.MessageBox.Show(this.Page, "修改定阅成功。");
        }
    }

    #region 信息绑定
    private void ControlBind(DataTable dt)
    {
        this.txtTitle.Text = dt.Rows[0]["Title"].ToString();

        //for (int i = 0; i < 2; i++)
        //{
        //    if (dt.Rows[0]["ValidateTerm"].ToString() == rblValidateTerm.Items[i].Value)
        //    {
        //        this.rblValidateTerm.Items[i].Selected = true;
        //    }
        //}

        for (int i = 0; i < 3; i++)
        {
            if (dt.Rows[0]["ItemCount"].ToString() == ddlItemCount.Items[i].Value)
            {
                this.ddlItemCount.Items[i].Selected = true;
            }
        }

        //	this.txtMail.Text=dt.Rows[0]["Email"].ToString();

        //if(dt.Rows[0]["Accept"].ToString()=="1")
        //{
        //    this.rblYesNOMaill.Items[0].Selected=true;
        //}
        //else
        //{
        //    this.rblYesNOMaill.Items[1].Selected=true;
        //}

    }
    #endregion
}
