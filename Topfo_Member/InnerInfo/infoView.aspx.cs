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

public partial class InnerInfo_infoView : System.Web.UI.Page
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
        if (Page.User.Identity.Name == null || Page.User.Identity.Name.Trim() == "")
        {
            Response.Redirect("../Login.aspx");
        }
        //page指令中设置了不安全验证
        Tz888.Model.InnerInfo model= new Tz888.Model.InnerInfo();
        Tz888.BLL.InnerInfo infoBLL = new Tz888.BLL.InnerInfo();
        if (Request.QueryString["ReceivedId"] != null && Request.QueryString["ReceivedId"] != "")
        {
            model = infoBLL.GetInfoContext(Convert.ToInt32(Request.QueryString["ReceivedId"]), 0);
        }
        this.HlpTopic.Text = model.Topic;
        this.InfoTime.Text = model.InfoTime.ToString();
        this.HplSendman.Text = model.SendName;
        this.TBoxInfoText.Text = model.Context;
        infoBLL.ReadInfoSet(Convert.ToInt32(Request.QueryString["ReceivedId"]));
        if (Request.QueryString["Ac"] != null && Request.QueryString["Ac"] != "")
        {
            if (Convert.ToInt32(Request.QueryString["Ac"].Trim()) == 1)
            {
                SetResponse();
            }
        }
        if (model.SendName.Trim() == "拓富网" || model.SendName.Trim().ToLower() == "tz888admin")
        {
            //this.BtnStartResponse.Visible = false;
            this.BtnInfoResponse.Visible = false;
            this.plreply.Visible = false;
            this.HplSendman.Text = "拓富网";
        }
    }
    protected void BtnReset_Click(object sender, EventArgs e)
    {
        //可以通过JS实现
        this.TboxReceiveName.Text = "";
        this.TBoxResponseText.Text = "";
        this.TBoxResponseTopic.Text = "";
    }
    protected void BtnReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("inbox2.aspx?");
    }
    protected void BtnInfoResponse_Click(object sender, EventArgs e)
    {
        bool result = false;
        Tz888.BLL.InnerInfo infoBLL = new Tz888.BLL.InnerInfo();
        Tz888.Model.InnerInfo infoModel = new Tz888.Model.InnerInfo();
        //设置Model字段成员
        infoModel.Topic = this.TBoxResponseTopic.Text;
        infoModel.Context = this.TBoxResponseText.Text;
        infoModel.ReceiveName = this.TboxReceiveName.Text;

        infoModel.SendName = Page.User.Identity.Name;
        infoModel.ChangeBy = Page.User.Identity.Name; 
        //infoModel.SendName = "sunray";
        //infoModel.ChangeBy = "sunray";
        infoModel.SendId = 0;
        result = infoBLL.SendInfoBLL(infoModel, this.CheckBoxSaveOther.Checked);
        Response.Redirect("inbox2.aspx?");
    }
    private void SetResponse()
    {
        if (this.HplSendman.Text != null && this.HplSendman.Text != "")
        {
            this.TboxReceiveName.Text = this.HplSendman.Text;
        }
        if ((this.HlpTopic.Text != null) && (this.HlpTopic.Text != ""))
        {
            this.TBoxResponseTopic.Text = "Re:" + this.HlpTopic.Text;
        }
        if ((this.TBoxInfoText.Text != null) && (this.TBoxInfoText.Text != ""))
        {
            this.TBoxResponseText.Text = "\n\n-------------------\n标题:" + this.HlpTopic.Text + "  " + this.InfoTime.Text
                                          + "\n发件人:" + this.HplSendman.Text + "\n" + this.TBoxInfoText.Text;
            this.TBoxResponseText.Focus();
        }
        //发送信息实现
    }

}