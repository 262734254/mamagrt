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
        #region-- ��� -------------------
        /// <summary>
        /// ���
        /// </summary>
        /// <returns>�Ƿ�����ɹ���true�ɹ���falseʧ�ܣ�</returns>
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

        #region-- �޸� -------------------
        /// <summary>
        /// �޸�ְ���������
        /// </summary>
        /// <returns>�Ƿ�����ɹ���true�ɹ���falseʧ�ܣ�</returns>
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

        #region-- ɾ�� -------------------
        /// <summary>
        /// ɾ��
        /// </summary>		
        /// <returns>�Ƿ�����ɹ���true�ɹ���falseʧ�ܣ�</returns>
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

        #region-- ȡֵ -------------------
        /// <summary>
        /// ȡֵ
        /// </summary>		
        /// <returns>����Dataview</returns>
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

        #region-- ��ѯ��Ӧ��¼ -----------
        /// <summary>
        /// ��ѯ��Ӧ��¼
        /// </summary>
        /// <param name="Key">�ؼ���</param>		
        /// <returns>�Ƿ�����ɹ���true�ɹ���falseʧ�ܣ�</returns>
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
        /// ��������,
        /// </summary>
        /// <param name="sourceID">ԴID</param>
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
