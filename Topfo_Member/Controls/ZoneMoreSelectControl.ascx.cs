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
using System.Collections.Generic;

namespace Tz888.Member.Controls
{
    [ToolboxData("<{0}:ZoneMoreSelectControl runat=\"server\" />")]
    public partial class ZoneMoreSelectControl : System.Web.UI.UserControl
    {
        private int _maxCount = 5;//允许添加的总投资区域数
        public int MaxCount
        {
            get { return _maxCount; }
            set { _maxCount = value; }
        }
        private List<Tz888.Model.Info.CapitalInfoAreaModel> _capitalInfoAreaModels = new List<Tz888.Model.Info.CapitalInfoAreaModel>();

        public List<Tz888.Model.Info.CapitalInfoAreaModel> CapitalInfoAreaModels
        {
            get {
                string SelectValue = this.hideSelectZone.Value.Trim();//获取所有已选择的区域的
                if (!string.IsNullOrEmpty(SelectValue))
                {
                    string[] ZoneList = SelectValue.Split('|');
                    for (int i = 0; i < ZoneList.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(ZoneList[i].ToString()))
                        {
                            string[] TmpList = ZoneList[i].ToString().Split(',');
                            Tz888.Model.Info.CapitalInfoAreaModel model = new Tz888.Model.Info.CapitalInfoAreaModel();
                            try
                            {
                                model.CountryCode = TmpList[0].ToString();
                                model.ProvinceID = TmpList[1].ToString();
                                model.CityID = TmpList[2].ToString();
                                model.CountyID = TmpList[3].ToString();
                            }
                            catch { }
                            this._capitalInfoAreaModels.Add(model);
                        }
                    }
                }
                return _capitalInfoAreaModels; }
            set { _capitalInfoAreaModels = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            AjaxPro.Utility.RegisterTypeForAjax(typeof(Tz888.Common.Ajax.AjaxMethod));
            if (!Page.IsPostBack)
            {
                this.LoadInfo();
            }
        }

        public void LoadInfo()
        {
            int listCount = 0;
            if (this._capitalInfoAreaModels != null)
            {
                Tz888.BLL.Common.ZoneSelectBLL bll = new Tz888.BLL.Common.ZoneSelectBLL();
                foreach (Tz888.Model.Info.CapitalInfoAreaModel model in this._capitalInfoAreaModels)
                {
                    string strText = "";
                    string strValue = "";
                    strText = bll.GetCountryNameByCode(model.CountryCode).Trim() + " ";
                    strValue = model.CountryCode.Trim();
                    if ((!string.IsNullOrEmpty(strText)) && (!string.IsNullOrEmpty(strValue)))
                    {
                        if (model.ProvinceID.Trim() != "")
                        {
                            strText += bll.GetProvinceNameByCode(model.ProvinceID).Trim() + " ";
                            strValue += "," + model.ProvinceID.Trim();
                            if (model.CityID.Trim() != "")
                            {
                                strText += bll.GetCityNameByCode(model.CityID).Trim() + " ";
                                strValue += "," + model.CityID.Trim();
                                if (model.CountyID.Trim() != "")
                                {
                                    strText += bll.GetCountyNameByCode(model.CountyID).Trim() + " ";
                                    strValue += "," + model.CountyID.Trim();
                                }
                            }
                        }
                        ListItem li = new ListItem(strText, strValue);
                        this.sltZone_Select.Items.Add(li);
                        this.hideSelectZone.Value += strValue + "|";
                        listCount++;
                    }
                }
            }
            this.hidListCount.Value = listCount.ToString();
        }
    }
}