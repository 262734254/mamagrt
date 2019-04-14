using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tz888.IDAL;
using Tz888.DBUtility;

namespace Tz888.SQLServerDAL
{
    public class VoucherConvert : IVoucherConvert
    {
        public VoucherConvert()
        { }
        //×ª³É¹ºÎïÈ¯
        public int ConvertTicket( string LoginName,int IntegralCount,string CustomerLoginName)
        {
            SqlParameter[] parameters = {
											new SqlParameter("@LoginName", SqlDbType.Char, 16 ),
											new SqlParameter("@IntegralCount",SqlDbType.Int ),
											new SqlParameter("@CustomerLoginName",SqlDbType.Char,16),
											new SqlParameter("@status",SqlDbType.Int),
										};

            parameters[0].Value = LoginName;
            parameters[1].Value = IntegralCount;
            parameters[2].Value = CustomerLoginName;
            parameters[3].Direction = ParameterDirection.Output;

            int Ret = DbHelperSQL.RunProcReturn("VoucherConvert", parameters);
            return Ret;
        }
    }
}
