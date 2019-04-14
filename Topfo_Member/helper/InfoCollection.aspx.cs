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

public partial class helper_InfoCollection : Tz888.Common.Pager.BasePage
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        bool isTof = Page.User.IsInRole("GT1002");

        if (isTof)
        {
            Page.MasterPageFile = "~/indexTof.master";
        }
        else
        {
            Page.MasterPageFile = "~/MasterPage.master";
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        AjaxPro.Utility.RegisterTypeForAjax(typeof(helper_InfoCollection));
        this.ViewState["MemberLoginName"] = Page.User.Identity.Name;
        if (this.ViewState["MemberLoginName"].ToString() == null || this.ViewState["MemberLoginName"].ToString().ToString() == "")
        {
            Response.Redirect("../Login.aspx");
        }

        PagerBase = Pager1;
        GridViewBase = dgCollection;
        if (!Page.IsPostBack)
        {
            if (!IsPostBack)
            {
                getList();
            }
        }
        tbKey.Attributes.Add("onfocus", "this.value=''");
    }

    #region  信息收藏夹列表显示


    public void getList()
    {
        System.Text.StringBuilder Criteria = new System.Text.StringBuilder();
        MakeCriteria(ref Criteria);
        string strCriteria = Criteria.ToString();
        PagerBase.StrWhere = strCriteria;
        PagerBase.DataBind();
        if (PagerBase.PageCount <= 0)
        {
            dgCollection.Visible = false;
            lbMessage.Text = "您在此段时间内没有收藏任何资源 <a href='http://www.topfo.com'>点此查看 说不定就有合适您的</a>";
            lbMessage.Visible = true;
        }
        else
        {
            dgCollection.Visible = true;
            lbMessage.Visible = false;
        }
    }
    private void MakeCriteria(ref System.Text.StringBuilder Criteria)
    {
        string str = "loginName='" + this.ViewState["MemberLoginName"].ToString() + "'"; //DeleteStatus  0:显示   1:浏览删除    2:收藏删除
        Criteria.Append(str);

        string key = tbKey.Text.Trim();//资源名称、发布者、类型

        if (key != "请输入资源名称、发布者、类型等" && key != "")
        {
            string strKey = " AND (Title like '%" + key + "%' OR PublishMan like '%" + key + "%' OR InfoTypeName like '%" + key + "%')";
            Criteria.Append(strKey);
        }

        //三天内、七天内、一个月内、三个月内、三个月以

        switch (this.ddCreateTime.SelectedValue.Trim())
        {
            case "91":
                string strDays = " AND CreateDate<='" + DateTime.Now.AddDays(-90).ToShortDateString() + "'";
                Criteria.Append(strDays);
                break;
            default:
                Tz888.Common.MakeCriteria.AddDTCriteria(ref Criteria, "CreateDate", DateTime.Now.AddDays(-Convert.ToDouble(this.ddCreateTime.SelectedValue.Trim())).ToShortDateString(), DateTime.Now.AddDays(1).ToShortDateString());
                break;
        }
    }
    #endregion
    [AjaxPro.AjaxMethod]
    public string dele(string strList)
    {
        Tz888.BLL.CollectionBLL obj = new Tz888.BLL.CollectionBLL();
        bool b = false;
        string[] arr = strList.Split(',');
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i].Trim() != "")
            {
                string[] arr2 = arr[i].ToString().Trim().Split('|');
                b = obj.Delete(arr2[0].Trim(), Convert.ToInt64(arr2[1].Trim()));
            }
        }
        return "ok";
    }
    protected void ddCreateTime_SelectedIndexChanged(object sender, EventArgs e)
    {
        getList();
    }
    protected void btSearch_Click(object sender, EventArgs e)
    {
        getList();
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Pager1.PageSize = 10;
        getList();
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Pager1.PageSize = 20;
        getList();
    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        Pager1.PageSize = 30;
        getList();
    }
}
