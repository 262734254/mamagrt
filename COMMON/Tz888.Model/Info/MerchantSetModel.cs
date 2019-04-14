using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Info
{
    /// <summary>
    /// ����������Ϣʵ��
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
        /// ������Ϣ
        /// </summary>
        public MainInfoModel MainInfoModel
        {
            get { return _mainInfoModel; }
            set { _mainInfoModel = value; }
        }

        /// <summary>
        /// ������Ϣ
        /// </summary>
        public MerchantInfoModel MerchantInfoModel
        {
            get { return _merchantInfoModel; }
            set { _merchantInfoModel = value; }
        }

        /// <summary>
        /// ����Ϣ
        /// </summary>
        public ShortInfoModel ShortInfoModel
        {
            get { return _shortInfoModel; }
            set { _shortInfoModel = value; }
        }

        /// <summary>
        /// ��ϵ��Ϣ
        /// </summary>
        public InfoContactModel InfoContactModel
        {
            get { return _infoContactModel; }
            set { _infoContactModel = value; }
        }

        /// <summary>
        /// ��ϵ����Ϣ
        /// </summary>
        public List<InfoContactManModel> InfoContactManModels
        {
            get { return _infoContactManModels; }
            set { _infoContactManModels = value; }
        }

        /// <summary>
        /// ��Ϣ�����Դ
        /// </summary>
        public List<InfoResourceModel> InfoResourceModels
        {
            get { return _infoResourceModels; }
            set { _infoResourceModels = value; }
        }
    }
}
