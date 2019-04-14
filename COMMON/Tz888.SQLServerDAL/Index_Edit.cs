using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tz888.IDAL;
using Tz888.DBUtility;//请先添加引用;
namespace Tz888.SQLServerDAL
{
    /// <summary>
    /// 数据访问类tzIndex_Edit 。
    /// </summary>
    public class Index_Edit : IIndex_Edit
    {
        public Index_Edit()
        { }
        /// <summary>
        ///  增加一条数据
        /// </summary>
        public int Add(Tz888.Model.Index_Edit model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
                    new SqlParameter("@flag", SqlDbType.VarChar,50),
					new SqlParameter("@Title", SqlDbType.VarChar,50),
					new SqlParameter("@TitleUrl", SqlDbType.VarChar,100),
					new SqlParameter("@TitleColor", SqlDbType.VarChar,20),
					new SqlParameter("@Pic", SqlDbType.VarChar,50),
					new SqlParameter("@InfoType", SqlDbType.Int,4),
                    new SqlParameter("@IndexNo", SqlDbType.Int,4),
                    new SqlParameter("@ListType", SqlDbType.Int,4),
					};
            parameters[0].Value = "strInsert";
            parameters[1].Value = model.Title;
            parameters[2].Value = model.TitleUrl;
            parameters[3].Value = model.TitleColor;
            parameters[4].Value = model.Pic;
            parameters[5].Value = model.InfoType;
            parameters[6].Value = model.IndexNo;
            parameters[7].Value = model.ListType;
            int i = DbHelperSQL.RunProcedure("Index_Edit_Sp", parameters, out rowsAffected);
            return i;
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public int Update(Tz888.Model.Index_Edit model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.VarChar,50),
					new SqlParameter("@TitleUrl", SqlDbType.VarChar,100),
					new SqlParameter("@TitleColor", SqlDbType.VarChar,20),
					new SqlParameter("@Pic", SqlDbType.VarChar,50),
					new SqlParameter("@InfoType", SqlDbType.Int,4),
					new SqlParameter("@AddDate", SqlDbType.DateTime),
                    new SqlParameter("@flag", SqlDbType.VarChar)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.TitleUrl;
            parameters[3].Value = model.TitleColor;
            parameters[4].Value = model.Pic;
            parameters[5].Value = model.InfoType;
            parameters[6].Value = model.AddDate;
            parameters[7].Value = "strUpdate";

            int i = DbHelperSQL.RunProcedure("Index_Edit_Sp", parameters, out rowsAffected);
            return i;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int ID)
        {

            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
				    new SqlParameter("@flag", SqlDbType.VarChar)};
            parameters[0].Value = ID;
            parameters[1].Value = "strDelete";
            int i = DbHelperSQL.RunProcedure("Index_Edit_Sp", parameters, out rowsAffected);
            return i;
        }
    }
}

