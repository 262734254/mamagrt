using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Tz888.DBUtility;
using System.Data;

namespace Tz888.SQLServerDAL.Info
{
    public class SetDefaultValue
    {
        #region-- 添加 -------------------
        /// <summary>
        /// 添加
        /// </summary>
        /// <returns>是否操作成功（true成功，false失败）</returns>
        public long Insert(Tz888.Model.Info.DefaultValueModel model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
											new SqlParameter("@ID",SqlDbType.BigInt),
											new SqlParameter("@InfoTypeID",SqlDbType.Char,10),
											new SqlParameter("@SubTypeID1",SqlDbType.Char,10),
											new SqlParameter("@SubTypeID2",SqlDbType.Char,10),
											new SqlParameter("@Remark",SqlDbType.VarChar, 100)	
										};
            parameters[0].Value = 0;
            parameters[0].Direction = ParameterDirection.InputOutput;

            parameters[1].Value = model.InfoTypeID;
            parameters[2].Value = model.SubTypeID1;
            parameters[3].Value = model.SubTypeID2;
            parameters[4].Value = model.Remark;

            DbHelperSQL.RunProcedure("SetDefaultValueTab_Insert", parameters, out rowsAffected);
            return Convert.ToInt64(parameters[0].Value);
        }
        #endregion

        #region-- 修改 -------------------
        /// <summary>
        /// 修改职务类型类别
        /// </summary>
        /// <returns>是否操作成功（true成功，false失败）</returns>
        public bool Update(Tz888.Model.Info.DefaultValueModel model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {	
											new SqlParameter("@ID",SqlDbType.BigInt),
											new SqlParameter("@InfoTypeID",SqlDbType.Char,10),
											new SqlParameter("@SubTypeID1",SqlDbType.Char,10),
											new SqlParameter("@SubTypeID2",SqlDbType.Char,10),
											new SqlParameter("@Remark",SqlDbType.VarChar, 100)	
										};

            parameters[0].Value = Convert.ToInt64(model.ID);
            parameters[1].Value = model.InfoTypeID;
            parameters[2].Value = model.SubTypeID1;
            parameters[3].Value = model.SubTypeID2;
            parameters[4].Value = model.Remark;


            DbHelperSQL.RunProcedure("SetDefaultValueTab_Update", parameters, out rowsAffected);

            if (rowsAffected > 0)
                return true;
            return false;
        }
        #endregion

        #region-- 删除 -------------------
        /// <summary>
        /// 删除
        /// </summary>		
        /// <returns>是否操作成功（true成功，false失败）</returns>
        public bool Delete(long ID)
        {
            int rowsAffected;
            SqlParameter[] parameters = {	
											new SqlParameter("@ID",SqlDbType.BigInt)	
										};
            parameters[0].Value = ID;

            DbHelperSQL.RunProcedure("SetDefaultValueTab_Delete", parameters, out rowsAffected);

            if (rowsAffected > 0)
                return true;
            return false;
        }
        #endregion

        #region-- 取值 -------------------
        /// <summary>
        /// 取值
        /// </summary>		
        /// <returns>返回Dataview</returns>
        public DataView GetValue(Tz888.Model.Info.DefaultValueModel model)
        {
            SqlParameter[] parameters = {	
											new SqlParameter("@InfoTypeID",SqlDbType.Char,10),
											new SqlParameter("@SubTypeID1",SqlDbType.Char,10),
											new SqlParameter("@SubTypeID2",SqlDbType.Char,10)
										};

            parameters[0].Value = model.InfoTypeID;
            parameters[1].Value = model.SubTypeID1;
            parameters[2].Value = model.SubTypeID2;

            DataSet ds = DbHelperSQL.RunProcedure("SetDefaultValueTab_GetValue", parameters, "ds");

            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables["ds"].DefaultView;
            return null;
        }
        #endregion

        #region-- 查询对应记录 -----------
        /// <summary>
        /// 查询对应记录
        /// </summary>
        /// <param name="Key">关键字</param>		
        /// <returns>是否操作成功（true成功，false失败）</returns>
        public Tz888.Model.Info.DefaultValueModel GetDetail(string Key)
        {
            long PageCount = 0;
            long CurrentPage = 1;

            Tz888.SQLServerDAL.Conn dal = new Conn();

            DataView dv = dal.GetList(
                "SetDefaultValueTabList",
                "*",
                "(ID=" + Key.Trim() + ")",
                "ID ASC",
                ref CurrentPage,
                -1,
                ref PageCount);

            if (dv != null && dv.Count == 1)
            {
                Tz888.Model.Info.DefaultValueModel model = new Tz888.Model.Info.DefaultValueModel();
                model.ID = dv[0]["ID"].ToString().TrimEnd();
                model.InfoTypeID = dv[0]["InfoTypeID"].ToString().TrimEnd();
                model.SubTypeID1 = dv[0]["SubTypeID1"].ToString().TrimEnd();
                model.SubTypeID2 = dv[0]["SubTypeID2"].ToString().TrimEnd();
                model.Remark = dv[0]["Remark"].ToString().TrimEnd();
                return model;
            }
            else
            {
                return null;
            }
        }

        #endregion

        #region-- 查询列表 ---------------
        /// <summary>
        /// 查询列表
        /// </summary>
        /// <param name="SelectCol">选择列</param>		
        /// <param name="Criteria">查询条件</param>
        /// <param name="OrderBy">排序</param>
        /// <param name="CurrentPage">显示的当前页号</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="PageCount">通过该查询条件，返回的查询记录的页数</param>
        /// <returns>查询列表</returns>
        public DataView GetList(
            string SelectCol,
            string Criteria,
            string OrderBy,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount)
        {

            Tz888.SQLServerDAL.Conn dal = new Conn();

            return dal.GetList(
                "SetDefaultValueTabList",
                SelectCol,
                Criteria,
                OrderBy,
                ref CurrentPage,
                PageSize,
                ref PageCount);
        }
        #endregion

        /// <summary>
        /// 复制数据,
        /// </summary>
        /// <param name="sourceID">源ID</param>
        /// <returns></returns>
        public long Clone(long sourceID,Tz888.Model.Info.DefaultValueModel model)
        {
            int rowsAffected;
            SqlParameter[] parameters = new SqlParameter[6];

            parameters[0] = new SqlParameter("@SourceID", SqlDbType.BigInt);
            parameters[0].Value = sourceID;

            parameters[1] = new SqlParameter("@DestID", SqlDbType.BigInt);
            parameters[1].Value = model.ID;
            parameters[1].Direction = ParameterDirection.InputOutput;
            parameters[2] = new SqlParameter("@InfoTypeID", SqlDbType.Char);
            parameters[2].Size = 10;
            parameters[2].Value = model.InfoTypeID;

            parameters[3] = new SqlParameter("@SubTypeID1", SqlDbType.Char);
            parameters[3].Size = 10;
            parameters[3].Value = model.SubTypeID1;

            parameters[4] = new SqlParameter("@SubTypeID2", SqlDbType.Char);
            parameters[4].Size = 10;
            parameters[4].Value = model.SubTypeID2;

            parameters[5] = new SqlParameter("@Remark", SqlDbType.VarChar);
            parameters[5].Size = 100;
            parameters[5].Value = model.Remark;


            DbHelperSQL.RunProcedure("SetDefaultValueTab_Clone", parameters, out rowsAffected);

            return Convert.ToInt64(parameters[1].Value);
        }
    }
}
