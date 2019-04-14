using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.IDAL
{ 
    public interface ITPVideo
    {
        /// <summary>
        ///  ����һ����Ƶ��Ϣ
        /// </summary>
        bool InsertVideoMess(Tz888.Model.TPVideo model);
 
        /// <summary>
        ///  ����һ����Ƶ��Ϣ
        /// </summary>
        bool UpdateVideoMess(Tz888.Model.TPVideo model);

        /// <summary>
        /// ɾ����Ƶ��Ϣ
        /// </summary> 
        bool DeleteVideoMess(string idLST);

        /// <summary>
        /// ��Ƶ��Ϣ
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
        ///��ȡ���󣬻�ȡ��ַ
        ///design by ww
        ///2009-05-06
        ///</summary>
        Tz888.Model.TPVideo GetVideoModelByID(long InfoID);

        string getAddrNameById(string ProvinceID, string CityID, string CountyID);
        
        long InsertVideo(Tz888.Model.TPVideo model);

        #endregion
    }
}
