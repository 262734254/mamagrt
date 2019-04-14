using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tz888.IDAL;
using Tz888.DBUtility;
namespace Tz888.SQLServerDAL
{
    /// <summary>
    /// 推广
    /// </summary>
    public class SubscribeSet : ISubscribeSet
    {
        //推广设置
        public bool SendSet(Tz888.Model.SubscribeSet model)
        {

            SqlParameter[] parameters = {
					new SqlParameter("@InfoID", SqlDbType.BigInt,8),
					new SqlParameter("@Title", SqlDbType.VarChar,50),
					new SqlParameter("@LoginName", SqlDbType.Char,16),
					new SqlParameter("@objectGradeID", SqlDbType.VarChar,40),
					new SqlParameter("@objectNeed", SqlDbType.VarChar,100),
					new SqlParameter("@CountryCode", SqlDbType.VarChar,50),
					new SqlParameter("@ProvinceID", SqlDbType.VarChar,50),
					new SqlParameter("@CityID", SqlDbType.VarChar,50),
					new SqlParameter("@CountyID", SqlDbType.VarChar,50),
					new SqlParameter("@Industry", SqlDbType.VarChar,100),
					new SqlParameter("@OtherCriter", SqlDbType.VarChar,500),
					new SqlParameter("@SubscribeType", SqlDbType.Char,10),
					new SqlParameter("@SubscribeCount", SqlDbType.Int,4),
                  };
            parameters[0].Value = model.InfoID;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.LoginName;
            parameters[3].Value = model.objectGradeID;
            parameters[4].Value = model.objectNeed;
            parameters[5].Value = model.CountryCode;
            parameters[6].Value = model.ProvinceID;
            parameters[7].Value = model.CityID;
            parameters[8].Value = model.CountyID;
            parameters[9].Value = model.Industry;
            parameters[10].Value = model.OtherCriter;
            parameters[11].Value = model.SubscribeType;
            parameters[12].Value = model.SubscribeCount;

            bool b = DbHelperSQL.RunProcLob("SubscribeSendSet", parameters);
            return b;
        }
        /// <summary>
        /// 推广接收设置
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ReceivedSet(Tz888.Model.SubscribeGetSet model)
        {
            bool b = false;
            SqlParameter[] parameters = {
					new SqlParameter("@flag", SqlDbType.VarChar,30),
					new SqlParameter("@LoginName", SqlDbType.Char,10),
					new SqlParameter("@IsGet", SqlDbType.Int,4),
					new SqlParameter("@objectGradeID", SqlDbType.VarChar,20),
					new SqlParameter("@objectNeed", SqlDbType.VarChar,50),
					new SqlParameter("@CountryCode", SqlDbType.VarChar,50),
					new SqlParameter("@ProvinceID", SqlDbType.VarChar,50),
					new SqlParameter("@CityID", SqlDbType.VarChar,50),
					new SqlParameter("@CountyID", SqlDbType.VarChar,50),
					new SqlParameter("@Industry", SqlDbType.VarChar,100),
					new SqlParameter("@OtherCriter", SqlDbType.VarChar,100),
					new SqlParameter("@ReveiveType", SqlDbType.Char,10)};
            parameters[0].Value = "ReceivedSet";//接收设置
            parameters[1].Value = model.LoginName;
            parameters[2].Value = model.IsGet;
            parameters[3].Value = model.objectGradeID;
            parameters[4].Value = model.objectNeed;
            parameters[5].Value = model.CountryCode;
            parameters[6].Value = model.ProvinceID;
            parameters[7].Value = model.CityID;
            parameters[8].Value = model.CountyID;
            parameters[9].Value = model.Industry;
            parameters[10].Value = model.OtherCriter;
            parameters[11].Value = model.ReveiveType;
            b = DbHelperSQL.RunProcLob("SubscribeReceivedSet", parameters);
            return b;
        }
        /// <summary>
        /// 是否接收
        /// </summary>
        /// <param name="LoginName"></param>
        /// <param name="isget">1为是  非1为否</param>
        /// <returns></returns>
        public bool IsReveive(string LoginName, int isget)
        {
            bool b = false;
            SqlParameter[] parameters = {
					            new SqlParameter("@flag", SqlDbType.VarChar,30),
                                 new SqlParameter("@LoginName", SqlDbType.VarChar,30),
                                 new SqlParameter("@isGet", SqlDbType.Int),
                                          };
            parameters[0].Value = "isGet";//接收设置
            parameters[1].Value = LoginName;
            parameters[2].Value = isget;
            b = DbHelperSQL.RunProcLob("SubscribeReceivedSet", parameters);
            return b;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        public bool DeleteInfo(long ID)
        {
            bool b = false;
            SqlParameter[] parameters = {
					new SqlParameter("@flag", SqlDbType.VarChar,50),
					new SqlParameter("@ID", SqlDbType.BigInt,8),
					};
            parameters[0].Value = "DeleteInfo";
            parameters[1].Value = ID;

            b = DbHelperSQL.RunProcLob("SubscribeAutoSend", parameters);
            return b;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="LoginName"></param>
        /// <returns></returns>
        public bool DeleteAll(string LoginName)
        {
            bool b = false;
            SqlParameter[] parameters = {
					new SqlParameter("@flag", SqlDbType.VarChar,50),
                    new SqlParameter("@ReceiveLoginName", SqlDbType.VarChar,50),
                     };
            parameters[0].Value = "DeleteAll";
            parameters[1].Value = LoginName;
            b = DbHelperSQL.RunProcLob("SubscribeAutoSend", parameters);
            return b;
        }
        /// <summary>
        /// 更改发送状态
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        public bool isSend(string ReceiveLoginName)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@flag", SqlDbType.VarChar,50),
					new SqlParameter("@ReceiveLoginName", SqlDbType.VarChar,50),
					};
            parameters[0].Value = "isSend";
            parameters[1].Value = ReceiveLoginName;
            bool b = DbHelperSQL.RunProcLob("SubscribeAutoSend", parameters);
            return b;
        }
        /// <summary>
        /// 定向推广接收人列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetReceivedList(string strWhere)
        {
            DataSet ds = null;
            SqlParameter[] parameters = {
					new SqlParameter("@flag", SqlDbType.VarChar,50),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,500),
					};
            parameters[0].Value = "select";
            parameters[1].Value = strWhere;
            ds = DbHelperSQL.RunProcedure("SubscribeAutoSend", parameters, "ds");
            return ds.Tables[0];
        }
        /// <summary>
        /// 资源订阅人列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetMachInfoList(string LoginName)
        {
            DataSet ds = null;
            SqlParameter[] parameters = {
                    new SqlParameter("@LoginName", SqlDbType.VarChar,500),
					};
            parameters[0].Value = LoginName;
            ds = DbHelperSQL.RunProcedure("SendMachInfo", parameters, "ds");
            return ds.Tables[0];
        }
        /// <summary>
        /// 会员过期预警通知
        /// </summary>
        /// <returns></returns>
        public DataTable GetMemberExpiredList()
        {
            DataSet ds = null;
            SqlParameter[] parameters = { };
            ds = DbHelperSQL.RunProcedure("MemberExpiredList", parameters, "ds");
            return ds.Tables[0];
        }
        /// <summary>
        /// 资源过期预警通知
        /// </summary>
        /// <returns></returns>
        public DataTable GetInfoExpiredList()
        {
            DataSet ds = null;
            SqlParameter[] parameters = { };
            ds = DbHelperSQL.RunProcedure("InfoExpiredList", parameters, "ds");
            return ds.Tables[0];
        }
        /// <summary>
        /// 根据ID查询完整的信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Tz888.Model.SubscribeSet GetModels(int Id, out string infotypeid, out string htmlFile)
        {
            SqlParameter[] parameters ={
            new SqlParameter("@ID",SqlDbType.Int,4)
            };
            parameters[0].Value = Id;
            Tz888.Model.SubscribeSet model = new Tz888.Model.SubscribeSet();
            DataSet ds = DbHelperSQL.RunProcedure("SubscribeSetTab_GetListByID", parameters, "ds");
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.InfoID = Convert.ToInt32(ds.Tables[0].Rows[0]["infoid"]);
                model.LoginName = ds.Tables[0].Rows[0]["LoginName"].ToString();
                model.objectGradeID = ds.Tables[0].Rows[0]["objectGradeID"].ToString();
                model.objectNeed = ds.Tables[0].Rows[0]["objectNeed"].ToString();
                model.CountryCode = ds.Tables[0].Rows[0]["CountryCode"].ToString();
                model.ProvinceID = ds.Tables[0].Rows[0]["ProvinceID"].ToString();
                model.CityID = ds.Tables[0].Rows[0]["CityID"].ToString();
                model.CountyID = ds.Tables[0].Rows[0]["CountyID"].ToString();
                model.Industry = ds.Tables[0].Rows[0]["Industry"].ToString();
                model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                model.OtherCriter = ds.Tables[0].Rows[0]["OtherCriter"].ToString();
                model.Promotioncount = ds.Tables[0].Rows[0]["Promotioncount"].ToString();
                model.SubscribeCount = Convert.ToInt32(ds.Tables[0].Rows[0]["SubscribeCount"]);
                model.SubscribeOver = Convert.ToInt32(ds.Tables[0].Rows[0]["SubscribeOver"]);
                model.ManageTypeId = ds.Tables[0].Rows[0]["ManageTypeId"].ToString();
                model.SubscribeType = ds.Tables[0].Rows[0]["SubscribeType"].ToString();
                infotypeid = ds.Tables[0].Rows[0]["infotypeid"].ToString();
                htmlFile = ds.Tables[0].Rows[0]["htmlFile"].ToString();
                return model;
            }
            else
            {
                htmlFile = "";
                infotypeid = "";
                return null;
            }
        }
        public Tz888.Model.SubscribeGetSet GetModel(string LoginName)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@flag", SqlDbType.VarChar,50),
                    new SqlParameter("@LoginName", SqlDbType.VarChar,16)
				};
            parameters[0].Value = "GetModel";
            parameters[1].Value = LoginName;
            Tz888.Model.SubscribeGetSet model = new Tz888.Model.SubscribeGetSet();

            DataSet ds = DbHelperSQL.RunProcedure("SubscribeReceivedSet", parameters, "ds");
            model.LoginName = LoginName;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.LoginName = ds.Tables[0].Rows[0]["LoginName"].ToString();
                if (ds.Tables[0].Rows[0]["IsGet"].ToString() != "")
                {
                    model.IsGet = int.Parse(ds.Tables[0].Rows[0]["IsGet"].ToString());
                }
                model.objectGradeID = ds.Tables[0].Rows[0]["objectGradeID"].ToString();
                model.objectNeed = ds.Tables[0].Rows[0]["objectNeed"].ToString();
                model.CountryCode = ds.Tables[0].Rows[0]["CountryCode"].ToString();
                model.ProvinceID = ds.Tables[0].Rows[0]["ProvinceID"].ToString();
                model.CityID = ds.Tables[0].Rows[0]["CityID"].ToString();
                model.CountyID = ds.Tables[0].Rows[0]["CountyID"].ToString();
                model.Industry = ds.Tables[0].Rows[0]["Industry"].ToString();
                model.OtherCriter = ds.Tables[0].Rows[0]["OtherCriter"].ToString();
                model.ReveiveType = ds.Tables[0].Rows[0]["ReveiveType"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }
        public bool SendSet1(Tz888.Model.SubscribeSet model, out int id)
        {
            SqlParameter[] parameters = {
                    
					new SqlParameter("@InfoID", SqlDbType.BigInt,8),
					new SqlParameter("@Title", SqlDbType.VarChar,50),
					new SqlParameter("@LoginName", SqlDbType.Char,16),
					new SqlParameter("@objectGradeID", SqlDbType.VarChar,40),
					new SqlParameter("@objectNeed", SqlDbType.VarChar,100),
					new SqlParameter("@CountryCode", SqlDbType.VarChar,50),
					new SqlParameter("@ProvinceID", SqlDbType.VarChar,50),
					new SqlParameter("@CityID", SqlDbType.VarChar,50),
					new SqlParameter("@CountyID", SqlDbType.VarChar,50),
					new SqlParameter("@Industry", SqlDbType.VarChar,100),
					new SqlParameter("@OtherCriter", SqlDbType.VarChar,500),
					new SqlParameter("@SubscribeType", SqlDbType.Char,10),
					new SqlParameter("@SubscribeCount", SqlDbType.Int,4),
                    new SqlParameter("@Promotioncount", SqlDbType.VarChar,20),
                new SqlParameter("@ManageTypeID", SqlDbType.VarChar,20),
                    new SqlParameter("@ID", SqlDbType.Int,4),
                  };

            parameters[0].Value = model.InfoID;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.LoginName;
            parameters[3].Value = model.objectGradeID;
            parameters[4].Value = model.objectNeed;
            parameters[5].Value = model.CountryCode;
            parameters[6].Value = model.ProvinceID;
            parameters[7].Value = model.CityID;
            parameters[8].Value = model.CountyID;
            parameters[9].Value = model.Industry;
            parameters[10].Value = model.OtherCriter;
            parameters[11].Value = model.SubscribeType;
            parameters[12].Value = model.SubscribeCount;
            parameters[13].Value = model.Promotioncount;
            parameters[14].Value = model.ManageTypeId;
            parameters[15].Direction = ParameterDirection.Output;

            bool b = DbHelperSQL.RunProcLob("SubscribeSendSet", parameters);
            if (parameters[15].Value == DBNull.Value)
            {
                id = 0;
            }
            else
            {
                id = Convert.ToInt32(parameters[15].Value);
            }
            return b;
        }

        public bool Update(int id, string subType)
        {
            string sql = "update SubscribeSetTab set subscribeType='" + subType + "' where id=" + id;
            int a = DbHelperSQL.ExecuteSql(sql);
            if (a > 0)
            { return true; }
            else
            { return false; }
        }
        /// <summary>
        /// 订单明细表
        /// 根据ID和orderNo来更新SmsConsumeRecTab表
        /// </summary>
        public bool UpdateSmsConsumeRecTab(int Recid)
        {
            string sql = "update SmsConsumeRecTab set promotionstatu=1 where Recid=" + Recid;
            int a = DbHelperSQL.ExecuteSql(sql);
            if (a > 0)
            { return true; }
            else
            { return false; }
        }
        /// <summary>
        /// 定向推广，明细记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Insert(Tz888.Model.SubscribeSetTabLog model)
        {

            StringBuilder sql = new StringBuilder();
            sql.Append("insert into SubscribeSetTabLog(LoginName,SID,LogTimes,SubType)");
            sql.Append("values(");
            sql.Append("'" + model.LoginName + "',");
            sql.Append(model.Sid + ",");
            sql.Append("getdate(),");
            sql.Append("'" + model.SubType + "'");
            sql.Append(")");
            int a = DbHelperSQL.ExecuteSql(sql.ToString());
            if (a > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 根据主表匹配三个表的类型来获取表中的项目描述
        /// </summary>
        /// <param name="infoId"></param>
        /// <param name="infoTypeId"></param>
        /// <returns></returns>
        public string GetDescript(long infoId, string infoTypeId, out string descript)
        {
            SqlParameter[] para = {
            new SqlParameter("@infoid",SqlDbType.BigInt,8), 
            new SqlParameter("@infoTypeId",SqlDbType.VarChar,20),
            new SqlParameter("@descript",SqlDbType.VarChar,5000),
            };
            para[0].Value = infoId;
            para[1].Value = infoTypeId;
            para[2].Direction = ParameterDirection.Output;
           
            DbHelperSQL.RunProcLob("maininfotab_ByinfoIdAndTypeId", para);
           
            descript = para[2].Value.ToString();
            return descript;
        }
    }

}
