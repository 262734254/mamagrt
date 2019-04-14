using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Security.Cryptography;
using Tz888.IDAL;
using System.Data.SqlClient;
using Tz888.DBUtility;//请先添加引用

namespace Tz888.SQLServerDAL
{
    public class BusinesProcess : IBusinesProcess
    {
        #region IBusinesProcess 成员
        /// <summary>
        ///  增加一条数据
        /// </summary>
        public bool Add(Tz888.Model.BusinesProcess model)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@flag", SqlDbType.VarChar,30),
					new SqlParameter("@UserName", SqlDbType.VarChar,16),
					new SqlParameter("@Title", SqlDbType.VarChar,50),
					new SqlParameter("@CompanyName", SqlDbType.VarChar,50),
					new SqlParameter("@SubmitMan", SqlDbType.VarChar,16),
					new SqlParameter("@Descript", SqlDbType.VarChar,300),
					new SqlParameter("@CountryCode", SqlDbType.VarChar,10),
					new SqlParameter("@ProvinceID", SqlDbType.VarChar,10),
					new SqlParameter("@CityID", SqlDbType.VarChar,10),
					new SqlParameter("@CountyID", SqlDbType.VarChar,10),
					new SqlParameter("@Address", SqlDbType.VarChar,50),
					new SqlParameter("@Tel", SqlDbType.VarChar,20),
					new SqlParameter("@Fax", SqlDbType.VarChar,20),
                    new SqlParameter("@Email", SqlDbType.VarChar,30),
                    new SqlParameter("@ServiesBID", SqlDbType.Int),
                    new SqlParameter("@ServiesMID", SqlDbType.Int),};
            parameters[0].Value = "Insert";
            parameters[1].Value = model.UserName;
            parameters[2].Value = model.Title;
            parameters[3].Value = model.CompanyName;
            parameters[4].Value = model.SubmitMan;
            parameters[5].Value = model.Descript;
            parameters[6].Value = model.CountryCode;
            parameters[7].Value = model.ProvinceID;
            parameters[8].Value = model.CityID;
            parameters[9].Value = model.CountyID;
            parameters[10].Value = model.Address;
            parameters[11].Value = model.Tel;
            parameters[12].Value = model.Fax;
            parameters[13].Value = model.Email;
            parameters[14].Value = model.ServiesBID;
            parameters[15].Value = model.ServiesMID;
            bool b = DbHelperSQL.RunProcLobHO("BusinesProcess", parameters);
            return b;
        }
        /// <summary>
        /// 大小类查询
        /// </summary>
        /// <param name="big"></param>
        /// <returns></returns>
        public DataSet SelectBig(int big)
        {
            DataSet ds = new DataSet();
            SqlParameter[] parameters = {
					new SqlParameter("@big", SqlDbType.Int)};
            parameters[0].Value = big;
            ds = DbHelperSQL.RunProcedures0("ServicesBigAndSmall", parameters, "ds");
            return ds;
        }

        /// <summary>
        /// 所属机构类别
        /// </summary>
        /// <param name="IndustryID"></param>
        /// <returns></returns>
        public DataSet SelectIndustry(int IndustryID)
        {
            DataSet ds = new DataSet();
            SqlParameter[] parameters = { 
                    new SqlParameter("@Structure", SqlDbType.Int) };
            parameters[0].Value = IndustryID;
            ds = DbHelperSQL.RunProcedures0("StructureCity", parameters, "ds");
            return ds;
        }

        #endregion
    }
}
