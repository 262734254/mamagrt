using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Search
{
    public class SearchKeyword
    {
        private long mlgID;
        private string mstrKeyword;
        private string mstrInfoTypeID;
        private DateTime mDateRegDate;
        private long mlgUserNum;

        public SearchKeyword()
        {

        }

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
        public DateTime RegDate
        {
            get
            {
                return this.mDateRegDate;
            }
            set
            {
                this.mDateRegDate = value;
            }
        }

        public long UserNum
        {
            get
            {
                return this.mlgUserNum;
            }
            set
            {
                this.mlgUserNum = value;
            }
        }

        #endregion
    }
}
