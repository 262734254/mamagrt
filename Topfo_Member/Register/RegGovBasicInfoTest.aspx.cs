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
using Tz888.BLL.Register;
using Tz888.Model.Register;
using Tz888.Common.DEncrypt;
using System.Security.Cryptography;
public partial class Register_RegGovBasicInfoTest : System.Web.UI.Page
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
            sdt();
        }

    }

    private void sdt()
    {
        string loginName;
        string passWord;
        string nikeName;
        string email;
        string phone;
        string zone;
        string mobile;
        string groupName;//单位名称
        string requirInfo;//意向
        string country;
        string invite;
        string tel;
        string answer;
        string question;

        loginName = this.usrname.Value;
        passWord = Request.Form["repwd"];
        nikeName = Request.Form["nikemame"];
        email = Request.Form["email"];
        tel = Request.Form["phone"];
        groupName = Request.Form["comname"];
        country = Request.Form["country"];
        zone = Request.Form["zone"];
        mobile = Request.Form["mobile"];
        requirInfo = Request.Form["coop"];
        invite = Request.Form["invite"];
        answer = Request.Form["answer"];
        question = Request.Form["question"];

        phone = country + "-" + zone + "-" + tel;


        #region 验证提交的验证码并清空验证码
        ///--------------------------------------------------
        ///--验证提交的验证码并清空验证码
        ///--------------------------------------------------
        string vercode;
        vercode = Request.Form["vercode"];
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
            model.adsiteID = logCook.Value.ToString();

            model.autoReg = 2;
        }
        model.CompanyName = this.comname.Value;
        model.LoginName = loginName;
        model.Password = passWord2;
        model.NickName = nikeName;
        model.PWDQuestion = question;
        model.PWDAnswere = answer;
        model.RoleName = "0";//会员
        model.ManageTypeID = "2001";
        model.MemberGradeID = "1001";
        model.IsCheckUp = false;
        model.Email = email;
        model.Tel = phone;
        model.RequirInfo = requirInfo;


        //----联系信息
        OrgContactModel orgModel = new OrgContactModel();
        orgModel.Email = email;         //邮箱
        orgModel.IsDel = false;
        orgModel.LoginName = loginName;  //登录名
        orgModel.Mobile = mobile;       //电话
        orgModel.Name = this.contactname.Value;  //用户真实姓名
        orgModel.OrganizationName = this.comname.Value; //招商机构名称
        orgModel.TelCountryCode = country;
        orgModel.TelNum = tel;
        orgModel.TelStateCode = zone;
        orgModel.address = this.TAddres.Value;   //通讯地址
        orgModel.PostCode = this.PpstCode.Value.ToString().Trim();//邮编

        //--------会员信息
        MemberInfoModel memberModel = new MemberInfoModel();
        memberModel.LoginName = loginName;  //登录名
        memberModel.NickName = nikeName;     //昵称
        memberModel.Email = email;          //邮箱
        memberModel.RequirInfo = requirInfo;
        memberModel.Tel = phone;                //电话
        memberModel.Mobile = mobile;         //手机
        memberModel.Birthday = DateTime.Now;   //生日
        memberModel.ContactTitle = this.contacttitle.Value.ToString().Trim(); //职位名称
        memberModel.PostCode = this.PpstCode.Value.ToString().Trim();  //邮编
        memberModel.CountryCode = this.ZoneSelectControl1.CountryID; //国别
        memberModel.ProvinceID = this.ZoneSelectControl1.ProvinceID; //省        
        memberModel.CountyID = this.ZoneSelectControl1.CountyID;    //市
        memberModel.CityID = this.ZoneSelectControl1.CityID;    //县
        memberModel.Address = this.TAddres.Value;  //地址
        memberModel.MemberName = this.contactname.Value.ToString().Trim();//用户真实姓名
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

            //论坛会员注册
            if (i > 0)
            {
                //BBS_Reg.Reg(nikeName, passWord, email);
            }
            //邀请注册
            if (invite.Trim().Length > 0)
            {
                loginfo.InviterRegiste(Request.UserHostAddress, email, invite);
            }
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
            string ValidUrl = "ValidSuccessGov.aspx?email=" + encryEmail + "&logname=" + encryLogname + "&act=" + act + "&PassWord=" + strPass;

            Response.Redirect(ValidUrl, true);
        }
        catch (Exception exp)
        {
            //Tz888.Common.MessageBox.ShowBack("数据提交时出错，注册失败。");
        }
        finally
        {
            string encryEmail = Server.UrlEncode(DEncrypt.Encrypt(email));
            string encryLogname = Server.UrlEncode(DEncrypt.Encrypt(loginName));
            string act = Server.UrlEncode(DEncrypt.Encrypt("register"));
            string strPass = Server.UrlEncode(DEncrypt.Encrypt(passWord));
            string ValidUrl = "ValidSuccessGov.aspx?email=" + encryEmail + "&logname=" + encryLogname + "&act=" + act + "&PassWord=" + strPass;
            Response.Redirect(ValidUrl, true);
        }
    }
}
