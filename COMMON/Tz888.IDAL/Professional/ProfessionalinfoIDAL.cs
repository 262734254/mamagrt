using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.Professional;
namespace Tz888.IDAL.Professional
{
    public interface ProfessionalinfoIDAL
    {
        /// <summary>
        /// רҵ��������
        /// ɾ����������ص�����
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DelInfoById(int id);
        /// <summary>
        /// רҵ����
        /// ɾ����������ص�����
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DelPleaseInfoById(int id);
        int UpdateAuditIdByID(int ProfessionalID);
        

        ProfessionalinfoTab GetModel(int ProfessionalID);
        
    }
}
