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

public partial class Company_CompanyMiddle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string LinkName = Page.User.Identity.Name;
            LinName(LinkName);
        }
    }

    private void LinName(string name)
    {
        Tz888.BLL.Company.CompanyBLL company = new Tz888.BLL.Company.CompanyBLL();
        Tz888.Model.Company.CompanyModel model = new Tz888.Model.Company.CompanyModel();
       
        int ifCommon = company.IfCompany(name);
        if (ifCommon <= 0)
        {
            Response.Redirect("CompanyAdd.aspx");
        }
        else
        {
           // int ad = company.SelAdution(name);//判断审核状态
            model = company.SelCompany(name);
            if (Convert.ToInt32(model.Auditingstatus) == 1)
            {
                string[] par = model.Htmlfile.Split('/');

                Response.Redirect("http://card.topfo.com/" +par[1]+ "/"+par[2]+"");
            }
            else
            {
                Response.Redirect("CompanyAdd.aspx");
            }
        }
    }
}
