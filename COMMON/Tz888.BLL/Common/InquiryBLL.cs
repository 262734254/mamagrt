using System;
using System.Collections.Generic;
using System.Text;
using Tz888.IDAL.Common;
using Tz888.DALFactory;

namespace Tz888.BLL.Common
{
    public class InquiryBLL
    {
        private readonly IInquiry dal = DataAccess.CreateInquiry();

        #region
        /// <summary>
        /// ����һ������
        /// </summary>
        public int Insert(Tz888.Model.Common.InquiryModel model)
        {
            return dal.Insert(model);
        }

        #endregion  ��Ա����
    }
}
