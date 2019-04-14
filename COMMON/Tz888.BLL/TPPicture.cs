using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Tz888.DALFactory;
using Tz888.Model;
using Tz888.IDAL;

namespace Tz888.BLL
{
    public class TPPicture
    {
        private readonly ITPPicture dal = DataAccess.CreateITPPicture();

        /// <summary>
        /// ��ȡͼƬ��Ϣ
        /// </summary>
        /// <param name="SelectStr"></param>
        /// <param name="Criteria"></param>
        /// <param name="Sort"></param>
        /// <param name="Page"></param>
        /// <param name="CurrentPageRow"></param>
        /// <param name="TotalCount"></param>
        /// <returns></returns>
        public DataSet dsGetPicMess(
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

            ds = dal.dsGetPicMess(
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
        public bool DeletePicMess(string idLST)
        {
            if (idLST.EndsWith(","))
            {
                idLST = idLST.Substring(0, idLST.Length - 1);
            }
            return dal.DeletePicMess(idLST);
        }
        #endregion


                /// <summary>
        ///  �����Ƶ��Ϣ 
        /// </summary>
        public bool InsertPicMess(Tz888.Model.TPPicture model)
        {
            return dal.InsertPicMess(model);
        }

                /// <summary>
        ///  �����Ƶ��Ϣ 
        /// </summary>
        public bool UpdatePicMess(Tz888.Model.TPPicture model)
        {
            return dal.UpdatePicMess(model);
        }

 
    }
}
