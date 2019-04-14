using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Tz888.Model.Koubei;
using Tz888.IDAL.Koubei;
using Tz888.DALFactory;
using System.Net;
using System.IO;
using System.Xml;

namespace Tz888.BLL.Koubei
{
    public class JoinKoubeiBLL
    {
        private readonly IJoinkoubei dal = DataAccess.CreateIJoinkoubei();
        public string partner_offer_id_pre = System.Configuration.ConfigurationManager.AppSettings["partner_offer_id_pre"].ToString();

        #region --数据操作信息--
        public string insertData(JoinKoubeiModel model)
        {
            return dal.insertData(model);
        }
        public void updateData(JoinKoubeiModel model)
        {
            dal.updateData(model);
        }
        public bool deleteData(int JoinID)
        {
            return dal.deleteData(JoinID);
        }
        public JoinKoubeiModel selectOne(JoinKoubeiModel model)
        {
            return dal.selectOne(model);
        }
        public JoinKoubeiModel selectOneById(int JoinID)
        {
            return dal.selectOneById(JoinID);
        }
        public JoinKoubeiModel getInfoFromMainInfo(string InfoType, long InfoID, string AreaAll)
        {
            return dal.getInfoFromMainInfo(InfoType, InfoID, AreaAll);
        }
        public string[] getTitleAndContent(string InfoType, long InfoID)
        {
            return dal.getTitleAndContent(InfoType, InfoID);
        }
        public bool checkKoubeiByInfoID(string InfoType, long InfoID)
        {
            return dal.checkKoubeiByInfoID(InfoType, InfoID);
        }
        public bool updateStateById(long JoinID, int state)
        {
            return dal.updateStateById(JoinID, state);
        }
        #endregion

        #region 根据推荐的返回信息处理
        public string dealInfoByRetStr(long JoinID, string retStr)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(retStr);
            string getCode = xmlDoc.SelectSingleNode("response/code").InnerText;
            string resultStr = "";
            switch (getCode.Trim())
            {
                case "200": resultStr = "执行成功"; break;
                case "401": resultStr = "未被授权使用"; break;
                case "403": resultStr = "无权限访问接口"; break;
                case "404": resultStr = "未找到指定资源"; break;
                case "406": resultStr = "不接受的参数类型,详细:" + xmlDoc.SelectSingleNode("response").InnerText; break;
                case "417": resultStr = "预处理失败"; break;
                case "500": resultStr = "接口服务端内部错误"; break;
                default: resultStr = "执行失败，无提示"; break;
            }
            //修改state
            if (getCode.Trim() == "200") //|| getCode.Trim() == "417"
            {
                updateStateById(JoinID, 1);
            }
            return resultStr;
        }
        #endregion

        #region postInfo传送信息(添加或者修改)
        public string postInfo(string postType, JoinKoubeiModel model)
        {
            string contact_person_Temp = model.Temp_contact_person;
            string contact_phone1_Temp = model.Temp_contact_phone1;
            string category_id = model.Temp_category_id;
            string partner_id = model.Temp_partner_id;
            string sign_key = model.Temp_sign_key;
            int debug = model.Temp_debug;

            //partner_offer_id
            string partner_offer_id = partner_offer_id_pre.Trim() + model.Join_ID.ToString().Trim();//"TZ" + 
            string source_url = model.Join_URL.Trim();
            int region_code = model.Join_AreaCode;
            string title = model.Join_Title;
            string content = model.Join_Content;
            int info_role = model.Join_Type;
            string start_time = getUnix_timestamp(model.Join_StartTime);
            string expire_time = getUnix_timestamp(model.Join_EndTime);

            string contact_person = model.Join_LinkMan;
            if (contact_person_Temp.Trim() != "")
                contact_person = contact_person_Temp;
            string contact_phone1 = model.Join_Tel;
            if (contact_phone1_Temp.Trim() != "")
                contact_phone1 = contact_phone1_Temp;
            string contact_phone2 = "";
            string contact_email = model.Join_Email;

            string postString = "";
            postString = "category_id=" + category_id.ToString();
            postString += "&contact_person=" + contact_person;
            postString += "&contact_phone1=" + contact_phone1;
            if (contact_phone2 != "")
                postString += "&contact_phone2=" + contact_phone2;
            if (contact_email != "")
                postString += "&contact_email=" + contact_email;
            postString += "&content=" + GetContent(content);
            postString += "&debug=" + debug;
            postString += "&expire_time=" + expire_time;
            postString += "&info_role=" + info_role;
            postString += "&partner_id=" + partner_id;
            postString += "&partner_offer_id=" + partner_offer_id;
            postString += "&region_code=" + region_code;
            postString += "&sign_value=" + GetSign_value(partner_id, sign_key, category_id, partner_offer_id, source_url, region_code, title, content, info_role, start_time, expire_time, contact_email, contact_person, contact_phone1, contact_phone2, debug);
            postString += "&source_url=" + source_url;
            postString += "&start_time=" + start_time;
            postString += "&title=" + GetTitle(title);

            byte[] byteArray = Encoding.UTF8.GetBytes(postString);
            HttpWebRequest webRequest2 = (HttpWebRequest)WebRequest.Create("http://api.fuwu.koubei.com/offer/" + postType);
            webRequest2.Method = "POST";
            webRequest2.ContentType = "application/x-www-form-urlencoded";
            webRequest2.ContentLength = byteArray.Length;
            Stream newStream = webRequest2.GetRequestStream();

            newStream.Write(byteArray, 0, byteArray.Length);//写入参数
            newStream.Close();

            HttpWebResponse response2 = (HttpWebResponse)webRequest2.GetResponse();
            StreamReader sr2 = new StreamReader(response2.GetResponseStream(), Encoding.Default);
            string retStr = sr2.ReadToEnd();
            string resultStr = dealInfoByRetStr(model.Join_ID, retStr);
            //return resultStr.ToString();
            return retStr;
        }
        #endregion

        #region removeInfo传送信息
        public string removeInfo(JoinKoubeiModel model)
        {
            string contact_person_Temp = model.Temp_contact_person;
            string contact_phone1_Temp = model.Temp_contact_phone1;
            string category_id = model.Temp_category_id;
            string partner_id = model.Temp_partner_id;
            string sign_key = model.Temp_sign_key;
            int debug = model.Temp_debug;

            string partner_offer_id = partner_offer_id_pre.Trim() + model.Join_ID.ToString().Trim();

            string postString = "";
            postString += "&partner_id=" + partner_id;
            postString += "&partner_offer_id=" + partner_offer_id;
            postString += "&sign_value=" + GetSign_value(partner_id, sign_key, category_id, partner_offer_id);

            byte[] byteArray = Encoding.UTF8.GetBytes(postString);
            HttpWebRequest webRequest2 = (HttpWebRequest)WebRequest.Create("http://api.fuwu.koubei.com/offer/OfferRemove");
            webRequest2.Method = "POST";
            webRequest2.ContentType = "application/x-www-form-urlencoded";
            webRequest2.ContentLength = byteArray.Length;
            Stream newStream = webRequest2.GetRequestStream();

            newStream.Write(byteArray, 0, byteArray.Length);//写入参数
            newStream.Close();

            HttpWebResponse response2 = (HttpWebResponse)webRequest2.GetResponse();
            StreamReader sr2 = new StreamReader(response2.GetResponseStream(), Encoding.Default);
            string retStr = sr2.ReadToEnd();
            string resultStr = dealInfoByRetStr(model.Join_ID, retStr);
            return resultStr.ToString();
        }
        #endregion

        #region GetSign_value 获取sign_value参数
        private string GetSign_value(string partner_id, string sign_key, string category_id, string partner_offer_id)
        {
            string str = "";
            str += "partner_id=" + partner_id;
            str += "&partner_offer_id=" + partner_offer_id;
            str += sign_key;
            str = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5").ToLower();
            return str;
        }
        private string GetSign_value(string partner_id, string sign_key, string category_id, string partner_offer_id, string source_url, int region_code, string title, string content, int info_role, string start_time, string expire_time, string contact_email, string contact_person, string contact_phone1, string contact_phone2, int debug)
        {
            string str = "";
            str = "category_id=" + category_id.ToString();
            if (contact_email != "")
                str += "&contact_email=" + contact_email;
            str += "&contact_person=" + contact_person;
            str += "&contact_phone1=" + contact_phone1;
            if (contact_phone2 != "")
                str += "&contact_phone2=" + contact_phone2;
            str += "&content=" + GetContent(content);
            str += "&debug=" + debug;
            str += "&expire_time=" + expire_time;
            str += "&info_role=" + info_role;
            str += "&partner_id=" + partner_id;
            str += "&partner_offer_id=" + partner_offer_id;
            str += "&region_code=" + region_code;
            str += "&source_url=" + source_url;
            str += "&start_time=" + start_time;
            str += "&title=" + GetTitle(title);
            str += sign_key;
            str = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5").ToLower();
            return str;
        }
        #endregion

        #region 截取标题与内容的长度
        private string GetTitle(string title)
        {
            string strTemp = title;
            if (strTemp.Length > 30)
            {
                strTemp = strTemp.Substring(0, 30);
            }
            return strTemp;
        }

        private string getUnix_timestamp(DateTime timeNow)
        {
            DateTime time = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            TimeSpan toNow = timeNow.Subtract(time);
            long unix_timestamp = (long)Math.Round(toNow.TotalSeconds);
            return unix_timestamp.ToString();
        }

        private string GetContent(string content)
        {
            string strTemp = content;
            if (strTemp.Length > 5000)
            {
                strTemp = strTemp.Substring(0, 5000);
            }
            return strTemp;
        }
        #endregion
    }
}
