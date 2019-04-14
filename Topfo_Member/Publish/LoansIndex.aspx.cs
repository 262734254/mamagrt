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

public partial class Publish_LoansIndex : System.Web.UI.Page
{
    Tz888.BLL.LoansInfo loansinfobll = new Tz888.BLL.LoansInfo();
    Tz888.BLL.loansInfoTab loansinfotabbll = new Tz888.BLL.loansInfoTab();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindShow();
        }
    }
    public string GetBorrowingType(int BorrowingType)
    {
        string par = "";
        if (BorrowingType == 0)
        {
            par = "个人";
        }
        else { par = "企业"; }
        return par;
    }
    public string GetProvinceName(int LoansInfoID)
    {
        Tz888.Model.LoansInfo loansinfo = (Tz888.Model.LoansInfo)loansinfobll.GetLoansInfoByLoansInfoId(LoansInfoID);
        string ProvinceID = loansinfo.ProvinceID.ToString().Trim();
        string provincename= loansinfobll.GetProvinceNameByProvinceId(ProvinceID).Trim ();
        if (provincename.Trim() == "")
        {
            provincename = "中国";
        }
        return provincename;

    }
    public string GetAmountMoney(int LoansInfoID)
    {
        Tz888.Model.LoansInfo loansinfo = (Tz888.Model.LoansInfo)loansinfobll.GetLoansInfoByLoansInfoId(LoansInfoID);
        return loansinfo .Amount.ToString ();
    }
    private void BindShow()
    {
        this.gvlistLoansManager.DataSource = loansinfotabbll.GetAllInfoTab();
        this.gvlistLoansManager.DataBind();
    }
}
