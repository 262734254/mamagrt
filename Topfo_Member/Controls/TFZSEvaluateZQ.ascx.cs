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

public partial class Controls_TFZSEvaluateZQ : TFZSEvaluateBase
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

        for (int i = 0; i < this.cbl12.Items.Count; i++)
        {
            this.cbl12.Items[i].Attributes.Add("onclick", "CheckBoxListCheckSelect('" + this.cbl12.ClientID + "',this);");
        }

        for (int i = 0; i < this.cbl13.Items.Count; i++)
        {
            this.cbl13.Items[i].Attributes.Add("onclick", "CheckBoxListCheckSelect('" + this.cbl13.ClientID + "',this);");
        }

        for (int i = 0; i < this.cbl15.Items.Count; i++)
        {
            this.cbl15.Items[i].Attributes.Add("onclick", "CheckBoxListCheckSelect('" + this.cbl15.ClientID + "',this);");
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

        this.cbl1.DataSource = msbll.GetListByExpressCode("1");
        this.cbl1.DataValueField = "MeasureCode";
        this.cbl1.DataTextField = "MeasureName";
        this.cbl1.DataBind();

        this.rbl2.DataSource = msbll.GetListByExpressCode("2");
        this.rbl2.DataValueField = "MeasureCode";
        this.rbl2.DataTextField = "MeasureName";
        this.rbl2.DataBind();

        this.rbl3.DataSource = msbll.GetListByExpressCode("3");
        this.rbl3.DataValueField = "MeasureCode";
        this.rbl3.DataTextField = "MeasureName";
        this.rbl3.DataBind();

        this.rbl4.DataSource = msbll.GetListByExpressCode("4");
        this.rbl4.DataValueField = "MeasureCode";
        this.rbl4.DataTextField = "MeasureName";
        this.rbl4.DataBind();

        this.rbl5.DataSource = msbll.GetListByExpressCode("5");
        this.rbl5.DataValueField = "MeasureCode";
        this.rbl5.DataTextField = "MeasureName";
        this.rbl5.DataBind();

        this.rbl6.DataSource = msbll.GetListByExpressCode("6");
        this.rbl6.DataValueField = "MeasureCode";
        this.rbl6.DataTextField = "MeasureName";
        this.rbl6.DataBind();

        this.rbl7.DataSource = msbll.GetListByExpressCode("7");
        this.rbl7.DataValueField = "MeasureCode";
        this.rbl7.DataTextField = "MeasureName";
        this.rbl7.DataBind();

        this.rbl8.DataSource = msbll.GetListByExpressCode("8");
        this.rbl8.DataValueField = "MeasureCode";
        this.rbl8.DataTextField = "MeasureName";
        this.rbl8.DataBind();

        this.rbl9.DataSource = msbll.GetListByExpressCode("9");
        this.rbl9.DataValueField = "MeasureCode";
        this.rbl9.DataTextField = "MeasureName";
        this.rbl9.DataBind();

        this.rbl10.DataSource = msbll.GetListByExpressCode("10");
        this.rbl10.DataValueField = "MeasureCode";
        this.rbl10.DataTextField = "MeasureName";
        this.rbl10.DataBind();

        this.rbl11.DataSource = msbll.GetListByExpressCode("11");
        this.rbl11.DataValueField = "MeasureCode";
        this.rbl11.DataTextField = "MeasureName";
        this.rbl11.DataBind();

        this.cbl12.DataSource = msbll.GetListByExpressCode("12");
        this.cbl12.DataValueField = "MeasureCode";
        this.cbl12.DataTextField = "MeasureName";
        this.cbl12.DataBind();

        this.cbl13.DataSource = msbll.GetListByExpressCode("13");
        this.cbl13.DataValueField = "MeasureCode";
        this.cbl13.DataTextField = "MeasureName";
        this.cbl13.DataBind();

        this.rbl14.DataSource = msbll.GetListByExpressCode("14");
        this.rbl14.DataValueField = "MeasureCode";
        this.rbl14.DataTextField = "MeasureName";
        this.rbl14.DataBind();

        this.cbl15.DataSource = msbll.GetListByExpressCode("15");
        this.cbl15.DataValueField = "MeasureCode";
        this.cbl15.DataTextField = "MeasureName";
        this.cbl15.DataBind();

        #endregion
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

    public override decimal GetEvaluate()
    {
        decimal num = 0;
        num += this.Save(this.cbl1, "1", false);
        num += this.Save(this.rbl2, "2", false);
        num += this.Save(this.rbl3, "3", false);
        num += this.Save(this.rbl4, "4", false);
        num += this.Save(this.rbl5, "5", false);
        num += this.Save(this.rbl6, "6", false);
        num += this.Save(this.rbl7, "7", false);
        num += this.Save(this.rbl8, "8", false);
        num += this.Save(this.rbl9, "9", false);
        num += this.Save(this.rbl10, "10", false);
        num += this.Save(this.rbl11, "11", false);
        num += this.Save(this.cbl12, "12", false);
        num += this.Save(this.cbl13, "13", false);
        num += this.Save(this.rbl14, "14", false);
        num += this.Save(this.cbl15, "15", false);

        return num;
    }

    public override decimal SaveEvaluate()
    {
        this.InfoID = Convert.ToInt64(this.ViewState["InfoID"]);
        if (this.InfoID == 0)
            return 0;
        decimal num = 0;
        num += this.Save(this.cbl1, "1", false);
        num += this.Save(this.rbl2, "2", false);
        num += this.Save(this.rbl3, "3", false);
        num += this.Save(this.rbl4, "4", false);
        num += this.Save(this.rbl5, "5", false);
        num += this.Save(this.rbl6, "6", false);
        num += this.Save(this.rbl7, "7", false);
        num += this.Save(this.rbl8, "8", false);
        num += this.Save(this.rbl9, "9", false);
        num += this.Save(this.rbl10, "10", false);
        num += this.Save(this.rbl11, "11", false);
        num += this.Save(this.cbl12, "12", false);
        num += this.Save(this.cbl13, "13", false);
        num += this.Save(this.rbl14, "14", false);
        num += this.Save(this.cbl15, "15", false);

        this.Save(this.cblIsNewIndustry, "35", true);
        this.Save(this.cblProjectInstance, "36", true);

        return num;
    }

    protected void btnGetEvaluate_Click(object sender, EventArgs e)
    {
        this.lblInfo.Text = "拓富指数评价得分：" + this.GetEvaluate();
    }
}