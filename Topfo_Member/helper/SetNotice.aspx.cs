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

public partial class helper_SetNotice : System.Web.UI.Page
{
    public string loginname = "";

    public string infochk = "";
    public string dzchk = "";
    public string InfoValiChk = "";
    public string memberValiChk = "";
    public string addfriendchk = "";
    public string commentchk = "";
    public string ppchk = "";
    public string buychk = "";
    public string czchk = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {        
            bind();         
        }
    }

    public void bind()
    {
        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        HtmlInputCheckBox check = new HtmlInputCheckBox();
        DataTable dt = dal.GetList("UserParametersTab", "*", "parID", 1, 1, 0, 1, "LoginName='" + Page.User.Identity.Name + "'");

        if (dt.Rows.Count > 0)
        {
            ppchk = dt.Rows[0]["InfoMatchingNotice"].ToString();//订阅
            txtEmail.Value = dt.Rows[0]["NoticeEmail"].ToString();
            txtMobile.Value = dt.Rows[0]["NoticeMobile"].ToString();
            DefaultCheck("ppchk", ppchk);
        }
    }

    /// <summary>
    /// checkbox取出默认选择
    /// </summary>
    /// <param name="clientid">控件ID前缀</param>
    /// <param name="str">设置的值</param>
    public void DefaultCheck(string clientid, string str)//默认选择
    {
        if (clientid != "" && clientid != "null" && clientid != null)
        {
            string[] s = str.Split('|');
            for (int i = 0; i < s.Length; i++) 
            {
                //ContentPlaceHolder cphDown = (ContentPlaceHolder)Master.FindControl("ContentPlaceHolder1");
                if (this.FindControl(clientid + s[i].Trim()) != null)
                {
                    HtmlInputCheckBox cb = (HtmlInputCheckBox)this.FindControl(clientid + s[i].Trim());
                    cb.Checked = true;
                }
            }
        }
    }
    /// <summary>
    /// 页面选择框的值
    /// </summary>
    /// <param name="chklist">控件</param>
    /// <returns></returns>
    public string SelectedValueString(HtmlInputCheckBox chklist)
    {
        string result = string.Empty;
        if (chklist.Value != null)
        {
            if (chklist.Checked)
            {
                result += chklist.Value + "|";
            }
        }
        return result;
    }

    protected void Button1_ServerClick(object sender, EventArgs e)
    {
        dzchk = SelectedValueString(dzchk1) + SelectedValueString(dzchk2) + SelectedValueString(dzchk3);

        Tz888.BLL.UserParameters bll = new Tz888.BLL.UserParameters();
        Tz888.Model.UserParameters model = new Tz888.Model.UserParameters();
        model.LoginName = Page.User.Identity.Name;
        model.InfoMatchingNotice = dzchk;
        model.NoticeEmail = txtEmail.Value.Trim();
        model.NoticeMobile = txtMobile.Value.Trim() ;

        bool b = bll.NoticeTypeSet(model);
        if (b)
        {
            Tz888.Common.MessageBox.Show(this.Page,"设置成功!");
            this.Hidden1.Value = "1";
            bind();         
        }
    }
}
