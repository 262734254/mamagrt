using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Info
{
    /// <summary>
    /// 投资资源完整信息实体类
    /// </summary>
    public class CapitalSetModel
    {
        private MainInfoModel _mainInfoModel = new MainInfoModel();
        private CapitalInfoModel _capitalInfoModel = new CapitalInfoModel();
        private ShortInfoModel _shortInfoModel = new ShortInfoModel();
        private InfoContactModel _infoContactModel = new InfoContactModel();
        private List<InfoContactManModel> _infoContactManModels = new List<InfoContactManModel>();
        private List<CapitalInfoAreaModel> _capitalInfoAreaModels = new List<CapitalInfoAreaModel>();
        private List<InfoResourceModel> _infoResourceModels = new List<InfoResourceModel>();

        /// <summary>
        /// 主体信息
        /// </summary>
        public MainInfoModel MainInfoModel
        {
            get { return _mainInfoModel; }
            set { _mainInfoModel = value; }
        }

        /// <summary>
        /// 投资个性信息
        /// </summary>
        public CapitalInfoModel CapitalInfoModel
        {
            get { return _capitalInfoModel; }
            set { _capitalInfoModel = value; }
        }

        /// <summary>
        /// 短信息
        /// </summary>
        public ShortInfoModel ShortInfoModel
        {
            get { return _shortInfoModel; }
            set { _shortInfoModel = value; }
        }

        /// <summary>
        /// 投资联系信息
        /// </summary>
        public InfoContactModel InfoContactModel
        {
            get { return _infoContactModel; }
            set { _infoContactModel = value; }
        }

        /// <summary>
        /// 投资联系人信息
        /// </summary>
        public List<InfoContactManModel> InfoContactManModels
        {
            get { return _infoContactManModels; }
            set { _infoContactManModels = value; }
        }

        /// <summary>
        /// 投资区域信息
        /// </summary>
        public List<CapitalInfoAreaModel> CapitalInfoAreaModels
        {
            get { return _capitalInfoAreaModels; }
            set { _capitalInfoAreaModels = value; }
        }
        
        /// <summary>
        /// 投资信息相关资源
        /// </summary>
        public List<InfoResourceModel> InfoResourceModels
        {
            get { return _infoResourceModels; }
            set { _infoResourceModels = value; }
        }
    }
}
