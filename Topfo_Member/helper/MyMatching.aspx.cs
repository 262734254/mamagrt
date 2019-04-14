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

public partial class helper_MyMatching : System.Web.UI.Page
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        bool isTof = Page.User.IsInRole("GT1002");

        //if (isTof)
        //{
        //    Page.MasterPageFile = "/indexTof.master";
        //}
        //else
        //{
        //    Page.MasterPageFile = "/MasterPage.master";
        //}
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Page.User.Identity.Name == null || Page.User.Identity.Name.Trim() == "")
        //{
        //    Response.Redirect("../Login.aspx?ReturnUrl=" + Server.UrlEncode(Request.RawUrl));

        //}
        //if (Page.User.IsInRole("GT1001"))
        //{
        //    Tz888.Common.MessageBox.ShowAndRedirect(this.Page, "对不起，普通会员不能进行此项服务！", "http://member.topfo.com/helper/MatchingInfo.aspx");
        //    return;
        //}

        this.ViewState["MemberLoginName"] = Page.User.Identity.Name.Trim();//Page.User.Identity.Name.ToString();
        //Tz888.Common.MessageBox.Show(this.Page, "用户名" + Page.User.Identity.Name.Trim());
        if (Request.QueryString["ID"] != null)
        {
            this.ViewState["ID"] = Request.QueryString["ID"].ToString();
        }
        else 
        {
            this.ViewState["ID"] = "";
        }
        if (!Page.IsPostBack)
        {
            this.ViewState["CustomType"] = "";
            this.ViewState["Type"] = "";
            this.ViewState["Genre"] = "";
            this.ViewState["Money"] = "";
            this.ViewState["Calling"] = "";
            this.ViewState["SmallCalling"] = "";
            this.ViewState["City"] = "";
            this.ViewState["Keyword"] = "";

            if (Request.QueryString["CustomType"] != null)
            {
                this.ViewState["CustomType"] = Request.QueryString["CustomType"].ToString();
                this.Hidden1.Value = Request.QueryString["CustomType"].ToString();
            }
            else
            {
                this.ViewState["CustomType"] = this.Hidden1.Value;
            }

            if (Request.QueryString["tag"] != null)
            {
                this.ViewState["tag"] = Request.QueryString["tag"].ToString();
            }
            else
            {
                this.ViewState["tag"] = "Add";
            }

            //页面绑定
            forPageload();

            if (this.ViewState["tag"].ToString() == "update")
            {
                //查询
                string Criteria = "LoginName = '" + Page.User.Identity.Name.Trim() + "' and id=" + this.ViewState["ID"].ToString();
                //string Criteria = "LoginName = '" + "hellocindy" + "' and id=" + this.ViewState["ID"].ToString();
                Tz888.SQLServerDAL.Conn obj = new Tz888.SQLServerDAL.Conn();
                DataTable dt1 = obj.GetList("CustomInfoTab", "*", "ID", 1, 1, 0, 1, Criteria);
                DataRow dr = dt1.Rows[0];
                FillData(dr);
            }

        }

        //注册JS
        this.lstIndustryBLeft.Attributes.Add("ondblclick", "moveOver(document.getElementById('ctl00_ContentPlaceHolder1_lstIndustryBLeft'),document.getElementById('ctl00_ContentPlaceHolder1_lstIndustryBRight'));");
        this.lstIndustryBRight.Attributes.Add("ondblclick", "removeMe(document.getElementById('ctl00_ContentPlaceHolder1_lstIndustryBRight'));");

        this.lstProvinceLeft.Attributes.Add("ondblclick", "moveOver(document.getElementById('ctl00_ContentPlaceHolder1_lstProvinceLeft'),document.getElementById('ctl00_ContentPlaceHolder1_lstProvinceRight'));");
        this.lstProvinceRight.Attributes.Add("ondblclick", "removeMe(document.getElementById('ctl00_ContentPlaceHolder1_lstProvinceRight'));");
        //政府招商
        this.lisTzhy.Attributes.Add("ondblclick", "moveOver(document.getElementById('ctl00_ContentPlaceHolder1_lisTzhy'),document.getElementById('ctl00_ContentPlaceHolder1_lisTzhyRight'));");
        this.lisTzhyRight.Attributes.Add("ondblclick", "removeMe(document.getElementById('ctl00_ContentPlaceHolder1_lisTzhyRight'));");

        this.lisTzQy.Attributes.Add("ondblclick", "moveOver(document.getElementById('ctl00_ContentPlaceHolder1_lisTzQy'),document.getElementById('ctl00_ContentPlaceHolder1_lisTzQyRight'));");
        this.lisTzQyRight.Attributes.Add("ondblclick", "removeMe(document.getElementById('ctl00_ContentPlaceHolder1_lisTzQyRight'));");

        this.lisTzhyQy.Attributes.Add("ondblclick", "moveOver(document.getElementById('ctl00_ContentPlaceHolder1_lisTzhyQy'),document.getElementById('ctl00_ContentPlaceHolder1_lisTzhyQyRight'));");
        this.lisTzhyQyRight.Attributes.Add("ondblclick", "removeMe(document.getElementById('ctl00_ContentPlaceHolder1_lisTzhyQyRight'));");

        this.lisTzqyQy.Attributes.Add("ondblclick", "moveOver(document.getElementById('ctl00_ContentPlaceHolder1_lisTzqyQy'),document.getElementById('ctl00_ContentPlaceHolder1_lisTzqyQyRight'));");
        this.lisTzqyQyRight.Attributes.Add("ondblclick", "removeMe(document.getElementById('ctl00_ContentPlaceHolder1_lisTzqyQyRight'));");

        //资本资源        
        //投资行业 calling
        string onClickValue = "FillToTxtFeild(document.getElementById('ctl00_ContentPlaceHolder1_lstIndustryBRight'), document.getElementById('ctl00_ContentPlaceHolder1_hidZyCalling'),document.getElementById('ctl00_ContentPlaceHolder1_hidZyCallingTxt'), '|');";
        //投资省市 city
        onClickValue += "FillToTxtFeild(document.getElementById('ctl00_ContentPlaceHolder1_lstProvinceRight'), document.getElementById('ctl00_ContentPlaceHolder1_hidZyCity'),document.getElementById('ctl00_ContentPlaceHolder1_hidZyCityTxt'), '|');";

        //政府招商
        onClickValue += "FillToTxtFeild(document.getElementById('ctl00_ContentPlaceHolder1_lisTzhyRight'), document.getElementById('ctl00_ContentPlaceHolder1_hidZfCalling'), document.getElementById('ctl00_ContentPlaceHolder1_hidZfCallingTxt'),'|');";
        onClickValue += "FillToTxtFeild(document.getElementById('ctl00_ContentPlaceHolder1_lisTzQyRight'), document.getElementById('ctl00_ContentPlaceHolder1_hidZfCity'), document.getElementById('ctl00_ContentPlaceHolder1_hidZfCityTxt'),'|');";
        //企业项目
        onClickValue += "FillToTxtFeild(document.getElementById('ctl00_ContentPlaceHolder1_lisTzhyQyRight'), document.getElementById('ctl00_ContentPlaceHolder1_hidQyCalling'), document.getElementById('ctl00_ContentPlaceHolder1_hidQyCallingTxt'),'|');";
        onClickValue += "FillToTxtFeild(document.getElementById('ctl00_ContentPlaceHolder1_lisTzqyQyRight'), document.getElementById('ctl00_ContentPlaceHolder1_hidQyCity'), document.getElementById('ctl00_ContentPlaceHolder1_hidQyCityTxt'),'|');";


        btnAdd.Attributes.Add("onClick", onClickValue);

    }

    #region 页面初使化



    private void forPageload()
    {
        Tz888.BLL.PageIniControl CustomList = new Tz888.BLL.PageIniControl();

        //招商类别        
        this.chkMerchantType.DataSource = Tz888.BLL.Info.Common.GetMerchantAttributeList();
        this.chkMerchantType.DataTextField = "MerchantAttributeName";
        this.chkMerchantType.DataValueField = "MerchantAttributeID";
        this.chkMerchantType.DataBind();

        //产业类型
        //this.chkIndustry.DataSource = CustomList.IndustryBDataBind();
        //this.chkIndustry.DataBind();

        //投资类别
        this.chkSETfinancingTarget.DataSource = CustomList.SETfinancingTargetTabBind();//.CaptitalTypeDataBind();
        this.chkSETfinancingTarget.DataBind();

        //金额
        this.chkCapital.DataSource = CustomList.CaptitalDataBind();
        this.chkCapital.DataBind();

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

        //引资金额 政府招商
        this.cboYzje.DataSource = CustomList.CaptitalDataBind();
        this.cboYzje.DataBind();


        #endregion

        #region 企业招商
        //投资行业
        lisTzhyQy.DataSource = dvIndustryB; ;
        lisTzhyQy.DataBind();

        //投资区域
        dv.RowFilter = "ProvinceID<>0000";
        lisTzqyQy.DataSource = dv;
        lisTzqyQy.DataBind();

        //借款金额
        ckJkjeQy.DataSource = CustomList.CaptitalDataBind();

        ckJkjeQy.DataBind();

        //融资对象        
        //this.ckRzdxQy.DataSource = Tz888.BLL.Info.Common.GetMerchantAttributeList();
        //this.ckRzdxQy.DataTextField = "MerchantAttributeName";
        //this.ckRzdxQy.DataValueField = "MerchantAttributeID";
        //this.ckRzdxQy.DataBind();

        ////投资类别
        this.ckRzdxQy.DataSource = CustomList.SETfinancingTargetTabBind();//.CaptitalTypeDataBind();
        ckRzdxQy.DataValueField = "financingID";
        ckRzdxQy.DataTextField = "financingName";
        this.ckRzdxQy.DataBind();
        #endregion


        ////资讯类型	
        DataTable dvNewsType = CustomList.GetList();
        chkNewsType.DataSource = dvNewsType;
        chkNewsType.DataBind();



        ////注意：小行业在前期版本中己不要了，现在存放招商的合作方式字段或资本项目的合作类型 (新加)


        //绑定合作方式     
        //if (this.ViewState["CustomType"].ToString() == "0")//招商
        //{
        //this.chkLstCooperationDemand2.DataSource = Tz888.BLL.Info.Common.GetCooperationDemandList("Merchant");
        //this.chkLstCooperationDemand2.DataTextField = "CooperationDemandName";
        //this.chkLstCooperationDemand2.DataValueField = "CooperationDemandTypeID";
        //this.chkLstCooperationDemand2.DataBind();

        //} 
        //else if (this.ViewState["CustomType"].ToString() == "1" || this.ViewState["CustomType"].ToString() == "2")//投融资

        //{
        this.chkLstCooperationDemand.DataSource = Tz888.BLL.Info.Common.GetCooperationDemandList("Merchant");
        this.chkLstCooperationDemand.DataTextField = "CooperationDemandName";
        this.chkLstCooperationDemand.DataValueField = "CooperationDemandTypeID";
        this.chkLstCooperationDemand.DataBind();
        //}
        // 设置货币种类

        //Tz888.BLL.Common.SetCurrencyBLL bll = new Tz888.BLL.Common.SetCurrencyBLL();
        //this.ddlCapitalCurrency.DataSource = bll.GetList();
        //this.ddlCapitalCurrency.DataTextField = "CurrencyName";
        //this.ddlCapitalCurrency.DataValueField = "CurrencyID";
        //this.ddlCapitalCurrency.DataBind();

        //投资发展阶段
        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        DataTable dt = dal.GetList("dicttab", "*", "idictvalue", 10, 1, 0, 0, " cdicttype='Qyfzjd' ");
        rblTzxmjd.DataTextField = "cdictname";
        rblTzxmjd.DataValueField = "idictvalue";
        rblTzxmjd.DataSource = dt;
        rblTzxmjd.DataBind();

        //企业发展阶段
        rdQyfzjd.DataTextField = "cdictname";
        rdQyfzjd.DataValueField = "idictvalue";
        rdQyfzjd.DataSource = dt;
        rdQyfzjd.DataBind();
    }

    #endregion

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
            //招商类别
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
                for (int i = 0; i < this.chkMerchantType.Items.Count; i++)
                {
                    for (int j = 0; j < arrType.Length; j++)
                    {
                        if (int.Parse(chkMerchantType.Items[i].Value) == int.Parse(arrType[j].Trim()))
                        {
                            chkMerchantType.Items[i].Selected = true;
                        }
                    }
                    //this.chkMerchantType.Items[i].Selected = arrTyp.Contains(this.chkMerchantType.Items[i].Value.Trim());
                }
            }

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

            if (dr["CooperationDemandTypeID"].ToString() != "")//合作方式
            {
                string[] arrType = dr["CooperationDemandTypeID"].ToString().Trim().Split('|');
                ArrayList arrTyp = new ArrayList();
                for (int i = 0; i < arrType.Length; i++)
                {
                    if (arrType[i].Trim() != "")
                    {
                        arrTyp.Add(arrType[i]);
                    }
                }
                for (int i = 0; i < this.chkLstCooperationDemand.Items.Count; i++)
                {
                    this.chkLstCooperationDemand.Items[i].Selected = arrTyp.Contains(this.chkLstCooperationDemand.Items[i].Value.Trim());
                }
                //for (int j = 0; j < this.chkLstCooperationDemand2.Items.Count; j++)
                //{
                //    this.chkLstCooperationDemand2.Items[j].Selected = arrTyp.Contains(this.chkLstCooperationDemand2.Items[j].Value.Trim());
                //    // Tz888.Common.MessageBox.Show(this.Page, this.chkLstCooperationDemand2.Items.Count+"aaaa"+);
                //}

            }

            //引资金额
            if (dr["Money"].ToString() != "")//合作方式
            {
                string[] arrType = dr["Money"].ToString().Trim().Split('|');
                ArrayList arrTyp = new ArrayList();
                for (int i = 0; i < arrType.Length; i++)
                {
                    if (arrType[i].Trim() != "")
                    {
                        arrTyp.Add(arrType[i]);
                    }
                }
                for (int i = 0; i < this.cboYzje.Items.Count; i++)
                {
                    for (int j = 0; j < arrType.Length; j++)
                    {
                        if (int.Parse(cboYzje.Items[i].Value.Trim()) == int.Parse(arrType[j].Trim()))
                        {
                            cboYzje.Items[i].Selected = true;
                        }
                    }
                    //this.cboYzje.Items[i].Selected = arrTyp.Contains(this.cboYzje.Items[i].Value.Trim());
                }
            }
        }
        #endregion

        #region 资本资源
        if (CustomType == "1")
        {
            //资本类型
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
                for (int i = 0; i < this.chkSETfinancingTarget.Items.Count; i++)
                {
                    this.chkSETfinancingTarget.Items[i].Selected = arrTyp.Contains(this.chkSETfinancingTarget.Items[i].Value.Trim());
                }
            }

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
            //企业投资阶段
            if (dr["StageForenterpriseDevelop"].ToString() != "")
            {
                for (int i = 0; i < rblTzxmjd.Items.Count; i++)
                {
                    if (rblTzxmjd.Items[i].Value.Trim() == dr["StageForenterpriseDevelop"].ToString().Trim())
                    {
                        rblTzxmjd.Items[i].Selected = true;
                    }
                }
            }
            ////strCurrency = ddlCapitalCurrency.SelectedValue.ToString();

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
                        listItem.Text = GetCallingTxtOpportunity(arrType[i].Trim());
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


            //融资对象
            if (dr["FinancingObject"].ToString() != "")
            {
                string[] arrType = dr["FinancingObject"].ToString().Split('|');
                ArrayList arrTyp = new ArrayList();
                for (int i = 0; i < arrType.Length; i++)
                {
                    if (arrType[i].Trim() != "")
                    {
                        arrTyp.Add(arrType[i]);
                    }
                }
                for (int i = 0; i < this.ckRzdxQy.Items.Count; i++)
                {
                    //this.chkCapital.Items[i].Selected = arrTyp.Contains(this.chkCapital.Items[i].Value.Trim());
                    for (int j = 0; j < arrTyp.Count; j++)
                    {
                        if (int.Parse(ckRzdxQy.Items[i].Value.Trim()) == int.Parse(arrTyp[j].ToString().Trim()))
                        {
                            ckRzdxQy.Items[i].Selected = true;
                        }
                    }

                }
            }

            //企业投资阶段
            if (dr["StageForenterpriseDevelop"].ToString() != "")
            {
                for (int i = 0; i < rdQyfzjd.Items.Count; i++)
                {
                    if (rdQyfzjd.Items[i].Value.Trim() == dr["StageForenterpriseDevelop"].ToString().Trim())
                    {
                        rdQyfzjd.Items[i].Selected = true;
                    }
                }
            }

            //公共属性赋值 

            //strCalling = this.hideIndustryB.Value.Trim();
            //strCallingTxt = this.hideIndustryBtxt.Value.Trim();
            // strSmallCalling = this.hideIndustryM.Value.Trim();
            //strSmallCallingTxt = this.hideIndustryMtxt.Value.Trim();


        }
        #endregion

        #region 资讯
        else if (CustomType == "3")
        {
            //资讯类别
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
                for (int i = 0; i < this.chkNewsType.Items.Count; i++)
                {
                    for (int j = 0; j < arrType.Length; j++)
                    {
                        if (int.Parse(chkNewsType.Items[i].Value.Trim()) == int.Parse(arrType[j].Trim()))
                        {
                            chkNewsType.Items[i].Selected = true;
                        }
                    }
                }
            }
        }
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
        {//政府招商 资 本 项 目 创 业 商 机 资 讯 (没有参数表)
            /*原项目说明：<asp:ListItem Value="0" Selected="True">政府招商</asp:ListItem>
                           <asp:ListItem Value="1">资本项目</asp:ListItem>
                           <asp:ListItem Value="2">企业项目</asp:ListItem>
                           <asp:ListItem Value="3">资讯信息</asp:ListItem>
                       </asp:dropdownlist></span></td>*/
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
            //招商类别
            for (int i = 0; i < this.chkMerchantType.Items.Count; i++)
            {
                if (this.chkMerchantType.Items[i].Selected)
                {
                    strType = strType + this.chkMerchantType.Items[i].Value.Trim() + "|";
                }
            }
            if (strType.Trim() != "")
            {
                strType = strType.Substring(0, strType.Length - 1);
            }

            //投资行业
            strCalling = hidZfCalling.Value.Trim();
            strCallingTxt = hidZfCallingTxt.Value;

            //投资区域
            strCity = hidZfCity.Value.Trim();
            strCityTxt = hidZfCityTxt.Value.Trim();

            //合作方式
            for (int i = 0; i < this.chkLstCooperationDemand.Items.Count; i++)
            {
                if (this.chkLstCooperationDemand.Items[i].Selected)
                {
                    strCooperationDemandTypeID = strCooperationDemandTypeID + this.chkLstCooperationDemand.Items[i].Value.Trim() + "|";
                }
            }

            //引资金额
            for (int i = 0; i < cboYzje.Items.Count; i++)
            {
                if (cboYzje.Items[i].Selected)
                {
                    strMoney = cboYzje.Items[i].Value + "|";
                }
            }
            if (strMoney.Trim() != "")
            {
                strMoney = strMoney.Substring(0, strMoney.Length - 1);
            }
        }
        #endregion

        #region 资本资源
        else if (strCustomType == "1")
        {
            //资本类型
            for (int i = 0; i < this.chkSETfinancingTarget.Items.Count; i++)
            {
                if (this.chkSETfinancingTarget.Items[i].Selected)
                {
                    strType = strType + this.chkSETfinancingTarget.Items[i].Value.Trim() + "|";
                }
            }
            if (strType.Trim() != "")
            {
                strType = strType.Substring(0, strType.Length - 1);
            }

            //投资方式
            for (int i = 0; i < this.chkLstCooperationDemand.Items.Count; i++)
            {
                if (this.chkLstCooperationDemand.Items[i].Selected)
                {
                    strCooperationDemandTypeID = strCooperationDemandTypeID + this.chkLstCooperationDemand.Items[i].Value.Trim() + "|";
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

            //企业投资阶段
            for (int i = 0; i < rblTzxmjd.Items.Count; i++)
            {
                strStageForenterpriseDevelop = rblTzxmjd.Items[i].Value;
            }

            ////strCurrency = ddlCapitalCurrency.SelectedValue.ToString();

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

            //融资对象
            for (int i = 0; i < this.ckRzdxQy.Items.Count; i++)
            {
                if (this.ckRzdxQy.Items[i].Selected)
                {
                    strfinancingObject = strfinancingObject + this.ckRzdxQy.Items[i].Value.Trim() + "|";
                }
            }
            if (strfinancingObject.Trim() != "")
            {
                strfinancingObject = strfinancingObject.Substring(0, strType.Length - 1);
            }
            //企业投资阶段
            for (int i = 0; i < rblTzxmjd.Items.Count; i++)
            {
                strStageForenterpriseDevelop = strStageForenterpriseDevelop + rdQyfzjd.Items[i].Value;
            }

            //公共属性赋值 

            //strCalling = this.hideIndustryB.Value.Trim();
            //strCallingTxt = this.hideIndustryBtxt.Value.Trim();
            // strSmallCalling = this.hideIndustryM.Value.Trim();
            //strSmallCallingTxt = this.hideIndustryMtxt.Value.Trim();


        }
        #endregion

        #region 资讯
        else if (strCustomType == "3")
        {
            for (int i = 0; i < this.chkNewsType.Items.Count; i++)
            {
                if (this.chkNewsType.Items[i].Selected)
                {
                    strType = strType + this.chkNewsType.Items[i].Value.Trim() + "|";
                }
            }
            if (strType.Trim() != "")
            {
                strType = strType.Substring(0, strType.Length - 1);
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
        CustomInfo.LoginName = Page.User.Identity.Name.Trim();

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
            //招商类别
            for (int i = 0; i < this.chkMerchantType.Items.Count; i++)
            {
                if (this.chkMerchantType.Items[i].Selected)
                {
                    strType = strType + this.chkMerchantType.Items[i].Value.Trim() + "|";
                }
            }
            if (strType.Trim() != "")
            {
                strType = strType.Substring(0, strType.Length - 1);
            }

            //投资行业
            strCalling = hidZfCalling.Value.Trim();
            strCallingTxt = hidZfCallingTxt.Value;

            //投资区域
            strCity = hidZfCity.Value.Trim();
            strCityTxt = hidZfCityTxt.Value.Trim();

            //合作方式
            for (int i = 0; i < this.chkLstCooperationDemand.Items.Count; i++)
            {
                if (this.chkLstCooperationDemand.Items[i].Selected)
                {
                    strCooperationDemandTypeID = strCooperationDemandTypeID + this.chkLstCooperationDemand.Items[i].Value.Trim() + "|";
                }
            }

            //引资金额
            for (int i = 0; i < cboYzje.Items.Count; i++)
            {
                if (cboYzje.Items[i].Selected)
                {
                    strMoney = strMoney + cboYzje.Items[i].Value + "|";
                }
            }
            if (strMoney.Trim() != "")
            {
                strMoney = strMoney.Substring(0, strMoney.Length - 1);
            }
        }
        #endregion

        #region 资本资源
        else if (strCustomType == "1")
        {
            //资本类型
            for (int i = 0; i < this.chkSETfinancingTarget.Items.Count; i++)
            {
                if (this.chkSETfinancingTarget.Items[i].Selected)
                {
                    strType = strType + this.chkSETfinancingTarget.Items[i].Value.Trim() + "|";
                }
            }
            if (strType.Trim() != "")
            {
                strType = strType.Substring(0, strType.Length - 1);
            }

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

            //企业投资阶段
            for (int i = 0; i < rblTzxmjd.Items.Count; i++)
            {
                if (rblTzxmjd.Items[i].Selected == true)
                {
                    strStageForenterpriseDevelop = rblTzxmjd.Items[i].Value;
                }
            }

            ////strCurrency = ddlCapitalCurrency.SelectedValue.ToString();

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
            //融资对象
            for (int i = 0; i < this.ckRzdxQy.Items.Count; i++)
            {
                if (this.ckRzdxQy.Items[i].Selected)
                {
                    strfinancingObject = strfinancingObject + this.ckRzdxQy.Items[i].Value.Trim() + "|";
                }
            }
            if (strfinancingObject.Trim() != "")
            {
                strfinancingObject = strfinancingObject.Substring(0, strfinancingObject.Length - 1);
            }
            //企业投资阶段
            for (int i = 0; i < rblTzxmjd.Items.Count; i++)
            {
                if (rdQyfzjd.Items[i].Selected == true)
                {
                    strStageForenterpriseDevelop = rdQyfzjd.Items[i].Value;
                }

            }

            //公共属性赋值 

            //strCalling = this.hideIndustryB.Value.Trim();
            //strCallingTxt = this.hideIndustryBtxt.Value.Trim();
            // strSmallCalling = this.hideIndustryM.Value.Trim();
            //strSmallCallingTxt = this.hideIndustryMtxt.Value.Trim();


        }
        #endregion

        #region 资讯
        else if (strCustomType == "3")
        {
            for (int i = 0; i < this.chkNewsType.Items.Count; i++)
            {
                if (this.chkNewsType.Items[i].Selected)
                {
                    strType = strType + this.chkNewsType.Items[i].Value.Trim() + "|";
                }
            }
            if (strType.Trim() != "")
            {
                strType = strType.Substring(0, strType.Length - 1);
            }
        }
        #endregion
        #endregion

        #region 将信添加至session
        #region 将信添加至model 并存至 session
        Tz888.Model.CustomInfoModel CustomInfo = new Tz888.Model.CustomInfoModel();

        //CustomInfo.ID = int.Parse(ID);
        CustomInfo.LoginName = Page.User.Identity.Name.Trim();

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
        if (this.ViewState["ID"] != null)
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

    #region 建立Table
    private DataTable MakeTable()
    {
        DataTable dt = new DataTable("CustunInfo");

        DataColumn IDColumn = new DataColumn();
        IDColumn.DataType = System.Type.GetType("System.Int64");
        IDColumn.ColumnName = "ID";
        IDColumn.AutoIncrement = true;
        IDColumn.AutoIncrementSeed = 1;
        IDColumn.AutoIncrementStep = 1;
        dt.Columns.Add(IDColumn);

        DataColumn TitleColumn = new DataColumn();
        TitleColumn.DataType = System.Type.GetType("System.String");
        TitleColumn.ColumnName = "Title";
        dt.Columns.Add(TitleColumn);

        DataColumn LoginNameColumn = new DataColumn();
        LoginNameColumn.DataType = System.Type.GetType("System.String");
        LoginNameColumn.ColumnName = "LoginName";
        dt.Columns.Add(LoginNameColumn);

        DataColumn CustomTypeColumn = new DataColumn();
        CustomTypeColumn.DataType = System.Type.GetType("System.Int32");
        CustomTypeColumn.ColumnName = "CustomType";
        dt.Columns.Add(CustomTypeColumn);

        DataColumn TypeColumn = new DataColumn();
        TypeColumn.DataType = System.Type.GetType("System.String");
        TypeColumn.ColumnName = "Type";
        dt.Columns.Add(TypeColumn);

        DataColumn GenreColumn = new DataColumn();
        GenreColumn.DataType = System.Type.GetType("System.String");
        GenreColumn.ColumnName = "Genre";
        dt.Columns.Add(GenreColumn);

        DataColumn MoneyColumn = new DataColumn();
        MoneyColumn.DataType = System.Type.GetType("System.String");
        MoneyColumn.ColumnName = "Money";
        dt.Columns.Add(MoneyColumn);

        DataColumn CallingColumn = new DataColumn();
        CallingColumn.DataType = System.Type.GetType("System.String");
        CallingColumn.ColumnName = "Calling";
        dt.Columns.Add(CallingColumn);

        DataColumn CallingTxtColumn = new DataColumn();
        CallingTxtColumn.DataType = System.Type.GetType("System.String");
        CallingTxtColumn.ColumnName = "CallingTxt";
        dt.Columns.Add(CallingTxtColumn);

        DataColumn SmallCallingColumn = new DataColumn();
        SmallCallingColumn.DataType = System.Type.GetType("System.String");
        SmallCallingColumn.ColumnName = "SmallCalling";
        dt.Columns.Add(SmallCallingColumn);

        DataColumn SmallCallingTxtColumn = new DataColumn();
        SmallCallingTxtColumn.DataType = System.Type.GetType("System.String");
        SmallCallingTxtColumn.ColumnName = "SmallCallingTxt";
        dt.Columns.Add(SmallCallingTxtColumn);

        DataColumn CityColumn = new DataColumn();
        CityColumn.DataType = System.Type.GetType("System.String");
        CityColumn.ColumnName = "City";
        dt.Columns.Add(CityColumn);

        DataColumn CityTxtColumn = new DataColumn();
        CityTxtColumn.DataType = System.Type.GetType("System.String");
        CityTxtColumn.ColumnName = "CityTxt";
        dt.Columns.Add(CityTxtColumn);

        DataColumn KeywordColumn = new DataColumn();
        KeywordColumn.DataType = System.Type.GetType("System.String");
        KeywordColumn.ColumnName = "Keyword";
        dt.Columns.Add(KeywordColumn);

        DataColumn CurrencyColumn = new DataColumn();
        CurrencyColumn.DataType = System.Type.GetType("System.String");
        CurrencyColumn.ColumnName = "currency";
        dt.Columns.Add(CurrencyColumn);

        DataColumn CooperationDemandTypeIDColumn = new DataColumn();
        CooperationDemandTypeIDColumn.DataType = System.Type.GetType("System.String");
        CooperationDemandTypeIDColumn.ColumnName = "CooperationDemandTypeID";
        dt.Columns.Add(CooperationDemandTypeIDColumn);

        DataColumn ValidateTermColumn = new DataColumn();
        ValidateTermColumn.DataType = System.Type.GetType("System.Int32");
        ValidateTermColumn.ColumnName = "ValidateTerm";
        dt.Columns.Add(ValidateTermColumn);

        DataColumn CustomCycColumn = new DataColumn();
        CustomCycColumn.DataType = System.Type.GetType("System.Int32");
        CustomCycColumn.ColumnName = "CustomCyc";
        dt.Columns.Add(CustomCycColumn);

        DataColumn ItemCountColumn = new DataColumn();
        ItemCountColumn.DataType = System.Type.GetType("System.Int32");
        ItemCountColumn.ColumnName = "ItemCount";
        dt.Columns.Add(ItemCountColumn);

        DataColumn EmailColumn = new DataColumn();
        EmailColumn.DataType = System.Type.GetType("System.String");
        EmailColumn.ColumnName = "Email";
        dt.Columns.Add(EmailColumn);

        DataColumn AcceptColumn = new DataColumn();
        AcceptColumn.DataType = System.Type.GetType("System.Byte");
        AcceptColumn.ColumnName = "Accept";
        dt.Columns.Add(AcceptColumn);

        DataColumn[] myColArray = new DataColumn[1];
        myColArray[0] = dt.Columns["ID"];
        dt.PrimaryKey = myColArray;
        return dt;
    }

    #endregion

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (this.ViewState["tag"].ToString() == "Add")
        {
            string Criteria = "LoginName = '" + Page.User.Identity.Name.Trim() + "'";

            Tz888.SQLServerDAL.Conn customObj = new Tz888.SQLServerDAL.Conn();
            DataTable dt = customObj.GetList("CustomInfoTab", "ID", "ID", 1, 1, 0, 1, Criteria);

            if (dt != null)
            {
                MackAddTable();
                Tz888.Common.MessageBox.Show(this.Page, "添加用户名:" + Page.User.Identity.Name.Trim());
                //Response.Redirect("ModifyMaching.aspx?tag=Add");
                Response.Redirect("ModifyMaching.aspx");
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
        //建立条件
        //if (this.ViewState["tag"].ToString() == "update")
        //{
        //    MackUpdateTable();
        //}
        //else
        //{
        //    MackAddTable();
        //}
        //this.ViewState["tag"] = "update";
        MackUpdateTable();

        Response.Write("<script type='text/javascript'>window.open('MachingMessage.aspx');</script>");
        //Response.Redirect("MachingMessage.aspx");
    }

}
