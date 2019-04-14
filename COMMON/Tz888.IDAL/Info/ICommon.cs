using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.Info;

namespace Tz888.IDAL.Info
{
    /// <summary>
    /// ��Ϣ�����������ӿ�
    /// </summary>
    public interface ICommon
    {
         /// <summary>
        /// ��ȡ������Ŀ��������
        /// </summary>
        /// <returns>���������б�</returns>
        List<CooperationDemandTypeModel> GetCooperationDemandList(string InfoType);


        /// <summary>
        /// ��ȡ������������
        /// </summary>
        /// <returns></returns>
        List<Tz888.Model.Info.MerchantAttributeModel> GetMerchantAttributeList();


        /// <summary>
        /// ��ȡ��Ϣ��������Ӧ�Ĵ���
        /// </summary>
        /// <param name="InfoTypeID">��Ϣ����</param>
        /// <returns></returns>
        string GetInfoTypeCode(string InfoTypeID);
    }
}
