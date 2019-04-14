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
        #region 添加举报信息
        /// <summary>
        /// 添加举报信息
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

        #region 处理举报信息
        public int addReplayInfo(long InfoID, string InfoTypeID, string ReplayContent, DateTime ReplayDate, string checkMan, string ID, string checkRemark)
        {
            int ReturnValue = 0;
            string SqlText = "update InfoReportTab set checkTime ='" + ReplayDate.ToString() + "',checkRemark='" + checkRemark + "',isCheck=1, checkMan='" + checkMan + "' where ID='" + ID + "'"; //处理举报信息

            using (SqlConnection sqlConn = DbHelperSQL.GetSqlConnection())
            {
                sqlConn.Open();
                SqlTransaction sqlTran = sqlConn.BeginTransaction();
                try
                {
                    int rowsAffected;
                    //处理举报信息
                    ReturnValue += DbHelperSQL.ExecuteSql(SqlText);
                  
                    //添加回复信息
                    SqlText = "insert into ReportReplayInfoTab(InfoID,InfoTypeID,ReplayContent,isSatisfied,ReplayDate,ReportID) values( '" + InfoID.ToString() + "', '" + InfoTypeID + "','" + ReplayContent + "','1','" + ReplayDate.ToString() + "','"+ID+"')"; //处理举报信息
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
