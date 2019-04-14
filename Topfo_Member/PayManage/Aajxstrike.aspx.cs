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

public partial class PayManage_Aajxstrike : System.Web.UI.Page
{
    Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
    Tz888.BLL.MeberLogin.MemberIndexBLL member = new Tz888.BLL.MeberLogin.MemberIndexBLL();
    Tz888.BLL.OrderManage orderM = new Tz888.BLL.OrderManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        string name = "cn001";
       // string name = Page.User.Identity.Name;
        LgName.Value = name;
        DDl();
        Order(name);
        Rec(name);
        if (!IsPostBack)
        {
            
        }
        if (Convert.ToInt32(Request["fID"]) != 0)
        {
            string num = Request["fID"].ToString();
            Del(num);
        }
    }

    public void DDl()
    {
        DataTable dttype = dal.GetList("setPayTypeTab", "*", "instant", 20, 1, 0, 1, "");
        sType.DataTextField = "PayTypeName";
        sType.DataValueField = "PayTypeCode";
        sType.DataSource = dttype;
        sType.DataBind();

        ListItem lit1 = new ListItem("---全部---", "all");
        sType.Items.Add(lit1);
        sType.Items[sType.Items.Count - 1].Selected = true;

    }
    public void Order(string name)
    {
        string FiledOrder = "TransMoney";
        string tableOrder = "StrikeOrderTab";
        string where = " LoginName='"+name+"' and Status<>1 and Status<>10";
        int SumOrder = member.SumMoney(FiledOrder,tableOrder,where);
        int PageOrder = member.PageOrder(name,"-1","all");
        SpanOrder1.InnerHtml = Convert.ToString(PageOrder);
        SpanOrder2.InnerHtml = Convert.ToString(SumOrder);
    }
    public void Rec(string name)
    {
        string FiledRec = "PointCount";
        string tableRec = "StrikeRecTab";
        string where = " LoginName='" + name + "'";
        int SumOrder = member.SumMoney(FiledRec, tableRec, where);
        int PageRec = member.PageRec(name, "-1", "all");
        SpanRec1.InnerHtml = Convert.ToString(PageRec);
        SpanRec2.InnerHtml = Convert.ToString(SumOrder);
    }
    public void Del(string num)
    {
        bool b = true;
        b = orderM.deleStrikeOrder(num,1);
        if (b)
        {
            Response.Write("<script>alert('删除成功！')</script>");
        }
        else
        {
            Response.Write("<script>alert('删除失败！')</script>");
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        string[] values = Request.Form.GetValues("cbxSelect");
        string sdt = "";
        string com = "";
        bool b=true;
        foreach (string str in values)
        {
            b = orderM.deleStrikeOrder(str,1);
            if (b)
            {
                com +="订单号:"+ str + "删除成功 \\n";
            }
            else
            {
                sdt += "订单号:"+str + "删除失败 \\n";
            }

        }
        if (com.Length > 0)
        {
            Response.Write("<script>alert('"+com+"');</script>");
        }
        if (sdt.Length > 0)
        {
            Response.Write("<script>alert('"+sdt+"');</script>");
        }
       
    }
}
