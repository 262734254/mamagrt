using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Tz888.BLL.Register;
using Tz888.Model.Register;
using Tz888.Common.DEncrypt;
using System.Security.Cryptography;
using System.Collections.Generic;

public partial class Register_RegEnterpriseInfo : System.Web.UI.Page
{
    public string introStr;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //20100505 是否有url传值的邀请人
            if (Request.Cookies["JID"] != null && Request.Cookies["JID"].Value.Trim() != "")
            {
                introStr = Request.Cookies["JID"].Value.Trim();
            }
            
           
        }

    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        string loginName;
        string passWord;
        string nikeName;
        string email;
        string phone;
        string zone;
        string country;
        string mobile;
        string groupName;//单位名称
      
        string invite;
        string countrycode;
        string province;
        string capital;
        string city;
        string address;
        string intent;//意向
        decimal cap = 1111;
        string tel;
        string anwser;
        string question;
       
        loginName = this.usrname.Value;
        passWord = Request.Form["repwd"];
        nikeName = Request.Form["nikename"];
        email = Request.Form["email"];
        tel = Request.Form["phone"];
        groupName = Request.Form["comname"];
        zone = Request.Form["zone"];
        country = Request.Form["country"];
        mobile = Request.Form["mobile"];
        invite = Request.Form["invite"];
        countrycode = Request.Form["CountryListCN"];
        province = Request.Form["provinceCN"];
        capital =Request.Form["capitalCN"];
        city = Request.Form["cityCN"];
        address = Request.Form["address"];
        intent = Request.Form["intent"];
        anwser = Request.Form["answer"];
        question = Request.Form["question"];

        phone = country + "-" + zone + "-" + tel;



        #region 验证提交的验证码并清空验证码
        ///--------------------------------------------------
        ///--验证提交的验证码并清空验证码
        ///--------------------------------------------------
        string vercode = Request.Form["vercode"];
        string strRndNum = "";
        //SESSION丢失
        if (Session["valationNo"] == null)
        {
            Response.Write("<script>alert('操作超时！请刷新页面！');</script>");
            return;
        }
        else
        {
            if (vercode.Trim() == "")
            {
                Response.Write("<script>alert('验证码不能为空，请重新提交！');</script>");
                return;
            }
            else
            {
                strRndNum = Session["valationNo"].ToString();
                if (vercode.Trim() != "" && vercode.ToLower().Trim() == strRndNum.ToLower())
                {
                    Session["valationNo"] = "";
                }
                else
                {
                    Response.Write("<script>alert('验证码错误，请重新提交！');</script>");
                    return;
                }
            }
        }
        #endregion


        if (capital != "")
        {
            cap = Convert.ToDecimal(capital);
        }
        //注册信息
        SHA1 sha1 = SHA1.Create();
        byte[] passWord2 = sha1.ComputeHash(Encoding.Unicode.GetBytes(passWord.Trim()));

        LoginInfoModel model = new LoginInfoModel();
        model.LoginName = loginName;
        model.Password = passWord2;
        model.NickName = nikeName;
        model.PWDAnswere = anwser;
        model.PWDQuestion = question;
        model.RoleName = "0";//会员
        model.ManageTypeID = "1003";
        model.MemberGradeID = "1001";
        model.IsCheckUp = false;
        model.Email = email;
        model.Tel = phone;
        model.RequirInfo = intent;

  
        //--------会员信息
        MemberInfoModel memberModel = new MemberInfoModel();
        memberModel.LoginName = loginName;
        memberModel.NickName = nikeName;
        memberModel.Email = email;
        memberModel.Tel = phone;
        memberModel.Mobile = mobile;
        memberModel.CountryCode = country;
        memberModel.CountyID = city;
        memberModel.ProvinceID = province;
        memberModel.RequirInfo = intent;
        memberModel.Address = address;
        memberModel.Birthday = DateTime.Now;

        OrgContactModel contactModel = new OrgContactModel();
        contactModel.address = address;
        contactModel.IsDel = false;
        contactModel.Mobile = mobile;
        contactModel.OrganizationName = groupName;
        contactModel.Email = email;
        contactModel.LoginName = loginName;
        contactModel.Name = "";
        contactModel.TelCountryCode = country;
        contactModel.TelNum = tel;
        contactModel.TelStateCode = zone;
        contactModel.FaxCountryCode = country;

        
        LoginInfoBLL loginfo = new LoginInfoBLL();
        common orgContact = new common();
        MemberInfoBLL member = new MemberInfoBLL();
        //向注册表写数据

        try
        {
            try
            { 
                loginfo.LogInfoAdd(model); 
            }
            catch (System.Data.SqlClient.SqlException exp)
            {
                throw (new Exception(exp.Message));
            }
            //企业注册 
            orgContact.AddOrgContect(contactModel);
            //会员信息
            int i=member.MemberMessage_Insert(memberModel);

            //论坛会员注册
            if (i > 0)
            { BBS_Reg.Reg(nikeName, passWord, email); }
            //邀请注册处理
            if (invite.Trim().Length > 0)
            {
                loginfo.InviterRegiste(Request.UserHostAddress, email, invite);
            }
            //添加邀请人
            if (loginName.Trim() != "" && invite.Trim() != "")
            {
                AdSystem.Introducer ad = new AdSystem.Introducer();
                ad.AddIntroducer(loginName, invite);
            }
        
            string encryEmail = Server.UrlEncode(DEncrypt.Encrypt(email));
            string encryLogname = Server.UrlEncode(DEncrypt.Encrypt(loginName));
            string act = Server.UrlEncode(DEncrypt.Encrypt("register"));
            string ValidUrl = "ValidSuccessEnter.aspx?email=" + encryEmail + "&logname=" + encryLogname+"&act="+act;

            Response.Redirect(ValidUrl, true);
        }
        catch(Exception ex)
        {
            Response.Write(ex.Message);
           //Tz888.Common.MessageBox.ShowBack("数据提交时出错,注册失败。");
        }

       
    }
}
