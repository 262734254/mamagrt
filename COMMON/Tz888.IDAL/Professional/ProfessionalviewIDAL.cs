using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Tz888.Model.Professional;
namespace Tz888.IDAL.Professional
{
    /// <summary>
    /// רҵ��������
    /// </summary>
   public interface ProfessionalviewIDAL
    {
       /// <summary>
       /// ����һ������
       /// </summary>
       /// <returns></returns>
       bool InsertProFessionlView(ProfessionalinfoTab mainInfo, Professionalview viewInfo, ProfessionalLink link);
       /// <summary>
       /// �޸�һ��רҵ��������
       /// </summary>
       /// <returns></returns>
       bool UpdateProFessionlView(ProfessionalinfoTab mainInfo, Professionalview viewInfo, ProfessionalLink link);
    }
}
