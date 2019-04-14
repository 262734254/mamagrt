using System;
using System.Collections;
using System.Configuration;
using System.Data;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;


public partial class Controls_ServiesControl : System.Web.UI.UserControl
{
    public string _ServicesBID;
    public string ServicesBID
    {
        get
        {
            this._ServicesBID = "";
            string SelectBValue = this.hdselectBValue.Value.Trim();//获取所有已选择的一级分类


            if (!string.IsNullOrEmpty(SelectBValue))
            {
                string[] ServiesList = SelectBValue.Split('&');
                for (int i = 0; i < ServiesList.Length; i++)
                {
                    string[] TmpList = ServiesList[i].ToString().Split(',');
                    try
                    {

                        this._ServicesBID += TmpList[1].ToString().Trim() + ",";
                    }
                    catch { }
                }
            }
            return this._ServicesBID;
        }

    }

    public string _ServicesMID;
    public string ServicesMID
    {
        get
        {
            this._ServicesMID = "";
            string SelectMValue = this.hdselectMValue.Value.Trim();//获取所有已选择的一级分类


            if (!string.IsNullOrEmpty(SelectMValue))
            {
                string[] ServiesList = SelectMValue.Split('&');
                for (int i = 0; i < ServiesList.Length; i++)
                {
                    string[] TmpList = ServiesList[i].ToString().Split(',');
                    try
                    {

                        this._ServicesMID += TmpList[1].ToString().Trim() + ",";
                    }
                    catch { }
                }
            }
            return this._ServicesMID;
        }
    }
    public string _ServiesBString;
    public string ServiesBString
    {
        get
        {
            _ServiesBString = ServicesBID + "|" + ServicesMID;
            return this._ServiesBString;
        }
        set
        {
            _ServiesBString = value;
            if (!string.IsNullOrEmpty(_ServiesBString))
            {
                Tz888.BLL.Union dal = new Tz888.BLL.Union();
                string[] BList = _ServiesBString.Split('|');
                this.sltServiesName_Select.Items.Clear();

                if (BList[0] != "")//1
                {
                    string[] bidList = BList[0].Split(',');
                    string tempb = "";
                    for (int i = 0; i < bidList.Length; i++)
                    {
                        string ServiesBName = "";
                        string bid = bidList[i].ToString();
                        if (bid != "" &bid !=null)
                        {
                            ServiesBName = dal.GetServiesBNameByID(Convert.ToInt32(bid));
                            tempb += ServiesBName + "," + bid + "&";

                            ListItem tmpLi = new ListItem();
                            tmpLi.Value = bid;
                            tmpLi.Text = ServiesBName;
                            if (sltServiesName_Select.Items.FindByText(ServiesBName) == null)
                            {
                                this.sltServiesName_Select.Items.Add(tmpLi);
                            }
                        }
                    }
                    this.hdselectBValue.Value = tempb;
                }
                if (BList[1] != "")//2
                {
                    string[] midList = BList[1].Split(',');
                    string tempm = "";
                    for (int i = 0; i < midList.Length; i++)
                    {
                        string ServiesMName = "";
                        string mid = midList[i].ToString();
                        if (mid.Trim() != "")
                        {
                            ServiesMName = dal.GetServiesMNameByID(Convert.ToInt32(mid));
                            tempm += dal.GetBNameByMID(Convert.ToInt32(mid)) + "-" + ServiesMName + "," + mid + "&";

                            ListItem tmpLiM = new ListItem();
                            tmpLiM.Value = "10|" + mid;
                            tmpLiM.Text = dal.GetBNameByMID(Convert.ToInt32(mid)) + "-" + ServiesMName;

                            if (sltServiesName_Select.Items.FindByText(ServiesMName) == null)
                            {
                                this.sltServiesName_Select.Items.Add(tmpLiM);
                            }
                        }
                    }
                    this.hdselectMValue.Value = tempm;
                }
            }
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        AjaxPro.Utility.RegisterTypeForAjax(typeof(Tz888.Common.Ajax.AjaxServies));

        if (IsPostBack)
        {
            string tmpB = this.ServiesBString;
            this.ServiesBString = tmpB;
        }
    }

}