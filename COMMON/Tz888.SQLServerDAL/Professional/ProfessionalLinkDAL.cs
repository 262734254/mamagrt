using System;
using System.Collections.Generic;
using Tz888.DBUtility;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using Tz888.Model.Professional;
using Tz888.IDAL.Professional;
namespace Tz888.SQLServerDAL.Professional
{
    public class ProfessionalLinkDAL:ProfessionalLinkIDAL
    {
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ProfessionalLink GetModel(int Lid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Lid,ProfessionalID,UserName,CompanyName,Address,Tel,phone,Fax,Email,Site from ProfessionalLink ");
            strSql.Append(" where ProfessionalID=@Lid");
            SqlParameter[] parameters = {
					new SqlParameter("@Lid", SqlDbType.Int,4)
};
            parameters[0].Value = Lid;

            ProfessionalLink model = new ProfessionalLink();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Lid"].ToString() != "")
                {
                    model.Lid = int.Parse(ds.Tables[0].Rows[0]["Lid"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProfessionalID"].ToString() != "")
                {
                    model.ProfessionalID = int.Parse(ds.Tables[0].Rows[0]["ProfessionalID"].ToString());
                }
                model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                model.CompanyName = ds.Tables[0].Rows[0]["CompanyName"].ToString();
                model.Address = ds.Tables[0].Rows[0]["Address"].ToString();
                model.Tel = ds.Tables[0].Rows[0]["Tel"].ToString();
                model.phone = ds.Tables[0].Rows[0]["phone"].ToString();
                model.Fax = ds.Tables[0].Rows[0]["Fax"].ToString();
                model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                model.Site = ds.Tables[0].Rows[0]["Site"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }
    }
}
