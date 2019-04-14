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
        /// 专业服务需求
        /// 删除跟主表相关的数据
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
        /// 专业机构
        /// 删除跟主表相关的数据
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
