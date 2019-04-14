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
using System.Data.SqlClient;
using System.Text.RegularExpressions;

using System.Net;
using System.Net.Mail;
using System.Configuration;

public partial class ValueAdd_ServiceAdd : System.Web.UI.Page
{
    public int countM;//帐户余额
    public string loginNameStr;
    public string salesman;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Page.User.Identity.Name))
        {
            Response.Redirect("/login.aspx?url=" + Page.Request.Url.ToString());
        }
        salesman = "";
        if (Request.QueryString["id"] != null && Request.QueryString["id"].ToString().Trim() != "")
        {
            string salesmanStr = Request.QueryString["id"].ToString().Trim();
            string rgStr = "^[A-Za-z0-9_-]+$";
            Regex rg = new Regex(rgStr);
            if (rg.IsMatch(salesmanStr))
            {
                salesman = salesmanStr.Length > 10 ? salesmanStr.Substring(0, 10) : salesmanStr;
                ViewState["salesman"] = salesman;
            }
        }

        if (!this.Page.IsPostBack)
        {
            databind();
        }
    }

    public void databind()
    {
        loginNameStr = Page.User.Identity.Name.Trim();
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SQLConnString1"].ToString());
        string sqlStr = "select NickName,Tel,Email,WorthPoint from logininfotab left join createcardtab on createcardtab.loginname=logininfotab.loginname "
            + " where logininfotab.loginname='" + loginNameStr + "'";
        SqlCommand com = new SqlCommand(sqlStr, con);
        try
        {
            con.Open();
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                textB_Name.Text = dr["NickName"].ToString();
                textB_Tel.Text = dr["Tel"].ToString();
                textB_Email.Text = dr["Email"].ToString();
                countM = Convert.ToInt32(dr["WorthPoint"].ToString());
            }
            con.Close();
        }
        catch
        {
            con.Close();
        }
    }

    protected void Btn_submit_Click(object sender, EventArgs e)
    {
        string typeStr = Request.Form["CB_Type"].ToString();
        string nameStr = textB_Name.Text.Trim(); //联系人姓名
        string emailStr = textB_Email.Text.Trim(); //邮箱    
        string telStr = textB_Tel.Text.Trim(); //电话号码
        string remarkStr = textB_Remark.Text.Trim(); //特殊要求
        DateTime dtime = DateTime.Now;

        if (typeStr != "")
        {
            int ret = 0;
            string[] typeArr = typeStr.Split(',');
            for (int i = 0; i < typeArr.Length; i++)
            {
                int typeid = Convert.ToInt32(typeArr[i].ToString());
                ret += insertService(typeid, nameStr, emailStr, telStr, remarkStr, dtime);
            }
            if (ret == typeArr.Length)
            {
                string bodyStr = getEmailbody(typeArr, countM.ToString(), nameStr, telStr, emailStr, dtime.ToString());
                sendEmail(emailStr.Trim(), bodyStr);
                Response.Redirect("ServiceAddOK.aspx");
            }
        }
        else
        {
            //没有选择类别
            Response.Write("<script language='javascript'>alert('您没有选择定制类别');history.go(-1);</script>");
        }
    }

    #region 添加增值服务记录
    public int insertService(int typeID, string nameStr, string emailStr, string telStr,string remarkStr,DateTime dtime)
    {
        string loginname = Page.User.Identity.Name.Trim();
        string typeName = "定向推广";   //定制的服务名称
        switch (typeID)
        {
            case 27: typeName = "定向推广"; break;
            case 28: typeName = "对口资源智能配对"; break;
            case 29: typeName = "对口资源专家推荐"; break;
            case 30: typeName = "编制商业计划书"; break;
            case 31: typeName = "电子杂志推广"; break;
            case 32: typeName = "领导专访"; break;
            case 33: typeName = "尊贵展示"; break;
            case 2: typeName = "招商投资路演"; break;
            case 34: typeName = "专题推荐"; break;
            case 1: typeName = "广告服务"; break;
            case 35: typeName = "站内互告"; break;
        }

        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SQLConnString1"].ToString());
        int ret = 0;
        try
        {
            string sqlStr = "insert serviceincrementtab(LoginName,Type,TypeName,Tile,Site,MatchNum,Remark,ApplyTime,IsDeal,Linkman,Email,Tel,SalesMan) "
            + " values ('" + loginname + "'," + typeID.ToString() + ",'" + typeName.Trim() + "','','',0,'" + remarkStr.Trim() + "',"
               + " '" + dtime.ToString() + "',0,'" + nameStr.Trim() + "','" + emailStr.Trim() + "','" + telStr.Trim() + "','" + salesman.Trim() + "'"
               + " ) ";
            SqlCommand com = new SqlCommand(sqlStr, con);

            con.Open();
            ret = com.ExecuteNonQuery();
            con.Close();
        }
        catch (SqlException ex)
        {
            con.Close();
            throw (ex);
        }
        return ret;
    }
    #endregion

    #region 获得发送邮件正文
    public string getEmailbody(string[] typeArr, string WorthPoint, string NickName, string Tel, string Email, string AddTime)
    {
        #region 邮件的模版参数 bodyTemp 和 serviceTemp
        string bodyTemp = @"<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>
<html xmlns='http://www.w3.org/1999/xhtml'>
<head>
<meta http-equiv='Content-Type' content='text/html; charset=gb2312' />
<title>您定制的增值服务成功</title>
<link href='CSS/style.css' rel='stylesheet' type='text/css' />
</head>

<body>
<table width='600' border='0' cellspacing='0' cellpadding='0' style=' line-height:25px;'>

  <tr>
    <td height='1' colspan='7' bgcolor='#999999' style=' padding-left:20px;'></td>
  </tr>
  <tr>
    <td width='1' rowspan='12' bgcolor='#999999'></td>
    <td height='30' colspan='5' bgcolor='#ffcc00'><div align='center'><span class='STYLE4'>会员<span class='STYLE3'>#LoginName#</span>增值服务定制 </span></div></td>
    <td width='1' rowspan='12' bgcolor='#999999'></td>
  </tr>
  
  <tr>
    <td height='1' colspan='5' bgcolor='#999999'></td>
  </tr>
  <tr>
    <td colspan='5'><table width='100%' border='0' cellspacing='0' cellpadding='0'>
      <tr>
        <td width='26%'><div align='right' class='STYLE7'>会员帐号：</div></td>
        <td width='74%'>#LoginName#</td>
      </tr>
      <tr>
        <td><div align='right' class='STYLE7'>帐户余额：</div></td>
        <td>#WorthPoint#元</td>
      </tr>
      <tr>
        <td><div align='right' class='STYLE7'>联系人姓名：</div></td>
        <td>#NickName#</td>
      </tr>
      <tr>
        <td><div align='right' class='STYLE7'>电话：</div></td>
        <td>#Tel#</td>
      </tr>
      <tr>
        <td><div align='right' class='STYLE7'>邮箱：</div></td>
        <td>#Email#</td>
      </tr>
      <tr>
        <td><div align='right' class='STYLE7'>定制增值服务提交时间：</div></td>
        <td>#AddTime#</td>
      </tr>
      <tr>
        <td><div align='right' class='STYLE7'>跟进业务员：</div></td>
        <td>#SalesMan#</td>
      </tr>
      <tr>
        <td><div align='right' class='STYLE7'>特殊要求：</div></td>
        <td>#Remark#</td>
      </tr>
    </table></td>
  </tr>
  <tr>
    <td height='1' colspan='5' bgcolor='#999999'></td>
  </tr>
  <tr>
    <td height='40' bgcolor='#fffbe8'><div align='center' class='STYLE2'>服务项目</div></td>
    <td width='1' bgcolor='#999999'></td>
    <td bgcolor='#fffbe8'><div align='center' class='STYLE2'>服务说明</div></td>
    <td width='1' bgcolor='#999999'></td>
    <td bgcolor='#fffbe8'><div align='center' class='STYLE2'>价格(人民币/元)</div></td>
  </tr>
  <tr>
    <td height='1' colspan='5' bgcolor='#999999'></td>
  </tr>
#ServiceItem#
</table>

</body>
</html> ";
        string ServiceTemp = @"<tr>
    <td>#Title#</td>
    <td width='1' bgcolor='#999999'></td>
    <td>#Descrip#</td>
    <td width='1' bgcolor='#999999'></td>
    <td>#Price#</td>
  </tr>
  <tr>
    <td height='1' colspan='5' bgcolor='#999999'></td>
  </tr>";
        #endregion

        string bodyStr = bodyTemp;
        bodyStr = bodyStr.Replace("#LoginName#", Page.User.Identity.Name.Trim());
        bodyStr = bodyStr.Replace("#WorthPoint#", WorthPoint);
        bodyStr = bodyStr.Replace("#NickName#", NickName);
        bodyStr = bodyStr.Replace("#Tel#", Tel);
        bodyStr = bodyStr.Replace("#Email#", Email);
        bodyStr = bodyStr.Replace("#AddTime#", AddTime);
        bodyStr = bodyStr.Replace("#Remark#", textB_Remark.Text.Trim());
        bodyStr = bodyStr.Replace("#SalesMan#", salesman.Trim());
        

        string ServiceItem = "";
        for (int i = 0; i < typeArr.Length; i++)
        {
            int typeID = Convert.ToInt32(typeArr[i].ToString());
            string typeName = "定向推广";
            string descrip = decrip_27.InnerHtml;
            string price = price_27.InnerHtml;
            switch (typeID)
            {
                #region 获取服务说明
                case 27: 
                    typeName = "定向推广";
                    descrip = decrip_27.InnerHtml;
                    price = price_27.InnerHtml;
                    break;
                case 28:
                    typeName = "对口资源智能配对";
                    descrip = decrip_28.InnerHtml;
                    price = price_28.InnerHtml;
                    break;
                case 29:
                    typeName = "对口资源专家推荐";
                    descrip = decrip_29.InnerHtml;
                    price = price_29.InnerHtml;
                    break;
                case 30:
                    typeName = "编制商业计划书";
                    descrip = decrip_30.InnerHtml;
                    price = price_30.InnerHtml;
                    break;
                case 31:
                    typeName = "电子杂志推广";
                    descrip = decrip_31.InnerHtml;
                    price = price_31.InnerHtml;
                    break;
                case 32:
                    typeName = "领导专访";
                    descrip = decrip_32.InnerHtml;
                    price = price_32.InnerHtml;
                    break;
                case 33:
                    typeName = "尊贵展示";
                    descrip = decrip_33.InnerHtml;
                    price = price_33.InnerHtml;
                    break;
                case 2:
                    typeName = "招商投资路演";
                    descrip = decrip_2.InnerHtml;
                    price = price_2.InnerHtml;
                    break;
                case 34:
                    typeName = "专题推荐";
                    descrip = decrip_34.InnerHtml;
                    price = price_34.InnerHtml;
                    break;
                case 1:
                    typeName = "广告服务";
                    descrip = decrip_1.InnerHtml;
                    price = price_1.InnerHtml;
                    break;
                case 35:
                    typeName = "站内互告";
                    descrip = decrip_35.InnerHtml;
                    price = price_35.InnerHtml;
                    break;
                #endregion
            }
            ServiceItem += ServiceTemp;
            ServiceItem = ServiceItem.Replace("#Title#", typeName);
            ServiceItem = ServiceItem.Replace("#Descrip#", descrip);
            ServiceItem = ServiceItem.Replace("#Price#", price);
        }

        bodyStr = bodyStr.Replace("#ServiceItem#", ServiceItem);
        //#LoginName#  #WorthPoint#   #NickName#  #Tel#  #Email#   #AddTime#  #ServiceItem#
        //#Title#  #Descrip#  #Price#
        return bodyStr;
    }
    #endregion

    #region 发送增值服务邮件
    public int sendEmail(string usermail,string bodyStr)
    {
        int flag = 0;
        string emailTo = "club@tz888.cn";   //usermail;              //收件人邮件地址
        string emailTo2 = "service@tz888.cn";
        string Title = "您有会员" + Page.User.Identity.Name.Trim() + "的增值服务定制订单，请查收"; //textB_Name.Text.Trim();   //邮件标题
        string body = bodyStr; //邮件内容
        if (emailTo == "")
            return flag;
        try
        {
            MailMessage MyEmilMessage = new System.Net.Mail.MailMessage();
            MyEmilMessage.From = new MailAddress("topfotest@gmail.com", "中国招商投资网", System.Text.Encoding.UTF8);
            MyEmilMessage.To.Add(emailTo); //收件人
            MyEmilMessage.To.Add(emailTo2);
            MyEmilMessage.Subject = Title;
            MyEmilMessage.SubjectEncoding = System.Text.Encoding.Default;
            MyEmilMessage.Body = body;
            MyEmilMessage.BodyEncoding = System.Text.Encoding.Default;
            MyEmilMessage.IsBodyHtml = true;
            MyEmilMessage.Priority = MailPriority.High;

            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential("topfotest@gmail.com", "a12345678");            
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Send(MyEmilMessage);

            //Response.Write("<script>alert('全部发送完毕!');window.location='" + Request.Url + "'</script>");
            flag = 1;
        }
        catch (Exception ex)
        {
           string Ess = "";
           Ess += emailTo + "：发送失败.原因：" + ex.Message.ToString() + "," + DateTime.Now.ToString() + "|";
           Ess += emailTo2 + "：发送失败.原因：" + ex.Message.ToString() + "," + DateTime.Now.ToString() + "|";
           //Response.Write("<script>alert('" + Ess + "');window.location='" + Request.Url + "'</script>");
        }
        return flag;
    }
    #endregion
}
