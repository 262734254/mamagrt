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
using Tz888.BLL.Register;
using Tz888.Model.Register;

public partial class Register_TTMemberRegister : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.ViewState["tag"] = "add";//默认为添加


        try
        {
            if (Request.QueryString["ApplyID"].ToString() != "" && Request.QueryString["ApplyID"] != null)
            {
                int ApplyID = Convert.ToInt32(Request.QueryString["ApplyID"]);
                this.ViewState["tag"] = "change"; //修改
                this.ViewState["ApplyID"] = ApplyID; //修改的ID号


                getMessage(ApplyID); //加载信息

            }
        }
        catch
        { }
    }

    protected void ibOK_Click(object sender, ImageClickEventArgs e)
    {
        Tz888.Model.Register.VIPMemberRegister modelInfo = new Tz888.Model.Register.VIPMemberRegister();
        Tz888.BLL.Register.VIPMemberRegister obj = new Tz888.BLL.Register.VIPMemberRegister();
        modelInfo.ApplyID = 0;
        modelInfo.LoginName = "";
        modelInfo.ManageTypeID = hidManageType.Value!="" ?hidManageType.Value:"1003" ;
        modelInfo.BuyTerm = Convert.ToInt16(rblBuyTerm.SelectedValue);
        modelInfo.OrgName = tbOrgName.Text;
        modelInfo.RealName = tbRealName.Text;
        modelInfo.Position = tbPosition.Text;//职务
        modelInfo.Sex = Convert.ToBoolean(rblSex.SelectedValue);
        modelInfo.TelCountryCode = txtTelCountry.Text;
        modelInfo.TelStateCode = txtTelZoneCode.Text;
        modelInfo.TelNum = txtTelNumber.Text;
        modelInfo.Mobile = txtMobile.Text;
        modelInfo.Email = txtEmail.Text;
        modelInfo.ApplyDate = DateTime.Now;
        modelInfo.IsPay = 0;//是否付费
        modelInfo.OprStatus = 0;// 审核状态：0未审核、1审核为拓富通会员、2已审核(已审基本信息)、3审核不通过、4退款、 
        modelInfo.OprDescript = "";
        modelInfo.OprMan = "";
        modelInfo.OprDate = DateTime.Now;
        modelInfo.Memo = "";
        modelInfo.MarketPersonName = "";
        modelInfo.VIPValidateDate = DateTime.Now;//生效时间
        modelInfo.Money = 0;
        modelInfo.Years = Convert.ToInt16(rblBuyTerm.SelectedValue);
        modelInfo.Price = 0;
        modelInfo.ServiceType = "2001";

        if (modelInfo.OrgName == "" && this.hidManageType.Value != "1001")
        {
            Tz888.Common.MessageBox.Show(this.Page, "公司名称不能为空");
            return;
        }
        if (modelInfo.RealName == "")
        {
            Tz888.Common.MessageBox.Show(this.Page, "真实姓名不能为空");
            return;
        }
        if (modelInfo.Email == "")
        {
            Tz888.Common.MessageBox.Show(this.Page, "'Email不能为空");
            return;
        }


        if (this.ViewState["tag"].ToString() == "add")
        {
            this.ViewState["ApplyID"] = obj.AddVIPMember(modelInfo);
        }
        else if (this.ViewState["tag"].ToString() == "update")
        {
            bool bl = obj.UpdateVIPMember(modelInfo);
        }
        if (Convert.ToInt32(this.ViewState["ApplyID"]) > 0)
        {
            Response.Redirect("VIPRegisterSubmit.aspx?ApplyID=" + this.ViewState["ApplyID"]);
        }
    }

    public void getMessage(int ApplyID)
    {
        Tz888.BLL.Register.VIPMemberRegister obj = new Tz888.BLL.Register.VIPMemberRegister();
        Tz888.Model.Register.VIPMemberRegister model = new Tz888.Model.Register.VIPMemberRegister();
        model = obj.GetVIPMemberModel(ApplyID);
        hidManageType.Value = model.ManageTypeID.ToString();
        if (model.ManageTypeID.Trim() == "2003") radioManageType1.Checked = true;
        if (model.ManageTypeID.Trim() == "2001") radioManageType3.Checked = true;

        rblBuyTerm.SelectedValue = model.BuyTerm.ToString();
        tbOrgName.Text = model.OrgName;
        tbRealName.Text = model.RealName;
        tbPosition.Text = model.Position;
        rblSex.SelectedValue = model.Sex.ToString();
        txtTelCountry.Text = model.TelCountryCode;
        txtTelZoneCode.Text = model.TelStateCode;
        txtTelNumber.Text = model.TelNum;
        txtMobile.Text = model.Mobile;
        txtEmail.Text = model.Email;
    }
}
