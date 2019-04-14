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
    /// ���ƣ��Ƽ���Ϣ��
    /// ��ѯ��CommendVIW
    /// ��;��Ϊ�Ƽ���Ϣ�����ṩ��Ӧ�ķ���������
    /// ����ˣ�wangwei
    /// �������ڣ�2009-06-03
	/// </summary>
    public class CommendDAL : ICommendDAL
    {
        public CommendDAL()
		{
		}

		#region-- ���� -------------------
		/// <summary>
		/// ����
		/// </summary>
		/// <returns>�Ƿ�����ɹ���true�ɹ���falseʧ�ܣ�</returns>
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

		#region-- ɾ�� -------------------
		/// <summary>
		/// ɾ��
		/// </summary>
		/// <returns>�Ƿ�����ɹ���true�ɹ���falseʧ�ܣ�</returns>
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

		#region-- ��ѯ��Ӧ��¼ -----------
		/// <summary>
		/// ��ѯ��Ӧ��¼
		/// </summary>
		/// <param name="Key">�ؼ���</param>		
		/// <returns>�Ƿ�����ɹ���true�ɹ���falseʧ�ܣ�</returns>
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

		#region-- ��ѯ�б� ---------------
		/// <summary>
		/// ��ѯ�б�
		/// </summary>
		/// <param name="SelectCol">ѡ����</param>		
		/// <param name="Criteria">��ѯ����</param>
		/// <param name="OrderBy">����</param>
		/// <param name="CurrentPage">��ʾ�ĵ�ǰҳ��</param>
		/// <param name="PageSize">ҳ��С</param>
		/// <param name="PageCount">ͨ���ò�ѯ���������صĲ�ѯ��¼��ҳ��</param>
		/// <returns>��ѯ�б�</returns>
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

		#region-- ��� -------------------
		/// <summary>
		/// ���
		/// </summary>
		/// <returns>�Ƿ�����ɹ���true�ɹ���falseʧ�ܣ�</returns>
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

        #region-- ��ѯ�б� ---------------
        /// <summary>
        /// ��ѯ�Ƽ��Ĵ���
        /// </summary>
        /// <param name="SelectCol">ѡ����</param>		
        /// <param name="Criteria">��ѯ�Ƽ�����ϢID��</param>
        /// <param name="OrderBy">����</param>
        /// <param name="CurrentPage">��ʾ�ĵ�ǰҳ��</param>
        /// <param name="PageSize">ҳ��С</param>
        /// <param name="PageCount">ͨ���ò�ѯ���������صĲ�ѯ��¼��ҳ��</param>
        /// <returns>��ѯ�б�</returns>
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
