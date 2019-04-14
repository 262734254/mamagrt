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
using System.Net;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Data.SqlClient;
using Tz888.BLL.Login;
using Tz888.BLL.Common;
using System.Collections.Generic;
using AdSystem;

public partial class autoRegCenter : System.Web.UI.Page
{
    protected string welusername = "";
    protected string welpwd = "";
    protected string welMessage = "";
    protected string welUrl = "";
    protected string sitekey = "";
    protected string infoid = "";
    protected string loginname = "";
    protected string checklogin = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        int siteid = Convert.ToInt32(Request.QueryString["siteID"]);
        int userID = Convert.ToInt32(Request.QueryString["uid"]);
        int infoID = Convert.ToInt32(Request.QueryString["path"]);

        //int siteid = 948;
        //int userID = 1204;
        //int infoID = 1132461;

        insertUserInfo(userID, siteid, infoID);
    }

    protected void insertUserInfo(int userID, int siteID, int infoID)
    {
        //根据infoID返回注册完要跳转到的url

        DataTable dtHtml = getHtmlFile(infoID);
        string redUrl = "";
        if (dtHtml.Rows.Count == 0)
        {
            redUrl = "http://www.topfo.com";
        }
        else
        {
            redUrl = "http://www.topfo.com/" + dtHtml.Rows[0]["HtmlFile"].ToString();
        }
        //根据siteid返回用户接口地址
        DataTable dt = getUserInter(siteID);

        string interUrl = "";
        if (Convert.ToInt32(dt.Rows[0]["datatype"]) == 1)//联盟成员没有提交返回用户数据库接口
        {
            //判断ad_lmuser表中是否存在此用户数据
            DataTable dtlmuser = getlmuser(siteID, userID);
            if (dt.Rows.Count > 0)//已存在,直接跳到资源页
            {
                Response.Redirect(redUrl, true);
            }
            else//不存的时将数据插入ad_lmuser表
            {
                Hashtable htlmuser = new Hashtable();
                htlmuser.Add("siteid", siteID);
                htlmuser.Add("userid", userID);
                Insert("ad_lmuser", htlmuser);
                //插入完成后跳转到资源页
                Response.Redirect(redUrl, true);
            }
        }
        if (dt.Rows[0]["interface"].ToString() != "")
        {
            interUrl = dt.Rows[0]["interface"].ToString();
        }
        else
        {
            Response.Redirect(redUrl, true);
        }
        string urlstr = "http://" + interUrl + "?uid=" + userID;
        string userInfo = "";
        if (userID == 0)//判断用户是否为注册用户
        {
            checklogin = "0";
            Response.Redirect(redUrl, true);
        }
        else
        {
            checklogin = "1";
            userInfo = getUserInfo(urlstr);
        }
        if (userInfo == "")
        {
            Response.Redirect(redUrl, true);
        }
        userInfo = userInfo.Remove(0, userInfo.IndexOf("value=\'") + 7);//<item value='name|email|tel|qq|msn'></item>
        userInfo = userInfo.Remove(userInfo.IndexOf("</item>"));
        string[] userInfoList = userInfo.Split(new char[] { '|' });

        string nameExt = "_" + siteID.ToString() + "_hg"; //getRendom(4);
        string uLoginName = userInfoList[0].ToString().Trim() + nameExt;
        string psd = userInfoList[0].ToString().Trim() + nameExt;
        SHA1 sha1 = SHA1.Create();
        byte[] password = sha1.ComputeHash(Encoding.Unicode.GetBytes(psd));
        //判断用户是否注册
        string userName = userInfoList[0].ToString();
        string userNameAuto = "";
        //DataTable dt1 = bll.getUserLoginName(userName);
        DataTable dt1 = getUserLoginName(uLoginName);

        //取得原始网站的siteID
        if (dt1.Rows.Count != 0)
        {
            userNameAuto = dt1.Rows[0]["LoginName"].ToString();
        }
        if (dt1.Rows.Count == 0) //(userName != userNameAuto)
        {
            #region //将用户资料注册到数据库

            //logininfotab params
            SqlParameter[] paras ={
                    new SqlParameter("@LoginName", SqlDbType.Char),
                    new SqlParameter("@PassWord", SqlDbType.VarBinary),
                    new SqlParameter("@RoleName", SqlDbType.Char),
                    new SqlParameter("@IsCheckUp", SqlDbType.Bit),
                    new SqlParameter("@MemberGradeID", SqlDbType.Char),
                    new SqlParameter("@NickName", SqlDbType.VarChar),
                    new SqlParameter("@Tel", SqlDbType.VarChar),
                    new SqlParameter("@Email", SqlDbType.VarChar),
                    new SqlParameter("@RequirInfo", SqlDbType.Char),
                    new SqlParameter("@ManageTypeID", SqlDbType.Char),
                    new SqlParameter("@companyname", SqlDbType.VarChar),
                    new SqlParameter("@contactname", SqlDbType.VarChar),
                    new SqlParameter("@contacttitle", SqlDbType.VarChar),
                    new SqlParameter("@propertyid", SqlDbType.TinyInt),
                    new SqlParameter("@autoReg",SqlDbType.Bit),
                    new SqlParameter("@siteID",SqlDbType.VarChar)};

            paras[0].Value = uLoginName.Trim();
            paras[1].Value = password;
            paras[2].Value = "0";
            paras[3].Value = 1;
            paras[4].Value = "1001";
            paras[5].Value = uLoginName.Trim();
            paras[6].Value = userInfoList[2].ToString();
            paras[7].Value = userInfoList[1].ToString();
            paras[8].Value = "testing";
            paras[9].Value = "2003";
            paras[10].Value = "testing";
            paras[11].Value = "testing";
            paras[12].Value = "testing";
            paras[13].Value = 1;
            paras[14].Value = 1;
            paras[15].Value = siteID.ToString();

            logininfotab_insert(paras);

            //memberinfotab params
            SqlParameter[] paras_member ={
                    new SqlParameter("@MemberID", SqlDbType.Int),
                    new SqlParameter("@LoginName", SqlDbType.Char),
                    new SqlParameter("@MemberName", SqlDbType.VarChar),
                    new SqlParameter("@Sex", SqlDbType.Bit),
                    new SqlParameter("@NickName", SqlDbType.VarChar),
                    new SqlParameter("@Birthday", SqlDbType.DateTime),
                    new SqlParameter("@CertificateID", SqlDbType.Char),
                    new SqlParameter("@CertificateNumber", SqlDbType.VarChar),
                    new SqlParameter("@CountryCode", SqlDbType.Char),
                    new SqlParameter("@ProvinceID", SqlDbType.Char),
                    new SqlParameter("@CityID", SqlDbType.Char),
                    new SqlParameter("@CountyID", SqlDbType.Char),
                    new SqlParameter("@Address", SqlDbType.VarChar),
                    new SqlParameter("@PostCode", SqlDbType.Char),
                    new SqlParameter("@Tel", SqlDbType.VarChar),
                    new SqlParameter("@Mobile", SqlDbType.VarChar),
                    new SqlParameter("@FAX", SqlDbType.VarChar),
                    new SqlParameter("@Email", SqlDbType.VarChar),
                    new SqlParameter("@IsSecurity", SqlDbType.Bit),
                    new SqlParameter("@ManageTypeID", SqlDbType.Char),
                    new SqlParameter("@RequirInfo", SqlDbType.Char),
                    new SqlParameter("@RequirInfoDesc", SqlDbType.VarChar),
                    new SqlParameter("@HeadPortrait", SqlDbType.VarChar),
                    new SqlParameter("@ContactName",SqlDbType.VarChar),
                    new SqlParameter("@contacttitle", SqlDbType.VarChar)};

            paras_member[0].Direction = ParameterDirection.Output;
            paras_member[1].Value = uLoginName.Trim();
            paras_member[2].Value = uLoginName.Trim();
            paras_member[3].Value = 1;
            paras_member[4].Value = uLoginName.Trim();
            paras_member[5].Value = DateTime.Now;
            paras_member[6].Value = "1001";
            paras_member[7].Value = "0";
            paras_member[8].Value = "CN";
            paras_member[9].Value = "1098";
            paras_member[10].Value = "1100";
            paras_member[11].Value = "1100";
            paras_member[12].Value = "0";
            paras_member[13].Value = "000000";
            paras_member[14].Value = userInfoList[2].ToString();
            paras_member[15].Value = "0";
            paras_member[16].Value = "";
            paras_member[17].Value = userInfoList[1].ToString();
            paras_member[18].Value = 0;
            paras_member[19].Value = "2003";
            paras_member[20].Value = "";
            paras_member[21].Value = "";
            paras_member[22].Value = "";
            paras_member[23].Value = "testing";
            paras_member[24].Value = "testing";

            memberinfotab_insert(paras_member);

            //返回刚插入的ID
            DataTable dtnew = getNewLoginID();
            string userLoginID = dtnew.Rows[0]["LoginID"].ToString();
            string userLoginName = dtnew.Rows[0]["LoginName"].ToString();

            //将用户数据插入到adinfohitstab表
            Hashtable htadinfo = new Hashtable();
            htadinfo.Add("infoid", infoID);
            htadinfo.Add("loginname", "'" + userLoginName + "'");
            Insert("adinfohitstab", htadinfo);
            #endregion

            //注册完成写入cookie(登录)

            loginname = userLoginName;
            sitekey = dt.Rows[0]["SiteKey"].ToString();
            infoid = infoID.ToString();

            //AdSystem.Logic loc = new Logic();
            //loc.setCookie(sitekey.Trim(), infoid.ToString());

            HttpCookie Cook = new HttpCookie("AdSystem");
            Cook["SiteKey"] = sitekey.Trim();
            Cook["InfoID"] = infoid.ToString();
            Cook["ClickT"] = "hugaoAd";
            Cook.Domain = ".topfo.com";
            Response.SetCookie(Cook);


            //Response.Write("<script language=JavaScript> alert('" + sitekey.Trim()+infoid.ToString() + "'); </script>");

            ////alter by 20100322
            //AdSystem.Logic ads = new Logic();
            //ads.setCookie(sitekey, infoid);
            try
            {
                DoLogin(uLoginName.Trim(), uLoginName.Trim());
            }
            catch (Exception ex) { throw (ex); }
            //确定页面要显示的信息
            welMessage = "恭喜你在中国招商投资网注册成功！请记住您的用户名和密码。";
            welusername = uLoginName.Trim();
            welpwd = psd;
        }
        else
        {
            loginname = dt1.Rows[0]["LoginName"].ToString();
            sitekey = dt.Rows[0]["SiteKey"].ToString();
            infoid = infoID.ToString();

            //AdSystem.Logic loc = new Logic();
            //loc.setCookie(sitekey.Trim(), infoid.ToString());

            HttpCookie Cook = new HttpCookie("AdSystem");
            Cook["SiteKey"] = sitekey.Trim();
            Cook["InfoID"] = infoid.ToString();
            Cook["ClickT"] = "hugaoAd";
            Cook.Domain = ".topfo.com";
            Response.SetCookie(Cook);

            //Response.Write("<script language=JavaScript> alert('" + sitekey.Trim() + infoid.ToString() + "'); </script>");

            //将用户数据插入到adinfohitstab表
            Hashtable htadinfo = new Hashtable();
            htadinfo.Add("infoid", infoID);
            htadinfo.Add("loginname", "'" + dt1.Rows[0]["LoginName"].ToString() + "'");
            Insert("adinfohitstab", htadinfo);

            try
            {
                DoLogin(loginname.Trim(), loginname.Trim());
            }
            catch (Exception ex) { throw (ex); }

            welMessage = "欢迎再次来到中国招商投资网。";
            welusername = dt1.Rows[0]["LoginName"].ToString();
            welpwd = "************";
        }

        welUrl = redUrl;
        //操作完跳转
        // Response.Write("<script language=JavaScript> location.href('" + redUrl + "'); </script>");
    }


    #region //登录
    private void DoLogin(string strLoginName, string strPassword)
    {
        int AuthenticationTickeTime = Convert.ToInt32(Common.GetAuthenticationTickeTime());
        string strRoleName = "";

        #region //会员登录

        //验证用户名与密码是否正确
        int ErrorID = 0;
        string ErrorMsg = "";
        LoginInfoBLL loginRule = new LoginInfoBLL();
        DataTable dt = new DataTable();

        dt = loginRule.Authenticate(
            strLoginName,
            0,
            strPassword,
            false,
            ref ErrorID,
            ref ErrorMsg);
        if (ErrorID != 0)
        {
            return;
        }
        if (dt.Rows.Count > 0)
        {
            strRoleName = dt.Rows[0]["RoleName"].ToString().Trim();
        }
        if ((dt.Rows.Count > 0) && (strRoleName == "0")) //
        {
            InsertLoginLog(strLoginName, strRoleName);

            //写登陆cookie开始
            HttpCookie loginedUser = new HttpCookie("loginedUser");
            loginedUser.Expires = DateTime.Now.AddDays(1);
            loginedUser.Value = strLoginName;
            Response.Cookies.Add(loginedUser);
            //写登陆cookie结束

            Tz888.BLL.Login.LoginInfoBLL.Logout();
            //BBS登录
            Tz888DZLogin.BBSLogin(dt.Rows[0]["NickName"].ToString().Trim(), strPassword.Trim(), dt.Rows[0]["email"].ToString().Trim());
            //分配验证票,同时建立角色信息		
            LoginInfoBLL.SetUserFormsCookie(strLoginName, dt.Rows[0]["MemberGradeID"].ToString().Trim(), dt.Rows[0]["ManageTypeID"].ToString().Trim(), true);
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
        }

        #endregion

    }
    //插入登录日志
    private void InsertLoginLog(string strLoginName, string strRoleName)
    {
        DateTime dtLoginTime = DateTime.Now;
        string strLoginIP = Request.UserHostAddress;
        LoginInfoBLL loginRule = new LoginInfoBLL();
        loginRule.CreateLoginLog(strLoginName, strRoleName, dtLoginTime, strLoginIP);

    }
    //插入登录失败日志
    private void CreateLoginErrorLog(string strLoginName)
    {
        DateTime dtLoginTime = DateTime.Now;
        string strLoginIP = Request.UserHostAddress;
        LoginInfoBLL loginRule = new LoginInfoBLL();
        loginRule.CreateLoginErrorLog(strLoginName, dtLoginTime, strLoginIP, true);
    }
    #endregion


    #region 页面其他方法

    protected string getUserInfo(string urlstr)//读取xml页的内容
    {
        WebRequest req = WebRequest.Create(urlstr);
        req.ContentType = "";
        WebResponse rep = req.GetResponse();
        StreamReader streader = new StreamReader(rep.GetResponseStream(), Encoding.Default);
        string str = streader.ReadToEnd();

        return str;
    }

    protected string getRendom(int len)
    {
        string str = "0,1,2,3,4,5,6,7,8,9,";
        str += "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z";

        string[] S = str.Split(new char[] { ',' });//将字符串拆分成字符串数组   
        string strNum = "";

        int tag = -1;//用于记录一个随机数的值，避免产生两个重复的值   
        int i;
        Random rnd = new Random();

        for (i = 1; i <= len; i++)
        {
            //if (tag == -1)   
            //{   
            //    rnd = new Random(i * tag * unchecked((int)DateTime.Now.Ticks));
            //}   
            int rndNum = rnd.Next(36);//返回小于61的随机数   
            ////加入生成相同的数则重新生成。   
            //if (tag != -1&&tag==rndNum)   
            //{
            //    return getRendom(1);   
            //}   
            //tag = rndNum;   
            strNum += S[rndNum];
        }
        return strNum;
    }

    #endregion


    #region //页面的数据操作

    public void logininfotab_insert(SqlParameter[] Paras)
    {
        RunProcGetNone("adsUnion_LoginInfoTab_add", Paras);
    }

    public DataTable getNewLoginID()
    {
        string sql = "select top 1 loginid,loginname from logininfotab order by loginid desc";
        DataSet ds = new DataSet();
        ds = GetDataSet(sql);
        return ds.Tables[0];
    }

    public DataTable getUserInter(int siteID)//返回用户提交接口的地址
    {
        string sql = "select siteid,interface,datatype,SiteKey from ad_site where siteid=" + siteID;
        DataSet ds = new DataSet();
        ds = GetDataSet(sql);
        return ds.Tables[0];
    }

    public DataTable getlmuser(int siteid, int userid)//根据网站ID和用户ID查找
    {
        string sql = "select * from ad_lmuser where siteid=" + siteid + " and userid=" + userid + "";
        DataSet ds = new DataSet();
        ds = GetDataSet(sql);
        return ds.Tables[0];
    }

    public DataTable getHtmlFile(int infoID)
    {
        string sql = "select InfoID,HtmlFile from MainInfoTab where InfoID=" + infoID;
        DataSet ds = new DataSet();
        ds = GetDataSet(sql);
        return ds.Tables[0];
    }

    public void memberinfotab_insert(SqlParameter[] Paras)
    {
        RunProcGetNone("MemberInfoTab_Insert", Paras);
    }

    public DataSet GetDataSet(String SqlString)
    {
        SqlConnection dbconn = CreateConnection();
        dbconn.Open();
        SqlDataAdapter adapter = new SqlDataAdapter(SqlString, dbconn);
        DataSet dataset = new DataSet();
        adapter.Fill(dataset);
        dbconn.Close();
        return dataset;
    }

    public DataTable getUserLoginName(string loginName)
    {
        string sql = "select LoginID,LoginName,registertime from logininfotab where loginname='" + loginName + "' and autoreg=1";
        DataSet ds = new DataSet();
        ds = GetDataSet(sql);
        return ds.Tables[0];
    }

    //open database
    public static SqlConnection CreateConnection()
    {
        return new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConnString1"].ConnectionString);
    }

    public void RunProcGetNone(string ProcName, SqlParameter[] Params)
    {
        SqlCommand cmd = CreateCommand(ProcName, Params);
        cmd.ExecuteNonQuery();
    }

    public bool Insert(String TableName, Hashtable Cols)
    {
        int Count = 0;
        if (Cols.Count <= 0)
        {
            return true;
        }
        String Fields = " (";
        String Values = " Values(";
        foreach (DictionaryEntry item in Cols)
        {
            if (Count != 0)
            {
                Fields += ",";
                Values += ",";
            }
            Fields += item.Key.ToString();
            Values += item.Value.ToString();
            Count++;
        }
        Fields += ")";
        Values += ")";
        String SqlString = "Insert into " + TableName + Fields + Values;
        return Convert.ToBoolean(ExecuteSQL(SqlString));
    }

    public int ExecuteSQL(String SqlString)
    {
        int count = -1;
        SqlConnection dbconn = CreateConnection();
        dbconn.Open();
        try
        {
            SqlCommand cmd = new SqlCommand(SqlString, dbconn);
            count = cmd.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            count = -1;
        }
        finally
        {
            dbconn.Close();
        }
        return count;
    }

    private SqlCommand CreateCommand(string procName, SqlParameter[] Prams)
    {
        SqlConnection dbConn = CreateConnection();
        dbConn.Open();
        SqlCommand cmd = new SqlCommand(procName, dbConn);
        cmd.CommandType = CommandType.StoredProcedure;
        if (Prams != null)
        {
            foreach (SqlParameter Parameter in Prams)
            {
                cmd.Parameters.Add(Parameter);
            }
        }
        return cmd;
    }

    #endregion

}