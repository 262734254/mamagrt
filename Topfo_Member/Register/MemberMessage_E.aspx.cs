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

public partial class Register_MemberMessage_E : System.Web.UI.Page
{
    public string LoginName = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        ///------------------------------
        ///--design by AdSystem_20090620
        ///------------------------------
        bool isBuy = false;
        string viewid = "0";
        string loginName = "";
        if (Request.QueryString["v"] != null && Request.QueryString["v"].ToString() != "")
        {
            viewid = Request.QueryString["v"].ToString().Trim();
        }
        if (Request.QueryString["LoginName"] != null && Request.QueryString["LoginName"].ToString() != "")
        {
            loginName = Request.QueryString["LoginName"].ToString().Trim();
        }
        AdSystem.Logic loc = new AdSystem.Logic();
        isBuy = loc.ViewInfo_IsBuy(Convert.ToInt64(viewid), loginName);
        if (!isBuy)
        {
            Response.Write("<script language=javascript>alert('您没有查看的权限，查询此信息需要花费1元，请先购买！');window.close();</script>");
            return;
        }


        //要传的值 ManageTypeID = 1003  LoginName
        if (Request.QueryString["LoginName"] != null)
        {
            LoginName = Request.QueryString["LoginName"].ToString();
            //注册信息        
            Tz888.BLL.Login.LoginInfoBLL obj1 = new Tz888.BLL.Login.LoginInfoBLL();
            DataTable dt1 = obj1.GetLoginInfoList("*", "LoginName='" + LoginName + "'", "LoginName");
            //登记联系人
            Tz888.BLL.Register.common obj2 = new Tz888.BLL.Register.common();
            Tz888.Model.Register.OrgContactModel model2 = new Tz888.Model.Register.OrgContactModel();
            model2 = obj2.getContactModel(LoginName);
            //会员信息表
            Tz888.Model.Register.MemberInfoModel model3 = new Tz888.Model.Register.MemberInfoModel();
            Tz888.BLL.Register.MemberInfoBLL obj3 = new Tz888.BLL.Register.MemberInfoBLL();
            model3 = obj3.GetModel("LoginName='" + LoginName + "'");
            //会员登陆信息
            Tz888.SQLServerDAL.Conn obj4 = new Tz888.SQLServerDAL.Conn();
           // DataTable dt4 = obj4.GetList("LoginLogTab", "LoginTime", "LoginTime", 10000, 1, 0, 1, "LoginName='" + LoginName + "'");
            //会员发布信息
           // DataTable dt5 = obj4.GetList("MainInfoViw", "Title,PublishT,HtmlFile", "PublishT", 1000, 1, 0, 1, "LoginName='" + LoginName + "'");
            //公司登记信息
            Tz888.BLL.Register.EnterpriseRegisterBLL obj6 = new Tz888.BLL.Register.EnterpriseRegisterBLL();
            DataTable dt6 = obj6.getEnterpriseModel( LoginName );
            //公司附加信息
            // DataTable dt7 = obj4.GetList("MemberResourceTab", "*", "LoginName", 1, 1, 0, 1, "LoginName='kittycat'");

            if (dt1 != null )
            {
                #region 信息绑定
                lbRealName.Text = dt1.Rows[0]["RealName"].ToString() == "" ? dt1.Rows[0]["NickName"].ToString() : dt1.Rows[0]["RealName"].ToString();
                lbLoginName.Text = dt1.Rows[0]["LoginName"].ToString();
                lbNickName.Text = dt1.Rows[0]["NickName"].ToString();
                lblNickName2.Text = dt1.Rows[0]["NickName"].ToString();
                HyperLink1.NavigateUrl = "http://member.topfo.com/helper/FriendManager/FriendFore.aspx?name=" + lbLoginName.Text;
                HyperLink2.NavigateUrl = "http://member.topfo.com/InnerInfo/SendView.aspx?name=" + lbNickName.Text;

                switch (dt1.Rows[0]["ManageTypeID"].ToString().Trim())
                {
                    case "1001":
                        lbManageType.Text = "个人会员";
                        break;
                    case "1003":
                        lbManageType.Text = "企业会员";
                        break;
                    case "1004":
                        lbManageType.Text = "政府会员";
                        break;
                    default:
                        break;

                }
                switch (dt1.Rows[0]["MemberGradeID"].ToString().Trim())
                {
                    case "1001":
                        GradeDiv.Visible=false;
                        break;
                    case "1002":
                        GradeDiv.Visible = true;
                        break;
                    default:
                        GradeDiv.Visible = false;
                        break;
                }
                string req = dt1.Rows[0]["RequirInfo"].ToString();
                string[] strReq = req.Split(',');
                string strRequar = "";
                for (int i = 0; i < strReq.Length; i++)
                {
                    switch (strReq[i].Trim())
                    {
                        case "1001":
                            strRequar += "政府招商 ";
                            break;
                        case "1002":
                            strRequar += "企业招商 ";
                            break;
                        case "1003":
                            strRequar += "项目融资 ";
                            break;
                        case "1004":
                            strRequar += "项目投资 ";
                            break;
                        case "1005":
                            strRequar += "创业合作 ";
                            break;
                        case "1006":
                            strRequar += "产品供求 ";
                            break;
                        default:
                            break;
                    }
                }

                lbRequar.Text = strRequar;//会员意向

                lbRegTime.Text = dt1.Rows[0]["RegisterTime"].ToString();


                if (model3 != null)
                {
                    lbSex.Text = model3.Sex ? "(女)" : "(男)";
                    imgHead.ImageUrl = model3.HeadPortrait.ToString() != "" ? ConfigurationManager.AppSettings["ImageDomain"].ToString() + "/" + model3.HeadPortrait.ToString() : "../images/MemberData/nopic.gif";
                }
               
                if (model2 != null)
                {
                    lbCareer.Text = model2.Career;
                    lbOrganizationName.Text = model2.OrganizationName != "" ? model2.OrganizationName : "暂无";

                    lbtAddress.Text = model2.address != "" ? model2.address : "暂无";

                    string tel = model2.TelCountryCode + model2.TelStateCode + model2.TelNum;
                    lbTel.Text = tel != "" ? tel : "暂无";

                    lbMoble.Text = model2.Mobile != "" ? model2.Mobile : "暂无";

                    string fax = model2.FaxCountryCode + model2.FaxStateCode + model2.FaxNum;
                    lbFax.Text = fax != "" ? fax : "暂无";

                    lbSite.Text = model2.Website != "" ? model2.Website : "暂无";
                }

                int rowCount=Convert.ToInt32(obj4.GetList("LoginLogTab", "LoginTime", "LoginTime", 1, 1, 1, 1, "LoginName='" + LoginName + "'").Rows[0][0]);

                if (rowCount > 0)
                {
                    DataTable dt4 = obj4.GetList("LoginLogTab", "LoginTime", "LoginTime", 1, 1, 0, 1, "LoginName='" + LoginName + "'");
                    lbLoginCount.Text = rowCount.ToString();
                    lbLoginB.Text = dt4.Rows[0]["LoginTime"].ToString();
                }
                else
                {
                    lbLoginCount.Text = "1";
                    lbLoginB.Text = DateTime.Now.ToShortDateString();
                }

                lbPublishCount.Text = obj4.GetList("MainInfoViw", "Title,PublishT,HtmlFile", "PublishT", 1, 1, 1, 1, "LoginName='" + LoginName + "' ").Rows[0][0].ToString();

                if (dt6 != null)
                {
                    string strMP = dt6.Rows[0]["MainProduct"].ToString();
                    string MainProduct = "";
                    if (strMP.Trim() != "")
                    {
                        MainProduct = strMP.Remove(strMP.Length - 1);
                    }
                    lbMainProduct.Text = MainProduct != "" ? MainProduct : "暂无";
                    string str = dt6.Rows[0]["Industrylist"].ToString();
                    string[] strList = str.Split(',');
                    Tz888.BLL.Common.IndustryBLL obj7 = new Tz888.BLL.Common.IndustryBLL();
                    string strIndustry = "";
                    for (int i = 0; i < strList.Length; i++)
                    {
                        if (strList[i] != "")
                        {
                            strIndustry += obj7.GetNameByID(strList[i])+" ";
                        }
                    }
                    lbIndustryModels.Text = strIndustry != "" ? strIndustry : "暂无";

                    //  2已审核(已审基本信息)，0未审核、1审核通过、3审核不通过、4退款                
                    if (dt6.Rows[0]["AuditingStatus"].ToString() == "1")
                    {
                        //查询认证信息
                        DataTable ddt6 = obj4.GetList("OrgAuditTab", "*", "AuditingDate", 1, 1, 0, 1, "LoginName='" + LoginName + "'");

                        lbAuditingStatus.Text = ddt6.Rows[0]["AuditingDate"].ToString() + "通过认证";
                    }
                    else
                    {
                        lbAuditingStatus.Text = "暂未通过认证";
                    }
                    
                   lbExhibitionHall.Text = dt6.Rows[0]["ExhibitionHall"].ToString() != "" ? "http://www." + dt6.Rows[0]["ExhibitionHall"].ToString() + ".co.tz888.cn " : "暂无";

                }
                /// 资源类型
                /// 0 -其他文档
                /// 1 -图片
                /// 2 -视频
                /// <summary>
                /// 资源性质
                /// 0 --其他
                /// 1--立项批文
                ///2--商业计划书
                ///3 --项目视频展播
                /// 附：（公司登记附件 4-8）
                ///4营业执照
                ///5税务登记证(国税)
                ///6税务登记证(地税)
                ///7荣誉和证书
                ///8其它
                if (Page.User.IsInRole("GT1001"))   //普通会员
                    spanRM.Visible = false;
                else
                {

                    DataTable dtmr4 = obj4.GetList("MemberResourceTab", "*", "LoginName", 1, 1, 0, 1, "LoginName='" + LoginName + "' AND ResourceType=4");
                    if (dtmr4 != null)
                        lbResourceType4.Text = dtmr4.Rows.Count == 0 ? "暂无" : dtmr4.Rows.Count + "张己上传";
                    else
                        lbResourceType4.Text = "暂无";
                    DataTable dtmr56 = obj4.GetList("MemberResourceTab", "*", "LoginName", 1, 1, 0, 1, "LoginName='" + LoginName + "' AND ResourceType=5 OR ResourceType=6");
                    if (dtmr56 != null)
                        lbResourceType56.Text = dtmr56.Rows.Count == 0 ? "暂无" : dtmr4.Rows.Count + "张己上传";
                    else
                        lbResourceType56.Text = "暂无";

                    DataTable dtmr7 = obj4.GetList("MemberResourceTab", "*", "LoginName", 1, 1, 0, 1, "LoginName='" + LoginName + "' AND ResourceType=7");
                    if (dtmr7 != null)
                        lbResourceType7.Text = dtmr7.Rows.Count == 0 ? "暂无" : dtmr4.Rows.Count + "张己上传";
                    else
                        lbResourceType7.Text = "暂无";
                }
              
            }

                #endregion
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "请求出错");
        }
    }
   
}
