using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.IDAL
{
   public interface ICollection
   {
       #region �ҵ��ղؼ�
       // ɾ����Ϣ�ղ� 
       bool Delete(string LoginName, long ID);

       // ɾ����˾�����ղ� 
       bool OrgDelete(string LoginName, long ID);

       //��Ϣ�ղ�
       bool InfoFavoriteInsert(long InfoID, string LoginName);

      // ��˾�����ղ���Ϣ
       bool InfoFavoriteOrgInsert(Tz888.Model.CollectionModel model);
       #endregion 

   }
}
