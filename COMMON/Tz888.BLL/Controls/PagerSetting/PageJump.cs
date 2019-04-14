using System;
using System.Web.UI;
using System.ComponentModel;
using System.Web;

namespace OurControl
{
    /// <summary>
    /// ����������
    /// </summary>
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class PageJump : System.Web.UI.IStateManager
    {
        #region ======= �Զ���ViewState =======

        private Boolean _isTrackingViewState;
        private StateBag _viewState;
        protected StateBag ViewState
        {
            get
            {
                if (this._viewState == null)
                {
                    this._viewState = new StateBag(false);
                    if (this._isTrackingViewState)
                    {
                        ((IStateManager)this._viewState).TrackViewState();
                    }
                }
                return this._viewState;
            }
        }

        #endregion

        #region ======= ���� =======

        [Description("��ȡ�������Ƿ���ʾ��ת������"), DefaultValue(true), NotifyParentProperty(true)]
        public Boolean Visiable
        {
            get { return ViewState["Visiable"] != null ? (Boolean)ViewState["Visiable"] : true; }
            set { ViewState["Visiable"] = value; }
        }

        [Description("��ȡ�������Ƿ���ʾ��ת��"), DefaultValue(true), NotifyParentProperty(true)]
        public Boolean DDLVisiable
        {
            get { return ViewState["ddlNumOfPager"] != null ? (Boolean)ViewState["ddlNumOfPager"] : true; }
            set { ViewState["ddlNumOfPager"] = value; }
        }

        [Description("��ȡ�������Ƿ���ʾ��ǰҳ�����ҳ����"), DefaultValue(true), NotifyParentProperty(true)]
        public Boolean CurrentPageVisiable
        {
            get { return ViewState["CurrentPageVisiable"] != null ? (Boolean)ViewState["CurrentPageVisiable"] : true; }
            set { ViewState["CurrentPageVisiable"] = value; }
        }

        [Description("��ȡ����������������͡�"), DefaultValue(0), NotifyParentProperty(true)]
        public PageJumpType PageJumpType
        {
            get { return ViewState["PageJumpType"] != null ? (PageJumpType)ViewState["PageJumpType"] : PageJumpType.DropDownList; }
            set { ViewState["PageJumpType"] = value; }
        }

        [Description("��ȡ������λ��ҳ��������ߵ����֡�"), DefaultValue("��ת"), NotifyParentProperty(true)]
        public String LeftText
        {
            get { return ViewState["LeftText"] != null ? (String)ViewState["LeftText"] : "��ת"; }
            set { ViewState["LeftText"] = value; }
        }

        [Description("��ȡ������λ��ҳ�������ұߵ����֡�"), DefaultValue("ҳ"), NotifyParentProperty(true)]
        public String RightText
        {
            get { return ViewState["RightText"] != null ? (String)ViewState["RightText"] : "ҳ"; }
            set { ViewState["RightText"] = value; }
        }

        [Description("��ȡ��������ת��ť�е����֡�"), DefaultValue("��ת"), NotifyParentProperty(true)]
        public String ButtonText
        {
            get { return ViewState["ButtonText"] != null ? (String)ViewState["ButtonText"] : "��ת"; }
            set { ViewState["ButtonText"] = value; }
        }

        #endregion

        #region ======= IStateManager ��Ա =======

        bool IStateManager.IsTrackingViewState
        {
            get
            {
                return this._isTrackingViewState;
            }
        }

        void IStateManager.LoadViewState(object savedState)
        {
            if (savedState != null)
            {
                ((IStateManager)this.ViewState).LoadViewState(savedState);
            }
        }

        object IStateManager.SaveViewState()
        {
            object savedState = null;
            if (this._viewState != null)
            {
                savedState = ((IStateManager)this._viewState).SaveViewState();
            }
            return savedState;
        }

        void IStateManager.TrackViewState()
        {
            this._isTrackingViewState = true;
            if (this._viewState != null)
            {
                ((IStateManager)this._viewState).TrackViewState();
            }
        }

        #endregion
    }
}
