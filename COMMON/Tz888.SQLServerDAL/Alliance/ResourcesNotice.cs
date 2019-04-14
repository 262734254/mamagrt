using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient; 
using Tz888.DBUtility;
using Tz888.IDAL;

namespace Tz888.SQLServerDAL
{
    public class ResourcesNotice:IResourcesNotice
    {
        /// <summary>
        ///  增加一条数据
        /// </summary>
        public bool Add(Tz888.Model.ResourcesNotice model)
        {
 
            SqlParameter[] parameters = {
					new SqlParameter("@flag", SqlDbType.VarChar,30),
					new SqlParameter("@UserName", SqlDbType.VarChar,16),
					new SqlParameter("@NoticeTitle", SqlDbType.VarChar,50),
					new SqlParameter("@NoticeDetails", SqlDbType.Text),
					new SqlParameter("@CreateDate", SqlDbType.DateTime,8),  
                new SqlParameter("@ResPath", SqlDbType.VarChar,100),  
                new SqlParameter("@FileSize", SqlDbType.VarChar,50),  
                new SqlParameter("@AuditStatus", SqlDbType.Int,4),  
            };
            parameters[0].Value = "Insert";
            parameters[1].Value = model.UserName;
            parameters[2].Value = model.NoticeTitle;
            parameters[3].Value = model.NoticeDetails;
            parameters[4].Value = model.CreateDate;
            parameters[5].Value = model.ResPath;
            parameters[6].Value = model.FileSize;
            parameters[7].Value = model.AuditStatus; 

            bool b = DbHelperSQL.RunProcLob("ResourcesNoticeInfo", parameters);
            return b;
        }

        /// <summary>
        /// 更新公告
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="PassWord"></param>
        /// <returns></returns>
        public bool Update(Tz888.Model.ResourcesNotice model)
        {
            SqlParameter[] parameters = {
                                        new SqlParameter("@ResourcesNoticeID", SqlDbType.Int,4),
					                    new SqlParameter("@UserName", SqlDbType.VarChar,16),
					                    new SqlParameter("@NoticeTitle", SqlDbType.VarChar,50),
					                    new SqlParameter("@NoticeDetails", SqlDbType.Text),	
                                        new SqlParameter("@CreateDate", SqlDbType.DateTime,8),
                                        new SqlParameter("@ResPath", SqlDbType.VarChar,100),  
                                        new SqlParameter("@FileSize", SqlDbType.VarChar,50),  
                                        new SqlParameter("@AuditStatus", SqlDbType.Int,4),  
				                        new SqlParameter("@flag ",SqlDbType.VarChar,30)						
                                        };
            parameters[0].Value = model.ResourcesNoticeID;
            parameters[1].Value = model.UserName;
            parameters[2].Value = model.NoticeTitle;
            parameters[3].Value = model.NoticeDetails;
            parameters[4].Value = model.CreateDate;
            parameters[5].Value = model.ResPath;
            parameters[6].Value = model.FileSize;
            parameters[7].Value = model.AuditStatus; 
            parameters[8].Value = "Update";
            bool b = DbHelperSQL.RunProcLob("ResourcesNoticeInfo", parameters);
            return b;

        }

        /// <summary>
        /// 查询一条数据
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public DataSet Select(int ID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ResourcesNoticeID", SqlDbType.Int,4),
                     new SqlParameter("@flag", SqlDbType.VarChar,30),

				};
            parameters[0].Value = ID;
            parameters[1].Value = "Select";
            DataSet ds = DbHelperSQL.RunProcedure("ResourcesNoticeInfo", parameters, "ttt");
            return ds;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ResourcesNoticeID", SqlDbType.Int,4),
                     new SqlParameter("@flag", SqlDbType.VarChar,30),

				};
            parameters[0].Value = ID;
            parameters[1].Value = "Delete";
            bool b = DbHelperSQL.RunProcLob("ResourcesNoticeInfo", parameters);
            return b;
        }
    }
}
