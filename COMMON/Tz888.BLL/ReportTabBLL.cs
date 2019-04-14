using System;
using System.Collections.Generic;
using System.Text;
using Tz888.IDAL;
using Tz888.DALFactory;

namespace Tz888.BLL
{
    public class ReportTabBLL
    {
        private readonly Tz888.IDAL.IReportTab dal = DataAccess.CreateInfo_IReportTab();
        //添加举报信息
        public int addReportInfo(long InfoID, string Title, string content, string insertTime)
        {
            return dal.addReportInfo(InfoID, Title, content, insertTime);
        }
    }
}
