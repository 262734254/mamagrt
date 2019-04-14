using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Info
{
    /// <summary>
    /// 项目合作类型实体
    /// </summary>
    public class CooperationDemandTypeModel
    {
        public CooperationDemandTypeModel()
		{}
		#region Model
		private string _cooperationdemandtypeid;
		private string _cooperationdemandname;
        private string _infoType;
		/// <summary>
		/// 
		/// </summary>
		public string CooperationDemandTypeID
		{
			set{ _cooperationdemandtypeid=value;}
			get{return _cooperationdemandtypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CooperationDemandName
		{
			set{ _cooperationdemandname=value;}
			get{return _cooperationdemandname;}
		}

        /// <summary>
        /// 
        /// </summary>
        public string InfoType
        {
            set { _infoType = value; }
            get { return _infoType; }
        }


        public CooperationDemandTypeModel(string cooperationdemandtypeid, string cooperationDemandName,string infoType)
        {
            this._cooperationdemandtypeid = cooperationdemandtypeid;
            this._cooperationdemandname = cooperationDemandName;
            this._infoType = infoType;
        }
		#endregion Model
    }
}
