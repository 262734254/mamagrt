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
using Tz888.Model;
using Tz888.BLL;

namespace Tz888.Member.Controls
{
    /// <summary>
    /// 行业类别选择控件
    /// 创建:CLandy.lee
    /// </summary>
    public partial class SelectIndustryControl : System.Web.UI.UserControl
    {
        /// <summary>
        /// 最大允许选择行业数
        /// </summary>
        private int _maxCount = 5;
        /// <summary>
        /// 已选择行业数
        /// </summary>
        private int _selectCount = 0;
        /// <summary>
        /// 已选中的行业集合(用于读取)
        /// </summary>
        private List<Tz888.Model.Common.IndustryModel> _industryModels = new List<Tz888.Model.Common.IndustryModel>();

        /// <summary>
        /// 选中行业的代码集合(用于设置)
        /// </summary>
        private string _industryString;

        /// <summary>
        /// 最大选择行业数
        /// </summary>
        public int MaxCount
        {
            get { return _maxCount; }
            set { _maxCount = value; }
        }
        /// <summary>
        /// 已选择行业数
        /// </summary>
        public int SelectCount
        {
            get { return _selectCount; }
        }

        /// <summary>
        /// 已选择行业集合(只读)
        /// </summary>
        public List<Tz888.Model.Common.IndustryModel> IndustryModels
        {
            get
            {
                string SelectValue = this.hdselectValue.Value.Trim();//获取所有已选择的行业
                if (!string.IsNullOrEmpty(SelectValue))
                {
                    string[] IndustryList = SelectValue.Split('|');
                    for (int i = 0; i < IndustryList.Length; i++)
                    {
                        string[] TmpList = IndustryList[i].ToString().Split(',');
                        Tz888.Model.Common.IndustryModel model = new Tz888.Model.Common.IndustryModel();
                        try
                        {
                            model.IndustryBName = TmpList[0].ToString();
                            model.IndustryBID = TmpList[1].ToString();
                            this._industryModels.Add(model);
                        }
                        catch { }
                    }
                }
                return _industryModels;
            }
        }

        public string IndustryString
        {
            get
            {
                string SelectValue = this.hdselectValue.Value.Trim();//获取所有已选择的行业
                if (!string.IsNullOrEmpty(SelectValue))
                {
                    string[] IndustryList = SelectValue.Split('|');
                    for (int i = 0; i < IndustryList.Length; i++)
                    {
                        string[] TmpList = IndustryList[i].ToString().Split(',');
                        try
                        {
                            this._industryString += TmpList[1].ToString().Trim() + ",";
                        }
                        catch { }
                    }
                }
                return this._industryString;
            }
            set
            {
                _industryString = value;
                if (!string.IsNullOrEmpty(_industryString))
                {
                    Tz888.BLL.Common.IndustryBLL bll = new Tz888.BLL.Common.IndustryBLL();
                    string IndustryList = "";
                    int count = 0;
                    string[] IndustryIDList = _industryString.Split(',');
                    for (int i = 0; i < IndustryIDList.Length; i++)
                    {
                        string IndustryID = IndustryIDList[i].Trim();
                        if (!string.IsNullOrEmpty(IndustryID))
                        {
                            string IndustryName = "";
                            IndustryName = bll.GetNameByID(IndustryID);
                            string temp = IndustryName + "," + IndustryID + "|";
                            IndustryList += temp;

                            ListItem tmpLi = new ListItem();
                            tmpLi.Value = IndustryID;
                            tmpLi.Text = IndustryName;

                            this.sltIndustryName_Select.Items.Add(tmpLi);
                            this.sltIndustryName_all.Items.Remove(tmpLi);
                            count++;
                        }
                    }
                    this._selectCount = count;
                    this.hdselectValue.Value = IndustryList;
                }
            }
        }
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.BindIndustry();
            }
        }

        /// <summary>
        /// 绑定所有行业类型信息到页面
        /// </summary>
        private void BindIndustry()
        {
            BLL.Common.IndustryBLL objIndustry = new Tz888.BLL.Common.IndustryBLL();
            this.sltIndustryName_all.DataSource = objIndustry.GetAllList();
            this.sltIndustryName_all.DataTextField = "IndustryBName";
            this.sltIndustryName_all.DataValueField = "IndustryBID";
            this.sltIndustryName_all.DataBind();
        }
    }
}