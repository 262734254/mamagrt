using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Tz888.DALFactory;
using Tz888.Model;
using Tz888.IDAL;


namespace Tz888.BLL
{
    public class TPVideo
    {
        private readonly ITPVideo dal = DataAccess.CreateITPVideo();

        /// <summary>
        /// ��ȡ��Ѷ��Ϣ
        /// </summary>
        /// <param name="SelectStr"></param>
        /// <param name="Criteria"></param>
        /// <param name="Sort"></param>
        /// <param name="Page"></param>
        /// <param name="CurrentPageRow"></param>
        /// <param name="TotalCount"></param>
        /// <returns></returns>
        public DataSet dsGetVideoMess(
                                     string SelectStr,
                                     string Criteria,
                                     string Sort,
                                     long Page,
                                     long CurrentPageRow,
                                     out long TotalCount
                                      )
        {
            long lgTotalCount = 0;

            DataSet ds;

            ds = dal.dsGetVideoMess(
                               SelectStr,
                               Criteria,
                               Sort,
                               Page,
                               CurrentPageRow,
                               ref lgTotalCount
                               );

            TotalCount = lgTotalCount;
            return (ds);
        }


        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="idLST">����б��ԡ��������������ԡ�������β</param>
        /// <returns></returns>
        #region------------ɾ��
        public bool DeleteVideoMess(string idLST)
        {
            if (idLST.EndsWith(","))
            {
                idLST = idLST.Substring(0, idLST.Length - 1);
            }
            return dal.DeleteVideoMess(idLST);
        }
        #endregion
                /// <summary>
        ///  �����Ƶ��Ϣ 
        /// </summary>
        public bool InsertVideoMess(Tz888.Model.TPVideo model)
        {
            return dal.InsertVideoMess(model);
        }

                /// <summary>
        ///  ������Ƶ��Ϣ 
        /// </summary>
        public bool UpdateVideoMess(Tz888.Model.TPVideo model)
        {
            return dal.UpdateVideoMess(model);
        }

        #region
        ///<summary>
        ///��ȡ���󣬻�ȡ��ַ
        ///design by ww
        ///2009-05-06
        ///</summary>
        public Tz888.Model.TPVideo GetVideoModelByID(long InfoID)
        {
            return dal.GetVideoModelByID(InfoID);
        }

        public string getAddrNameById(string ProvinceID, string CityID, string CountyID)
        {
            return dal.getAddrNameById(ProvinceID, CityID, CountyID);
        }

        public long InsertVideo(Tz888.Model.TPVideo model)
        {
            return dal.InsertVideo(model);
        }

        #endregion
    }
}
