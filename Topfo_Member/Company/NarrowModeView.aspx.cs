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

public partial class Company_NarrowModeView : System.Web.UI.Page
{
    Tz888.BLL.Company.CompanyMadeBLL company = new Tz888.BLL.Company.CompanyMadeBLL();
    Tz888.BLL.Company.NarrowAdInfoBLL na = new Tz888.BLL.Company.NarrowAdInfoBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Page.User.Identity.Name))
        {
            Response.Redirect("/login.aspx?url=" + Page.Request.Url.ToString());
        }
        if (!IsPostBack)
        {
            dataBind();
            if (Convert.ToInt32(Request["AdID"]) != 0)
            {
                int id = Convert.ToInt32(Request["AdID"]);
                NaDelete(id);
            }
        }
    }
    private void NaDelete(int id)
    {
        int num = na.Delete(id);
        if (num == 0)
        {
            Tz888.Common.MessageBox.Show(this.Page, "删除成功！");
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page,"删除失败");
        }
        dataBind();
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
        string strCriteria = "";

        strCriteria = " UserName='"+Page.User.Identity.Name+"'";
        //strCriteria = " UserName='cn001'";
        long CurrentPage = Convert.ToInt64(this.AspNetPager1.CurrentPageIndex);
        int PageNum = 20;
        long TotalCount = 1;
        long PageCount = 1;
        AspNetPager1.PageSize = PageNum;
        DataTable dt = company.GetListT("NarrowAdInfoTab", "AdID", "*", strCriteria, "CreateDate desc", ref CurrentPage, PageNum, ref TotalCount);
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

    #region 类型翻译
    protected string TypeName(string name)
    {
        string num = "";
        if (name != "")
        {
            switch (name)
            {
                case "Project":
                    num = "项目方";
                    break;
                case "Merchant":
                    num = "招商方";
                    break;
                case "Capital":
                    num = "投资方";
                    break;
            }
        }
        return num;
    }
    #endregion

    #region 将时间翻译
    protected string Time(string name)
    {
        string num = "";
        DateTime date = Convert.ToDateTime(name);
        num = date.ToString("yyyy-MM-dd");
        return num;
    }
    #endregion

    #region 将省份翻译
    protected string ProvinceName(string name)
    {
        Tz888.BLL.MeberLogin.PertinentLink per = new Tz888.BLL.MeberLogin.PertinentLink();
        string num = per.Province(name);
        return num;
    }
    #endregion
}
