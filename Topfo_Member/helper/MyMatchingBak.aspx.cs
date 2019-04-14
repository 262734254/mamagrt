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
        if (Page.User.IsInRole("GT1001"))
        {
            Tz888.Common.MessageBox.ShowAndRedirect(this.Page, "对不起，普通会员不能进行此项服务！", "http://member.topfo.com/helper/MatchingInfo.aspx");
            return;
        }

        this.ViewState["MemberLoginName"] = Page.User.Identity.Name;

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
            if (Request.QueryString["ID"] != null)
            {
                this.ViewState["ID"] = Request.QueryString["ID"].ToString();
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
                string Criteria = "LoginName = '" + this.ViewState["MemberLoginName"].ToString() + "' and id=" + this.ViewState["ID"].ToString();

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

        this.lstCarveoutInd.Attributes.Add("ondblclick", "moveOver(document.getElementById('ctl00_ContentPlaceHolder1_lstCarveoutInd'),document.getElementById('ctl00_ContentPlaceHolder1_lstCarveoutIndRight'));");
        this.lstCarveoutIndRight.Attributes.Add("ondblclick", "removeMe(document.getElementById('ctl00_ContentPlaceHolder1_lstCarveoutIndRight'));");

        this.lstOpporIndleft.Attributes.Add("ondblclick", "moveOver(document.getElementById('ctl00_ContentPlaceHolder1_lstOpporIndleft'),document.getElementById('ctl00_ContentPlaceHolder1_lstOpporIndRight'));");
        this.lstOpporIndRight.Attributes.Add("ondblclick", "removeMe(document.getElementById('ctl00_ContentPlaceHolder1_lstOpporIndRight'));");

        this.lstExhibitonIndleft.Attributes.Add("ondblclick", "moveOver(document.getElementById('ctl00_ContentPlaceHolder1_lstExhibitonIndleft'),document.getElementById('ctl00_ContentPlaceHolder1_lstExhibitonIndRight'));");
        this.lstExhibitonIndRight.Attributes.Add("ondblclick", "removeMe(document.getElementById('ctl00_ContentPlaceHolder1_lstExhibitonIndRight'));");

        string onClickValue = "FillToTxtFeild(document.getElementById('ctl00_ContentPlaceHolder1_lstIndustryBRight'), document.getElementById('ctl00_ContentPlaceHolder1_hideIndustryB'),document.getElementById('ctl00_ContentPlaceHolder1_hideIndustryBtxt'), '|');";
        //   onClickValue += "FillToTxtFeild(document.getElementById('lstIndustryMRight'), document.getElementById('hideIndustryM'), document.getElementById('hideIndustryMtxt'),'|');";
        onClickValue += "FillToTxtFeild(document.getElementById('ctl00_ContentPlaceHolder1_lstProvinceRight'), document.getElementById('ctl00_ContentPlaceHolder1_hideProvince'), document.getElementById('ctl00_ContentPlaceHolder1_hideProvincetxt'),'|');";
        onClickValue += "FillToTxtFeild(document.getElementById('ctl00_ContentPlaceHolder1_lstCarveoutIndRight'), document.getElementById('ctl00_ContentPlaceHolder1_hideIndustryCarveout'), document.getElementById('ctl00_ContentPlaceHolder1_hideIndustryCarveouttxt'),'|');";
        onClickValue += "FillToTxtFeild(document.getElementById('ctl00_ContentPlaceHolder1_lstOpporIndRight'), document.getElementById('ctl00_ContentPlaceHolder1_hideIndustryOppor'), document.getElementById('ctl00_ContentPlaceHolder1_hideIndustryOpportxt'),'|');";
        onClickValue += "FillToTxtFeild(document.getElementById('ctl00_ContentPlaceHolder1_lstExhibitonIndRight'), document.getElementById('ctl00_ContentPlaceHolder1_hideIndustryExhibition'), document.getElementById('ctl00_ContentPlaceHolder1_hideIndustryExhibitiontxt'),'|');";

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
        this.chkIndustry.DataSource = CustomList.IndustryBDataBind();
        this.chkIndustry.DataBind();

        //投资类别
        this.chkCapitalType.DataSource = CustomList.CaptitalTypeDataBind();
        this.chkCapitalType.DataBind();

        //金额
        this.chkCapital.DataSource = CustomList.CaptitalDataBind();
        this.chkCapital.DataBind();

        //大行业

        DataTable dvIndustryB = CustomList.IndustryBDataBind();
        this.lstIndustryBLeft.DataSource = dvIndustryB;
        this.lstIndustryBLeft.DataBind();

        ////小行业

        //DataTable dvIndustryM = CustomList.IndustryMDataBind("");
        //this.lstIndustryMLeft.DataSource = dvIndustryM;
        //this.lstIndustryMLeft.DataBind();

        //城市
        DataTable dvProvince = CustomList.ProvinceDataBind(null);
        DataView dv= dvProvince.DefaultView ;
        dv.RowFilter =  "ProvinceID<>0000";
        lstProvinceLeft.DataSource = dv;
        lstProvinceLeft.DataBind();

        //资讯类型	
        DataTable dvNewsType = CustomList.GetList();
        chkNewsType.DataSource = dvNewsType;
        chkNewsType.DataBind();

        //创业行业     
        DataTable dvIndustryCarveout = CustomList.GetListIndustryCarveout();
        this.lstCarveoutInd.DataSource = dvIndustryCarveout;
        this.lstCarveoutInd.DataBind();


        //商机行业     
        DataTable dvIndustryoppor = CustomList.GetListIndustryOppor();
        this.lstOpporIndleft.DataSource = dvIndustryoppor;
        this.lstOpporIndleft.DataBind();

        //会展行业     
        ////DataTable dvIndustryExhibition = setIndustryE.GetList();
        //this.lstExhibitonIndleft.DataSource = null;
        //this.lstExhibitonIndleft.DataBind();

        ////注意：小行业在前期版本中己不要了，现在存放招商的合作方式字段或资本项目的合作类型 (新加)


        //绑定合作方式     
        //if (this.ViewState["CustomType"].ToString() == "0")//招商
        //{
             this.chkLstCooperationDemand2.DataSource = Tz888.BLL.Info.Common.GetCooperationDemandList("Merchant");
            this.chkLstCooperationDemand2.DataTextField = "CooperationDemandName";
            this.chkLstCooperationDemand2.DataValueField = "CooperationDemandTypeID";
            this.chkLstCooperationDemand2.DataBind();

        //} 
        //else if (this.ViewState["CustomType"].ToString() == "1" || this.ViewState["CustomType"].ToString() == "2")//投融资
        //{
            this.chkLstCooperationDemand.DataSource = Tz888.BLL.Info.Common.GetCooperationDemandList("Capital");
            this.chkLstCooperationDemand.DataTextField = "CooperationDemandName";
            this.chkLstCooperationDemand.DataValueField = "CooperationDemandTypeID";
            this.chkLstCooperationDemand.DataBind();
        //}
        // 设置货币种类

        Tz888.BLL.Common.SetCurrencyBLL bll = new Tz888.BLL.Common.SetCurrencyBLL();
        this.ddlCapitalCurrency.DataSource = bll.GetList();
        this.ddlCapitalCurrency.DataTextField = "CurrencyName";
        this.ddlCapitalCurrency.DataValueField = "CurrencyID";
        this.ddlCapitalCurrency.DataBind();
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
                this.chkMerchantType.Items[i].Selected = arrTyp.Contains(this.chkMerchantType.Items[i].Value.Trim());
            }


            if (dr["CustomType"].ToString() == "3")
            {
                rblCarveoutType.SelectedValue = dr["Type"].ToString();
            }
            //合作方式(暂存于小行业内容里)
            //if (dr["CustomType"].ToString() == "0")
            //{ 
            //    string []str=dr["Type"].ToString().Split('|');
            //    for(int i=0;i<cblCooperationDemandType.Items.Count;i++)
            //    {
            //        if(cblCooperationDemandType.Items[i].Value == str
            //    }
            //}
        }

        //if (dr["Calling"].ToString() != "")
        //{
        //    string[] arrType = dr["Calling"].ToString().Split('|');
        //    ArrayList arrTyp = new ArrayList();
        //    for (int i = 0; i < arrType.Length; i++)
        //    {
        //        if (arrType[i].Trim() != "")
        //        {
        //            arrTyp.Add(arrType[i]);
        //        }
        //    }
        //    for (int i = 0; i < this.chkIndustry.Items.Count; i++)
        //    {
        //        this.chkIndustry.Items[i].Selected = arrTyp.Contains(this.chkIndustry.Items[i].Value.Trim());
        //    }
        //}

        if (dr["Genre"].ToString() != "")
        {
            string[] arrType = dr["Genre"].ToString().Split('|');
            ArrayList arrTyp = new ArrayList();
            for (int i = 0; i < arrType.Length; i++)
            {
                if (arrType[i].Trim() != "")
                {
                    arrTyp.Add(arrType[i]);
                }
            }
            for (int i = 0; i < this.chkCapitalType.Items.Count; i++)
            {
                this.chkCapitalType.Items[i].Selected = arrTyp.Contains(this.chkCapitalType.Items[i].Value.Trim());
            }
        }


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
                this.chkCapital.Items[i].Selected = arrTyp.Contains(this.chkCapital.Items[i].Value.Trim());
            }
        }

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
                    this.lstCarveoutIndRight.Items.Add(listItem);
                }

                if (dr["CustomType"].ToString() == "4")
                {
                    listItem.Value = arrType[i].Trim();
                    listItem.Text = GetCallingTxtOpportunity(arrType[i].Trim());
                    this.lstOpporIndRight.Items.Add(listItem);
                }

            }
            this.txtKey.Text = dr["Keyword"].ToString();
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
            for (int j = 0; j < this.chkLstCooperationDemand2.Items.Count; j++)
            {
                this.chkLstCooperationDemand2.Items[j].Selected = arrTyp.Contains(this.chkLstCooperationDemand2.Items[j].Value.Trim());
              // Tz888.Common.MessageBox.Show(this.Page, this.chkLstCooperationDemand2.Items.Count+"aaaa"+);
            }

        }
        ddlCapitalCurrency.SelectedValue = dr["currency"].ToString();//币种

        //this.lstIndustryMRight.Items.Clear();
        //string[] arrType = dr["SmallCalling"].ToString().Split('|');
        //string[] arrTypeTxt = dr["SmallCallingTxt"].ToString().Split('|');
        //ArrayList arrTyp = new ArrayList();
        //for (int i = 0; i < arrType.Length; i++)
        //{
        //    arrTyp.Add(arrType[i]);
        //    ListItem listItem = new ListItem();
        //    listItem.Value = arrType[i].Trim();
        //    listItem.Text = GetSmallCallingTxt(arrType[i].Trim());
        //    this.lstIndustryMRight.Items.Add(listItem);
        //}      

        if (dr["City"].ToString() != "")
        {
            this.lstProvinceRight.Items.Clear();
            string[] arrType = dr["City"].ToString().Split('|');
            string[] arrTypeTxt = dr["CityTxt"].ToString().Split('|');
            ArrayList arrTyp = new ArrayList();
            for (int i = 0; i < arrType.Length; i++)
            {
                if (arrType[i].Trim() != "")
                {
                    arrTyp.Add(arrType[i]);
                    ListItem listItem = new ListItem();
                    listItem.Value = arrType[i].Trim();
                    listItem.Text = GetCityTxt(arrType[i].Trim());
                    this.lstProvinceRight.Items.Add(listItem);
                }
            }
        }
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
            /*原项目说明：<asp:ListItem Value="0" Selected="True">招商信息</asp:ListItem>
                           <asp:ListItem Value="1">投资信息</asp:ListItem>
                           <asp:ListItem Value="2">融资信息</asp:ListItem>
                           <asp:ListItem Value="3">创业信息</asp:ListItem>
                           <asp:ListItem Value="4">商机信息</asp:ListItem>
                           <asp:ListItem Value="5">资讯信息</asp:ListItem>
                       </asp:dropdownlist></span></td>*/
            case "0":
                strCustomTypeName = "政府招商";
                break;
            case "1":
                strCustomTypeName = "资本信息";
                break;
            case "2":
                strCustomTypeName = "项目信息";
                break;
            case "3":
                strCustomTypeName = "创业信息";
                break;
            case "4":
                strCustomTypeName = "商机信息";
                break;
            case "5":
                strCustomTypeName = "资讯信息";
                break;
            default:
                strCustomTypeName = "政府招商";
                break;
        }

        string strTitle =strCustomTypeName + System.DateTime.Now.ToString();
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
        string strKeyword = this.txtKey.Text.Trim();
        int iValidateTerm = Convert.ToInt32(ddlValidateTerm.SelectedValue.ToString());//有效时间
        string strCurrency = "";
        string strCooperationDemandTypeID = "";//合作类型

        byte bAccept = 1;
        int iCustomCyc = 2;
        int iItemCount = 10;
        string strEmail = "";

        #endregion

        #region  变量赋值

        if (strCustomType == "0")
        {
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

            //for (int i = 0; i < this.chkIndustry.Items.Count; i++)
            //{
            //    if (this.chkIndustry.Items[i].Selected)
            //    {
            //        strCalling = strCalling + this.chkIndustry.Items[i].Value.Trim() + "|";

            //    }
            //}
            strCalling = this.hideIndustryB.Value.Trim();
            if (strCalling.Trim() != "")
            {
                strCalling = strCalling.Substring(0, strCalling.Length - 1);
            }
            //新添加（金额）

            for (int i = 0; i < this.chkCapital.Items.Count; i++)
            {
                if (this.chkCapital.Items.Count == 0)
                {
                    strMoney = "0";
                }
                if (this.chkCapital.Items[i].Selected)
                {
                    strMoney = strMoney + this.chkCapital.Items[i].Value.Trim() + "|";
                }
            }

            for (int i = 0; i < this.chkLstCooperationDemand2.Items.Count; i++)
            {
                if (this.chkLstCooperationDemand2.Items[i].Selected)
                {
                    strCooperationDemandTypeID = strCooperationDemandTypeID + this.chkLstCooperationDemand2.Items[i].Value.Trim() + "|";
                }
            }

            strCurrency = ddlCapitalCurrency.SelectedValue.ToString();
            strCity = hideProvince.Value.Trim();
        }
        else if (strCustomType == "1")
        {
            for (int i = 0; i < this.chkCapitalType.Items.Count; i++)
            {
                if (this.chkCapitalType.Items[i].Selected)
                {
                    strGenre = strGenre + this.chkCapitalType.Items[i].Value.Trim() + "|";
                }
            }
            if (strGenre.Trim() != "")
            {
                strGenre = strGenre.Substring(0, strGenre.Length - 1);
            }

            for (int i = 0; i < this.chkLstCooperationDemand.Items.Count; i++)
            {
                if (this.chkLstCooperationDemand.Items[i].Selected)
                {
                    strCooperationDemandTypeID = strCooperationDemandTypeID + this.chkLstCooperationDemand.Items[i].Value.Trim() + "|";
                }
            }

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

            strCurrency = ddlCapitalCurrency.SelectedValue.ToString();
            strCity = hideProvince.Value.Trim();
            strCalling = this.hideIndustryB.Value.Trim();
            strCallingTxt = this.hideIndustryBtxt.Value.Trim();
            // strSmallCalling = this.hideIndustryM.Value.Trim();
            //strSmallCallingTxt = this.hideIndustryMtxt.Value.Trim();
        }
        else if (strCustomType == "2")
        {
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

            for (int i = 0; i < this.chkLstCooperationDemand.Items.Count; i++)
            {
                if (this.chkLstCooperationDemand.Items[i].Selected)
                {
                    strCooperationDemandTypeID = strCooperationDemandTypeID + this.chkLstCooperationDemand.Items[i].Value.Trim() + "|";
                }
            }
            if (strMoney.Trim() != "")
            {
                strMoney = strMoney.Substring(0, strMoney.Length - 1);
            }

            strCurrency = ddlCapitalCurrency.SelectedValue.ToString();
            strCalling = this.hideIndustryB.Value.Trim();
            strCallingTxt = this.hideIndustryBtxt.Value.Trim();
            strSmallCalling = this.hideIndustryM.Value.Trim();
            strSmallCallingTxt = this.hideIndustryMtxt.Value.Trim();
            strCity = this.hideProvince.Value.Trim();
            strCityTxt = this.hideProvincetxt.Value.Trim();
        }

            //创业
        else if (strCustomType == "3")
        {
            strType = rblCarveoutType.SelectedValue.ToString().Trim();

            if (this.chkCapital.Items.Count == 0)
            {
                strMoney = "0";//默认为不限资金
            }
            for (int i = 0; i < this.chkCapital.Items.Count; i++)
            {
                if (this.chkCapital.Items[i].Selected)
                {
                    strMoney = strMoney + this.chkCapital.Items[i].Value.Trim() + "|";
                }
            }
            if (strMoney.Trim() != "")
            {
                strMoney = strMoney.Substring(0, strMoney.Length - 1);
            }
            strCurrency = ddlCapitalCurrency.SelectedValue.ToString();
            strCalling = this.hideIndustryCarveout.Value.Trim();
            strCallingTxt = this.hideIndustryCarveouttxt.Value.Trim();
            strCity = this.hideProvince.Value.Trim();
            strCityTxt = this.hideProvincetxt.Value.Trim();
        }

            //商机
        else if (strCustomType == "4")
        {
            strType = rblOpporType.SelectedValue.ToString().Trim();

            if (this.chkCapital.Items.Count == 0)
            {
                strMoney = "0";//默认为不限资金
            }
            for (int i = 0; i < this.chkCapital.Items.Count; i++)
            {
                if (this.chkCapital.Items[i].Selected)
                {
                    strMoney = strMoney + this.chkCapital.Items[i].Value.Trim() + "|";
                }
            }
            if (strMoney.Trim() != "")
            {
                strMoney = strMoney.Substring(0, strMoney.Length - 1);
            }
            strCurrency = ddlCapitalCurrency.SelectedValue.ToString();
            strCalling = this.hideIndustryOppor.Value.Trim();
            strCallingTxt = this.hideIndustryOpportxt.Value.Trim();
            strCity = this.hideProvince.Value.Trim();
            strCityTxt = this.hideProvincetxt.Value.Trim();
        }
        //资讯
        else if (strCustomType == "5")
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
        else
        {
        }
        #endregion

        #region 将信添加至session

        DataTable dt = null;
        dt = MakeTable();
        DataRow dr;
        dr = dt.NewRow();
        dr["Title"] = strTitle;
        dr["LoginName"] = this.ViewState["MemberLoginName"].ToString();
        dr["Type"] = strType;
        dr["CustomType"] = strCustomType;
        dr["Genre"] = strGenre;
        dr["Money"] = strMoney;
        dr["Calling"] = strCalling;
        dr["CallingTxt"] = strCallingTxt;
        dr["SmallCalling"] = strSmallCalling;
        dr["SmallCallingTxt"] = strSmallCallingTxt;
        dr["City"] = strCity;
        dr["CityTxt"] = strCityTxt;
        dr["Keyword"] = strKeyword;
        dr["ValidateTerm"] = iValidateTerm;

        dr["Accept"] = bAccept;
        dr["CustomCyc"] = iCustomCyc;
        dr["ItemCount"] = iItemCount;
        dr["Email"] = strEmail;

        dr["CooperationDemandTypeID"] = strCooperationDemandTypeID;//合作方式
        dr["currency"] = strCurrency;//币种

        dt.Rows.Add(dr);

        DataSet ds = new DataSet();
        ds.Tables.Add(dt);

        Session["CustomInfo"] = ds;

        #endregion

    }

    #endregion

    #region 修改后 保存session
    private void MackUpdateTable()
    {
        #region 变量定义
        string strCustomType = this.ViewState["CustomType"].ToString();
        string strTitle = this.ViewState["Title"].ToString();
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

        bool bAccept = Convert.ToBoolean(this.ViewState["Accept"]);
        int iCustomCyc = Convert.ToInt32(this.ViewState["CustomCyc"]);
        int iItemCount = Convert.ToInt32(this.ViewState["ItemCount"]);
        string strEmail = this.ViewState["Email"].ToString();

        #endregion

        #region  变量赋值

        if (strCustomType == "0")
        {
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

            //for (int i = 0; i < this.chkIndustry.Items.Count; i++)
            //{
            //    if (this.chkIndustry.Items[i].Selected)
            //    {
            //        strCalling = strCalling + this.chkIndustry.Items[i].Value.Trim() + "|";

            //    }
            //}
            strCalling = this.hideIndustryB.Value.Trim();
            if (strCalling.Trim() != "")
            {
                strCalling = strCalling.Substring(0, strCalling.Length - 1);
            }
            for (int i = 0; i < this.chkLstCooperationDemand2.Items.Count; i++)
            {
                if (this.chkLstCooperationDemand2.Items[i].Selected)
                {
                    strCooperationDemandTypeID = strCooperationDemandTypeID + this.chkLstCooperationDemand2.Items[i].Value.Trim() + "|";
                }
            }
            strCity = hideProvince.Value.Trim();
        }
        else if (strCustomType == "1")
        {
            for (int i = 0; i < this.chkCapitalType.Items.Count; i++)
            {
                if (this.chkCapitalType.Items[i].Selected)
                {
                    strGenre = strGenre + this.chkCapitalType.Items[i].Value.Trim() + "|";
                }
            }
            if (strGenre.Trim() != "")
            {
                strGenre = strGenre.Substring(0, strGenre.Length - 1);
            }
            for (int i = 0; i < this.chkLstCooperationDemand.Items.Count; i++)
            {
                if (this.chkLstCooperationDemand.Items[i].Selected)
                {
                    strCooperationDemandTypeID = strCooperationDemandTypeID + this.chkLstCooperationDemand.Items[i].Value.Trim() + "|";
                }
            }
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
            strCity = hideProvince.Value.Trim();
            strCurrency = ddlCapitalCurrency.SelectedValue.ToString();
            strCalling = this.hideIndustryB.Value.Trim();
            strCallingTxt = this.hideIndustryBtxt.Value.Trim();
            strSmallCalling = this.hideIndustryM.Value.Trim();
            strSmallCallingTxt = this.hideIndustryMtxt.Value.Trim();
        }
        else if (strCustomType == "2")
        {
            for (int i = 0; i < this.chkLstCooperationDemand.Items.Count; i++)
            {
                if (this.chkLstCooperationDemand.Items[i].Selected)
                {
                    strCooperationDemandTypeID = strCooperationDemandTypeID + this.chkLstCooperationDemand.Items[i].Value.Trim() + "|";
                }
            }
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
            strCurrency = ddlCapitalCurrency.SelectedValue.ToString();
            strCalling = this.hideIndustryB.Value.Trim();
            strCallingTxt = this.hideIndustryBtxt.Value.Trim();
            strSmallCalling = this.hideIndustryM.Value.Trim();
            strSmallCallingTxt = this.hideIndustryMtxt.Value.Trim();
            strCity = this.hideProvince.Value.Trim();
            strCityTxt = this.hideProvincetxt.Value.Trim();
        }

            //创业
        else if (strCustomType == "3")
        {
            strType = rblCarveoutType.SelectedValue.ToString().Trim();

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
            strCurrency = ddlCapitalCurrency.SelectedValue.ToString();
            strCalling = this.hideIndustryCarveout.Value.Trim();
            strCallingTxt = this.hideIndustryCarveouttxt.Value.Trim();
            strCity = this.hideProvince.Value.Trim();
            strCityTxt = this.hideProvincetxt.Value.Trim();
        }

            //商机
        else if (strCustomType == "4")
        {
            strType = rblOpporType.SelectedValue.ToString().Trim();

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
            strCurrency = ddlCapitalCurrency.SelectedValue.ToString();
            strCalling = this.hideIndustryOppor.Value.Trim();
            strCallingTxt = this.hideIndustryOpportxt.Value.Trim();
            strCity = this.hideProvince.Value.Trim();
            strCityTxt = this.hideProvincetxt.Value.Trim();
        }

        else if (strCustomType == "5")
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
        else
        {
        }
        #endregion

        #region 将信添加至session

        DataTable dt = null;
        dt = MakeTable();
        DataRow dr;
        dr = dt.NewRow();
        dr["Title"] = strTitle;
        dr["LoginName"] = this.ViewState["MemberLoginName"].ToString();
        dr["Type"] = strType;
        dr["CustomType"] = strCustomType;
        dr["Genre"] = strGenre;
        if (strMoney == "")
        {
            strMoney = "0";
        }
        dr["Money"] = strMoney;
        dr["Calling"] = strCalling;
        dr["CallingTxt"] = strCallingTxt;
        dr["SmallCalling"] = strSmallCalling;
        dr["SmallCallingTxt"] = strSmallCallingTxt;
        dr["City"] = strCity;
        dr["CityTxt"] = strCityTxt;
        dr["Keyword"] = strKeyword;
        dr["ValidateTerm"] = iValidateTerm;

        dr["Accept"] = bAccept;
        dr["CustomCyc"] = iCustomCyc;
        dr["ItemCount"] = iItemCount;
        dr["Email"] = strEmail;
        dr["CooperationDemandTypeID"] = strCooperationDemandTypeID;//合作方式
        dr["currency"] = strCurrency;//币种
        dt.Rows.Add(dr);

        DataSet ds = new DataSet();
        ds.Tables.Add(dt);
        Session["CustomInfo"] = ds;


        #endregion
    }

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
            string Criteria = "LoginName = '" + this.ViewState["MemberLoginName"].ToString() + "'";

            Tz888.SQLServerDAL.Conn customObj = new Tz888.SQLServerDAL.Conn();
            DataTable dt = customObj.GetList("CustomInfoTab", "ID", "ID", 1, 1, 0, 1, Criteria);

            if (dt != null )
            {
                MackAddTable();
                Response.Redirect("ModifyMaching.aspx?tag=Add");
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
        if (this.ViewState["tag"].ToString() == "update")
        {
            MackUpdateTable();
        }
        else
        {
            MackAddTable();
        }
        Response.Redirect("MachingMessage.aspx");
    }
}
