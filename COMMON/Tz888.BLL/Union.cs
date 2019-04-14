using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace Tz888.BLL
{
  public   class Union
    {
        /// <summary>
        /// ͨ�ò�ѯ�б�
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
        public DataTable GetList(string TableViewName, string Key, string SelectStr, string Criteria, string Sort,
        ref long CurrentPage, long PageSize, ref long TotalCount)
        {
            Tz888.SQLServerDAL.Union dal = new Tz888.SQLServerDAL.Union();
            return dal.GetList(TableViewName, Key, SelectStr, Criteria, Sort, ref  CurrentPage, PageSize, ref  TotalCount);
        }

        /// <summary>
        ///��ȡ������Ϣ /���󣬻������˲� �Ӹ��� ��ѯ����  ����Ҫ��ѯ����
        /// </summary>
        /// <returns></returns>
        /// <summary>
        public DataTable GetList(string FileName, string TableName, string Where, int Top)
        {
            Tz888.SQLServerDAL.Union dal = new  Tz888.SQLServerDAL.Union();
            return dal.GetList(FileName, TableName, Where, Top);
        }
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public bool Delete(string table,string where)
        {
            Tz888.SQLServerDAL.Union dal = new Tz888.SQLServerDAL.Union();
            return dal.Delete(table ,where);
        }

        /// <summary>
        /// ����һ����������
        /// </summary>
        /// <returns></returns>
        public string GetServiesBNameByID(int ServiesBID)
        {
            string str = "";
            if (ServiesBID != 0)
            {
                Tz888.SQLServerDAL.Union dal = new Tz888.SQLServerDAL.Union();
                DataTable dt = dal.GetList("ServiesBName", "setServiesBigTab", "where ServiesBID=" + ServiesBID, 1);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        str = dt.Rows[0]["ServiesBName"].ToString();
                    }
                }


            }
            return str;
        }

        /// <summary>
        /// ���������������
        /// </summary>
        /// <returns></returns>
        public string GetServiesMNameByID(int ServiesMID)
        {
            Tz888.SQLServerDAL.Union dal = new Tz888.SQLServerDAL.Union();
            DataTable dt = dal.GetList("ServiesMName", "setServiesSmallTab",  "where ServiesMID=" + ServiesMID,1);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["ServiesMName"].ToString();
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// ����С��IDȡ�ô���Name
        /// </summary>
        /// <param name="MID"></param>
        /// <returns></returns>
        public string GetBNameByMID(int MID)
        {
            Tz888.SQLServerDAL.Union dal = new Tz888.SQLServerDAL.Union();
            DataTable dt = dal.GetList("ServiesbName", "setServiesbigtab",  "where ServiesBID=(select ServiesBID from setServiessmalltab where ServiesMID=" + MID + ")",1);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["ServiesbName"].ToString();
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// ������������б�
        /// </summary>
        /// <param name="isShow">isShowΪtrue ��ʾ��isshow=1��,������ʾ������</param>
        /// <returns></returns>
        public DataView GetServiesList(int ServiesBID, bool isShow)
        {
            Tz888.SQLServerDAL.Union dal = new Tz888.SQLServerDAL.Union();
            return dal.GetServiesList(ServiesBID, isShow);
        }

        /// <summary>
        /// ����һ�������б�
        /// </summary>
        /// <param name="isShow">isShowΪtrue ��ʾ��isshow=1��,������ʾ������</param>
        /// <returns></returns>
        public DataView GetServiesList(bool isShow)
        {
            Tz888.SQLServerDAL.Union dal = new Tz888.SQLServerDAL.Union();
            return dal.GetServiesList(isShow);
        }
    }
}
