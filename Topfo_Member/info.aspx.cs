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
using System.Security.Cryptography;
using Tz888.Model.Register;
using Tz888.Common.DEncrypt;
using Tz888.BLL.Register;

public partial class info : System.Web.UI.Page
{
    public string keyStr;
    public string infoURL;
    public string infoTitle;
    public string manageurl;
    public string pwdurl;
    public AdSystem._DES des;
    public AdSystem.Logic loc;

    protected void Page_Load(object sender, EventArgs e)
    {
        des = new AdSystem._DES();
        loc = new AdSystem.Logic();

        infoURL = "";
        infoTitle = "";
        manageurl = "";
        pwdurl = "";

        if (!IsPostBack)
        {
            if (Request.QueryString["key"] != null && Request.QueryString["key"].ToString().Trim() != "")
            {
                keyStr = Request.QueryString["key"].ToString();
                string flag = getString(UnEscape(keyStr));
            }
            else
            {
                //string str = "sitekey=1eae257e44aa9d5b" + "&infoid=1054669" + "&validatanum=123456" + "&uid=mylove" 
                //    + "&linkman=王伟" + "&email=mylove@tz888.cn" + "&tel=122222" + "&addr=深圳";
                //string str1 = des.EncryptString(str);
                //string str2 = des.DecryptString(str1);

                //Response.Redirect("info.aspx?key=" + Escape(str1));
                return;
            }
        }
    }

    #region
    public string getString(string keystring)
    {
        #region 参数说明
        string flag = "";       //返回提示信息
        int action = 0;         //操作说明

        string sitekey = "";    //必填项，不为空，来源网站key值
        string infoid = "";     //必填项，不为空，来源用户信息
        string validatanum = "";//必填项，不为空，验证号码
        string uid = "";        //必填项，不为空，是否有重名 （siteid_uid）
        string linkman = "";    //必填项，可为空，联系人
        string email = "";      //必填项，可为空，邮箱
        string tel = "";        //必填项，可为空，电话号码
        string addr = "";       //必填项，可为空，地址
        #endregion

        #region 获取并初步判断传值 sitekey,infoid,validatanum,uid,
        keyStr = des.DecryptString(keystring.Trim());
        string[] keyArr = keyStr.Split('&');

        if (keyArr.Length >= 2 && keyArr.Length<=8)
        {
            sitekey = keyArr[0].ToString().Split('=')[1].Trim();
            infoid = keyArr[1].ToString().Split('=')[1].Trim();
            if (infoid == "" || sitekey == "" || loc.isAdInfo(infoid, sitekey)) //是否存在此来源
            {
                flag = "来源信息错误";
                return flag;
            }
            validatanum = keyArr[2].ToString().Split('=')[1].Trim();
            uid = keyArr[3].ToString().Split('=')[1].Trim();
            if (validatanum == "" || uid == "")
            {
                flag = "来源信息错误";
                return flag;
            }
            else if (loc.checkUserBySite(uid, sitekey))
            {
                flag = "来源用户已注册，登陆";
                action = 2;
            }
            else
            {
                flag = "来源用户未注册，注册并登陆";
                action = 1;
            }

            linkman = keyArr[4].ToString().Split('=')[1].Trim();
            email = keyArr[5].ToString().Split('=')[1].Trim();
            tel = keyArr[6].ToString().Split('=')[1].Trim();
            addr = keyArr[7].ToString().Split('=')[1].Trim();

            Panel1.Visible = false;
            Panel2.Visible = true;
        }
        else
        {
            flag = "无完整来源信息";
            return flag;
        }
        #endregion

        #region 资源信息绑定
        string [] infoArr = loc.getInfoByID(Convert.ToInt64(infoid));
        infoTitle = infoArr[1].ToString().Trim();
        infoURL = "http://www.topfo.com/" + infoArr[2].ToString().Trim();
        #endregion

        #region 非一次性传递资源信息，生成ws，ws获取site信息
        ////////test
        ///////   <param   name="url">WebService的http形式的地址</param>   
        ///////   <param   name="namespace">调用的WebService的命名空间</param>   
        ///////   <param   name="classname">调用的WebService的类名（不包括命名空间前缀）</param>   
        ///////   <param   name="methodname">调用的WebService的方法名</param>   
        ///////   <param   name="args">参数列表</param>  
        ////string url = "http://member.topfo.com/webservice/InfoContractDetail.asmx";
        ////object obj = new AdSystem.AutoWS().InvokeWebservice(url, "InfoContractDetail", "InfoContractDetail", "GetOtherResource", new object[] { "1053712" });
        ////Response.Write("ddd:" + obj.ToString());

        //string [] siteinfo = loc.getSiteWsInfo(sitekey);
        //string key = des.EncryptString(uid + "&" + validatanum);
        //object[] key_obj = new object[1] { };
        //key_obj[0] = key;
        //object obj = ws.InvokeWebservice(siteinfo[0], siteinfo[1], siteinfo[2], siteinfo[3], new object[] { key});
        //if (obj == null)
        //{
        //    string wsStr = obj.ToString();
        //}
        #endregion

        #region action 注册用户
        string passWord = RndNum(6);                //生成随记密码
        SHA1 sha1 = SHA1.Create();
        byte[] passWord2 = sha1.ComputeHash(Encoding.Unicode.GetBytes(passWord.Trim()));
        int retNum = 0;
        if (action == 1)                            //注册用户
        {
            uid = loc.getUserBySite(uid, sitekey);      //判断用户名是否存在，或者是否重名
            retNum = insertData(uid, passWord2, email, linkman, tel, addr, infoid, sitekey);
            InsertLoginLog(uid, "0");
        }
        #endregion

        #region action 注册用户或登陆
        if ((action == 1 || action == 2) && retNum==1)             //会员登陆
        {
            //写登陆cookie开始
            HttpCookie loginedUser = new HttpCookie("loginedUser");
            loginedUser.Expires = DateTime.Now.AddDays(1);
            loginedUser.Value = uid;
            Response.Cookies.Add(loginedUser);

            //写登陆cookie结束
            Tz888.BLL.Login.LoginInfoBLL.Logout();
            //BBS登录
            //Tz888DZLogin.BBSLogin(uid.Trim(), password1, email);
            //分配验证票,同时建立角色信息		
            //LoginInfoBLL.SetUserFormsCookie(uid, "1001", "1001", true);

            if (!(HttpContext.Current.User == null))
            {
                if (HttpContext.Current.User.Identity.AuthenticationType == "Forms")
                {
                    System.Web.Security.FormsIdentity id;
                    id = (System.Web.Security.FormsIdentity)HttpContext.Current.User.Identity;
                    String[] myRoles = new String[4];
                    myRoles[0] = "2001";
                    myRoles[1] = "2002";
                    myRoles[2] = "2003";
                    myRoles[3] = "2004";
                    HttpContext.Current.User = new System.Security.Principal.GenericPrincipal(id, myRoles);
                }
            }
            manageurl = "http://member.topfo.com/index.aspx";
            pwdurl = "http://member.topfo.com/Register/MemberPwdModify.aspx";
        }
        return flag;
        #endregion
    }
    #endregion

    #region 注册用户
    public int insertData(string loginName, byte[] passWord2, string email, string nikeName, string tel, string addr,string infoid,string sitekey)
    {
        int flag = 0;

        LoginInfoModel model = new LoginInfoModel();
        model.LoginName = loginName;
        model.Password = passWord2;
        model.NickName = nikeName;
        model.RoleName = "0";//会员
        model.ManageTypeID = "2002";
        model.MemberGradeID = "1001";
        model.IsCheckUp = false;
        model.Email = email;
        model.Tel = tel;
        model.CompanyName = addr;
        model.PropertyID = Int32.Parse("0");
        //--------会员信息
        MemberInfoModel memberModel = new MemberInfoModel();
        memberModel.LoginName = loginName;
        memberModel.ManageTypeID = "2002";
        memberModel.NickName = nikeName;
        memberModel.Email = email;
        memberModel.Tel = tel;
        memberModel.Mobile = "";
        memberModel.Birthday = DateTime.Now;

        LoginInfoBLL loginfo = new LoginInfoBLL();
        MemberInfoBLL member = new MemberInfoBLL();
        try
        {
            try
            {
                loginfo.LogInfoAdd(model);                      //向注册表写数据
                loc.AdLogin_Add2(model.LoginName.Trim(),infoid,sitekey); //向AdLoginInfoTab表写数据
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                throw (new Exception(ex.Message));
            }
            int i = member.MemberMessage_Insert(memberModel);   //会员信息
            if (i > 0)
            {
                //BBS_Reg.Reg(nikeName, "123456", email);         //论坛会员注册
                flag = 1;
            }
        }
        catch (Exception exp)
        {
            flag = -1;
            Tz888.Common.MessageBox.ShowBack("数据提交时出错，注册失败。");
        }
        return flag;
    }
    #endregion

    #region 产生随机数
    private string RndNum(int VcodeNum)
    {
        string Vchar = "0,1,2,3,4,5,6,7,8,9";

        string[] VcArray = Vchar.Split(new Char[] { ',' });
        string VNum = "";
        int temp = -1;

        Random rand = new Random();
        for (int i = 1; i < VcodeNum + 1; i++)
        {
            int valNum = rand.Next(10);
            if (temp != -1 && temp == valNum)
            {
                return RndNum(VcodeNum);
            }
            temp = valNum;
            VNum += VcArray[valNum];
        }
        return VNum;
    }
    #endregion

    #region 插入登录日志
    private void InsertLoginLog(string strLoginName, string strRoleName)
    {
        DateTime dtLoginTime = DateTime.Now;
        string strLoginIP = Request.UserHostAddress;
        Tz888.BLL.Login.LoginInfoBLL loginRule = new Tz888.BLL.Login.LoginInfoBLL();
        loginRule.CreateLoginLog(strLoginName, strRoleName, dtLoginTime, strLoginIP);
    }
    #endregion

    #region url编码
    public static string Escape(string str)
    {
        if (str == null)
            return String.Empty;

        StringBuilder sb = new StringBuilder();
        int len = str.Length;

        for (int i = 0; i < len; i++)
        {
            char c = str[i];

            //everything other than the optionally escaped chars _must_ be escaped 
            if (Char.IsLetterOrDigit(c) || c == '-' || c == '_' || c == '/' || c == '\\' || c == '.')
                sb.Append(c);
            else
                sb.Append(Uri.HexEscape(c));
        }

        return sb.ToString();
    }

    public static string UnEscape(string str)
    {
        if (str == null)
            return String.Empty;

        StringBuilder sb = new StringBuilder();
        int len = str.Length;
        int i = 0;
        while (i != len)
        {
            if (Uri.IsHexEncoding(str, i))
                sb.Append(Uri.HexUnescape(str, ref i));
            else
                sb.Append(str[i++]);
        }

        return sb.ToString();
    }
    #endregion
}
