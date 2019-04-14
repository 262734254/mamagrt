using System;
using System.Collections.Generic;
using System.Text;
using Tz888.IDAL.Info;
using Tz888.DALFactory;
using System.Data;

namespace Tz888.BLL.Info
{
    public class SetDefaultValue
    {

        private readonly ISetDefaultValue dal = DataAccess.CreateSetDefaultValue();

        #region-- ��� -------------------
        /// <summary>
        /// ���
        /// </summary>
        /// <returns>�Ƿ�����ɹ���true�ɹ���falseʧ�ܣ�</returns>
        public long Insert(Tz888.Model.Info.DefaultValueModel model)
        {
            return dal.Insert(model);
        }
        #endregion

        #region-- �޸� -------------------
        /// <summary>
        /// �޸�ְ���������
        /// </summary>
        /// <returns>�Ƿ�����ɹ���true�ɹ���falseʧ�ܣ�</returns>
        public bool Update(Tz888.Model.Info.DefaultValueModel model)
        {
            return dal.Update(model);
        }
        #endregion

        #region-- ɾ�� -------------------
        /// <summary>
        /// ɾ��
        /// </summary>		
        /// <returns>�Ƿ�����ɹ���true�ɹ���falseʧ�ܣ�</returns>
        public bool Delete(long ID)
        {
            return dal.Delete(ID);
        }
        #endregion

        #region-- ȡֵ -------------------
        /// <summary>
        /// ȡֵ
        /// </summary>		
        /// <returns>����Dataview</returns>
        public DataView GetValue(Tz888.Model.Info.DefaultValueModel model)
        {
            return dal.GetValue(model);
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
            return dal.GetDetail(Key);
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

            return dal.GetList(SelectCol, Criteria, OrderBy, ref CurrentPage, PageSize, ref PageCount);
        }
        #endregion

        /// <summary>
        /// ��������,
        /// </summary>
        /// <param name="sourceID">ԴID</param>
        /// <returns></returns>
        public long Clone(long sourceID, Tz888.Model.Info.DefaultValueModel model)
        {
            return dal.Clone(sourceID, model);
        }


        /// <summary>
        /// ȡ��ĳ����Ϣ����صĵĲ��������
        /// </summary>
        /// <param name="info">ĳ���������Ϣ</param>
        /// <returns>������Ӧ�Ĺؼ��ֵȲ��������</returns>
        public DataView GetValue(Tz888.Model.Info.MainInfoModel model)
        {
            Tz888.Model.Info.DefaultValueModel model1 = new Tz888.Model.Info.DefaultValueModel();
            model1.InfoTypeID = model.InfoTypeID;

            string subTypeID1 = "";
            string subTypeID2 = "";
            SetInfoTypeRef.GetSubTypeID(model1.InfoTypeID, ref subTypeID1, ref subTypeID2);
            Type infoObjType = model.GetType();
            if (subTypeID1 != "")
            {
                System.Reflection.PropertyInfo pi = infoObjType.GetProperty(subTypeID1);
                if (pi != null)
                {
                    model1.SubTypeID1 = pi.GetValue(model, null).ToString().Trim();
                }
                if (subTypeID2 != "")
                {
                    pi = infoObjType.GetProperty(subTypeID2);
                    if (pi != null)
                    {
                        model1.SubTypeID2 = pi.GetValue(model, null).ToString().Trim();
                    }
                }
            }
            if (model1.SubTypeID1 == null)
            {
                model1.SubTypeID1 = "";
            }
            if (model1.SubTypeID2 == null)
            {
                model1.SubTypeID2 = "";
            }
            return GetValue(model1);
        }
    }
}
