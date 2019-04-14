using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Tz888.IDAL.Company;
using Tz888.Model.Company;
using Tz888.DBUtility;

namespace Tz888.SQLServerDAL.Company
{
    public class CompanyDAL:ICompanyInfoTab
    {
        #region ICompanyInfoTab 成员

        CrmDBHelper crm = new CrmDBHelper();
        #region
       
        /// <summary>
        /// 企业名片添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Company_Add(CompanyModel model)
        {
            int rowsAffected;
            int num = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@LoginName", SqlDbType.VarChar,50),
					new SqlParameter("@CompanyName", SqlDbType.VarChar,200),
					new SqlParameter("@IndustryID", SqlDbType.Int,4),
					new SqlParameter("@IndustryName", SqlDbType.VarChar,50),
					new SqlParameter("@RangeID", SqlDbType.Int,4),
					new SqlParameter("@RangeName", SqlDbType.VarChar,50),
					new SqlParameter("@NatureID", SqlDbType.Int,4),
					new SqlParameter("@NatureName", SqlDbType.VarChar,50),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@Hit", SqlDbType.Int,4),
					new SqlParameter("@Integrity", SqlDbType.Int,4),
					new SqlParameter("@EstablishMent", SqlDbType.VarChar,50),
					new SqlParameter("@Employees", SqlDbType.BigInt,8),
					new SqlParameter("@Capital", SqlDbType.BigInt,8),
					new SqlParameter("@LinkName", SqlDbType.VarChar,50),
					new SqlParameter("@Email", SqlDbType.VarChar,50),
					new SqlParameter("@URL", SqlDbType.VarChar,50),
					new SqlParameter("@Address", SqlDbType.VarChar,50),
					new SqlParameter("@Logo", SqlDbType.VarChar,1000),
					new SqlParameter("@Introduction", SqlDbType.NVarChar,2000),
					new SqlParameter("@ServiceProce", SqlDbType.NVarChar,2000),
					new SqlParameter("@Title", SqlDbType.VarChar,50),
					new SqlParameter("@Keywords", SqlDbType.VarChar,100),
					new SqlParameter("@Description", SqlDbType.VarChar,300),
                    new SqlParameter("@TelPhone",SqlDbType.VarChar,50),
                    new SqlParameter("@Mobile",SqlDbType.VarChar,50),
                    new SqlParameter("@AuditingStatus",SqlDbType.Int,4),
                    new SqlParameter("@HtmlFile",SqlDbType.VarChar,100),
                    new SqlParameter("@Ismake",SqlDbType.Int,4),
                    new SqlParameter("@IsDelete",SqlDbType.Int,4),
                    new SqlParameter("@Privice",SqlDbType.Int,4),
                    new SqlParameter("@City",SqlDbType.Int,4),
                    new SqlParameter("@FromId",SqlDbType.Int,4)
            };
            parameters[0].Value = model.LoginName;
            parameters[1].Value = model.CompanyName;
            parameters[2].Value = model.IndustryID;
            parameters[3].Value = model.IndustryName;
            parameters[4].Value = model.RangeID;
            parameters[5].Value = model.RangeName;
            parameters[6].Value = model.NatureID;
            parameters[7].Value = model.NatureName;
            parameters[8].Value = model.CreateDate;
            parameters[9].Value = model.Hit;
            parameters[10].Value = model.Integrity;
            parameters[11].Value = model.EstablishMent;
            parameters[12].Value = model.Employees;
            parameters[13].Value = model.Capital;
            parameters[14].Value = model.LinkName;
            parameters[15].Value = model.Email;
            parameters[16].Value = model.URL;
            parameters[17].Value = model.Address;
            parameters[18].Value = model.Logo;
            parameters[19].Value = model.Introduction;
            parameters[20].Value = model.ServiceProce;
            parameters[21].Value = model.Title;
            parameters[22].Value = model.Keywords;
            parameters[23].Value = model.Description;
            parameters[24].Value = model.Telphone;
            parameters[25].Value = model.Mobile;
            parameters[26].Value = model.Auditingstatus;
            parameters[27].Value = model.Htmlfile;
            parameters[28].Value = model.Ismake;
            parameters[29].Value = model.IsDelete;
            parameters[30].Value = model.Provice;
            parameters[31].Value = model.City;
            parameters[32].Value = 0;
            num=crm.RunProcedure("Pro_Company_Add", parameters, out rowsAffected);
            return num;
        }
        #endregion

        #region 企业名片修改
        /// <summary>
        /// 企业名片修改
        /// </summary>
        /// <param name="model"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Company_Update(CompanyModel model, int id)
        {
            int rowsAffected;
            int num = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@CompanyID", SqlDbType.Int,4),
					new SqlParameter("@LoginName", SqlDbType.VarChar,50),
					new SqlParameter("@CompanyName", SqlDbType.VarChar,200),
					new SqlParameter("@IndustryID", SqlDbType.Int,4),
					new SqlParameter("@IndustryName", SqlDbType.VarChar,50),
					new SqlParameter("@RangeID", SqlDbType.Int,4),
					new SqlParameter("@RangeName", SqlDbType.VarChar,50),
					new SqlParameter("@NatureID", SqlDbType.Int,4),
					new SqlParameter("@NatureName", SqlDbType.VarChar,50),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@Hit", SqlDbType.Int,4),
					new SqlParameter("@Integrity", SqlDbType.Int,4),
					new SqlParameter("@EstablishMent", SqlDbType.VarChar,50),
					new SqlParameter("@Employees", SqlDbType.BigInt,8),
					new SqlParameter("@Capital", SqlDbType.BigInt,8),
					new SqlParameter("@LinkName", SqlDbType.VarChar,50),
					new SqlParameter("@Email", SqlDbType.VarChar,50),
					new SqlParameter("@URL", SqlDbType.VarChar,50),
					new SqlParameter("@Address", SqlDbType.VarChar,50),
					new SqlParameter("@Logo", SqlDbType.VarChar,1000),
					new SqlParameter("@Introduction", SqlDbType.NVarChar,2000),
					new SqlParameter("@ServiceProce", SqlDbType.NVarChar,2000),
					new SqlParameter("@Title", SqlDbType.VarChar,50),
					new SqlParameter("@Keywords", SqlDbType.VarChar,100),
					new SqlParameter("@Description", SqlDbType.VarChar,300),
                    new SqlParameter("@TelPhone",SqlDbType.VarChar,50),
                    new SqlParameter("@Mobile",SqlDbType.VarChar,50),
                    new SqlParameter("@AuditingStatus",SqlDbType.Int,4),
                    new SqlParameter("@HtmlFile",SqlDbType.VarChar,100),
                    new SqlParameter("@Ismake",SqlDbType.Int,4),
                    new SqlParameter("@IsDelete",SqlDbType.Int,4),
                    new SqlParameter("@Provice",SqlDbType.Int,4),
                    new SqlParameter("@City",SqlDbType.Int,4)
            };
            model.CompanyID = id;
            parameters[0].Value = model.CompanyID;
            parameters[1].Value = model.LoginName;
            parameters[2].Value = model.CompanyName;
            parameters[3].Value = model.IndustryID;
            parameters[4].Value = model.IndustryName;
            parameters[5].Value = model.RangeID;
            parameters[6].Value = model.RangeName;
            parameters[7].Value = model.NatureID;
            parameters[8].Value = model.NatureName;
            parameters[9].Value = model.CreateDate;
            parameters[10].Value = model.Hit;
            parameters[11].Value = model.Integrity;
            parameters[12].Value = model.EstablishMent;
            parameters[13].Value = model.Employees;
            parameters[14].Value = model.Capital;
            parameters[15].Value = model.LinkName;
            parameters[16].Value = model.Email;
            parameters[17].Value = model.URL;
            parameters[18].Value = model.Address;
            parameters[19].Value = model.Logo;
            parameters[20].Value = model.Introduction;
            parameters[21].Value = model.ServiceProce;
            parameters[22].Value = model.Title;
            parameters[23].Value = model.Keywords;
            parameters[24].Value = model.Description;
            parameters[25].Value = model.Telphone;
            parameters[26].Value = model.Mobile;
            parameters[27].Value = model.Auditingstatus;
            parameters[28].Value = model.Htmlfile;
            parameters[29].Value = model.Ismake;
            parameters[30].Value = model.IsDelete;
            parameters[31].Value = model.Provice;
            parameters[32].Value = model.City;
            num=crm.RunProcedure("Pro_Company_Update", parameters, out rowsAffected);
            return num;
        }
        #endregion
        #region 判断是否发布了企业名片
        /// <summary>
        /// 判断是否发布了企业名片
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int IfCompany(string name)
        {
            int num = 0;
            string sql = "select count(CompanyID) from CompanyTab where LoginName=@name";
            SqlParameter[] para ={ 
               new SqlParameter("@name",SqlDbType.VarChar,50)
            };
            para[0].Value = name;
            num = Convert.ToInt32(crm.GetSingle(sql,para));
            return num;
        }
        #endregion
        #region 根据用户名查找审核状态
        /// <summary>
        /// 根据用户名查找审核状态
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int SelAdution(string name)
        {
            int num = 0;
            string sql = "select AuditingStatus from CompanyTab where LoginName=@name";
            SqlParameter[] para ={ 
                new SqlParameter("@name",SqlDbType.VarChar,50)
            };
            para[0].Value = name;
            num = Convert.ToInt32(crm.GetSingle(sql,para));
            return num;
        }
        #endregion

        #region 根据用户名查询所对应的信息
        public CompanyModel SelCompany(string name)
        {
            CompanyModel com = new CompanyModel();
            string sql = "select [CompanyID],[LoginName],[CompanyName],[IndustryID],[IndustryName],[RangeID],"
                + "[RangeName],[NatureID],[NatureName],[CreateDate],[Hit],[AuditingStatus],[HtmlFile],[Integrity],"
                + "[EstablishMent],[Employees],[Capital],[Ismake],[IsDelete],[LinkName],[Email],[TelPhone],[Mobile],"
                + "[URL],[Address],[Logo],[Introduction],[ServiceProce],[Title],[Keywords],[Description],[Sheng],[City] from [CompanyTab] "
                + "where LoginName=@name and IsDelete=0";
            SqlParameter[] para ={ 
               new SqlParameter("@name",SqlDbType.VarChar,50)
            };
            para[0].Value = name;
            DataSet ds = crm.Query(sql, para);
            if (ds.Tables[0].Rows.Count <= 0)
                return null;
            com.CompanyID = Convert.ToInt32(ds.Tables[0].Rows[0]["CompanyID"].ToString());//用户编号
            com.LoginName = ds.Tables[0].Rows[0]["LoginName"].ToString();//用户帐号
            com.CompanyName = ds.Tables[0].Rows[0]["CompanyName"].ToString();//企业名称
            com.IndustryID = Convert.ToInt32(ds.Tables[0].Rows[0]["IndustryID"].ToString());//行业ID
            com.IndustryName = ds.Tables[0].Rows[0]["IndustryName"].ToString();//行业名称   
            com.RangeID = Convert.ToInt32(ds.Tables[0].Rows[0]["RangeID"].ToString());//区域ID
            com.RangeName = ds.Tables[0].Rows[0]["RangeName"].ToString();//区域名称
            com.NatureID = Convert.ToInt32(ds.Tables[0].Rows[0]["NatureID"].ToString());//企业性质ID
            com.NatureName = ds.Tables[0].Rows[0]["NatureName"].ToString();//企业性质名称

            com.CreateDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["CreateDate"].ToString());//发布日期
            com.Hit = Convert.ToInt32(ds.Tables[0].Rows[0]["Hit"].ToString());//点击率
            com.Auditingstatus = Convert.ToInt32(ds.Tables[0].Rows[0]["Auditingstatus"].ToString());//审核状态
            com.Htmlfile = ds.Tables[0].Rows[0]["Htmlfile"].ToString();//静态路径
            com.Integrity = Convert.ToInt32(ds.Tables[0].Rows[0]["Integrity"].ToString());//诚信指度
            com.EstablishMent = ds.Tables[0].Rows[0]["EstablishMent"].ToString();//成立日期
            com.Employees = Convert.ToInt64(ds.Tables[0].Rows[0]["Employees"].ToString());//员工人数    
            com.Capital = Convert.ToInt64(ds.Tables[0].Rows[0]["Capital"].ToString());//注册自己
            com.Ismake = Convert.ToInt32(ds.Tables[0].Rows[0]["Ismake"].ToString());//是否推荐  
            com.IsDelete = Convert.ToInt32(ds.Tables[0].Rows[0]["IsDelete"].ToString());//是否删除
            com.Provice = Convert.ToInt32(ds.Tables[0].Rows[0]["Sheng"].ToString());//省份
            com.City = Convert.ToInt32(ds.Tables[0].Rows[0]["City"].ToString());//市区

            com.LinkName = ds.Tables[0].Rows[0]["LinkName"].ToString();//联系人
            com.Email = ds.Tables[0].Rows[0]["Email"].ToString();//电子邮箱
            com.Telphone = ds.Tables[0].Rows[0]["TelPhone"].ToString();//电话号码
            com.Mobile = ds.Tables[0].Rows[0]["Mobile"].ToString();//手机号码
            com.URL = ds.Tables[0].Rows[0]["URL"].ToString();//网址
            com.Address = ds.Tables[0].Rows[0]["Address"].ToString();//联系地址
            com.Logo = ds.Tables[0].Rows[0]["Logo"].ToString();//图片
            com.Introduction = ds.Tables[0].Rows[0]["Introduction"].ToString();//企业介绍
            com.ServiceProce = ds.Tables[0].Rows[0]["ServiceProce"].ToString();//主营介绍
            com.Title = ds.Tables[0].Rows[0]["Title"].ToString();//标题
            com.Keywords = ds.Tables[0].Rows[0]["Keywords"].ToString();//网页关键字
            com.Description = ds.Tables[0].Rows[0]["Description"].ToString();//网页短标题

            return com;
        }

        /// <summary>
        /// 获取省份列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetProvinceList()
        {
            string sql = "select ProvinceID,ProvinceName from SetProvinceTab where ProvinceID!=0000";
            DataSet ds = DbHelperSQL.ExecuteQuery(sql);
            return ds.Tables[0];
        }

        /// <summary>
        /// 获取城市列表
        /// </summary>
        /// <param name="ProvinceID"></param>
        /// <returns></returns>
        public DataTable GetCity(string ProvinceID)
        {
            SqlParameter[] parameters = {
											new SqlParameter("@ProvinceID", SqlDbType.Char,10),
			};
            parameters[0].Value = ProvinceID;
            DataSet ds = DbHelperSQL.RunProcedure("SetCityTab_GetList", parameters, "ds");
            if (ds == null || ds.Tables[0].Rows.Count == 0)
                return null;
            return ds.Tables[0];
        }

        /// <summary>
        /// 查询联系人信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //public string SelLinkName(int id)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    CompanyModel com = new CompanyModel();
        //    com = SelCompany(id);
        //    sb.Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"tab1\">");
        //    sb.Append("<tr><td class=\"col\">企业名称：</td>");
        //    sb.Append("<td colspan=\"3\">" + com.CompanyName + "</td></tr>");
        //    sb.Append("<tr><td width=\"17%\" class=\"col\">联系人：</td><td width=\"30%\">" + com.LinkName + "</td>");
        //    sb.Append("<td width=\"15%\" class=\"col\">联系电话：</td><td>" + com.Telphone + "</td></tr>");
        //    sb.Append("<tr><td class=\"col\">企业网址：</td><td>" + com.URL + "</td>");
        //    sb.Append("<td class=\"col\">  EMail:</td><td>" + com.Email + "</td></tr>");
        //    sb.Append("<tr><td class=\"col\">企业地址：</td>");
        //    sb.Append("<td colspan=\"3\">" + com.Address + "</td></tr>");
        //    sb.Append("</table>");
        //    return sb.ToString();
        //}

        #endregion
        #endregion
    }
}
