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
        /// 将所选择的项全部置为不选择状态
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
        /// 选择infoID的关键字等的定义
        /// </summary>
        /// <param name="infoID">信息ID</param>
        /// <param name="defType">全部:0。标题：1，关键字：2，网页描述：4</param>
        /// <returns></returns>
        public DataView GetList(long infoID, byte defType)
        {
            return dal.GetList(infoID,defType);
        }

        /// <summary>
        /// 获取某条信息的标题
        /// </summary>
        /// <param name="infoID">信息ID</param>
        /// <param name="title">标题</param>
        /// <param name="info">某条信息</param>
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
                throw new Exception("没有找到id=" + model.InfoID.ToString() + "信息.");
            }
            if (NewsLblStatus == "0")
            {
                title = title + "－" + dvInfo[0]["AreaName"].ToString().Trim() + "－" + dvInfo[0]["NewsTypeName"].ToString().Trim() + "－ 资讯频道 - 中国招商投资网";
            }
            else
            {
                title = title + "－" + dvInfo[0]["NewsIndustryName"].ToString().Trim() + "－" + dvInfo[0]["NewsTypeName"].ToString().Trim() + "－ 资讯频道 - 中国招商投资网";
            }
        }

        /// <summary>
        /// 获取某条信息的关键字，标题，网页描述
        /// </summary>
        /// <param name="infoID">信息ID</param>http://localhost:3200/InterFace/Info/Employee/EliteView.aspx
        /// <param name="keyWord">关键字</param>
        /// <param name="title">标题</param>
        /// <param name="description">网页描述</param>
        /// <param name="contentKeyWord">内容关键字</param>
        /// <param name="info">某条信息</param>

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
                throw new Exception("没有找到id=" + model.InfoID.ToString() + "信息.");
            }
            //生成关键字
            dv.RowFilter = "DefType=2 OR DefType=3 OR DefType=6 OR DefType=7";
            dv.Sort = "Seq";
            keyWord = GetStr(dv, keyWord, dvInfo, ',', dvInfo[0]["contentKeyWord"].ToString());


            //生成标题
            dv.RowFilter = "DefType=1 OR DefType=3 OR DefType=5 OR DefType=7";
            title = GetStr(dv, title, dvInfo, '-', "");
            //生成描述
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
                if (fromColumn != "")//取字段值
                {
                    if (dvInfo.Table.Columns.Contains(fromColumn))
                    {
                        fromValue = dvInfo[0][fromColumn].ToString().Trim();

                        //对合作需求作特殊处理
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
                else//取固定值
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
        /// 生成关键字或标题等
        /// </summary>
        /// <param name="info">信息</param>
        /// <param name="subDefaults">SetSubDefaultValue的ID集合，用逗号隔开</param>
        /// <param name="originStr">传入的字符串</param>
        /// <param name="div">分隔符,','用在关键字和描述，'-'用在网页标题</param>
        /// <param name="isKeyword">是否是关键字,如果是生成关键字，则会再加上ContentKeyWord的内容</param>
        /// <returns>生成之后的字符串</returns>
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
                throw new Exception("没有找到id=" + infoID.ToString() + "信息.");
            }

            string contentKeyWord = "";
            if (isKeyword)
            {
                contentKeyWord = dvInfo[0]["contentKeyWord"].ToString();
            }

            //生成关键字

            string returnStr = GetStr(dv, originStr, dvInfo, div, contentKeyWord);

            return returnStr;

        }
    }
}