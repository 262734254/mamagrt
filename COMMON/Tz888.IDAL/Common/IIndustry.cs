using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Tz888.Model.Common;

namespace Tz888.IDAL.Common
{
    /// <summary>
    /// ��ҵ������ݿ�����߼��ӿڶ���
    /// </summary>
    public interface IIndustry
    {
        /// <summary>
        /// ȡ����ҵ����������б�
        /// </summary>
        /// <returns>��ҵ�����б�</returns>
        List<IndustryModel> GetAllList();


        /// <summary>
        /// ������ҵ�����ȡ��ҵ����
        /// </summary>
        /// <param name="IndustryID">��ҵ����</param>
        /// <returns></returns>
        string GetNameByID(string IndustryID);

        /// <summary>
        /// �޸�ʱ������ҵ�����ȡ��ҵ����
        /// </summary>
        /// <param name="IndustryID">list</param>
        /// <returns></returns>
        List<IndustryModel> GetIndustryList(string IndustryList);


        /// <summary>
        /// ��ȡ������ҵ��Ϣ
        /// </summary>
        /// <returns></returns>
        DataView dvGetAllIndustry();
    }
}
