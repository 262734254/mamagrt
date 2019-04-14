using System;
using System.Collections.Generic;
using System.Text;
using Tz888.BLL.Common;
using System.Data;
//using SelfCreateWeb.Model;
//using SelfCreateWeb.BLL;
//using SelfCreateWeb.Common;

namespace Tz888.Common.Ajax
{
    [AjaxPro.AjaxNamespace("AjaxMethod")]
    public class AjaxMethod
    {

        #region 中文版地区数据绑定
        #region GetCountryList 国家
        [AjaxPro.AjaxMethod]
        public string GetCountryList()
        {
            Tz888.BLL.Common.ZoneSelectBLL bll = new Tz888.BLL.Common.ZoneSelectBLL();
            DataView dv = new DataView();
            try
            {
                dv = bll.GetCountryList();
            }
            catch
            {
            }
            string str = ",";
            for (int m = 0; m < dv.Table.Rows.Count; m++)
            {
                str += "," + dv[m]["CountryCode"].ToString().Trim() + "|" + dv[m]["CountryName"].ToString().Trim();
            }
            return str;
        }
        #endregion

        #region GetProvinceList 省份
        [AjaxPro.AjaxMethod]
        public string GetProvinceList(string CountryID)
        {
            Tz888.BLL.Common.ZoneSelectBLL bll = new Tz888.BLL.Common.ZoneSelectBLL();
            DataView dv = bll.GetProvinceList(CountryID);

            string str = "|省份";
            if (dv == null)
                return str;
            for (int m = 0; m < dv.Table.Rows.Count; m++)
            {
                str += "," + dv[m]["ProvinceID"].ToString().Trim() + "|" + dv[m]["ProvinceName"].ToString().Trim();
            }
            //str=str.Substring(1,str.Length-1);
            return str;
        }
        #endregion

        #region GetCityList 城市
        [AjaxPro.AjaxMethod]
        public string GetCityList(string ProvinceID)
        {
            Tz888.BLL.Common.ZoneSelectBLL bll = new Tz888.BLL.Common.ZoneSelectBLL();
            DataView dv = bll.GetCityList(ProvinceID);

            string str = "|地级市";
            if (dv == null)
                return str;
            for (int m = 0; m < dv.Table.Rows.Count; m++)
            {
                str += "," + dv[m]["CityID"].ToString().Trim() + "|" + dv[m]["CityName"].ToString().Trim();
            }
            //str=str.Substring(1,str.Length-1);
            return str;
        }
        #endregion

        #region GetCountyList 县
        [AjaxPro.AjaxMethod]
        public string GetCountyList(string CityID)
        {
            Tz888.BLL.Common.ZoneSelectBLL bll = new Tz888.BLL.Common.ZoneSelectBLL();
            DataView dv = bll.GetCountyList(CityID);

            string str = "|县级地区";
            if (dv == null)
                return str;
            for (int m = 0; m < dv.Table.Rows.Count; m++)
            {
                try
                {
                    str += "," + dv[m]["CountyID"].ToString().Trim() + "|" + dv[m]["CountyName"].ToString().Trim();
                }
                catch
                {
                    //continue
                }
            }
            //str=str.Substring(1,str.Length-1);
            return str;
        }
        #endregion
        #endregion

        #region 验证帐号是否存在
        [AjaxPro.AjaxMethod]
        public bool ValiLoginName(string loginname)
        {
            Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
            DataTable dt = dal.GetList("LoginInfoTab","LoginName","''",1,1,1,1,"LoginName='"+loginname+"'");
            if (dt.Rows[0].ItemArray[0].ToString() == "0")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region 获取会员相关信息
        [AjaxPro.AjaxMethod]
        public string GetMemberMessage(string log, string nic)
        {
            string Criteria = "";
            if (log != "")
            {
                Criteria = "LoginName='" + log + "'";
            }
            if (nic != "")
            {
                Criteria = "NickName='" + nic + "'";
            }

            /*暂未做*/
            //Invest.Rule.MemberManageInfo BalanceView = new Invest.Rule.MemberManageInfo();
            //BalanceView.GetIntegralSum2(Criteria);
            //int IntegralSum = BalanceView.IntegralSum;

            //return IntegralSum + "积分";
            return "";
        }
        #endregion

        #region 
        [AjaxPro.AjaxMethod]
        public string GetMemberByLN(string log)
        {
            string name = "";
            Tz888.BLL.Register.MemberInfoBLL objLog = new Tz888.BLL.Register.MemberInfoBLL();
            
            name = objLog.getNickName(log);
            if (name == "" || name == null) return "不存在此会员，请先注册！"; 
            else return "会员存在";
         
        }
        #endregion

        #region
        [AjaxPro.AjaxMethod]
        public string GetMemberByNN(string nic)
        {
            string name = "";
            Tz888.BLL.Register.MemberInfoBLL objLog = new Tz888.BLL.Register.MemberInfoBLL();
            name = objLog.getLoginName(nic);
            if (name == "" || name==null) return "不存在此会员，请先注册！";
            else   return "会员存在";
        }
        #endregion

        #region 查询展厅域名是否己使用
        [AjaxPro.AjaxMethod]
        public string CheckDomain(string domain,string loginName)
        {
            Tz888.BLL.Register.common objDomain = new Tz888.BLL.Register.common();
            int result = objDomain.CheckDomain(domain, loginName);


            if (result > 0)
            {
                return "域名己使用";
            }
            else
            {
                return "域名可用";
            }

        }
        #endregion

        #region 查询展厅域名是否己使用
        [AjaxPro.AjaxMethod]
        public int CheckExhibitionHall(string domain, string loginName)
        {
            Tz888.BLL.Register.common objDomain = new Tz888.BLL.Register.common();
            int result = objDomain.CheckDomain(domain, loginName);
            if (result > 0)
            {
                return 0;//不可用
            }
            else
            {
                return 1;//可用
            }

        }
        #endregion

        #region 资源匹配条数统计
        [AjaxPro.AjaxMethod]
        public int GetMatchCount(long InfoID, string MatchType)
        {
            Tz888.BLL.Info.MatchInfoBLL bll = new Tz888.BLL.Info.MatchInfoBLL();
            return bll.GetCount(InfoID, MatchType, "");
        }
        #endregion

        #region 设置--取消购物券
        [AjaxPro.AjaxMethod]
        public string SetInfoCost(long InfoID,int flg)
        {
            Tz888.BLL.Info.MainInfoBLL dal = new Tz888.BLL.Info.MainInfoBLL();
            int result = dal.HasCost(InfoID, flg);
            return result.ToString();
        }
        #endregion

        #region 获取所有行业数据
        [AjaxPro.AjaxMethod]
        public string GetIndustryList()
        {
            Tz888.BLL.Common.IndustryBLL bll = new Tz888.BLL.Common.IndustryBLL();
            DataView dv = bll.dvGetAllIndustry();

            string str = "";
            if (dv == null)
                return str;
            for (int m = 0; m < dv.Table.Rows.Count; m++)
            {
                if(m == 0)
                    str = dv[m]["IndustryBID"].ToString().Trim() + "|" + dv[m]["IndustryBName"].ToString().Trim();
                else
                    str += "," + dv[m]["IndustryBID"].ToString().Trim() + "|" + dv[m]["IndustryBName"].ToString().Trim();
            }
            return str;
        }
        #endregion
    }
}
