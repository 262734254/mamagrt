using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.Orders;
using System.Data;
using Tz888.DBUtility;
using System.Data.SqlClient;
namespace Tz888.SQLServerDAL.Order
{
    public class OrderLinkDAL:Tz888.IDAL.Order.OrderLinkIDAL
    {
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public OrderLink GetModel(string orderNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 linkId,orderNo,loginName,phone,tel,email from OrderLink ");
            strSql.Append(" where orderNo=@orderNo");
            SqlParameter[] parameters = {
					new SqlParameter("@orderNo", SqlDbType.VarChar,50)
};
            parameters[0].Value = orderNo;

            OrderLink model = new OrderLink();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["linkId"].ToString() != "")
                {
                    model.linkId = int.Parse(ds.Tables[0].Rows[0]["linkId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["orderNo"].ToString() != "")
                {
                    model.orderNo = ds.Tables[0].Rows[0]["orderNo"].ToString();
                }
                model.loginName = ds.Tables[0].Rows[0]["loginName"].ToString();
                model.phone = ds.Tables[0].Rows[0]["phone"].ToString();
                model.tel = ds.Tables[0].Rows[0]["tel"].ToString();
                model.email = ds.Tables[0].Rows[0]["email"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }

    }
}
