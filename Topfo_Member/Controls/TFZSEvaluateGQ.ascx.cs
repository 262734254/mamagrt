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

public partial class Controls_TFZSEvaluateGQ : TFZSEvaluateBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.InitOptions();
        }

        for (int i = 0; i < this.cblProjectInstance.Items.Count; i++)
        {
            this.cblProjectInstance.Items[i].Attributes.Add("onclick", "CheckBoxListCheckSelect('" + this.cblProjectInstance.ClientID + "',this);");
        }

        for (int i = 0; i < this.cbl22.Items.Count; i++)
        {
            this.cbl22.Items[i].Attributes.Add("onclick", "CheckBoxListCheckSelect('" + this.cbl22.ClientID + "',this);");
        }

        for (int i = 0; i < this.cbl34.Items.Count; i++)
        {
            this.cbl34.Items[i].Attributes.Add("onclick", "CheckBoxListCheckSelect('" + this.cbl34.ClientID + "',this);");
        }
        this.btnGetEvaluate.Attributes.Add("onclick", "loading();");
    }

    private void InitOptions()
    {
        #region 加载评价数据
        Tz888.BLL.TFZS.MeasureStandard msbll = new Tz888.BLL.TFZS.MeasureStandard();

        this.cblIsNewIndustry.DataSource = msbll.GetListByExpressCode("35");
        this.cblIsNewIndustry.DataValueField = "MeasureCode";
        this.cblIsNewIndustry.DataTextField = "MeasureName";
        this.cblIsNewIndustry.DataBind();

        this.cblProjectInstance.DataSource = msbll.GetListByExpressCode("36");
        this.cblProjectInstance.DataValueField = "MeasureCode";
        this.cblProjectInstance.DataTextField = "MeasureName";
        this.cblProjectInstance.DataBind();

        this.rbl16.DataSource = msbll.GetListByExpressCode("16");
        this.rbl16.DataValueField = "MeasureCode";
        this.rbl16.DataTextField = "MeasureName";
        this.rbl16.DataBind();

        this.cbl17.DataSource = msbll.GetListByExpressCode("17");
        this.cbl17.DataValueField = "MeasureCode";
        this.cbl17.DataTextField = "MeasureName";
        this.cbl17.DataBind();

        this.rbl18.DataSource = msbll.GetListByExpressCode("18");
        this.rbl18.DataValueField = "MeasureCode";
        this.rbl18.DataTextField = "MeasureName";
        this.rbl18.DataBind();

        this.rbl19.DataSource = msbll.GetListByExpressCode("19");
        this.rbl19.DataValueField = "MeasureCode";
        this.rbl19.DataTextField = "MeasureName";
        this.rbl19.DataBind();

        this.rbl20.DataSource = msbll.GetListByExpressCode("20");
        this.rbl20.DataValueField = "MeasureCode";
        this.rbl20.DataTextField = "MeasureName";
        this.rbl20.DataBind();

        this.rbl21.DataSource = msbll.GetListByExpressCode("21");
        this.rbl21.DataValueField = "MeasureCode";
        this.rbl21.DataTextField = "MeasureName";
        this.rbl21.DataBind();

        this.cbl22.DataSource = msbll.GetListByExpressCode("22");
        this.cbl22.DataValueField = "MeasureCode";
        this.cbl22.DataTextField = "MeasureName";
        this.cbl22.DataBind();

        this.rbl23.DataSource = msbll.GetListByExpressCode("23");
        this.rbl23.DataValueField = "MeasureCode";
        this.rbl23.DataTextField = "MeasureName";
        this.rbl23.DataBind();

        this.cbl24.DataSource = msbll.GetListByExpressCode("24");
        this.cbl24.DataValueField = "MeasureCode";
        this.cbl24.DataTextField = "MeasureName";
        this.cbl24.DataBind();

        this.rbl25.DataSource = msbll.GetListByExpressCode("25");
        this.rbl25.DataValueField = "MeasureCode";
        this.rbl25.DataTextField = "MeasureName";
        this.rbl25.DataBind();

        this.rbl26.DataSource = msbll.GetListByExpressCode("26");
        this.rbl26.DataValueField = "MeasureCode";
        this.rbl26.DataTextField = "MeasureName";
        this.rbl26.DataBind();

        this.rbl27.DataSource = msbll.GetListByExpressCode("27");
        this.rbl27.DataValueField = "MeasureCode";
        this.rbl27.DataTextField = "MeasureName";
        this.rbl27.DataBind();

        this.rbl28.DataSource = msbll.GetListByExpressCode("28");
        this.rbl28.DataValueField = "MeasureCode";
        this.rbl28.DataTextField = "MeasureName";
        this.rbl28.DataBind();

        this.rbl29.DataSource = msbll.GetListByExpressCode("29");
        this.rbl29.DataValueField = "MeasureCode";
        this.rbl29.DataTextField = "MeasureName";
        this.rbl29.DataBind();

        this.rbl30.DataSource = msbll.GetListByExpressCode("30");
        this.rbl30.DataValueField = "MeasureCode";
        this.rbl30.DataTextField = "MeasureName";
        this.rbl30.DataBind();

        this.rbl31.DataSource = msbll.GetListByExpressCode("31");
        this.rbl31.DataValueField = "MeasureCode";
        this.rbl31.DataTextField = "MeasureName";
        this.rbl31.DataBind();

        this.rbl32.DataSource = msbll.GetListByExpressCode("32");
        this.rbl32.DataValueField = "MeasureCode";
        this.rbl32.DataTextField = "MeasureName";
        this.rbl32.DataBind();

        this.rbl33.DataSource = msbll.GetListByExpressCode("33");
        this.rbl33.DataValueField = "MeasureCode";
        this.rbl33.DataTextField = "MeasureName";
        this.rbl33.DataBind();

        this.cbl34.DataSource = msbll.GetListByExpressCode("34");
        this.cbl34.DataValueField = "MeasureCode";
        this.cbl34.DataTextField = "MeasureName";
        this.cbl34.DataBind();



        #endregion
    }

    public override decimal GetEvaluate()
    {
        decimal num = 0;
        num += this.Save(this.rbl16, "16", false);
        num += this.Save(this.cbl17, "17", false);
        num += this.Save(this.rbl18, "18", false);
        num += this.Save(this.rbl19, "19", false);
        num += this.Save(this.rbl20, "20", false);
        num += this.Save(this.rbl21, "21", false);
        num += this.Save(this.cbl22, "22", false);
        num += this.Save(this.rbl23, "23", false);
        num += this.Save(this.cbl24, "24", false);
        num += this.Save(this.rbl25, "25", false);
        num += this.Save(this.rbl26, "26", false);
        num += this.Save(this.rbl27, "27", false);
        num += this.Save(this.rbl28, "28", false);
        num += this.Save(this.rbl29, "29", false);
        num += this.Save(this.rbl30, "30", false);
        num += this.Save(this.rbl31, "31", false);
        num += this.Save(this.rbl32, "32", false);
        num += this.Save(this.rbl33, "33", false);
        num += this.Save(this.cbl34, "34", false);

        return num;
    }

    public override decimal SaveEvaluate()
    {
        this.InfoID = Convert.ToInt64(this.ViewState["InfoID"]);
        if (this.InfoID == 0)
            return 0;
        decimal num = 0;
        num += this.Save(this.rbl16, "16", true);
        num += this.Save(this.cbl17, "17", true);
        num += this.Save(this.rbl18, "18", true);
        num += this.Save(this.rbl19, "19", true);
        num += this.Save(this.rbl20, "20", true);
        num += this.Save(this.rbl21, "21", true);
        num += this.Save(this.cbl22, "22", true);
        num += this.Save(this.rbl23, "23", true);
        num += this.Save(this.cbl24, "24", true);
        num += this.Save(this.rbl25, "25", true);
        num += this.Save(this.rbl26, "26", true);
        num += this.Save(this.rbl27, "27", true);
        num += this.Save(this.rbl28, "28", true);
        num += this.Save(this.rbl29, "29", true);
        num += this.Save(this.rbl30, "30", true);
        num += this.Save(this.rbl31, "31", true);
        num += this.Save(this.rbl32, "32", true);
        num += this.Save(this.rbl33, "33", true);
        num += this.Save(this.cbl34, "34", true);

        this.Save(this.cblIsNewIndustry, "35", true);
        this.Save(this.cblProjectInstance, "36", true);

        return num;
    }

    private decimal Save(RadioButtonList rbl, string code, bool IsSave)
    {
        Tz888.Model.TFZS.TFZS_ProjectDetaiSubModel model = new Tz888.Model.TFZS.TFZS_ProjectDetaiSubModel();
        model.id = 0;
        model.InfoID = this.InfoID;
        model.ExpressCode = code;
        model.DicMainCode = "";
        model.TARGET_ANSWER = rbl.SelectedValue.Trim();
        model.TARGET_POINT = 0;

        Tz888.BLL.TFZS.TFZS_ProjectDetaiSubBLL bll = new Tz888.BLL.TFZS.TFZS_ProjectDetaiSubBLL();

        return bll.Save(model, IsSave);
    }

    private decimal Save(CheckBoxList cbl, string code, bool IsSave)
    {
        Tz888.Model.TFZS.TFZS_ProjectDetaiSubModel model = new Tz888.Model.TFZS.TFZS_ProjectDetaiSubModel();
        string Answer = "";
        for (int i = 0; cbl.Items.Count > i; i++)
        {
            if (cbl.Items[i].Selected)
            {
                Answer += cbl.Items[i].Value.Trim() + ",";
            }
        }
        model.id = 0;
        model.InfoID = this.InfoID;
        model.ExpressCode = code;
        model.DicMainCode = "";
        model.TARGET_ANSWER = Answer;
        model.TARGET_POINT = 0;

        Tz888.BLL.TFZS.TFZS_ProjectDetaiSubBLL bll = new Tz888.BLL.TFZS.TFZS_ProjectDetaiSubBLL();

        return bll.Save(model, IsSave);
    }

    protected void btnGetEvaluate_Click(object sender, EventArgs e)
    {
        this.lblInfo.Text = "拓富指数评价得分：" + this.GetEvaluate();
    }
}
