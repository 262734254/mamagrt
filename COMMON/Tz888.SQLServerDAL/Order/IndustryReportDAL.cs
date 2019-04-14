using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.Orders;
using Tz888.DBUtility;
using System.Data;
using System.Data.SqlClient;
namespace Tz888.SQLServerDAL.Order
{
    public class IndustryReportDAL:Tz888.IDAL.Order.IndustryReportIDAL
    {
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public IndustryReport GetModel(string orderNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 industryId,orderNo,Company,LinkName,address,sex,fax,reportID,position,Note,reportPrice from IndustryReport ");
            strSql.Append(" where orderNo=@orderNo");
            SqlParameter[] parameters = {
					new SqlParameter("@orderNo", SqlDbType.VarChar,50)
};
            parameters[0].Value = orderNo;

            IndustryReport model = new IndustryReport();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["reportID"].ToString() != "")
                {
                    model.reportID = int.Parse(ds.Tables[0].Rows[0]["reportID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["industryId"].ToString() != "")
                {
                    model.industryId = int.Parse(ds.Tables[0].Rows[0]["industryId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["reportPrice"].ToString() != "")
                {
                    model.reportPrice = ds.Tables[0].Rows[0]["reportPrice"].ToString();
                }
                if (ds.Tables[0].Rows[0]["orderNo"].ToString() != "")
                {
                    model.orderNo = ds.Tables[0].Rows[0]["orderNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["LinkName"].ToString() != "")
                {
                    model.LinkName = ds.Tables[0].Rows[0]["LinkName"].ToString();
                }
                model.Company = ds.Tables[0].Rows[0]["Company"].ToString();
                model.address = ds.Tables[0].Rows[0]["address"].ToString();
                if (ds.Tables[0].Rows[0]["sex"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["sex"].ToString() == "1") || (ds.Tables[0].Rows[0]["sex"].ToString().ToLower() == "true"))
                    {
                        model.sex = true;
                    }
                    else
                    {
                        model.sex = false;
                    }
                }
                model.fax = ds.Tables[0].Rows[0]["fax"].ToString();
                model.position = ds.Tables[0].Rows[0]["position"].ToString();
                model.Note = ds.Tables[0].Rows[0]["Note"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }
    }
}
