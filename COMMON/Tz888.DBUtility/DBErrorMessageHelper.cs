using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Tz888.DBUtility
{
    /// <summary>
    /// Ԥ�������ݿ������Ϣ������
    /// </summary>
    public class DBErrorMessageHelper
    {
        private static DataView dv = null;

        /// <summary>
        /// ȡ��Ӧ�Ĵ�������
        /// </summary>
        /// <param name="ErrorID"></param>
        /// <returns></returns>
        public static string GetErrorDesc(string ErrorID, string ErrorMsg)
        {
            string strRetrun = "";

            if (dv == null)
            {
                dv = GetDataView();
            }

            if (dv != null)
            {
                try
                {
                    dv.RowFilter = "ErrorID=" + ErrorID;
                    if (dv.Count == 1)
                    {
                        if (Convert.ToInt32(ErrorID) < 50000)
                        {
                            strRetrun = ErrorMsg;
                        }
                        else
                        {
                            strRetrun = dv[0]["ErrorMsg"].ToString().Trim();
                        }
                    }
                }
                catch
                {
                    strRetrun = "";
                }
            }
            return (strRetrun);
        }

        /// <summary>
        /// ȡ��Ӧ�ô���Ĵ��������б�
        /// </summary>
        /// <returns></returns>
        private static DataView GetDataView()
        {
            SqlConnection SqlCn = null;
            SqlDataAdapter da = null;
            DataView dvReturn = null;

            try
            {
                SqlCn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConnString1"].ConnectionString);
                SqlCn.Open();
                DataSet ds = new DataSet();
                da = new SqlDataAdapter("Select * from ErrorMsgTab", SqlCn);
                da.Fill(ds);

                dvReturn = ds.Tables[0].DefaultView;
            }
            catch
            {
            }
            finally
            {
                if (da != null)
                {
                    da.Dispose();
                }
                if (SqlCn != null && SqlCn.State != ConnectionState.Closed)
                {
                    SqlCn.Close();
                    SqlCn = null;
                }
            }
            return (dvReturn);
        }
    }
}
