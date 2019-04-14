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


public partial class InnerInfo_Send2 : System.Web.UI.Page
{
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
            Response.Redirect("../Login.aspx?ReturnUrl=" + Server.UrlEncode(Request.RawUrl));
        }
        Tz888.Model.InnerInfo model = new Tz888.Model.InnerInfo();
        Tz888.BLL.InnerInfo infoBLL = new Tz888.BLL.InnerInfo();
        string userName = Page.User.Identity.Name;
        if (Request.QueryString.Count > 0)
        {
            if (Request.QueryString["SendId"] != null && Request.QueryString["SendId"] != "" && Request.QueryString["SendId"] != "%")
            {
                model = infoBLL.GetInfoContext(Convert.ToInt32(Request.QueryString["SendId"]), 1);

                this.txtReceivedMan.Text = model.ReceiveName;
                this.txtTopic.Text = model.Topic;
                this.txtContext.Text = model.Context;
            }
            if (Request.QueryString["name"] != null && Request.QueryString["name"].ToString() != "" && Request.QueryString["name"].ToString() != "%")
            {
                this.txtReceivedMan.Text = Request.QueryString["name"].ToString();
            }
        }
        //userName = "kiki";
        //好友列表
        //DataTable dt = infoBLL.getFriends(userName);


        //string strWhere = "loginName='" + userName + "'";
        //Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        //string sqlText = "select DISTINCT nickName from innerInfoContactManInfoVIW where loginName='" + userName + "' and groupId=1";
        //DataTable dt = Tz888.DBUtility.DbHelperSQL.Query(sqlText).Tables[0];

        long CurrPage = 0;
        long TotalCount = 0;
        long pageSize = 0;
        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        string strWhere = "loginName= '" + userName + "'and groupId= '1'";
        DataTable dt = dal.GetList("innerInfoContactManInfoVIW", "ContactId",
            "ContactId,nickName", strWhere, "ContactId desc", ref CurrPage, pageSize, ref TotalCount);

        this.lstFriend.DataSource = dt;
        
        if (dt != null && dt.Rows.Count > 0)
        {
            lstFriend.DataValueField = dt.Columns["ContactId"].ToString();
            lstFriend.DataTextField = dt.Columns["nickName"].ToString();
        }
        this.lstFriend.DataBind();
    }
    protected void butSend_Click(object sender, EventArgs e)
    {//发送消息
        if (txtReceivedMan.Text.Trim() == "")
        {
            return;
        }
        if (txtTopic.Text.Trim() == "")
        {
            return ;
        }
        if (txtContext.Text.Trim() == "")
        {
            return ;
        }
        bool result=false;
        Tz888.Model.InnerInfo model = new Tz888.Model.InnerInfo();
        Tz888.BLL.InnerInfo infoBLL = new Tz888.BLL.InnerInfo();
        string[] s = this.txtReceivedMan.Text.Split(',');

        model.SendName = Page.User.Identity.Name;
        //model.SendName = "kiki";
        model.Topic = this.txtTopic.Text;
        model.Context = this.txtContext.Text;
        model.InfoTime = DateTime.Now;
        model.ChangeBy = Page.User.Identity.Name;

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i].Trim() != "")
            {
                Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
                long m = 0;
                long k = 0;
                long j = 0;
                string name = s[i].Trim();
                string strWhere = "nickName='" + name + "'";
                DataTable dt = dal.GetList("loginInfoTab", "loginName", "loginName", strWhere, "loginName", ref m, k, ref j);
                if (dt == null)
                {
                    Tz888.Common.MessageBox.Show(this.Page, "收件人用户[" + name + "]不存在!");
                    return;
                }
                else
                {
                    if (dt.Rows.Count == 0)
                    {
                        Tz888.Common.MessageBox.Show(this.Page, "收件人用户[" + name + "]不存在!");
                        return;
                    }
                }
                if (dt != null && dt.Rows.Count > 0)
                {
                    model.ReceiveName = dt.Rows[0][0].ToString().Trim();
                }
                //else
                //{
                //    Tz888.Common.MessageBox.Show(this.Page, "收件人用户[" + name + "]不存在!");
                //    return;
                //}
                //model.ReceiveName = s[i];

                //SendId 自动生成 
                Tz888.BLL.GoodFriend friendBll = new Tz888.BLL.GoodFriend();
                bool bl = friendBll.IsSpecies(model.ReceiveName, Page.User.Identity.Name, 3);
                if (!bl)
                {
                    result = infoBLL.SendInfoBLL(model, this.cbIsSave.Checked);
                   Tz888.Common.MessageBox.ShowAndHref("短消息发送成功", "SendBox2.aspx");
                }
                else
                {
                    Response.Write("<script>alert('短消息发送失败！您被"+name+"加入黑名单')</script>");
                }
            }
        }
    }
}
