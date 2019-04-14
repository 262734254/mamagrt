using System;
using System.Collections.Generic;
using System.Text;
using Tz888.IDAL;
using Tz888.DALFactory;
namespace Tz888.BLL
{
    public class CollectionBLL 
    {
        private readonly ICollection dal = DataAccess.CreateICollection();
        public bool Delete(string LoginName, long ID)
        {
            return dal.Delete(LoginName,ID);
        }
        public bool OrgDelete(string LoginName, long ID)
        {
            return dal.Delete(LoginName, ID);
        }

        #region   收藏信息插入
        public bool InfoFavorite(long InfoID, string LoginName)          
        {
            return dal.InfoFavoriteInsert(InfoID, LoginName);
        }
        #endregion

        #region  -- 公司机构收藏信息插入--------
        public bool InfoFavoriteOrgInsert(Tz888.Model.CollectionModel model)
        {
            return dal.InfoFavoriteOrgInsert(model);
        }
        #endregion
    }
}
