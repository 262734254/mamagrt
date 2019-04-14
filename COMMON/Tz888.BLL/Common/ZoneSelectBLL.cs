using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.Common;
using Tz888.IDAL.Common;
using Tz888.DALFactory;
using System.Data;

namespace Tz888.BLL.Common
{
    public class ZoneSelectBLL
    {
        private readonly IZoneSelect dal = DataAccess.CreateZoneSelect();

        /// <summary>
        /// ��ȡ���еĹ�����Ϣ
        /// </summary>
        /// <returns>���й�����Ϣ�б�</returns>
        public DataView GetCountryList()
        {
            return dal.GetCountryList();
        }

        /// <summary>
        /// ��ȡָ�����ҵ�����ʡ����������Ϣ
        /// </summary>
        /// <param name="CountryID">���Ҵ���</param>
        /// <returns>����ʡ����������Ϣ</returns>
        public DataView GetProvinceList(string CountryID)
        {
            return dal.GetProvinceList(CountryID);
        }

        /// <summary>
        /// ��ȡָ��ʡ�������м���������Ϣ
        /// </summary>
        /// <param name="ProvinceID">ʡ������������</param>
        /// <returns>�м���������Ϣ</returns>
        public DataView GetCityList(string ProvinceID)
        {
            return dal.GetCityList(ProvinceID);
        }

        /// <summary>
        /// ��ȡָ���е������ص���Ϣ
        /// </summary>
        /// <param name="CityID">���д���</param>
        /// <returns>����Ϣ</returns>
        public DataView GetCountyList(string CityID)
        {
            return dal.GetCountyList(CityID);
        }

        /// <summary>
        /// ���ݹ��Ҵ����ȡ��������
        /// </summary>
        /// <param name="CountryID"></param>
        /// <returns></returns>
        public string GetCountryNameByCode(string CountryID)
        {
            return dal.GetCountryNameByCode(CountryID);
        }

        /// <summary>
        /// ����ʡ�����ȡʡ����
        /// </summary>
        /// <param name="ProvinceID"></param>
        /// <returns></returns>
        public string GetProvinceNameByCode(string ProvinceID)
        {
            return dal.GetProvinceNameByCode(ProvinceID);
        }

        /// <summary>
        /// ���ݳ��д����ȡ��������
        /// </summary>
        /// <param name="CityID"></param>
        /// <returns></returns>
        public string GetCityNameByCode(string CityID)
        {
            return dal.GetCityNameByCode(CityID);
        }

        /// <summary>
        /// �����ش����ȡ������
        /// </summary>
        /// <param name="CountyID"></param>
        /// <returns></returns>
        public string GetCountyNameByCode(string CountyID)
        {
            return dal.GetCountyNameByCode(CountyID);
        }
    }
}
