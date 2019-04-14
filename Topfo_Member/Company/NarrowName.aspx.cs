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

public partial class Company_NarrowName : System.Web.UI.Page
{
    Tz888.BLL.Company.CompanyMadeBLL company = new Tz888.BLL.Company.CompanyMadeBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dataBind();
        }
    }
    #region 绑定分页
    /// <summary>
    /// 绑定分页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        dataBind();
    }
    #endregion

    #region 绑定
    /// <summary>
    /// 绑定
    /// </summary>
    protected void dataBind()
    {
        int ad = Convert.ToInt32(Request["AdID"]);
        string strCriteria = "";

        strCriteria = " AdID="+ad+"";

        long CurrentPage = Convert.ToInt64(this.AspNetPager1.CurrentPageIndex);
        int PageNum = 20;
        long TotalCount = 1;
        long PageCount = 1;
        AspNetPager1.PageSize = PageNum;
        DataTable dt = company.GetListT("NarrowSearchTab", "ID", "*", strCriteria, "AdID desc", ref CurrentPage, PageNum, ref TotalCount);
        if (dt != null)
        {
            this.AspNetPager1.RecordCount = Convert.ToInt32(TotalCount);
            this.RfList.DataSource = dt.DefaultView;

            this.RfList.DataBind();

            if (TotalCount % PageNum > 0)
                PageCount = TotalCount / PageNum + 1;
            else
                PageCount = TotalCount / PageNum;

            this.pinfo.InnerText = Convert.ToString(TotalCount);
        }
    }
    #endregion

}
