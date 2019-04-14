using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Tz888.DBUtility;

namespace Tz888.SQLServerDAL.Register
{
    public class SS_Agency_Services
    {
        #region　　会员注册－－－－－－－－－－－－－－－

        public void AgencyAdd(Tz888.Model.Register.SS_Agency_Services model)
        {

            SqlParameter[] parameters = {
					
                
                new SqlParameter("@LoginName", SqlDbType.Char,16),
					new SqlParameter("@OrganName",SqlDbType.VarChar,50 ),
					new SqlParameter("@CountryCode", SqlDbType.Char,10),
                    new SqlParameter("@ProvinceID", SqlDbType.Int),
                    new SqlParameter("@CityID", SqlDbType.Int),
					new SqlParameter("@Area", SqlDbType.Int),
					new SqlParameter("@OrganType", SqlDbType.Int),
					new SqlParameter("@ServiceBigtype", SqlDbType.Int),
					new SqlParameter("@ServiceSmalltype", SqlDbType.VarChar,100),
					new SqlParameter("@BusinessCount", SqlDbType.Int),
                    new SqlParameter("@Bankroll",SqlDbType.Int),
                    new SqlParameter("@FoundDate",SqlDbType.VarChar,30),
                    new SqlParameter("@Turnover",SqlDbType.VarChar,50),
                    new SqlParameter("@BusinessView",SqlDbType.VarChar,200),
                    new SqlParameter("@www",SqlDbType.VarChar,50), 
                    new SqlParameter("@LinkName",SqlDbType.VarChar,50),

                    new SqlParameter("@Tel", SqlDbType.VarChar,50),
                    new SqlParameter("@FAX",SqlDbType.VarChar,50),
                    new SqlParameter("@Email",SqlDbType.VarChar,50),
                    new SqlParameter("@Regdate",SqlDbType.DateTime)
                  
			};

            parameters[0].Value = model.LoginName;
            parameters[1].Value = model.OrganName;
            parameters[2].Value = model.CountryCode;
            parameters[3].Value = model.ProvinceID;
            parameters[4].Value = model.CityID;
            parameters[5].Value = model.Area;
            parameters[6].Value = model.OrganType;
            parameters[7].Value = model.ServiceBigtype;
            parameters[8].Value = model.ServiceSmalltype;
            parameters[9].Value = model.BusinessCount;
            parameters[10].Value = model.Bankroll;
            parameters[11].Value = model.FoundDate;
            parameters[12].Value = model.Turnover;
            parameters[13].Value = model.BusinessView;
            parameters[14].Value = model.www;
            parameters[15].Value = model.LinkName;

            parameters[16].Value = model.Tel;
            parameters[17].Value = model.FAX;
            parameters[18].Value = model.Email;
            parameters[19].Value = model.Regdate;
            try
            {
                DbHelperSQL.RunProcLob("StructInsert", parameters);

            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            // DbHelperSQL.RunProcedure(
        }
        #endregion


        public Tz888.Model.Register.SS_Agency_Services getModel(string FileName, string TableName, string Where, int Top)
        {
            SqlParameter[] parameters = {
					
                
                new SqlParameter("@FileName", SqlDbType.VarChar,300),
					new SqlParameter("@TableName",SqlDbType.VarChar,100 ),
					new SqlParameter("@Where", SqlDbType.VarChar,300),
                    new SqlParameter("@Top", SqlDbType.Int),
         	};

            parameters[0].Value = FileName;
            parameters[1].Value = TableName;
            parameters[2].Value = Where;
            parameters[3].Value = Top;
            DataSet ds = DbHelperSQL.RunProcedure("Common_Top", parameters, "SS_Str");
            Tz888.Model.Register.SS_Agency_Services model = new Tz888.Model.Register.SS_Agency_Services();
            if (ds != null)
            {
                DataTable dt = ds.Tables["SS_Str"];
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        model.LoginName = dt.Rows[0]["LoginName"].ToString();
                        model.OrganName = dt.Rows[0]["OrganName"].ToString();
                        model.CountryCode = dt.Rows[0]["CountryCode"].ToString();
                        if (!string.IsNullOrEmpty(dt.Rows[0]["ProvinceID"].ToString()))
                        {
                            model.ProvinceID = int.Parse(dt.Rows[0]["ProvinceID"].ToString());
                        }
                        if (!string.IsNullOrEmpty(dt.Rows[0]["CityID"].ToString()))
                        {
                            model.CityID = int.Parse(dt.Rows[0]["CityID"].ToString());
                        }
                        if (!string.IsNullOrEmpty(dt.Rows[0]["Area"].ToString()))
                        {
                            model.Area = int.Parse(dt.Rows[0]["Area"].ToString());
                        }
                        if (!string.IsNullOrEmpty(dt.Rows[0]["OrganType"].ToString()))
                        {
                            model.OrganType = int.Parse(dt.Rows[0]["OrganType"].ToString());
                        }
                        if (!string.IsNullOrEmpty(dt.Rows[0]["ServiceBigtype"].ToString()))
                        {
                            model.ServiceBigtype = int.Parse(dt.Rows[0]["ServiceBigtype"].ToString());
                        }

                        model.ServiceSmalltype = dt.Rows[0]["ServiceSmalltype"].ToString();
                        if (!string.IsNullOrEmpty(dt.Rows[0]["BusinessCount"].ToString()))
                        {
                            model.BusinessCount = int.Parse(dt.Rows[0]["BusinessCount"].ToString());
                        }
                        if (!string.IsNullOrEmpty(dt.Rows[0]["Bankroll"].ToString()))
                        {
                            model.Bankroll = int.Parse(dt.Rows[0]["Bankroll"].ToString());
                        }
                        model.FoundDate = dt.Rows[0]["FoundDate"].ToString();
                        model.Turnover = dt.Rows[0]["Turnover"].ToString();
                        model.BusinessView = dt.Rows[0]["BusinessView"].ToString();
                        model.www = dt.Rows[0]["www"].ToString();
                        model.LinkName = dt.Rows[0]["LinkName"].ToString();
                        model.Tel = dt.Rows[0]["Tel"].ToString();
                        model.FAX = dt.Rows[0]["FAX"].ToString();
                        model.Email = dt.Rows[0]["Email"].ToString();
                        if (!string.IsNullOrEmpty(dt.Rows[0]["Regdate"].ToString()))
                        {
                            model.Regdate = DateTime.Parse(dt.Rows[0]["Regdate"].ToString());
                        }
                        if (!string.IsNullOrEmpty(dt.Rows[0]["IsChekUp"].ToString()))
                        {
                            model.IsChekUp = int.Parse(dt.Rows[0]["IsChekUp"].ToString());
                        }

                    }
                }
            }

            return model;
        }
        public bool SS_StrUpdate(Tz888.Model.Register.SS_Agency_Services model)
        {
            SqlParameter[] parameters = {
					
                
                new SqlParameter("@OrganID", SqlDbType.Int),
					new SqlParameter("@OrganName",SqlDbType.VarChar,50 ),
					new SqlParameter("@CountryCode", SqlDbType.Char,10),
                    new SqlParameter("@ProvinceID", SqlDbType.Int),
                    new SqlParameter("@CityID", SqlDbType.Int),
					new SqlParameter("@Area", SqlDbType.Int),
					new SqlParameter("@OrganType", SqlDbType.Int),
					new SqlParameter("@ServiceBigtype", SqlDbType.Int),
					new SqlParameter("@ServiceSmalltype", SqlDbType.VarChar,100),
					new SqlParameter("@BusinessCount", SqlDbType.Int),
                    new SqlParameter("@Bankroll",SqlDbType.Int),
                    new SqlParameter("@FoundDate",SqlDbType.VarChar,30),
                    new SqlParameter("@Turnover",SqlDbType.VarChar,50),
                    new SqlParameter("@BusinessView",SqlDbType.VarChar,200),
                    new SqlParameter("@www",SqlDbType.VarChar,50), 
                    new SqlParameter("@LinkName",SqlDbType.VarChar,50),

                    new SqlParameter("@Tel", SqlDbType.VarChar,50),
                    new SqlParameter("@FAX",SqlDbType.VarChar,50),
                    new SqlParameter("@Email",SqlDbType.VarChar,50),
                new SqlParameter("@flag",SqlDbType.VarChar,50),
                  
			};

            parameters[0].Value = model.OrganID;
            parameters[1].Value = model.OrganName;
            parameters[2].Value = model.CountryCode;
            parameters[3].Value = model.ProvinceID;
            parameters[4].Value = model.CityID;
            parameters[5].Value = model.Area;
            parameters[6].Value = model.OrganType;
            parameters[7].Value = model.ServiceBigtype;
            parameters[8].Value = model.ServiceSmalltype;
            parameters[9].Value = model.BusinessCount;
            parameters[10].Value = model.Bankroll;
            parameters[11].Value = model.FoundDate;
            parameters[12].Value = model.Turnover;
            parameters[13].Value = model.BusinessView;
            parameters[14].Value = model.www;
            parameters[15].Value = model.LinkName;

            parameters[16].Value = model.Tel;
            parameters[17].Value = model.FAX;
            parameters[18].Value = model.Email;
            parameters[19].Value = "update";
            return DbHelperSQL.RunProcLob("StructInsert", parameters);
        }
    }
}


