using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Specialized;

namespace Tz888.BLL.InfoStatic
{
    public class SetInfoPageStaticTab
    {
        private static readonly Tz888.IDAL.InfoStatic.ISetInfoPageStaticTab dal = Tz888.DALFactory.DataAccess.CreateSetInfoPageStaticTab();

        #region  成员方法
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Tz888.Model.InfoStatic.SetInfoPageStaticTab model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {
            return dal.Delete(ID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Tz888.Model.InfoStatic.SetInfoPageStaticTab GetModel(int ID)
        {
            return dal.GetModel(ID);
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        public DataSet GetList(string GetFields, string OrderName, int PageSize, int PageIndex, int doCount, int OrderType, string StrWhere)
        {
            return dal.GetList(GetFields, OrderName, PageSize, PageIndex, doCount, OrderType, StrWhere);
        }

        public Tz888.Model.InfoStatic.SetInfoPageStaticTab GetModel()
        {
            DataSet ds = this.GetList("*", "ID", 1, 1, 0, 0, "");
            Tz888.Model.InfoStatic.SetInfoPageStaticTab model = new Tz888.Model.InfoStatic.SetInfoPageStaticTab();
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
                if (ds.Tables[0].Rows[0]["LastUpdateTime"].ToString() != "")
                {

                    model.LastUpdateTime = DateTime.Parse(ds.Tables[0].Rows[0]["LastUpdateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["MinUpdateTime"].ToString() != "")
                {
                    model.MinUpdateTime = int.Parse(ds.Tables[0].Rows[0]["MinUpdateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsActive"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["IsActive"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsActive"].ToString().ToLower() == "true"))
                    {
                        model.IsActive = true;
                    }
                    else
                    {
                        model.IsActive = false;
                    }
                }

                model.RunTime = ds.Tables[0].Rows[0]["RunTime"].ToString();
                if (ds.Tables[0].Rows[0]["StartTime"].ToString() != "")
                {

                    model.StartTime = DateTime.Parse(ds.Tables[0].Rows[0]["StartTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["EndTime"].ToString() != "")
                {

                    model.EndTime = DateTime.Parse(ds.Tables[0].Rows[0]["EndTime"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 更新服务最后启动时间
        /// </summary>
        public bool UpdateLastUpdateTime(int ID)
        {
            Tz888.Model.InfoStatic.SetInfoPageStaticTab model = this.GetModel(ID);
            model.LastUpdateTime = System.DateTime.Now;
            return this.Update(model);
        }

        #endregion  成员方法
    }
}
