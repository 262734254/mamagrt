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
using Tz888.BLL.Subject;

public partial class Subject_ExtendAddressSee : System.Web.UI.Page
{
    SubjectExtendBLL subBll = new SubjectExtendBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataBind();
        }
    }


    private void DataBind()
    {
        string strCriteria = "";
        int sub = Convert.ToInt32(Request["id"]);
        strCriteria = " SubID=" + sub + " ";


        long CurrentPage = Convert.ToInt64(this.AspNetPager1.CurrentPageIndex);
        int PageNum = 2;
        long TotalCount = 1;
        long PageCount = 1;
        AspNetPager1.PageSize = PageNum;
        DataTable dt = subBll.GetListT("ExtendAddressTab", "ExtendID", "*", strCriteria, "ExtendID desc", ref CurrentPage, PageNum, ref TotalCount);
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
