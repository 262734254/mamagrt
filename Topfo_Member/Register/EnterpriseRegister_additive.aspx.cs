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

public partial class Register_EnterpriseRegister_additive : System.Web.UI.Page
{
    public Tz888.Model.MemberResourceModel modelYYZZ;
    public Tz888.Model.MemberResourceModel modelGS;
    public Tz888.Model.MemberResourceModel modelDS;
    public Tz888.Model.MemberResourceModel modelRYZS;

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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.User.Identity.Name == null || Page.User.Identity.Name.Trim() == "")
        {
            Response.Redirect("../Login.aspx?ReturnUrl=" + Server.UrlEncode(Request.RawUrl));
        }

        if (!IsPostBack)
        {
            //查询是否己有过公司登记
            Tz888.BLL.Register.EnterpriseRegisterBLL obj = new Tz888.BLL.Register.EnterpriseRegisterBLL();
            DataTable dt = obj.getEnterpriseModel(Page.User.Identity.Name);
            if (dt.Rows.Count < 0)
            {
                Tz888.Common.MessageBox.ShowAndRedirect(this.Page, "您还没有进行公司登记，请先登记！", "EnterpriseRegister.aspx");
                return;
            }
        }

        imgLoad();

          #region 组织机构代码 OrganizationCode
          //组织机构代码

          Tz888.BLL.Register.EnterpriseRegisterBLL objOrgCode = new Tz888.BLL.Register.EnterpriseRegisterBLL();
          string strCode = objOrgCode.GetOrganizationCode(Page.User.Identity.Name);
          if (strCode != "")
          {
              string[] Code = strCode.Split('-');
              TextBox1.Text = Code[0];
              TextBox2.Text = Code[1];
          }   
          #endregion
      }

    public void imgLoad()
    {
        #region
        /*/// <summary>
        /// 资源类型
		/// 0 -其他文档
        /// 1 -图片
        /// 2 -视频
         /// <summary>
        
        /// 资源性质 
         * ///0 公司介绍（多图片）登记介绍
        ///1营业执照
        ///2税务登记证(国税)
        ///3税务登记证(地税)
        ///4荣誉和证书
        ///5其它*/

        #endregion
        #region 图片信息加载
        Tz888.SQLServerDAL.Conn objResource = new Tz888.SQLServerDAL.Conn();

        DataTable dtResource1 = objResource.GetList("MemberResourceTab", "*", "ResourceID", 1, 1, 0, 1, "LoginName='" + Page.User.Identity.Name.Trim() + "' AND ResourceProperty=1");
        if (dtResource1 != null && dtResource1.Rows.Count > 0)
        {
            fuYYZZ.Img = ConfigurationManager.AppSettings["ImageDomain"].ToString() + "/" + dtResource1.Rows[0]["ResourceAddr"].ToString();
            fuYYZZ.ButtonName = "修改";
            fuYYZZ.IsUp = "0";
        }
        else
        {
            fuYYZZ.Img = @"../images/publish/noneimg.gif";
            fuYYZZ.ButtonName = "添加上传";
            fuYYZZ.IsUp = "0";
        }

        DataTable dtResource2 = objResource.GetList("MemberResourceTab", "*", "ResourceID", 1, 1, 0, 1, "LoginName='" + Page.User.Identity.Name.Trim() + "' AND ResourceProperty=2");
        if (dtResource2 != null && dtResource2.Rows.Count > 0)
        {
            fuGS.Img = ConfigurationManager.AppSettings["ImageDomain"].ToString() + "/" + dtResource2.Rows[0]["ResourceAddr"].ToString();
            fuGS.ButtonName = "修改";
            fuGS.IsUp = "0";
        }
        else
        {
            fuGS.Img = @"../images/publish/noneimg.gif";
            fuGS.ButtonName = "添加上传";
            fuGS.IsUp = "0";
        }

        DataTable dtResource3 = objResource.GetList("MemberResourceTab", "*", "ResourceID", 1, 1, 0, 1, "LoginName='" + Page.User.Identity.Name.Trim() + "' AND ResourceProperty=3");
        if (dtResource3 != null && dtResource3.Rows.Count > 0)
        {
            fuDS.Img = ConfigurationManager.AppSettings["ImageDomain"].ToString() + "/" + dtResource3.Rows[0]["ResourceAddr"].ToString();
            fuDS.ButtonName = "修改";
            fuDS.IsUp = "0";
        }
        else
        {
            fuDS.Img = @"../images/publish/noneimg.gif";
            fuDS.ButtonName = "添加上传";
            fuDS.IsUp = "0";
        }
        DataTable dtResource4 = objResource.GetList("MemberResourceTab", "*", "ResourceID", 1, 1, 0, 1, "LoginName='" + Page.User.Identity.Name.Trim() + "' AND ResourceProperty=4");
        if (dtResource4 != null && dtResource4.Rows.Count > 0)
        {
            fuRYZS.Img = ConfigurationManager.AppSettings["ImageDomain"].ToString() + "/" + dtResource4.Rows[0]["ResourceAddr"].ToString();
            fuRYZS.ButtonName = "修改";
            fuRYZS.IsUp = "0";
        }
        else
        {
            fuRYZS.Img = @"../images/publish/noneimg.gif";
            fuRYZS.ButtonName = "添加上传";
            fuRYZS.IsUp = "0";
        }
        #endregion 
    }
    protected void btSend_Click(object sender, EventArgs e)
    {
        #region 营业执照fuYYZZ
        string[] YYZZName = fuYYZZ.SaveImages("EnterpriseRegister");
        string PicYYZZ = "";
        if (YYZZName.Length > 0)
        {
            modelYYZZ = new Tz888.Model.MemberResourceModel();
            PicYYZZ = YYZZName[0];

            modelYYZZ.ResourceID = 0;
            modelYYZZ.LoginName = Page.User.Identity.Name.Trim();
            modelYYZZ.ResourceName = "营业执照";
            modelYYZZ.ResourceTitle = "营业执照";
            modelYYZZ.ResourceDescrib = "营业执照";//资源介绍
            modelYYZZ.ResourceType = 1;//资源类型
            modelYYZZ.ResourceAddr = PicYYZZ;
            modelYYZZ.ResourceProperty = 1;//资源性质
            modelYYZZ.ResourcePassword = null;//资源密码
            modelYYZZ.UpDate = DateTime.Now;//上传日期
            modelYYZZ.IsDel = false;//是否删除
            modelYYZZ.remark = "营业执照";
            UpLoadImage(modelYYZZ);
        }
        #endregion 

        #region 税务登记证(国税)fuGS
        string[] GSName = fuGS.SaveImages("EnterpriseRegister");
        string PicGS = "";
        if (GSName.Length > 0)
        {
            modelGS = new Tz888.Model.MemberResourceModel();
            PicGS = GSName[0];

            modelGS.ResourceID = 0;
            modelGS.LoginName = Page.User.Identity.Name.Trim();
            modelGS.ResourceName = "税务登记证(国税)";
            modelGS.ResourceTitle = "国税";
            modelGS.ResourceDescrib = "税务登记证(国税)";//资源介绍
            modelGS.ResourceType = 1;//资源类型
            modelGS.ResourceAddr = PicGS;
            modelGS.ResourceProperty = 2;//资源性质
            modelGS.ResourcePassword = null;//资源密码
            modelGS.UpDate = DateTime.Now;//上传日期
            modelGS.IsDel = false;//是否删除
            modelGS.remark = "税务登记证(国税)";
            UpLoadImage(modelGS);

        }
        #endregion 

        #region 税务登记证(地税)fuDS
        string[] DSName = fuDS.SaveImages("EnterpriseRegister");
        string PicDS = "";
        if (DSName.Length > 0)
        {
            modelDS = new Tz888.Model.MemberResourceModel();
            PicDS = DSName[0];

            modelDS.ResourceID = 0;
            modelDS.LoginName = Page.User.Identity.Name.Trim();
            modelDS.ResourceName = "税务登记证(地税)";
            modelDS.ResourceTitle = "地税";
            modelDS.ResourceDescrib = "税务登记证(地税)";//资源介绍
            modelDS.ResourceType = 1;//资源类型
            modelDS.ResourceAddr = PicDS;
            modelDS.ResourceProperty = 3;//资源性质
            modelDS.ResourcePassword = null;//资源密码
            modelDS.UpDate = DateTime.Now;//上传日期
            modelDS.IsDel = false;//是否删除
            modelDS.remark = "税务登记证(地税)";
            UpLoadImage(modelDS);
        }
        #endregion 

        #region 其它荣誉和证书fuRYZS
        string[] RYZSName = fuRYZS.SaveImages("EnterpriseRegister");
        string PicRYZS = "";
        if (RYZSName.Length > 0)
        {
            modelRYZS = new Tz888.Model.MemberResourceModel();
            PicRYZS = RYZSName[0];

            modelRYZS.ResourceID = 0;
            modelRYZS.LoginName = Page.User.Identity.Name.Trim();
            modelRYZS.ResourceName = "其它荣誉和证书";
            modelRYZS.ResourceTitle = "其它荣誉和证书";
            modelRYZS.ResourceDescrib = "其它荣誉和证书";//资源介绍
            modelRYZS.ResourceType = 1;//资源类型
            modelRYZS.ResourceAddr = PicRYZS;
            modelRYZS.ResourceProperty = 4;//资源性质
            modelRYZS.ResourcePassword = null;//资源密码
            modelRYZS.UpDate = DateTime.Now;//上传日期
            modelRYZS.IsDel = false;//是否删除
            modelRYZS.remark = "其它荣誉和证书";
            UpLoadImage(modelRYZS);
        }
        #endregion 

        //组织机构代码

        Tz888.BLL.Register.EnterpriseRegisterBLL objOrgCode = new Tz888.BLL.Register.EnterpriseRegisterBLL();
        string strCode = objOrgCode.GetOrganizationCode(Page.User.Identity.Name);
        if (strCode != "")
        {
            string[] Code = strCode.Split('-');
            TextBox1.Text = Code[0];
            TextBox2.Text = Code[1];
        }       
          
        if (TextBox1.Text.Trim() != "" && TextBox2.Text.Trim() != "")
        {
            string Code=TextBox1.Text.Trim()+"-"+TextBox2.Text.Trim();
            if (objOrgCode.UpdateOrganizationCode(Page.User.Identity.Name, Code) < 0)
            {
                Tz888.Common.MessageBox.Show(this.Page, "组织机构代码修改出错！");
                return;
            }
        }

        //string reg=Request.QueryString["reg"].Trim();
        //string web=Request.QueryString["web"].Trim();

        //int type = 0;
        //if (Page.User.IsInRole("GT1001"))   //普通会员
        //    type = 0;
        //else
        //    type = 1;        
       //  Response.Redirect("OrgRegisterSucceed.aspx?type=" + type + "&reg="+reg+"&web=" + web);


        Tz888.Common.MessageBox.ShowAndRedirect(this.Page,"上传成功！", "EnterpriseRegister_additive.aspx");
        imgLoad();
    }

    protected void UpLoadImage(Tz888.Model.MemberResourceModel UpLoadImage)
    {
        Tz888.SQLServerDAL.MemberResourceDAL objSendImage = new Tz888.SQLServerDAL.MemberResourceDAL();
        Tz888.Model.MemberResourceModel ResourceModel = new Tz888.Model.MemberResourceModel();
      
        //保存进数据库
        ResourceModel.ResourceID = 0;
        ResourceModel.LoginName = UpLoadImage.LoginName;
        ResourceModel.ResourceName = UpLoadImage.ResourceName;
        ResourceModel.ResourceTitle = UpLoadImage.ResourceTitle;
        ResourceModel.ResourceDescrib = UpLoadImage.ResourceDescrib;
        ResourceModel.ResourceType = UpLoadImage.ResourceType;
        ResourceModel.ResourceAddr = UpLoadImage.ResourceAddr;
        ResourceModel.ResourceProperty = UpLoadImage.ResourceProperty;
        ResourceModel.ResourcePassword = null;
        ResourceModel.UpDate = DateTime.Now;
        ResourceModel.IsDel = false;
        ResourceModel.remark = "附件添加";
        objSendImage.AddFromResult(ResourceModel);        
    }
}
