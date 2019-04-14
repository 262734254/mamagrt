using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.IDAL
{
   public interface ICollection
   {
       #region 我的收藏夹
       // 删除信息收藏 
       bool Delete(string LoginName, long ID);

       // 删除公司机构收藏 
       bool OrgDelete(string LoginName, long ID);

       //信息收藏
       bool InfoFavoriteInsert(long InfoID, string LoginName);

      // 公司机构收藏信息
       bool InfoFavoriteOrgInsert(Tz888.Model.CollectionModel model);
       #endregion 

   }
}
