using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Tz888.DBUtility;
using Tz888.IDAL.Common;

namespace Tz888.SQLServerDAL.Common
{
    public class InquiryDAL : IInquiry
    {
        /// <summary>
        ///  增加一条数据
        /// </summary>
        public int Insert(Tz888.Model.Common.InquiryModel model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@InquiID", SqlDbType.Int,4),
					new SqlParameter("@Name", SqlDbType.VarChar,50),
					new SqlParameter("@Address", SqlDbType.VarChar,100),
					new SqlParameter("@Tel", SqlDbType.VarChar,100),
                    new SqlParameter("@Email",SqlDbType.VarChar,100),
					new SqlParameter("@MessageTitle", SqlDbType.VarChar,100),
					new SqlParameter("@MessageBody", SqlDbType.VarChar,-1),
					new SqlParameter("@PostDate", SqlDbType.SmallDateTime),
					new SqlParameter("@AuditStatus", SqlDbType.TinyInt,1)};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.Address;
            parameters[3].Value = model.Tel;
            parameters[4].Value = model.Email;
            parameters[5].Value = model.MessageTitle;
            parameters[6].Value = model.MessageBody;
            parameters[7].Value = model.PostDate;
            parameters[8].Value = model.AuditStatus;

            DbHelperSQL.RunProcedure("InquiTab_Insert", parameters, out rowsAffected);
            return (int)parameters[0].Value;
        }
    }
}
