using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.TFZS;
using Tz888.IDAL.TFZS;
using Tz888.DBUtility;
using System.Data.SqlClient;
using System.Data;

namespace Tz888.SQLServerDAL.TFZS
{
    /// <summary>
    /// ����Ŀ�����ݿ�����߼���
    /// </summary>
    public class MeasureStandardDAL : IMeasureStandard
    {
        /// <summary>
        /// ���ݱ���ָ������ȡ����Ŀ����Ϣ�б�
        /// </summary>
        /// <param name="expressCode">����ָ�����</param>
        /// <returns>����Ŀ����Ϣ�б�</returns>
        public List<TFZS_MeasureStandard> GetListByExpressCode(string expressCode)
        {
            List<TFZS_MeasureStandard> lists = new List<TFZS_MeasureStandard>();
            SqlParameter parm = new SqlParameter("@ExpressCode", SqlDbType.Char, 30);
            parm.Value = expressCode;

            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "TFZS_MeasureStandard_GetListByExpressCode", parm))
            {
                while (rdr.Read())
                {
                    TFZS_MeasureStandard item = new TFZS_MeasureStandard();
                    item.ExpressCode = rdr["ExpressCode"].ToString();
                    item.ExpressRemark = rdr["ExpressRemark"].ToString();
                    item.MeasureCode = rdr["MeasureCode"].ToString();
                    item.MeasureName = rdr["MeasureName"].ToString();
                    item.MeasurePoint = Convert.ToDecimal(rdr["MeasurePoint"]);
                    lists.Add(item);
                }
            }
            return lists;
        }
    }
}
