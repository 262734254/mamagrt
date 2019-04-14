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

public partial class ResourcesEvaluation : System.Web.UI.Page
{
    string InfoID = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        //判断是否已经登录
        if (string.IsNullOrEmpty(Page.User.Identity.Name))
        {
            Response.Redirect("/Login.aspx?ReturnUrl=" + Server.UrlEncode(Request.RawUrl));
        }
        if (Request.QueryString["infoid"] != null)
        {
            InfoID = Request.QueryString["infoid"].ToString();
        }

    }
    //提交资源评价信息
    protected void btSubmit_Click(object sender, EventArgs e)
    {
        //从主页面获取信息编号
        //单独调试设定默认值
        //Session["InfoID"] = "103";
        string point = "0";
        //根据编号查询主表信息
        Tz888.BLL.Info.MainInfoBLL BLL = new Tz888.BLL.Info.MainInfoBLL();
        if (InfoID != "")
        {
            if (rdPoint5.Checked == true)
            {
                point = rdPoint5.Value;
            }
            if (rdPoint4.Checked == true)
            {
                point = rdPoint4.Value;
            }
            if (rdPoint3.Checked == true)
            {
                point = rdPoint3.Value;
            }
            if (rdPoint2.Checked == true)
            {
                point = rdPoint2.Value;
            }
            if (rdPoint1.Checked == true)
            {
                point = rdPoint1.Value;
            }
            int returnValue = 0;
            try
            {
                returnValue = BLL.GetInfoMainEvaluation(long.Parse(InfoID), int.Parse(point));
            }
            catch
            {

            }
            // BLL.GetInfoBuyersCount(long.Parse(Session["InfoID"].ToString()));//
            if (returnValue > 0)
            {
                Tz888.Common.MessageBox.ShowAndRedirect(this.Page, "评价成功", "PayManage/trade_info_list.aspx");
                //Response.Write("<script>alert('评分提交成功!');</script>");
                //Response.Redirect("PayManage/trade_info_list.aspx");
            }
        }



    }
}
