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

public partial class ResourceReport : System.Web.UI.Page
{
    string InfoID = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        //本地调试时使用默认值
        //InfoID = "103";
        if (string.IsNullOrEmpty(Page.User.Identity.Name))
        {
            Response.Redirect("/Login.aspx?ReturnUrl=" + Server.UrlEncode(Request.RawUrl));
        }
        if (Request.QueryString["InfoID"] != null)
        {
            InfoID = Request.QueryString["InfoID"].ToString();
        }

        //根据InfoID获取资源标题
        //Session["Title"] = "投资壹亿美金合作建设“中国硅热法炼镁”基地";
        if (InfoID.Trim() != "")
        {
            Tz888.BLL.Info.MainInfoBLL MainInfoBLL = new Tz888.BLL.Info.MainInfoBLL();
            Tz888.Model.Info.MainInfoModel MainInfoModel = new Tz888.Model.Info.MainInfoModel();
            MainInfoModel = MainInfoBLL.GetModel(long.Parse(InfoID));
            if (MainInfoModel != null)
            {
                tbTitle.Value = MainInfoModel.Title.ToString();
            }
        }
    }
    //提交举报信息
    protected void Submit1_ServerClick(object sender, EventArgs e)
    {
        string Title = tbTitle.Value.Trim();
        string content = tbContent.Text.Trim();
        Tz888.BLL.ReportTabBLL BLL = new Tz888.BLL.ReportTabBLL();
        int returnValue = 0;
        if (InfoID != null)
        {
            try
            {
                returnValue = BLL.addReportInfo(long.Parse(InfoID), Title, content, DateTime.Now.ToShortDateString());
            }
            catch 
            {
            
            }
        }
        if (returnValue > 0)
        {
            Response.Write("<script>alert('举报提交成功!');</script>");
        }
    }
}
