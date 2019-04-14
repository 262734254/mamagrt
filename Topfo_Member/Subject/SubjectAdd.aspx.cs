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


public partial class Subject_SubjectAdd : System.Web.UI.Page
{
    Tz888.BLL.Subject.SubjectExtendBLL subBll = new Tz888.BLL.Subject.SubjectExtendBLL();
    Tz888.Model.Subject.SubjectExtendModel model = new Tz888.Model.Subject.SubjectExtendModel();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string sub = Request["Sub"].ToString();
            ViewState["Sub"] = sub;
            
            if (sub == "Modify")
            {
                int SubID = Convert.ToInt32(Request["id"]);
                ViewState["SubID"] = SubID;
                ModifySub(SubID);
            }

        }
    }

    private void ModifySub(int id)
    {
        model = subBll.SelSubject(id);
        txtTitle.Value = model.SubTitle.ToString().Trim();
        txtRemark.Value = model.Remark.ToString().Trim();
        txtLinkName.Value = model.LinkMan.ToString().Trim();
        txtMobile.Value = model.Phone.ToString().Trim();
    }
    protected void IbtnSubmit_Click(object sender, ImageClickEventArgs e)
    {
        model.LoginName = Page.User.Identity.Name;
        //model.LoginName = "cn001";//帐号名称
        model.SubTitle = txtTitle.Value.ToString().Trim();//专题标题
        model.Remark = txtRemark.Value.ToString().Trim();//专题说明
        model.Audit = 0;//审核状态
        model.Source = 1;//来源 1：表示来源会员，0：表示来源总站
        model.HtmlUrl = "";//访问地址
        model.Sort = 0;//排序
        model.SubType = 0;//类型
        model.SubTime = DateTime.Now;//发布时间
        model.LinkMan = txtLinkName.Value.ToString().Trim();//联系人
        model.Phone = txtMobile.Value.ToString().Trim();//联系人手机
        model.Picture = "";//图片
        if (Convert.ToString(ViewState["Sub"]) == "add")
        {
            int SubAdd = subBll.AddSubjectExtend(model);
            if (SubAdd >= 0)
            {
                Tz888.Common.MessageBox.ShowAndHref("添加成功", "SubjectSee.aspx");
            }
            else
            {
                Tz888.Common.MessageBox.Show(this.Page,"添加失败");
            }
        }
        else if (Convert.ToString(ViewState["Sub"]) == "Modify")
        {
            int subUpdate = subBll.ModfiySubjectExtend(model, Convert.ToInt32(ViewState["SubID"]));
            if (subUpdate >= 0)
            {
                Tz888.Common.MessageBox.ShowAndHref("修改成功", "SubjectSee.aspx");
            }
            else
            {
                Tz888.Common.MessageBox.Show(this.Page, "修改失败");
            }
        }
        
    }
}
