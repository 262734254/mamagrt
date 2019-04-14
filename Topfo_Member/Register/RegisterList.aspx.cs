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
using Tz888.Common.DEncrypt;
using System.Security.Cryptography;
using System.Text;

public partial class Register_RegisterList : System.Web.UI.Page
{
    private string str
    {
        get
        {
            return ViewState["str"].ToString();
        }
        set
        {
            ViewState["str"] = value;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            str = Request.QueryString["str"].ToString();
          
           
         
        }
    }

    #region 政府招商注册
    private void Merchant()
    {
        
        //注册信息
        SHA1 sha1 = SHA1.Create();
        byte[] passWord2 = sha1.ComputeHash(Encoding.Unicode.GetBytes(this.txtpassWords.Value.ToString().Trim()));

        LoginInfoModel model = new LoginInfoModel();

        if (Request.Cookies["adv_cpa"] != null)
        {
            HttpCookie logCook = Request.Cookies["adv_cpa"];
            model.adsiteID = logCook.Value.ToString();

            model.autoReg = 2;
        }
        model.CompanyName = "";
        model.LoginName = this.txtloginName.Value.ToString().Trim();
        model.Password = passWord2;
        model.NickName = "";
        model.PWDQuestion = "";
        model.PWDAnswere = "";
        model.RoleName = "0";//会员
        model.ManageTypeID = "2001";
        model.MemberGradeID = "1001";
        model.IsCheckUp = false;
        model.Email = this.txtemail.Value.ToString().Trim();
        string phone = txtCount.Value.ToString().Trim() + "-" + txtStatCount.Value.ToString().Trim() + "-" + txtTel.Value.ToString().Trim();
        model.Tel = phone;
        model.RequirInfo = "0";
        

    


        //----联系信息
        OrgContactModel orgModel = new OrgContactModel();
        orgModel.Email = this.txtemail.Value.ToString().Trim(); ;         //邮箱
        orgModel.IsDel = false;
        orgModel.LoginName = this.txtloginName.Value.ToString().Trim();  //登录名
        orgModel.Mobile = txtMoblie.Value.ToString().Trim();     //手机
        orgModel.Name = "";  //用户真实姓名
        orgModel.OrganizationName = ""; //招商机构名称
        orgModel.TelCountryCode = txtCount.Value.ToString().Trim();
        orgModel.TelNum = txtTel.Value.ToString().Trim();
        orgModel.TelStateCode = txtStatCount.Value.ToString().Trim();
        orgModel.address = "";   //通讯地址
        orgModel.PostCode = ""; //邮编

        //--------会员信息
        MemberInfoModel memberModel = new MemberInfoModel();
        memberModel.LoginName = this.txtloginName.Value.ToString().Trim();  //登录名
        memberModel.NickName = "";     //昵称
        memberModel.Email = this.txtemail.Value.ToString().Trim();          //邮箱
        memberModel.RequirInfo = "";
        memberModel.Tel = phone.ToString().Trim();                //电话
        memberModel.Mobile = txtMoblie.Value.ToString().Trim();         //手机

        memberModel.Birthday = DateTime.Now;   //生日
        memberModel.ContactTitle =""; //招商机构名称
        memberModel.PostCode = "";  //邮编
        memberModel.CountryCode =null; //国别
        memberModel.ProvinceID = null; //省        
        memberModel.CountyID = null;    //市
        memberModel.CityID = null;    //县
        memberModel.Address = "";  //地址
        memberModel.MemberName = "";//用户真实姓名
        LoginInfoBLL loginfo = new LoginInfoBLL();
        common orgContect = new common();
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
            //政府注册 
            orgContect.AddOrgContect(orgModel);
            //会员信息
            int i = member.MemberMessage_Insert(memberModel);

            //邀请注册
            //if (invite.Trim().Length > 0)
            //{
            //    loginfo.InviterRegiste(Request.UserHostAddress, email, invite);
            //}


            string encryEmail = Server.UrlEncode(DEncrypt.Encrypt(this.txtemail.Value.ToString().Trim()));
            string encryLogname = Server.UrlEncode(DEncrypt.Encrypt(this.txtloginName.Value.ToString().Trim()));
            string act = Server.UrlEncode(DEncrypt.Encrypt("register"));
            string strPass = Server.UrlEncode(DEncrypt.Encrypt(this.txtpassWords.Value.ToString().Trim()));
            string ValidUrl = "ValidSuccessGov.aspx?email=" + encryEmail + "&logname=" + encryLogname + "&act=" + act + "&PassWord=" + strPass;
            Response.Redirect(ValidUrl, true);
            Response.Redirect(ValidUrl, true);
        }
        catch (Exception exp)
        {
            //Tz888.Common.MessageBox.ShowBack("数据提交时出错，注册失败。");
        }
        finally
        {
            string encryEmail = Server.UrlEncode(DEncrypt.Encrypt(this.txtemail.Value.ToString().Trim()));
            string encryLogname = Server.UrlEncode(DEncrypt.Encrypt(this.txtloginName.Value.ToString().Trim()));
            string act = Server.UrlEncode(DEncrypt.Encrypt("register"));
            string strPass = Server.UrlEncode(DEncrypt.Encrypt(this.txtpassWords.Value.ToString().Trim()));
            string ValidUrl = "ValidSuccessGov.aspx?email=" + encryEmail + "&logname=" + encryLogname + "&act=" + act + "&PassWord=" + strPass;
            Response.Redirect(ValidUrl, true);
        }
    } 
    #endregion


    #region 项目方注册方法
    private void ProjectInfo()
    {
        //注册信息
        SHA1 sha1 = SHA1.Create();
        byte[] passWord2 = sha1.ComputeHash(Encoding.Unicode.GetBytes(this.txtpassWords.Value.ToString().Trim()));

        LoginInfoModel model = new LoginInfoModel();

        if (Request.Cookies["adv_cpa"] != null)
        {
            HttpCookie logCook = Request.Cookies["adv_cpa"];
            model.adsiteID = logCook.Value.ToString().Trim();

            model.autoReg = 2;
        }
        model.LoginName = this.txtloginName.Value.ToString().Trim();
        model.Password = passWord2;
        model.NickName = "";
        model.RoleName = "0";//会员
        model.ManageTypeID = "2003";
        model.MemberGradeID = "1001";
        model.IsCheckUp = false;
        model.Email = this.txtemail.Value.ToString().Trim();
        string phone = txtCount.Value.ToString().Trim() + "-" + txtStatCount.Value.ToString().Trim() + "-" + txtTel.Value.ToString().Trim();
        model.Tel = phone.ToString().Trim();
        model.CompanyName = "";
        model.ContactName = "";
        model.ContactTitle = "";
        model.PropertyID = 0;//项目类型

        //--------会员信息
        MemberInfoModel memberModel = new MemberInfoModel();
        memberModel.LoginName = this.txtloginName.Value.ToString().Trim();
        memberModel.ManageTypeID = "2003";
        memberModel.NickName = "";
        memberModel.Email = this.txtemail.Value.ToString().Trim();
        memberModel.Tel = phone;
        //memberModel.RequirInfo = intent;
        memberModel.Mobile = txtMoblie.Value.ToString().Trim();     //手机
        memberModel.Birthday = DateTime.Now;
        memberModel.PostCode = "";  //邮编
        memberModel.MemberName = "";//用户真实姓名




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

            ////论坛会员注册
            //if (i > 0)
            //{
            //    BBS_Reg.Reg(nikeName, passWord, email);
            //}
 

           string encryEmail = Server.UrlEncode(DEncrypt.Encrypt(this.txtemail.Value.ToString().Trim()));
            string encryLogname = Server.UrlEncode(DEncrypt.Encrypt(this.txtloginName.Value.ToString().Trim()));
            string act = Server.UrlEncode(DEncrypt.Encrypt("register"));
            string strPass = Server.UrlEncode(DEncrypt.Encrypt(this.txtpassWords.Value.ToString().Trim()));
            string ValidUrl = "RegisterSuccessProject.aspx?email=" + encryEmail + "&logname=" + encryLogname + "&act=" + act + "&PassWord=" + strPass;
            Response.Redirect(ValidUrl, true);
        }
        catch (Exception exp)
        {
            Tz888.Common.MessageBox.ShowBack(exp.Message.ToString());
        }
        finally
        {
            

            string encryEmail = Server.UrlEncode(DEncrypt.Encrypt(this.txtemail.Value.ToString().Trim()));
            string encryLogname = Server.UrlEncode(DEncrypt.Encrypt(this.txtloginName.Value.ToString().Trim()));
            string act = Server.UrlEncode(DEncrypt.Encrypt("register"));
            string strPass = Server.UrlEncode(DEncrypt.Encrypt(this.txtpassWords.Value.ToString().Trim()));
            string ValidUrl = "ValidSuccessGov.aspx?email=" + encryEmail + "&logname=" + encryLogname + "&act=" + act + "&PassWord=" + strPass;

            Response.Redirect(ValidUrl, true);
        }

    } 
    #endregion

    #region 投资方注册
    private void Investors()
    {


        //注册信息
        SHA1 sha1 = SHA1.Create();
        byte[] passWord2 = sha1.ComputeHash(Encoding.Unicode.GetBytes(this.txtpassWords.Value.ToString().Trim()));

        LoginInfoModel model = new LoginInfoModel();

        if (Request.Cookies["adv_cpa"] != null)
        {
            HttpCookie logCook = Request.Cookies["adv_cpa"];
            model.adsiteID = logCook.Value.ToString().Trim();

            model.autoReg = 2;
        }

        model.LoginName = this.txtloginName.Value.ToString().Trim();
        model.Password = passWord2;
        model.NickName = "";
        //model.PWDAnswere = answer;
        //model.PWDQuestion = question;
        model.RoleName = "0";//会员
        model.ManageTypeID = "2002";
        model.MemberGradeID = "1001";
        model.IsCheckUp = false;
        model.Email = this.txtemail.Value.ToString().Trim();
        string phone = txtCount.Value.ToString().Trim() + "-" + txtStatCount.Value.ToString().Trim() + "-" + txtTel.Value.ToString().Trim();
        model.Tel = phone.ToString().Trim();
        model.CompanyName = "";
        model.ContactName = "";
        model.ContactTitle = "";
        model.PropertyID = 0;//项目类型
        //model.RequirInfo = intent;


        //--------会员信息
        MemberInfoModel memberModel = new MemberInfoModel();
        memberModel.LoginName = this.txtloginName.Value.ToString().Trim();
        memberModel.ManageTypeID = "2002";
        memberModel.NickName = "";
        memberModel.Email = this.txtemail.Value.ToString().Trim();
        memberModel.Tel = phone;
        //memberModel.RequirInfo = intent;
        memberModel.Mobile = txtMoblie.Value.ToString().Trim();     //手机
        memberModel.Birthday = DateTime.Now;
        memberModel.PostCode = "";  //邮编
        memberModel.MemberName = "";//用户真实姓名




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

            ////论坛会员注册
            //if (i > 0)
            //{ BBS_Reg.Reg(nikeName, passWord, email); }



            string encryEmail = Server.UrlEncode(DEncrypt.Encrypt(this.txtemail.Value.ToString().Trim()));
            string encryLogname = Server.UrlEncode(DEncrypt.Encrypt(this.txtloginName.Value.ToString().Trim()));
            string act = Server.UrlEncode(DEncrypt.Encrypt("register"));
            string strPass = Server.UrlEncode(DEncrypt.Encrypt(this.txtpassWords.Value.ToString().Trim()));
            string ValidUrl = "RegisterSuccessInvestor.aspx?email=" + encryEmail + "&logname=" + encryLogname + "&act=" + act + "&PassWord=" + strPass;

            Response.Redirect(ValidUrl, true);
        }
        catch (Exception exp)
        {
            //Tz888.Common.MessageBox.ShowBack(exp.Message.ToString());
            Tz888.Common.MessageBox.ShowBack(exp.Message.ToString());
        }
        finally
        {
            string encryEmail = Server.UrlEncode(DEncrypt.Encrypt(this.txtemail.Value.ToString().Trim()));
            string encryLogname = Server.UrlEncode(DEncrypt.Encrypt(this.txtloginName.Value.ToString().Trim()));
            string act = Server.UrlEncode(DEncrypt.Encrypt("register"));
            string strPass = Server.UrlEncode(DEncrypt.Encrypt(this.txtpassWords.Value.ToString().Trim()));
            string ValidUrl = "RegisterSuccessInvestor.aspx?email=" + encryEmail + "&logname=" + encryLogname + "&act=" + act + "&PassWord=" + strPass;

            Response.Redirect(ValidUrl, true);
        }
    } 
    #endregion
     #region 专业服务机构
    private void jigou()
    {
        string loginName;

        loginName = this.txtloginName.Value.ToString().Trim();


 
        //注册信息
        SHA1 sha1 = SHA1.Create();
        byte[] passWord2 = sha1.ComputeHash(Encoding.Unicode.GetBytes(this.txtpassWords.Value.ToString().Trim()));

        LoginInfoModel model = new LoginInfoModel();

        if (Request.Cookies["adv_cpa"] != null)
        {
            HttpCookie logCook = Request.Cookies["adv_cpa"];
            model.adsiteID = logCook.Value.ToString();

            model.autoReg = 2;
        }

        model.LoginName = loginName;
        model.Password = passWord2;
        model.RoleName = "0";//会员
        model.ManageTypeID = "2007";
        model.MemberGradeID = "1001";
        model.IsCheckUp = false;
        model.Email = this.txtemail.Value.ToString().Trim();
        string phone = txtCount.Value.ToString().Trim() + "-" + txtStatCount.Value.ToString().Trim() + "-" + txtTel.Value.ToString().Trim();
        model.Tel = phone;
        model.CompanyName = "";
        model.NickName = " ";
        model.PWDAnswere = "";
        model.PWDQuestion = "";
        model.RequirInfo = "";

        //--------会员信息
        MemberInfoModel memberModel = new MemberInfoModel();
        memberModel.LoginName = loginName;
        memberModel.Email = this.txtemail.Value.ToString().Trim();
        memberModel.ManageTypeID = "2007";
        //memberModel.RequirInfo = requirInfo;
        memberModel.Tel = phone;
        memberModel.Mobile = txtMoblie.Value.ToString().Trim();//手机
        memberModel.Birthday = DateTime.Now;



        LoginInfoBLL loginfo = new LoginInfoBLL();
        Tz888.BLL.Register.SS_Agency_ServicesBLL smode = new SS_Agency_ServicesBLL();
        MemberInfoBLL member = new MemberInfoBLL();
        try
        {
            ////机构服务表

            //try
            //{ smode.AgencyAdd(service); }
            //catch (System.Data.SqlClient.SqlException ex)
            //{
            //    throw (new Exception(ex.Message));
            //}
            //向注册表写数据


            try
            { loginfo.LogInfoAdd(model); }
            catch (System.Data.SqlClient.SqlException ex)
            {
                throw (new Exception(ex.Message));
            }


            // 会员信息
            int i = member.MemberMessage_Insert(memberModel);

            string encryEmail = Server.UrlEncode(DEncrypt.Encrypt(this.txtemail.Value.ToString().Trim()));
            string encryLogname = Server.UrlEncode(DEncrypt.Encrypt(this.txtloginName.Value.ToString().Trim()));
            string act = Server.UrlEncode(DEncrypt.Encrypt("register"));
            string strPass = Server.UrlEncode(DEncrypt.Encrypt(this.txtpassWords.Value.ToString().Trim()));
            string ValidUrl = "ValidSuccessGov.aspx?email=" + encryEmail + "&logname=" + encryLogname + "&act=" + act + "&PassWord=" + strPass;

            Response.Redirect(ValidUrl, true);
        }
        catch (Exception exp)
        {
            Tz888.Common.MessageBox.ShowBack("数据提交时出错，注册失败。");
        }
        finally
        {
            string encryEmail = Server.UrlEncode(DEncrypt.Encrypt(this.txtemail.Value.ToString().Trim()));
            string encryLogname = Server.UrlEncode(DEncrypt.Encrypt(this.txtloginName.Value.ToString().Trim()));
            string act = Server.UrlEncode(DEncrypt.Encrypt("register"));
            string strPass = Server.UrlEncode(DEncrypt.Encrypt(this.txtpassWords.Value.ToString().Trim()));
            string ValidUrl = "ValidSuccessGov.aspx?email=" + encryEmail + "&logname=" + encryLogname + "&act=" + act + "&PassWord=" + strPass;
        }
    } 
    #endregion

    #region 专业服务人才(个人)
    private void Jgrc()
    {
    
        //注册信息
        SHA1 sha1 = SHA1.Create();
        byte[] passWord2 = sha1.ComputeHash(Encoding.Unicode.GetBytes(this.txtpassWords.Value.ToString().Trim()));

        LoginInfoModel model = new LoginInfoModel();
        model.LoginName = this.txtloginName.Value.ToString().Trim();
        model.Password = passWord2;

        model.RoleName = "0";//会员
        model.ManageTypeID = "2006";
        model.MemberGradeID = "1001";
        model.IsCheckUp = false;
        model.Email = this.txtemail.Value.ToString().Trim();
        string phone = txtCount.Value.ToString().Trim() + "-" + txtStatCount.Value.ToString().Trim() + "-" + txtTel.Value.ToString().Trim();
        model.Tel = phone;


        //--------会员信息
        MemberInfoModel memberModel = new MemberInfoModel();
        memberModel.LoginName = this.txtloginName.Value.ToString().Trim();
        memberModel.ManageTypeID = "2006";
        memberModel.Email = this.txtemail.Value.ToString().Trim();
   
        memberModel.Tel = phone;
        memberModel.Mobile = txtMoblie.Value.ToString().Trim();     //手机
        memberModel.CountryCode = null; //国别
        memberModel.ProvinceID = null; //省        
        memberModel.CountyID = null;    //市
        memberModel.CityID = null;    //县
        memberModel.Address = "";
        memberModel.Birthday = DateTime.Now;

        LoginInfoBLL loginfo = new LoginInfoBLL();
     
        MemberInfoBLL member = new MemberInfoBLL();
        //向注册表写数据


        try
        {
            loginfo.LogInfoAdd(model);
        
            try
            {
                int i = member.MemberMessage_Insert(memberModel);

            }
            catch (System.Data.SqlClient.SqlException exp)
            {
                throw (new Exception(exp.Message));
            }

            // 会员信息
            string encryEmail = Server.UrlEncode(DEncrypt.Encrypt(this.txtemail.Value.ToString().Trim()));
            string encryLogname = Server.UrlEncode(DEncrypt.Encrypt(this.txtloginName.Value.ToString().Trim()));
            string act = Server.UrlEncode(DEncrypt.Encrypt("register"));
            string strPass = Server.UrlEncode(DEncrypt.Encrypt(this.txtpassWords.Value.ToString().Trim()));
            string ValidUrl = "ValidSuccessGov.aspx?email=" + encryEmail + "&logname=" + encryLogname + "&act=" + act + "&PassWord=" + strPass;

            Response.Redirect(ValidUrl, true);
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
            Tz888.Common.MessageBox.ShowBack("数据提交时出错,注册失败。");
        }
        finally
        {
            string encryEmail = Server.UrlEncode(DEncrypt.Encrypt(this.txtemail.Value.ToString().Trim()));
            string encryLogname = Server.UrlEncode(DEncrypt.Encrypt(this.txtloginName.Value.ToString().Trim()));
            string act = Server.UrlEncode(DEncrypt.Encrypt("register"));
            string strPass = Server.UrlEncode(DEncrypt.Encrypt(this.txtpassWords.Value.ToString().Trim()));
            string ValidUrl = "ValidSuccessGov.aspx?email=" + encryEmail + "&logname=" + encryLogname + "&act=" + act + "&PassWord=" + strPass;
        }
    } 
    #endregion

    #region 中介机构
    private void Intermediary()
    {
        
        //注册信息
        SHA1 sha1 = SHA1.Create();
        byte[] passWord2 = sha1.ComputeHash(Encoding.Unicode.GetBytes(this.txtpassWords.Value.ToString().Trim()));

        LoginInfoModel model = new LoginInfoModel();

        if (Request.Cookies["adv_cpa"] != null)
        {
            HttpCookie logCook = Request.Cookies["adv_cpa"];
            model.adsiteID = logCook.Value.ToString().Trim();

            model.autoReg = 2;
        }

        model.LoginName = this.txtloginName.Value.ToString().Trim();
        model.Password = passWord2;
        model.NickName = "";

        model.RoleName = "0";//会员
        model.ManageTypeID = "2004";
        model.MemberGradeID = "1001";
        model.IsCheckUp = false;
        model.Email = this.txtemail.Value.ToString().Trim();
        string phone = txtCount.Value.ToString().Trim() + "-" + txtStatCount.Value.ToString().Trim() + "-" + txtTel.Value.ToString().Trim();
        model.Tel = phone;
        model.CompanyName = "";
        model.PropertyID = 0;

        //--------会员信息
        MemberInfoModel memberModel = new MemberInfoModel();
        memberModel.LoginName = this.txtloginName.Value.ToString().Trim();
        memberModel.ManageTypeID = "2004";
        memberModel.NickName = "";
        memberModel.Email = this.txtemail.Value.ToString().Trim();
        memberModel.Tel = phone;
        //memberModel.RequirInfo = intent;
        memberModel.Mobile = txtMoblie.Value.ToString().Trim();     //手机
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


            string encryEmail = Server.UrlEncode(DEncrypt.Encrypt(this.txtemail.Value.ToString().Trim()));
            string encryLogname = Server.UrlEncode(DEncrypt.Encrypt(this.txtloginName.Value.ToString().Trim()));
            string act = Server.UrlEncode(DEncrypt.Encrypt("register"));
            string strPass = Server.UrlEncode(DEncrypt.Encrypt(this.txtpassWords.Value.ToString().Trim()));
            string ValidUrl = "ValidSuccessGov.aspx?email=" + encryEmail + "&logname=" + encryLogname + "&act=" + act + "&PassWord=" + strPass;

            Response.Redirect(ValidUrl, true);
        }
        catch (Exception exp)
        {
            //Tz888.Common.MessageBox.ShowBack(exp.Message.ToString());
            Tz888.Common.MessageBox.ShowBack("数据提交时出错，注册失败。");
        }
        finally
        {
            string encryEmail = Server.UrlEncode(DEncrypt.Encrypt(this.txtemail.Value.ToString().Trim()));
            string encryLogname = Server.UrlEncode(DEncrypt.Encrypt(this.txtloginName.Value.ToString().Trim()));
            string act = Server.UrlEncode(DEncrypt.Encrypt("register"));
            string strPass = Server.UrlEncode(DEncrypt.Encrypt(this.txtpassWords.Value.ToString().Trim()));
            string ValidUrl = "ValidSuccessGov.aspx?email=" + encryEmail + "&logname=" + encryLogname + "&act=" + act + "&PassWord=" + strPass;

            Response.Redirect(ValidUrl, true);
        }

    } 
    #endregion





    protected void imgbtnSave_Click(object sender, ImageClickEventArgs e)
    {
        if (txtloginName.Value.Trim() == "")
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('请输入用户名');", true);
            return;
        }
        if (txtemail.Value.Trim() == "")
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('请输入用户名');", true);
            return;
        }
        if (txtpassword.Value.Trim() == "")
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('请输入密码');", true);
            return;
        }
        if (txtpassWords.Value.Trim() == "")
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('请输入确认密码');", true);
            return;
        }
        if (txtyanzheng.Value.Trim()=="")
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('请输入验证码');", true);
            return;
        }


    #region 根据选择的类型调用方法
		
       if(str=="GOV")
       {Merchant();}//招商
         if(str=="PRO")
       { ProjectInfo();}//项目方
          if(str=="INV")
       {Investors();}//投资方
          if(str=="SER")
       {jigou(); }//专业服务机构
          if(str=="SEROWNER")
       { Jgrc(); }//专业服务几个（个人）
          if(str=="INT")
          { Intermediary(); }//中介机构
       
	#endregion

           
   
  }

 
}
