using System;
using System.Collections.Generic;
using System.Text;
using Tz888.IDAL;
using System.Data.SqlClient;
using Tz888.Model;
using Tz888.DBUtility;
using System.Data;

namespace Tz888.SQLServerDAL
{
    public class loanscontactsTab : IloanscontactsTab
    {
        public Tz888.Model.LoanscontactsTab GetLoanscontactsTabByLoansInfoId(int LoansInfoId) 
        {
            string sql = "select * from loanscontactsTab where loansInfoID=@loansinfoid";
            DataSet set = DbHelperSQL.Query(sql, new SqlParameter("@LoansInfoId", LoansInfoId));
            LoanscontactsTab loansinfo = null;
            try
            {
               foreach(DataRow row in set.Tables [0].Rows)
                {
                    Tz888.SQLServerDAL.loansInfoTab loantabl = new loansInfoTab();
                    loansinfo = new LoanscontactsTab();
                    loansinfo.ContactsID = Convert.ToInt32(row["ContactsID"]);
                    loansinfo.LoansInfoID = loantabl.GetLoansInfoTabByLoansInfoId(Convert.ToInt32(row["LoansInfoID"]));
                    loansinfo.EnterpriseName =row["EnterpriseName"].ToString();
                    loansinfo.ContactsName = row["ContactsName"].ToString();
                    loansinfo.Telephone = row["Telephone"].ToString();
                    loansinfo.Moblie = row["Moblie"].ToString();
                    loansinfo.Mail = row["Mail"].ToString();
                    loansinfo.Address =row["Address"].ToString();
                    loansinfo.Loginname = row["Loginname"].ToString();
                }
               
            }
            catch (Exception)
            {

                throw;
            }
        
            return loansinfo;

        }
        public int UpdateloanscontactsTab(Tz888.Model.LoanscontactsTab loansinfo, int LoansInfoId)
        {
            string sql = "Update loanscontactsTab  set EnterpriseName=@EnterpriseName ,ContactsName=@ContactsName,Telephone=@Telephone,Moblie=@Moblie,Mail=@Mail,Address=@Address where loansInfoID=@loansInfoID ";
            SqlParameter[] ps = new SqlParameter[]{
                     new SqlParameter("@EnterpriseName",loansinfo.EnterpriseName)
                    ,new SqlParameter ("@ContactsName",loansinfo.ContactsName)
                    ,new SqlParameter ("@Telephone",loansinfo.Telephone)
                    ,new SqlParameter ("@Moblie",loansinfo.Moblie)
                    ,new SqlParameter ("@Mail",loansinfo.Mail)
                    ,new SqlParameter ("@Address",loansinfo.Address)
                    ,new SqlParameter ("@loansInfoID",LoansInfoId)};
            int result = DbHelperSQL.ExecuteSql(sql, ps);
            return result;
        }
        public int DeleteloanscontactsTab(int loansInfoID)
        {
            string sql = "delete loanscontactsTab where loansInfoID=@loansInfoID  ";
            int result = DbHelperSQL.ExecuteSql(sql, new SqlParameter("loansInfoID", loansInfoID));
            return result;
        }
    }
}