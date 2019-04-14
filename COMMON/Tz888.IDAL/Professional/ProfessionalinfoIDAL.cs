using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.Professional;
namespace Tz888.IDAL.Professional
{
    public interface ProfessionalinfoIDAL
    {
        /// <summary>
        /// 专业服务需求
        /// 删除跟主表相关的数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DelInfoById(int id);
        /// <summary>
        /// 专业机构
        /// 删除跟主表相关的数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DelPleaseInfoById(int id);
        int UpdateAuditIdByID(int ProfessionalID);
        

        ProfessionalinfoTab GetModel(int ProfessionalID);
        
    }
}
