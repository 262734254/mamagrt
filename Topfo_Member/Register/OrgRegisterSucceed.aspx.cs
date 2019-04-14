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

public partial class Register_OrgRegisterSucceed : System.Web.UI.Page
{
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
            Response.Redirect("../Login.aspx?ReturnUrl=" + Server.UrlEncode(Request.RawUrl));

        } 
     
        string web = Request.QueryString["web"].ToString();
        string Site ="http://" +web+ "topfo.com";
        string strGT = Request.QueryString["type"].ToString();       

        if (Page.User.IsInRole("GT1001"))     //普通会员 
        {
            panel1001.Visible = true;
            panel1002.Visible = false;
            if (Page.User.IsInRole("MT1003"))//企业
            {
                Message.InnerHtml = "<br/>您的资料将在<span class='red_c1'>1个工作日内（节假日顺延）</span>被审核。审核结果通过邮件通知您，请注意查收！<br />" +
                            "您的网上展厅地址为：" + Site;
            }
            else if (Page.User.IsInRole("MT1004"))//政府
            {
                Message.InnerHtml = "<span class='cu'>重要提示：</span><br />为保证政府招商需求的真实性和严肃性，您需要将招商的委托授权书传真给我们，经确认后您的登记的信息方可发布上网！<br />" +
                    "传真号码：<span class='cheng cu'>0755-82213698</span> 咨询电话：0755-82210116 82212980<br />" +
                    "您的网上展厅地址为：" + Site + "<a href='" + Site + "'> 预览</a>";
            }
            else
            {
               
            }
          
        }
        else if (Page.User.IsInRole("GT1002") || Page.User.IsInRole("GT1003"))  //拓富通    
        {
            panel1001.Visible = false;
            panel1002.Visible = true;
            if (Page.User.IsInRole("MT1003"))//企业
            {
                Message.InnerHtml = "<br/>拓富通会员发布的信息采取<font color='red'>先发后审</font>的形式，您发布的招商机构已经上网！ 点此查看稍后我们将对您发布的信息进行例行审核，审核结果通过邮件通知您，请注意查收！";
            }
            else if (Page.User.IsInRole("MT1004"))//政府
            {
                Message.InnerHtml = "<br/>拓富通会员发布的信息采取<font color='red'>先发后审</font>的形式，您发布的招商机构已经上网！ 点此查看稍后我们将对您发布的信息进行例行审核，审核结果通过邮件通知您，请注意查收！";
            }
            else
            {
                
            }
        }
        else
        {  
          
            
        }
       
        string reg = Request.QueryString["reg"].ToString();
        switch (reg)
        {
            case "Gov_Add":
                lbOrgType.Text = "机构登记信息";
                Label1.Text = "添加";
                break;
            case "Gov_Update":
                lbOrgType.Text = "机构登记信息";
                Label1.Text = "修改";
                break;
            case "Ent_Add":
                lbOrgType.Text = "公司登记信息";
                Label1.Text = "添加";
                break;
            case "Ent_Update":
                lbOrgType.Text = "公司登记信息";
                Label1.Text = "修改";
                break;

        }
   
    }
}
