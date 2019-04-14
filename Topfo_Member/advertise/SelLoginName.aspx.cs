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

public partial class advertise_SelLoginName : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (string.IsNullOrEmpty(Page.User.Identity.Name))
            {
                Response.Redirect("/Login.aspx?ReturnUrl=" + Server.UrlEncode(Request.RawUrl));
            }
            string Lg = Request["Login"].ToString().Trim();
            int advl = Convert.ToInt32(Request["adv"]);

            divId.Value = Convert.ToString(advl);
            ViewState["adv"] = advl;
            if (Lg == "游客" || Lg == "匿名")
            {
                PaNum.Visible = false;
                PanTishi.Visible = true;
            }
            else
            {
                PaNum.Visible = true;
                PanTishi.Visible = false;
                Login(Lg);
            }
        }
    }

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
    private void Login(string name)
    {
        Tz888.BLL.Register.common bll = new Tz888.BLL.Register.common();
        //Tz888.Model.Register.OrgContactModel model = new Tz888.Model.Register.OrgContactModel();
        Tz888.Model.Register.MemberInfoModel model = new Tz888.Model.Register.MemberInfoModel();
        model = bll.SelorgContact(name);
        // model = bll.getContactModel(name);
        // this.lblCompanyName.Text = model.OrganizationName.Trim();
        this.lblEmial.Text = model.Email.ToString();
        //  this.lblLinkMan.Text = model.Name.ToString();
        this.lblMobile.Text = model.Mobile.ToString();
        this.lblPhone.Text = model.Tel.ToString();// model.TelStateCode.ToString() + "-" + model.TelNum.ToString();
        this.lblAddress.Text = model.Address.ToString();
        SpanCard.InnerHtml = "<a href='http://card.topfo.com/" + name + "/' class='lan1' target='_blank'>http://card.topfo.com/"+name+"/</a>";
    }
    protected void Lbtadv_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdvisitInfo.aspx?adv=" + ViewState["adv"].ToString() + "");
    }

}
