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
using Tz888.Common;
using Tz888.BLL;
public partial class PublishNavigateH : System.Web.UI.Page
{
    public string selectsmallvalue;
    protected void Page_Load(object sender, EventArgs e)
    {
        AjaxPro.Utility.RegisterTypeForAjax(typeof(PublishNavigateH));
        if (!Page.IsPostBack)
        {
            BigClass();

            //if (string.IsNullOrEmpty(Page.User.Identity.Name))
            //{
            //    Response.Redirect("~/Login.aspx?ReturnUrl=" + Server.UrlEncode(Request.RawUrl));
            //}
            if (Request.QueryString["alt"] == "1")
            {
                btnSubmit.Visible = false;
                if (!string.IsNullOrEmpty(Request.QueryString["InfoID"]))
                {

                    getModel(int.Parse(Request.QueryString["InfoID"]));
                }
                else { Tz888.Common.MessageBox.Show(this.Page, "参数有误！"); }

            }
            else
            {
                Update.Visible = false; 
              
            }
        }
        btnSubmit.Attributes.Add("onclick", "return CheckForm();");
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
    protected void getModel(int id)
    {
        Tz888.BLL.Info.ReleaseInsertBLL dal = new Tz888.BLL.Info.ReleaseInsertBLL();
        Tz888.Model.BusinesProcess model = dal.getModel(id);
        this.txtTitle.Text = model.Title;
        this.txtTel.Text = model.Tel;
        this.txtLinkMan.Text = model.SubmitMan;
        this.txtFix.Text = model.Fax;
        this.txtEmail.Text = model.Email;
        this.txtContent.Text = model.Descript.ToString().Trim();
        this.txtCompany.Text = model.CompanyName;
        this.txtAddress.Text = model.Address;
        this.slServerBDrop.SelectedValue = model.ServiesBID.ToString();
        if (model.ServiesMID.ToString() != "0")
        {
            DataTable dt = GetSmallTypes(model.ServiesBID.ToString());

            if (dt != null)
            {
                this.slServerMDrop.DataSource = dt;

                this.slServerMDrop.DataTextField = "ServiesMName";
                this.slServerMDrop.DataValueField = "ServiesMID";

                this.slServerMDrop.DataBind();
                slServerMDrop.SelectedValue = model.ServiesMID.ToString();

            }
        }
       

        //this.slServerBDrop. = model.ServiesMID.ToString();
        this.ZoneSelectControl1.CountryID = model.CountryCode;
        this.ZoneSelectControl1.ProvinceID = model.ProvinceID;
        this.ZoneSelectControl1.CityID = model.CityID;
        this.ZoneSelectControl1.CountyID = model.CountyID.ToString();
    }
    private void BigClass()
    {
        Tz888.BLL.BusinesProcess bll = new Tz888.BLL.BusinesProcess();
        DataSet ds = bll.SelectBig(0);
        if (ds != null)
        {
            this.slServerBDrop.DataSource = ds;
            this.slServerBDrop.DataTextField = "ServiesBName";
            this.slServerBDrop.DataValueField = "ServiesBID";
            this.slServerBDrop.DataBind();

            this.slServerBDrop.Items.Add("请选择服务大类");
            this.slServerBDrop.Items[this.slServerBDrop.Items.Count - 1].Value = "0";
            this.slServerBDrop.SelectedIndex = this.slServerBDrop.Items.Count - 1;

            this.slServerMDrop.Items.Add("请选择服务小类");
            this.slServerMDrop.Items[this.slServerMDrop.Items.Count - 1].Value = "0";
            this.slServerMDrop.SelectedIndex = this.slServerMDrop.Items.Count - 1;
        }
    }
    /// <summary>
    /// 更改大类后的小类
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    [AjaxPro.AjaxMethod()]
    public DataTable GetSmallTypes(string BigType)
    {
        if (BigType == "" || BigType == "0")
        { return null; }
        else
        {
            DataTable dt = new DataTable();
            Tz888.BLL.BusinesProcess bll = new Tz888.BLL.BusinesProcess();
            int big = Convert.ToInt32(BigType);
            dt = bll.SelectBig(big).Tables[0];
            int i = dt.Rows.Count;
          
            return dt;
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(this.txtTitle.Text))
        {
            Tz888.Common.MessageBox.Show(this.Page, "请填写标题!");
            return;
        }
        if (string.IsNullOrEmpty(this.slServerBDrop.SelectedValue))
        {
            Tz888.Common.MessageBox.Show(this.Page, "请选择服务大类！");
            return;
        }
        //if (string.IsNullOrEmpty(this.slServerMDrop.SelectedValue))
        //{
        //    Tz888.Common.MessageBox.Show(this.Page, "请选择服务小类！");
        //    return;
        //}
        if (string.IsNullOrEmpty(this.txtContent.Text))
        {
            Tz888.Common.MessageBox.Show(this.Page, "请填写说明!");
            return;
        }
        if (string.IsNullOrEmpty(this.txtCompany.Text))
        {
            Tz888.Common.MessageBox.Show(this.Page, "请填写单位名称!");
            return;
        }
        if (string.IsNullOrEmpty(this.txtAddress.Text))
        {
            Tz888.Common.MessageBox.Show(this.Page, "请填写地址!");
            return;
        }
        if (string.IsNullOrEmpty(this.txtLinkMan.Text))
        {
            Tz888.Common.MessageBox.Show(this.Page, "请填写申请人!");
            return;
        }
        if (string.IsNullOrEmpty(this.txtTel.Text))
        {
            Tz888.Common.MessageBox.Show(this.Page, "请填写联系电话!");
            return;
        }
        if (string.IsNullOrEmpty(this.txtFix.Text))
        {
            Tz888.Common.MessageBox.Show(this.Page, "请填写传真号码!");
            return;
        }
        if (string.IsNullOrEmpty(this.txtEmail.Text))
        {
            Tz888.Common.MessageBox.Show(this.Page, "请填写电子邮件!");
            return;
        }

        string Mid = Request["ctl00$ContentPlaceHolder1$slServerMDrop"];
        selectsmallvalue = Mid;

        Tz888.BLL.Info.ReleaseInsertBLL dal = new Tz888.BLL.Info.ReleaseInsertBLL();
        Tz888.Model.Info.MainInfoModel mainInfoModel = new Tz888.Model.Info.MainInfoModel();  //创建主体信息实体
        Tz888.Model.Info.ShortInfoModel sortInfoModel = new Tz888.Model.Info.ShortInfoModel(); //创建短信息实体
        Tz888.Model.BusinesProcess model = new Tz888.Model.BusinesProcess();  //发布服务需求信息表

        //-----------------------------------发布服务需求信息-------------
        model.UserName = Page.User.Identity.Name;
        model.Title = this.txtTitle.Text;
        model.Descript =  Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(this.txtContent.Text.Trim());
        model.SubmitMan = this.txtLinkMan.Text;
        model.ServiesBID = Convert.ToInt32(this.slServerBDrop.Text);
        if (!string.IsNullOrEmpty(Mid))
        {
            model.ServiesMID = Convert.ToInt32(Mid);
        }
        else { model.ServiesMID = 0; }
        model.CountryCode = this.ZoneSelectControl1.CountryID;
        model.ProvinceID = this.ZoneSelectControl1.ProvinceID;
        model.CityID = this.ZoneSelectControl1.CityID;
        model.CountyID = this.ZoneSelectControl1.CountyID;
        model.CompanyName = this.txtCompany.Text;
        model.Address = this.txtAddress.Text;
        model.Tel = this.txtTel.Text;
        model.Fax = this.txtFix.Text;
        model.Email = this.txtEmail.Text;
        model.AuditStatus = 0;
        DateTime time_Now = DateTime.Now;
        //-----------------------------------主表信息-------------

        mainInfoModel.Title =  Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(this.txtTitle.Text);
        mainInfoModel.InfoCode = Tz888.BLL.Info.Common.CreateInfoCode("Release", this.slServerBDrop.Text, this.ZoneSelectControl1.CountryID, time_Now);
        mainInfoModel.Descript = this.txtContent.Text.Trim().ToString();
        mainInfoModel.InfoID = int.Parse(Request.QueryString["InfoID"]);




        //------------------------
        sortInfoModel.ShortTitle = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(this.txtTitle.Text);



        bool stats = dal.update(mainInfoModel, model, sortInfoModel);

        if (stats )
        {

            Response.Redirect("../PayManage/ServiesManageList.aspx");
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "更改失败！");
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //event.returnValue=false;
        //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "", "<script type=\"text/javascript\">setun()</script>", false);
        if (string.IsNullOrEmpty(this.txtTitle.Text))
        {
            Tz888.Common.MessageBox.Show(this.Page, "请填写标题!");
            return;
        }
        if (string.IsNullOrEmpty(this.txtContent.Text))
        {
            Tz888.Common.MessageBox.Show(this.Page, "请填写说明!");
            return;
        }
        if (string.IsNullOrEmpty(this.txtCompany.Text))
        {
            Tz888.Common.MessageBox.Show(this.Page, "请填写单位名称!");
            return;
        }
        if (string.IsNullOrEmpty(this.txtAddress.Text))
        {
            Tz888.Common.MessageBox.Show(this.Page, "请填写地址!");
            return;
        }
        if (string.IsNullOrEmpty(this.txtLinkMan.Text))
        {
            Tz888.Common.MessageBox.Show(this.Page, "请填写申请人!");
            return;
        }
        if (string.IsNullOrEmpty(this.txtTel.Text))
        {
            Tz888.Common.MessageBox.Show(this.Page, "请填写联系电话!");
            return;
        }
        if (string.IsNullOrEmpty(this.txtFix.Text))
        {
            Tz888.Common.MessageBox.Show(this.Page, "请填写传真号码!");
            return;
        }
        if (string.IsNullOrEmpty(this.txtEmail.Text))
        {
            Tz888.Common.MessageBox.Show(this.Page, "请填写电子邮件!");
            return;
        }

        string Mid = Request["ctl00$ContentPlaceHolder1$slServerMDrop"];
        selectsmallvalue = Mid;

        Tz888.BLL.Info.ReleaseInsertBLL dal = new Tz888.BLL.Info.ReleaseInsertBLL();
        Tz888.Model.Info.MainInfoModel mainInfoModel = new Tz888.Model.Info.MainInfoModel();  //创建主体信息实体
        Tz888.Model.Info.ShortInfoModel sortInfoModel = new Tz888.Model.Info.ShortInfoModel(); //创建短信息实体
        Tz888.Model.BusinesProcess model = new Tz888.Model.BusinesProcess();  //发布服务需求信息表
       
        //-----------------------------------发布服务需求信息-------------

        model.Title = this.txtTitle.Text;
        model.Descript = this.txtContent.Text.Trim();
        model.SubmitMan = this.txtLinkMan.Text;
       string usersName = Page.User.Identity.Name;
        model.UserName = usersName;
        model.ServiesBID = Convert.ToInt32(this.slServerBDrop.Text);
        if (!string.IsNullOrEmpty(Mid))
        {
            model.ServiesMID = Convert.ToInt32(Mid);
        }
        else {model.ServiesMID =0; };
        model.CountryCode = this.ZoneSelectControl1.CountryID;
        model.ProvinceID = this.ZoneSelectControl1.ProvinceID;
        model.CityID = this.ZoneSelectControl1.CityID;
        model.CountyID = this.ZoneSelectControl1.CountyID;
        model.CompanyName = this.txtCompany.Text;
        model.Address = this.txtAddress.Text;
        model.Tel = this.txtTel.Text;
        model.Fax = this.txtFix.Text;
        model.Email = this.txtEmail.Text;
        model.AuditStatus = 0;

        //-----------------------------------主表信息-------------
       
            mainInfoModel.Title =this.txtTitle.Text;
 DateTime time_Now = DateTime.Now;
        mainInfoModel.InfoCode = Tz888.BLL.Info.Common.CreateInfoCode("Release", this.slServerBDrop.Text, this.ZoneSelectControl1.CountryID, time_Now);
        mainInfoModel.publishT = time_Now;
        mainInfoModel.Hit = 0;

        mainInfoModel.IsCore = true;
        //mainInfoModel.LoginName = ""; //用户名称
        mainInfoModel.LoginName = Page.User.Identity.Name;
        //mainInfoModel.LoginName = usersName;
        mainInfoModel.InfoOriginRoleName = "0"; //用户角色
        mainInfoModel.GradeID = "0";
        mainInfoModel.FixPriceID = "1";
        mainInfoModel.FeeStatus = 0;

        string keyword = "";

        mainInfoModel.Descript = this.txtContent.Text.Trim();
        if (!string.IsNullOrEmpty(this.txtTitle.Text.Trim()))
            mainInfoModel.DisplayTitle = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(this.txtTitle.Text.Trim());
        mainInfoModel.FrontDisplayTime = time_Now;
        mainInfoModel.ValidateStartTime = time_Now;
        mainInfoModel.ValidateTerm = 3;
        mainInfoModel.TemplateID = "001";
        mainInfoModel.HtmlFile = "";


        //------------------------
        sortInfoModel.ShortInfoControlID = "ReleaseIndex1";
        sortInfoModel.ShortTitle = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(this.txtTitle.Text);
        sortInfoModel.ShortContent = "";
        sortInfoModel.Remark = "";


        long infoID = dal.ReleaseInsert(mainInfoModel, model, sortInfoModel);

        if (infoID > 0)
        {
            Response.Write("<script>alert('发布成功！');document.location='../PayManage/ServiesManageList.aspx'</script>");
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "发布失败！");
        }

    }
}
