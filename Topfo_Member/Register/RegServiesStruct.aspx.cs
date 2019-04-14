using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Tz888.BLL.Register;
using Tz888.Model.Register;
using Tz888.Common.DEncrypt;
using System.Security.Cryptography;


public partial class Register_RegServiesStruct : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {


            structid.SelectedIndex = 1;
            structid.Items.Insert(0, "--请选择机构--");
            Tz888.BLL.Union union = new Tz888.BLL.Union();
            DataTable dt = union.GetList("StructureName,StructureID", "SetStructureTab", "", 100);

            Tz888.Common.Common.ToBind(structid, dt, "StructureName", "StructureID");
            if (Request.QueryString["alt"] == "1")
            {
                ImageButton1.Visible = false;
                if (!string.IsNullOrEmpty(Request.QueryString["OrganID"]))
                {
                    getModel(int.Parse(Request.QueryString["OrganID"]));
                }
                else { Tz888.Common.MessageBox.ShowBack("参数有误。"); }


            }
            else { Update.Visible = false; }

        }
       

    }
    protected void getModel(int id)
    {
        Tz888.BLL.Register.SS_Agency_ServicesBLL dal=new SS_Agency_ServicesBLL();
        Tz888.Model.Register.SS_Agency_Services mode = dal.getModel("*", "SS_Agency_Services", "where OrganID="+id, 1);
        company.Value = mode.OrganName;
        this.ZoneSelectControl1.CountryID = mode.CountryCode.Trim();
        this.ZoneSelectControl1.ProvinceID = mode.ProvinceID.ToString();
        this.ZoneSelectControl1.CityID = mode.CityID.ToString();
        this.ZoneSelectControl1.CountyID = mode.Area.ToString();
        this.structid.SelectedValue = mode.OrganType.ToString();

        ServiesControl.ServiesBString = mode.ServiceBigtype + "|" + mode.ServiceSmalltype;
        capital.Value = mode.Bankroll.ToString();
        count.Value = mode.Turnover.ToString();
        scale.Value = mode.BusinessCount.ToString();
        createdate.Value = mode.FoundDate;
        directions.Value = mode.BusinessView;
        website.Value = mode.www;
        linkman.Value = mode.LinkName;
        linktel.Value = mode.Tel;
        email.Value = mode.Email;
        fex.Value = mode.FAX;
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Tz888.Model.Register.SS_Agency_Services model = new SS_Agency_Services();
        model.OrganName = company.Value;
        model.CountryCode = ZoneSelectControl1.CountryID;
        if (!string.IsNullOrEmpty(ZoneSelectControl1.ProvinceID))
        {
            model.ProvinceID = int.Parse(ZoneSelectControl1.ProvinceID);
        }
        if (!string.IsNullOrEmpty(ZoneSelectControl1.CityID))
        {
            model.CityID = int.Parse(ZoneSelectControl1.CityID);
        }
        if (!string.IsNullOrEmpty(ZoneSelectControl1.CountyID))
        {
            model.Area = int.Parse(ZoneSelectControl1.CountyID);
        }
        if (!string.IsNullOrEmpty(structid.SelectedValue))
        {
            model.OrganType = int.Parse(structid.SelectedValue);
        }
        string[] str = ServiesControl.ServicesBID.Split(',');
        model.ServiceBigtype = int.Parse(str[0]);
        model.ServiceSmalltype = ServiesControl.ServicesMID.ToString();
        if (!string.IsNullOrEmpty(scale.Value))
        {
            model.BusinessCount = int.Parse(scale.Value);
        }
        if (!string.IsNullOrEmpty(capital.Value))
        {
            model.Bankroll = int.Parse(capital.Value);
        }
        model.OrganID = int.Parse(Request.QueryString["OrganID"].ToString());
        model.FoundDate = createdate.Value;
        model.Turnover = count.Value;
        model.BusinessView = directions.Value;
        model.www = website.Value;
        model.LinkName = linkman.Value;
        model.Tel = linktel.Value;
        model.FAX = fex.Value;
        model.Email = email.Value;
        Tz888.BLL.Register.SS_Agency_ServicesBLL dal = new SS_Agency_ServicesBLL();
        bool stat = dal.SS_StrUpdate(model);

        if (stat)
        {
            Response.Redirect("../PayManage/ServiesRCList.aspx", true);
        }
        else { Tz888.Common.MessageBox.ShowBack("数据更新失败。"); }

    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        string loginName;
        string passWord;
        string companyname;//单位名称
        string country;//国家
        int province = 0;//省
               
        int city = 0;//市

        int xian = 0;//县

        int sid;//机构类别
        int serviesgig = 0;//服务大类
        string serviesmall;//服务小类
        int scale = 0;//企业规模
        int capital = 0;//注册资金
        string createdate;//企业创建时间
        string count;// 营业额

        string directions;//主营业务说明
        string website;//网址
        string linkman;//联系人

        string linktel;//联系电话
        string fex;//传真号码
        string email;//电子邮件


        loginName = this.usrname.Value;
        passWord = Request.Form["repwd"];
        companyname = Request.Form["company"];
        country = this.ZoneSelectControl1.CountryID.ToString();

        if (this.ZoneSelectControl1.CityID.ToString() != "")
        {
            city = int.Parse(this.ZoneSelectControl1.CityID.ToString());
        }

        if (this.ZoneSelectControl1.CountyID.ToString() != "")
        {
            xian = int.Parse(this.ZoneSelectControl1.CountyID.ToString());
        }
        if (this.ZoneSelectControl1.ProvinceID.ToString() != "")
        {
            province = int.Parse(this.ZoneSelectControl1.ProvinceID.ToString());
        }
        sid = Convert.ToInt32(structid.SelectedItem.Value);
        if (ServiesControl.ServicesBID.ToString() != "")
        {
            string[] Test = ServiesControl.ServicesBID.Split(',');
            string TestValue = Test[0].Trim();
            serviesgig = Convert.ToInt32(TestValue);
        }
        if (Request.Form["scale"].ToString() != "")
        {
            scale = int.Parse(Request.Form["scale"].ToString());
        }
        serviesmall = ServiesControl.ServicesMID.ToString();
        if (Request.Form["capital"].ToString() != "")
        {
            capital = int.Parse(Request.Form["capital"].ToString());
        }

        createdate = Request.Form["createdate"];
        count = Request.Form["count"];
        directions = Request.Form["directions"];
        website = Request.Form["website"];
        linkman = Request.Form["linkman"];
        linktel = Request.Form["linktel"];
        fex = Request.Form["fex"];
        email = Request.Form["email"];





        #region 验证提交的验证码并清空验证码
        ///--------------------------------------------------
        ///--验证提交的验证码并清空验证码
        ///--------------------------------------------------
        string vercode = Request.Form["vercode"];
        string strRndNum = "";
        //SESSION丢失
        if (Session["valationNo"] == null)
        {
            Response.Write("<script>alert('操作超时！请刷新页面！');</script>");
            return;
        }
        else
        {
            if (vercode.Trim() == "")
            {
                Response.Write("<script>alert('验证码不能为空，请重新提交！');</script>");
                return;
            }
            else
            {
                strRndNum = Session["valationNo"].ToString();
                if (vercode.Trim() != "" && vercode.ToLower().Trim() == strRndNum.ToLower())
                {
                    Session["valationNo"] = "";
                }
                else
                {
                    Response.Write("<script>alert('验证码错误，请重新提交！');</script>");
                    return;
                }
            }
        }
        #endregion


        //注册信息
        SHA1 sha1 = SHA1.Create();
        byte[] passWord2 = sha1.ComputeHash(Encoding.Unicode.GetBytes(passWord.Trim()));

        LoginInfoModel model = new LoginInfoModel();

        if (Request.Cookies["adv_cpa"] != null)
        {
            HttpCookie logCook = Request.Cookies["adv_cpa"];
            model.adsiteID = logCook.Value.ToString();

            model.autoReg = 2;
        }

        model.LoginName = loginName;
        model.Password = passWord2;
        model.RoleName = "0";//会员
        model.ManageTypeID = "2007";
        model.MemberGradeID = "1001";
        model.IsCheckUp = false;
        model.Email = email;
        model.Tel = linktel;
        model.CompanyName = companyname;
        model.NickName = " ";
        model.PWDAnswere = "";
        model.PWDQuestion = "";
        model.RequirInfo = "";

        //--------会员信息
        MemberInfoModel memberModel = new MemberInfoModel();
        memberModel.LoginName = loginName;
        memberModel.Email = email;
        memberModel.ManageTypeID = "2007";
        //memberModel.RequirInfo = requirInfo;
        memberModel.Tel = linktel;
        memberModel.Mobile = linktel;
        memberModel.Birthday = DateTime.Now;

        // -------------专业服务机构
        Tz888.Model.Register.SS_Agency_Services service = new SS_Agency_Services();
        service.LoginName = loginName;
        service.OrganName = companyname;
        service.OrganType = sid;
        service.CountryCode = country;
        service.ProvinceID = province;
        service.CityID = city;
        service.Area = xian;
        service.ServiceBigtype = serviesgig;
        service.ServiceSmalltype = serviesmall;
        service.BusinessCount = scale;
        service.BusinessView = directions;
        service.Bankroll = capital;
        service.FoundDate = createdate;
        service.Turnover = count;
        service.www = website;
        service.LinkName = linkman;
        service.Tel = linktel;
        service.FAX = fex;
        service.Email = email;
        service.Regdate = DateTime.Now;



        LoginInfoBLL loginfo = new LoginInfoBLL();
        Tz888.BLL.Register.SS_Agency_ServicesBLL smode = new SS_Agency_ServicesBLL();
        MemberInfoBLL member = new MemberInfoBLL();
        try
        {
            //机构服务表

            try
            { smode.AgencyAdd(service); }
            catch (System.Data.SqlClient.SqlException ex)
            {
                throw (new Exception(ex.Message));
            }
            //向注册表写数据


            try
            { loginfo.LogInfoAdd(model); }
            catch (System.Data.SqlClient.SqlException ex)
            {
                throw (new Exception(ex.Message));
            }
          

           // 会员信息
            int i = member.MemberMessage_Insert(memberModel);

            string encryEmail = Server.UrlEncode(DEncrypt.Encrypt(email));
            string encryLogname = Server.UrlEncode(DEncrypt.Encrypt(loginName));
            string act = Server.UrlEncode(DEncrypt.Encrypt("register"));
            string strPass = Server.UrlEncode(DEncrypt.Encrypt(passWord));
            string ValidUrl = "ValidSuccessGov.aspx?email=" + encryEmail + "&logname=" + encryLogname + "&act=" + act+"&PassWord="+strPass;

            Response.Redirect(ValidUrl, true);
        }
        catch (Exception exp)
        {
            Tz888.Common.MessageBox.ShowBack("数据提交时出错，注册失败。");
        }
        finally
        {
            string encryEmail = Server.UrlEncode(DEncrypt.Encrypt(email));
            string encryLogname = Server.UrlEncode(DEncrypt.Encrypt(loginName));
            string act = Server.UrlEncode(DEncrypt.Encrypt("register"));
            string strPass = Server.UrlEncode(DEncrypt.Encrypt(passWord));
            string ValidUrl = "ValidSuccessGov.aspx?email=" + encryEmail + "&logname=" + encryLogname + "&act=" + act+"&PassWord="+strPass;
            Response.Redirect(ValidUrl, true);
        }
    }

}

