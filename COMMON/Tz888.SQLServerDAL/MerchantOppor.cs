using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model;
using Tz888.IDAL;
using Tz888.DBUtility;
using System.Data.SqlClient;
using System.Data;

namespace Tz888.SQLServerDAL
{
    public class MerchantOppor : IMerchantOppor
    {
        /// <summary>
        /// 设置为重大商机
        /// </summary>
        /// <returns></returns>
        public bool IsVip(long InfoID,int isVip,string VipAbout)
        {
            bool b = false;
            SqlParameter[] parameters = {
                    new SqlParameter("@flag", SqlDbType.VarChar,30),
					new SqlParameter("@InfoID", SqlDbType.BigInt),
                    new SqlParameter("@isVip", SqlDbType.Int),
                    new SqlParameter("@VipAbout", SqlDbType.VarChar,100),
                    
			};
            parameters[0].Value = "setisVip";
            parameters[1].Value = InfoID;
            parameters[2].Value = isVip;
            parameters[3].Value = VipAbout;
            try
            {
                b = DbHelperSQL.RunProcLob("MerchantOppor", parameters);
            }
            catch
            { }
            return b;
        }
        /// <summary>
        /// 设置置顶
        /// </summary>
        /// <param name="InfoID"></param>
        /// <param name="isTop">1置顶 0取消置顶</param>
        /// <returns></returns>
        public bool isTop(long InfoID, int isTop)
        {
            bool b = false;
            SqlParameter[] parameters = {
                    new SqlParameter("@flag", SqlDbType.VarChar,30),
					new SqlParameter("@InfoID", SqlDbType.BigInt),
                    new SqlParameter("@isTop", SqlDbType.Int),
                    
			};
            parameters[0].Value = "setisTop";
            parameters[1].Value = InfoID;
            parameters[2].Value = isTop;
            try
            {
                b = DbHelperSQL.RunProcLob("MerchantOppor", parameters);
            }
            catch
            { }
            return b;
        }
    }
}
