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

        #region-- 添加 -------------------
        /// <summary>
        /// 添加
        /// </summary>
        /// <returns>是否操作成功（true成功，false失败）</returns>
        public long Insert(Tz888.Model.Info.DefaultValueModel model)
        {
            return dal.Insert(model);
        }
        #endregion

        #region-- 修改 -------------------
        /// <summary>
        /// 修改职务类型类别
        /// </summary>
        /// <returns>是否操作成功（true成功，false失败）</returns>
        public bool Update(Tz888.Model.Info.DefaultValueModel model)
        {
            return dal.Update(model);
        }
        #endregion

        #region-- 删除 -------------------
        /// <summary>
        /// 删除
        /// </summary>		
        /// <returns>是否操作成功（true成功，false失败）</returns>
        public bool Delete(long ID)
        {
            return dal.Delete(ID);
        }
        #endregion

        #region-- 取值 -------------------
        /// <summary>
        /// 取值
        /// </summary>		
        /// <returns>返回Dataview</returns>
        public DataView GetValue(Tz888.Model.Info.DefaultValueModel model)
        {
            return dal.GetValue(model);
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
            return dal.GetDetail(Key);
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

            return dal.GetList(SelectCol, Criteria, OrderBy, ref CurrentPage, PageSize, ref PageCount);
        }
        #endregion

        /// <summary>
        /// 复制数据,
        /// </summary>
        /// <param name="sourceID">源ID</param>
        /// <returns></returns>
        public long Clone(long sourceID, Tz888.Model.Info.DefaultValueModel model)
        {
            return dal.Clone(sourceID, model);
        }


        /// <summary>
        /// 取与某条信息最相关的的参数定义表
        /// </summary>
        /// <param name="info">某条具体的信息</param>
        /// <returns>返回相应的关键字等参数定义表</returns>
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
