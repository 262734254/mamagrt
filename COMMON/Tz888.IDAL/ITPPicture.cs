using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.IDAL
{
    public interface ITPPicture
    {
        /// <summary>
        ///  ����һ��ͼƬ��Ϣ
        /// </summary>
        bool InsertPicMess(Tz888.Model.TPPicture model);

        /// <summary>
        ///  ����һ��ͼƬ��Ϣ
        /// </summary>
        bool UpdatePicMess(Tz888.Model.TPPicture model);

        /// <summary>
        /// ɾ��ͼƬ��Ϣ
        /// </summary> 
        bool DeletePicMess(string idLST);

        /// <summary>
        /// ͼƬ��Ϣ
        /// </summary>
        /// <param name="SelectStr"></param>
        /// <param name="Criteria"></param>
        /// <param name="Sort"></param>
        /// <param name="Page"></param>
        /// <param name="CurrentPageRow"></param>
        /// <param name="TotalCount"></param>
        /// <returns></returns>
        DataSet dsGetPicMess(
                                string SelectStr,
                                 string Criteria,
                                 string Sort,
                                 long Page,
                                 long CurrentPageRow,
                                 ref long TotalCount

                                );
    }
}
