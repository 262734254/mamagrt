using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Tz888.Model.Register;
using Tz888.Common.DEncrypt;
using System.Security.Cryptography;
using Tz888.BLL.Register;
using System.Collections.Generic;

public partial class Register_RegIntermediary : System.Web.UI.Page
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
        else
        {
            Click();
        }
    }

   // protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
      private void Click()
       {
        string loginName;
        string passWord;
        string nikeName;
        string email;
        string phone;
        string zone;
        string country;
        string mobile;
        string company;
        //string propertyid;
        string invite;      //邀请人
        //string intent;//意向
        //string question;
        //string answer;



        loginName = this.usrname.Value;
        passWord = Request.Form["repwd"];
        nikeName = Request.Form["nikename"];
        email = Request.Form["email"];
        phone = Request.Form["phone"];
        zone = Request.Form["zone"];
        country = Request.Form["country"];
        mobile = Request.Form["mobile"];
        company = Request.Form["company"];
        //propertyid = Request.Form["propertyid"];


        invite = Request.Form["invite"];
        //intent = Request.Form["intent"];
        //question = Request.Form["question"];
        //answer = Request.Form["answer"];

        phone = country + "-" + zone + "-" + phone;



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


        //注册信息
        SHA1 sha1 = SHA1.Create();
        byte[] passWord2 = sha1.ComputeHash(Encoding.Unicode.GetBytes(passWord.Trim()));

        LoginInfoModel model = new LoginInfoModel();

        if (Request.Cookies["adv_cpa"] != null)
        {
            HttpCookie logCook = Request.Cookies["adv_cpa"];
            model.adsiteID = logCook.Value.ToString().Trim();

            model.autoReg = 2;
        }

        model.LoginName = loginName;
        model.Password = passWord2;
        model.NickName = nikeName;
        //model.PWDAnswere = answer;
        //model.PWDQuestion = question;
        model.RoleName = "0";//会员
        model.ManageTypeID = "2004";
        model.MemberGradeID = "1001";
        model.IsCheckUp = false;
        model.Email = email;
        model.Tel = phone;
        model.CompanyName = company;
        model.PropertyID = 0;

        //model.ContactTitle = "";
        //model.ContactName = "";
        //model.RequirInfo = "";
        //model.RequirInfo = intent;


        //--------会员信息
        MemberInfoModel memberModel = new MemberInfoModel();
        memberModel.LoginName = loginName;
        memberModel.ManageTypeID = "2004";
        memberModel.NickName = nikeName;
        memberModel.Email = email;
        memberModel.Tel = phone;
        //memberModel.RequirInfo = intent;
        memberModel.Mobile = mobile;
        memberModel.Birthday = DateTime.Now;




        LoginInfoBLL loginfo = new LoginInfoBLL();

        MemberInfoBLL member = new MemberInfoBLL();
        try
        {

            //向注册表写数据

            try
            { loginfo.LogInfoAdd(model); }
            catch (System.Data.SqlClient.SqlException ex)
            {
                throw (new Exception(ex.Message));
            }

            //会员信息
            int i = member.MemberMessage_Insert(memberModel);

            //论坛会员注册
            if (i > 0)
            { BBS_Reg.Reg(nikeName, passWord, email); }
            //邀请注册
            //if (invite.Trim().Length > 0)
            //{
            //    loginfo.InviterRegiste(Request.UserHostAddress, email, invite);
            //}

            //添加邀请人
            //if (loginName.Trim() != "" && invite.Trim() != "")
            //{
            //    AdSystem.Introducer ad = new AdSystem.Introducer();
            //    ad.AddIntroducer(loginName, invite);
            //}

            string encryEmail = Server.UrlEncode(DEncrypt.Encrypt(email));
            string encryLogname = Server.UrlEncode(DEncrypt.Encrypt(loginName));
            string act = Server.UrlEncode(DEncrypt.Encrypt("register"));
            string strPass = Server.UrlEncode(DEncrypt.Encrypt(passWord));
            string ValidUrl = "RegisterSuccessIntermediary.aspx?email=" + encryEmail + "&logname=" + encryLogname + "&act=" + act+"&PassWord="+strPass;

            Response.Redirect(ValidUrl, true);
        }
        catch (Exception exp)
        {
            //Tz888.Common.MessageBox.ShowBack(exp.Message.ToString());
            Tz888.Common.MessageBox.ShowBack("数据提交时出错，注册失败。");
        }
        finally
        {
            string encryEmail = Server.UrlEncode(DEncrypt.Encrypt(email));
            string encryLogname = Server.UrlEncode(DEncrypt.Encrypt(loginName));
            string act = Server.UrlEncode(DEncrypt.Encrypt("register"));
            string strPass = Server.UrlEncode(DEncrypt.Encrypt(passWord));
            string ValidUrl = "RegisterSuccessIntermediary.aspx?email=" + encryEmail + "&logname=" + encryLogname + "&act=" + act + "&PassWord=" + strPass;
            Response.Redirect(ValidUrl, true);
        }

    }
}
