using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Tz888.DBUtility;

namespace Tz888.BLL.MeberLogin
{
    public class Promotion
    {
        /// <summary>
        /// 查询推广信息
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        public string SelTitleTime(string InfoID)
        {
            string num = "";
            string sql = "select Title,FrontDisplayTime,HtmlFile,RecordID from MainInfoTab where InfoID=@InfoID";
            SqlParameter[] para ={ 
               new SqlParameter("@InfoID",SqlDbType.VarChar,50)
            };
            para[0].Value = InfoID;
            DataSet ds = DbHelperSQL.Query(sql,para);
            string title = ds.Tables[0].Rows[0]["Title"].ToString().Trim();
            string time = ds.Tables[0].Rows[0]["FrontDisplayTime"].ToString().Trim();
            string HtmlFile = ds.Tables[0].Rows[0]["HtmlFile"].ToString().Trim();
            string RecordID = ds.Tables[0].Rows[0]["RecordID"].ToString().Trim();
            num = title + "|" + time+"|"+HtmlFile+"|"+RecordID;
            return num;
        }
        /// <summary>
        /// 修改推广状态
        /// </summary>
        /// <param name="InfoID"></param>
        /// <param name="time"></param>
        /// <param name="RecordID"></param>
        /// <returns></returns>
        public int UpdateRecord(string InfoID,string RecordID)
        {
            int num = 0;
            string sql = "update MainInfoTab set RecordID=@RecordID where InfoID=@InfoID";
            SqlParameter[] para ={ 
                new SqlParameter("@InfoID",SqlDbType.VarChar,50),
                new SqlParameter("@RecordID",SqlDbType.VarChar,10)
            };
            para[0].Value = InfoID;
            para[1].Value=RecordID;
            num = Convert.ToInt32(DbHelperSQL.GetSingle(sql, para));
            return num;
        }
        /// <summary>
        /// 修改推广时间
        /// </summary>
        /// <param name="InfoID"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public int UpdateTime(string InfoID, string time)
        {
            int num = 0;
            string sql = "update MainInfoTab set FrontDisplayTime=@time where InfoID=@InfoID";
            SqlParameter[] para ={ 
                 new SqlParameter("@InfoID",SqlDbType.VarChar,50),
                 new SqlParameter("@time",SqlDbType.VarChar,100)
            };
            para[0].Value = InfoID;
             para[1].Value = time;
            num = Convert.ToInt32(DbHelperSQL.GetSingle(sql, para));
            return num;
        }
    }
}
