using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Tz888.IDAL;
using Tz888.DBUtility;
using System.Security.Cryptography;
namespace Tz888.SQLServerDAL
{
    public class Card:ICard
    {
        public int Insert(Tz888.Model.Card model)
        {
            SHA1 sha1 = SHA1.Create();
            byte[] bytePassword = sha1.ComputeHash(Encoding.Unicode.GetBytes(model.Password));
            SqlParameter[] parameters = {
					new SqlParameter("@CardNo", SqlDbType.BigInt,8),
					new SqlParameter("@Password", SqlDbType.VarBinary,50),
					new SqlParameter("@PointCount", SqlDbType.Float,8),
					new SqlParameter("@IsPublish", SqlDbType.TinyInt,1),
					new SqlParameter("@IsGift", SqlDbType.TinyInt,1),
					new SqlParameter("@IsVirtual", SqlDbType.TinyInt,1),
					new SqlParameter("@ChangeBy", SqlDbType.Char,16),
                    new SqlParameter("@returnValue", SqlDbType.Int)
            };
            parameters[0].Value = model.CardNo;
            parameters[1].Value = bytePassword;
            parameters[2].Value = model.PointCount;
            parameters[3].Value = model.IsPublish;
            parameters[4].Value = model.IsGift;
            parameters[5].Value = model.IsVirtual;
            parameters[6].Value = model.ChangeBy;
            parameters[7].Direction = ParameterDirection.Output;

           int rowsAffected=DbHelperSQL.RunProcReturn("StrikeCardTab_Insert", parameters);
           return rowsAffected;
        }

        public int Update(Tz888.Model.Card model)
        {
            int rowsAffected;
            SHA1 sha1 = SHA1.Create();
            byte[] bytePassword = sha1.ComputeHash(Encoding.Unicode.GetBytes(model.Password));
            SqlParameter[] parameters = {
					new SqlParameter("@CardNo", SqlDbType.BigInt,8),
					new SqlParameter("@Password", SqlDbType.VarBinary,50),
					new SqlParameter("@PointCount", SqlDbType.Float,8),
					new SqlParameter("@IsPublish", SqlDbType.TinyInt,1),
					new SqlParameter("@IsGift", SqlDbType.TinyInt,1),
					new SqlParameter("@ChangeBy", SqlDbType.Char,16),
            };
            parameters[0].Value = model.CardNo;
            parameters[1].Value = bytePassword;
            parameters[2].Value = model.PointCount;
            parameters[3].Value = model.IsPublish;
            parameters[4].Value = model.IsGift;
            parameters[5].Value = model.ChangeBy;

            rowsAffected = DbHelperSQL.RunProcReturn("StrikeCardTab_Update", parameters);
            return rowsAffected;
        }
        public bool Delete(long CardNo)
        {
            
            SqlParameter[] parameters = {
					new SqlParameter("@CardNo", SqlDbType.BigInt,8),
            };
            parameters[0].Value =CardNo;

            bool  b = DbHelperSQL.RunProcLob("StrikeCardTab_Delete", parameters);
            return b;
        }
    }
}
