using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.Info;
using Tz888.IDAL.Info.V124;
using Tz888.DBUtility;
using System.Data.SqlClient;
using System.Data;

namespace Tz888.SQLServerDAL.Info.V124
{
    public class MerchantZoneDAL : IMerchantZone
    {
        #region  成员方法
        /// <summary>
        ///  增加一条数据
        /// </summary>
        public long Insert(Tz888.Model.Info.V124.MerchantZoneModel model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@InfoID", SqlDbType.BigInt,8),
					new SqlParameter("@CountryCode", SqlDbType.Char,10),
					new SqlParameter("@ProvinceID", SqlDbType.Char,10),
					new SqlParameter("@CityID", SqlDbType.Char,10),
					new SqlParameter("@CountyID", SqlDbType.Char,10),
					new SqlParameter("@GovName", SqlDbType.VarChar,50),
					new SqlParameter("@Address", SqlDbType.VarChar,50),
					new SqlParameter("@WebSite", SqlDbType.VarChar,50),
					new SqlParameter("@ZoneSituation", SqlDbType.Text),
					new SqlParameter("@MineralSituation", SqlDbType.Text),
					new SqlParameter("@IndustrySituation", SqlDbType.Text),
					new SqlParameter("@MerchantPolicy", SqlDbType.Text),
					new SqlParameter("@ProAndGov", SqlDbType.Text),
					new SqlParameter("@LinkName", SqlDbType.VarChar,30),
					new SqlParameter("@Tel", SqlDbType.VarChar,30),
					new SqlParameter("@Mobile", SqlDbType.VarChar,30),
					new SqlParameter("@Email", SqlDbType.VarChar,50),
					new SqlParameter("@LoginName", SqlDbType.VarChar,30),
					new SqlParameter("@InfoCode", SqlDbType.VarChar,30),
					new SqlParameter("@PublishTime", SqlDbType.DateTime),
					new SqlParameter("@ValiditeTerm", SqlDbType.Int,4),
					new SqlParameter("@HtmlFile", SqlDbType.VarChar,100),
					new SqlParameter("@AuditBy", SqlDbType.VarChar,30),
					new SqlParameter("@AuditTime", SqlDbType.DateTime),
					new SqlParameter("@StateFlag", SqlDbType.Int,4)};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.CountryCode;
            parameters[2].Value = model.ProvinceID;
            parameters[3].Value = model.CityID;
            parameters[4].Value = model.CountyID;
            parameters[5].Value = model.GovName;
            parameters[6].Value = model.Address;
            parameters[7].Value = model.WebSite;
            parameters[8].Value = model.ZoneSituation;
            parameters[9].Value = model.MineralSituation;
            parameters[10].Value = model.IndustrySituation;
            parameters[11].Value = model.MerchantPolicy;
            parameters[12].Value = model.ProAndGov;
            parameters[13].Value = model.LinkName;
            parameters[14].Value = model.Tel;
            parameters[15].Value = model.Mobile;
            parameters[16].Value = model.Email;
            parameters[17].Value = model.LoginName;
            parameters[18].Value = model.InfoCode;
            parameters[19].Value = model.PublishTime;
            parameters[20].Value = model.ValiditeTerm;
            parameters[21].Value = model.HtmlFile;
            parameters[22].Value = model.AuditBy;
            parameters[23].Value = model.AuditTime;
            parameters[24].Value = model.StateFlag;

            DbHelperSQL.RunProcedure("MerchantZoneTab_Insert", parameters, out rowsAffected);
            return (long)parameters[0].Value;
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public bool Update(Tz888.Model.Info.V124.MerchantZoneModel model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@InfoID", SqlDbType.BigInt,8),
					new SqlParameter("@CountryCode", SqlDbType.Char,10),
					new SqlParameter("@ProvinceID", SqlDbType.Char,10),
					new SqlParameter("@CityID", SqlDbType.Char,10),
					new SqlParameter("@CountyID", SqlDbType.Char,10),
					new SqlParameter("@GovName", SqlDbType.VarChar,50),
					new SqlParameter("@Address", SqlDbType.VarChar,50),
					new SqlParameter("@WebSite", SqlDbType.VarChar,50),
					new SqlParameter("@ZoneSituation", SqlDbType.Text),
					new SqlParameter("@MineralSituation", SqlDbType.Text),
					new SqlParameter("@IndustrySituation", SqlDbType.Text),
					new SqlParameter("@MerchantPolicy", SqlDbType.Text),
					new SqlParameter("@ProAndGov", SqlDbType.Text),
					new SqlParameter("@LinkName", SqlDbType.VarChar,30),
					new SqlParameter("@Tel", SqlDbType.VarChar,30),
					new SqlParameter("@Mobile", SqlDbType.VarChar,30),
					new SqlParameter("@Email", SqlDbType.VarChar,50),
					new SqlParameter("@LoginName", SqlDbType.VarChar,30),
					new SqlParameter("@InfoCode", SqlDbType.VarChar,30),
					new SqlParameter("@PublishTime", SqlDbType.DateTime),
					new SqlParameter("@ValiditeTerm", SqlDbType.Int,4),
					new SqlParameter("@HtmlFile", SqlDbType.VarChar,100),
					new SqlParameter("@AuditBy", SqlDbType.VarChar,30),
					new SqlParameter("@AuditTime", SqlDbType.DateTime),
					new SqlParameter("@StateFlag", SqlDbType.Int,4)};
            parameters[0].Value = model.InfoID;
            parameters[1].Value = model.CountryCode;
            parameters[2].Value = model.ProvinceID;
            parameters[3].Value = model.CityID;
            parameters[4].Value = model.CountyID;
            parameters[5].Value = model.GovName;
            parameters[6].Value = model.Address;
            parameters[7].Value = model.WebSite;
            parameters[8].Value = model.ZoneSituation;
            parameters[9].Value = model.MineralSituation;
            parameters[10].Value = model.IndustrySituation;
            parameters[11].Value = model.MerchantPolicy;
            parameters[12].Value = model.ProAndGov;
            parameters[13].Value = model.LinkName;
            parameters[14].Value = model.Tel;
            parameters[15].Value = model.Mobile;
            parameters[16].Value = model.Email;
            parameters[17].Value = model.LoginName;
            parameters[18].Value = model.InfoCode;
            parameters[19].Value = model.PublishTime;
            parameters[20].Value = model.ValiditeTerm;
            parameters[21].Value = model.HtmlFile;
            parameters[22].Value = model.AuditBy;
            parameters[23].Value = model.AuditTime;
            parameters[24].Value = model.StateFlag;

            DbHelperSQL.RunProcedure("MerchantZoneTab_Update", parameters, out rowsAffected);

            if (rowsAffected > 0)
                return true;
            return false;
        }

        public bool Update(string colName, string value,long infoID)
        {
            string SqlText = "Update set " + colName + " = '" + value + "' from MerchantZoneTab where InfoID = " + infoID.ToString();

            int rowsAffected = DbHelperSQL.ExecuteSql(SqlText);

            if (rowsAffected > 0)
                return true;
            return false;
        }

        #endregion  成员方法
    }
}