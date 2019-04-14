<%@ Application Language="C#" %>

<script RunAt="server">

    void Application_Start(object sender, EventArgs e)
    {
        // 在应用程序启动时运行的代码


    }

    void Application_End(object sender, EventArgs e)
    {
        //  在应用程序关闭时运行的代码


    }

    void Application_Error(object sender, EventArgs e)
    {
        #region 程序错误处理
        //bool IsDisposeError = Tz888.Common.ConfigHelper.GetConfigBool("IsDisposeError");
        //if (!IsDisposeError)
        //    return;
        //Exception ex = Server.GetLastError();
        //bool LogInFile = bool.Parse(Tz888.Common.ConfigHelper.GetConfigString("LogInFile"));
        //bool LogInDB = bool.Parse(Tz888.Common.ConfigHelper.GetConfigString("LogInDB"));
        //string errmsg = "";
        //string Particular = "";
        //if (ex.InnerException != null)
        //{
        //    errmsg = ex.InnerException.Message;
        //    Particular = ex.InnerException.StackTrace;
        //}
        //else
        //{
        //    errmsg = ex.Message;
        //    Particular = ex.StackTrace;
        //}
        //if (LogInFile)
        //{
        //    string filename = Server.MapPath("~/ErrorMessage.txt");
        //    string strTime = DateTime.Now.ToString();
        //    System.IO.StreamWriter sw = new System.IO.StreamWriter(filename, true);
        //    sw.WriteLine(strTime + ":" + errmsg);
        //    //sw.WriteLine(Particular);
        //    sw.Close();
        //}
        //if (LogInDB)
        //{

        //}
        //Server.Transfer("~/ErrorMsg.aspx");
        #endregion
    }

    protected void Application_AuthenticateRequest(Object sender, EventArgs e)
    {

        //string sAuth = Tz888.BLL.Login.LoginInfoBLL.GetFormsTicketCookie();
        string sAuth = "";
        HttpCookie authCookieForms = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];

        if (authCookieForms != null)
        {
            FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookieForms.Value);//解密                
            sAuth = authTicket.UserData.Trim();
        }

        string[] roles = sAuth.Split(new char[] { '|' });

        if (!(HttpContext.Current.User == null))
        {
            if (HttpContext.Current.User.Identity.AuthenticationType == "Forms")
            {
                System.Web.Security.FormsIdentity id;
                id = (System.Web.Security.FormsIdentity)HttpContext.Current.User.Identity;
                HttpContext.Current.User = new System.Security.Principal.GenericPrincipal(id, roles);
            }
        }
    }

    void Session_Start(object sender, EventArgs e)
    {
        // 在新会话启动时运行的代码

    }

    void Session_End(object sender, EventArgs e)
    {
        // 在会话结束时运行的代码。 
        // 注意: 只有在 Web.config 文件中的 sessionstate 模式设置为

        // InProc 时，才会引发 Session_End 事件。如果会话模式设置为 StateServer 
        // 或 SQLServer，则不会引发该事件。
    }

    void Application_BeginRequest(Object sender, EventArgs e)
    {
        //遍历Post参数，隐藏域除外
        foreach (string i in this.Request.Form)
        {
            if (i == "__VIEWSTATE") continue;
            this.goErr(this.Request.Form[i].ToString());
        }
        //遍历Get参数。
        foreach (string i in this.Request.QueryString)
        {
            this.goErr(this.Request.QueryString[i].ToString());
        }
    }

    private void goErr(string tm)
    {
        if (SqlFilter2(tm))
        {
            this.Response.Write("非法的输入");
            this.Response.Flush();
            this.Response.End();
        }
    }

    public bool SqlFilter2(string InText)
    {
        string word = "and|exec|insert|select|delete|update|chr|mid|master|or|truncate|char|declare|join";
        if (InText == null)
            return false;
        foreach (string i in word.Split('|'))
        {
            if ((InText.ToLower().IndexOf(i + " ") > -1) || (InText.ToLower().IndexOf(" " + i) > -1))
            {
                return true;
            }
        }
        return false;
    }
       
</script>

