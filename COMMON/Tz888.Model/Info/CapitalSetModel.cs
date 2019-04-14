using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Info
{
    /// <summary>
    /// Ͷ����Դ������Ϣʵ����
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
        /// ������Ϣ
        /// </summary>
        public MainInfoModel MainInfoModel
        {
            get { return _mainInfoModel; }
            set { _mainInfoModel = value; }
        }

        /// <summary>
        /// Ͷ�ʸ�����Ϣ
        /// </summary>
        public CapitalInfoModel CapitalInfoModel
        {
            get { return _capitalInfoModel; }
            set { _capitalInfoModel = value; }
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
        /// Ͷ����ϵ��Ϣ
        /// </summary>
        public InfoContactModel InfoContactModel
        {
            get { return _infoContactModel; }
            set { _infoContactModel = value; }
        }

        /// <summary>
        /// Ͷ����ϵ����Ϣ
        /// </summary>
        public List<InfoContactManModel> InfoContactManModels
        {
            get { return _infoContactManModels; }
            set { _infoContactManModels = value; }
        }

        /// <summary>
        /// Ͷ��������Ϣ
        /// </summary>
        public List<CapitalInfoAreaModel> CapitalInfoAreaModels
        {
            get { return _capitalInfoAreaModels; }
            set { _capitalInfoAreaModels = value; }
        }
        
        /// <summary>
        /// Ͷ����Ϣ�����Դ
        /// </summary>
        public List<InfoResourceModel> InfoResourceModels
        {
            get { return _infoResourceModels; }
            set { _infoResourceModels = value; }
        }
    }
}
