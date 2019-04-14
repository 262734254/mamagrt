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

public partial class Register_MemberMessage_P : System.Web.UI.Page
{
    public string LoginName="";
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



        //要传的值 ManageTypeID = 1001  LoginName
        if (Request.QueryString["LoginName"] != null)
        {
           // ManageTypeID=Request.QueryString["ManageTypeID"] ;
            LoginName = Request.QueryString["LoginName"].ToString().Trim() ;
            //注册信息        
            Tz888.BLL.Login.LoginInfoBLL obj1 = new Tz888.BLL.Login.LoginInfoBLL();
            //登记联系人
            Tz888.BLL.Register.common obj2 = new Tz888.BLL.Register.common();
            Tz888.Model.Register.OrgContactModel model2 = new Tz888.Model.Register.OrgContactModel();
            //会员信息表           
            Tz888.Model.Register.MemberInfoModel model3 = new Tz888.Model.Register.MemberInfoModel();
            Tz888.BLL.Register.MemberInfoBLL obj3 = new Tz888.BLL.Register.MemberInfoBLL();
            //会员登陆信息
            Tz888.SQLServerDAL.Conn obj4 = new Tz888.SQLServerDAL.Conn();
           // DataTable dt4 = obj4.GetList("LoginLogTab", "LoginTime", "LoginTime", 1, 1, 1, 1, "LoginName='"+LoginName+"'");
            //会员发布信息
          //  DataTable dt5 = obj4.GetList("MainInfoViw", "Title,PublishT,HtmlFile", "PublishT", 1000, 1, 0, 1, "LoginName='" + LoginName + "' ");

            DataTable dt1 = obj1.GetLoginInfoList("*", "LoginName='"+LoginName+"'", "LoginName");
            model2 = obj2.getContactModel(LoginName);

            model3 = obj3.GetModel("LoginName='"+LoginName+"'");

            if (dt1.Rows.Count > 0)
            { 
                #region 信息绑定
                lbRealName.Text = dt1.Rows[0]["RealName"].ToString()=="" ? dt1.Rows[0]["NickName"].ToString() : dt1.Rows[0]["RealName"].ToString(); ;
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
                        GradeDiv.Visible = false;
                        break;
                    case "1002":
                        GradeDiv.Visible = true;
                        break;                
                    default:
                        break;
                }

                string req = dt1.Rows[0]["RequirInfo"].ToString().Trim();
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

            }

            if (model2 != null)
            {
                lbCareer.Text = model2.Career;
                lbOrganizationName.Text = model2.OrganizationName != "" ? model2.OrganizationName : "暂无";

                lbtAddress.Text = model2.address != "" ? model2.address : "暂无";
           
                lbSite.Text = model2.Website != "" ? model2.Website : "暂无";
            }

            int rowCount = Convert.ToInt32(obj4.GetList("LoginLogTab", "LoginTime", "LoginTime", 1, 1, 1, 1, "LoginName='" + LoginName + "'").Rows[0][0]);
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
            if (model3 != null)
            {
                lbSex.Text = model3.Sex ? "(女)" : "(男)";
                try
                {
                    imgHead.ImageUrl = model3.HeadPortrait.ToString() != "" ? ConfigurationManager.AppSettings["ImageDomain"].ToString() + "/" + model3.HeadPortrait.ToString() : @"../images/publish/noneimg.gif";
                }
                catch { imgHead.ImageUrl = @"../images/publish/noneimg.gif"; }
                lbTel.Text = model3.Tel;
                lbMoble.Text = model3.Mobile;
                lbFax.Text = model3.FAX;

            }
            else
            {
                imgHead.ImageUrl = @"../images/publish/noneimg.gif";
            }
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "请求出错");
        }
#endregion 
    }
    protected void ibToSendInfo_Click(object sender, ImageClickEventArgs e)
    {
        //Response.Redirect("../InnerInfo/SendInfo.aspx?ReceivedMan=" + lbLoginName.Text.Trim());
    }
    protected void ibToFriend_Click(object sender, ImageClickEventArgs e)
    {        
        //Response.Redirect("../InnerInfo/SendInfo.aspx?ReceivedMan=" + lbLoginName.Text.Trim());
    }
   
}

