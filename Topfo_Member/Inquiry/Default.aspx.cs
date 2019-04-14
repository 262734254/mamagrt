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

public partial class Inquiry_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void manage_Click(object sender, ImageClickEventArgs e)
    {
        Tz888.BLL.Common.InquiryBLL bll = new Tz888.BLL.Common.InquiryBLL();
        Tz888.Model.Common.InquiryModel model = new Tz888.Model.Common.InquiryModel();

        model.MessageTitle = this.txtQuestion.Text.Trim();
        model.MessageBody = Tz888.Common.Utility.PageValidate.HtmlToTxt(this.txtDesc.Value.Trim());
        model.Name = this.txtName.Text.Trim();
        model.Tel = this.txtPhone.Text.Trim();
        model.Address = this.txtZone.Text.Trim();
        model.Email = this.txtEmail.Text.Trim();

        int id = bll.Insert(model);
    }
}
