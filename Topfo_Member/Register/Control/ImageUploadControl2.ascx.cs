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

public partial class Register_Control_ImageUploadControl2 : System.Web.UI.UserControl
{
    public string ImageDomain = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Tz888.SQLServerDAL.Conn objResource = new Tz888.SQLServerDAL.Conn();
        DataTable dtResource1 = objResource.GetList("MemberResourceTab", "*", "ResourceID", 100, 1, 0, 1, "LoginName='kittycat' AND ResourceProperty=0");

        ImageDomain = ConfigurationManager.AppSettings["ImageDomain"].ToString()+"/";

        if (dtResource1.Rows.Count > 0)
        {
            Repeater1.DataSource = dtResource1;
            Repeater1.DataBind();
        }
        else
        {
            Repeater1.Visible = false;
        }
        AjaxPro.Utility.RegisterTypeForAjax(typeof(Register_Control_ImageUploadControl2));
    }

    [AjaxPro.AjaxMethod]
    public string Delete(string InfoArrList)
    {
        //SubscribeSet dal = new SubscribeSet();
        //string[] s = InfoArrList.Split(',');
        //// bool b = dal.DeleteInfo(Convert.ToInt64(s[0].ToString()));
        //for (int i = 0; i < s.Length; i++)
        //{
        //    if (s[i].ToString() != "")
        //    {
        //        bool b = dal.DeleteInfo(Convert.ToInt64(s[i].ToString()));
        //        return "1";
        //    }
        //    else
        //    {
        //        return "0";
        //    }
        //}
        return "1";
    }
}
