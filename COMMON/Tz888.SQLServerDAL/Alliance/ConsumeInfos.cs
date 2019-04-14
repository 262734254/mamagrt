using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Tz888.DBUtility;
using Tz888.IDAL;

namespace Tz888.SQLServerDAL
{
    public class ConsumeInfos :IConsumeInfos
    {
         /// <summary>
         /// 用户发布资源信息列表
         /// </summary>
         /// <param name="SelectStr"></param>
         /// <param name="Criteria"></param>
         /// <param name="Sort"></param>
         /// <param name="Page"></param>
         /// <param name="CurrentPageRow"></param>
         /// <param name="TotalCount"></param>
         /// <param name="start"></param>
         /// <param name="end"></param>
         /// <returns></returns>
        public DataSet dsGetConsumeCountList(
                                string SelectStr,
                                string Criteria,
                                string Sort,
                                long Page,
                                long CurrentPageRow,
                                out long TotalCount,
                                string  start,
                                string  end
                               )
        {
            DataSet ds = new DataSet();
            TotalCount = 0;
            SqlParameter[] parameters = {	
                                        new SqlParameter("@SelectStr",SqlDbType.VarChar,500),
                                        new SqlParameter("@Criteria",SqlDbType.VarChar,8000),
					                    new SqlParameter("@Sort",SqlDbType.VarChar,255), 
					                    new SqlParameter("@Page",SqlDbType.BigInt),
					                    new SqlParameter("@CurrentPageRow",SqlDbType.BigInt),
					                    new SqlParameter("@TotalCount",SqlDbType.BigInt), 
                                        new SqlParameter("@start",SqlDbType.VarChar,50),
                                        new SqlParameter("@end",SqlDbType.VarChar,50),
			                };
            parameters[0].Value = SelectStr;
            parameters[1].Value = Criteria;
            parameters[2].Value = Sort;
            parameters[3].Value = CurrentPageRow;
            parameters[4].Value = Page;

            parameters[5].Value = TotalCount;
            parameters[5].Direction = ParameterDirection.InputOutput;

            parameters[6].Value = start;
            parameters[7].Value = end;

            try
            {
                ds = DbHelperSQL.RunProcedure("Sp_MConsumeInfoList", parameters, "dss");

                if (ds != null)
                {
                    DataView dv = new DataView();

                    //dv = dt.DefaultView;
                    dv = ds.Tables[0].DefaultView;
                    int count = ds.Tables[0].Rows.Count;
                    if (Page > 0)
                    {
                        TotalCount = Convert.ToInt64(parameters[5].Value);
                    }
                    else
                    {
                        TotalCount = dv.Count;
                        if (TotalCount > 0)
                        {
                            CurrentPageRow = 1;
                        }
                        else
                        {
                            CurrentPageRow = 0;
                        }
                    }
                }
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {

            }

            return ds;
        }
        /// <summary>
        /// 资源联盟收益总数信息 
        /// </summary>
        /// <returns></returns>
        public DataSet GetCountMess()
        {
            SqlParameter[] parameters ={ };
            DataSet ds = DbHelperSQL.RunProcedure("Sp_Count", parameters, "ds");
            return ds;
        }

        public DataTable GetConsumeCount(string UserName)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,16), 
            };
            parameters[0].Value = UserName;

            DataSet ds = DbHelperSQL.RunProcedure("countGaint", parameters, "ds");
            return ds.Tables[0];
        }

        
        public DataTable GetAuditingStatusCount(string UserName)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,16), 
            };
            parameters[0].Value = UserName;

            DataSet ds = DbHelperSQL.RunProcedure("Sp_MAuditingStatus", parameters, "ds");
            return ds.Tables[0];
        }



        /// <summary>
        /// 增加一条数据 －－购买 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add(Tz888.Model.ConsumeInfos model)
        {
            SqlParameter[] parameters = {  
                    new SqlParameter("@InfoID", SqlDbType.BigInt,8),
                    new SqlParameter("@PublishUserName", SqlDbType.VarChar,30),
                    new SqlParameter("@ExpendMoney", SqlDbType.Float,8), 
                    new SqlParameter("@GainMoney", SqlDbType.Float,8),
                    new SqlParameter("@ExpendUserName",SqlDbType.VarChar,30), 
                    new SqlParameter("@CreateDate",SqlDbType.DateTime,8),
                    new SqlParameter("@status",SqlDbType.Int,4),
                    new SqlParameter("@flag",SqlDbType.VarChar,30),
            };
            parameters[0].Value = model.InfoID;
            parameters[1].Value = model.PublishUserName;
            parameters[2].Value = model.ExpendMoney;
            parameters[3].Value = model.GainMoney;
            parameters[4].Value = model.ExpendUserName;
            parameters[5].Value = model.CreateDate;
            parameters[6].Value = model.Status;
            parameters[7].Value = "Insert";
            bool b = DbHelperSQL.RunProcLob("SP_ConsumeInfo", parameters);
            return b;
        } 

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="PassWord"></param>
        /// <returns></returns>
        public bool Update(Tz888.Model.ConsumeInfos model)
        {
            SqlParameter[] parameters = {
					                    new SqlParameter("@ID", SqlDbType.BigInt,8), 
                                        new SqlParameter("@status",SqlDbType.Int,4), 
                                        new SqlParameter("@Remark",SqlDbType.Text),
				                        new SqlParameter("@flag ",SqlDbType.VarChar,30)						
                                        };
            parameters[0].Value = model.ID; 
            parameters[1].Value = model.Status;
            parameters[2].Value = model.Remark;
            parameters[3].Value = "Update";
            bool b = DbHelperSQL.RunProcLob("SP_ConsumeRec", parameters);
            return b;

        }
    }
}
