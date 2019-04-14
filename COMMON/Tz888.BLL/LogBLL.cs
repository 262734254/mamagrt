using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Tz888.DALFactory;
using Tz888.Model;
using Tz888.IDAL;

namespace Tz888.BLL
{
    /// <summary>
    /// ��Ϣ����:0:һ�㡡1���ɹ�  2;ʧ��
    /// </summary>
    public enum LogLevel : byte
    {
        Fault = 4,
        Error = 3,
        Warn = 2,
        Info = 1,
        Debug = 0
    }
    public enum LogEventType : byte
    {
        ServiceStart = 0,
        ServiceExit = 1,
        GenList = 2,
        ManualGen = 3,
        GenDetailPage = 5,
        GenPage = 6,
        FinishGenList = 7
    }

    //��־������
    public class LogBLL
    {

        private static readonly Tz888.IDAL.ILog dal = Tz888.DALFactory.DataAccess.CreateLog();


        public static bool SaveLog(int settingID, string msg, LogLevel level, LogEventType eventType, string loginName)
        {
            bool result = false;
            Tz888.Model.LogModel model = new LogModel();

            model.DateTime = DateTime.Now;
            model.ThreadID = System.Threading.Thread.CurrentThread.ManagedThreadId;
            model.SettingID = settingID;
            model.Message = msg;
            model.Level = (byte)level;
            model.EventType = (byte)eventType;
            model.LoginName = loginName;

            return dal.Insert(model);
        }

        public static bool SaveLog(int settingID, string msg, LogLevel level, LogEventType eventType)
        {
            return SaveLog(settingID, msg, level, eventType, "Service");
        }

        public static bool SaveLog(string msg, LogLevel level, LogEventType eventType)
        {
            return SaveLog(0, msg, level, eventType, "Service");
        }

        public static bool Detele(long LogID)
        {
            return dal.Delete(LogID);
        }
    }
}
