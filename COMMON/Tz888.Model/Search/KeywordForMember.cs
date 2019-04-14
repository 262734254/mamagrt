using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Search
{
    public class KeywordForMember
    {
        private long mlgID;
        private string mstrKeyword;
        private string mstrInfoTypeID;
        private DateTime mDateRecordTime;
        private string mstrLoginName;

        #region  --  Ù–‘ -------------------
        public long ID
        {
            get
            {
                return this.mlgID;
            }
            set
            {
                this.mlgID = value;
            }
        }
        public string Keyword
        {
            get
            {
                return this.mstrKeyword;
            }
            set
            {
                this.mstrKeyword = value;
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
                this.mstrInfoTypeID = value;
            }
        }
        public DateTime RecordTime
        {
            get
            {
                return this.mDateRecordTime;
            }
            set
            {
                this.mDateRecordTime = value;
            }
        }

        public string LoginName
        {
            get
            {
                return this.mstrLoginName;
            }
            set
            {
                this.mstrLoginName = value;
            }
        }

        #endregion


    }
}
