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

public partial class Manage_AajxStatus : System.Web.UI.Page
{
    Tz888.BLL.MeberLogin.MemberIndexBLL member = new Tz888.BLL.MeberLogin.MemberIndexBLL();
    string title = "";
    string name = "";
    string state = "";
    string type = "";
    string pageID = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        BindInfoType();
        name = "tz888admin";
       // name = Page.User.Identity.Name;
        state = this.NameID.Value == "" ? "" : this.NameID.Value;
        pageID = this.txtPageID.Value == "" ? "" : this.txtPageID.Value;
        type = this.ddlInfoType.SelectedValue == "All" ? "All" : this.ddlInfoType.SelectedValue;
        title = this.txtTitle.Text == "" ? "" : this.txtTitle.Text;
        AjaxPro.Utility.RegisterTypeForAjax(typeof(Manage_AajxStatus));
        if (!IsPostBack)
        {

        }
        //if (Convert.ToInt32(Request["fID"]) != 0)
        //{
        //    long id = Convert.ToInt64(Request["fID"]);
        //    Del(id);
        //}
        
    }
    private void BindInfoType()
    {
        ListItem li1 = new ListItem("所有需求", "All");
        this.ddlInfoType.Items.Add(li1);
        ListItem li2 = new ListItem("投资需求", "Capital");
        this.ddlInfoType.Items.Add(li2);
        ListItem li3 = new ListItem("政府招商", "Merchant");
        this.ddlInfoType.Items.Add(li3);
        ListItem li4 = new ListItem("融资需求", "Project");
        this.ddlInfoType.Items.Add(li4);
        ListItem li5 = new ListItem("创业需求", "CarveOut");
        this.ddlInfoType.Items.Add(li5);
        ListItem li6 = new ListItem("商机", "Oppor");
        this.ddlInfoType.Items.Add(li6);
        this.ddlInfoType.SelectedIndex = 0;
    }
    [AjaxPro.AjaxMethod]
    public void Del(string infoId)
    {
        string name = "tz888admin";
       // Tz888.BLL.Info.MainInfoBLL bll = new Tz888.BLL.Info.MainInfoBLL();
        string[] a = infoId.Split(',');
        int ErrorID = 0;
        string ErrorMsg = "";
       
        for (int i = 0; i < a.Length;i++ )
        {
            if (a[i].ToString().Trim() != "")
            {
               // b = bll.UserDelete(Convert.ToInt64(a[i]), name, ref ErrorID, ref ErrorMsg);
                int n = member.SelDelMain(a[i]);
            }
        }
    }

    protected void btnSetOverdue_Click(object sender, EventArgs e)
    {
        string[] values = Request.Form.GetValues("cbxSelect");
        string msg = "";

        if (values == null)
            return;

        Tz888.BLL.Info.MainInfoBLL bll = new Tz888.BLL.Info.MainInfoBLL();
        foreach (string str in values)
        {
            long InfoID = Convert.ToInt64(str);
            if (!bll.SetValidateTerm(InfoID, 0))
                msg += "[" + InfoID.ToString() + "]设置过期失败！\n";
        }
        if (!string.IsNullOrEmpty(msg))
            Tz888.Common.MessageBox.Show(this.Page, msg);

    }
    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        string[] values = Request.Form.GetValues("cbxSelect");
        string msg = "";

        if (values == null || values.Length < 1)
        {
            Tz888.Common.MessageBox.Show(this.Page, "请选择要刷新的资源!");
            return;
        }

        Tz888.BLL.Info.MainInfoBLL bll = new Tz888.BLL.Info.MainInfoBLL();
        foreach (string str in values)
        {
            long InfoID = Convert.ToInt64(str);
            if (!bll.UpdateRefresh(InfoID))
                msg += "[" + InfoID.ToString() + "]刷新失败！\n";
        }
        if (!string.IsNullOrEmpty(msg))
            Tz888.Common.MessageBox.Show(this.Page, msg);
        else
            Tz888.Common.MessageBox.Show(this.Page, "刷新成功！");

    }
    //protected void btnDelete_Click(object sender, EventArgs e)
    //{
    //    string[] values = Request.Form.GetValues("cbxSelect");
    //    string msg = "";

    //    string loginName = "tz888admin";
    //   // string loginName = Page.User.Identity.Name; //注释2010-06-13
    //    if (values == null || values.Length < 1)
    //    {
    //        Tz888.Common.MessageBox.Show(this.Page, "请选择要删除的资源!");
    //        return;
    //    }
    //    Tz888.BLL.Info.MainInfoBLL bll = new Tz888.BLL.Info.MainInfoBLL();
    //    foreach (string str in values)
    //    {
    //        long InfoID = Convert.ToInt64(str);
    //        int ErrorID = 0;
    //        string ErrorMsg = "";
    //        if (!bll.UserDelete(InfoID, loginName, ref ErrorID, ref ErrorMsg))
    //            msg += "[" + InfoID.ToString() + "]删除失败！" + ErrorMsg + "\n";
    //    }
    //    if (!string.IsNullOrEmpty(msg))
    //        Tz888.Common.MessageBox.Show(this.Page, msg);
    //   string neirong= member.AjaxStatus(name, Convert.ToInt32(state), Convert.ToInt32(pageID), type, title);
    //   string fenye=  member.pageCont(name, Convert.ToInt32(state), Convert.ToInt32(pageID), type, title);
    //   StatuID.InnerHtml = neirong;
    //   spanPage.InnerHtml = fenye;
   // }

}
