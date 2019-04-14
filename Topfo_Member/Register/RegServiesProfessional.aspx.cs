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


public partial class Register_RegServiesProfessional : System.Web.UI.Page
{
    public string p;
    public string introStr;
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
                getModel(int.Parse(Request.QueryString["PSID"]));

            }
            else { Update.Visible = false; }

        }

    }
    protected void getModel(int id)
    {
        Tz888.BLL.Info.ReleaseInsertBLL dal=new Tz888.BLL.Info.ReleaseInsertBLL();
        Tz888.Model.SS_ProfessionalServicesModel model = dal.getProModel(id);
        contactname.Value = model.RealName;
        comname.Value = model.NnitName;
        this.ZoneSelectControl1.CountryID=model.CountryCode.ToString().Trim();
        this.ZoneSelectControl1.ProvinceID = model.ProvinceID.ToString();
        this.ZoneSelectControl1.CityID = model.CityID.ToString();
        this.ZoneSelectControl1.CountyID = model.AreaID.ToString();
        contacttitle.Value = model.Job;
        structid.SelectedValue = model.TalentType.ToString();
        ServiesControl.ServiesBString = model.ServiceBigtype + "|" + model.ServiceSmalltype;
        Resume.Value = model.Resume;
        Specialty.Value = model.Specialty;
        BefCase.Value = model.BefCase;
        if (!string.IsNullOrEmpty(model.Tel))
        {
            string[] str = model.Tel.Split('-');
            country.Value = str[0];
            zone.Value = str[1];
            phone.Value = str[2];
        }
        else { country.Value = ""; zone.Value = ""; phone.Value = ""; }
        fax.Value = model.FAX;
        mobile.Value = model.Mobile;
        address.Value = model.Address;
        txtAds1.Text = model.Pic;
        email.Value = model.Email;
        p = model.Pic;

    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Tz888.Model.Register.SS_ProfessionalServices fesModel = new Tz888.Model.Register.SS_ProfessionalServices();
        fesModel.RealName = contactname.Value;
        fesModel.NnitName = comname.Value;
        fesModel.CountryCode = this.ZoneSelectControl1.CountryID.ToString().Trim();
        if (!string.IsNullOrEmpty(this.ZoneSelectControl1.ProvinceID.ToString()))
        {
            fesModel.ProvinceID = int.Parse(this.ZoneSelectControl1.ProvinceID.ToString());
        }
        if (!string.IsNullOrEmpty(this.ZoneSelectControl1.CityID.ToString()))
        {
            fesModel.CityID =int.Parse( this.ZoneSelectControl1.CityID.ToString());
        }
        if (!string.IsNullOrEmpty(this.ZoneSelectControl1.CountyID.ToString()))
        {
            fesModel.AreaID = int.Parse(this.ZoneSelectControl1.CountyID.ToString());
        }
        fesModel.Job = contacttitle.Value;
        if(!string.IsNullOrEmpty(structid.SelectedValue))
        { 
            fesModel.TalentType =int.Parse((structid.SelectedValue));
        }
        if (ServiesControl.ServicesBID.ToString() != "")
        {
            string[] str = ServiesControl.ServicesBID.Split(',');

           fesModel.ServiceBigtype = int.Parse(str[0].ToString());
        }
      fesModel.ServiceSmalltype = ServiesControl.ServicesMID.ToString();
      fesModel.Resume = Resume.Value;
      fesModel.Specialty = Specialty.Value;
      fesModel.Tel = country.Value + "-" +zone.Value + "-" + phone.Value;
      fesModel.BefCase = BefCase.Value;
      fesModel.FAX = fax.Value;
      fesModel.Mobile = mobile.Value;
      fesModel.Address = address.Value;
      if (txtAds1.Text.Trim() != null && txtAds1.Text.Trim() != "")
      {
          fesModel.Pic = txtAds1.Text;
      }
      else { fesModel.Pic = "Img/photo.jpg"; }
      fesModel.Email = email.Value;
      fesModel.PSID = int.Parse(Request.QueryString["PSID"].ToString());
      Tz888.BLL.Register.SS_ProfessionalServices ss = new Tz888.BLL.Register.SS_ProfessionalServices();
      bool stat = ss.SS_ProUpdate(fesModel);
      if (stat)
      {
          Response.Redirect("../PayManage/ServiesRCList.aspx", true);
      }
      else { Tz888.Common.MessageBox.ShowBack("数据更新失败。"); }

    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        string loginName;//帐号
        string passWord;//密码
        string contactname;//真实姓名
        string groupName;//单位名称
        string countrycode;//国家
        int province=0;//省

        int  city=0;//城市
        int  area=0;//县

        string contacttitle;//职务
        int sid=0;//人才类别
        int ServiesBig=0;//服务大类
        string ServiesSmall;//服务小类
        string Resume;//个人简历

        string Specialty;//个人特长
        string BefCase;//成功案例
        string phone;//固定电话
        string zone;//固定电话城市区号
        string country;//固定电话国家编号
        string fax;//传真
        string mobile;//手机
        string address;//地址
        string txtAds1;//相片地址
        string email;
        string tel;


        loginName = this.usrname.Value;
        passWord = Request.Form["repwd"];
        contactname = Request.Form["contactname"];
        groupName = Request.Form["comname"];
        countrycode = this.ZoneSelectControl1.CountryID;
        if (this.ZoneSelectControl1.ProvinceID.ToString() != "")
        {
            province = int.Parse(this.ZoneSelectControl1.ProvinceID.ToString());
        }
        if (this.ZoneSelectControl1.CityID.ToString() != "")
        {
            city = int.Parse(this.ZoneSelectControl1.CityID.ToString());
        }
        if (this.ZoneSelectControl1.CountyID.ToString() != "")
        {
            area = int.Parse(this.ZoneSelectControl1.CountyID.ToString());
        }
        contacttitle = Request.Form["contacttitle"];
        sid = Convert.ToInt32(structid.SelectedItem.Value);

        if (ServiesControl._ServicesBID.ToString() != "")
        {
            string []str=ServiesControl._ServicesBID.Split(',');

            ServiesBig = int.Parse(str[0].ToString());
        }
        ServiesSmall = ServiesControl._ServicesMID.ToString();
        Resume = Request.Form["Resume"];
        Specialty = Request.Form["Specialty"];
        BefCase = Request.Form["BefCase"];
        tel = Request.Form["phone"];
        zone = Request.Form["zone"];
        country = Request.Form["country"];
        fax = this.fax.Value;

  mobile = Request.Form["mobile"];
  address = Request.Form["address"];
  txtAds1 = Request.Form["txtAds1"];
  email = Request.Form["email"];
   
        phone = country + "-" + zone + "-" + tel;



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
        model.LoginName = loginName;
        model.Password = passWord2;

        model.RoleName = "0";//会员
        model.ManageTypeID = "2006";
        model.MemberGradeID = "1001";
        model.IsCheckUp = false;
        model.Email = email;
        model.Tel = phone;



        //--------会员信息
        MemberInfoModel memberModel = new MemberInfoModel();
        memberModel.LoginName = loginName;
        memberModel.ManageTypeID = "2006";
        memberModel.Email = email;
        memberModel.Tel = phone;
        memberModel.Mobile = mobile;
        memberModel.CountryCode = country;
        memberModel.CountyID = city.ToString();
        memberModel.ProvinceID = province.ToString();
        memberModel.Address = address;
        memberModel.Birthday = DateTime.Now;


        Tz888.Model.Register.SS_ProfessionalServices fesModel = new Tz888.Model.Register.SS_ProfessionalServices();
        fesModel.LoginName = loginName;
        fesModel.NnitName = groupName;
        fesModel.CountryCode = countrycode;
        fesModel.CityID = city;
        fesModel.ProvinceID = province;
        fesModel.AreaID = area;
        fesModel.Job = contacttitle;
        fesModel.TalentType = sid;
        fesModel.ServiceBigtype = ServiesBig;
        fesModel.ServiceSmalltype = ServiesSmall;
        fesModel.Resume = Resume;
        fesModel.Specialty = Specialty;
        fesModel.BefCase = BefCase;
        fesModel.Tel = phone;
        fesModel.Mobile = mobile;
        fesModel.FAX = fax;
        fesModel.Email = email;
        fesModel.Address = address;
        if (txtAds1 != null && txtAds1 != "")
        {
            fesModel.Pic = txtAds1;
        }
        else
        {
            fesModel.Pic = "Img/photo.jpg";
        }
        fesModel.RegDate = DateTime.Now;
        fesModel.RealName = contactname;
       
        LoginInfoBLL loginfo = new LoginInfoBLL();
        Tz888.BLL.Register.SS_ProfessionalServices pro = new Tz888.BLL.Register.SS_ProfessionalServices();
        MemberInfoBLL member = new MemberInfoBLL();
        //向注册表写数据


        try
        {   loginfo.LogInfoAdd(model);
            
            //  注册 
            pro.ProfessionalAdd(fesModel);

            try
            {  
                int i = member.MemberMessage_Insert(memberModel);
              
            }
            catch (System.Data.SqlClient.SqlException exp)
            {
                throw (new Exception(exp.Message));
            }
        
           // 会员信息
           



            string encryEmail = Server.UrlEncode(DEncrypt.Encrypt(email));
            string encryLogname = Server.UrlEncode(DEncrypt.Encrypt(loginName));
            string act = Server.UrlEncode(DEncrypt.Encrypt("register"));
            string ValidUrl = "ValidSuccessEnter.aspx?email=" + encryEmail + "&logname=" + encryLogname + "&act=" + act;

            Response.Redirect(ValidUrl, true);
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
            Tz888.Common.MessageBox.ShowBack("数据提交时出错,注册失败。");
        }
        finally
        {
            string encryEmail = Server.UrlEncode(DEncrypt.Encrypt(email));
            string encryLogname = Server.UrlEncode(DEncrypt.Encrypt(loginName));
            string act = Server.UrlEncode(DEncrypt.Encrypt("register"));
            string ValidUrl = "ValidSuccessGov.aspx?email=" + encryEmail + "&logname=" + encryLogname + "&act=" + act;
            Response.Redirect(ValidUrl, true);
        }

    }
}
