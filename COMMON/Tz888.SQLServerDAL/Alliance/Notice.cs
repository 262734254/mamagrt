using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Tz888.DBUtility;
using Tz888.IDAL;

namespace Tz888.SQLServerDAL
{
    public class Notice:INotice
    {
        /// <summary>
        ///  增加或更新资源联盟首页公告 
        /// </summary>
        public bool Add(Tz888.Model.Notice model)
        {
            SqlParameter[] parameters = {  
					new SqlParameter("@NoticeTitle", SqlDbType.VarChar,100),
					new SqlParameter("@NoticeContent", SqlDbType.Text), 
					new SqlParameter("@CreateDate", SqlDbType.DateTime,8),};

            parameters[0].Value = model.Title;
            parameters[1].Value = model.Details;
            parameters[2].Value = model.CreateDate;
            bool b = DbHelperSQL.RunProcLob("AllianceNoticeInfo", parameters);
            return b;
        }


        /// <summary>
        ///   公告
        /// </summary>
        /// <returns></returns>
        public DataSet GetNoticeMess()
        {
            string strsql = "select * from AllianceNoticeTab";
            return DBUtility.DbHelperSQL.Query(strsql);
        }
    }
}
