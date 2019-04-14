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

public partial class helper_Test1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.ViewState["MemberLoginName"] ="topfo001";
        if (!IsPostBack)
        {
            this.ViewState["CustomType"] = "";
            this.ViewState["Type"] = "";
            this.ViewState["Genre"] = "";
            this.ViewState["Money"] = "";
            this.ViewState["Calling"] = "";
            this.ViewState["SmallCalling"] = "";
            this.ViewState["City"] = "";
            this.ViewState["Keyword"] = "";
            this.ViewState["ID"] = "";

            BindCooperationDemandType();
            BindSetCapital();
            forPageload();
            SetBindSetCapital();
            if (Convert.ToString(Request.QueryString["ID"]) != null)
            {
                this.ViewState["ID"] = Request.QueryString["ID"].ToString();
            }
            else
            {
                this.ViewState["ID"] = "";
            }

            if (Request.QueryString["tag"] != null)
            {
                this.ViewState["tag"] = Request.QueryString["tag"].ToString();
            }
            else
            {
                this.ViewState["tag"] = "Add";
            }
            hidType.Value = ViewState["tag"].ToString();
            if (this.ViewState["tag"].ToString() == "update")
            {
                Hidden1.Value = Request["CustomType"].ToString();
                //查询
                string Criteria = "LoginName = '" + Page.User.Identity.Name + "' and id=" + this.ViewState["ID"].ToString();
                //string Criteria = "LoginName = '" + "hellocindy" + "' and id=" + this.ViewState["ID"].ToString();
                Tz888.SQLServerDAL.Conn obj = new Tz888.SQLServerDAL.Conn();
                DataTable dt1 = obj.GetList("CustomInfoTab", "*", "ID", 1, 1, 0, 1, Criteria);
                DataRow dr = dt1.Rows[0];
                FillData(dr);
            }
        }
        //注册JS
        this.lstIndustryBLeft.Attributes.Add("ondblclick", "moveOver(document.getElementById('lstIndustryBLeft'),document.getElementById('lstIndustryBRight'));");
        this.lstIndustryBRight.Attributes.Add("ondblclick", "removeMe(document.getElementById('lstIndustryBRight'));");

        this.lstProvinceLeft.Attributes.Add("ondblclick", "moveOver(document.getElementById('lstProvinceLeft'),document.getElementById('lstProvinceRight'));");
        this.lstProvinceRight.Attributes.Add("ondblclick", "removeMe(document.getElementById('lstProvinceRight'));");
        //政府招商
        this.lisTzhy.Attributes.Add("ondblclick", "moveOver(document.getElementById('lisTzhy'),document.getElementById('lisTzhyRight'));");
        this.lisTzhyRight.Attributes.Add("ondblclick", "removeMe(document.getElementById('lisTzhyRight'));");

        this.lisTzQy.Attributes.Add("ondblclick", "moveOver(document.getElementById('lisTzQy'),document.getElementById('lisTzQyRight'));");
        this.lisTzQyRight.Attributes.Add("ondblclick", "removeMe(document.getElementById('lisTzQyRight'));");

        this.lisTzhyQy.Attributes.Add("ondblclick", "moveOver(document.getElementById('lisTzhyQy'),document.getElementById('lisTzhyQyRight'));");
        this.lisTzhyQyRight.Attributes.Add("ondblclick", "removeMe(document.getElementById('lisTzhyQyRight'));");

        this.lisTzqyQy.Attributes.Add("ondblclick", "moveOver(document.getElementById('lisTzqyQy'),document.getElementById('lisTzqyQyRight'));");
        this.lisTzqyQyRight.Attributes.Add("ondblclick", "removeMe(document.getElementById('lisTzqyQyRight'));");

        //资本资源        
        //投资行业 calling
        string onClickValue = "FillToTxtFeild(document.getElementById('lstIndustryBRight'), document.getElementById('hidZyCalling'),document.getElementById('hidZyCallingTxt'), '|');";
        //投资省市 city
        onClickValue += "FillToTxtFeild(document.getElementById('lstProvinceRight'), document.getElementById('hidZyCity'),document.getElementById('hidZyCityTxt'), '|');";

        //政府招商
        onClickValue += "FillToTxtFeild(document.getElementById('lisTzhyRight'), document.getElementById('hidZfCalling'), document.getElementById('hidZfCallingTxt'),'|');";
        onClickValue += "FillToTxtFeild(document.getElementById('lisTzQyRight'), document.getElementById('hidZfCity'), document.getElementById('hidZfCityTxt'),'|');";
        //企业项目
        onClickValue += "FillToTxtFeild(document.getElementById('lisTzhyQyRight'), document.getElementById('hidQyCalling'), document.getElementById('hidQyCallingTxt'),'|');";
        onClickValue += "FillToTxtFeild(document.getElementById('lisTzqyQyRight'), document.getElementById('hidQyCity'), document.getElementById('hidQyCityTxt'),'|');";

        btnAdd.Attributes.Add("onClick", onClickValue);
    }

    private void BindCooperationDemandType()
    {
        this.chTzfsZb.DataSource = Tz888.BLL.Info.Common.GetCooperationDemandList("Capital");
        this.chTzfsZb.DataTextField = "CooperationDemandName";
        this.chTzfsZb.DataValueField = "CooperationDemandTypeID";
        this.chTzfsZb.DataBind();
    }

    /// <summary>
    /// 设置融资金额
    /// </summary>
    private void BindSetCapital()
    {
        Tz888.BLL.Common.SetCapitalBLL bll = new Tz888.BLL.Common.SetCapitalBLL();
        chkCapital.DataSource = bll.GetList();
        chkCapital.DataTextField = "CapitalName";
        chkCapital.DataValueField = "CapitalID";
        chkCapital.DataBind();
    }

    private void SetBindSetCapital()
    {
        Tz888.BLL.Common.SetCapitalBLL bll = new Tz888.BLL.Common.SetCapitalBLL();
        ckJkjeQy.DataSource = bll.GetList();
        ckJkjeQy.DataTextField = "CapitalName";
        ckJkjeQy.DataValueField = "CapitalID";
        ckJkjeQy.DataBind();
        //rbtnCapital.SelectedIndex = 0; 选定第一个
    }

    private void forPageload()
    {
        Tz888.BLL.PageIniControl CustomList = new Tz888.BLL.PageIniControl();


        //大行业 资本资源

        DataTable dvIndustryB = CustomList.IndustryBDataBind();
        this.lstIndustryBLeft.DataSource = dvIndustryB;
        this.lstIndustryBLeft.DataBind();

        //城市
        DataTable dvProvince = CustomList.ProvinceDataBind(null);
        DataView dv = dvProvince.DefaultView;
        dv.RowFilter = "ProvinceID<>0000";
        lstProvinceLeft.DataSource = dv;
        lstProvinceLeft.DataBind();

        #region 政府招商
        //投资行业  政府招商
        this.lisTzhy.DataSource = dvIndustryB;
        this.lisTzhy.DataBind();

        //投资区域 政府招商
        dv.RowFilter = "ProvinceID<>0000";
        lisTzQy.DataSource = dv;
        lisTzQy.DataBind();

        #endregion

        #region 企业招商
        //投资行业
        lisTzhyQy.DataSource = dvIndustryB; ;
        lisTzhyQy.DataBind();

        //投资区域
        dv.RowFilter = "ProvinceID<>0000";
        lisTzqyQy.DataSource = dv;
        lisTzqyQy.DataBind();

        #endregion
    }

    private void FillData(DataRow dr)
    {
        //  this.ViewState["CustomType"] = dr["CustomType"].ToString() ;
        this.ViewState["Title"] = dr["Title"].ToString();
        this.ViewState["CustomCyc"] = dr["CustomCyc"].ToString();
        this.ViewState["ItemCount"] = dr["ItemCount"].ToString();//每次发送数量


        this.ViewState["Email"] = dr["Email"].ToString();
        this.ViewState["Accept"] = dr["Accept"].ToString();//是否接收中国招商投资网的订阅信息邮件 
        this.ViewState["ValidateTerm"] = dr["ValidateTerm"].ToString();//订阅周期


        //2010-06-23修改
        string CustomType = Request.QueryString["CustomType"].ToString();
        #region 政府招商
        if (CustomType == "0")   //政府招商
        {
            //投资行业
            if (dr["Calling"].ToString() != "")
            {
                this.lisTzhyRight.Items.Clear();
                string[] arrType = dr["Calling"].ToString().Split('|');
                string[] arrTypeTxt = dr["CallingTxt"].ToString().Split('|');
                ArrayList arrTyp = new ArrayList();
                for (int i = 0; i < arrType.Length; i++) //(int i = 0; i < arrType.Length; i++)
                {
                    arrTyp.Add(arrType[i]);
                    ListItem listItem = new ListItem();
                    listItem.Value = arrType[i].Trim();
                    listItem.Text = GetCallingTxt(arrType[i].Trim());
                    this.lisTzhyRight.Items.Add(listItem);

                    if (dr["CustomType"].ToString() == "3")
                    {
                        listItem.Value = arrType[i].Trim();
                        listItem.Text = GetCallingTxtCarveout(arrType[i].Trim());
                        this.lisTzhyRight.Items.Add(listItem);
                    }

                    if (dr["CustomType"].ToString() == "4")
                    {
                        listItem.Value = arrType[i].Trim();
                        listItem.Text = GetCallingTxtOpportunity(arrType[i].Trim());
                        this.lisTzhyRight.Items.Add(listItem);
                    }

                }
            }

            ////投资区域
            if (dr["City"].ToString() != "")
            {
                this.lisTzQyRight.Items.Clear();
                string[] arrType = dr["City"].ToString().Split('|');
                string[] arrTypeTxt = dr["CityTxt"].ToString().Split('|');
                ArrayList arrTyp = new ArrayList();
                for (int i = 0; i < arrType.Length; i++) //(int i = 0; i < arrType.Length; i++)
                {
                    arrTyp.Add(arrType[i]);
                    ListItem listItem = new ListItem();
                    listItem.Value = arrType[i].Trim();
                    listItem.Text = GetCityTxt(arrType[i].Trim());
                    this.lisTzQyRight.Items.Add(listItem);

                    if (dr["CustomType"].ToString() == "3")
                    {
                        listItem.Value = arrType[i].Trim();
                        listItem.Text = GetCallingTxtCarveout(arrType[i].Trim());
                        this.lisTzQyRight.Items.Add(listItem);
                    }

                    if (dr["CustomType"].ToString() == "4")
                    {
                        listItem.Value = arrType[i].Trim();
                        listItem.Text = GetCallingTxtOpportunity(arrType[i].Trim());
                        this.lisTzQyRight.Items.Add(listItem);
                    }

                }
            }
        }
        #endregion

        #region 资本资源
        if (CustomType == "1")
        {
            //投资方式
            if (dr["CooperationDemandTypeID"].ToString() != "")
            {
                string[] arrType = dr["CooperationDemandTypeID"].ToString().Split('|');
                ArrayList arrTyp = new ArrayList();
                for (int i = 0; i < arrType.Length; i++)
                {
                    if (arrType[i].Trim() != "")
                    {
                        arrTyp.Add(arrType[i]);
                    }
                }
                for (int i = 0; i < this.chTzfsZb.Items.Count; i++)
                {
                    this.chTzfsZb.Items[i].Selected = arrTyp.Contains(this.chTzfsZb.Items[i].Value.Trim());
                }
            }

            //单项目可投资金额
            if (dr["Money"].ToString() != "")
            {
                string[] arrType = dr["Money"].ToString().Split('|');
                ArrayList arrTyp = new ArrayList();
                for (int i = 0; i < arrType.Length; i++)
                {
                    if (arrType[i].Trim() != "")
                    {
                        arrTyp.Add(arrType[i]);
                    }
                }
                for (int i = 0; i < this.chkCapital.Items.Count; i++)
                {
                    //this.chkCapital.Items[i].Selected = arrTyp.Contains(this.chkCapital.Items[i].Value.Trim());
                    for (int j = 0; j < arrType.Length; j++)
                    {
                        if (int.Parse(chkCapital.Items[i].Value.Trim()) == int.Parse(arrType[j].Trim()))
                        {
                            chkCapital.Items[i].Selected = true;
                        }
                    }

                }
            }


            //投资行业
            if (dr["Calling"].ToString() != "")
            {
                this.lstIndustryBRight.Items.Clear();
                string[] arrType = dr["Calling"].ToString().Split('|');
                string[] arrTypeTxt = dr["CallingTxt"].ToString().Split('|');
                ArrayList arrTyp = new ArrayList();
                for (int i = 0; i < arrType.Length; i++) //(int i = 0; i < arrType.Length; i++)
                {
                    arrTyp.Add(arrType[i]);
                    ListItem listItem = new ListItem();
                    listItem.Value = arrType[i].Trim();
                    listItem.Text = GetCallingTxt(arrType[i].Trim());
                    this.lstIndustryBRight.Items.Add(listItem);

                    if (dr["CustomType"].ToString() == "3")
                    {
                        listItem.Value = arrType[i].Trim();
                        listItem.Text = GetCallingTxtCarveout(arrType[i].Trim());
                        this.lstIndustryBRight.Items.Add(listItem);
                    }

                    if (dr["CustomType"].ToString() == "4")
                    {
                        listItem.Value = arrType[i].Trim();
                        listItem.Text = GetCallingTxtOpportunity(arrType[i].Trim());
                        this.lstIndustryBRight.Items.Add(listItem);
                    }

                }
            }

            ////投资区域
            if (dr["City"].ToString() != "")
            {
                this.lstProvinceRight.Items.Clear();
                string[] arrType = dr["City"].ToString().Split('|');
                string[] arrTypeTxt = dr["CityTxt"].ToString().Split('|');
                ArrayList arrTyp = new ArrayList();
                for (int i = 0; i < arrType.Length; i++) //(int i = 0; i < arrType.Length; i++)
                {
                    arrTyp.Add(arrType[i]);
                    ListItem listItem = new ListItem();
                    listItem.Value = arrType[i].Trim();
                    listItem.Text = GetCityTxt(arrType[i].Trim());
                    this.lstProvinceRight.Items.Add(listItem);

                    if (dr["CustomType"].ToString() == "3")
                    {
                        listItem.Value = arrType[i].Trim();
                        listItem.Text = GetCallingTxtCarveout(arrType[i].Trim());
                        this.lstProvinceRight.Items.Add(listItem);
                    }

                    if (dr["CustomType"].ToString() == "4")
                    {
                        listItem.Value = arrType[i].Trim();
                        listItem.Text = GetCallingTxtOpportunity(arrType[i].Trim());
                        this.lstProvinceRight.Items.Add(listItem);
                    }

                }
            }

        }
        #endregion

        #region 企业项目
        else if (CustomType == "2")
        {
            //融资类型
            if (dr["Type"].ToString() != "")
            {
                string[] arrType = dr["Type"].ToString().Split('|');
                ArrayList arrTyp = new ArrayList();
                for (int i = 0; i < arrType.Length; i++)
                {
                    if (arrType[i].Trim() != "")
                    {
                        arrTyp.Add(arrType[i]);
                    }
                }
                for (int i = 0; i < this.ckRzlxQy.Items.Count; i++)
                {
                    for (int j = 0; j < arrType.Length; j++)
                    {
                        if (int.Parse(ckRzlxQy.Items[i].Value.Trim()) == int.Parse(arrType[j].Trim()))
                        {
                            ckRzlxQy.Items[i].Selected = true;
                        }
                    }
                    //this.ckRzlxQy.Items[i].Selected = arrTyp.Contains(this.ckRzlxQy.Items[i].Value.Trim());
                }
            }

            //投资行业
            if (dr["Calling"].ToString() != "")
            {
                this.lisTzhyQyRight.Items.Clear();
                string[] arrType = dr["Calling"].ToString().Split('|');
                string[] arrTypeTxt = dr["CallingTxt"].ToString().Split('|');
                ArrayList arrTyp = new ArrayList();
                for (int i = 0; i < arrType.Length; i++) //(int i = 0; i < arrType.Length; i++)
                {
                    arrTyp.Add(arrType[i]);
                    ListItem listItem = new ListItem();
                    listItem.Value = arrType[i].Trim();
                    listItem.Text = GetCallingTxt(arrType[i].Trim());
                    this.lisTzhyQyRight.Items.Add(listItem);

                    if (dr["CustomType"].ToString() == "3")
                    {
                        listItem.Value = arrType[i].Trim();
                        listItem.Text = GetCallingTxtCarveout(arrType[i].Trim());
                        this.lisTzhyQyRight.Items.Add(listItem);
                    }

                    if (dr["CustomType"].ToString() == "4")
                    {


                        listItem.Value = arrType[i].Trim();
                        this.lisTzhyQyRight.Items.Add(listItem);
                    }

                }
            }

            ////投资区域
            if (dr["City"].ToString() != "")
            {
                this.lisTzqyQyRight.Items.Clear();
                string[] arrType = dr["City"].ToString().Split('|');
                string[] arrTypeTxt = dr["CityTxt"].ToString().Split('|');
                ArrayList arrTyp = new ArrayList();
                for (int i = 0; i < arrType.Length; i++) //(int i = 0; i < arrType.Length; i++)
                {
                    arrTyp.Add(arrType[i]);
                    ListItem listItem = new ListItem();
                    listItem.Value = arrType[i].Trim();
                    listItem.Text = GetCityTxt(arrType[i].Trim());
                    this.lisTzqyQyRight.Items.Add(listItem);

                    if (dr["CustomType"].ToString() == "3")
                    {
                        listItem.Value = arrType[i].Trim();
                        listItem.Text = GetCallingTxtCarveout(arrType[i].Trim());
                        this.lisTzqyQyRight.Items.Add(listItem);
                    }

                    if (dr["CustomType"].ToString() == "4")
                    {
                        listItem.Value = arrType[i].Trim();
                        listItem.Text = GetCallingTxtOpportunity(arrType[i].Trim());
                        this.lisTzqyQyRight.Items.Add(listItem);
                    }

                }
            }
            //借款金额
            if (dr["Money"].ToString() != "")
            {
                string[] arrType = dr["Money"].ToString().Split('|');
                ArrayList arrTyp = new ArrayList();
                for (int i = 0; i < arrType.Length; i++)
                {
                    if (arrType[i].Trim() != "")
                    {
                        arrTyp.Add(arrType[i]);
                    }
                }
                for (int i = 0; i < this.ckJkjeQy.Items.Count; i++)
                {
                    //this.chkCapital.Items[i].Selected = arrTyp.Contains(this.chkCapital.Items[i].Value.Trim());
                    for (int j = 0; j < arrType.Length; j++)
                    {
                        if (int.Parse(ckJkjeQy.Items[i].Value.Trim()) == int.Parse(arrType[j].Trim()))
                        {
                            ckJkjeQy.Items[i].Selected = true;
                        }
                    }

                }
            }

        }
        #endregion

        #region
        //关键字
        this.txtKey.Text = dr["Keyword"].ToString();
        //发布时间
        for (int i = 0; i < ddlValidateTerm.Items.Count; i++)
        {
            if (ddlValidateTerm.Items[i].Value == dr["ValidateTerm"].ToString())
            {
                ddlValidateTerm.Items[i].Selected = true;
            }
        }
        #endregion

        #region 根据参数改变样式
        if (CustomType == "0")
        {
            div0.Attributes["class"] = "btn_on";
            div1.Attributes["class"] = "";
            div2.Attributes["class"] = "";
            panel0.Style["display"] = "block";
            panel1.Style["display"] = "none";
            panel2.Style["display"] = "none";
        }
        else if (CustomType == "1")
        {
            div1.Attributes["class"] = "btn_on";
            div0.Attributes["class"] = "";
            div2.Attributes["class"] = "";
            panel1.Style["display"] = "block";
            panel0.Style["display"] = "none";
            panel2.Style["display"] = "none";
        }
        else if (CustomType == "2")
        {
            div2.Attributes["class"] = "btn_on";
            div0.Attributes["class"] = "";
            div1.Attributes["class"] = "";
            panel2.Style["display"] = "block";
            panel1.Style["display"] = "none";
            panel0.Style["display"] = "none";
        }
        #endregion
    }
    #region 修改时要绑定的某些信息



    private string GetCallingTxt(string CallingValue)
    {
        Tz888.BLL.Common.DictionaryInfoBLL obj1 = new Tz888.BLL.Common.DictionaryInfoBLL();
        return obj1.GetDetail(CallingValue);
    }

    private string GetCallingTxtCarveout(string CallingValue)
    {
        Tz888.BLL.Common.DictionaryInfoBLL obj2 = new Tz888.BLL.Common.DictionaryInfoBLL();
        return obj2.GetDetailCarveout(CallingValue);
    }

    private string GetCallingTxtOpportunity(string CallingValue)
    {
        Tz888.BLL.Common.DictionaryInfoBLL obj3 = new Tz888.BLL.Common.DictionaryInfoBLL();
        return obj3.GetDetailOpportunity(CallingValue);
    }

    private string GetCallingTxtExhibition(string CallingValue)
    {
        Tz888.BLL.Common.DictionaryInfoBLL obj4 = new Tz888.BLL.Common.DictionaryInfoBLL();
        return obj4.GetIndustryExhibitionName(CallingValue);
    }

    private string GetCityTxt(string Cityvalue)
    {
        Tz888.BLL.Common.DictionaryInfoBLL obj5 = new Tz888.BLL.Common.DictionaryInfoBLL();
        return obj5.GetProvinceName(Cityvalue);
    }
    #endregion

    #region 添加订阅保存session
    private void MackAddTable()
    {
        #region 变量定义
        string strCustomType = this.Hidden1.Value.ToString();// this.ViewState["CustomType"].ToString();
        string strCustomTypeName = "政府招商";
        switch (strCustomType)
        {
            case "0":
                strCustomTypeName = "政府招商";
                break;
            case "1":
                strCustomTypeName = "资本项目";
                break;
            case "2":
                strCustomTypeName = "企业项目";
                break;
            case "3":
                strCustomTypeName = "资讯信息";
                break;
            default:
                strCustomTypeName = "资本项目";
                break;
        }
        /*2010-06-17修改*/
        Tz888.BLL.CustomInfoBLL BLL = new Tz888.BLL.CustomInfoBLL();
        Tz888.Model.CustomInfoModel customInfo = new Tz888.Model.CustomInfoModel();

        //customInfo.Accept   是否接收邮件默认为1


        string strTitle = strCustomTypeName + System.DateTime.Now.ToString();
        this.ViewState["title"] = strTitle;
        string strType = "";

        string strGenre = "";
        string strMoney = "0";
        string strCalling = "";
        string strCallingTxt = "";
        string strSmallCalling = "";
        string strSmallCallingTxt = "";
        string strCity = "";
        string strCityTxt = "";
        string strKeyword = "";
        int iValidateTerm = 0;//有效时间
        string strCurrency = "";
        string strCooperationDemandTypeID = "";//合作类型


        byte bAccept = 1;
        int iCustomCyc = 2;
        int iItemCount = 10;
        string strEmail = "";
        //投资阶段
        string strStageForenterpriseDevelop = "";
        //融资对象
        string strfinancingObject = "";
        string strtrade = ""; //投资行业
        #endregion

        #region  变量赋值

        #region 政府招商
        if (strCustomType == "0")   //政府招商
        {

            //投资行业
            strCalling = hidZfCalling.Value.Trim();
            strCallingTxt = hidZfCallingTxt.Value;

            //投资区域
            strCity = hidZfCity.Value.Trim();
            strCityTxt = hidZfCityTxt.Value.Trim();

        }
        #endregion

        #region 资本资源
        else if (strCustomType == "1")
        {

            //单项目可投资金额            
            for (int i = 0; i < this.chkCapital.Items.Count; i++)
            {
                if (this.chkCapital.Items.Count == 0)
                {
                    strMoney = "0";//默认为不限资金

                }
                if (this.chkCapital.Items[i].Selected)
                {
                    strMoney = strMoney + this.chkCapital.Items[i].Value.Trim() + "|";
                }
            }
            if (strMoney.Trim() != "")
            {
                strMoney = strMoney.Substring(0, strMoney.Length - 1);
            }


            //投资行业
            strCalling = hidZyCalling.Value.Trim();
            strCallingTxt = hidZyCallingTxt.Value;

            //投资区域
            strCity = hidZyCity.Value.Trim();
            strCityTxt = hidZyCityTxt.Value.Trim();

        }
        #endregion

        #region 企业项目
        else if (strCustomType == "2")
        {
            //融资类型
            for (int i = 0; i < ckRzlxQy.Items.Count; i++)
            {
                if (ckRzlxQy.Items[i].Selected)
                {
                    strType = strType + ckRzlxQy.Items[i].Value + "|";
                }
            }
            if (strType.Trim() != "")
            {
                strType = strType.Substring(0, strType.Length - 1);
            }
            //投资行业
            strCalling = hidQyCalling.Value.Trim();
            strCallingTxt = hidQyCallingTxt.Value;

            //投资区域
            strCity = hidQyCity.Value.Trim();
            strCityTxt = hidQyCityTxt.Value.Trim();
            //借款金额
            for (int i = 0; i < this.ckJkjeQy.Items.Count; i++)
            {
                //if (this.ckJkjeQy.Items.Count == 0)
                //{
                //    strMoney = "0";//默认为不限资金

                //}

                if (this.ckJkjeQy.Items[i].Selected)
                {
                    strMoney = strMoney + this.ckJkjeQy.Items[i].Value.Trim() + "|";
                }
            }
            if (strMoney.Trim() != "")
            {
                strMoney = strMoney.Substring(0, strType.Length - 1);
            }
        }
        #endregion

        #region 将信添加至model 并存至 session
        Tz888.Model.CustomInfoModel CustomInfo = new Tz888.Model.CustomInfoModel();

        //CustomInfo.ID = int.Parse(ID);

        //公共属性
        //strGenre = "";
        //strCalling = "";
        //strCallingTxt = "";
        //strSmallCalling = "";
        //strSmallCallingTxt = "";

        strKeyword = this.txtKey.Text.Trim();
        iValidateTerm = Convert.ToInt32(ddlValidateTerm.SelectedValue.ToString());//有效时间g
        strCurrency = "";

        bAccept = 1;
        iCustomCyc = 2;
        iItemCount = 10;
        strEmail = "";

        ////strCurrency = ddlCapitalCurrency.SelectedValue.ToString();

        CustomInfo.Accept = true;
        CustomInfo.Email = strEmail;
        CustomInfo.CustomCyc = Convert.ToInt32(this.ViewState["CustomCyc"]);//Convert.ToInt32(strCustomCyc);
        CustomInfo.LoginName = "topfo001";

        CustomInfo.CustomType = Convert.ToInt32(strCustomType);
        CustomInfo.Type = strType;  //类型
        CustomInfo.Genre = strGenre;
        CustomInfo.Money = strMoney;
        CustomInfo.Calling = strCalling;
        CustomInfo.SmallCalling = strSmallCalling;
        CustomInfo.City = strCity;

        CustomInfo.CallingTxt = strCallingTxt;
        CustomInfo.SmallCallingTxt = strSmallCallingTxt;
        CustomInfo.CityTxt = strCityTxt;

        CustomInfo.Keyword = strKeyword;
        CustomInfo.currency = strCurrency;
        CustomInfo.CooperationDemandTypeID = strCooperationDemandTypeID;  //合作方式

        CustomInfo.Title = strTitle;
        Session["title"] = strTitle;

        //新增字段
        CustomInfo.StageForenterpriseDevelop = strStageForenterpriseDevelop;
        CustomInfo.Trade = strtrade;
        CustomInfo.FinancingObject = strfinancingObject;



        Session["customInfo"] = CustomInfo;

        #endregion

        //添加数据至 信息定制表


    }

        #endregion

    #region 修改后 保存session
    private void MackUpdateTable()
    {
        #region 变量定义
        string strCustomType = this.Hidden1.Value.ToString();
        //if (this.ViewState["CustomType"] != null)
        //{
        //    strCustomType = this.ViewState["CustomType"].ToString();
        //}
        string strTitle = "";
        if (this.ViewState["Title"] != null)
        {
            strTitle = this.ViewState["Title"].ToString();
        }
        string strType = "";
        string strGenre = "";
        string strMoney = "";
        string strCalling = "";
        string strCallingTxt = "";
        string strSmallCalling = "";
        string strSmallCallingTxt = "";
        string strCity = "";
        string strCityTxt = "";
        string strKeyword = this.txtKey.Text.Trim();
        int iValidateTerm = Convert.ToInt32(ddlValidateTerm.SelectedValue.ToString());
        string strCurrency = "";
        string strCooperationDemandTypeID = "";//合作类型

        int bAccept = 1;//int.Parse(this.ViewState["Accept"].ToString());
        int iCustomCyc = Convert.ToInt32(this.ViewState["CustomCyc"]);
        int iItemCount = Convert.ToInt32(this.ViewState["ItemCount"]);
        string strEmail = "";
        if (this.ViewState["Email"] != null)
        {
            strEmail = this.ViewState["Email"].ToString();
        }

        string strStageForenterpriseDevelop = ""; //企业投资阶段
        string strfinancingObject = "";//融资对象
        string strtrade = "";
        #endregion

        #region  变量赋值

        #region 政府招商
        if (strCustomType == "0")   //政府招商
        {

            //投资行业
            strCalling = hidZfCalling.Value.Trim();
            strCallingTxt = hidZfCallingTxt.Value;

            //投资区域
            strCity = hidZfCity.Value.Trim();
            strCityTxt = hidZfCityTxt.Value.Trim();
        }
        #endregion

        #region 资本资源
        else if (strCustomType == "1")
        {
            //投资方式
            for (int i = 0; i < this.chTzfsZb.Items.Count; i++)
            {
                if (this.chTzfsZb.Items[i].Selected)
                {
                    strCooperationDemandTypeID = strCooperationDemandTypeID + this.chTzfsZb.Items[i].Value.Trim() + "|";
                }
            }

            //单项目可投资金额            
            for (int i = 0; i < this.chkCapital.Items.Count; i++)
            {
                if (this.chkCapital.Items.Count == 0)
                {
                    strMoney = "0";//默认为不限资金

                }
                if (this.chkCapital.Items[i].Selected)
                {
                    strMoney = strMoney + this.chkCapital.Items[i].Value.Trim() + "|";
                }
            }
            if (strMoney.Trim() != "")
            {
                strMoney = strMoney.Substring(0, strMoney.Length - 1);
            }


            //投资行业
            strCalling = hidZyCalling.Value.Trim();
            strCallingTxt = hidZyCallingTxt.Value;

            //投资区域
            strCity = hidZyCity.Value.Trim();
            strCityTxt = hidZyCityTxt.Value.Trim();

        }
        #endregion

        #region 企业项目
        else if (strCustomType == "2")
        {
            //融资类型
            for (int i = 0; i < ckRzlxQy.Items.Count; i++)
            {
                if (ckRzlxQy.Items[i].Selected)
                {
                    strType = strType + ckRzlxQy.Items[i].Value + "|";
                }
            }
            if (strType.Trim() != "")
            {
                strType = strType.Substring(0, strType.Length - 1);
            }
            //投资行业
            strCalling = hidQyCalling.Value.Trim();
            strCallingTxt = hidQyCallingTxt.Value;

            //投资区域
            strCity = hidQyCity.Value.Trim();
            strCityTxt = hidQyCityTxt.Value.Trim();
            //借款金额
            for (int i = 0; i < this.ckJkjeQy.Items.Count; i++)
            {
                if (this.ckJkjeQy.Items.Count == 0)
                {
                    strMoney = "0";//默认为不限资金

                }

                if (this.ckJkjeQy.Items[i].Selected)
                {
                    strMoney = strMoney + this.ckJkjeQy.Items[i].Value.Trim() + "|";
                }
            }
            if (strMoney.Trim() != "")
            {
                strMoney = strMoney.Substring(0, strMoney.Length - 1);
            }

        }
        #endregion

        #endregion

        #region 将信添加至session
        #region 将信添加至model 并存至 session
        Tz888.Model.CustomInfoModel CustomInfo = new Tz888.Model.CustomInfoModel();

        //CustomInfo.ID = int.Parse(ID);
        CustomInfo.LoginName = "topfo001";

        //公共属性
        //strGenre = "";
        //strCalling = "";
        //strCallingTxt = "";
        //strSmallCalling = "";
        //strSmallCallingTxt = "";

        strKeyword = this.txtKey.Text.Trim();
        iValidateTerm = Convert.ToInt32(ddlValidateTerm.SelectedValue.ToString());//有效时间
        strCurrency = "";

        bAccept = 1;
        iCustomCyc = 2;
        iItemCount = 10;
        strEmail = "";

        ////strCurrency = ddlCapitalCurrency.SelectedValue.ToString();

        CustomInfo.Accept = true;
        CustomInfo.Email = strEmail;
        CustomInfo.CustomCyc = Convert.ToInt32(this.ViewState["CustomCyc"]);//Convert.ToInt32(strCustomCyc);

        CustomInfo.CustomType = Convert.ToInt32(strCustomType);
        CustomInfo.Type = strType;  //类型
        CustomInfo.Genre = strGenre;
        CustomInfo.Money = strMoney;
        CustomInfo.Calling = strCalling;
        CustomInfo.SmallCalling = strSmallCalling;
        CustomInfo.City = strCity;

        CustomInfo.CallingTxt = strCallingTxt;
        CustomInfo.SmallCallingTxt = strSmallCallingTxt;
        CustomInfo.CityTxt = strCityTxt;

        CustomInfo.Keyword = strKeyword;
        CustomInfo.currency = strCurrency;
        CustomInfo.CooperationDemandTypeID = strCooperationDemandTypeID;  //合作方式

        CustomInfo.Title = strTitle;


        //新增字段
        CustomInfo.StageForenterpriseDevelop = strStageForenterpriseDevelop;
        CustomInfo.Trade = strtrade;
        CustomInfo.FinancingObject = strfinancingObject;
        string na = ViewState["ID"].ToString();
        if (Convert.ToString(ViewState["ID"]) != "")
        {
            CustomInfo.ID = int.Parse(this.ViewState["ID"].ToString());
        }

        Session["customInfo"] = CustomInfo;
        Session["title"] = strTitle;
        #endregion
        //Session["CustomInfo"] = ds;


        #endregion
    }
    #endregion
    #endregion



    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (this.ViewState["tag"].ToString() == "Add")
        {
            string Criteria = "LoginName ='topfo001'";

            Tz888.SQLServerDAL.Conn customObj = new Tz888.SQLServerDAL.Conn();
            DataTable dt = customObj.GetList("CustomInfoTab", "ID", "ID", 1, 1, 0, 1, Criteria);

            if (dt != null)
            {
                MackAddTable();
                // Tz888.Common.MessageBox.Show(this.Page, "添加用户名:" + Page.User.Identity.Name.Trim());
                Tz888.Common.MessageBox.Show(this.Page, "添加用户名:topfo001");
                //Response.Redirect("ModifyMaching.aspx?tag=Add");
                Response.Redirect("TestModifyMaching.aspx");
            }
            else
            {
                Session["CustomInfo"] = null;
                Tz888.Common.MessageBox.Show(this.Page, "你已经订阅了5个搜索条件，不能在添加新的搜索条件！");
            }
        }
        else
        {

            MackUpdateTable();
            Response.Redirect("ModifyMaching.aspx?tag=Update" + "&id=" + this.ViewState["ID"]);
        }
    }
    protected void butSelect_Click(object sender, EventArgs e)
    {
        MackUpdateTable();

        //Response.Write("<script type='text/javascript'>window.open('MachingMessage.aspx');</script>");
        Response.Redirect("MachingMessage.aspx");
    }
}
