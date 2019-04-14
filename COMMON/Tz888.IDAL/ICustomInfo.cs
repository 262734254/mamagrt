using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.IDAL
{
    public interface ICustomInfo
	{
		#region  我的定阅成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(int ID);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int  Add(Tz888.Model.CustomInfoModel model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
        void Update(Tz888.Model.CustomInfoModel model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		void Delete(int ID);
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        Tz888.Model.CustomInfoModel GetModel(int ID);
		/// <summary>
		/// 获得数据列表
		/// </summary>
		//DataSet GetList(string strWhere);
		/// <summary>
		/// 获得数据列表
		/// </summary>
		DataSet GetList();
		#endregion  成员方法
	}    
}
