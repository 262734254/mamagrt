using System;
using System.Collections.Generic;
using System.Text;
using Tz888.IDAL.Professional;
using Tz888.Model.Professional;
using Tz888.DBUtility;
using System.Data.SqlClient;
using System.Data;
namespace Tz888.SQLServerDAL.Professional
{
    public class ProfessionalPleaseDAL : ProfessionalPleaseIDAL
    {
        #region ProfessionalviewIDAL 成员
        /// <summary>
        /// 插入一条专业服务数据
        /// </summary>
        /// <returns></returns>
        public bool InsertProFessionlView(ProfessionalinfoTab mainInfo, ProfessionalPlease viewInfo, ProfessionalLink link)
        {
            int result = 0;
            SqlParameter[] parameters = {
                 new SqlParameter("@Title",SqlDbType.VarChar,200),
                 new SqlParameter("@LoginName",SqlDbType.VarChar,50),
                 new SqlParameter("@typeID",SqlDbType.Int,4),
                 new SqlParameter("@htmlUrl",SqlDbType.VarChar,200),
                 new SqlParameter("@formID",SqlDbType.Int,4),
                 new SqlParameter("@recommendID",SqlDbType.Int,4), //6
                

                 new SqlParameter("@CountryCode",SqlDbType.VarChar,10),
                 new SqlParameter("@ProvinceID",SqlDbType.VarChar,10),
                 new SqlParameter("@CityID",SqlDbType.VarChar,10),
                 new SqlParameter("@CountyID",SqlDbType.VarChar,10),
                 new SqlParameter("@servicetypeID",SqlDbType.Int,4),
                 
                 new SqlParameter("@validityID",SqlDbType.Int,4),
                 new SqlParameter("@description",SqlDbType.NVarChar,2000),
                 new SqlParameter("@Webtitle",SqlDbType.VarChar,50),
                 new SqlParameter("@keywords",SqlDbType.VarChar,50),
                 new SqlParameter("@Webdescription",SqlDbType.VarChar,50), //10

                 new SqlParameter("@UserName",SqlDbType.VarChar,100),
                 new SqlParameter("@CompanyName",SqlDbType.VarChar,100),
                 new SqlParameter("@Address",SqlDbType.VarChar,100),
                 new SqlParameter("@Tel",SqlDbType.VarChar,50),
                 new SqlParameter("@phone",SqlDbType.VarChar,50),
                 new SqlParameter("@Fax",SqlDbType.VarChar,50),
                 new SqlParameter("@Email",SqlDbType.VarChar,50),
                 new SqlParameter("@Site",SqlDbType.VarChar,50), 
                 new SqlParameter("@price",SqlDbType.Decimal,18), //9

                 new SqlParameter("@institutionsID",SqlDbType.Int,4),
                 new SqlParameter("@Enterprisesize",SqlDbType.NVarChar,2000),
                 new SqlParameter("@funds",SqlDbType.VarChar,50),
                 new SqlParameter("@turnover",SqlDbType.VarChar,50),
                 new SqlParameter("@companyDate",SqlDbType.DateTime)  //5
             };
            parameters[0].Value = mainInfo.Titel;
            parameters[1].Value = mainInfo.LoginName;
            parameters[2].Value = mainInfo.typeID;
            parameters[3].Value = mainInfo.htmlUrl;
            parameters[4].Value = mainInfo.FromId;
            parameters[5].Value = mainInfo.recommendId;
            parameters[6].Value = viewInfo.CountryCode;
            parameters[7].Value = viewInfo.ProvinceID;
            parameters[8].Value = viewInfo.CityID;
            parameters[9].Value = viewInfo.CountyID;
            parameters[10].Value = viewInfo.servicetypeID;
            parameters[11].Value = viewInfo.validityID;
            parameters[12].Value = viewInfo.description;
            parameters[13].Value = viewInfo.title;
            parameters[14].Value = viewInfo.keywords;
            parameters[15].Value = viewInfo.description;
            parameters[16].Value = link.UserName;
            parameters[17].Value = link.CompanyName;
            parameters[18].Value = link.Address;
            parameters[19].Value = link.Tel;
            parameters[20].Value = link.phone;
            parameters[21].Value = link.Fax;
            parameters[22].Value = link.Email;
            parameters[23].Value = link.Site;
            parameters[24].Value = mainInfo.price;

            parameters[25].Value = viewInfo.institutionsID;
            parameters[26].Value = viewInfo.Enterprisesize;
            parameters[27].Value = viewInfo.funds;
            parameters[28].Value = viewInfo.turnover;
            parameters[29].Value = viewInfo.companydate;
            return DbHelperSQL.RunProcLob("ProfessionalPleasetab_insert", parameters);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ProfessionalPlease GetModel(int ProfessionalID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 provideID,ProfessionalID,CountryCode,ProvinceID,CityID,CountyID,servicetypeID,institutionsID,Enterprisesize,funds,turnover,companydate,validityID,description,title,keywords,webdescription from ProfessionalPlease ");
            strSql.Append(" where ProfessionalID=@ProfessionalID");
            SqlParameter[] parameters = {
					new SqlParameter("@ProfessionalID", SqlDbType.Int,4)
};
            parameters[0].Value = ProfessionalID;

            ProfessionalPlease model = new ProfessionalPlease();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["provideID"].ToString() != "")
                {
                    model.provideID = int.Parse(ds.Tables[0].Rows[0]["provideID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProfessionalID"].ToString() != "")
                {
                    model.ProfessionalID = int.Parse(ds.Tables[0].Rows[0]["ProfessionalID"].ToString());
                }
                model.CountryCode = ds.Tables[0].Rows[0]["CountryCode"].ToString();
                model.ProvinceID = ds.Tables[0].Rows[0]["ProvinceID"].ToString();
                model.CityID = ds.Tables[0].Rows[0]["CityID"].ToString();
                model.CountyID = ds.Tables[0].Rows[0]["CountyID"].ToString();
                if (ds.Tables[0].Rows[0]["servicetypeID"].ToString() != "")
                {
                    model.servicetypeID = int.Parse(ds.Tables[0].Rows[0]["servicetypeID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["institutionsID"].ToString() != "")
                {
                    model.institutionsID = int.Parse(ds.Tables[0].Rows[0]["institutionsID"].ToString());
                }
                model.Enterprisesize = ds.Tables[0].Rows[0]["Enterprisesize"].ToString();
                model.funds = ds.Tables[0].Rows[0]["funds"].ToString();
                model.turnover = ds.Tables[0].Rows[0]["turnover"].ToString();
                if (ds.Tables[0].Rows[0]["companydate"].ToString() != "")
                {
                    model.companydate = DateTime.Parse(ds.Tables[0].Rows[0]["companydate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["validityID"].ToString() != "")
                {
                    model.validityID = int.Parse(ds.Tables[0].Rows[0]["validityID"].ToString());
                }
                model.description = ds.Tables[0].Rows[0]["description"].ToString();
                model.title = ds.Tables[0].Rows[0]["title"].ToString();
                model.keywords = ds.Tables[0].Rows[0]["keywords"].ToString();
                model.webdescription = ds.Tables[0].Rows[0]["webdescription"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }

        public bool UpdateProFessionlView(ProfessionalinfoTab mainInfo, ProfessionalPlease viewInfo, ProfessionalLink link)
        {
            int result = 0;
            SqlParameter[] parameters = {
                 new SqlParameter("@Title",SqlDbType.VarChar,200),
                 new SqlParameter("@LoginName",SqlDbType.VarChar,50),
                 new SqlParameter("@typeID",SqlDbType.Int,4),
                 new SqlParameter("@htmlUrl",SqlDbType.VarChar,200),
                 new SqlParameter("@formID",SqlDbType.Int,4),
                 new SqlParameter("@recommendID",SqlDbType.Int,4), //6
                

                 new SqlParameter("@CountryCode",SqlDbType.VarChar,10),
                 new SqlParameter("@ProvinceID",SqlDbType.VarChar,10),
                 new SqlParameter("@CityID",SqlDbType.VarChar,10),
                 new SqlParameter("@CountyID",SqlDbType.VarChar,10),
                 new SqlParameter("@servicetypeID",SqlDbType.Int,4),
                 
                 new SqlParameter("@validityID",SqlDbType.Int,4),
                 new SqlParameter("@description",SqlDbType.NVarChar,2000),
                 new SqlParameter("@Webtitle",SqlDbType.VarChar,50),
                 new SqlParameter("@keywords",SqlDbType.VarChar,50),
                 new SqlParameter("@Webdescription",SqlDbType.VarChar,50), //10

                 new SqlParameter("@UserName",SqlDbType.VarChar,100),
                 new SqlParameter("@CompanyName",SqlDbType.VarChar,100),
                 new SqlParameter("@Address",SqlDbType.VarChar,100),
                 new SqlParameter("@Tel",SqlDbType.VarChar,50),
                 new SqlParameter("@phone",SqlDbType.VarChar,50),
                 new SqlParameter("@Fax",SqlDbType.VarChar,50),
                 new SqlParameter("@Email",SqlDbType.VarChar,50),
                 new SqlParameter("@Site",SqlDbType.VarChar,50), 
                 new SqlParameter("@price",SqlDbType.Decimal,18), //9

                 new SqlParameter("@institutionsID",SqlDbType.Int,4),
                 new SqlParameter("@Enterprisesize",SqlDbType.NVarChar,2000),
                 new SqlParameter("@funds",SqlDbType.VarChar,50),
                 new SqlParameter("@turnover",SqlDbType.VarChar,50),
                 new SqlParameter("@companyDate",SqlDbType.DateTime,25), //5

                 new SqlParameter("@flag",SqlDbType.VarChar,20), 
                 new SqlParameter("@ProfessionalID",SqlDbType.Int,4) //2
             };
            parameters[0].Value = mainInfo.Titel;
            parameters[1].Value = mainInfo.LoginName;
            parameters[2].Value = mainInfo.typeID;
            parameters[3].Value = mainInfo.htmlUrl;
            parameters[4].Value = mainInfo.FromId;
            parameters[5].Value = mainInfo.recommendId;
            parameters[6].Value = viewInfo.CountryCode;
            parameters[7].Value = viewInfo.ProvinceID;
            parameters[8].Value = viewInfo.CityID;
            parameters[9].Value = viewInfo.CountyID;
            parameters[10].Value = viewInfo.servicetypeID;
            parameters[11].Value = viewInfo.validityID;
            parameters[12].Value = viewInfo.description;
            parameters[13].Value = viewInfo.title;
            parameters[14].Value = viewInfo.keywords;
            parameters[15].Value = viewInfo.description;
            parameters[16].Value = link.UserName;
            parameters[17].Value = link.CompanyName;
            parameters[18].Value = link.Address;
            parameters[19].Value = link.Tel;
            parameters[20].Value = link.phone;
            parameters[21].Value = link.Fax;
            parameters[22].Value = link.Email;
            parameters[23].Value = link.Site;
            parameters[24].Value = mainInfo.price;

            parameters[25].Value = viewInfo.institutionsID;
            parameters[26].Value = viewInfo.Enterprisesize;
            parameters[27].Value = viewInfo.funds;
            parameters[28].Value = viewInfo.turnover;
            parameters[29].Value = viewInfo.companydate;
            parameters[30].Value = "Update";
            parameters[31].Value = mainInfo.ProfessionalID;
            try
            {
                return DbHelperSQL.RunProcLob("ProfessionalPleasetab_insert", parameters);
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        #endregion

    }
}
