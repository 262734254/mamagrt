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

public partial class Company_CompanyMade : System.Web.UI.Page
{
    Tz888.BLL.Company.CompanyMadeBLL Made = new Tz888.BLL.Company.CompanyMadeBLL();
    Tz888.Model.Company.CompanyMadeModel model = new Tz888.Model.Company.CompanyMadeModel();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Page.User.Identity.Name))
        {
            Response.Redirect("/login.aspx?url=" + Page.Request.Url.ToString());
        }
        if (!IsPostBack)
        {
            begTime.Value = DateTime.Now.ToString("yyyy-MM-dd");
            endTime.Value = DateTime.Now.AddMonths(1).ToString("yyyy-MM-dd");
        }
    }
    protected void btnAdd_Click(object sender, ImageClickEventArgs e)
    {
        string Index = cblIndex.SelectedValue.Trim();
        int IndexPrice = IndexName(Index);

        string Rz = cblRz.SelectedValue.Trim();
        int RzPrice = RzName(Rz);

        string Tz = cblTz.SelectedValue.Trim();
        int TzPrice = TzName(Tz);

        string Zs = cblZs.SelectedValue.Trim();
        int ZsPrice = ZsName(Zs);

        model.CompanyID = Index + "-" + Rz + "-" + Tz+"-"+Zs;
        model.Price = Convert.ToString(IndexPrice + "-" + RzPrice + "-" + TzPrice+"-"+ZsPrice);
        model.SumPrice = Convert.ToString(IndexPrice + RzPrice + TzPrice + ZsPrice);
        Session["SumPrice"] = model.SumPrice;
        model.UserName = Page.User.Identity.Name;
        model.CreateDate = DateTime.Now;
        model.BeginTime = Convert.ToDateTime(begTime.Value.Trim());
        model.EndTime = Convert.ToDateTime(endTime.Value.Trim());
        model.LinkName = LinkName.Value.Trim();
        model.TelPhone = TelPhone.Value.Trim();
        model.Email = Email.Value.Trim();
        model.Audit = 0;
        model.AuditName = "";
        model.Hit = 0;
        model.VisitHit = 0;
        int sum = Made.Add(model);
        if (sum == 1)
        {
            Tz888.Common.MessageBox.ShowAndHref("添加成功！", "PostMade.aspx");
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "添加失败！");
        }

    }

    #region 根据首页广告得出价格
    private int IndexName(string Index)
    {
        int IndexPrice = 0;
        if (Index != "")
        {
            switch (Index)
            { 
                case "A1":
                    IndexPrice = 20000;
                    break;
                case "A2":
                    IndexPrice = 8000;
                    break;
                case "A3":
                    IndexPrice = 6000;
                    break;
                case "A4":
                    IndexPrice = 8000;
                    break;
                case "A5":
                    IndexPrice = 12000;
                    break;
                case "A6":
                    IndexPrice = 5000;
                    break;
                case "A7":
                    IndexPrice = 4800;
                    break;
                case "A8":
                    IndexPrice = 3800;
                    break;
                case "A9":
                    IndexPrice = 4800;
                    break;
            }
        }
        return IndexPrice;
    }
    #endregion 

    #region 根据融资广告得出价格
    private int RzName(string rz)
    {
        int RzPrice = 0;
        if (rz != "")
        {
            switch (rz)
            { 
                case "B1":
                    RzPrice =1000;
                    break;
                case "B2":
                    RzPrice = 5000;
                    break;
                case "B3":
                    RzPrice =1000;
                    break;
                case "B4":
                    RzPrice = 2000;
                    break;
                case "B5":
                    RzPrice = 2000;
                    break;
                case "B6":
                    RzPrice = 6000;
                    break;
                case "B7":
                    RzPrice = 4800;
                    break;
            }
        }
        return RzPrice;
    }
    #endregion

    #region 根据投资广告得出价格
    private int TzName(string tz)
    {
        int TzPrice = 0;
        if (tz != "")
        {
            switch (tz)
            { 
                case "C1":
                    TzPrice = 1000;
                    break;
                case "C2":
                    TzPrice = 5000;
                    break;
                case "C3":
                    TzPrice = 1000;
                    break;
                case "C4":
                    TzPrice = 2000;
                    break;
                case "C5":
                    TzPrice = 6000;
                    break;
                case "C6":
                    TzPrice = 2000;
                    break;
                case "C7":
                    TzPrice = 4800;
                    break;
                case "C8":
                    TzPrice = 1000;
                    break;
            }
        }
        return TzPrice;
    }
    #endregion
    #region 根据招商广告得出价格
    private int ZsName(string zs)
    {
        int ZsPrice = 0;
        if (zs != "")
        {
            switch (zs)
            { 
                case "D1":
                    ZsPrice = 1000;
                    break;
                case "D2":
                    ZsPrice = 5000;
                    break;
                case "D3":
                    ZsPrice = 1000;
                    break;
                case "D4":
                    ZsPrice = 6000;
                    break;
                case "D5":
                    ZsPrice = 2000;
                    break;
                case "D6":
                    ZsPrice = 4800;
                    break;
            }
        }
        return ZsPrice;
    }
    #endregion

}
