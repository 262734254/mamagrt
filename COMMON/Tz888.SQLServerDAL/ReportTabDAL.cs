using System;
using System.Collections.Generic;
using System.Text;
using Tz888.IDAL;
using Tz888.DBUtility;
using System.Data;
using System.Data.SqlClient;

namespace Tz888.SQLServerDAL
{
    public class ReportTabDAL : IReportTab
    {
        #region ��Ӿٱ���Ϣ
        /// <summary>
        /// ��Ӿٱ���Ϣ
        /// </summary>
        /// <param name="InfoID"></param>
        /// <param name="Title"></param>
        /// <param name="content"></param>
        /// <param name="insertTime"></param>
        /// <returns></returns>
        public int addReportInfo(long InfoID, string Title, string content, string insertTime)
        {
            string SqlText = "insert into InfoReportTab(InfoID,ReportTime,ReportRemark,isCheck) values('" + InfoID + "','" + insertTime + "','" + content + "','0')";
            return DbHelperSQL.ExecuteSql(SqlText);
        }
        #endregion

        #region ����ٱ���Ϣ
        public int addReplayInfo(long InfoID, string InfoTypeID, string ReplayContent, DateTime ReplayDate, string checkMan, string ID, string checkRemark)
        {
            int ReturnValue = 0;
            string SqlText = "update InfoReportTab set checkTime ='" + ReplayDate.ToString() + "',checkRemark='" + checkRemark + "',isCheck=1, checkMan='" + checkMan + "' where ID='" + ID + "'"; //����ٱ���Ϣ

            using (SqlConnection sqlConn = DbHelperSQL.GetSqlConnection())
            {
                sqlConn.Open();
                SqlTransaction sqlTran = sqlConn.BeginTransaction();
                try
                {
                    int rowsAffected;
                    //����ٱ���Ϣ
                    ReturnValue += DbHelperSQL.ExecuteSql(SqlText);
                  
                    //��ӻظ���Ϣ
                    SqlText = "insert into ReportReplayInfoTab(InfoID,InfoTypeID,ReplayContent,isSatisfied,ReplayDate,ReportID) values( '" + InfoID.ToString() + "', '" + InfoTypeID + "','" + ReplayContent + "','1','" + ReplayDate.ToString() + "','"+ID+"')"; //����ٱ���Ϣ
                    ReturnValue += DbHelperSQL.ExecuteSql(SqlText);
                    sqlTran.Commit();
                    sqlConn.Close();
                    
                }
                catch
                {
                    sqlTran.Rollback();
                    ReturnValue = 0;
                }
                finally
                {
                    sqlConn.Close();
                }
            }
            return ReturnValue;
        }
        #endregion
    }
}
