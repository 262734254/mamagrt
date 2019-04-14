using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Info
{
    /// <summary>
    /// 项目完整信息实体
    /// </summary>
    public class ProjectSetModel
    {
        private MainInfoModel _mainInfoModel = new MainInfoModel();
        private ProjectInfoModel _projectInfoModel = new ProjectInfoModel();
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
        /// 项目信息
        /// </summary>
        public ProjectInfoModel ProjectInfoModel
        {
            get { return _projectInfoModel; }
            set { _projectInfoModel = value; }
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
