using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using Tz888.DBUtility;

namespace Tz888.SQLServerDAL
{
    public class WebUnion_UserInfo 
    { 
        /// <summary>
        /// 更新用户资料
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateWebUnion_UserInfo(Tz888.Model.WebUnion_UserInfo model)
        {

            SqlParameter[] parameters = {
					new SqlParameter("@flag", SqlDbType.VarChar,30),
					new SqlParameter("@UserName", SqlDbType.VarChar,16),
					new SqlParameter("@CompanyName", SqlDbType.VarChar,50),
					new SqlParameter("@LinkMan", SqlDbType.VarChar,20),
					new SqlParameter("@LinkTel", SqlDbType.VarChar,20),
					new SqlParameter("@Email", SqlDbType.VarChar,30),
                    new SqlParameter("@QQMSN", SqlDbType.VarChar,20),
                    new SqlParameter("@NetName",SqlDbType.VarChar,50),
                    new SqlParameter("@NetDomain",SqlDbType.VarChar,50),
                    new SqlParameter("@NetDescript",SqlDbType.Text),
                    new SqlParameter("@NetCallNum",SqlDbType.Int,4),
                    new SqlParameter("@NetType",SqlDbType.VarChar,30),
                    new SqlParameter("@NetRemark",SqlDbType.Text),
                    new SqlParameter("@AuditStatus",SqlDbType.Int,4),
                    new SqlParameter("@AuditMan",SqlDbType.VarChar,16),
                 new SqlParameter("@NetName",SqlDbType.VarChar,50),
                 new SqlParameter("@NetDomain",SqlDbType.VarChar,50),
                 new SqlParameter("@Netscript",SqlDbType.Text),
                 new SqlParameter("@NetCallNum",SqlDbType.Int,16),
                 new SqlParameter("@NetType",SqlDbType.VarChar,30),
                new SqlParameter("@NetRemark",SqlDbType.Text)
					};
            parameters[0].Value = "AuditNet";
            parameters[1].Value = model.UserName;
            parameters[2].Value = model.CompanyName;
            parameters[3].Value = model.LinkMan;
            parameters[4].Value = model.LinkTel;
            parameters[5].Value = model.Email;
            parameters[6].Value = model.QQMSN;
            parameters[7].Value = model.NetName;
            parameters[8].Value = model.NetDomain;
            parameters[9].Value = model.NetDescript;
            parameters[10].Value = model.NetCallnum;
            parameters[11].Value = model.NetType;
            parameters[12].Value = model.NetRemark;
            parameters[13].Value = model.AuditStatus;
            parameters[14].Value = model.AuditMan;
            parameters[15].Value = model.NetName;
            parameters[16].Value = model.NetDomain;
            parameters[17].Value = model.NetDescript;
            parameters[18].Value = model.NetCallnum;
            parameters[19].Value = model.NetType;
            parameters[20].Value = model.NetRemark;
            bool b = DbHelperSQL.RunProcLob("UserInfo", parameters);
            return b;
        }


   

        /// <summary>
        /// 用户详细信息
        /// </summary>
        public Tz888.Model.WebUnion_UserInfo GetModel(string UserName)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,16),
                    new SqlParameter("@flag", SqlDbType.VarChar,30)
				};
            parameters[0].Value = UserName;
            parameters[1].Value = "SelectNet";
            Tz888.Model.WebUnion_UserInfo model = new Tz888.Model.WebUnion_UserInfo();

            DataSet ds = DbHelperSQL.RunProcedure("UserInfo", parameters, "ds");
            model.UserName = UserName;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                model.CompanyName = ds.Tables[0].Rows[0]["CompanyName"].ToString();
                model.CountryCode = ds.Tables[0].Rows[0]["CountryCode"].ToString();
                model.ProvinceID = ds.Tables[0].Rows[0]["ProvinceID"].ToString();
                model.CityID = ds.Tables[0].Rows[0]["CityID"].ToString();
                model.CountyID = ds.Tables[0].Rows[0]["CountyID"].ToString();
                model.IndustryID = ds.Tables[0].Rows[0]["IndustryID"].ToString();
                model.ServiesMID = ds.Tables[0].Rows[0]["ServiesMID"].ToString();
                if (ds.Tables[0].Rows[0]["EmployeeCount"].ToString() != "")
                {
                    model.EmployeeCount = int.Parse(ds.Tables[0].Rows[0]["EmployeeCount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RegistMoeny"].ToString() != "")
                {
                    model.RegistMoeny = decimal.Parse(ds.Tables[0].Rows[0]["RegistMoeny"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RegistYear"].ToString() != "")
                {
                    model.RegistYear = decimal.Parse(ds.Tables[0].Rows[0]["RegistYear"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Turnover"].ToString() != "")
                {
                    model.Turnover = decimal.Parse(ds.Tables[0].Rows[0]["Turnover"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ServiesBID"].ToString() != "")
                {
                    model.ServiesBID = ds.Tables[0].Rows[0]["ServiesBID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ServiesMID"].ToString() != "")
                {
                    model.ServiesMID = ds.Tables[0].Rows[0]["ServiesMID"].ToString();
                }
                model.BusinesDetails = ds.Tables[0].Rows[0]["BusinesDetails"].ToString();
                model.WebSite = ds.Tables[0].Rows[0]["WebSite"].ToString();
                model.LinkMan = ds.Tables[0].Rows[0]["LinkMan"].ToString();
                model.LinkTel = ds.Tables[0].Rows[0]["LinkTel"].ToString();
                model.LinkFax = ds.Tables[0].Rows[0]["LinkFax"].ToString();
                model.QQMSN = ds.Tables[0].Rows[0]["QQMSN"].ToString();
                model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                if (ds.Tables[0].Rows[0]["isOpen"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["isOpen"].ToString() == "1") || (ds.Tables[0].Rows[0]["isOpen"].ToString().ToLower() == "true"))
                    {
                        model.isOpen = true;
                    }
                    else
                    {
                        model.isOpen = false;
                    }
                }

                if (ds.Tables[0].Rows[0]["SubmitDate"].ToString() != "")
                {

                    model.SubmitDate = DateTime.Parse(ds.Tables[0].Rows[0]["SubmitDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AuditStatus"].ToString() != "")
                {
                    model.AuditStatus = int.Parse(ds.Tables[0].Rows[0]["AuditStatus"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AuditDate"].ToString() != "")
                {

                    model.AuditDate = DateTime.Parse(ds.Tables[0].Rows[0]["AuditDate"].ToString());
                }
                model.AuditMan = ds.Tables[0].Rows[0]["AuditMan"].ToString();
                model.NetName = ds.Tables[0].Rows[0]["NetName"].ToString();
                model.NetDomain = ds.Tables[0].Rows[0]["NetDomain"].ToString();
                model.NetDescript = ds.Tables[0].Rows[0]["NetDescript"].ToString();
                model.NetCallnum = ds.Tables[0].Rows[0]["NetCallNum"].ToString();
                model.NetType = ds.Tables[0].Rows[0]["NetType"].ToString();
                model.NetRemark = ds.Tables[0].Rows[0]["NetRemark"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 联盟申请信息
        /// </summary>
        /// <param name="SelectStr"></param>
        /// <param name="Criteria"></param>
        /// <param name="Sort"></param>
        /// <param name="Page"></param>
        /// <param name="CurrentPageRow"></param>
        /// <param name="TotalCount"></param>
        /// <returns></returns>
        public DataSet dsGetNetUserTabList(
                                     string SelectStr,
                                     string Criteria,
                                     string Sort,
                                     long Page,
                                     long CurrentPageRow,
                                     out long TotalCount
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
			                };
            parameters[0].Value = SelectStr;
            parameters[1].Value = Criteria;
            parameters[2].Value = Sort;
            parameters[3].Value = Page;
            parameters[4].Value = CurrentPageRow;

            parameters[5].Value = TotalCount;
            parameters[5].Direction = ParameterDirection.InputOutput;

            try
            {
                ds = DbHelperSQL.RunProcedure("Sp_NetUserTabList", parameters, "ds");

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
        /// 删除一条数据
        /// </summary>
        public bool Delete(int UserID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@LoginID", SqlDbType.Int,4),
                     new SqlParameter("@flag", SqlDbType.VarChar,30),

				};
            parameters[0].Value = UserID;
            parameters[1].Value = "Deletes";
            bool b = DbHelperSQL.RunProcLob("UserInfo", parameters);
            return b;
        }

 
    }

}