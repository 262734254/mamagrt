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


public partial class helper_Promotionset : System.Web.UI.Page
{
    public string InfoID;
    public string[] InfoIDArrList;
    protected string loginname = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.User.Identity.Name == null || Page.User.Identity.Name.Trim() == "")
        {
            Response.Redirect("../Login.aspx");
        }
        loginname = Page.User.Identity.Name;
        //loginname = "topfo001";
        if (Request.QueryString["InfoID"] != null && Request.QueryString["InfoID"].Trim() != "")
        {
            InfoID = Request.QueryString["InfoID"].Trim();
            InfoIDArrList = InfoID.Split(',');
        }
        else
        {
            //InfoID = "173169";
            //InfoIDArrList = InfoID.Split(',');
            Tz888.Common.MessageBox.ResponseScript(this.Page, "window.close();");
        }
        if (!Page.IsPostBack)
        {
            //bind();
        }
    }
    public void bind()
    {
        if (InfoIDArrList.Length == 1 || InfoIDArrList.Length == 2)
        {
            Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
            DataTable dt = dal.GetList("SubscribeSetTab", "*", "ID", 1, 1, 0, 1, "LoginName='" + loginname + "' and InfoID=" + Convert.ToInt64(InfoIDArrList[0].Trim()));
            if (dt.Rows.Count > 0)
            {
                rabGradeID.SelectedValue = dt.Rows[0]["objectGradeID"].ToString();
                //txtSendCount.Text = dt.Rows[0]["SubscribeCount"].ToString();
                if (dt.Rows[0]["objectNeed"].ToString().Trim() != "")
                {
                    string need = dt.Rows[0]["objectNeed"].ToString().Trim();
                    string strneed;
                    for (int i = 0; i < chkType.Items.Count; i++)
                    {
                        strneed = chkType.Items[i].Value;
                        if (need.IndexOf(strneed) != -1)
                            chkType.Items[i].Selected = true;
                    }
                }
                //2010-06-18
                if (dt.Rows[0]["SubscribeType"].ToString().Trim() != "")
                {
                    string[] SubscribeType = dt.Rows[0]["SubscribeType"].ToString().Split(new char[] { ',' });
                    string[] Promotioncount = dt.Rows[0]["Promotioncount"].ToString().Split(new char[] { ',' });
                    if (SubscribeType.Length > 0)
                    {
                        for (int i = 0; i < SubscribeType.Length; i++)
                        {
                            try
                            {
                                switch (SubscribeType[i].ToString())
                                {
                                    case "1": //站内短信
                                        cbkShort.Checked = true;
                                        if (Promotioncount[i] != "")
                                        {
                                            txtPromotionShortSum.Text = Promotioncount[i].ToString();
                                        }
                                        break;
                                    case "3": //手机短信
                                        cbkPhone.Checked = true;
                                        if (Promotioncount[i] != "")
                                        {
                                            txtPromotionPhoneSum.Text = Promotioncount[i].ToString();
                                        }
                                        break;
                                    default:
                                        break;
                                }
                            }
                            catch (Exception) { throw; }
                        }
                    }
                }
                //end
                //地区
                List<Tz888.Model.Info.CapitalInfoAreaModel> lists = new List<Tz888.Model.Info.CapitalInfoAreaModel>();
                string[] countrycode = dt.Rows[0]["countrycode"].ToString().Trim().Split(',');
                string[] province = dt.Rows[0]["provinceid"].ToString().Trim().Split(',');
                string[] city = dt.Rows[0]["cityid"].ToString().Trim().Split(',');
                string[] county = dt.Rows[0]["countyid"].ToString().Trim().Split(',');
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
                    this.Zone.CapitalInfoAreaModels = lists;
                }
                //行业
                //this.Industry.IndustryString = dt.Rows[0]["Industry"].ToString().Trim();
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        #region
        int phone = 0;
        int email = 0;
        if (Zone.CapitalInfoAreaModels.Count==0)
        {
            lblMsg.Text = "你选择你要推广的区域";
            Zone.CapitalInfoAreaModels.Clear();
            return;
        }
        if (chkType.SelectedValue == "")
        {
            lblMsg.Text = "请至少选择一个受众需求";
            return;
        }
        if (!cbkPhone.Checked && !cbkShort.Checked)
        {
            lblMsg1.Text = "请至少选择一个推广方式";
            return;
        }
        if (txtPromotionShortSum.Text.Trim() == "0")
        {
            lblMsg1.Text = "推广数量不能为零";
            return;
        }
        if (cbkShort.Checked && string.IsNullOrEmpty(txtPromotionShortSum.Text.Trim()))
        {
            lblMsg1.Text = "请输入你要推广的数量";
            return;
        }
        if (txtPromotionShortSum.Text.IndexOf("-") != -1)
        {
            lblMsg1.Text = "推广的数量只能为整数";
            return;
        }
        try
        {
            email = int.Parse(txtPromotionShortSum.Text.Trim());

        }
        catch (Exception) { lblMsg1.Text = "推广数量只能为整数"; return; }
        if (txtPromotionPhoneSum.Text.Trim() == "0")
        {
            lblMsg1.Text = "推广数量不能为零";
            return;
        }
        if (txtPromotionPhoneSum.Text.IndexOf("-") != -1)
        {
            lblMsg1.Text = "推广的数量只能为整数";
            return;
        }
        if (cbkPhone.Checked && string.IsNullOrEmpty(txtPromotionPhoneSum.Text.Trim()))
        {
            lblMsg1.Text = "请输入你要推广的数量";
            return;
        }
        if (!cbkPhone.Checked && txtPromotionPhoneSum.Text.Trim() != "")
        {
            lblMsg1.Text = "请选中您的推广方式";
            return;
        }
        try
        {
            if (txtPromotionPhoneSum.Text == "")
            {
                txtPromotionPhoneSum.Text = "0";
            }
            else
            {
                phone = int.Parse(txtPromotionPhoneSum.Text.Trim());
            }
        }
        catch (Exception)
        { lblMsg1.Text = "推广数量只能为整数"; return; }
        #endregion
        Tz888.BLL.SubscribeSet dal = new Tz888.BLL.SubscribeSet();
        Tz888.Model.SubscribeSet model = new Tz888.Model.SubscribeSet();
        List<Tz888.Model.Common.IndustryModel> industryModel = new List<Tz888.Model.Common.IndustryModel>(); //融资行业实体列表
        List<Tz888.Model.Info.CapitalInfoAreaModel> AreaModel = new List<Tz888.Model.Info.CapitalInfoAreaModel>();//投资区域信息实体列表

        model.LoginName = loginname;
        model.objectGradeID = rabGradeID.SelectedValue.ToString();
        string type = "";
        string matype = "";
        for (int i = 0; i < chkType.Items.Count; i++)
        {
            if (chkType.Items[i].Selected)
            {
                switch (chkType.Items[i].Value.ToString())
                {
                    case "2001"://政府招商机构
                        matype += "2001,";
                        break;
                    case "2002": //投资方
                        matype += "2002, ";
                        break;
                    case "2003"://项目方
                        matype += "2003,";
                        break;
                    case "2004"://中介机构
                        matype += "2004,";
                        break;
                    case "2006"://中介机构
                        matype += "2006,";
                        break;
                    default:
                        break;
                }
                type += chkType.Items[i].Value.ToString() + ",";
            }
        }
        model.ManageTypeId = matype;
        model.objectNeed = type;
        AreaModel = this.Zone.CapitalInfoAreaModels;
        //industryModel = this.Industry.IndustryModels;
        for (int i = 0; i < AreaModel.Count; i++)
        {
            model.CountryCode += AreaModel[i].CountryCode + ",";
            model.ProvinceID += AreaModel[i].ProvinceID + ",";
            model.CityID += AreaModel[i].CityID + ",";
            model.CountyID += AreaModel[i].CountyID + ",";
        }
        string industry = "";
        for (int j = 0; j < industryModel.Count; j++)
        {
            industry += industryModel[j].IndustryBID + ",";
        }
        model.Industry = industry;
        //2010-06-18
        if (cbkShort.Checked)
        {
            model.SubscribeType += "1,2" + ","; //站内短信
            model.Promotioncount += txtPromotionShortSum.Text.Trim() + "," + txtPromotionShortSum.Text.Trim() + ",";
        }
        else
        {
            model.SubscribeType += ","; //站内短信
            model.Promotioncount += ",";
        }
        if (cbkPhone.Checked)
        {
            model.SubscribeType += "3,"; //手机短信
            model.Promotioncount += txtPromotionPhoneSum.Text.Trim() + ",";
        }
        else
        {
            model.SubscribeType += ","; //手机短信
            model.Promotioncount += ",";
        }

        model.SubscribeCount = phone + email;
        int totalPrice = phone * 1 + email * 1;
        //end
        bool b = false;
        int id = 0;
        for (int i = 0; i < InfoIDArrList.Length; i++)
        {
            if (InfoIDArrList[i].ToString() != "")
            {
                model.InfoID = Convert.ToInt32(InfoIDArrList[i]);
                id = 0;
                b = dal.SendSet1(model, out id);
            }
        }
        if (b)
        {
            //2010-06-18新增
            Tz888.BLL.Info.MainInfoBLL bll = new Tz888.BLL.Info.MainInfoBLL();
            bll.UpdatePromotionStatu(long.Parse(InfoID), 1);
            Response.Redirect("order_item_promotion.aspx?smscount=" + Server.UrlEncode(model.SubscribeCount.ToString()) + "&price=" + totalPrice + "&Id=" + id, false);
            //Response.Redirect("http://union2.topfo.com/IndexUnion.aspx");
            //Tz888.Common.MessageBox.ResponseScript(this.Page, "alert('设置成功!'),window.close();");
        }
    }
}
