using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.IDAL
{
    public interface ITPPicture
    {
        /// <summary>
        ///  增加一条图片信息
        /// </summary>
        bool InsertPicMess(Tz888.Model.TPPicture model);

        /// <summary>
        ///  更新一条图片信息
        /// </summary>
        bool UpdatePicMess(Tz888.Model.TPPicture model);

        /// <summary>
        /// 删除图片信息
        /// </summary> 
        bool DeletePicMess(string idLST);

        /// <summary>
        /// 图片信息
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
