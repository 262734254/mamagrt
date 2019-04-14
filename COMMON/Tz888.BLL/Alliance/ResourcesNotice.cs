using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Tz888.DALFactory;
using Tz888.Model;
using Tz888.IDAL;

namespace Tz888.BLL
{
    public class ResourcesNotice
    {
        private readonly IResourcesNotice dal = DataAccess.CreateIResourcesNotice(); 
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Tz888.Model.ResourcesNotice model)
        { 
            return dal.Add(model);
        }

        /// <summary>
        /// 更新公告
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="PassWord"></param>
        /// <returns></returns>
        public bool Update(Tz888.Model.ResourcesNotice model)
        { 
            return dal.Update(model);
        }
                /// <summary>
        /// 查询一条数据
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public DataSet Select(int ID)
        { 
            return dal.Select(ID);
        }
                /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        { 
            return dal.Delete(ID);
        }
    }
}
