using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Tz888.IDAL.Common;
using Tz888.DBUtility;

namespace Tz888.SQLServerDAL.Common
{
    public class CommonFunction : ICommonFunction
    {

        /// <summary>
        /// ��ȡȫ������Ϣ�б�
        /// </summary>
        /// <param name="mySql">�������ݿ���</param>
        /// <param name="FNStrName">�����ַ���</param>
        /// <param name="Key">�ؼ���</param>
        /// <param name="SelectStr">ѡ�����ַ���</param>
        /// <param name="Criteria">��ѯ����</param>
        /// <param name="Sort">�����ַ���</param>
        /// <param name="CurrentPage">��ʾ�ĵ�ǰҳ��</param>
        /// <param name="PageSize">ҳ��С</param>
        /// <param name="TotalCount">ͨ���ò�ѯ���������صĲ�ѯ��¼����ҳ��</param>
        /// <returns>���ص�ǰҳ����Ϣ�б�</returns>
        public DataView GetList(
            string FNStrName,
            string Key,
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
											new SqlParameter("@FNName",SqlDbType.VarChar,500),
											new SqlParameter("@Key",SqlDbType.VarChar,50),
											new SqlParameter("@SelectStr",SqlDbType.VarChar,500),
											new SqlParameter("@Criteria",SqlDbType.VarChar,8000),
											new SqlParameter("@Sort",SqlDbType.VarChar,255),
											new SqlParameter("@Page",SqlDbType.BigInt),
											new SqlParameter("@CurrentPageRow",SqlDbType.BigInt),
											new SqlParameter("@TotalCount",SqlDbType.BigInt)
										};

            parameters[0].Value = FNStrName;
            parameters[1].Value = Key;
            parameters[2].Value = SelectStr;
            parameters[3].Value = Criteria;
            parameters[4].Value = Sort;

            parameters[5].Direction = ParameterDirection.InputOutput;
            parameters[5].Value = CurrentPage;

            parameters[6].Value = PageSize;

            parameters[7].Direction = ParameterDirection.InputOutput;
            parameters[7].Value = 1;

            try
            {

                DataTable dt = DbHelperSQL.RunProcedure("GetFNDataList", parameters, "tGetList").Tables[0];

                if (dt != null)
                {
                    dv = dt.DefaultView;
                    if (PageSize > 0)
                    {
                        TotalCount = Convert.ToInt64(parameters[7].Value);
                        CurrentPage = Convert.ToInt64(parameters[5].Value);
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
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {

            }

            return dv;
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
        public DataView GetListSet(
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
            parameters[5].Value = 0;

            try
            {
                DataTable dt = DbHelperSQL.RunProcedure(SPName, parameters, "tbGetList").Tables[0];

                if (dt != null)
                {
                    dv = dt.DefaultView;
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
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {

            }

            return dv;
        }



        /// 
        /// <summary>
        /// ��ȡ�����ö����Ĳ�ѯ����б�
        /// </summary>
        /// <param name="SPName"></param>
        /// <param name="SelectStr"></param>
        /// <param name="Criteria"></param>
        /// <param name="Sort"></param>
        /// <param name="CurrentPage"></param>
        /// <param name="PageSize"></param>
        /// <param name="FristTopNum"></param>
        /// <param name="TotalCount"></param>
        /// <returns></returns>

        public DataView GetListSetForFirstTopNum(
        string SPName,
        string SelectStr,
        string Criteria,
        string Sort,
        ref long CurrentPage,
        long PageSize,
        int FristTopNum,
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
                                            new SqlParameter("@FristTopNum",SqlDbType.BigInt),
											new SqlParameter("@TotalCount",SqlDbType.BigInt),
			};

            parameters[0].Value = SelectStr;
            parameters[1].Value = Criteria;
            parameters[2].Value = Sort;

            parameters[3].Direction = ParameterDirection.InputOutput;
            parameters[3].Value = CurrentPage;

            parameters[4].Value = PageSize;

            parameters[5].Value = FristTopNum;

            parameters[6].Direction = ParameterDirection.InputOutput;
            parameters[6].Value = 0;

            try
            {
                DataTable dt = DbHelperSQL.RunProcedure(SPName, parameters, "tbGetList").Tables[0];

                if (dt != null)
                {
                    dv = dt.DefaultView;
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
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {

            }

            return dv;
        }

     

        /// 
        /// <summary>
        /// ��ȡ�����ö���DataSet���͵Ĳ�ѯ����б�
        /// </summary>
        /// <param name="SPName"></param>
        /// <param name="SelectStr"></param>
        /// <param name="Criteria"></param>
        /// <param name="Sort"></param>
        /// <param name="CurrentPage"></param>
        /// <param name="PageSize"></param>
        /// <param name="FristTopNum"></param>
        /// <param name="TotalCount"></param>
        /// <returns></returns>

        public DataSet dsGetTopFirstNumContactBySP(
        string SPName,
       string InfoID
        )
        {
            DataSet ds = new DataSet();
           

            SqlParameter[] parameters = {	
											new SqlParameter("@InfoID",SqlDbType.VarChar,500),											
			};

            parameters[0].Value = InfoID;
            

            try
            {
                ds = DbHelperSQL.RunProcedure(SPName, parameters, "ds");
 
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


        /// 
        /// <summary>
        /// ��ȡ�����ö���DataSet���͵Ĳ�ѯ����б�
        /// </summary>
        /// <param name="SPName"></param>
        /// <param name="SelectStr"></param>
        /// <param name="Criteria"></param>
        /// <param name="Sort"></param>
        /// <param name="CurrentPage"></param>
        /// <param name="PageSize"></param>
        /// <param name="FristTopNum"></param>
        /// <param name="TotalCount"></param>
        /// <returns></returns>

        public DataSet dsGetListSetForFirstTopNum(
        string SPName,
        string SelectStr,
        string Criteria,
        string Sort,
        ref long CurrentPage,
        long PageSize,
        int FristTopNum,
        ref long TotalCount
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
                                            new SqlParameter("@FristTopNum",SqlDbType.BigInt),
											new SqlParameter("@TotalCount",SqlDbType.BigInt),
			};

            parameters[0].Value = SelectStr;
            parameters[1].Value = Criteria;
            parameters[2].Value = Sort;

            parameters[3].Direction = ParameterDirection.InputOutput;
            parameters[3].Value = CurrentPage;

            parameters[4].Value = PageSize;

            parameters[5].Value = FristTopNum;

            parameters[6].Direction = ParameterDirection.InputOutput;
            parameters[6].Value = 0;

            try
            {
                ds = DbHelperSQL.RunProcedure(SPName, parameters, "ds");

                if (ds != null)
                {
                    DataView dv = new DataView();

                    //dv = dt.DefaultView;
                    dv = ds.Tables[0].DefaultView;
                    if (PageSize > 0)
                    {
                        TotalCount = Convert.ToInt64(parameters[6].Value);
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
        public DataTable GetDataTable(
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
            DataTable dtGet = null;
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
            parameters[5].Value = 0;

            try
            {
                dtGet = DbHelperSQL.RunProcedure(SPName, parameters, "tbGetDT").Tables[0];

                if (dtGet != null)
                {
                    dv = dtGet.DefaultView;
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
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {

            }

            return dtGet;
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
        public DataTable GetDTFromTableOrView(string TableViewName, string Key, string SelectStr, string Criteria, string Sort,
            ref long CurrentPage, long PageSize, ref long TotalCount)
        {
            DataTable dt = null;
            SqlParameter[] parameters = {	
											new SqlParameter("@TableViewName",SqlDbType.VarChar,50),
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

            try
            {
                dt = DbHelperSQL.RunProcedure("GetDataList", parameters, "ds").Tables[0];
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
            }
            catch (Exception err)
            {
                throw err;
            } 
            return dt;
        }

        /// <summary>
        /// ��Ѷ��Ϣ
        /// </summary>
        /// <param name="SPName"></param>
        /// <param name="SelectStr"></param>
        /// <param name="Criteria"></param>
        /// <param name="Sort"></param>
        /// <param name="Page"></param>
        /// <param name="CurrentPageRow"></param>
        /// <param name="TotalCount"></param>
        /// <returns></returns>
        public DataSet dsGetListNewsTopNums(
                                  string SPName,
                                    string SelectStr,
                                 string Criteria,
                                 string Sort,
                                 long PageSize,
                                 long CurrentPageRow,
                                 ref long TotalCount
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
            parameters[3].Value = PageSize;
            parameters[4].Value = CurrentPageRow;

            parameters[5].Value = TotalCount;
            parameters[5].Direction = ParameterDirection.InputOutput; 

            try
            {
                ds = DbHelperSQL.RunProcedure(SPName, parameters, "ds");

                if (ds != null)
                {
                    DataView dv = new DataView();

                    //dv = dt.DefaultView;
                    dv = ds.Tables[0].DefaultView;
                    int count = ds.Tables[0].Rows.Count;
                    if (PageSize > 0)
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

    }
}
