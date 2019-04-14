using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.IDAL
{
    public interface IResourcesNotice
    {
                /// <summary>
        ///  ����һ������
        /// </summary>
        bool Add(Tz888.Model.ResourcesNotice model);

                /// <summary>
        /// ���¹���
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="PassWord"></param>
        /// <returns></returns>
        bool Update(Tz888.Model.ResourcesNotice model);

                /// <summary>
        /// ��ѯһ������
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        DataSet Select(int ID);

                /// <summary>
        /// ɾ��һ������
        /// </summary>
        bool Delete(int ID);
    }
}
