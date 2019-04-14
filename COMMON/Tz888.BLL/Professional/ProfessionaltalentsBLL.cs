using System;
using System.Collections.Generic;
using System.Text;
using Tz888.IDAL.Professional;
using Tz888.Model.Professional;
using System.Data;
using Tz888.DALFactory;
namespace Tz888.BLL.Professional
{
    public class ProfessionaltalentsBLL
    {
        ProfessionaltalentsIDAL dal = DataAccess.CreatetalentsInfo();
        /// <summary>
        /// ����һ��רҵ��������
        /// </summary>
        /// <returns></returns>
        public bool InsertProFessionlView(ProfessionalinfoTab mainInfo, Professionaltalents viewInfo, ProfessionalLink link)
        {
            return dal.InsertProFessionlView(mainInfo, viewInfo, link);
        }

        /// <summary>
        /// �޸�һ��רҵ�˲�����
        /// </summary>
        /// <returns></returns>
        public bool UpdateProFessionlView(ProfessionalinfoTab mainInfo, Professionaltalents viewInfo, ProfessionalLink link)
        {
            return dal.UpdateProFessionlView(mainInfo, viewInfo, link);
        }
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Professionaltalents GetModel(int ProfessionalID)
        {
            return dal.GetModel(ProfessionalID);
        }
    }
}
