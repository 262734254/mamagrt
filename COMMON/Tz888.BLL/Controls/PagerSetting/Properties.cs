using System;
using System.Web.UI;
using System.ComponentModel;
using System.Web;

namespace OurControl
{
    public partial class MTCPager
    {

        #region ======= ��ҳ��� =======

        #region ======= ������ʽ =======

        [Browsable(true), Description("��ȡ��������ҳ���֡�"), Category("��ҳ���"), DefaultValue("��ҳ")]
        public String FirstPageDescription
        {
            get { return ViewState["FirstPageDescription"] != null ? (String)ViewState["FirstPageDescription"] : "<<"; }
            set { ViewState["FirstPageDescription"] = value; }
        }

        [Browsable(true), Description("��ȡ������ĩҳ���֡�"), Category("��ҳ���"), DefaultValue("βҳ")]
        public String LastPageDescription
        {
            get { return ViewState["LastPageDescription"] != null ? (String)ViewState["LastPageDescription"] : ">>"; }
            set { ViewState["LastPageDescription"] = value; }
        }

        [Browsable(true), Description("��ȡ��������һҳ�֡�"), Category("��ҳ���"), DefaultValue("��һҳ")]
        public String PagePreviousDescription
        {
            get { return ViewState["PagePreviousDescription"] != null ? (String)ViewState["PagePreviousDescription"] : "��һҳ"; }
            set { ViewState["PagePreviousDescription"] = value; }
        }

        [Browsable(true), Description("��ȡ��������һҳ���֡�"), Category("��ҳ���"), DefaultValue("��һҳ")]
        public String PageNextDescription
        {
            get { return ViewState["PageNextDescription"] != null ? (String)ViewState["PageNextDescription"] : "��һҳ"; }
            set { ViewState["PageNextDescription"] = value; }
        }

        [Browsable(true), Description("��ȡ������ǰ�����֡�"), Category("��ҳ���"), DefaultValue("ǰ��")]
        public String PageUpDescription
        {
            get { return ViewState["PageUpDescription"] != null ? (String)ViewState["PageUpDescription"] : "<"; }
            set { ViewState["PageUpDescription"] = value; }
        }

        [Browsable(true), Description("��ȡ�����ú����֡�"), Category("��ҳ���"), DefaultValue("��")]
        public String PageDownDescription
        {
            get { return ViewState["PageDownDescription"] != null ? (String)ViewState["PageDownDescription"] : ">"; }
            set { ViewState["PageDownDescription"] = value; }
        }

        #endregion

        #region ======= Ĭ����ʽ =======

        [Browsable(true), Description("��ȡ�����ÿؼ������塣"), Category("��ҳ���"), DefaultValue("Verdana")]
        public String PagerFontFamily
        {
            get { return ViewState["PagerFontFamily"] != null ? (String)ViewState["PagerFontFamily"] : "Verdana"; }
            set { ViewState["PagerFontFamily"] = value; }
        }

        [Browsable(true), Description("��ȡ�����ÿؼ��������С��"), Category("��ҳ���"), DefaultValue("12px")]
        public String PagerFontSize
        {
            get { return ViewState["PagerFontSize"] != null ? (String)ViewState["PagerFontSize"] : "12px"; }
            set { ViewState["PagerFontSize"] = value; }
        }

        [Browsable(true), Description("��ȡ�����ÿؼ���������ɫ��"), Category("��ҳ���"), DefaultValue("Black")]
        public String PagerFontColor
        {
            get { return ViewState["PagerFontColor"] != null ? (String)ViewState["PagerFontColor"] : "#000000"; }
            set { ViewState["PagerFontColor"] = value; }
        }

        [Browsable(true), Description("��ȡ������λ�ڿؼ�������ߵķ��š�"), Category("��ҳ���"), DefaultValue("")]
        public String PagerLeftText
        {
            get { return ViewState["PagerLeftText"] != null ? (String)ViewState["PagerLeftText"] : String.Empty; }
            set { ViewState["PagerLeftText"] = value; }
        }

        [Browsable(true), Description("��ȡ������λ�ڿؼ������ұߵķ��š�"), Category("��ҳ���"), DefaultValue("")]
        public String PagerRightText
        {
            get { return ViewState["PagerRightText"] != null ? (String)ViewState["PagerRightText"] : String.Empty; }
            set { ViewState["PagerRightText"] = value; }
        }

        #endregion

        #region ======= ҳ����ʽ =======

        [Browsable(true), Description("��ȡ������ҳ�����ɫ��"), Category("��ҳ���"), DefaultValue("Black")]
        public String PageNumberColor
        {
            get { return ViewState["PageNumberColor"] != null ? (String)ViewState["PageNumberColor"] : "#000000"; }
            set { ViewState["PageNumberColor"] = value; }
        }

        [Browsable(true), Description("��ȡ�����õ�ǰѡ��ҳ�����ɫ��"), Category("��ҳ���"), DefaultValue("Red")]
        public String SelectedPageNumberColor
        {
            get { return ViewState["SelectedPageNumberColor"] != null ? (String)ViewState["SelectedPageNumberColor"] : "#FF0000"; }
            set { ViewState["SelectedPageNumberColor"] = value; }
        }

        [Browsable(true), Description("��ȡ������λ��ҳ����ߵķ��š�"), Category("��ҳ���"), DefaultValue("")]
        public String TextBeforePageNumber
        {
            get { return ViewState["TextBeforePageNumber"] != null ? (String)ViewState["TextBeforePageNumber"] : String.Empty; }
            set { ViewState["TextBeforePageNumber"] = value; }
        }

        [Browsable(true), Description("��ȡ������λ��ҳ���ұߵķ��š�"), Category("��ҳ���"), DefaultValue("")]
        public String TextAfterPageNumber
        {
            get { return ViewState["TextAfterPageNumber"] != null ? (String)ViewState["TextAfterPageNumber"] : String.Empty; }
            set { ViewState["TextAfterPageNumber"] = value; }
        }

        //[Browsable(true), Description("��ȡ�����÷�ҳ�ؼ��߶ȡ�"), Category("��ҳ���"), DefaultValue(25)]
        //public int Height
        //{
        //    get { return ViewState["Height"] != null ? (int)ViewState["Height"] : 25; }
        //    set { ViewState["Height"] = value; }
        //}

        private PagingMode _pagingMode;
        /// <summary>
        /// �Զ����ҳ����ʾģʽ
        /// </summary>
        [Description("�Զ����ҳ����ʾģʽ"),
        Category("��ҳ���"),
        NotifyParentProperty(true),
        DefaultValue(typeof(PagingMode), "Default")
        ]
        public virtual PagingMode PagingMode
        {
            get { return _pagingMode; }
            set { _pagingMode = value; }
        }

        #endregion

        #region ======= ��ת������ =======

        private PageJump pageJump;
        [Browsable(true)]
        [Category("��ҳ���")]
        [Description("��ȡ��������ת���������ʽ��")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public PageJump PageJump
        {
            get
            {
                if (pageJump == null)
                {
                    pageJump = new PageJump();
                    // IsTrackingViewState��ȡһ��ֵ������ָʾ�������ؼ��Ƿ�Ὣ���ı��浽����ͼ״̬��
                    if (IsTrackingViewState)
                    {
                        ((IStateManager)pageJump).TrackViewState();
                    }
                }
                return pageJump;
            }
        }

        #endregion

        #endregion

        #region ======= ��ҳ���� =======

        [Browsable(true), Description("��ȡ���������ݼ�¼������"), Category("��ҳ����"), DefaultValue(100)]
        public Int32 RecordCount
        {
            get { return ViewState["RecordCount"] != null ? (Int32)ViewState["RecordCount"] : 100; }
            set { ViewState["RecordCount"] = value; }
        }

        [Browsable(true), Description("��ȡ������ÿҳ��ʾ�ļ�¼������"), Category("��ҳ����"), DefaultValue(10)]
        public Int32 PageSize
        {
            get { return ViewState["PageSize"] != null ? (Int32)ViewState["PageSize"] : 10; }
            set { ViewState["PageSize"] = value; }
        }

        [Browsable(true), Description("��ȡ��ҳ����"), Category("��ҳ����"), DefaultValue(10)]
        public Int32 PageCount
        {
            get { return this.PageSize == 0 ? 0 : (this.RecordCount + this.PageSize - 1) / this.PageSize; }
            //set { value = _pageCount; }_pageCount == null ? 10 : _pageCount; }//
        }

        [Browsable(true), Description("��ȡ�����õ�ǰҳ�롣"), Category("��ҳ����"), DefaultValue(10)]
        public Int32 PageIndex
        {
            get { return ViewState["PageIndex"] != null ? (Int32)ViewState["PageIndex"] : 1; }
            set { ViewState["PageIndex"] = value; }
        }

        [Browsable(true), Description("��ȡ������ÿ����ʾ��ҳ��������"), Category("��ҳ����"), DefaultValue(10)]
        public Int32 ShowPageNumberCount
        {
            get { return ViewState["ShowPageNumberCount"] != null ? (Int32)ViewState["ShowPageNumberCount"] : 6; }
            set { ViewState["ShowPageNumberCount"] = value; }
        }

        [Browsable(true), Description("��ȡ�����õ�ǰ��ID��"), Category("��ID"), DefaultValue(10)]
        public Int32 ParentId
        {
            get { return ViewState["ParentId"] != null ? (Int32)ViewState["ParentId"] : 1; }
            set { ViewState["ParentId"] = value; }
        }

        [Browsable(true), Description("��ȡ�����õ�ǰ����ID��"), Category("����ID"), DefaultValue(10)]
        public Int32 ParentTypeId
        {
            get { return ViewState["ParentTypeId"] != null ? (Int32)ViewState["ParentTypeId"] : 1; }
            set { ViewState["ParentTypeId"] = value; }
        }

        #endregion

    }
}
