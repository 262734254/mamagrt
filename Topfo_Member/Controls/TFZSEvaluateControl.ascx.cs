using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.ComponentModel;
using System.Text;
public partial class Controls_TFZSEvaluateControl_ZQ : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.InitOptions();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    private void InitOptions()
    {
        Tz888.BLL.TFZS.ExpressTarget bll = new Tz888.BLL.TFZS.ExpressTarget();
        this.RfOptions.DataSource = bll.GetListByMainTargetType("GQ");
        this.RfOptions.DataBind();
    }

    /// <summary>
    /// 生成评价项细则选项
    /// </summary>
    /// <param name="ExpressCode"></param>
    /// <param name="IsMulti"></param>
    /// <returns></returns>
    protected string GetOptionDetails(string ExpressCode,bool IsMulti)
    {
        string inputmodel = "<INPUT id={0} type={1} value={2} name={3}><LABEL title=\"{4}\" for={5}>{6}&nbsp;&nbsp;</LABEL>";
        StringBuilder sb = new StringBuilder();

        Tz888.BLL.TFZS.MeasureStandard bll = new Tz888.BLL.TFZS.MeasureStandard();

        List<Tz888.Model.TFZS.TFZS_MeasureStandard> lists = new List<Tz888.Model.TFZS.TFZS_MeasureStandard>();

        lists = bll.GetListByExpressCode(ExpressCode);

        string Type = "radio";
        if (IsMulti)
            Type = "checkbox";
        foreach (Tz888.Model.TFZS.TFZS_MeasureStandard model in lists)
        {
            string temp = string.Format(inputmodel, Type + model.MeasureCode.Trim(),
                                            Type, model.MeasureCode.Trim(), Type + "_" + ExpressCode.Trim(),
                                            model.MeasureName.Trim(), Type + model.MeasureCode.Trim(), model.MeasureName.Trim());
            sb.Append(temp);
        }
        return sb.ToString();
    }
}