using System;
using System.Collections.Generic;
using System.Text;
using Tz888.IDAL;
using System.Data.SqlClient;
using Tz888.DBUtility;
using Tz888.Model;
using System.Data;

namespace Tz888.SQLServerDAL
{
    class loansInfo:IloansInfo
    {
        public Tz888.Model.LoansInfo GetLoansInfoByLoansInfoId(int LoansInfoId)
        {
            string sql = "select * from loansInfo where loansInfoID=" + LoansInfoId;
            DataSet set = DbHelperSQL.Query(sql);
            LoansInfo loansinfo = null;
            try
            {
                foreach(DataRow row in set.Tables [0].Rows)
                {
                    Tz888.SQLServerDAL.loansInfoTab loantabl=new loansInfoTab ();
                    loansinfo = new LoansInfo();
                    loansinfo.LoanID = Convert.ToInt32(row["LoanID"]);
                    loansinfo.LoansInfoID = loantabl.GetLoansInfoTabByLoansInfoId(Convert.ToInt32(row["LoansInfoID"]));
                    loansinfo.ValidityID = Convert.ToInt32 (row["ValidityID"].ToString());
                    loansinfo.CountryID = row["CountryID"].ToString();
                    loansinfo.ProvinceID = row["ProvinceID"].ToString();
                    loansinfo.CityID = row["CityID"].ToString();
                    loansinfo.CountyID = row["CountyID"].ToString();
                    loansinfo.Amount = Convert.ToInt32(row["Amount"]);
                    loansinfo.Deadline = Convert.ToInt32(row["Deadline"]);
                    loansinfo.Reimbursement = Convert.ToInt32(row["Reimbursement"]);
                    loansinfo.Guarantee = Convert.ToInt32(row["Guarantee"]);
                    loansinfo.BorrowingUse = row["BorrowingUse"].ToString();
                    loansinfo.Title = row["Title"].ToString();
                    loansinfo.Keywords = row["Keywords"].ToString();
                    loansinfo.Description = row["Description"].ToString();
                    loansinfo.Reason = row["Reason"].ToString();
                }
                
            }
            catch (Exception)
            {

         
            }
            
            return loansinfo;

        }
        public int UpdateloansInfo(Tz888.Model.LoansInfo loansinfo, int LoansInfoId)
        {
            string sql = "Update loansInfo set CountryID=@CountryID ,ProvinceID=@ProvinceID,CityID=@CityID,CountyID=@CountyID,Amount=@Amount,Deadline=@Deadline,Reimbursement=@Reimbursement,Guarantee=@Guarantee,BorrowingUse=@BorrowingUse,ValidityID=@ValidityID where loansInfoID=@loansInfoID ";
            SqlParameter[] ps = new SqlParameter[]{
                     new SqlParameter("@CountryID",loansinfo.CountryID)
                    ,new SqlParameter ("@ProvinceID",loansinfo.ProvinceID)
                    ,new SqlParameter ("@CityID",loansinfo.CityID)
                    ,new SqlParameter ("@CountyID",loansinfo.CountyID)
                    ,new SqlParameter ("@Amount",loansinfo.Amount)
                    ,new SqlParameter ("@Deadline",loansinfo.Deadline)
                    ,new SqlParameter ("@Reimbursement",loansinfo.Reimbursement)              
                    ,new SqlParameter ("@Guarantee",loansinfo.Guarantee)
                    ,new SqlParameter ("@BorrowingUse",loansinfo.BorrowingUse )
                    ,new SqlParameter ("@ValidityID",loansinfo.ValidityID)
                    ,new SqlParameter ("@loansInfoID",LoansInfoId)

                    
            };
            int result = DbHelperSQL.ExecuteSql(sql, ps);
            return result;
        }
        public string GetProvinceNameByProvinceId(string ProvinceId)
        {
            string sql = "select * from SetProvinceTab where ProvinceID=@provinceid";
            SqlDataReader reader = DbHelperSQL.ExecuteReader(sql, new SqlParameter("provinceid", ProvinceId));
            string name="";
            try
            {
                if (reader.Read())
                {
                    name = reader["ProvinceName"].ToString().Trim();
                    
                }
                reader.Close();
            }
            catch (Exception)
            {

                throw;
            }
            finally { reader.Close(); }
            return name;
        }
        public int ShenHeloansInfo(Tz888.Model.LoansInfo loansinfo, int LoansInfoId)
        {
            string sql = "Update loansInfo set CountryID=@CountryID ,ProvinceID=@ProvinceID,CityID=@CityID,CountyID=@CountyID,Amount=@Amount,Deadline=@Deadline,Reimbursement=@Reimbursement,Guarantee=@Guarantee,BorrowingUse=@BorrowingUse,ValidityID=@ValidityID,Title=@Title,Keywords=@Keywords,Description=@Description,Reason=@Reason where loansInfoID=@loansInfoID ";
            SqlParameter[] ps = new SqlParameter[]{
                     new SqlParameter("@CountryID",loansinfo.CountryID)
                    ,new SqlParameter ("@ProvinceID",loansinfo.ProvinceID)
                    ,new SqlParameter ("@CityID",loansinfo.CityID)
                    ,new SqlParameter ("@CountyID",loansinfo.CountyID)
                    ,new SqlParameter ("@Amount",loansinfo.Amount)
                    ,new SqlParameter ("@Deadline",loansinfo.Deadline)
                    ,new SqlParameter ("@Reimbursement",loansinfo.Reimbursement)              
                    ,new SqlParameter ("@Guarantee",loansinfo.Guarantee)
                    ,new SqlParameter ("@BorrowingUse",loansinfo.BorrowingUse )
                    ,new SqlParameter ("@ValidityID",loansinfo.ValidityID)
                    ,new SqlParameter ("@Title",loansinfo.Title)              
                    ,new SqlParameter ("@Keywords",loansinfo.Keywords )
                    ,new SqlParameter ("@Description",loansinfo.Description )
                    ,new SqlParameter ("@Reason",loansinfo.Reason)
                    ,new SqlParameter ("@loansInfoID",LoansInfoId)

                    
            };
            int result = DbHelperSQL.ExecuteSql(sql, ps);
            return result;
        }
        public int DeleteLoansInfo(int loansInfoID)
        {
            string sql = "delete loansinfo where loansInfoID=@loansInfoID  ";
            int result = DbHelperSQL.ExecuteSql(sql, new SqlParameter("loansInfoID", loansInfoID));
            return result;
        }
    }
}
