using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.IO;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Collections.Generic;
using Tz888.Model;

public partial class Register_MemberRegisterDetail : System.Web.UI.Page
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
        btnOk.Attributes.Add("onclick", "return chkPost();");

        this.ViewState["LoginMemberName"] = Page.User.Identity.Name;
        this.ViewState["HeadPortrait"] = "";
           
        //注册信息        
        Tz888.BLL.Login.LoginInfoBLL obj1 = new Tz888.BLL.Login.LoginInfoBLL();
        //登记联系人

        Tz888.BLL.Register.common obj2 = new Tz888.BLL.Register.common();
        Tz888.Model.Register.OrgContactModel model2 = new Tz888.Model.Register.OrgContactModel();
        //会员信息表

        Tz888.Model.Register.MemberInfoModel model3 = new Tz888.Model.Register.MemberInfoModel();       
        Tz888.BLL.Register.MemberInfoBLL obj3 = new Tz888.BLL.Register.MemberInfoBLL();

        model3 = obj3.GetModel("LoginName='" + this.ViewState["LoginMemberName"].ToString() + "'");

        ////头像
        //if (model3 != null)
        //{
        //    rblSex.SelectedValue = model3.Sex.ToString();
        //    if (model3.HeadPortrait != "" && model3.HeadPortrait != null)
        //    {
        //        FileUploader1.Img = ConfigurationManager.AppSettings["ImageDomain"].ToString() + "/" + model3.HeadPortrait;
        //        FileUploader1.ButtonName = "修改";
        //        FileUploader1.MaxPics = 0;
        //        FileUploader1.IsUp = "0";//是否通过控件上传
        //        //  this.ViewState["HeadPortrait"] = model3.HeadPortrait;
        //        this.ViewState["HeadPortrait"] = model3.HeadPortrait;
        //    }
        //    else
        //    {
        //        FileUploader1.Img = "../images/MemberData/nopic.gif";
        //        FileUploader1.ButtonName = "修改";
        //        FileUploader1.MaxPics = 1;
        //        FileUploader1.IsUp = "0";//是否通过控件上传
        //    }
        //}

        if (!IsPostBack)
        {
            DataTable dt1 = obj1.GetLoginInfoList("*", "LoginName='"+ this.ViewState["LoginMemberName"].ToString()+"'", "LoginName");
            model2 = obj2.getContactModel( this.ViewState["LoginMemberName"].ToString());
            if (dt1.Rows.Count > 0)
            {
                #region 信息绑定
                txtEmail.Text = dt1.Rows[0]["Email"].ToString();
                lbLoginName.Text = dt1.Rows[0]["LoginName"].ToString();

                switch (dt1.Rows[0]["ManageTypeID"].ToString().Trim())
                {
                    case "1001":
                        lbManageType.Text = "个人会员";
                        ChkLstRequirInfo.Items[0].Enabled = false;
                        Label1.Text = "公司网址";
                        hlView.NavigateUrl = "MemberMessage_P.aspx?LoginName=" + this.ViewState["LoginMemberName"].ToString();
                        HyperLink1.NavigateUrl = "MemberMessage_P.aspx?LoginName=" + this.ViewState["LoginMemberName"].ToString();
                        break;
                    case "1003":
                        lbManageType.Text = "企业会员";
                        ChkLstRequirInfo.Items[0].Enabled = false;
                        Label1.Text = "公司网址";
                        hlView.NavigateUrl = "MemberMessage_E.aspx?LoginName=" + this.ViewState["LoginMemberName"].ToString();
                        HyperLink1.NavigateUrl = "MemberMessage_E.aspx?LoginName=" + this.ViewState["LoginMemberName"].ToString();
                        break;
                    case "1004":
                        lbManageType.Text = "政府会员";
                        ChkLstRequirInfo.Items[1].Enabled = false;
                        ChkLstRequirInfo.Items[2].Enabled = false;
                        ChkLstRequirInfo.Items[3].Enabled = false;
                        ChkLstRequirInfo.Items[4].Enabled = false;
                        ChkLstRequirInfo.Items[5].Enabled = false;
                        Label1.Text = "机构网址";
                        hlView.NavigateUrl = "MemberMessage_G.aspx?LoginName=" + this.ViewState["LoginMemberName"].ToString();
                        HyperLink1.NavigateUrl = "MemberMessage_G.aspx?LoginName=" + this.ViewState["LoginMemberName"].ToString();
                        break;
                    default:
                        break;

                }
                this.ViewState["ManageTypeID"] = dt1.Rows[0]["ManageTypeID"].ToString();
                string[] code = dt1.Rows[0]["RequirInfo"].ToString().Split(new char[] { ',' }, 6);
                foreach (ListItem li in ChkLstRequirInfo.Items)
                {
                    for (int i = 0; i < code.Length; i++)
                    {
                        if (li.Value == code[i].Trim())
                        {
                            li.Selected = true;
                        }
                    }
                }

                if (dt1.Rows[0]["Tel"] != "")
                {
                    try
                    {
                        string[] tel = dt1.Rows[0]["Tel"].ToString().Split('-');
                        txtTelCountry.Text = tel[0].ToString();
                        txtTelZoneCode.Text = tel[1].ToString();
                        txtTelNumber.Text = tel[2].ToString();
                    }
                    catch
                    {
                        txtTelCountry.Text = "+86";
                        txtTelZoneCode.Text = "";
                        txtTelNumber.Text = dt1.Rows[0]["Tel"].ToString();//因以前数据格式不同原因，没有用‘-’分格

                    }
                }
             

                lbNickName.Text = dt1.Rows[0]["NickName"].ToString();
                txtMemberName.Text = dt1.Rows[0]["RealName"].ToString();
                

                //公司，机构登记    公司网址
                if (Page.User.IsInRole("MT1004"))//机构
                {
                    Tz888.BLL.Register.GovernmentRegisterBLL obj = new Tz888.BLL.Register.GovernmentRegisterBLL();
                    DataTable dtGov = obj.getGovernmentModel(this.ViewState["LoginMemberName"].ToString());
                    if (dtGov == null)
                    {
                        Label2.Text = "<span class='hui'> 您还没有登记您的机构信息<a href='/Register/GovernmentRegister.aspx'>立即登记</a></span>";
                        Label3.Text = "<span class='hui'>如果您的机构还没有网站</span><a href='http://co.topfo.com/manager/intro.aspx' target='blank'>请点此建立您的网上展厅</a>";
                    }
                    else
                    {
                        Label3.Text = "<span class='hui'>您的展厅地址为：www." + dtGov.Rows[0]["ExhibitionHall"].ToString().Trim() + ".co.tz888.cn <span class='hui'>，如果您的公司还没有网站，可用此网址。</span> ";
                    }
                   
                }
                else if (Page.User.IsInRole("MT1003")) //企业
                {
                    Tz888.BLL.Register.EnterpriseRegisterBLL obj = new Tz888.BLL.Register.EnterpriseRegisterBLL();
                    DataTable dtEnt = obj.getEnterpriseModel(this.ViewState["LoginMemberName"].ToString());
                    if (dtEnt == null)
                    {
                        Label2.Text = "<span class='hui'> 您还没有登记您的公司信息<a href='/Register/EnterpriseRegister.aspx'>立即登记</a></span>";
                        Label3.Text = "<span class='hui'>如果您的公司还没有网站</span><a href='http://co.topfo.com/Manager/intro.aspx' target='blank'>请点此建立您的网上展厅</a>";
                    }
                    else
                    {
                        Label3.Text = "<span class='hui'>您的展厅地址为：www." + dtEnt.Rows[0]["ExhibitionHall"].ToString().Trim() + ".co.tz888.cn <span class='hui'>，如果您的公司还没有网站，可用此网址。</span> ";
                         
                    }
                  
                }
                else if (Page.User.IsInRole("MT1001")) //个人
                {
                    Label2.Text = "";
                }

            

                
                if (model2 != null)
                {
                    txtOrganizationName.Text = model2.OrganizationName;
                    txtMobile.Text = model2.Mobile;
                    txtFaxCountry.Text = model2.FaxCountryCode;
                    txtFaxZoneCode.Text = model2.FaxStateCode;
                    txtFaxNumber.Text = model2.FaxNum;
                    txtAddress.Text = model2.address;
                    txtPostCode.Text = model2.PostCode;                   
                }
                else
                {

                }
             
                #endregion

                this.ViewState["tag"] = "update";
            }
            else
            {
                this.ViewState["tag"] = "add";
            }
        }
        //会员是否存在
        AjaxPro.Utility.RegisterTypeForAjax(typeof(Tz888.Common.Ajax.AjaxMethod));
      
    }
    protected void btnOk_Click(object sender, EventArgs e)
    {
             
            //注册信息        
            Tz888.BLL.Login.LoginInfoBLL objInfo1 = new Tz888.BLL.Login.LoginInfoBLL();
            //登记联系人


            Tz888.BLL.Register.common objInfo2 = new Tz888.BLL.Register.common();
            Tz888.Model.Register.OrgContactModel modelInfo2 = new Tz888.Model.Register.OrgContactModel();
            //会员信息表


            Tz888.Model.Register.MemberInfoModel modelInfo3 = new Tz888.Model.Register.MemberInfoModel();
            Tz888.BLL.Register.MemberInfoBLL objInfo3 = new Tz888.BLL.Register.MemberInfoBLL();

            #region  信息赋值



            string LoginName = this.ViewState["LoginMemberName"].ToString();
            string MemberName = txtMemberName.Text.Trim();
            bool Sex = Convert.ToBoolean(rblSex.SelectedValue);
            string NickName = lbNickName.Text;

            string Address = txtAddress.Text;
            string PostCode = txtPostCode.Text;
            string Mobile = txtMobile.Text;
            string ManageTypeID = this.ViewState["ManageTypeID"].ToString();

            #region 注册信息
            modelInfo3.MemberID = 0;
            modelInfo3.LoginName = this.ViewState["LoginMemberName"].ToString();
            modelInfo3.MemberName = MemberName;
            modelInfo3.Sex = Sex;
            modelInfo3.NickName = NickName;
            modelInfo3.Birthday = DateTime.Now;
            modelInfo3.CertificateID = "";
            modelInfo3.CertificateNumber = "";
            modelInfo3.CountryCode = "";
            modelInfo3.ProvinceID = "";
            modelInfo3.CountyID = "";
            modelInfo3.Address = Address;
            modelInfo3.PostCode = PostCode;
            modelInfo3.Tel = txtTelCountry.Text +"-" +txtTelZoneCode.Text +"-" +txtTelNumber.Text;
            modelInfo3.Mobile = txtMobile.Text;
            modelInfo3.FAX = txtFaxCountry.Text + "-" + txtFaxZoneCode.Text + "-" + txtFaxNumber.Text;
            modelInfo3.Email = txtEmail.Text;
            modelInfo3.IsSecurity = false;
            modelInfo3.ManageTypeID = ManageTypeID;

            string strRequirInfo = "";
            foreach (ListItem li in ChkLstRequirInfo.Items)
            {
                if (li.Selected && li.Enabled)
                {
                    strRequirInfo = strRequirInfo + li.Value.ToString().Trim() + ",";
                }
            }
            if (strRequirInfo == "")
            {
                Tz888.Common.MessageBox.Show(this.Page,"请选择您的用户意向。");
            }
            modelInfo3.RequirInfo = strRequirInfo;

            modelInfo3.RequirInfoDesc = "";

            //保存头像  
        string Pic1 = "";
        try
        {
            string[] UploadImgFileName = FileUploader1.SaveImages("MemberHead");

            if (UploadImgFileName.Length > 0)
            {
                Pic1 = UploadImgFileName[0];
            }
        }
        catch(Exception aa) {
           //// Response.Write(aa.ToString());
            //return;
        }
            if (this.ViewState["HeadPortrait"] != null && this.ViewState["HeadPortrait"].ToString()!="")
            {
                modelInfo3.HeadPortrait = Pic1 != "" ? Pic1 : this.ViewState["HeadPortrait"].ToString();
            }
            else
            {
                modelInfo3.HeadPortrait = Pic1 != "" ? Pic1 : "";
            }

            this.ViewState["HeadPortrait"] = modelInfo3.HeadPortrait;

          //  Response.Write(Session["HeadPortrait"].ToString());

            FileUploader1.Img = ConfigurationManager.AppSettings["ImageDomain"].ToString() + "/" + modelInfo3.HeadPortrait;
            FileUploader1.ButtonName = "修改";
            FileUploader1.MaxPics = 1;
            FileUploader1.IsUp = "0";//是否通过控件上传

            #endregion

            #region 公司登记信息
            modelInfo2.ContactID = 0;
            modelInfo2.LoginName = this.ViewState["LoginMemberName"].ToString();
            modelInfo2.OrganizationName = txtOrganizationName.Text;
            modelInfo2.Name = LoginName;
            modelInfo2.Career = tbCareer.Text;
            modelInfo2.TelCountryCode = txtTelCountry.Text;
            modelInfo2.TelStateCode = txtTelZoneCode.Text;
            modelInfo2.TelNum = txtTelNumber.Text;
            modelInfo2.FaxCountryCode = txtFaxCountry.Text;
            modelInfo2.FaxStateCode = txtFaxZoneCode.Text;
            modelInfo2.FaxNum = txtFaxNumber.Text;
            modelInfo2.Email = txtEmail.Text;
            modelInfo2.Mobile = txtMobile.Text;
            modelInfo2.address = txtAddress.Text;
            modelInfo2.PostCode = txtPostCode.Text;
            modelInfo2.Website = txtWebSite.Text;
            modelInfo2.IsDel = false;
            modelInfo2.remark = "";

            #endregion
            #endregion

            int int1 = 0;
            long int2 = 0;


            //判断会员信息表里是否己存在,并更新注册表
            if (this.ViewState["tag"].ToString() == "add")
            {
                int1 = objInfo3.MemberMessage_Insert(modelInfo3);
            }
            else if (this.ViewState["tag"].ToString() == "update")
            {
                int1 = objInfo3.MemberMessage_Update(modelInfo3);
            }


            //判断登记联系人表里是否己存在       
            int2 = objInfo2.OrgContactMan_FromMemberMessage(modelInfo2);

            if (int1 > 0 && int2 > 0)
            {
                Tz888.Common.MessageBox.Show(this.Page, "信息修改成功！");
            }
       
    }
}
