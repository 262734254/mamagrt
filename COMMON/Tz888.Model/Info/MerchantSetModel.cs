using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Info
{
    /// <summary>
    /// 招商完整信息实体
    /// </summary>
    public class MerchantSetModel
    {
        private MainInfoModel _mainInfoModel = new MainInfoModel();
        private MerchantInfoModel _merchantInfoModel = new MerchantInfoModel();
        private ShortInfoModel _shortInfoModel = new ShortInfoModel();
        private InfoContactModel _infoContactModel = new InfoContactModel();
        private List<InfoContactManModel> _infoContactManModels = new List<InfoContactManModel>();
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
        /// 招商信息
        /// </summary>
        public MerchantInfoModel MerchantInfoModel
        {
            get { return _merchantInfoModel; }
            set { _merchantInfoModel = value; }
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
        /// 联系信息
        /// </summary>
        public InfoContactModel InfoContactModel
        {
            get { return _infoContactModel; }
            set { _infoContactModel = value; }
        }

        /// <summary>
        /// 联系人信息
        /// </summary>
        public List<InfoContactManModel> InfoContactManModels
        {
            get { return _infoContactManModels; }
            set { _infoContactManModels = value; }
        }

        /// <summary>
        /// 信息相关资源
        /// </summary>
        public List<InfoResourceModel> InfoResourceModels
        {
            get { return _infoResourceModels; }
            set { _infoResourceModels = value; }
        }
    }
}
