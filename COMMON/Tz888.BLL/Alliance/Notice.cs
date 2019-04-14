using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Tz888.DALFactory;
using Tz888.Model;
using Tz888.IDAL;

namespace Tz888.BLL
{
    public class Notice
    {
        private readonly INotice dal = DataAccess.CreateINotice(); 
        /// <summary>
        /// 添加/更新资源联盟首页公告
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add(Tz888.Model.Notice model)
        { 
            return dal.Add(model);
        }
        
        /// <summary>
        ///   公告
        /// </summary>
        /// <returns></returns>
        public DataSet GetNoticeMess()
        { 
            return dal.GetNoticeMess();
        }

    }
}
