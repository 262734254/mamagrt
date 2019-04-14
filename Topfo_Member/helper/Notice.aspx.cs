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

public partial class helper_Notice : System.Web.UI.Page
{
    public string loginname = "";
    protected void Page_PreInit(object sender, EventArgs e)
    {
        bool isTof = Page.User.IsInRole("GT1002");

        if (isTof)
        {
            Page.MasterPageFile = "/indexTof.master";
        }
        else
        {
            Page.MasterPageFile = "/MasterPage.master";
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.User.Identity.Name == null || Page.User.Identity.Name.Trim() == "")
        {
            Response.Redirect("../Login.aspx");
        }
        loginname = Page.User.Identity.Name;
        if (!Page.IsPostBack)
        {
            bind();
        }
    }
    
    public void defaultChk()
    {
        if (Page.User.IsInRole("GT1002"))
        {
            DefaultCheck("infocheck", "1|2|3|");
            DefaultCheck("dzchk", "1|2|3|");
            DefaultCheck("InfoValiChk", "1|2|3|");
            DefaultCheck("memberValiChk", "1|2|3|");
            DefaultCheck("addfriendchk", "1|2|3|");
            DefaultCheck("commentchk", "1|2|3|");
            DefaultCheck("rebackchk", "1|2|3|");
            DefaultCheck("czchk", "1|2|3|");
            DefaultCheck("ppchk", "1|2|3|");
            DefaultCheck("buychk", "1|2|3|");
            DefaultCheck("czchk", "1|2|3|");
        }
        else
        {
            DefaultCheck("infocheck", "1|2|");
            DefaultCheck("dzchk", "1|2|");
            DefaultCheck("InfoValiChk", "1|2|");
            DefaultCheck("memberValiChk", "1|2|");
            DefaultCheck("addfriendchk", "1|2|");
            DefaultCheck("commentchk", "1|2|");
            DefaultCheck("rebackchk", "1|2|");
            DefaultCheck("ppchk", "1|2|");
            DefaultCheck("buychk", "1|2|");
            DefaultCheck("czchk", "1|2|");
        }
    }
    public void bind()
    {
        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        HtmlInputCheckBox check = new HtmlInputCheckBox();
        DataTable dt = dal.GetList("UserParametersTab", "*", "parID", 1, 1, 0, 1, "LoginName='" + loginname + "'");

        if (dt.Rows.Count > 0)
        {
            string infocheck = dt.Rows[0]["InfoCheckNotice"].ToString();//审核通知
            string dzchk = dt.Rows[0]["SubscribeNotice"].ToString();//定制通知
            string InfoValiChk = dt.Rows[0]["InfoExpiredNotice"].ToString();//资源有效期
            string memberValiChk = dt.Rows[0]["VipExpiredNotice"].ToString();//会员有效期
            string addfriendchk = dt.Rows[0]["FriendAddNotice"].ToString();//好友添加通知
            string commentchk = dt.Rows[0]["InfoCommentNotice"].ToString();//资源留言
            string rebackchk = dt.Rows[0]["RebackNotice"].ToString();//留言回复
            string ppchk = dt.Rows[0]["InfoMatchingNotice"].ToString();//匹配通知
            string buychk = dt.Rows[0]["PayNotice"].ToString();//成功购买
            string czchk = dt.Rows[0]["StrikeNotice"].ToString();//成功充值
            txtEmail.Value = dt.Rows[0]["NoticeEmail"].ToString();
            txtMobile.Value = dt.Rows[0]["NoticeMobile"].ToString();
            DefaultCheck("infocheck", infocheck);
            DefaultCheck("dzchk", dzchk);
            DefaultCheck("InfoValiChk", InfoValiChk);
            DefaultCheck("memberValiChk", memberValiChk);
            DefaultCheck("addfriendchk", addfriendchk);
            DefaultCheck("commentchk", commentchk);
            DefaultCheck("rebackchk", rebackchk);
            DefaultCheck("ppchk", ppchk);
            DefaultCheck("buychk", buychk);
            DefaultCheck("czchk", czchk);
            lblNoticeCount.Text = dt.Rows[0]["MobileCount"].ToString();
        }
        else
        {
            defaultChk();
        }
    }
    protected void Button1_ServerClick(object sender, EventArgs e)
    {
        string infochk = SelectedValueString(infocheck1) + SelectedValueString(infocheck2) + SelectedValueString(infocheck3);
        string dzchk = SelectedValueString(dzchk1) + SelectedValueString(dzchk2) + SelectedValueString(dzchk3);
        string InfoValiChk = SelectedValueString(InfoValiChk1) + SelectedValueString(InfoValiChk2) + SelectedValueString(InfoValiChk3);
        string memberValiChk = SelectedValueString(memberValiChk1) + SelectedValueString(memberValiChk2) + SelectedValueString(memberValiChk3);
        string addfriendchk = SelectedValueString(addfriendchk1) + SelectedValueString(addfriendchk2) + SelectedValueString(addfriendchk3);
        string commentchk = SelectedValueString(commentchk1) + SelectedValueString(commentchk2) + SelectedValueString(commentchk3);
        string rebackchk = SelectedValueString(rebackchk1) + SelectedValueString(rebackchk2) + SelectedValueString(rebackchk3);
        string ppchk = SelectedValueString(ppchk1) + SelectedValueString(ppchk2) + SelectedValueString(ppchk3);
        string buychk = SelectedValueString(buychk1) + SelectedValueString(buychk2) + SelectedValueString(buychk3);
        string czchk = SelectedValueString(czchk1) + SelectedValueString(czchk2) + SelectedValueString(czchk3);

        Tz888.BLL.UserParameters bll = new Tz888.BLL.UserParameters();
        Tz888.Model.UserParameters model = new Tz888.Model.UserParameters();
        model.LoginName = loginname;
        model.InfoCheckNotice = infochk;
        model.SubscribeNotice = dzchk;
        model.InfoExpiredNotice = InfoValiChk;
        model.VipExpiredNotice = memberValiChk;
        model.FriendAddNotice = addfriendchk;
        model.InfoCommentNotice = commentchk;
        model.RebackNotice = rebackchk;
        model.PayNotice = buychk;
        model.StrikeNotice = czchk;
        model.InfoMatchingNotice = ppchk;
        model.NoticeEmail = txtEmail.Value.Trim();
        model.NoticeMobile = txtMobile.Value.Trim() ;
        bool b = bll.NoticeTypeSet(model);
        if (b)
        {
            Tz888.Common.MessageBox.Show(this.Page,"设置成功!");
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
                ContentPlaceHolder cphDown = (ContentPlaceHolder)Master.FindControl("ContentPlaceHolder1");
                if (cphDown.FindControl(clientid + s[i].Trim()) != null)
                {
                    HtmlInputCheckBox cb = (HtmlInputCheckBox)cphDown.FindControl(clientid + s[i].Trim());
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
            else
            {
                result += "|";
            }
        }
        return result;
    }
}
