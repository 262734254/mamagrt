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
using Tz888.BLL.Professional;
using Tz888.Model.Professional;
using Tz888.Common.Utility;
using Tz888.Common;
using System.IO;
public partial class Publish_Professional_PublishProtalent : System.Web.UI.Page
{
    ProfessionalinfoBLL infoBll = new ProfessionalinfoBLL();
    ProfessionalLinkBLL linkBll = new ProfessionalLinkBLL();
    ProfessionaltalentsBLL plBll = new ProfessionaltalentsBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            if (string.IsNullOrEmpty(Page.User.Identity.Name))
            {
                Response.Redirect("~/Login.aspx?ReturnUrl=" + Server.UrlEncode(Request.RawUrl));
            }

            databind();
            ViewState["strSavePath"] = "";
            this.rdlValiditeTerm.SelectedIndex = 0;
        } btnOk.Attributes.Add("onclick", "return chkPost();");
    }
    //机构列表 
    private void databind()
    {
        ProfessionalTypeBLL bll = new ProfessionalTypeBLL();
        ddlServiceType.DataSource = bll.GetTypeAll();
        ddlServiceType.DataTextField = "typeName";
        ddlServiceType.DataValueField = "typeId";
        ddlServiceType.DataBind();

        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        DataTable dt = dal.GetList("dicttab", "*", "idictvalue", 10, 1, 0, 0, " cdicttype='xmyxqxx' ");
        this.rdlValiditeTerm.DataTextField = "cdictname";
        this.rdlValiditeTerm.DataValueField = "idictvalue";
        this.rdlValiditeTerm.DataSource = dt;
        this.rdlValiditeTerm.DataBind();
        //人才类别
        ProfessionalTalentsType orgBll = new ProfessionalTalentsType();
        this.DropIndustry.DataSource = orgBll.GetList("");
        this.DropIndustry.DataTextField = "TypeName";
        this.DropIndustry.DataValueField = "typeID";
        this.DropIndustry.DataBind();
    }
    
    protected void btnUpload2_Click(object sender, EventArgs e)
    {
        string picTitle = "";
        if (this.uploadPic.HasFile)
        {
            DateTime Now = DateTime.Now;
            //string path = "F:/Topfo/dservice/image/" + Now.Year.ToString() + "/" + Now.Month.ToString() + "/";
            string path = "J:/topfo/tzWeb/dservice/image/" + Now.Year.ToString() + "/";
            picTitle = UploadFile(uploadPic, path, 500, "default");
            switch (picTitle)
            {
                case "1":
                    Tz888.Common.MessageBox.Show(this.Page, "图片类型不对！");
                    break;
                case "2":
                    Tz888.Common.MessageBox.Show(this.Page, "图片大小超出500K！");
                    break;
                case "3":
                    Tz888.Common.MessageBox.Show(this.Page, "请选择上传图片！");
                    break;
                default:
                    ViewState["strSavePath"] = "/dservice/image/" + Now.Year.ToString() + "/" + picTitle;
                    imageDis.Attributes.Add("style", "display:''");
                    Image1.ImageUrl = "http://www.topfo.com" + ViewState["strSavePath"].ToString();
                    //this.lblImages.Text = "您最新上传的图片";
                    this.LblMessage2.Text = "上传图片成功"; break;

            }
        }
        else
        {
            RegisterStartupScript("alertMessage", "<script>alert('请选择上传的图片!'); </script>");
        }
    }
    /// <summary>
    /// 上传文件
    /// </summary>
    /// <param name="postedFile">上传文件控件</param>
    /// <param name="path">存入的物理路径,留空则为根目录下 UploadFile 目录</param>
    /// <param name="size">文件大小,0为不限制</param>
    /// <param name="filetype">可上传的文件类型，格式：".gif|.jpg|.png",留空为不限制,"default"即默认".gif|.jpg|.bmp"类型</param>
    /// <returns>上传后文件的名称 返回1:文件类型不对 返回2:大小超出限制</returns>
    public static string UploadFile(System.Web.UI.WebControls.FileUpload postedFile, string path, int size, string filetype)
    {
        try
        {
            string strSaveName = string.Empty;
            string strtype = System.IO.Path.GetExtension(postedFile.PostedFile.FileName);//扩展名
            DateTime Now = DateTime.Now;
            strSaveName = Now.Year.ToString() + Now.Month.ToString() + Now.Day.ToString() +
                Now.Hour.ToString() + Now.Minute.ToString() + Now.Second.ToString() + strtype;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string strSavePath = path + strSaveName;//为文件获取保存路径
            int fileSize = postedFile.PostedFile.ContentLength / 1024;
            //是否限制文件类型
            if (filetype.Length > 0)
            {
                if (filetype.ToLower().Equals("default"))
                {
                    if (strtype.ToLower() != ".jpg" && strtype.ToLower() != ".bmp" && strtype.ToLower() != ".gif")
                        return "1";
                }
            }
            //是否限制大小
            if (size > 0)
            {
                if (fileSize <= size)
                {
                    postedFile.PostedFile.SaveAs(strSavePath);//保存上传的文件到指定的路径
                    return strSaveName;
                }
                else
                {
                    //上传的文件大小超出
                    return "2";
                }
            }
            else
            {
                postedFile.PostedFile.SaveAs(strSavePath);//保存上传的文件到指定的路径
                return strSaveName;
            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    protected void btnOk_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(this.txtTitle.Text))
        {
            Tz888.Common.MessageBox.Show(this.Page, "请填写标题!");
            return;
        }

        if (this.DropIndustry.SelectedValue == "" || this.DropIndustry.SelectedValue == "0")
        {
            Tz888.Common.MessageBox.Show(this.Page, "请选择人才类别！");
            return;
        }
        if (this.ddlServiceType.SelectedValue == "")
        {
            Tz888.Common.MessageBox.Show(this.Page, "服务类型不能为空！");
            return;
        }
        //if (!string.IsNullOrEmpty(uploadPic.FileName))
        //{
        //    string fileName1 = uploadPic.FileName;
        //    string extendName = fileName1.ToLower().Substring(fileName1.LastIndexOf("."));
        //    if (extendName != ".bmp" && extendName != ".gif" && extendName != ".jpg")
        //    {
        //        Tz888.Common.MessageBox.Show(this.Page, "只能上传｜jpg｜gif｜bmp｜格式的图片！");
        //        return;
        //    }
        //}
        if (txtPosition.Value == "")
        {
            Tz888.Common.MessageBox.Show(this.Page, "职务不能为空！");
            return;
        }
        if (txtLinkMan.Value.Trim() == "")
        {
            Tz888.Common.MessageBox.Show(this.Page, "联系人不能为空！");
            return;
        }
        if (txtCompanyName.Value.Trim() == "")
        {
            Tz888.Common.MessageBox.Show(this.Page, "公司名称不能为空！");
            return;
        }
        if (txtLinkTel.Text.Trim() == "" && txtPhone.Text.Trim() == "")
        {
            Tz888.Common.MessageBox.Show(this.Page, "联系人电话和手机至少填一个！");
            return;
        }
        else
        {
            if (txtLinkTel.Text.Trim() != "")
            {
                if (!PageValidate.IsNumber(txtLinkTel.Text.Trim()))
                {
                    Tz888.Common.MessageBox.Show(this.Page, "联系人电话格式错误！");
                    return;
                }
            }

        }

        if (txtEmail.Value.Trim() == "")
        {
            Tz888.Common.MessageBox.Show(this.Page, "Email不能为空！！");
            return;
        }
        if (txtEmail.Value.Trim() != "")
        {
            if (!PageValidate.IsEmail(txtEmail.Value.ToLower().Trim()))
            {
                Tz888.Common.MessageBox.Show(this.Page, "Email地址格式错误！");
                return;
            }
        }
        Professionaltalents please = new Professionaltalents();
        ProfessionalinfoTab MainInfo = new ProfessionalinfoTab();
        ProfessionalLink link = new ProfessionalLink();


        if (!string.IsNullOrEmpty(Request.QueryString["ProfessionalID"]))
        {
            int ProfessionalID = int.Parse(Request.QueryString["ProfessionalID"].ToString());
            MainInfo.ProfessionalID = ProfessionalID;
        }
        if (!string.IsNullOrEmpty(ViewState["strSavePath"].ToString()))
        {
            please.Images = ViewState["strSavePath"].ToString();
        }
        else
        {
            please.Images = "/dservice/image/photo.jpg";
        }
        please.CountryCode = this.ZoneSelectControl1.CountryID;
        please.ProvinceID = this.ZoneSelectControl1.ProvinceID;
        please.CityID = this.ZoneSelectControl1.CityID;
        please.CountyID = this.ZoneSelectControl1.CountyID;
        please.companydate = Convert.ToDateTime(DateTime.Now.ToString()); //Convert.ToDateTime(txtRegistYear.Text.Trim().ToString());
        please.position = txtPosition.Value.Trim();
        please.title = "";
        please.servicetypeID = int.Parse(ddlServiceType.SelectedValue.ToString());//服务类型
        please.talentsTypeID = int.Parse(DropIndustry.SelectedValue.ToString()); //人才类别
        please.resume = txtresume.Text;//个人简历
        please.specialty = txtspecialty.Text;//个人特长
        please.ScuccCase = txtSuccess.Text;//成功案例
        please.validityID = int.Parse(rdlValiditeTerm.SelectedValue.ToString());//有效期
        link.CompanyName = txtCompanyName.Value.Trim();
        link.Email = txtEmail.Value.Trim();
        link.Fax = txtLinkFax.Value.Trim();
        string tel = string.Empty;
        if (!string.IsNullOrEmpty(txtcontactsTel.Text.Trim()))
        {
            tel = txtcontactsTel.Text.Trim()+",";
        }
        else
        {
            tel = ",";
        }
        if (!string.IsNullOrEmpty(txtLinkTel.Text.Trim()))
        {
            tel += txtLinkTel.Text.Trim() + ",";
        }
        else
        {
            tel += ",";
        }
        if (!string.IsNullOrEmpty(txttel2.Text.Trim()))
        {
            tel += txttel2.Text.Trim() + ",";
        }
        else
        {
            tel += ",";
        }
        link.Tel = tel;
        link.UserName = txtLinkMan.Value.Trim();
        link.Site = txtWebSite.Value.Trim();
        link.phone = txtPhone.Text.Trim();
        link.Address = txtAddress.Text.Trim();
        MainInfo.LoginName = Page.User.Identity.Name;
        MainInfo.Titel = txtTitle.Text.Trim();
        MainInfo.typeID = 3;
        MainInfo.htmlUrl = "";
        MainInfo.FromId = 1;
        MainInfo.recommendId = 0;
        MainInfo.price = 0;
        if (plBll.InsertProFessionlView(MainInfo, please, link))
        {
            Response.Write("<script>alert('发布成功！');document.location='ServiesManage.aspx'</script>");
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "发布失败！");
        }
    }

}
