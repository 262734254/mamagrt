using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Tz888.Model.Professional;
namespace Tz888.IDAL.Professional
{
    /// <summary>
    /// 专业服务需求
    /// </summary>
   public interface ProfessionalviewIDAL
    {
       /// <summary>
       /// 插入一条数据
       /// </summary>
       /// <returns></returns>
       bool InsertProFessionlView(ProfessionalinfoTab mainInfo, Professionalview viewInfo, ProfessionalLink link);
       /// <summary>
       /// 修改一条专业服务数据
       /// </summary>
       /// <returns></returns>
       bool UpdateProFessionlView(ProfessionalinfoTab mainInfo, Professionalview viewInfo, ProfessionalLink link);
    }
}
