using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Tz888.Model;
using Tz888.IDAL;
using Tz888.DBUtility;

namespace Tz888.SQLServerDAL
{
    /// <summary>
    /// 名称：推荐信息表
    /// 查询：CommendVIW
    /// 用途：为推荐信息处理提供相应的方法和属性
    /// 设计人：wangwei
    /// 创建日期：2009-06-03
	/// </summary>
    public class CommendDAL : ICommendDAL
    {
        public CommendDAL()
		{
		}

		#region-- 发送 -------------------
		/// <summary>
		/// 发送
		/// </summary>
		/// <returns>是否操作成功（true成功，false失败）</returns>
		public bool Send(Tz888.Model.Commend com)
		{
			bool blRet = false;
			SqlParameter[] parameters = {	new SqlParameter("@InfoID",SqlDbType.BigInt),
											new SqlParameter("@SendBy",SqlDbType.Char,16),
											new SqlParameter("@receivedBy",SqlDbType.Char,16)
										};
            parameters[0].Value = com.InfoID;
			parameters[1].Value = com.SendBy;			
			parameters[2].Value = com.receivedBy;															

			blRet = DbHelperSQL.RunProcLob("CommendTab_Send", parameters);
			return blRet;
		}
		#endregion

		#region-- 删除 -------------------
		/// <summary>
		/// 删除
		/// </summary>
		/// <returns>是否操作成功（true成功，false失败）</returns>
        public bool Update(Tz888.Model.Commend com)
		{
			bool blRet = false;
			SqlParameter[] parameters = {	
											new SqlParameter("@ID",SqlDbType.BigInt),
											new SqlParameter("@LoginName",SqlDbType.Char,16)
										};
            parameters[0].Value = com.ID;
			parameters[1].Value = com.LoginName;												
            blRet = DbHelperSQL.RunProcLob("CommendTab_Delete", parameters);
			return blRet;
		}
		#endregion

		#region-- 查询对应记录 -----------
		/// <summary>
		/// 查询对应记录
		/// </summary>
		/// <param name="Key">关键字</param>		
		/// <returns>是否操作成功（true成功，false失败）</returns>
		public bool GetDetail(string Key)
		{
			long PageCount = 0;
            long CurrentPage = 1;
            Common.CommonFunction comm = new Tz888.SQLServerDAL.Common.CommonFunction();
            DataView dv = comm.GetList("CommendTabList", "ID", "*", "(ID=" + Key.Trim() + ")", "ID Asc", ref CurrentPage, 1, ref PageCount);
			
			if( dv != null && dv.Count == 1 )
			{
				return( true);
			}
			else
			{
				return( false);
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
			ref long PageCount )
        {
            Common.CommonFunction comm = new Tz888.SQLServerDAL.Common.CommonFunction();
            DataView dv = comm.GetList("CommendTabList", "ID", SelectCol, Criteria, OrderBy, ref CurrentPage, PageSize, ref PageCount);
            return dv;
		}
		#endregion

		#region-- 添加 -------------------
		/// <summary>
		/// 添加
		/// </summary>
		/// <returns>是否操作成功（true成功，false失败）</returns>
		public bool Insert(Tz888.Model.Commend commend)
		{
			bool blRet = false;
			SqlParameter[] parameters = {	new SqlParameter("@InfoID",SqlDbType.BigInt),
											new SqlParameter("@IsCollect",SqlDbType.Bit),
											new SqlParameter("@SendBy",SqlDbType.Char,16),
											new SqlParameter("@receivedBy",SqlDbType.Char,16)
										};
			parameters[0].Value = commend.InfoID;
			parameters[1].Value = commend.IsCollect;
			parameters[2].Value = commend.SendBy;		
			parameters[3].Value = commend.receivedBy;

            blRet = DbHelperSQL.RunProcLob("CommendTab_Insert", parameters);
			return blRet;
		}
        #endregion

        #region-- 查询列表 ---------------
        /// <summary>
        /// 查询推荐的次数
        /// </summary>
        /// <param name="SelectCol">选择列</param>		
        /// <param name="Criteria">查询推荐的信息ID号</param>
        /// <param name="OrderBy">排序</param>
        /// <param name="CurrentPage">显示的当前页号</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="PageCount">通过该查询条件，返回的查询记录的页数</param>
        /// <returns>查询列表</returns>
        public int GetListCount(
            string SelectCol,
            string Criteria,
            string OrderBy,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount)
        {
            int count = 0;
            Common.CommonFunction comm = new Tz888.SQLServerDAL.Common.CommonFunction();
            DataTable dt = comm.GetDataTable("CommendTabList", SelectCol, Criteria, OrderBy, ref CurrentPage, PageSize, ref PageCount);
            if (dt != null && dt.Rows != null)
            {
                count = dt.Rows.Count;
            }
            return count;
        }
        #endregion
    }
}
