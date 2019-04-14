using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Tz888.DBUtility;
using System.Data.SqlClient;
using Tz888.IDAL.Info;
namespace Tz888.SQLServerDAL.Info
{
    /// <summary>
    /// 资源联系方式数据库访问逻辑类
    /// </summary>
    public class InfoContactDAL:IInfoContact
    {
        /// <summary>
        /// 获取信息资源的联系方式
        /// </summary>
        /// <param name="InfoID">资源ID</param>
        /// <returns></returns>
        public Tz888.Model.Info.InfoContactModel GetModel(long InfoID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@InfoID", SqlDbType.BigInt,8)
				};
            parameters[0].Value = InfoID;
            Tz888.Model.Info.InfoContactModel model = new Tz888.Model.Info.InfoContactModel();

            DataSet ds = DbHelperSQL.RunProcedure("InfoContactTab_GetModel", parameters, "ds");
            model.InfoID = InfoID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ContactID"].ToString() != "")
                {
                    model.ContactID = Convert.ToInt64(ds.Tables[0].Rows[0]["ContactID"]);
                }
                model.OrganizationName = ds.Tables[0].Rows[0]["OrganizationName"].ToString();
                model.OrgIntro = ds.Tables[0].Rows[0]["OrgIntro"].ToString();
                model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                model.Career = ds.Tables[0].Rows[0]["Career"].ToString();
                model.TelCountryCode = ds.Tables[0].Rows[0]["TelCountryCode"].ToString();
                model.TelStateCode = ds.Tables[0].Rows[0]["TelStateCode"].ToString();
                model.TelNum = ds.Tables[0].Rows[0]["TelNum"].ToString();
                model.FaxCountryCode = ds.Tables[0].Rows[0]["FaxCountryCode"].ToString();
                model.FaxStateCode = ds.Tables[0].Rows[0]["FaxStateCode"].ToString();
                model.FaxNum = ds.Tables[0].Rows[0]["FaxNum"].ToString();
                model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                model.WebSite = ds.Tables[0].Rows[0]["WebSite"].ToString();
                model.Mobile = ds.Tables[0].Rows[0]["Mobile"].ToString();
                model.Address = ds.Tables[0].Rows[0]["address"].ToString();
                model.PostCode = ds.Tables[0].Rows[0]["PostCode"].ToString();
                //2010-06-11新增
                model.Position = ds.Tables[0].Rows[0]["Position"].ToString();
                //end
                if (ds.Tables[0].Rows[0]["IsDel"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["IsDel"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsDel"].ToString().ToLower() == "true"))
                    {
                        model.IsDel = true;
                    }
                    else
                    {
                        model.IsDel = false;
                    }
                }

                model.remark = ds.Tables[0].Rows[0]["remark"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(long ContactID)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ContactID", SqlDbType.BigInt,8)
				};
            parameters[0].Value = ContactID;
            DbHelperSQL.RunProcedure("InfoContactTab_Delete", parameters, out rowsAffected);
            if (rowsAffected > 0)
                return true;
            return false;
        }

        /// <summary>
        /// 删除指定InfoID的联系信息
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        public bool DeleteByInfoID(long InfoID)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ContactID", SqlDbType.BigInt,8)
				};
            parameters[0].Value = InfoID;
            DbHelperSQL.RunProcedure("InfoContactTab_DeleteByInfoID", parameters, out rowsAffected);
            if (rowsAffected > 0)
                return true;
            return false;
        }
        public bool Add(Tz888.Model.Info.InfoContactModel model)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@InfoID", SqlDbType.BigInt,8),
					new SqlParameter("@OrganizationName", SqlDbType.VarChar,100),
					new SqlParameter("@Name", SqlDbType.VarChar,20),
					new SqlParameter("@Career", SqlDbType.VarChar,20),
					new SqlParameter("@TelNum", SqlDbType.VarChar,100),
					new SqlParameter("@Email", SqlDbType.VarChar,50),
					new SqlParameter("@WebSite", SqlDbType.VarChar,200),
					new SqlParameter("@Mobile", SqlDbType.VarChar,30),
					new SqlParameter("@address", SqlDbType.VarChar,100),
                    new SqlParameter("@TelStateCode", SqlDbType.VarChar,10)};
            parameters[0].Value = model.InfoID;
            parameters[1].Value = model.OrganizationName;
            parameters[2].Value = model.Name;
            parameters[3].Value = model.Career;
            parameters[4].Value = model.TelNum;
            parameters[5].Value = model.Email;
            parameters[6].Value = model.WebSite;
            parameters[7].Value = model.Mobile;
            parameters[8].Value = model.Address;
            parameters[9].Value = model.TelStateCode;
            bool b=false;
            b=DbHelperSQL.RunProcLob("InfoContact", parameters);
            return b;

        }


        public bool Update(Tz888.Model.Info.InfoContactModel model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@InfoID", SqlDbType.BigInt,8),
					new SqlParameter("@Name", SqlDbType.VarChar,20),
					new SqlParameter("@Career", SqlDbType.VarChar,20),
					new SqlParameter("@TelCountryCode", SqlDbType.Char,6),
					new SqlParameter("@TelStateCode", SqlDbType.Char,8),
					new SqlParameter("@TelNum", SqlDbType.VarChar,100),
					new SqlParameter("@FaxCountryCode", SqlDbType.Char,6),
					new SqlParameter("@FaxStateCode", SqlDbType.Char,8),
					new SqlParameter("@FaxNum", SqlDbType.VarChar,100),
					new SqlParameter("@Email", SqlDbType.VarChar,50),
					new SqlParameter("@WebSite", SqlDbType.VarChar,200),
					new SqlParameter("@Mobile", SqlDbType.VarChar,30),
					new SqlParameter("@address", SqlDbType.VarChar,100),
					new SqlParameter("@PostCode", SqlDbType.VarChar,10),
					new SqlParameter("@OrganizationName", SqlDbType.VarChar,100),
                    new SqlParameter("@Position",SqlDbType.VarChar,50)
            };
            parameters[0].Value = model.InfoID;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.Career;
            parameters[3].Value = model.TelCountryCode;
            parameters[4].Value = model.TelStateCode;
            parameters[5].Value = model.TelNum;
            parameters[6].Value = model.FaxCountryCode;
            parameters[7].Value = model.FaxStateCode;
            parameters[8].Value = model.FaxNum;
            parameters[9].Value = model.Email;
            parameters[10].Value = model.WebSite;
            parameters[11].Value = model.Mobile;
            parameters[12].Value = model.Address;
            parameters[13].Value = model.PostCode;
            parameters[14].Value = model.OrganizationName;
            parameters[15].Value = model.Position;


            DbHelperSQL.RunProcedure("InfoContactTab_Update", parameters, out rowsAffected);

            if (rowsAffected > 0)
                return true;
            return false;
        }
        public void UpdateUndertaker(long InfoID, string ReceiveOrganization)
        {
            int i = DbHelperSQL.ExecuteSql("update merchantinfotab set ReceiveOrganization='" + ReceiveOrganization + "' where InfoID=" + InfoID);

        }
    }
}
