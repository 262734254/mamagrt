using System;
using System.Data;
using System.Data.SqlClient;
using Tz888.IDAL.Professional;
using Tz888.DBUtility;//请先添加引用
using Tz888.Model.Professional;
namespace Tz888.SQLServerDAL.Professional
{
    public class ProfessionalviewDAL : ProfessionalviewIDAL
    {

        #region ProfessionalviewIDAL 成员
        /// <summary>
        /// 插入一条专业服务数据
        /// </summary>
        /// <returns></returns>
        public bool InsertProFessionlView(ProfessionalinfoTab mainInfo, Professionalview viewInfo, ProfessionalLink link)
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
                 new SqlParameter("@typeID1",SqlDbType.Int,4),
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
                 new SqlParameter("@Site",SqlDbType.VarChar,50),  //8


                 new SqlParameter("@price",SqlDbType.Decimal,18) //1
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
            parameters[10].Value = viewInfo.typeID;
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
          return DbHelperSQL.RunProcLob("Professionalviewtab_insert", parameters);
        }
          
        #endregion

        #region ProfessionalviewIDAL 成员


        public bool UpdateProFessionlView(ProfessionalinfoTab mainInfo, Professionalview viewInfo, ProfessionalLink link)
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
                 new SqlParameter("@typeID1",SqlDbType.Int,4),
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
                 new SqlParameter("@Site",SqlDbType.VarChar,50),  //8
                 new SqlParameter("@price",SqlDbType.Decimal,18), //1

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
            parameters[10].Value = viewInfo.typeID;
            parameters[11].Value = viewInfo.validityID;
            parameters[12].Value =viewInfo.description;
            parameters[13].Value = viewInfo.title;
            parameters[14].Value = viewInfo.keywords;
            parameters[15].Value = viewInfo.Webdescription;
            parameters[16].Value = link.UserName;
            parameters[17].Value = link.CompanyName;
            parameters[18].Value = link.Address;
            parameters[19].Value = link.Tel;
            parameters[20].Value = link.phone;
            parameters[21].Value = link.Fax;
            parameters[22].Value = link.Email;
            parameters[23].Value = link.Site;
            parameters[24].Value = mainInfo.price;
            parameters[25].Value = "Update";
            parameters[26].Value = mainInfo.ProfessionalID;
            return DbHelperSQL.RunProcLob("Professionalviewtab_insert", parameters);
        }

        #endregion
    }
}

