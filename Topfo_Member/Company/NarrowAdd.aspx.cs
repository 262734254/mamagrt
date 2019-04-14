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
using System.Collections.Generic;
using System.Text;

public partial class Company_NarrowAdd : Tz888.Common.Pager.BasePage
{
    Tz888.BLL.Company.NarrowAdInfoBLL na = new Tz888.BLL.Company.NarrowAdInfoBLL();
    Tz888.Model.Company.NarrowAdInfoModel model = new Tz888.Model.Company.NarrowAdInfoModel();
    Tz888.Model.Company.NarrowSearchModel NaModel = new Tz888.Model.Company.NarrowSearchModel();
    private int _myPageSize = 30;
    private string _criteria;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Page.User.Identity.Name))
        {
            Response.Redirect("/login.aspx?url=" + Page.Request.Url.ToString());
        }
        if (!IsPostBack)
        {

        }
    }
    protected void btnAdd_Click(object sender, ImageClickEventArgs e)
    {
        List<Tz888.Model.Common.IndustryModel> industryModels = new List<Tz888.Model.Common.IndustryModel>();

        model.UserName = Page.User.Identity.Name;
        model.CreateDate = Convert.ToDateTime(DateTime.Now);
        model.Title = txtTitle.Value.Trim();
        model.Descript = txtDescript.Value.Trim();
        model.Url = txtUrl.Value.Trim();
        model.InfoTypeName = cblMangeType.SelectedValue.Trim();
        ViewState["TypeName"] = cblMangeType.SelectedValue.Trim();
        model.CountryCode = ZoneSelectControl1.CountryID.Trim();
        model.ProvinceID = ZoneSelectControl1.ProvinceID.Trim();
        ViewState["ProvinceID"]=model.ProvinceID;
        model.CityID = ZoneSelectControl1.CityID.Trim();
        model.CountyId = ZoneSelectControl1.CountyID;
        //industryModels = SelectIndustryControl1.IndustryModels;
        //foreach (Tz888.Model.Common.IndustryModel modellist in industryModels)
        //{
        //    model.IndustryBID += modellist.IndustryBID + ",";
        //}
        model.IndustryBID = "";
        int numAdd= na.NaAdd(model);
        ViewState["AdID"] = numAdd;
        if (numAdd != 0)
        {
            spanId.Style["display"] = "block";
            
            string TypeNameS = TypeName(Convert.ToString(ViewState["TypeName"]));
            string typeIn = "";
            if (TypeNameS != "")
            {
                if (TypeNameS == "all")
                {
                    typeIn = "ManageTypeID in('2001','2002','2003') and ProvinceID='"+ViewState["ProvinceID"].ToString().Trim()+"'";
                }
                else
                {
                    typeIn = "ManageTypeID='" + TypeNameS + "' and ProvinceID='" + ViewState["ProvinceID"].ToString().Trim() + "'";
                }
                PagerBase = this.Pager1;
                RepeaterBase = this.RfList;
                SetPagerParameters(typeIn);
     
                this.Pager1.DataBind();
            }
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "发布失败！");
        }

    }
    private void SetPagerParameters(string type)
    {

        if (ViewState["MyPageSize"] != null)
            this._myPageSize = Convert.ToInt32(ViewState["MyPageSize"]);
        else
            ViewState["MyPageSize"] = this._myPageSize;

        //if (ViewState["Criteria"] == null)
        //{
            string time = DateTime.Now.AddYears(-2).ToString();
            this._criteria = " " + type + " and RegisterTime>='" + time + "' and LoginName not in('"+Page.User.Identity.Name+"')";
            ViewState["Criteria"] = this._criteria;
       // }
       // else
           // this._criteria = ViewState["Criteria"].ToString();

        this.Pager1.PageSize = this._myPageSize;
        this.Pager1.StrWhere = this._criteria;
        this.Pager1.TableViewName = "LoginMemberView";
        this.Pager1.KeyColumn = "RegisterTime";
        this.Pager1.SelectColumns = "*";
        this.Pager1.SortColumn = "RegisterTime";
        this.Pager1.SortType = Tz888.Common.Pager.SortType.DESC;
    }

    private string TypeName(string typeID)
    {
        string num = "";
        if (typeID != "")
        {
            switch (typeID)
            { 
                case "all":
                    num = "all";
                    break;
                case "Project":
                    num = "2003";
                    break;
                case "Merchant":
                    num = "2001";
                    break;
                case "Capital":
                    num = "2002";
                    break;
            }
        }
        return num;
    }
    protected string SumName(string type)
    {
        string num = "";
        string typeID = type.Trim();
        switch (typeID)
        { 
            case "2001":
                num = "招商方";
                break;
            case "2002":
                num = "投资方";
                break;
            case "2003":
                num = "项目方";
                break;
        }
        return num;
    }
    protected string ProvinceName(string id)
    {
        Tz888.BLL.MeberLogin.PertinentLink per = new Tz888.BLL.MeberLogin.PertinentLink();
        string num = per.Province(id);
        return num;
    }
    protected void IbtSe_Click(object sender, ImageClickEventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        string[] values = Request.Form.GetValues("cbxSelect");
        foreach (string str in values)
        {
            string lgName = na.SelLoginName(Convert.ToInt32(str));
            NaModel.AdID = Convert.ToInt32(ViewState["AdID"]);
            NaModel.LoginName = lgName;
            NaModel.CreateDate = Convert.ToDateTime(DateTime.Now);
            int com = na.SearchLoginName(Convert.ToInt32(ViewState["AdID"]),lgName);
            if (com != 0)
            {
                sb.Append("添加失败：您已经窄告用户:"+lgName+"\\n");
            }
            else
            {
                int num = na.SearchAdd(NaModel);
            }
            
        }
        if (sb.ToString() != "")
        {
          //  Tz888.Common.MessageBox.Show(this.Page, sb.ToString());
            Tz888.Common.MessageBox.ShowAndHref(sb.ToString(), "PostNarrow.aspx");
        }
        else
        {
            Tz888.Common.MessageBox.ShowAndHref("窄告信息发布成功", "PostNarrow.aspx");
        }
    }
}
