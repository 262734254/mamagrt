using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Tz888.DALFactory;
using Tz888.IDAL;
using Tz888.SQLServerDAL.MyHome;
using Tz888.Model.MyHome;
namespace Tz888.BLL.MyHome
{
    public class HomeTypeManager
    {
        HomeTypeService type = new HomeTypeService();
        #region ��ѯ������������
        /// <summary>
        /// ��ѯ������������
        /// </summary>
        /// <returns></returns>
        public IList<MyHomeType> GetHomeTypeList(string LoginName)
        {
            try
            {
                return type.GetHomeTypeList(LoginName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        
        #endregion

        #region �鿴����
        /// <summary>
        /// ����ID�鿴����
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public MyHomeType GetAllTypeById(int Id)
        {
            try
            {
                return type.GetAllTypeById(Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        } 
        #endregion

        #region IHomeType �������

        /// <summary>
        /// �������
        /// </summary>
        /// <param name="cs"></param>
        /// <returns></returns>
        public int InsertHomeType(MyHomeType cs)
        {
            try
            {
                return type.InsertHomeType(cs);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

        }

        #endregion
        #region ��ѯ���
        /// <summary>
        /// ��ѯ���
        /// </summary>
        /// <param name="LoginName"></param>
        /// <returns></returns>
        public List<MyHomeType> SelectHomeType(string LoginName)
        {
            try
            {
                return type.SelectHomeType(LoginName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        } 
        #endregion
        #region ��ѯ���е����ID
        public DataTable GetAlTypeId(string LoginName)
        {
            string sql = "select TID,TypeName,LoginName,LoginID,sort,Datatimes from  HomeType where LoginName='"+ LoginName +" '";
        
            DataTable db = Tz888.DBUtility.DBHelpe.GetDataSet(sql);
            return db;
        

        } 
        #endregion
        #region ����ID�޸ĺ�ɾ����Ϣ
        /// <summary>
        /// ����IDɾ����Ϣ
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int deleteHomeType(int Id)
        {
            try
            {
                return type.deleteHomeType(Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        /// <summary>
        /// ����ID�޸���Ϣ
        /// </summary>
        /// <param name="cs"></param>
        /// <returns></returns>
        public int UpdateHomeType(MyHomeType cs)
        {
            try
            {
                return type.UpdateHomeType(cs);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        #endregion
    }
}
