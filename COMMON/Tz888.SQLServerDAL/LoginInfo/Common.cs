using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tz888.IDAL;
using Tz888.DBUtility;
using System.Security.Cryptography;


namespace Tz888.SQLServerDAL.LoginInfo
{
    public class Common
    {
        private Tz888.SQLServerDAL.Conn coon;                //���ݿ����Ӷ���
        public Common()
        {
            coon = new Conn();
        }
    }
}
