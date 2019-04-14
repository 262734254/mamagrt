using System;
using System.Data;
using System.Data.SqlClient;
using Tz888.IDAL.Info;
using Tz888.DALFactory;
namespace Tz888.BLL.Info
{
    /// <summary>
    ///	
    /// <remarks></remarks>
    public class SetSubDefaultValueRule
    {
        private readonly ISetSubDefaultValue dal = DataAccess.CreateSetSubDefaultValue();

        public long Insert(Tz888.Model.Info.SubDefaultValueModel model)
        {
            return dal.Insert(model);
        }

        public bool Update(Tz888.Model.Info.SubDefaultValueModel model)
        {
            return dal.Update(model);
        }

        public bool Delete(long ID)
        {
            return dal.Delete(ID);
        }

        public Tz888.Model.Info.SubDefaultValueModel GetDetail(string Key)
        {
            return dal.GetDetail(Key);
        }

        public DataView GetList(
            string SelectCol,
            string Criteria,
            string OrderBy,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount)
        {
            return dal.GetList(SelectCol,Criteria,OrderBy,ref CurrentPage,PageSize,ref PageCount);
        }
    }
}
