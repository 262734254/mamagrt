using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Tz888.DBUtility;
namespace Tz888.SQLServerDAL.Order
{
  public  class BusStrikeRecDAL
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
      public int Add(Tz888.Model.Orders.BusStrikeRecTab model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BusStrikeRecTab(");
            strSql.Append("LoginName,CardNo,PointCount,Remark,ChangeBy,ChangeTime,ForeignTradeNo,Email,Tel,Mobile,StrikeType,Free,CardNumber)");
            strSql.Append(" values (");
            strSql.Append("@LoginName,@CardNo,@PointCount,@Remark,@ChangeBy,@ChangeTime,@ForeignTradeNo,@Email,@Tel,@Mobile,@StrikeType,@Free,@CardNumber)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@LoginName", SqlDbType.Char,16),
					new SqlParameter("@CardNo", SqlDbType.BigInt,8),
					new SqlParameter("@PointCount", SqlDbType.Float,8),
					new SqlParameter("@Remark", SqlDbType.VarChar,50),
					new SqlParameter("@ChangeBy", SqlDbType.Char,16),
					new SqlParameter("@ChangeTime", SqlDbType.SmallDateTime),
					new SqlParameter("@ForeignTradeNo", SqlDbType.VarChar,60),
					new SqlParameter("@Email", SqlDbType.VarChar,50),
					new SqlParameter("@Tel", SqlDbType.VarChar,50),
					new SqlParameter("@Mobile", SqlDbType.VarChar,20),
					new SqlParameter("@StrikeType", SqlDbType.Char,10),
            	new SqlParameter("@Free", SqlDbType.BigInt,8),
                new SqlParameter("@CardNumber",SqlDbType.VarChar,20)};
            parameters[0].Value = model.LoginName;
            parameters[1].Value = model.CardNo;
            parameters[2].Value = model.PointCount;
            parameters[3].Value = model.Remark;
            parameters[4].Value = model.ChangeBy;
            parameters[5].Value = model.ChangeTime;
            parameters[6].Value = model.ForeignTradeNo;
            parameters[7].Value = model.Email;
            parameters[8].Value = model.Tel;
            parameters[9].Value = model.Mobile;
            parameters[10].Value = model.StrikeType;
            parameters[11].Value = model.Free;
            parameters[12].Value = model.CardNumber;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
    }
}
