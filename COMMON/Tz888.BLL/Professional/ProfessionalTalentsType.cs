using System;
using System.Collections.Generic;
using System.Text;
using Tz888.IDAL.Professional;
using Tz888.Model.Professional;
using Tz888.DBUtility;
using System.Data.SqlClient;
using System.Data;
namespace Tz888.BLL.Professional
{
   public  class ProfessionalTalentsType
    {
        #region Model
        private int _typeid;
        private string _typename;
        private int  _orderid;
        /// <summary>
        /// 
        /// </summary>
        public int typeid
        {
            set { _typeid = value; }
            get { return _typeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string typeName
        {
            set { _typename = value; }
            get { return _typename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int orderId
        {
            set { _orderid = value; }
            get { return _orderid; }
        }
        #endregion Model

        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select typeid,typeName,orderId ");
            strSql.Append(" FROM TalentsType ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" typeid,typeName,orderId ");
            strSql.Append(" FROM TalentsType ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}
