using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.IDAL.Info
{
    public interface IInfoDefaultDEF
    {
        long Insert(Tz888.Model.Info.InfoDefaultDEFModel model);
        /// <summary>
        /// ����ѡ�����ȫ����Ϊ��ѡ��״̬
        /// </summary>
        /// <returns></returns>
        bool DeSelect(long ID);

        bool Delete(long ID);
        /// <summary>
        /// ѡ��infoID�Ĺؼ��ֵȵĶ���
        /// </summary>
        /// <param name="infoID">��ϢID</param>
        /// <param name="defType">���⣺1���ؼ��֣�2����ҳ������4</param>
        /// <returns></returns>
        DataView GetList(
            long infoID,
            byte defType
            );
    }
}
