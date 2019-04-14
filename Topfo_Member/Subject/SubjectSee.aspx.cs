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
using Tz888.Model.Subject;
using Tz888.BLL.Subject;

public partial class Subject_SubjectSee : System.Web.UI.Page
{
    SubjectExtendBLL subBll = new SubjectExtendBLL();
    SubjectExtendModel subModel = new SubjectExtendModel();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           MemberGrad();
            ViewState["Criteria"] = "";
            DataBind();
        }
    }

    private void MemberGrad()
    {
        if (Page.User.IsInRole("GT1001"))
        {
            pointId.InnerHtml = "<img src=http://img2.topfo.com/member/images/dingyun.jpg class=\"fl\" />"
                +"<div class=\"fbcg1-1\"><p class=\"f_14px lanl\">"
                +"您的级别不够查看访问者信息，如果您想查看信息。</p> <br />"
                +"<p class=\"f_black\">请点此<a href='#' class=\"lan1\" target=\"_blank\"> 升级VIP会员</a> 或咨询热线：0755-89805588</p></div>";
            divId.Visible = false;
        }
    }

    private void DataBind()
    {
        string strCriteria = "";

        strCriteria = " LoginName='"+Page.User.Identity.Name+"'";
        //strCriteria = " LoginName='topfo001' ";


        long CurrentPage = Convert.ToInt64(this.AspNetPager1.CurrentPageIndex);
        int PageNum = 2;
        long TotalCount = 1;
        long PageCount = 1;
        AspNetPager1.PageSize = PageNum;
        DataTable dt = subBll.GetListT("SubjectExtendTab", "SubID", "*", strCriteria, "SubID desc", ref CurrentPage, PageNum, ref TotalCount);
        if (dt != null)
        {
            this.AspNetPager1.RecordCount = Convert.ToInt32(TotalCount);
            this.dgMatching.DataSource = dt.DefaultView;

            this.dgMatching.DataBind();

            if (TotalCount % PageNum > 0)
                PageCount = TotalCount / PageNum + 1;
            else
                PageCount = TotalCount / PageNum;

            this.pinfo.InnerText = Convert.ToString(TotalCount);
        }
    }

    protected string Audit(string ad)
    {
        string num="";
        switch (ad)
        { 
            case "0":
                num = "审核中";
                break;
            case "1":
                num = "审核通过";
                break;
            case "2":
                num = "审核未通过";
                break;
        }
        return num;
    }

    #region 绑定分页
    /// <summary>
    /// 绑定分页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        DataBind();
    }
    #endregion
}
