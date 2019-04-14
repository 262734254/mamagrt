using System;
using System.Collections.Generic;
using System.Text;
using System.Data; 
using Tz888.DALFactory;
using Tz888.Model;
using Tz888.IDAL;

namespace Tz888.BLL
{
    public class WebUnion_UserInfo
    {
        private readonly IWebUnion_UserInfo dal = DataAccess.CreateIWebUnion_UserInfo(); 
 
        /// <summary>
        /// 修改用户资料
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateWebUnion_UserInfo(Tz888.Model.WebUnion_UserInfo model)
        { 
            return dal.UpdateWebUnion_UserInfo(model);
        }
 

 

        /// <summary>
        /// 用户详细资料
        /// </summary>
        public Tz888.Model.WebUnion_UserInfo GetModel(string UserName)
        { 
            return dal.GetModel(UserName);
        }

        /// <summary>
        /// 联盟申请信息
        /// </summary>
        /// <param name="SelectStr"></param>
        /// <param name="Criteria"></param>
        /// <param name="Sort"></param>
        /// <param name="Page"></param>
        /// <param name="CurrentPageRow"></param>
        /// <param name="TotalCount"></param>
        /// <returns></returns>
        public DataSet dsGetNetUserTabList(
                                     string SelectStr,
                                     string Criteria,
                                     string Sort,
                                     long Page,
                                     long CurrentPageRow,
                                     out long TotalCount
                                    )
        { 
            return dal.dsGetNetUserTabList(SelectStr, Criteria, Sort, Page, CurrentPageRow, out TotalCount);
        }

                /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int UserID)
        {
            return dal.Delete(UserID);
        }
    }
}
