using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Tz888.DALFactory;
using Tz888.Model;
using Tz888.IDAL;

namespace Tz888.BLL
{
    public class ConsumeInfo
    {
        private readonly IConsumeInfos dal = DataAccess.CreateIConsumeInfos();
                /// <summary>
         /// �û�������Դ��Ϣ�б�
         /// </summary>
         /// <param name="SelectStr"></param>
         /// <param name="Criteria"></param>
         /// <param name="Sort"></param>
         /// <param name="Page"></param>
         /// <param name="CurrentPageRow"></param>
         /// <param name="TotalCount"></param>
         /// <param name="start"></param>
         /// <param name="end"></param>
         /// <returns></returns>
        public DataSet dsGetConsumeCountList(
                                string SelectStr,
                                string Criteria,
                                string Sort,
                                long Page,
                                long CurrentPageRow,
                                out long TotalCount,
                                string start,
                                string end
                               )
        { 
            return dal.dsGetConsumeCountList(SelectStr, Criteria, Sort, Page, CurrentPageRow, out TotalCount, start, end);
        }
                /// <summary>
        /// ��Դ��������������Ϣ 
        /// </summary>
        /// <returns></returns>
        public DataSet GetCountMess()
        { 
            return dal.GetCountMess();
        }

        public DataTable GetConsumeCount(string UserName)
        { 
            return dal.GetConsumeCount(UserName);
        }
        public DataTable GetAuditingStatusCount(string UserName)
        { 
            return dal.GetAuditingStatusCount(UserName);
        }


                /// <summary>
        /// ����һ������ �������� 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add(Tz888.Model.ConsumeInfos model)
        {
            return dal.Add(model);
        }


                /// <summary>
        /// ����
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="PassWord"></param>
        /// <returns></returns>
        public bool Update(Tz888.Model.ConsumeInfos model)
        {
            return dal.Update(model);
        }
    }
}
