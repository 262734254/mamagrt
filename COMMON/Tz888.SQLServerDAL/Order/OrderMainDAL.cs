using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.Orders;
using System.Data;
using System.Data.SqlClient;
using Tz888.DBUtility;
namespace Tz888.SQLServerDAL.Order
{
    public class OrderMainDAL:Tz888.IDAL.Order.OrderMainIDAL
    {
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public OrderMain GetModel(string orderNo)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 orderId,orderNo,typeId,Num,state,orderDate,amount,paySate,payMent from OrderMain ");
            strSql.Append(" where orderNo=@orderNo");
            SqlParameter[] parameters = {
					new SqlParameter("@orderNo", SqlDbType.VarChar,50)
};
            parameters[0].Value = orderNo;

            OrderMain model = new OrderMain();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["orderNo"].ToString() != "")
                {
                    model.orderNo = ds.Tables[0].Rows[0]["orderNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["typeId"].ToString() != "")
                {
                    model.typeId = int.Parse(ds.Tables[0].Rows[0]["typeId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Num"].ToString() != "")
                {
                    model.num = int.Parse(ds.Tables[0].Rows[0]["Num"].ToString());
                }
                if (ds.Tables[0].Rows[0]["state"].ToString() != "")
                {
                    model.state = int.Parse(ds.Tables[0].Rows[0]["state"].ToString());
                }
                if (ds.Tables[0].Rows[0]["orderDate"].ToString() != "")
                {
                    model.orderDate = DateTime.Parse(ds.Tables[0].Rows[0]["orderDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["amount"].ToString() != "")
                {
                    model.amount = decimal.Parse(ds.Tables[0].Rows[0]["amount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["paySate"].ToString() != "")
                {
                    model.paySate = int.Parse(ds.Tables[0].Rows[0]["paySate"].ToString());
                }
                model.payMent = ds.Tables[0].Rows[0]["payMent"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 插入一条数据
        /// </summary>
        /// <param name="main"></param>
        /// <param name="linkInfo"></param>
        /// <param name="report"></param>
        /// <returns></returns>
        public bool InsertMainThreeTab(OrderMain main, OrderLink linkInfo, IndustryReport report)
        {
            //int result = 0;

            SqlParameter[] parameters ={
                 new SqlParameter("@orderNo",SqlDbType.VarChar,100),
                 new SqlParameter("@typeId",SqlDbType.Int,4),
                 new SqlParameter("@state",SqlDbType.Int,4),
                 new SqlParameter("@amount",SqlDbType.Decimal),
                 new SqlParameter("@paySate",SqlDbType.Int,4),
                 new SqlParameter("@payMent",SqlDbType.VarChar,50),
                 new SqlParameter("@Num",SqlDbType.Int,4), 

                 new SqlParameter("@loginName",SqlDbType.VarChar,50),
                 new SqlParameter("@phone",SqlDbType.VarChar,50),
                 new SqlParameter("@tel",SqlDbType.VarChar,50),
                 new SqlParameter("@email",SqlDbType.VarChar,50),

                 new SqlParameter("@Company",SqlDbType.VarChar,50),
                 new SqlParameter("@address",SqlDbType.VarChar,50),
                 new SqlParameter("@sex",SqlDbType.Bit),
                 new SqlParameter("@fax",SqlDbType.VarChar,50),
                 new SqlParameter("@position ",SqlDbType.VarChar,50),
                 new SqlParameter("@Note",SqlDbType.VarChar,3000),
                 new SqlParameter("@LinkName",SqlDbType.VarChar,50),
                 new SqlParameter("@reportID",SqlDbType.Int),
                new SqlParameter("@reportPrice",SqlDbType.VarChar,80)
            };
            parameters[0].Value = main.orderNo;
            parameters[1].Value = main.typeId;
            parameters[2].Value = main.state;
            parameters[3].Value = main.amount;
            parameters[4].Value = main.paySate;
            parameters[5].Value = main.payMent;
            parameters[6].Value = main.num;
            parameters[7].Value = linkInfo.loginName;
            parameters[8].Value = linkInfo.phone;
            parameters[9].Value = linkInfo.tel;
            parameters[10].Value = linkInfo.email;
            parameters[11].Value = report.Company;
            parameters[12].Value = report.address;
            parameters[13].Value = report.sex;
            parameters[14].Value = report.fax;
            parameters[15].Value = report.position;
            parameters[16].Value = report.Note;
            parameters[17].Value = report.LinkName;
            parameters[18].Value = report.reportID;
            parameters[19].Value = report.reportPrice;
            return DbHelperSQL.RunProcLob("OrderThreeTabMain_insert", parameters);
        }
        /// <summary>
        /// 修改一条数据
        /// </summary>
        /// <param name="main"></param>
        /// <param name="linkInfo"></param>
        /// <param name="report"></param>
        /// <returns></returns>
        public bool UpdateMainThreeTab(OrderMain main, OrderLink linkInfo, IndustryReport report)
        {
            int result = 0;

            SqlParameter[] parameters ={
                 new SqlParameter("@orderNo",SqlDbType.VarChar,100),
                 new SqlParameter("@typeId",SqlDbType.Int,4),
                 new SqlParameter("@state",SqlDbType.Int,4),

                 new SqlParameter("@amount",SqlDbType.Decimal),
                 new SqlParameter("@paySate",SqlDbType.Int,4),
                 new SqlParameter("@payMent",SqlDbType.VarChar,50),
                 new SqlParameter("@Num",SqlDbType.Int,4), 

                 //new SqlParameter("@loginName",SqlDbType.VarChar,50),
                 new SqlParameter("@phone",SqlDbType.VarChar,50),
                 new SqlParameter("@tel",SqlDbType.VarChar,50),
                 new SqlParameter("@email",SqlDbType.VarChar,50),

                 new SqlParameter("@Company",SqlDbType.VarChar,50),
                 new SqlParameter("@address",SqlDbType.VarChar,50),
                 new SqlParameter("@sex",SqlDbType.Bit),
                 new SqlParameter("@fax",SqlDbType.VarChar,50),
                 new SqlParameter("@position ",SqlDbType.VarChar,50),
                 new SqlParameter("@Note",SqlDbType.VarChar,3000),
                 new SqlParameter("@LinkName",SqlDbType.VarChar,50),
                 //new SqlParameter("@reportID",SqlDbType.Int),
                new SqlParameter("@reportPrice",SqlDbType.VarChar,80),
                new SqlParameter("@flag",SqlDbType.VarChar,50),
            };
            parameters[0].Value = main.orderNo;
            parameters[1].Value = main.typeId;
            parameters[2].Value = main.state;
            
            parameters[3].Value = main.amount;
            parameters[4].Value = main.paySate;
            parameters[5].Value = main.payMent;
            parameters[6].Value = main.num;
            //parameters[7].Value = linkInfo.loginName;
            parameters[7].Value = linkInfo.phone;
            parameters[8].Value = linkInfo.tel;
            parameters[9].Value = linkInfo.email;
            parameters[10].Value = report.Company;
            parameters[11].Value = report.address;
            parameters[12].Value = report.sex;
            parameters[13].Value = report.fax;
            parameters[14].Value = report.position;
            parameters[15].Value = report.Note;
            parameters[16].Value = report.LinkName;
            //parameters[18].Value = report.reportID;
            parameters[17].Value = report.reportPrice;
            parameters[18].Value = "updateManage";
            return DbHelperSQL.RunProcLob("OrderThreeTabMain_insert", parameters);
        }
        public bool DeleteMainByOrderNo(string OrderNo)
        {
            string sql = "update OrderMain set state=3 where orderNo='" + OrderNo+"'";
            if (DbHelperSQL.ExecuteSql(sql) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
