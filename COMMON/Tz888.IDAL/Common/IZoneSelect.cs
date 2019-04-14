using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.IDAL.Common
{
    /// <summary>
    /// ���ҵ�����Ϣ���ݿ�����߼���ӿڶ���
    /// </summary>
    public interface IZoneSelect
    {
        /// <summary>
        /// ��ȡ���еĹ�����Ϣ
        /// </summary>
        /// <returns>���й�����Ϣ�б�</returns>
        DataView GetCountryList();

        /// <summary>
        /// ��ȡָ�����ҵ�����ʡ����������Ϣ
        /// </summary>
        /// <param name="CountryID">���Ҵ���</param>
        /// <returns>����ʡ����������Ϣ</returns>
        DataView GetProvinceList(string CountryID);

        /// <summary>
        /// ��ȡָ��ʡ�������м���������Ϣ
        /// </summary>
        /// <param name="ProvinceID">ʡ������������</param>
        /// <returns>�м���������Ϣ</returns>
        DataView GetCityList(string ProvinceID);

        /// <summary>
        /// ��ȡָ���е������ص���Ϣ
        /// </summary>
        /// <param name="CityID">���д���</param>
        /// <returns>����Ϣ</returns>
        DataView GetCountyList(string CityID);

        /// <summary>
        /// ���ݹ��Ҵ����ȡ��������
        /// </summary>
        /// <param name="CountryID"></param>
        /// <returns></returns>
        string GetCountryNameByCode(string CountryID);

        /// <summary>
        /// ����ʡ�����ȡʡ����
        /// </summary>
        /// <param name="ProvinceID"></param>
        /// <returns></returns>
        string GetProvinceNameByCode(string ProvinceID);

        /// <summary>
        /// ���ݳ��д����ȡ��������
        /// </summary>
        /// <param name="CityID"></param>
        /// <returns></returns>
        string GetCityNameByCode(string CityID);

        /// <summary>
        /// �����ش����ȡ������
        /// </summary>
        /// <param name="CountyID"></param>
        /// <returns></returns>
        string GetCountyNameByCode(string CountyID);
    }
}
