using System;

using System.Text;
using Tz888.IDAL;
using System.Data;
using Tz888.DBUtility;
using System.Data.SqlClient;
using Tz888.Model;
using System.Collections.Generic;

namespace Tz888.SQLServerDAL
{
    class loansInfoTab : IloansInfoTab
    {
        //添加贷款记录
        public int InsertLoansInfoTab(Tz888 .Model .LoansInfoTab loansinfotab,Tz888 .Model .LoansInfo loansinfo,Tz888 .Model .LoanscontactsTab loanscontactstab)
        {
            int rowsAffected=0;
            SqlParameter[] parameters = {
					new SqlParameter("@LoginName", SqlDbType.VarChar,50),
					new SqlParameter("@LoansTitle", SqlDbType.VarChar,100),
					new SqlParameter("@BorrowingType", SqlDbType.Int,4),
					new SqlParameter("@auditID", SqlDbType.Int,4),
					new SqlParameter("@chargeID", SqlDbType.Int,4),
					new SqlParameter("@recommendID", SqlDbType.Int,4),
					new SqlParameter("@url", SqlDbType.VarChar,200),
					new SqlParameter("@loansdate", SqlDbType.DateTime),
                    new SqlParameter("@formID", SqlDbType.Int ,4),
                    new SqlParameter("@price", SqlDbType.Int,4),
                    new SqlParameter("@refurbishtime", SqlDbType.DateTime),
					new SqlParameter("@enterpriseName", SqlDbType.VarChar,100),
					new SqlParameter("@contactsName", SqlDbType.VarChar,100),
					new SqlParameter("@telephone", SqlDbType.VarChar,50),
					new SqlParameter("@Moblie", SqlDbType.VarChar,50),
					new SqlParameter("@Mail", SqlDbType.VarChar,50),
					new SqlParameter("@Address", SqlDbType.VarChar,50),
					new SqlParameter("@ValidityID", SqlDbType.Int,4),
					new SqlParameter("@CountryID", SqlDbType.NChar,30),
					new SqlParameter("@ProvinceID", SqlDbType.NChar,30),
					new SqlParameter("@CityID", SqlDbType.NChar,30),
					new SqlParameter("@CountyID", SqlDbType.NChar,30),
					new SqlParameter("@amount", SqlDbType.Int,4),
					new SqlParameter("@deadline", SqlDbType.Int,4),
					new SqlParameter("@reimbursement", SqlDbType.Int,4),
					new SqlParameter("@guarantee", SqlDbType.Int,4),
					new SqlParameter("@Borrowinguse", SqlDbType.VarChar,2000),
					new SqlParameter("@title", SqlDbType.VarChar,100),
                    new SqlParameter("@keywords", SqlDbType.VarChar,100),
                    new SqlParameter("@description", SqlDbType.VarChar,100),
                    new SqlParameter("@reason", SqlDbType.VarChar,100)
            };
            parameters[0].Value = loansinfotab.LoginName;
            parameters[1].Value = loansinfotab.LoansTitle;
            parameters[2].Value = loansinfotab.BorrowingType;
            parameters[3].Value = loansinfotab.AuditID ;
            parameters[4].Value = loansinfotab.ChargeID;
            parameters[5].Value = loansinfotab.RecommendID;
            parameters[6].Value = loansinfotab.Url;
            parameters[7].Value = loansinfotab.Loansdate;
            parameters[8].Value = loansinfotab.Formid;
            parameters[9].Value = loansinfotab.Price;
            parameters[10].Value = loansinfotab.Refurbishtime;
            parameters[11].Value = loanscontactstab.EnterpriseName;
            parameters[12].Value = loanscontactstab.ContactsName;
            parameters[13].Value = loanscontactstab.Telephone ;
            parameters[14].Value = loanscontactstab.Moblie;
            parameters[15].Value = loanscontactstab.Mail;
            parameters[16].Value = loanscontactstab.Address;
            parameters[17].Value = loansinfo.ValidityID ;
            parameters[18].Value = loansinfo.CountryID;
            parameters[19].Value = loansinfo.ProvinceID ;
            parameters[20].Value = loansinfo.CityID ;
            parameters[21].Value = loansinfo.CountyID;
            parameters[22].Value = loansinfo.Amount;
            parameters[23].Value = loansinfo.Deadline ;
            parameters[24].Value = loansinfo.Reimbursement;
            parameters[25].Value = loansinfo.Guarantee;
            parameters[26].Value = loansinfo.BorrowingUse ;
            parameters[27].Value = loansinfo.Title ;
            parameters[28].Value = loansinfo.Keywords;
            parameters[29].Value = loansinfo.Description;
            parameters[30].Value = loansinfo.Reason;


            DbHelperSQL.RunProcedure("loansinfotab_insert", parameters, out rowsAffected);
            return rowsAffected;
            
        }

        //审核用
        public List<Tz888.Model.LoansInfoTab> GetAllInfoTab()
        {
            string sql = "select * from loansInfoTab";
            List<Tz888.Model.LoansInfoTab> list = new List<LoansInfoTab>();
            DataSet set = null;
            set = DbHelperSQL.Querys(sql);
            foreach (DataRow row in set.Tables[0].Rows)
            {
                LoansInfoTab loansinfo = new LoansInfoTab();
                loansinfo.LoansInfoID = Convert.ToInt32(row["loansInfoID"]);
                loansinfo.LoginName = row["LoginName"].ToString();
                loansinfo.LoansTitle = row["LoansTitle"].ToString();
                loansinfo.BorrowingType = Convert.ToInt32(row["BorrowingType"]);
                loansinfo.AuditID = Convert.ToInt32(row["auditID"]);
                loansinfo.ChargeID = Convert.ToInt32(row["chargeID"]);
                loansinfo.RecommendID = Convert.ToInt32(row["recommendID"]);
                loansinfo.Url = row["URL"].ToString();
                loansinfo.Loansdate = row["loansdate"].ToString();
                list.Add(loansinfo);
            }
            return list;
        }
        public Tz888.Model.LoansInfoTab GetLoansInfoTabByLoansInfoId(int LoansInfoId)
        {
            string sql = "select * from loansInfoTab where loansInfoID=@loansinfoid";
            SqlDataReader reader = DbHelperSQL.ExecuteReader(sql, new SqlParameter("loansinfoid", LoansInfoId));
            LoansInfoTab loansinfo = null;
            try
            {
                if (reader.Read())
                {
                    loansinfo = new LoansInfoTab();
                    loansinfo.LoansInfoID = Convert.ToInt32(reader["loansInfoID"]);
                    loansinfo.LoginName = reader["LoginName"].ToString();
                    loansinfo.LoansTitle = reader["LoansTitle"].ToString();
                    loansinfo.BorrowingType = Convert.ToInt32(reader["BorrowingType"]);
                    loansinfo.AuditID = Convert.ToInt32(reader["auditID"]);
                    loansinfo.ChargeID = Convert.ToInt32(reader["chargeID"]);
                    loansinfo.RecommendID = Convert.ToInt32(reader["recommendID"]);
                    loansinfo.Url = reader["URL"].ToString();
                    loansinfo.Loansdate = reader["loansdate"].ToString();
                }
                reader.Close();
            }
            catch (Exception)
            {

                throw;
            }
            finally { reader.Close(); }
            return loansinfo;

        }
        public int UpdateLoansInfoTabauditID(int id) 
        {
            string sql = "Update loansinfotab set auditID=5 where loansInfoID=@loansInfoID ";
            SqlParameter[] ps = new SqlParameter[]{
                    new SqlParameter ("@loansInfoID",id)};
            int result = DbHelperSQL.ExecuteSql(sql, ps);
            return result;
        }
        public int UpdateLoansInfoTab(Tz888.Model.LoansInfoTab loansinfotab)
        {
            string sql = "Update loansinfotab set LoansTitle=@LoansTitle ,Updatetime=@Updatetime where loansInfoID=@loansInfoID ";
            SqlParameter[] ps = new SqlParameter[]{
                     new SqlParameter("@LoansTitle",loansinfotab.LoansTitle)
                    ,new SqlParameter("@Updatetime",loansinfotab.Updatetime )
                    ,new SqlParameter ("@loansInfoID",loansinfotab.LoansInfoID)};
            int result = DbHelperSQL.ExecuteSql(sql, ps);
            return result;
        }
        public int ShenHeLoansInfoTab(Tz888.Model.LoansInfoTab loansinfotab)
        {
            string sql = "Update loansinfotab set LoansTitle=@LoansTitle ,Updatetime=@Updatetime,AuditID=@AuditID,RecommendID=@RecommendID where loansInfoID=@loansInfoID ";
            SqlParameter[] ps = new SqlParameter[]{
                     new SqlParameter("@LoansTitle",loansinfotab.LoansTitle)
                    ,new SqlParameter("@Updatetime",loansinfotab.Updatetime )
                    ,new SqlParameter("@AuditID",loansinfotab.AuditID)
                    ,new SqlParameter("@RecommendID",loansinfotab.RecommendID )
                    ,new SqlParameter ("@loansInfoID",loansinfotab.LoansInfoID)};
            int result = DbHelperSQL.ExecuteSql(sql, ps);
            return result;
        }
        public int DeleteLoansInfoTab(int loansInfoID)
        {
            string sql = "delete loansinfotab where loansInfoID=@loansInfoID  ";
            int result = DbHelperSQL.ExecuteSql(sql, new SqlParameter("loansInfoID", loansInfoID));
            return result;
        }
                    

    }


}
