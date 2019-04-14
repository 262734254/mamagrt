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
using AjaxPro;
public partial class Register_Ajax : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string yuming = Request["username"].ToString();
        if (Request["username"] != null & Request["username"] != "")
        {
            if (checkYuMing(Request["username"].ToString()) == "0")
            {
                Response.Write("1");

            }
            else
            {

                Response.Write("0");

            }
            //return;
        }
    }
    public string checkYuMing(string userName) //检测域名名是否存在
    {
        string flag = "0";
        if (userName.Trim() != "")
        {
            Tz888.BLL.Register.GovernmentRegisterBLL bll = new Tz888.BLL.Register.GovernmentRegisterBLL();
            flag =bll.YuMing(userName.Trim().ToLower())==true? "1" : "0";
        }
        return flag;
    }
}
