using System;
namespace Tz888.Model.InfoStatic
{
    /// <summary>
    ///  µÃÂ¿‡InfoStaticQueueTab 
    /// </summary>
    public class InfoStaticQueueTab
    {
        public InfoStaticQueueTab()
        { }
        #region Model
        private int _infoid;
        private string _infotype;
        private int _stateflag;
        /// <summary>
        /// 
        /// </summary>
        public int InfoID
        {
            set { _infoid = value; }
            get { return _infoid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string InfoType
        {
            set { _infotype = value; }
            get { return _infotype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int StateFlag
        {
            set { _stateflag = value; }
            get { return _stateflag; }
        }
        #endregion Model
    }
}
