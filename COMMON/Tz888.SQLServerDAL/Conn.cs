using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tz888.IDAL;
using Tz888.DBUtility;
namespace Tz888.SQLServerDAL
{
    public class Conn : IConn
    {
        /// <summary>
        /// ͨ�ò�ѯ�б�
        /// </summary>
        /// <param name="tblName">��������ͼ��</param>
        /// <param name="strGetFields">��Ҫ���ص���,*Ϊȫ����</param>
        /// <param name="fldName">�����ֶ�</param>
        /// <param name="PageSize">ҳ����</param>
        /// <param name="PageIndex">ҳ��</param>
        /// <param name="doCount">�ؼ�¼��������0ֵ�򷵣�0�򷵻ز�ѯ�ļ�¼</param>
        /// <param name="OrderType">��������ʽ����0ֵ�����У�0Ϊ������</param>
        /// <param name="strWhere">��ѯ����������Ҫ��where</param>
        /// <returns>DataTable</returns>
        public DataTable GetList(string tblName, string strGetFields, string fldName, int PageSize, int PageIndex, int doCount,
            int OrderType, string strWhere)
        {
            DataSet ds = null;
            SqlParameter[] Parameters = new SqlParameter[]{
															 new  SqlParameter("@tblName",SqlDbType.VarChar,255),
															 new  SqlParameter("@strGetFields",SqlDbType.VarChar,1000),
															 new  SqlParameter("@fldName",SqlDbType.VarChar,255),
															 new  SqlParameter("@PageSize",SqlDbType.Int,4),
															 new  SqlParameter("@PageIndex",SqlDbType.Int,4),
															 new  SqlParameter("@doCount",SqlDbType.Bit),
															 new  SqlParameter("@OrderType",SqlDbType.Bit),
															 new  SqlParameter("@strWhere",SqlDbType.VarChar,1500)
														 };
            Parameters[0].Value = tblName;
            Parameters[1].Value = strGetFields;
            Parameters[2].Value = fldName;
            Parameters[3].Value = PageSize;
            Parameters[4].Value = PageIndex;
            Parameters[5].Value = doCount;
            Parameters[6].Value = OrderType;
            Parameters[7].Value = strWhere;

            try
            {
                ds = DbHelperSQL.RunProcedure("Sp_Conn_Sort", Parameters, "ds");
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {
            }
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null)
            {
                return ds.Tables[0];
            }
            else
            {
                return new DataTable();
            }
        }

        /// <summary>
        /// ͨ�ò�ѯ�б�
        /// </summary>
        /// <param name="TableName">��������ͼ��</param>
        /// <param name="FileName">��Ҫ���ص���,*Ϊȫ����</param>        
        /// <param name="Where">��ѯ��������Ҫ��where</param>
        /// <returns>DataTable</returns>
        public DataTable GetList(string FileName, string TableName, string Where)
        {
            DataSet ds = null;
            SqlParameter[] parameters = {
                new SqlParameter("@tableName", SqlDbType.VarChar,300),
                new SqlParameter("@fieldName", SqlDbType.VarChar,1000),
                new SqlParameter("@where", SqlDbType.VarChar,500),
            };
            parameters[0].Value = TableName;
            parameters[1].Value = FileName;
            parameters[2].Value = Where;
            
            try
            {
                ds = DbHelperSQL.RunProcedure("Conn", parameters, "ds");
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {
            }
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null)
            {
                return ds.Tables[0];
            }
            else
            {
                return new DataTable();
            }
        }
        /// <summary>
        /// ͳ�Ƽ�¼����
        /// </summary>
        /// <param name="tblName">���ݱ����ͼ��</param>
        /// <param name="fldName">��������</param>
        /// <param name="strWhere">ͳ������</param>
        /// <returns>ͳ�Ƽ�¼����</returns>
        public int GetCount(string tblName, string fldName, string strWhere)
        {
            SqlParameter[] Parameters = new SqlParameter[]{
															 new  SqlParameter("@tblName",SqlDbType.VarChar,255),
															 new  SqlParameter("@strGetFields",SqlDbType.VarChar,1000),
															 new  SqlParameter("@fldName",SqlDbType.VarChar,255),
															 new  SqlParameter("@PageSize",SqlDbType.Int,4),
															 new  SqlParameter("@PageIndex",SqlDbType.Int,4),
															 new  SqlParameter("@doCount",SqlDbType.Bit),
															 new  SqlParameter("@OrderType",SqlDbType.Bit),
															 new  SqlParameter("@strWhere",SqlDbType.VarChar,1500)
														 };
            Parameters[0].Value = tblName;
            Parameters[1].Value = fldName;
            Parameters[2].Value = fldName;
            Parameters[3].Value = 1;
            Parameters[4].Value = 1;
            Parameters[5].Value = 1;
            Parameters[6].Value = 0;
            Parameters[7].Value = strWhere;

            DataSet ds = DbHelperSQL.RunProcedure("Sp_Conn_Sort", Parameters, "ds");

            return Convert.ToInt32(ds.Tables[0].Rows[0][0]);
        }

        /// <summary>
        /// ͳ�Ƽ�¼����
        /// </summary>
        /// <param name="tblName">���ݱ����ͼ��</param>
        /// <param name="fldName">��������</param>
        /// <param name="strWhere">ͳ������</param>
        /// <returns>ͳ�Ƽ�¼����</returns>
        public int GetCountFN(string tblName, string fldName, string strWhere)
        {
            SqlParameter[] Parameters = new SqlParameter[]{
															 new  SqlParameter("@tblName",SqlDbType.VarChar,255),
															 new  SqlParameter("@strGetFields",SqlDbType.VarChar,1000),
															 new  SqlParameter("@fldName",SqlDbType.VarChar,255),
															 new  SqlParameter("@PageSize",SqlDbType.Int,4),
															 new  SqlParameter("@PageIndex",SqlDbType.Int,4),
															 new  SqlParameter("@doCount",SqlDbType.Bit),
															 new  SqlParameter("@OrderType",SqlDbType.Bit),
															 new  SqlParameter("@strWhere",SqlDbType.VarChar,1500)
														 };
            Parameters[0].Value = tblName;
            Parameters[1].Value = fldName;
            Parameters[2].Value = fldName;
            Parameters[3].Value = 1;
            Parameters[4].Value = 1;
            Parameters[5].Value = 1;
            Parameters[6].Value = 0;
            Parameters[7].Value = strWhere;

            DataSet ds = DbHelperSQL.RunProcedure("Sp_Conn_Sort_FN", Parameters, "ds");

            return Convert.ToInt32(ds.Tables[0].Rows[0][0]);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="TableViewName">����</param>
        /// <param name="Key">����</param>
        /// <param name="SelectStr">��ѯ�ֶ�</param>
        /// <param name="Criteria">����</param>
        /// <param name="Sort">�����ֶ�</param>
        /// <param name="CurrentPage">��ǰҳ</param>
        /// <param name="PageSize">ҳ��С</param>
        /// <param name="TotalCount">�ܼ�¼</param>
        /// <returns></returns>
        public DataTable GetListFN(string TableViewName, string Key, string SelectStr, string Criteria, string Sort,
            ref long CurrentPage, long PageSize, ref long TotalCount)
        {
            DataTable dt = null;
            SqlParameter[] parameters = {	
											new SqlParameter("@TableViewName",SqlDbType.VarChar,255),
											new SqlParameter("@Key",SqlDbType.VarChar,50),
											new SqlParameter("@SelectStr",SqlDbType.VarChar,500),
											new SqlParameter("@Criteria",SqlDbType.VarChar,8000),
											new SqlParameter("@Sort",SqlDbType.VarChar,255),
											new SqlParameter("@Page",SqlDbType.BigInt),
											new SqlParameter("@CurrentPageRow",SqlDbType.BigInt),
											new SqlParameter("@TotalCount",SqlDbType.BigInt)
										};

            parameters[0].Value = TableViewName;
            parameters[1].Value = Key;
            parameters[2].Value = SelectStr;
            parameters[3].Value = Criteria;
            parameters[4].Value = Sort;
            parameters[5].Direction = ParameterDirection.InputOutput;
            parameters[5].Value = CurrentPage;
            parameters[6].Value = PageSize;
            parameters[7].Direction = ParameterDirection.InputOutput;
            parameters[7].Value = 1;

            DataSet ds = DbHelperSQL.RunProcedure("GetDataList_FN", parameters, "ds");

            if (ds == null)
                return null;
            dt = ds.Tables[0];
            if (dt != null)
            {
                if (PageSize > 0)
                {
                    TotalCount = Convert.ToInt64(parameters[7].Value);
                    CurrentPage = Convert.ToInt64(parameters[5].Value);
                }
                else
                {
                    TotalCount = Convert.ToInt64(dt.Rows.Count);
                    if (TotalCount > 0)
                    {
                        CurrentPage = 1;
                    }
                    else
                    {
                        CurrentPage = 0;
                    }
                }
            }
            return dt;
        }
        /// <summary>
        /// ͨ��ɾ��
        /// </summary>
        /// <param name="tblName">����</param>
        /// <param name="where ">where</param>
        public bool  Delect(string tblName, string where )
        {

            SqlParameter[] Parameters = new SqlParameter[]{
															 new  SqlParameter("@tblName",SqlDbType.VarChar,255),
															 new  SqlParameter("@where",SqlDbType.VarChar,500),
        };
            Parameters[0].Value = tblName;
            Parameters[1].Value = where;
            return DbHelperSQL.RunProcLob("DelectCommon",Parameters);


        }



        /// <summary>
        /// ȡ����չ������
        /// </summary>
        /// <param name="tblName"></param>
        /// <param name="strGetFields"></param>
        /// <param name="fldName"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="doCount"></param>
        /// <param name="OrderType"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetWebSiteList(string tblName, string strGetFields, string fldName, int PageSize, int PageIndex, int doCount,
            int OrderType, string strWhere)
        {
            DataSet ds = null;
            SqlParameter[] Parameters = new SqlParameter[]{
															 new  SqlParameter("@tblName",SqlDbType.VarChar,255),
															 new  SqlParameter("@strGetFields",SqlDbType.VarChar,1000),
															 new  SqlParameter("@fldName",SqlDbType.VarChar,255),
															 new  SqlParameter("@PageSize",SqlDbType.Int,4),
															 new  SqlParameter("@PageIndex",SqlDbType.Int,4),
															 new  SqlParameter("@doCount",SqlDbType.Bit),
															 new  SqlParameter("@OrderType",SqlDbType.Bit),
															 new  SqlParameter("@strWhere",SqlDbType.VarChar,1500)
														 };
            Parameters[0].Value = tblName;
            Parameters[1].Value = strGetFields;
            Parameters[2].Value = fldName;
            Parameters[3].Value = PageSize;
            Parameters[4].Value = PageIndex;
            Parameters[5].Value = doCount;
            Parameters[6].Value = OrderType;
            Parameters[7].Value = strWhere;

            ds = DbHelperSQL.GetWebSiteList("Sp_Conn_Sort", Parameters, "ds");
            if(ds != null && ds.Tables.Count != 0)
                return ds.Tables[0];
            return null;
        }
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="TableViewName">����</param>
        /// <param name="Key">����</param>
        /// <param name="SelectStr">��ѯ�ֶ�</param>
        /// <param name="Criteria">����</param>
        /// <param name="Sort">�����ֶ�</param>
        /// <param name="CurrentPage">��ǰҳ</param>
        /// <param name="PageSize">ҳ��С</param>
        /// <param name="TotalCount">�ܼ�¼</param>
        /// <returns></returns>
        public DataTable GetList(string TableViewName, string Key,string SelectStr,string Criteria,string Sort,
            ref long CurrentPage, long PageSize,ref long TotalCount)
        {
            DataTable dt = null;
            SqlParameter[] parameters = {	
											new SqlParameter("@TableViewName",SqlDbType.VarChar,255),
											new SqlParameter("@Key",SqlDbType.VarChar,50),
											new SqlParameter("@SelectStr",SqlDbType.VarChar,500),
											new SqlParameter("@Criteria",SqlDbType.VarChar,8000),
											new SqlParameter("@Sort",SqlDbType.VarChar,255),
											new SqlParameter("@Page",SqlDbType.BigInt),
											new SqlParameter("@CurrentPageRow",SqlDbType.BigInt),
											new SqlParameter("@TotalCount",SqlDbType.BigInt)
										};

            parameters[0].Value = TableViewName;
            parameters[1].Value = Key;
            parameters[2].Value = SelectStr;
            parameters[3].Value = Criteria;
            parameters[4].Value = Sort;
            parameters[5].Direction = ParameterDirection.InputOutput;
            parameters[5].Value = CurrentPage;
            parameters[6].Value = PageSize;
            parameters[7].Direction = ParameterDirection.InputOutput;
            //parameters[7].Value = 1;

            DataSet ds = DbHelperSQL.RunProcedure("GetDataList", parameters, "ds");

            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0] == null)
            {
                return null;
            }
            dt = ds.Tables[0];
            if (dt != null)
            {
                if (PageSize > 0)
                {
                    TotalCount = Convert.ToInt64(parameters[7].Value);
                    CurrentPage = Convert.ToInt64(parameters[5].Value);
                }
                else
                {
                    TotalCount = Convert.ToInt64(dt.Rows.Count);
                    if (TotalCount > 0)
                    {
                        CurrentPage = 1;
                    }
                    else
                    {
                        CurrentPage = 0;
                    }
                }
            }
            return dt;
        }
        public bool Update(int psid, int IsChekUp)
        {

            SqlParameter[] parameters = {
					new SqlParameter("@Psid", SqlDbType.Int),
					new SqlParameter("@IsChekUp", SqlDbType.Int),
					};
            parameters[0].Value = psid;
            parameters[1].Value = IsChekUp;
            return DbHelperSQL.RunProcLob("RCUpdate", parameters);


        }

        /// <summary>
        /// ��ȡȫ������Ϣ�б�
        /// </summary>
        /// <param name="SPName">�洢���̵�����</param>
        /// <param name="SelectStr">ѡ�����ַ���</param>
        /// <param name="Criteria">��ѯ����</param>
        /// <param name="Sort">�����ַ���</param>
        /// <param name="CurrentPage">��ʾ�ĵ�ǰҳ��</param>
        /// <param name="PageSize">ҳ��С</param>
        /// <param name="TotalCount">ͨ���ò�ѯ���������صĲ�ѯ��¼����ҳ��</param>
        /// <returns>���ص�ǰҳ����Ϣ�б�</returns>
        public DataView GetList(
            string SPName,
            string SelectStr,
            string Criteria,
            string Sort,
            ref long CurrentPage,
            long PageSize,
            ref long TotalCount
            )
        {
            DataView dv = null;
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

            parameters[3].Direction = ParameterDirection.InputOutput;
            parameters[3].Value = CurrentPage;

            parameters[4].Value = PageSize;

            parameters[5].Direction = ParameterDirection.InputOutput;
            parameters[5].Value = 1;

            DataSet ds = DbHelperSQL.RunProcedure(SPName, parameters, "ds");

            if (ds != null && ds.Tables.Count>0)
            {
                dv = ds.Tables["ds"].DefaultView;
                if (PageSize > 0)
                {
                    TotalCount = Convert.ToInt64(parameters[5].Value);
                    CurrentPage = Convert.ToInt64(parameters[3].Value);
                }
                else
                {
                    TotalCount = dv.Count;
                    if (TotalCount > 0)
                    {
                        CurrentPage = 1;
                    }
                    else
                    {
                        CurrentPage = 0;
                    }
                }
            }
            return dv;
        }
    }
}
