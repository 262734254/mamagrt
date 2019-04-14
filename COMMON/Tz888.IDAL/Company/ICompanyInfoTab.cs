using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.Company;
using System.Data;

namespace Tz888.IDAL.Company
{
    public interface ICompanyInfoTab
    {
        /// <summary>
        /// ��ҵ��Ƭ���
        /// </summary>
        /// <returns></returns>
        int Company_Add(CompanyModel model);
        /// <summary>
        /// ��ҵ��Ƭ�޸�
        /// </summary>
        /// <returns></returns>
        int Company_Update(CompanyModel model, int id);
        /// <summary>
        /// �ж��Ƿ񷢲�����ҵ��Ƭ
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        int IfCompany(string name);
        /// <summary>
        /// �����û����������״̬
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        int SelAdution(string name);
        /// <summary>
        /// �����û�����ѯ������Ӧ����Ϣ
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        CompanyModel SelCompany(string name);

        /// <summary>
        /// ��ȡʡ���б�
        /// </summary>
        /// <returns></returns>
        DataTable GetProvinceList();

        /// <summary>
        /// ��ȡ�����б�
        /// </summary>
        /// <param name="ProvinceID"></param>
        /// <returns></returns>
        DataTable GetCity(string ProvinceID);
    } 
}
