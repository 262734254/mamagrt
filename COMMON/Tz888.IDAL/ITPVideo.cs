using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.IDAL
{ 
    public interface ITPVideo
    {
        /// <summary>
        ///  增加一条视频信息
        /// </summary>
        bool InsertVideoMess(Tz888.Model.TPVideo model);
 
        /// <summary>
        ///  更新一条视频信息
        /// </summary>
        bool UpdateVideoMess(Tz888.Model.TPVideo model);

        /// <summary>
        /// 删除视频信息
        /// </summary> 
        bool DeleteVideoMess(string idLST);

        /// <summary>
        /// 视频信息
        /// </summary>
        /// <param name="SelectStr"></param>
        /// <param name="Criteria"></param>
        /// <param name="Sort"></param>
        /// <param name="Page"></param>
        /// <param name="CurrentPageRow"></param>
        /// <param name="TotalCount"></param>
        /// <returns></returns>
        DataSet dsGetVideoMess(
                                string SelectStr,
                                 string Criteria,
                                 string Sort,
                                 long Page,
                                 long CurrentPageRow,
                                 ref long TotalCount

                                );


        #region
        ///<summary>
        ///获取对象，获取地址
        ///design by ww
        ///2009-05-06
        ///</summary>
        Tz888.Model.TPVideo GetVideoModelByID(long InfoID);

        string getAddrNameById(string ProvinceID, string CityID, string CountyID);
        
        long InsertVideo(Tz888.Model.TPVideo model);

        #endregion
    }
}
