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
public partial class helper_ReceivedSet : System.Web.UI.Page
{
    public string loginname = "";
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
            Response.Redirect("../Login.aspx");
        }
        loginname = Page.User.Identity.Name; //"caiyanhua"
        if (!Page.IsPostBack)
        {
            bind();
        }
    }
    public void bind()
    {
        Tz888.BLL.SubscribeSet bll = new Tz888.BLL.SubscribeSet();
        Tz888.Model.SubscribeGetSet model = bll.GetModel(loginname);
        if (model == null)
        {
            return;
        }
        string[] type = model.ReveiveType.ToString().Split(new char[] { ',' });
        for (int i = 0; i < type.Length; i++)
        {
            switch (type[i].Trim())
            {
                case "1":
                    cbkEmail.Checked = true;
                    break;
                case "3":
                    cbkMobile.Checked = true;
                    break;
                default:
                    break;
            }
        }
        Tz888.BLL.Conn dalConn = new Tz888.BLL.Conn();
        DataTable dt = dalConn.GetList("UserParametersTab", "NoticeEmail,NoticeMobile,infocheckNotice", "ParID", 1, 1, 0, 1, "LoginName='" + loginname + "'");
        if (dt.Rows.Count > 0)
        {
            ViewState["Email"] = dt.Rows[0]["NoticeEmail"].ToString();
            txtMobile.Value = dt.Rows[0]["NoticeMobile"].ToString();
        }
        int isget = model.IsGet;
        if (isget == 1)
        {
            isShow.Style.Add("display", "");

        }
        else
        {
            isShow.Style.Add("display", "none");
        }
        //rabIsGet.SelectedValue = model.IsGet.ToString();
        rabGradeID.SelectedValue = model.objectGradeID.Trim();
        string need = model.objectNeed.Trim();
        string strneed;
        for (int i = 0; i < chkNeed.Items.Count; i++)
        {
            strneed = chkNeed.Items[i].Value;
            if (need.IndexOf(strneed) != -1)
                chkNeed.Items[i].Selected = true;
        }
        //地区
        List<Tz888.Model.Info.CapitalInfoAreaModel> lists = new List<Tz888.Model.Info.CapitalInfoAreaModel>();
        string[] countrycode = model.CountryCode.Trim().Split(',');
        string[] province = model.ProvinceID.Split(',');
        string[] city = model.CityID.Trim().Split(',');
        string[] county = model.CountyID.Trim().Split(',');
        for (int i = 0; i < countrycode.Length - 1; i++)
        {
            Tz888.Model.Info.CapitalInfoAreaModel Areamodel = new Tz888.Model.Info.CapitalInfoAreaModel();
            Areamodel.CountryCode = countrycode[i].Trim();
            try { Areamodel.ProvinceID = province[i].Trim(); }
            catch { Areamodel.ProvinceID = ""; };
            try { Areamodel.CityID = city[i].Trim(); }
            catch { Areamodel.CityID = ""; }
            try { Areamodel.CountyID = county[i].Trim(); }
            catch { Areamodel.CountyID = ""; }
            lists.Add(Areamodel);
            this.ZoneControl.CapitalInfoAreaModels = lists;
        }
        //行业
        //this.IndustryControl.IndustryString = model.Industry.Trim();
        //接收方式
        string gettype = model.ReveiveType.Trim();
        string str;
        //for (int i = 0; i < chkGetType.Items.Count; i++)
        //{
        //    str = chkGetType.Items[i].Value;
        //    if (gettype.IndexOf(str) != -1)
        //        chkGetType.Items[i].Selected = true;
        //}
    }
    protected void btnEnter_ServerClick(object sender, EventArgs e)
    {
        Tz888.Model.SubscribeGetSet model = new Tz888.Model.SubscribeGetSet();
        Tz888.BLL.SubscribeSet dal = new Tz888.BLL.SubscribeSet();
        List<Tz888.Model.Common.IndustryModel> industryModel = new List<Tz888.Model.Common.IndustryModel>(); //融资行业实体列表
        List<Tz888.Model.Info.CapitalInfoAreaModel> AreaModel = new List<Tz888.Model.Info.CapitalInfoAreaModel>();//投资区域信息实体列表

        bool b = false;
        //if (isGet.Checked)
        //{
        if (chkNeed.SelectedValue == "")
        {
            lblMsg.Text = "请至少选择一个受众对象";
            return;
        }
        if (cbkMobile.Checked && txtMobile.Value=="")
        {
            Label1.Text = "手机号不能为空";
            return;
        }
        model.IsGet = 1;
        model.LoginName = loginname;
        model.objectGradeID = rabGradeID.SelectedValue;
        string needtype = "";
        for (int i = 0; i < chkNeed.Items.Count; i++)
        {
            if (chkNeed.Items[i].Selected)
            {
                needtype += chkNeed.Items[i].Value.ToString() + ",";
            }
        }
        model.objectNeed = needtype;
        AreaModel = this.ZoneControl.CapitalInfoAreaModels;
        //industryModel = this.IndustryControl.IndustryModels;
        //区域
        for (int i = 0; i < AreaModel.Count; i++)
        {
            model.CountryCode += AreaModel[i].CountryCode + ",";
            model.ProvinceID += AreaModel[i].ProvinceID + ",";
            model.CityID += AreaModel[i].CityID + ",";
            model.CountyID += AreaModel[i].CountyID + ",";
        }

        string industry = "";//行业
        for (int j = 0; j < industryModel.Count; j++)
        {
            industry += industryModel[j].IndustryBID + ",";
        }
        model.Industry = industry;
        string reveivetype = "";
        #region
        //for (int i = 0; i < chkGetType.Items.Count; i++)
        //{
        //    if (chkGetType.Items[i].Selected)
        //    {
        //        reveivetype += chkGetType.Items[i].Value.ToString() + ",";
        //    }
        //}
        #endregion
        if (cbkEmail.Checked)
        {
            reveivetype += "1,2,";
        }
        if (cbkMobile.Checked)
        {
            reveivetype += "3";
        }
        model.ReveiveType = reveivetype;//接收方式
        b = dal.ReceivedSet(model);
        if (b)
        {
            Tz888.BLL.UserParameters noticenNO = new Tz888.BLL.UserParameters();
            bool notice = noticenNO.NoticeSet(loginname, ViewState["Email"].ToString(), txtMobile.Value.Trim());
            Tz888.Common.MessageBox.ShowAndHref("设置成功!", Request.Url.ToString());
        }

    }
    //else
    //{
    //b = dal.IsReveive(Page.User.Identity.Name, 0);//设置为不接收
    //if (b)
    //{
    //    Tz888.Common.MessageBox.ShowAndHref("设置成功!", Request.Url.ToString());
    //}
}
