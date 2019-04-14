using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using Tz888.IDAL.Info;
using Tz888.DALFactory;
using System.Collections.Generic;

namespace Tz888.BLL.Info
{
    public class InfoDefaultDEFRule
    {
        private readonly IInfoDefaultDEF dal = DataAccess.CreateInfoDefaultDEF();

        public long Insert(Tz888.Model.Info.InfoDefaultDEFModel model)
        {
            return dal.Insert(model);
        }

        /// <summary>
        /// ����ѡ�����ȫ����Ϊ��ѡ��״̬
        /// </summary>
        /// <returns></returns>
        public bool DeSelect(long InfoID)
        {
            return dal.DeSelect(InfoID);
        }

        public bool Delete(long ID)
        {
            return dal.Delete(ID);
        }

        /// <summary>
        /// ѡ��infoID�Ĺؼ��ֵȵĶ���
        /// </summary>
        /// <param name="infoID">��ϢID</param>
        /// <param name="defType">ȫ��:0�����⣺1���ؼ��֣�2����ҳ������4</param>
        /// <returns></returns>
        public DataView GetList(long infoID, byte defType)
        {
            return dal.GetList(infoID,defType);
        }

        /// <summary>
        /// ��ȡĳ����Ϣ�ı���
        /// </summary>
        /// <param name="infoID">��ϢID</param>
        /// <param name="title">����</param>
        /// <param name="info">ĳ����Ϣ</param>
        public void GetTitle(Tz888.Model.Info.MainInfoModel model,ref string title, string NewsLblStatus)
        {
            long currentPage = 1;
            long pageCount = 0;

            DataView dvInfo = Tz888.BLL.Info.Common.GetListByInfoType(model.InfoTypeID,
                    "*",
                    "InfoID=" + model.InfoID,
                    "",
                    ref currentPage,
                    1,
                    ref pageCount
                    );

            if (dvInfo.Count == 0)
            {
                throw new Exception("û���ҵ�id=" + model.InfoID.ToString() + "��Ϣ.");
            }
            if (NewsLblStatus == "0")
            {
                title = title + "��" + dvInfo[0]["AreaName"].ToString().Trim() + "��" + dvInfo[0]["NewsTypeName"].ToString().Trim() + "�� ��ѶƵ�� - �й�����Ͷ����";
            }
            else
            {
                title = title + "��" + dvInfo[0]["NewsIndustryName"].ToString().Trim() + "��" + dvInfo[0]["NewsTypeName"].ToString().Trim() + "�� ��ѶƵ�� - �й�����Ͷ����";
            }
        }

        /// <summary>
        /// ��ȡĳ����Ϣ�Ĺؼ��֣����⣬��ҳ����
        /// </summary>
        /// <param name="infoID">��ϢID</param>http://localhost:3200/InterFace/Info/Employee/EliteView.aspx
        /// <param name="keyWord">�ؼ���</param>
        /// <param name="title">����</param>
        /// <param name="description">��ҳ����</param>
        /// <param name="contentKeyWord">���ݹؼ���</param>
        /// <param name="info">ĳ����Ϣ</param>

        public void GetKeyWordTitleDes(Tz888.Model.Info.MainInfoModel model, ref string keyWord, ref string title, ref string description)
        {
            long currentPage = 1;
            long pageCount = 0;
            DataView dv = GetList(model.InfoID, 0);
            if (dv == null || dv.Count == 0)
            {
                Tz888.BLL.Info.SetDefaultValue defaultValueObj = new SetDefaultValue();

                dv = defaultValueObj.GetValue(model);
                if (dv == null || dv.Count == 0)
                {
                    return;
                }
            }

            DataView dvInfo = Tz888.BLL.Info.Common.GetListByInfoType(model.InfoTypeID,
                "*",
                "InfoID=" + model.InfoID,
                "",
                ref currentPage,
                1,
                ref pageCount
                );
            if (dvInfo.Count == 0)
            {
                throw new Exception("û���ҵ�id=" + model.InfoID.ToString() + "��Ϣ.");
            }
            //���ɹؼ���
            dv.RowFilter = "DefType=2 OR DefType=3 OR DefType=6 OR DefType=7";
            dv.Sort = "Seq";
            keyWord = GetStr(dv, keyWord, dvInfo, ',', dvInfo[0]["contentKeyWord"].ToString());


            //���ɱ���
            dv.RowFilter = "DefType=1 OR DefType=3 OR DefType=5 OR DefType=7";
            title = GetStr(dv, title, dvInfo, '-', "");
            //��������
            if (description.Trim() == "")
            {
                dv.RowFilter = "DefType=4 OR DefType=5 OR DefType=6 OR DefType=7";
                description = GetStr(dv, "", dvInfo, ',', "");
            }
        }


        private string GetStr(DataView dv, string value, DataView dvInfo, char divChar, string attachStr)
        {
            System.Collections.ArrayList keys = new System.Collections.ArrayList();
            string[] skeys = value.Split(new char[] { divChar });
            for (int i = 0; i < skeys.Length; i++)
            {
                if (skeys[i] != "")
                {
                    keys.Add(skeys[i]);
                }
            }

            for (int i = 0; i < dv.Count; i++)
            {
                string fromColumn = dv[i]["FromColumn"].ToString().Trim();
                string fromValue = "";
                if (fromColumn != "")//ȡ�ֶ�ֵ
                {
                    if (dvInfo.Table.Columns.Contains(fromColumn))
                    {
                        fromValue = dvInfo[0][fromColumn].ToString().Trim();

                        //�Ժ������������⴦��
                        if (fromColumn == "CooperationDemandType")
                        {
                            string[] coopers = fromValue.Split(new char[] { ',' });
                            PageIniControl bindObj = new PageIniControl();

                            List<Tz888.Model.Info.CooperationDemandTypeModel> dvCooper = Tz888.BLL.Info.Common.GetCooperationDemandList("Capital");
                            for (int j = 0; j < coopers.Length; j++)
                            {
                                //CooperationDemandType CooperationDemandTypeID,CooperationDemandTypeName,CooperationDemandTypeID
                                for (int k = 0; k < dvCooper.Count; k++)
                                {
                                    if (coopers[j] == dvCooper[k].CooperationDemandTypeID.Trim())
                                    {
                                        keys.Add(dvCooper[k].CooperationDemandName.Trim());
                                    }
                                }
                                fromValue = "";
                            }

                        }
                    }
                }
                else//ȡ�̶�ֵ
                {
                    fromValue = dv[i]["FromValue"].ToString().Trim();
                }

                if (fromValue != "" && keys.Contains(fromValue) == false)
                {
                    keys.Add(fromValue);
                }

            }

            if (attachStr != "")
            {
                string[] attachStrs = attachStr.Split(new char[] { divChar });
                for (int i = 0; i < attachStrs.Length; i++)
                {
                    if (attachStrs[i] != "" && keys.Contains(attachStrs[i]) == false)
                    {
                        keys.Add(attachStrs[i]);
                    }
                }
            }

            string keyWord = "";
            for (int i = 0; i < keys.Count; i++)
            {
                keyWord += (string)keys[i] + divChar;
            }
            keyWord = keyWord.TrimEnd(new char[] { divChar });

            return keyWord;
        }

        /// <summary>
        /// ���ɹؼ��ֻ�����
        /// </summary>
        /// <param name="info">��Ϣ</param>
        /// <param name="subDefaults">SetSubDefaultValue��ID���ϣ��ö��Ÿ���</param>
        /// <param name="originStr">������ַ���</param>
        /// <param name="div">�ָ���,','���ڹؼ��ֺ�������'-'������ҳ����</param>
        /// <param name="isKeyword">�Ƿ��ǹؼ���,��������ɹؼ��֣�����ټ���ContentKeyWord������</param>
        /// <returns>����֮����ַ���</returns>
        public string GetKeyWordOrTitleOrDes(string infoID, string infoTypeID, string subDefaultIds, string originStr, char div, bool isKeyword)
        {


            if (subDefaultIds.Trim().Length == 0)
            {
                return originStr;
            }
            string[] subDefaults = subDefaultIds.Split(new char[] { ',' });
            string criteira = "ID IN(";
            for (int i = 0; i < subDefaults.Length; i++)
            {
                criteira += subDefaults[i] + ",";
            }
            criteira = criteira.Remove(criteira.Length - 1, 1) + ")";

            long currentPage = 1;
            long pageCount = 0;

            Tz888.BLL.Info.SetSubDefaultValueRule obj = new SetSubDefaultValueRule();
            DataView dv = obj.GetList("*", criteira, "Seq", ref currentPage, -1, ref pageCount);

            DataView dvInfo = Tz888.BLL.Info.Common.GetListByInfoType(infoTypeID,
                "*",
                "InfoID=" + infoID,
                "",
                ref currentPage,
                1,
                ref pageCount
                );
            if (dvInfo.Count == 0)
            {
                throw new Exception("û���ҵ�id=" + infoID.ToString() + "��Ϣ.");
            }

            string contentKeyWord = "";
            if (isKeyword)
            {
                contentKeyWord = dvInfo[0]["contentKeyWord"].ToString();
            }

            //���ɹؼ���

            string returnStr = GetStr(dv, originStr, dvInfo, div, contentKeyWord);

            return returnStr;

        }
    }
}