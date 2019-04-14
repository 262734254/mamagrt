using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Tz888.DBUtility;

namespace Tz888.SQLServerDAL.Register
{
 public    class SS_ProfessionalServices
    {

     #region　　会员注册－－－－－－－－－－－－－－－
     public void ProfessionalAdd(Tz888.Model.Register.SS_ProfessionalServices model)
     {

         SqlParameter[] parameters = {
					
                
                new SqlParameter("@LoginName", SqlDbType.Char,16),
					new SqlParameter("@NnitName",SqlDbType.VarChar,50 ),
					new SqlParameter("@CountryCode", SqlDbType.Char,10),
                    new SqlParameter("@ProvinceID", SqlDbType.Int),
                    new SqlParameter("@CityID", SqlDbType.Int),
					new SqlParameter("@AreaID", SqlDbType.Int),
					new SqlParameter("@Job", SqlDbType.VarChar,50),
					new SqlParameter("@TalentType", SqlDbType.Int),
					new SqlParameter("@ServiceSmalltype", SqlDbType.VarChar,100),
					new SqlParameter("@ServiceBigtype", SqlDbType.Int),
                    new SqlParameter("@Resume",SqlDbType.VarChar,2000),
                    new SqlParameter("@Specialty",SqlDbType.VarChar,2000),
                    new SqlParameter("@BefCase",SqlDbType.VarChar,2000),
                    new SqlParameter("@Tel",SqlDbType.VarChar,50),
                    new SqlParameter("@FAX",SqlDbType.VarChar,50), 
                    new SqlParameter("@Mobile",SqlDbType.VarChar,50),
                    new SqlParameter("@Address", SqlDbType.VarChar,100),
                    new SqlParameter("@Pic",SqlDbType.VarChar,100),
                    new SqlParameter("@Email",SqlDbType.VarChar,50),
                    new SqlParameter("@Regdate",SqlDbType.DateTime),
                    new SqlParameter("@RealName",SqlDbType.VarChar,50)
                  
			};

         parameters[0].Value = model.LoginName;
         parameters[1].Value = model.NnitName;
         parameters[2].Value = model.CountryCode;
         parameters[3].Value = model.ProvinceID;
         parameters[4].Value = model.CityID;
         parameters[5].Value = model.AreaID;
         parameters[6].Value = model.Job;
         parameters[7].Value = model.TalentType;
         parameters[8].Value = model.ServiceSmalltype;
         parameters[9].Value = model.ServiceBigtype;
         parameters[10].Value = model.Resume;
         parameters[11].Value = model.Specialty;
         parameters[12].Value = model.BefCase;
         parameters[13].Value = model.Tel;
         parameters[14].Value = model.FAX;
         parameters[15].Value = model.Mobile;
         parameters[16].Value = model.Address;
         parameters[17].Value = model.Pic;
         parameters[18].Value = model.Email;
         parameters[19].Value = model.RegDate;
         parameters[20].Value = model.RealName;
         try
         {
             DbHelperSQL.RunProcedure("ProfessionalServicesInsert", parameters);

         }
         catch (SqlException ex)
         {
             throw new Exception(ex.Message);
         }
         // DbHelperSQL.RunProcedure(
     }
     #endregion
     public bool SS_ProUpdate(Tz888.Model.Register.SS_ProfessionalServices model)
     {
         SqlParameter[] parameters = {
					
                
                new SqlParameter("@PSID", SqlDbType.Int),
					new SqlParameter("@NnitName",SqlDbType.VarChar,50 ),
					new SqlParameter("@CountryCode", SqlDbType.Char,10),
                    new SqlParameter("@ProvinceID", SqlDbType.Int),
                    new SqlParameter("@CityID", SqlDbType.Int),
					new SqlParameter("@AreaID", SqlDbType.Int),
					new SqlParameter("@Job", SqlDbType.VarChar,50),
					new SqlParameter("@TalentType", SqlDbType.Int),
					new SqlParameter("@ServiceSmalltype", SqlDbType.VarChar,100),
					new SqlParameter("@ServiceBigtype", SqlDbType.Int),
                    new SqlParameter("@Resume",SqlDbType.VarChar,2000),
                    new SqlParameter("@Specialty",SqlDbType.VarChar,2000),
                    new SqlParameter("@BefCase",SqlDbType.VarChar,2000),
                    new SqlParameter("@Tel",SqlDbType.VarChar,50),
                    new SqlParameter("@FAX",SqlDbType.VarChar,50), 
                    new SqlParameter("@Mobile",SqlDbType.VarChar,50),
                    new SqlParameter("@Address", SqlDbType.VarChar,100),
                    new SqlParameter("@Pic",SqlDbType.VarChar,100),
                    new SqlParameter("@Email",SqlDbType.VarChar,50),
                    new SqlParameter("@RealName",SqlDbType.VarChar,50),
                  new SqlParameter("@flag",SqlDbType.VarChar,50)
			};

         parameters[0].Value = model.PSID ;
         parameters[1].Value = model.NnitName;
         parameters[2].Value = model.CountryCode;
         parameters[3].Value = model.ProvinceID;
         parameters[4].Value = model.CityID;
         parameters[5].Value = model.AreaID;
         parameters[6].Value = model.Job;
         parameters[7].Value = model.TalentType;
         parameters[8].Value = model.ServiceSmalltype;
         parameters[9].Value = model.ServiceBigtype;
         parameters[10].Value = model.Resume;
         parameters[11].Value = model.Specialty;
         parameters[12].Value = model.BefCase;
         parameters[13].Value = model.Tel;
         parameters[14].Value = model.FAX;
         parameters[15].Value = model.Mobile;
         parameters[16].Value = model.Address;
         parameters[17].Value = model.Pic;
         parameters[18].Value = model.Email;
         parameters[19].Value = model.RealName;
         parameters[20].Value = "Update";

         return DbHelperSQL.RunProcLob("ProfessionalServicesInsert", parameters);
     }
    }
}
