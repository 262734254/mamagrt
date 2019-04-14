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

public partial class helper_TestModifyMaching : System.Web.UI.Page
{
    protected DataTable dt;
    protected int ID = 0;
    protected string tag = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        HtmlInputCheckBox check = new HtmlInputCheckBox();
        DataTable dt = dal.GetList("UserParametersTab", "*", "parID", 1, 1, 0, 1, "LoginName='topfo001'");

        this.ViewState["MemberLoginName"] = "topfo001";
        //try
        //{
        txtTitle.Text = Session["title"].ToString();  //默认标题   
        if (Convert.ToString(Request["tag"]) == null)
        {
            tag = "Add";
        }
        else
        {
            tag = Request["tag"].ToString();
        }
        // tag =Convert.ToString(Request.QueryString["tag"].ToString()) == "" ? "Add" : Request.QueryString["tag"].ToString();
        ID = Convert.ToInt32(Request.QueryString["id"]);
        //}
        //catch
        //{
        //    tag = "Add";

        //}

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
        //CustomInfo.ValidateTerm = Convert.ToInt32(this.rblValidateTerm.SelectedValue.ToString().Trim());
        //CustomInfo.ItemCount = Convert.ToInt32(this.ddlItemCount.SelectedValue.ToString().Trim());

        string name = CustomInfo.CooperationDemandTypeID;

        if (tag == "Add")
        {
            int i = CustomObj.Add(CustomInfo);
            Tz888.Common.MessageBox.Show(this.Page, CustomInfo.LoginName.ToString());
            this.Page.Response.Redirect("TestMatchingInfo.aspx");
            //   Tz888.Common.MessageBox.Show(this.Page, i.ToString());
            return;
        }
        if (tag == "Update")
        {
            CustomObj.Update(CustomInfo);
            this.Page.Response.Redirect("TestMatchingInfo.aspx");
            // Tz888.Common.MessageBox.Show(this.Page, "修改定阅成功。");
        }
    }

    #region 信息绑定
    private void ControlBind(DataTable dt)
    {
        this.txtTitle.Text = dt.Rows[0]["Title"].ToString();

    }
    #endregion
}

