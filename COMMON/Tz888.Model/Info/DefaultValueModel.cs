using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Info
{
    public class DefaultValueModel
    {
        private string mstrID;
		private string mstrInfoTypeID;
		private string mstrSubTypeID1;
		private string mstrSubTypeID2;
//		private string mstrDefaultTitleKeyword;
//		private string mstrDefaultKeyword;
//		private string mstrDefaultDescription;
		private string mstrRemark;

		#region  --  Ù–‘ -------------------
		public string ID
		{
			get
			{
				return this.mstrID;
			}
			set
			{
				this.mstrID=value;
			}
		}
		public string InfoTypeID
		{
			get
			{
				return this.mstrInfoTypeID;
			}
			set
			{
				this.mstrInfoTypeID=value;
			}
		}
		
		public string SubTypeID1
		{
			get
			{
				return this.mstrSubTypeID1;
			}
			set
			{
				this.mstrSubTypeID1=value;
			}
		}

		public string SubTypeID2
		{
			get
			{
				return this.mstrSubTypeID2;
			}
			set
			{
				this.mstrSubTypeID2=value;
			}
		}

//		public string DefaultTitleKeyword
//		{
//			get
//			{
//				return this.mstrDefaultTitleKeyword;
//			}
//			set
//			{
//				this.mstrDefaultTitleKeyword=value;
//			}
//		}
//		public string DefaultKeyword
//		{
//			get
//			{
//				return this.mstrDefaultKeyword;
//			}
//			set
//			{
//				this.mstrDefaultKeyword=value;
//			}
//		}
//		public string DefaultDescription
//		{
//			get
//			{
//				return this.mstrDefaultDescription;
//			}
//			set
//			{
//				this.mstrDefaultDescription=value;
//			}
//		}
		public string Remark
		{
			get
			{
				return this.mstrRemark;
			}
			set
			{
				this.mstrRemark=value;
			}
		}
		#endregion
    }
}
