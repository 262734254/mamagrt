using System;
using System.Collections.Generic;
using System.Text;
using Tz888.IDAL.Professional;
using Tz888.Model.Professional;
using System.Data;
using Tz888.DALFactory;
namespace Tz888.BLL.Professional
{
    public class ProfessionalinfoBLL
    {
        ProfessionalinfoIDAL dal = DataAccess.CreateMainInfo();
        /// <summary>
        /// רҵ��������
        /// ɾ����������ص�����
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DelInfoById(int id)
        {
            return dal.DelInfoById(id);
        }
        public int UpdateAuditIdByID(int ProfessionalID)
        {
            return dal.UpdateAuditIdByID(ProfessionalID);
        }
        /// <summary>
        /// רҵ����
        /// ɾ����������ص�����
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DelPleaseInfoById(int id)
        {
            return dal.DelPleaseInfoById(id);
        }
        public ProfessionalinfoTab GetModel(int ProfessionalID)
        {
            return dal.GetModel(ProfessionalID);
        }
    }
}
