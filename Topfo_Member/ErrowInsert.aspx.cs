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

public partial class ErrowInsert : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Tz888.BLL.ErrowTabBLL bll = new Tz888.BLL.ErrowTabBLL();
        Tz888.Model.ErrowTab model = new Tz888.Model.ErrowTab();
        model.LoginName = "0";//游客
        model.LinkURL = txtlinkurl.Text;
        model.QuestionDescript = txtdescrption.Text;
        model.Connetions = txtconnection.Text;
        model.BoolChuLi = 0;
        model.BoolReturn = 0;
        model.ReturnContext ="";
        model.Descript = "";
        model.createtime = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString().Trim();
        model.updatetime = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString().Trim();
        int result = bll.Add(model);
        if (result > 0)
        {
            Response.Write("<script>alert('添加成功！');</script>");
        }
        else 
        {
            Response.Write("<script>alert('添加失败！');</script>");
        }
    }
}
