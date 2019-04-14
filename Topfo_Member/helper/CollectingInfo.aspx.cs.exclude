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

public partial class helper_CollectingInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.User.Identity.Name == null || Page.User.Identity.Name.Trim() == "")
        {
            Response.Redirect("../Login.aspx?ReturnUrl=" + Server.UrlEncode(Request.RawUrl));
            return;
        }

        //信息收藏
        if (Request.Params["infoid"] != null && Request.Params["infoid"].ToString() != "")
        {
            long InfoID = Convert.ToInt64(Request.Params["infoid"]);

            //查询是否己收藏此资源
            Tz888.BLL.Conn obj = new Tz888.BLL.Conn();
            DataTable dtCheck = obj.GetList("InfoViewCollectionTab", "InfoID", "InfoID", 1, 1, 0, 1, "InfoID=" + InfoID + "and  LoginName='" + Page.User.Identity.Name + "'");
            if (dtCheck.Rows.Count <= 0)
            {               
                Tz888.BLL.CollectionBLL objColl = new Tz888.BLL.CollectionBLL();
                if (objColl.InfoFavorite(InfoID, Page.User.Identity.Name))
                {
                    Response.Redirect("InfoCollection.aspx");
                }
                else
                {
                    Tz888.Common.MessageBox.ShowAndRedirect(this.Page, "收藏出错!", "InfoCollection.aspx");
                }
            }
            else
            {
                Tz888.Common.MessageBox.ShowAndRedirect(this.Page, "此信息己被收藏!", "InfoCollection.aspx");
            }

        }
        //企业机构收藏
        else if (Request.Params["ContactLoginName"] != null && Request.Params["ContactLoginName"].ToString() != "")
        {
            Tz888.Model.CollectionModel CollModel = new Tz888.Model.CollectionModel();
            Tz888.BLL.CollectionBLL CollObj = new Tz888.BLL.CollectionBLL();
            
            //查询是否己收藏此资源
            Tz888.BLL.Conn obj = new Tz888.BLL.Conn();
            DataTable dtCheck = obj.GetList("OrgCollectionTab", "ContactLoginName", "ContactLoginName", 1, 1, 0, 1, "ContactLoginName='" + Request.Params["ContactLoginName"].ToString().Trim() + "' and  LoginName='" + Page.User.Identity.Name + "'");

         //   Tz888.Common.MessageBox.Show(this.Page, dtCheck.Rows.Count.ToString());
          //  return;
            if (dtCheck.Rows.Count <= 0)
            {

                CollModel.LoginName = Page.User.Identity.Name;
                CollModel.ContactLoginName = Request.Params["ContactLoginName"].ToString().Trim();

                Tz888.BLL.Register.LoginInfoBLL objMT = new Tz888.BLL.Register.LoginInfoBLL();
                switch (objMT.GetManagerType(CollModel.ContactLoginName).Trim())
                {
                    case "企业单位":
                        Tz888.BLL.Conn obj1 = new Tz888.BLL.Conn();
                        DataTable ModelE = obj1.GetList("EnterpriseTab", "*", "EnterpriseID", 1, 1, 0, 1, "AuditingStatus=1 and LoginName='" + CollModel.ContactLoginName + "'");
                        if (ModelE != null && ModelE.Rows.Count > 0)
                        {
                            CollModel.IndustryBID = ModelE.Rows[0]["Industrylist"].ToString();
                            CollModel.CollectOrgType = Convert.ToInt32(ModelE.Rows[0]["SetComTypeID"]);
                            CollModel.CollectOrgName = ModelE.Rows[0]["EnterpriseName"].ToString();
                            CollModel.CountryCode = ModelE.Rows[0]["CountryCode"].ToString();
                            CollModel.ProvinceID = ModelE.Rows[0]["ProvinceID"].ToString();
                            CollModel.CityID = ModelE.Rows[0]["CityID"].ToString();
                            CollModel.CountyID = ModelE.Rows[0]["CountyID"].ToString();
                            //CollModel.Remrk = "http://" + ModelE.Rows[0]["ExhibitionHall"].ToString() + ".co.topfo.com";
                            System.Collections.Generic.IList<SelfCreateWeb.Model.MSelfCreateWebInfo> list = new SelfCreateWeb.BLL.BSelfCreateWebInfo().GetSelfCreateWebInfo(1, 1, new string[] { "LoginName" }, new string[] { Request.Params["ContactLoginName"].ToString().Trim() });
                            if (list.Count > 0)
                            {
                                CollModel.Remrk = "http://" + list[0].Domain.Trim() + ".co.topfo.com";
                            }
                            else
                            {
                                CollModel.Remrk = "";
                            }
                        }
                        else
                        {
                            Tz888.Common.MessageBox.ShowAndRedirect(this.Page, "此公司展厅未通过审核，不能收藏！", "OrgCollection.aspx");
                            return;
                        }
                        break;
                    case "政府机构":
                        Tz888.BLL.Conn obj2 = new Tz888.BLL.Conn();
                        string s = "AuditingStatus=1 and LoginName='" + CollModel.ContactLoginName + "'";
                        DataTable ModelG = obj2.GetList("GovernmentTab", "*", "GovernmentID", 1, 1, 0, 1, "AuditingStatus=1 and LoginName='" + CollModel.ContactLoginName + "'");
                        if (ModelG != null && ModelG.Rows.Count > 0)
                        {
                            CollModel.IndustryBID = "";
                            CollModel.CollectOrgType = Convert.ToInt32(ModelG.Rows[0]["SubjectType"]);
                            CollModel.CollectOrgName = ModelG.Rows[0]["GovernmentName"].ToString();
                            CollModel.CountryCode = ModelG.Rows[0]["CountryCode"].ToString();
                            CollModel.ProvinceID = ModelG.Rows[0]["ProvinceID"].ToString();
                            CollModel.CityID = ModelG.Rows[0]["CityID"].ToString();
                            CollModel.CountyID = ModelG.Rows[0]["CountyID"].ToString();
                            //CollModel.Remrk = "http://" + ModelG.Rows[0]["ExhibitionHall"].ToString() + ".gov.topfo.com";
                            System.Collections.Generic.IList<SelfCreateWeb.Model.MSelfCreateWebInfo> list = new SelfCreateWeb.BLL.BSelfCreateWebInfo().GetSelfCreateWebInfo(1, 1, new string[] { "LoginName" }, new string[] { Request.Params["ContactLoginName"].ToString().Trim() });
                            if (list.Count > 0)
                            {
                                CollModel.Remrk = "http://" + list[0].Domain.Trim() + ".gov.topfo.com";
                            }
                            else
                            {
                                CollModel.Remrk = "";
                            }
                        }
                        else
                        {
                            Tz888.Common.MessageBox.ShowAndRedirect(this.Page, "此机构展厅未通过审核，不能收藏！", "OrgCollection.aspx");
                            return;
                        }
                        break;
                    default:
                        Tz888.Common.MessageBox.ShowAndRedirect(this.Page, "收藏出错!", "OrgCollection.aspx");
                        return;
                        break;
                }
            }
            else
            {
                Tz888.Common.MessageBox.ShowAndRedirect(this.Page, "己有此收藏记录!", "OrgCollection.aspx");
            }
         
            Tz888.BLL.CollectionBLL objColl = new Tz888.BLL.CollectionBLL();
            if ( CollObj.InfoFavoriteOrgInsert(CollModel))
            { 
                 Response.Redirect("OrgCollection.aspx");
            }
            else
            {
                Tz888.Common.MessageBox.ShowAndRedirect(this.Page, "收藏出错!", "OrgCollection.aspx");
            }
        }
    }
}
