using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.IDAL
{
    public interface ICustomInfo
	{
		#region  �ҵĶ��ĳ�Ա����
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		bool Exists(int ID);
		/// <summary>
		/// ����һ������
		/// </summary>
		int  Add(Tz888.Model.CustomInfoModel model);
		/// <summary>
		/// ����һ������
		/// </summary>
        void Update(Tz888.Model.CustomInfoModel model);
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		void Delete(int ID);
		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
        Tz888.Model.CustomInfoModel GetModel(int ID);
		/// <summary>
		/// ��������б�
		/// </summary>
		//DataSet GetList(string strWhere);
		/// <summary>
		/// ��������б�
		/// </summary>
		DataSet GetList();
		#endregion  ��Ա����
	}    
}
