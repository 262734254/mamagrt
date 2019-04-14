using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Tz888.DALFactory;
using Tz888.Model;
using Tz888.IDAL;

namespace Tz888.BLL
{
    public class ResourcesNotice
    {
        private readonly IResourcesNotice dal = DataAccess.CreateIResourcesNotice(); 
        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Add(Tz888.Model.ResourcesNotice model)
        { 
            return dal.Add(model);
        }

        /// <summary>
        /// ���¹���
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="PassWord"></param>
        /// <returns></returns>
        public bool Update(Tz888.Model.ResourcesNotice model)
        { 
            return dal.Update(model);
        }
                /// <summary>
        /// ��ѯһ������
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public DataSet Select(int ID)
        { 
            return dal.Select(ID);
        }
                /// <summary>
        /// ɾ��һ������
        /// </summary>
        public bool Delete(int ID)
        { 
            return dal.Delete(ID);
        }
    }
}
