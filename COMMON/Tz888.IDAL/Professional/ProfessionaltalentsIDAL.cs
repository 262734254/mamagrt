using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.Professional;
namespace Tz888.IDAL.Professional
{
    public interface ProfessionaltalentsIDAL
    {
        /// <summary>
        /// ����һ��רҵ��������
        /// </summary>
        /// <returns></returns>
        bool InsertProFessionlView(ProfessionalinfoTab mainInfo, Professionaltalents viewInfo, ProfessionalLink link);
        /// <summary>
        /// �޸�һ��רҵ�˲�����
        /// </summary>
        /// <returns></returns>

        bool UpdateProFessionlView(ProfessionalinfoTab mainInfo, Professionaltalents viewInfo, ProfessionalLink link);
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        Professionaltalents GetModel(int ProfessionalID);
    }
}
