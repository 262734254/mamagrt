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

        #region ���İ�������ݰ�
        #region GetCountryList ����
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

        #region GetProvinceList ʡ��
        [AjaxPro.AjaxMethod]
        public string GetProvinceList(string CountryID)
        {
            Tz888.BLL.Common.ZoneSelectBLL bll = new Tz888.BLL.Common.ZoneSelectBLL();
            DataView dv = bll.GetProvinceList(CountryID);

            string str = "|ʡ��";
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

        #region GetCityList ����
        [AjaxPro.AjaxMethod]
        public string GetCityList(string ProvinceID)
        {
            Tz888.BLL.Common.ZoneSelectBLL bll = new Tz888.BLL.Common.ZoneSelectBLL();
            DataView dv = bll.GetCityList(ProvinceID);

            string str = "|�ؼ���";
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

        #region GetCountyList ��
        [AjaxPro.AjaxMethod]
        public string GetCountyList(string CityID)
        {
            Tz888.BLL.Common.ZoneSelectBLL bll = new Tz888.BLL.Common.ZoneSelectBLL();
            DataView dv = bll.GetCountyList(CityID);

            string str = "|�ؼ�����";
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

        #region ��֤�ʺ��Ƿ����
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

        #region ��ȡ��Ա�����Ϣ
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

            /*��δ��*/
            //Invest.Rule.MemberManageInfo BalanceView = new Invest.Rule.MemberManageInfo();
            //BalanceView.GetIntegralSum2(Criteria);
            //int IntegralSum = BalanceView.IntegralSum;

            //return IntegralSum + "����";
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
            if (name == "" || name == null) return "�����ڴ˻�Ա������ע�ᣡ"; 
            else return "��Ա����";
         
        }
        #endregion

        #region
        [AjaxPro.AjaxMethod]
        public string GetMemberByNN(string nic)
        {
            string name = "";
            Tz888.BLL.Register.MemberInfoBLL objLog = new Tz888.BLL.Register.MemberInfoBLL();
            name = objLog.getLoginName(nic);
            if (name == "" || name==null) return "�����ڴ˻�Ա������ע�ᣡ";
            else   return "��Ա����";
        }
        #endregion

        #region ��ѯչ�������Ƿ�ʹ��
        [AjaxPro.AjaxMethod]
        public string CheckDomain(string domain,string loginName)
        {
            Tz888.BLL.Register.common objDomain = new Tz888.BLL.Register.common();
            int result = objDomain.CheckDomain(domain, loginName);


            if (result > 0)
            {
                return "������ʹ��";
            }
            else
            {
                return "��������";
            }

        }
        #endregion

        #region ��ѯչ�������Ƿ�ʹ��
        [AjaxPro.AjaxMethod]
        public int CheckExhibitionHall(string domain, string loginName)
        {
            Tz888.BLL.Register.common objDomain = new Tz888.BLL.Register.common();
            int result = objDomain.CheckDomain(domain, loginName);
            if (result > 0)
            {
                return 0;//������
            }
            else
            {
                return 1;//����
            }

        }
        #endregion

        #region ��Դƥ������ͳ��
        [AjaxPro.AjaxMethod]
        public int GetMatchCount(long InfoID, string MatchType)
        {
            Tz888.BLL.Info.MatchInfoBLL bll = new Tz888.BLL.Info.MatchInfoBLL();
            return bll.GetCount(InfoID, MatchType, "");
        }
        #endregion

        #region ����--ȡ������ȯ
        [AjaxPro.AjaxMethod]
        public string SetInfoCost(long InfoID,int flg)
        {
            Tz888.BLL.Info.MainInfoBLL dal = new Tz888.BLL.Info.MainInfoBLL();
            int result = dal.HasCost(InfoID, flg);
            return result.ToString();
        }
        #endregion

        #region ��ȡ������ҵ����
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
