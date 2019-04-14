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

public partial class PayManage_strike_records : System.Web.UI.Page
{
    Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
    Tz888.BLL.MeberLogin.MemberIndexBLL member = new Tz888.BLL.MeberLogin.MemberIndexBLL();
    Tz888.BLL.OrderManage orderM = new Tz888.BLL.OrderManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        AjaxPro.Utility.RegisterTypeForAjax(typeof(PayManage_strike_records));
        if (Page.User.Identity.Name == null || Page.User.Identity.Name.Trim() == "")
        {
            Response.Redirect("../Login.aspx");
        }
       // string name = "cn001";
        
        string name = Page.User.Identity.Name;
        LgName.Value = name;
        DDl();
        Order(name);
        Rec(name);
        if (!IsPostBack)
        {
            
        }
       
    }
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
    [AjaxPro.AjaxMethod()]
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
    [AjaxPro.AjaxMethod()]
    public void dele(string strList)
    {
        Tz888.BLL.CollectionBLL obj = new Tz888.BLL.CollectionBLL();
        bool b = false;
        string[] arr = strList.Split(',');
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i].Trim() != "")
            {
                string[] arr2 = arr[i].ToString().Trim().Split('|');
                orderM.deleStrikeOrder(arr[i], 1);
            }
        }
    }
}
