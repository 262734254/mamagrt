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
using Tz888.BLL.Common;
using SelfCreateWeb.Model;
using SelfCreateWeb.BLL;
using SelfCreateWeb.Common;

public partial class Enterprise_Register : System.Web.UI.Page
{
    public Tz888.BLL.Register.EnterpriseRegisterBLL obj;
    public Tz888.Model.Register.EnterpriseInfoModel mode;
    public Tz888.BLL.Register.MemberInfoBLL obj2;
    public Tz888.Model.LoginInfo model2;

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
        //if (Page.User.Identity.Name == null || Page.User.Identity.Name.Trim() == "")
        //{
        //    Response.Redirect("../Login.aspx?ReturnUrl=" + Server.UrlEncode(Request.RawUrl));
        //}

        //if (Page.User.IsInRole("MT1004"))
        //    Response.Redirect("GovernmentRegisterResult.aspx");

        //buSend.Attributes.Add("onclick", "return chkPost();");
        //if (Page.User.IsInRole("MT1001"))
        //{
        //    Tz888.Common.MessageBox.ShowAndRedirect(this.Page, "对不起，您是个人会员，不能进行公司登记", "/index.aspx");

        //    Response.Flush();
        //    Response.End();
        //    return;
        //}

        //if (Page.User.IsInRole("GT1001"))
        //{
        //    ImageUploadControl1.Count = 5;
        //    ImageUploadControl1.NoneCount = 3;
        //}
        //else
        //{
        //    ImageUploadControl1.Count = 5;
        //    ImageUploadControl1.NoneCount = 5;
        //}


        if (!Page.IsPostBack)
           {
               this.ViewState["MemberLoginName"] = Page.User.Identity.Name;//

            //展厅
               System.Collections.Generic.IList<SelfCreateWeb.Model.MSelfCreateWebInfo> finduser = new SelfCreateWeb.BLL.BSelfCreateWebInfo().GetSelfCreateWebInfo(1, 100, new string[] { "LoginName" }, new string[] { this.ViewState["MemberLoginName"].ToString() });

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

            //联系信息加载
            List<Tz888.Model.Register.OrgContactMan> contactMans = new List<Tz888.Model.Register.OrgContactMan>();//联系人实体列表 
            Tz888.Model.Register.OrgContactModel orgContact = new Tz888.Model.Register.OrgContactModel(); //创建信息联系方式主体
            List<Tz888.Model.MemberResourceModel> infoResource = new List<Tz888.Model.MemberResourceModel>();//图片资料

            Tz888.BLL.Register.common  com= new common();
         
            orgContact = com.getContactModel(this.ViewState["MemberLoginName"].ToString());
            try
            {
                contactMans = com.GetOrgContactMan(this.ViewState["MemberLoginName"].ToString());
            }
            catch
            {
                contactMans = null;
            }
                ///0 公司介绍（多图片）

                ///1营业执照
                ///2税务登记证(国税)
                ///3税务登记证(地税)
                ///4荣誉和证书


                ///5其它*/
            try
            {
                infoResource = com.GetMemberResourceModel(this.ViewState["MemberLoginName"].ToString(), 0);
            }
            catch
            {
                infoResource = null;
            }

            OrgContactControl1.OrgContact = orgContact;//联系信息
            OrgContactControl1.ContactMans = contactMans;//联系人

            ImageUploadControl1.InfoList = infoResource;
            

            //企业性质
            obj = new EnterpriseRegisterBLL();
            ddManageType.DataSource = obj.getEnterpriceManageType();
            ddManageType.DataTextField = "SetComTypeName";
            ddManageType.DataValueField = "SetComTypeID";
            ddManageType.DataBind();  


            //判断操作性质：添加，修改
             Tz888.BLL.Register.EnterpriseRegisterBLL obj2 = new EnterpriseRegisterBLL();
             DataTable dt = obj2.getEnterpriseModel( this.ViewState["MemberLoginName"].ToString());
             this.ViewState["Domain"] = "Add";
             this.ViewState["EnterpriseID"] = 0;   
       
             if (dt != null && dt.Rows.Count > 0)//修改
            { 
                this.ViewState["EnterpriseID"] = dt.Rows[0]["EnterpriseID"].ToString(); ;
                //基本信息               
                tbEnterpriseName.Text = dt.Rows[0]["EnterpriseName"].ToString();
                ddManageType.SelectedValue = dt.Rows[0]["SetComTypeID"].ToString();
                tbRegisterDate.Text = dt.Rows[0]["RegisterDate"].ToString();
               
                 //网上展厅(按LoginName读取展厅地址)
                if (dt.Rows[0]["ExhibitionHall"].ToString() != "")
                {
                   // tbExhibitionHall.Text = dt.Rows[0]["ExhibitionHall"].ToString();
                   // tbExhibitionHall.Enabled = false;
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
               

                ddlCapitalCurrency.SelectedValue = dt.Rows[0]["currency"].ToString();
                tbRegCapital.Text = dt.Rows[0]["RegCapital"].ToString() ;
                
                //行业
                SelectIndustryControl1.IndustryString = dt.Rows[0]["Industrylist"].ToString();

                ContentPlaceHolder content = (ContentPlaceHolder)Master.FindControl("ContentPlaceHolder1");
                string mp = dt.Rows[0]["MainProduct"].ToString();
                string[] Product = null;
                Product = mp.Split(',');
                if (mp != "" || mp != null)
                {
                    Product = mp.Split(',');                  
                    for (int i = 0; i < mp.Length; i++)
                    {
                        try
                        {
                            string value = Product[i].ToString();
                            int j = i + 1;
                            System.Web.UI.WebControls.TextBox tb = (TextBox)content.FindControl("tbMainProduct" + j.ToString());
                            tb.Text = value;
                        }
                        catch { }
                    }
                }

                tbComAbout.Text = Tz888.Common.Utility.PageValidate.HtmlToTxt(dt.Rows[0]["ComAbout"].ToString()); 

            }//添加
            else {
                //读取注册信息
                //Tz888.BLL.Conn obCon = new Tz888.BLL.Conn();
                //DataTable dtContact = obCon.GetList("OrgContactTab", "*", "LoginName", 1, 1, 0, 1, "LoginName='" + Page.User.Identity.Name + "'");
                //if (dtContact != null)
                //{
                //    tbEnterpriseName.Text = dtContact.Rows[0]["OrganizationName"].ToString();
                //}
                this.ViewState["EnterpriseID"] = 0;               
            }            
        }
      
        AjaxPro.Utility.RegisterTypeForAjax(typeof(Tz888.Common.Ajax.AjaxMethod));
        tbExhibitionHall.Attributes.Add("onblur", "CheckDomain(this.value,'" +  this.ViewState["MemberLoginName"].ToString() + "');");

    }


    protected void buSend_Click(object sender, ImageClickEventArgs e)
    {
       
        obj = new EnterpriseRegisterBLL();
        mode = new EnterpriseInfoModel();

        List<Tz888.Model.Common.IndustryModel> industryModels = new List<Tz888.Model.Common.IndustryModel>(); //行业实体列表
        List<Tz888.Model.Register.OrgContactMan> ContactManModels = new  List<Tz888.Model.Register.OrgContactMan>();//联系人实体列表 
        Tz888.Model.Register.OrgContactModel  ContactModel= new Tz888.Model.Register.OrgContactModel(); //创建信息联系方式主体     
        List<Tz888.Model.MemberResourceModel> infoResourceModels = new List<Tz888.Model.MemberResourceModel>();//图片资料

        mode.LoginName =  this.ViewState["MemberLoginName"].ToString();
        mode.EnterpriseName = tbEnterpriseName.Text;
        mode.SetComTypeID = Convert.ToInt32(ddManageType.SelectedValue);
        try
        {
            mode.RegisterDate = Convert.ToDateTime(tbRegisterDate.Text);
        }
        catch
        { 
            Tz888.Common.MessageBox.Show(this.Page, "注册时间输入错误");
            return;
        }
        mode.CountryCode = this.ZoneSelectControl1.CountryID;
        mode.ProvinceID = this.ZoneSelectControl1.ProvinceID;
        mode.CityID = this.ZoneSelectControl1.CityID;
        mode.CountyID = this.ZoneSelectControl1.CountyID;
        if (mode.ProvinceID == "" && mode.CountryCode.Trim()=="CN")
        {
            Tz888.Common.MessageBox.Show(this.Page, "请选取更详细的注册地址");         
            return;
        }

        industryModels = this.SelectIndustryControl1.IndustryModels;
        if (industryModels == null)
        {
            Tz888.Common.MessageBox.Show(this.Page, "行业不能为空");    
            return;
        }
        foreach (Tz888.Model.Common.IndustryModel IM in industryModels)
        {
            mode.Industrylist += IM.IndustryBID + ",";
        }
        mode.currency = ddlCapitalCurrency.SelectedValue;//币种
        try
        {
            mode.RegCapital = Convert.ToDecimal(tbRegCapital.Text);//注册资金
        }
        catch 
        { 
            Tz888.Common.MessageBox.Show(this.Page, "请正确输入注册资金！"); 
            return; 
        }
        #region 主营产品或服务

        string MainProduct = "";
        if(!string.IsNullOrEmpty(this.tbMainProduct1.Text.Trim()))
            MainProduct += this.tbMainProduct1.Text.Trim() + ",";
        if(!string.IsNullOrEmpty(this.tbMainProduct2.Text.Trim()))
            MainProduct += this.tbMainProduct2.Text.Trim() + ",";
        if(!string.IsNullOrEmpty(this.tbMainProduct3.Text.Trim()))
            MainProduct += this.tbMainProduct3.Text.Trim() + ",";
        mode.MainProduct = MainProduct;
        #endregion

        #region  读取意向
        Tz888.BLL.Conn objReq = new Tz888.BLL.Conn();
        string req ="";
        DataTable dtReq = objReq.GetList("logininfotab", "RequirInfo", "LoginName", 1, 1, 0, 1, "LoginName='" + this.ViewState["MemberLoginName"].ToString()+ "'");
        if(dtReq!=null)
         req = dtReq.Rows[0]["RequirInfo"].ToString().Trim();  
        #endregion 

        mode.RequirInfo = req;//意向(从注册表里读取)
        mode.AuditingStatus = 0;//审核状态

        if (tbComAbout.Text.Length < 50 || tbComAbout.Text.Length > 2000)
        {
            Tz888.Common.MessageBox.Show(this.Page, "请输入50-2000的公司介绍信息！");
            return;
        }

        mode.ComAbout = Tz888.Common.Utility.PageValidate.TxtToHtml(tbComAbout.Text);//公司介绍

        mode.ComAboutBrief = "";
        mode.ExhibitionHall = tbExhibitionHall.Text;//展厅tbExhibitionHall
        mode.hits = 0;//点击数

        mode.remark = "";
        
        ContactModel = this.OrgContactControl1.OrgContact;//联系信息
        ContactManModels = this.OrgContactControl1.ContactMans;//联系人


        if (ContactModel.Name.Trim() == "" && ContactModel.TelNum.Trim() == "" && ContactModel.Mobile.Trim() == "")
        {
            Tz888.Common.MessageBox.Show(this.Page, "请输入完整的联系信息！");
            return;
        }

        //将已上传的图片从临时目录迁移到正式目录      
        //infoResourceModels = Tz888.Common.InfoResourceManage.MemberImageTransfer("Image", "EnterpriseRegister", Tz888.Common.ResourceType.Image, Tz888.Common.MemberResourceProperty.RP0, ImageUploadControl1.InfoList);
        infoResourceModels = ImageUploadControl1.InfoList;

        ////展厅
        //if (this.ViewState["WebInfo"].ToString() == "1")
        //{
        //    bool IsVip = false;
        //    if (Page.User.IsInRole("GT1002")) IsVip = true;

        //    SelfCreateWeb.Model.DatabaseOperationStatus dos = new SelfCreateWeb.BLL.BSelfCreateWebInfo().AddSelfCreateWebInfo(new SelfCreateWeb.Model.MSelfCreateWebInfo(0, this.ViewState["MemberLoginName"].ToString(), "", 0, tbExhibitionHall.Text.Trim(), DateTime.Now, DateTime.Now), new SelfCreateWeb.ParameterMap.PSelfCreateWebInfo(false, true, false, false, true, false, false));
        //    if (dos == SelfCreateWeb.Model.DatabaseOperationStatus.Success)
        //    {
        //        new SelfCreateWeb.BLL.BSelfCreateWebInfo().InitPageParameter(this.ViewState["MemberLoginName"].ToString(), IsVip, false);
        //    }
        //    else
        //    {
        //        Tz888.Common.MessageBox.Show(this.Page, "此域名不可用，请重新输入！");
        //        return;
        //    }
        //}

        //信息
        int EnterpriseId = Convert.ToInt32(this.ViewState["EnterpriseID"]);

        int type = 0;
        //if (Page.User.IsInRole("GT1001"))   //普通会员

        //    type = 0;
        //else
            type = 1;

       
        if (EnterpriseId == 0)
        {
            int rv = obj.EnterpriseAdd(mode, ContactModel, ContactManModels,infoResourceModels);
            if (rv > 0)
            { 
               Response.Redirect("OrgRegisterSucceed.aspx?type=" + type + "&reg=Ent_Add&web=" + tbExhibitionHall.Text + ".co.");
              // string para="type=" + type + "&reg=Ent_Add&web=" + tbExhibitionHall.Text + ".co.";
            //   Response.Redirect("EnterpriseRegister_additive.aspx?reg=Ent_Add&web=" + tbExhibitionHall.Text + ".co.");
            }
        }
        else
        {
            mode.EnterpriseID = EnterpriseId;
           int rv = obj.EnterpriseUpdate(mode, ContactModel, ContactManModels, infoResourceModels);    
             Response.Redirect("OrgRegisterSucceed.aspx?type=" + type + "&reg=Ent_Update&web=" + tbExhibitionHall.Text + ".co.");
           // string para ="type=" + type + "&reg=Ent_Update&web=" + tbExhibitionHall.Text + ".co.";
          // Response.Redirect("EnterpriseRegister_additive.aspx?reg=Ent_Update&web=" + tbExhibitionHall.Text + ".co.");
          
        }       
    }
}
