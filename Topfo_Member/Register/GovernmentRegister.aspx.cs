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
using Tz888.Model.Register;
using Tz888.BLL.Register;
using System.Collections.Generic;
                              
public partial class Register_GovernmentRegister : System.Web.UI.Page
{
    public Tz888.BLL.Register.GovernmentRegisterBLL obj;
    public Tz888.Model.Register.GovernmentInfoModel mode;
    public Tz888.BLL.Register.MemberInfoBLL obj2;
    public Tz888.Model.LoginInfo model2;
    public int GovernmentId;
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
            Response.Redirect("../Login.aspx?ReturnUrl=" + Server.UrlEncode(Request.RawUrl));
            return;
        }
        if (Page.User.IsInRole("MT1003"))
            Response.Redirect("EnterpriseRegisterResult.aspx");

        if (Page.User.IsInRole("MT1001"))
        {
            Tz888.Common.MessageBox.Show(this.Page, "对不起，您是个人会员，不能进行机构登记！");
            return;
        }

        //buSend.Attributes.Add("onclick", "return chkPost();");

        if (Page.User.IsInRole("GT1001"))
        {
            ImageUploadControl1.Count = 5;
            ImageUploadControl1.NoneCount = 3;
        }
        else
        {
            ImageUploadControl1.Count = 5;
            ImageUploadControl1.NoneCount = 5;
        }

        this.ImageUploadControl1.InfoType = "GovernmentRegister";
        this.ImageUploadControl1.IsTopfoUser = (Page.User.IsInRole("GT1002"));

        if (!Page.IsPostBack)
        {
            //展厅

            System.Collections.Generic.IList<SelfCreateWeb.Model.MSelfCreateWebInfo> finduser = new SelfCreateWeb.BLL.BSelfCreateWebInfo().GetSelfCreateWebInfo(1, 100, new string[] { "LoginName" }, new string[] { Page.User.Identity.Name});
            if (finduser.Count > 0)
            {
                string url = finduser[0].Domain.Trim();
                tbExhibitionHall.Text = url;
                tbExhibitionHall.Enabled = false;
                finduser.Clear();
                this.ViewState["WebInfo"] = 0;
            }
            else
            {
                tbExhibitionHall.Text = "";
                tbExhibitionHall.Enabled = true;
                this.ViewState["WebInfo"] = 1;
            }

            this.ViewState["MemberLoginName"] = Page.User.Identity.Name;
            //页面信息加载
            List<Tz888.Model.Register.OrgContactMan> contactMans = new List<Tz888.Model.Register.OrgContactMan>();//联系人实体列表 
            Tz888.Model.Register.OrgContactModel orgContact = new Tz888.Model.Register.OrgContactModel(); //创建信息联系方式主体
            List<Tz888.Model.MemberResourceModel> infoResource = new List<Tz888.Model.MemberResourceModel>();//图片资料

            Tz888.BLL.Register.common com = new common();

            try
            {
                contactMans = com.GetOrgContactMan(Page.User.Identity.Name);
                orgContact = com.getContactModel(Page.User.Identity.Name);
            
            ///0 公司介绍（多图片）


            ///1营业执照
            ///2税务登记证(国税)
            ///3税务登记证(地税)
            ///4荣誉和证书


            ///5其它*/ 
            infoResource = com.GetMemberResourceModel(this.ViewState["MemberLoginName"].ToString(), 0);
                }
            catch { }
             
            OrgContactControl1.OrgContact = orgContact;//联系信息
            OrgContactControl1.ContactMans = contactMans;//联系人


            ImageUploadControl1.InfoList = infoResource;
            //机构主体
            obj = new GovernmentRegisterBLL();
            ddlSubjectType.DataSource = obj.getMerchantTypeTab();
            ddlSubjectType.DataTextField = "MerchantTypeName";
            ddlSubjectType.DataValueField = "MerchantTypeID";
            ddlSubjectType.DataBind();

            //文件上传
            string GM = "1001";
            switch (GM)
            {
                case "1001":
                    fileDiv.Style.Add("display", "none");
                    break;
                case "1002":
                    fileDiv.Style.Add("display", "none");
                    break;
            }

            //判断操作性质：添加，修改
            Tz888.BLL.Register.GovernmentRegisterBLL obj2 = new GovernmentRegisterBLL();
            DataTable dt = obj2.getGovernmentModel(Page.User.Identity.Name);
            this.ViewState["Domain"] = "Add";
            this.ViewState["GovermentID"] = 0;

            if (dt != null && dt.Rows.Count > 0)//修改
            {
                ViewState["GovermentID"] = Convert.ToInt32(dt.Rows[0]["GovernmentID"]);
                //基本信息               
                tbGovernmentName.Text = dt.Rows[0]["GovernmentName"].ToString();
                ddlSubjectType.SelectedValue = dt.Rows[0]["SubjectType"].ToString();

                //网上展厅(按LoginName读取展厅地址)
                if (dt.Rows[0]["ExhibitionHall"].ToString() != "")
                {
                   // tbExhibitionHall.Text = dt.Rows[0]["ExhibitionHall"].ToString();
                  //  tbExhibitionHall.Enabled = false;
                    Hidden1.Value = "不可修改";
                    this.ViewState["Domain"] = "不可修改";
                }
                else
                {
                   // tbExhibitionHall.Enabled = true;
                }
                // 地区
                ZoneSelectControl1.CountryID = dt.Rows[0]["CountryCode"].ToString().Trim();
                ZoneSelectControl1.ProvinceID = dt.Rows[0]["ProvinceID"].ToString().Trim();
                ZoneSelectControl1.CityID = dt.Rows[0]["CityID"].ToString().Trim();
                ZoneSelectControl1.CountyID = dt.Rows[0]["CountyID"].ToString().Trim();

                tbGovAbout.Text = Tz888.Common.Utility.PageValidate.HtmlToTxt( dt.Rows[0]["GovAbout"].ToString());

                //上传文件（暂未开发）

            }//添加
            else
            {
                //Tz888.BLL.Conn obCon = new Tz888.BLL.Conn();
                //DataTable dtContact = obCon.GetList("OrgContactTab", "*", "LoginName", 1, 1, 0, 1, "LoginName='" + Page.User.Identity.Name + "'");
                //if (dtContact != null &&dtContact.Rows.Count>0)
                //{
                //    tbGovernmentName.Text = dtContact.Rows[0]["OrganizationName"].ToString();
                //}
                this.ViewState["GovernmentID"] = 0;
            }
        }
     

        string loginName = this.ViewState["MemberLoginName"].ToString();
        AjaxPro.Utility.RegisterTypeForAjax(typeof(Tz888.Common.Ajax.AjaxMethod));
        tbExhibitionHall.Attributes.Add("onblur", "CheckDomain(this.value,'" + this.ViewState["MemberLoginName"].ToString() + "');");
    }
    protected void buSend_Click(object sender, ImageClickEventArgs e)
    {
        if (!Page.IsValid)
        {
            return;
        }
        obj = new GovernmentRegisterBLL();
        mode = new GovernmentInfoModel();

        List<Tz888.Model.Common.IndustryModel> industryModels = new List<Tz888.Model.Common.IndustryModel>(); //行业实体列表
        List<Tz888.Model.Register.OrgContactMan> ContactManModels = new List<Tz888.Model.Register.OrgContactMan>();//联系人实体列表 
        Tz888.Model.Register.OrgContactModel ContactModel = new Tz888.Model.Register.OrgContactModel(); //创建信息联系方式主体
        List<Tz888.Model.MemberResourceModel> infoResourceModels = new List<Tz888.Model.MemberResourceModel>();//图片资料

        //基本信息
        mode.LoginName = Page.User.Identity.Name;
        mode.GovernmentName = tbGovernmentName.Text;
        mode.GovAbout = Tz888.Common.Utility.PageValidate.TxtToHtml(tbGovAbout.Text);//公司介绍
        mode.GovAboutBrief = "";
        mode.SubjectType = ddlSubjectType.SelectedValue;
        mode.CountryCode = this.ZoneSelectControl1.CountryID;
        mode.ProvinceID = this.ZoneSelectControl1.ProvinceID;
        mode.CityID = this.ZoneSelectControl1.CityID;
        mode.CountyID = this.ZoneSelectControl1.CountyID;
        mode.AuditingStatus = 0;//审核状态



        //if (mode.ProvinceID == "" && mode.CountryCode.Trim() == "CN")
        //{
        //    Tz888.Common.MessageBox.Show(this.Page, "请选取更详细的注册地址");         
        //    return;
        //}

        mode.ExhibitionHall = tbExhibitionHall.Text;//展厅       
        mode.Hits = 0;//点击数


        mode.remark = "";

        //联系信息
        ContactModel = this.OrgContactControl1.OrgContact;//联系信息
        ContactManModels = this.OrgContactControl1.ContactMans;//联系人


        if (ContactModel.Name.Trim() == "" && ContactModel.TelNum.Trim() == "" && ContactModel.Mobile.Trim() == "")
        {
            Tz888.Common.MessageBox.Show(this.Page, "请输入完整的联系信息！");
            return;
        }

        //将已上传的图片从临时目录迁移到正式目录      
        //infoResourceModels = Tz888.Common.InfoResourceManage.MemberImageTransfer("Image", "GovernmentRegister", Tz888.Common.ResourceType.Image, Tz888.Common.MemberResourceProperty.RP0, ImageUploadControl1.InfoList);
        infoResourceModels = ImageUploadControl1.InfoList;

        //展厅
        if (this.ViewState["WebInfo"].ToString() == "1")
        {
            bool IsVip = false;
            if (Page.User.IsInRole("GT1002")) IsVip = true;

            SelfCreateWeb.Model.DatabaseOperationStatus dos = new SelfCreateWeb.BLL.BSelfCreateWebInfo().AddSelfCreateWebInfo(new SelfCreateWeb.Model.MSelfCreateWebInfo(0, Page.User.Identity.Name, "", 0, tbExhibitionHall.Text.Trim(), DateTime.Now, DateTime.Now,0,""), new SelfCreateWeb.ParameterMap.PSelfCreateWebInfo(false, true, false, false, true, false, false,false,false));
            if (dos == SelfCreateWeb.Model.DatabaseOperationStatus.Success)
            {
                new SelfCreateWeb.BLL.BSelfCreateWebInfo().InitPageParameter(Page.User.Identity.Name, IsVip, true);
            }
            else
            {
                Tz888.Common.MessageBox.Show(this.Page, "此域名不可用，请重新输入！");
                return;
            }
        }   

        int type = 0;
        if (Page.User.IsInRole("GT1001"))   //普通会员

            type = 0;
        else
            type = 1;

        int GovernmentId = Convert.ToInt32(ViewState["GovermentID"].ToString());
        if (GovernmentId == 0)
        {
            int rv = obj.GovernmentAdd(mode, ContactModel, ContactManModels, infoResourceModels);
            if (rv > 0)
            { 
                Response.Redirect("OrgRegisterSucceed.aspx?type=" + type + "&reg=Gov_Add&web=" + tbExhibitionHall.Text + ".gov.");
            }
            else
            {
                Tz888.Common.MessageBox.Show(this.Page, "此域名不可用，请重新输入！");
                return;
            }
        }
        else
        {
            mode.GovernmentID = GovernmentId;
            int rv = obj.GovernmentUpdate(mode, ContactModel, ContactManModels, infoResourceModels);
            Response.Redirect("OrgRegisterSucceed.aspx?type=" + type + "&reg=Gov_Update&web=" + tbExhibitionHall.Text + ".gov.");
        }
    }
    //查询是否重复

}
