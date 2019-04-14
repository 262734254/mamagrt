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

public partial class Publish_LoansInfoEnterprise : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Page.User.Identity.Name))
        {
            Response.Redirect("/login.aspx?url=" + Page.Request.Url.ToString());
        }
        if (!IsPostBack)
        {
            BindSetvaliDate();
        }
    }
    //绑定还款期限
    private void BindSetvaliDate()
    {
        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        DataTable dt = dal.GetList("dicttab", "*", "idictvalue", 10, 1, 0, 0, " cdicttype='xmyxqxx' ");
        this.rdlValiditeTerm.DataTextField = "cdictname";
        this.rdlValiditeTerm.DataValueField = "idictvalue";
        this.rdlValiditeTerm.DataSource = dt;
        this.rdlValiditeTerm.SelectedIndex = 0;
        this.rdlValiditeTerm.DataBind();
        this.rdlValiditeSystem.DataTextField = "cdictname";
        this.rdlValiditeSystem.DataValueField = "idictvalue";
        this.rdlValiditeSystem.DataSource = dt;
        this.rdlValiditeSystem.SelectedIndex = 0;
        this.rdlValiditeSystem.DataBind();


    }
    protected void IbtnSubmit_Click(object sender, ImageClickEventArgs e)
    {
        string loginname = Page.User.Identity.Name.Trim();
        Tz888.BLL.loansInfoTab loansinfotabbll = new Tz888.BLL.loansInfoTab();
        //贷款主表添加数据
        Tz888.Model.LoansInfoTab loansinfotab = new Tz888.Model.LoansInfoTab();
        loansinfotab.LoginName = loginname;
        loansinfotab.LoansTitle = this.txtCapitalTitle.Text.Trim();
        loansinfotab.BorrowingType = 1;
        loansinfotab.AuditID = 0;
        loansinfotab.ChargeID = 0;
        loansinfotab.RecommendID = 0;
        loansinfotab.Url = "";
        loansinfotab.Price = 0;//价格
        loansinfotab.Formid = 1;//1:会员2：业务员3：协会 4：分站
        loansinfotab.Refurbishtime = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString().Trim();//刷新时间
        if (txtCapitalTitle.Text.Trim() == "")
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('请输入标题！');", true);
            return;
        }
        //贷款表添加数据
        loansinfotab.Loansdate = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString().Trim();
        Tz888.Model.LoansInfo loansinfo = new Tz888.Model.LoansInfo();
        loansinfo.CountryID = this.ZoneSelectControl1.CountryID;
        loansinfo.ProvinceID = this.ZoneSelectControl1.ProvinceID;
        loansinfo.CityID = this.ZoneSelectControl1.CityID;
        loansinfo.CountyID = this.ZoneSelectControl1.CountyID;
        if (txtCapitalMoney.Text.Trim() == "")
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('请输入贷款金额！');", true);
            return;
        }
        else if (Convert.ToInt32(txtCapitalMoney.Text.Trim().Length) > 9)
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('请输入小于10亿的金额！');", true);
            return;
        }
        else if (txtCapitalIntent.Value.Trim() == "")
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('请输入贷款原因！');", true);
            return;
        }
        loansinfo.Deadline = Convert.ToInt32(rdlValiditeTerm.SelectedValue.Trim());
        loansinfo.Guarantee = Convert.ToInt32(this.radiodanbao.SelectedValue.Trim());
        loansinfo.BorrowingUse = txtCapitalIntent.Value.Trim();
        loansinfo.ValidityID = Convert.ToInt32(rdlValiditeSystem.SelectedValue.Trim());
        loansinfo.Amount = Convert.ToInt32(txtCapitalMoney.Text.Trim());
        loansinfo.Title = "";
        loansinfo.Keywords = "";
        loansinfo.Description = "";
        loansinfo.Reason = "";
        //联系人信息表添加数据
        Tz888.Model.LoanscontactsTab loanscontactstab = new Tz888.Model.LoanscontactsTab();
        loanscontactstab.EnterpriseName = txtentriname.Text.Trim();
        loanscontactstab.ContactsName = txtcontactsName.Text.Trim();
        loanscontactstab.Telephone = txtcontactsTel.Text.Trim() + "-" + txttel1.Text.Trim() + "-" + txttel2.Text.Trim();
        loanscontactstab.Moblie = txtcontactsphone.Text.Trim();
        loanscontactstab.Mail = txtcontactsemail.Text.Trim();
        loanscontactstab.Address = this.txtcontactsaddress.Text.Trim();
        if (txtentriname.Text.Trim() == "")
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('请输入公司名称！');", true);
            return;
        }
        else if (txtcontactsName.Text.Trim() == "")
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('请输入联系人！');", true);
            return;
        }
        else if (txtcontactsTel.Text.Trim() == "" && txtcontactsphone.Text.Trim() == "")
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('至少输入一个联系电话！');", true);
            return;
        }
        else if (txttel1.Text.Trim() == "" && txtcontactsphone.Text.Trim() == "")
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('至少输入一个联系电话！');", true);
            return;
        }
        else if (txttel2.Text.Trim() == "" && txtcontactsphone.Text.Trim() == "")
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('至少输入一个联系电话！');", true);
            return;
        }
        else if (txtcontactsemail.Text.Trim() == "")
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('请输入邮箱！');", true);
            return;
        }
        else
        {
            int result = loansinfotabbll.InsertLoansInfoTab(loansinfotab, loansinfo, loanscontactstab);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "提示f：", "ss();", true);
            if (result > 0)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "location.href='LoansManager.aspx'", true);
            }
        }
    }
}
