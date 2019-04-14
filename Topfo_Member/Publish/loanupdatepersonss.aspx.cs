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
using Tz888.Model;

public partial class Publish_loanupdatepersonss : System.Web.UI.Page
{
    private int loansInfoID
    {
        get
        {
            return (int)ViewState["loansInfoID"];
        }
        set
        {
            ViewState["loansInfoID"] = value;
        }
    }
    private int resultrow3
    {
        get
        {
            return (int)ViewState["resultrow3"];
        }
        set
        {
            ViewState["resultrow3"] = value;
        }
    }
    private int resultrow2
    {
        get
        {
            return (int)ViewState["resultrow2"];
        }
        set
        {
            ViewState["resultrow2"] = value;
        }
    }
    private int resultrow1
    {
        get
        {
            return (int)ViewState["resultrow1"];
        }
        set
        {
            ViewState["resultrow1"] = value;
        }
    }
    Tz888.BLL.loansInfoTab loansInfoTabbll = new Tz888.BLL.loansInfoTab();
    Tz888.BLL.LoansInfo loansinfobll = new Tz888.BLL.LoansInfo();
    Tz888.BLL.loanscontactsTab loanscontacttabbll = new Tz888.BLL.loanscontactsTab();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Page.User.Identity.Name))
        {
            Response.Redirect("/login.aspx?url=" + Page.Request.Url.ToString());
        }
        if (!IsPostBack)
        {
            resultrow3 = 0;
            resultrow2 = 0;
            resultrow1 = 0;
            loansInfoID = Convert.ToInt32(Request.QueryString["str"].ToString());
            BindShow();
        }
    }

    private void BindShow()
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




        Tz888.Model.LoansInfoTab loansInfotab = (Tz888.Model.LoansInfoTab)loansInfoTabbll.GetLoansInfoTabByLoansInfoId(loansInfoID);
        Tz888.Model.LoansInfo loansinfo = (Tz888.Model.LoansInfo)loansinfobll.GetLoansInfoByLoansInfoId(loansInfoID);
        Tz888.Model.LoanscontactsTab loanscontactstab = (Tz888.Model.LoanscontactsTab)loanscontacttabbll.GetLoanscontactsTabByLoansInfoId(loansInfoID);

        txtCapitalTitle.Text = loansInfotab.LoansTitle.ToString();
        txtCapitalMoney.Text = loansinfo.Amount.ToString();
        radiohaiMoney.Items.FindByValue(loansinfo.Reimbursement.ToString().Trim()).Selected = true;
        radiodanbao.Items.FindByValue(loansinfo.Guarantee.ToString().Trim()).Selected = true;
        txtCapitalIntent.Value = loansinfo.BorrowingUse.ToString();
        txtcontactsName.Text = loanscontactstab.ContactsName.ToString();
        txtcontactsphone.Text = loanscontactstab.Moblie.ToString();

            string[] num = loanscontactstab.Telephone.ToString().Trim().Split('-');
            if (num.Length==1)
            {
                txttel1.Text = num[0];
            }
            else if (num.Length == 2)
            {
                txttel1.Text = num[0];
            }
            else if(num .Length ==3)
            {
                txtcontactsTel.Text = num[0];
                txttel1.Text = num[1];
                txttel2.Text = num[2];
            }
            

        
       
        txtcontactsemail.Text = loanscontactstab.Mail.ToString();
        txtcontactsaddress.Text = loanscontactstab.Address.ToString();
        this.ZoneSelectControl1.CountryID = loansinfo.CountryID.ToString().Trim();
        this.ZoneSelectControl1.ProvinceID = loansinfo.ProvinceID.ToString().Trim();
        this.ZoneSelectControl1.CityID = loansinfo.CityID.ToString().Trim();
        this.ZoneSelectControl1.CountyID = loansinfo.CountyID.ToString().Trim();
        this.rdlValiditeTerm.Items.FindByValue(loansinfo.Deadline.ToString().Trim()).Selected = true;
        this.rdlValiditeSystem.Items.FindByValue(loansinfo.ValidityID.ToString().Trim()).Selected = true;


    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Tz888.Model.LoansInfoTab loansInfotab = new LoansInfoTab();
        Tz888.Model.LoansInfo loansinfo = new LoansInfo();
        Tz888.Model.LoanscontactsTab loanscontactstab = new LoanscontactsTab();
        //贷款主表的修改

        loansInfotab.LoansInfoID = loansInfoID;
        loansInfotab.LoansTitle = txtCapitalTitle.Text.Trim();
        loansInfotab.Updatetime = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString().Trim();
        if (txtCapitalTitle.Text.Trim() == "")
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('请输入标题！');", true);
            return;
        }
        else
        {
             resultrow1 = loansInfoTabbll.UpdateLoansInfoTab(loansInfotab);
        }
        //贷款详细表的修改

        if (txtCapitalMoney.Text.Trim() == "")
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('请输入借款金额！');", true);
            return;
        }
        else if (Convert.ToInt32(txtCapitalMoney.Text.Trim().Length) > 9)
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('请输入小于10亿的金额！');", true);
            return;
        }
        else if (txtCapitalIntent.Value .Trim() == "")
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('请输入借款内容！');", true);
            return;
        }
        else
        {
            loansinfo.CountryID = this.ZoneSelectControl1.CountryID;
            loansinfo.ProvinceID = this.ZoneSelectControl1.ProvinceID;
            loansinfo.CityID = this.ZoneSelectControl1.CityID;
            loansinfo.CountyID = this.ZoneSelectControl1.CountyID;
            loansinfo.Amount = Convert.ToInt32(txtCapitalMoney.Text.Trim());
            loansinfo.Deadline = Convert.ToInt32(rdlValiditeTerm.SelectedValue.Trim());
            loansinfo.Reimbursement = Convert.ToInt32(this.radiohaiMoney.SelectedValue.Trim());
            loansinfo.Guarantee = Convert.ToInt32(this.radiodanbao.SelectedValue.Trim());
            loansinfo.BorrowingUse = txtCapitalIntent.Value.Trim();
            loansinfo.ValidityID = Convert.ToInt32(rdlValiditeSystem.SelectedValue.Trim());
             resultrow2 = loansinfobll.UpdateLoansInfoTab(loansinfo, loansInfoID);
        }
        //联系方式
        loanscontactstab.EnterpriseName = "";
        loanscontactstab.ContactsName = txtcontactsName.Text.Trim();
        loanscontactstab.Telephone = txtcontactsTel.Text.Trim() + "-" + txttel1.Text.Trim() + "-" + txttel2.Text.Trim();
        loanscontactstab.Moblie = txtcontactsphone.Text.Trim();
        loanscontactstab.Mail = txtcontactsemail.Text.Trim();
        loanscontactstab.Address = this.txtcontactsaddress.Text.Trim();
        if (txtcontactsName.Text.Trim() == "")
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('请输入姓名！');", true);
            return;
        }
        else if (txtcontactsTel.Text.Trim() == "" && txtcontactsphone.Text .Trim ()=="")
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
            ScriptManager.RegisterStartupScript(this, this.GetType(), "提示f：", "sss();", true);
             resultrow3 = loanscontacttabbll.UpdateloanscontactsTab(loanscontactstab, loansInfoID);
        }
        if (resultrow1 > 0 && resultrow2 > 0 && resultrow3 > 0)
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "location.href='LoansManager.aspx'", true);
        }
        else 
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('修改失败！');", true);
        }

    }
}
