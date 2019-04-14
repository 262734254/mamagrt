using System;
using System.Web.UI;
using System.ComponentModel;
using System.Web;

namespace OurControl
{
    public partial class MTCPager
    {

        #region ======= 分页外观 =======

        #region ======= 文字样式 =======

        [Browsable(true), Description("获取或设置首页文字。"), Category("分页外观"), DefaultValue("首页")]
        public String FirstPageDescription
        {
            get { return ViewState["FirstPageDescription"] != null ? (String)ViewState["FirstPageDescription"] : "<<"; }
            set { ViewState["FirstPageDescription"] = value; }
        }

        [Browsable(true), Description("获取或设置末页文字。"), Category("分页外观"), DefaultValue("尾页")]
        public String LastPageDescription
        {
            get { return ViewState["LastPageDescription"] != null ? (String)ViewState["LastPageDescription"] : ">>"; }
            set { ViewState["LastPageDescription"] = value; }
        }

        [Browsable(true), Description("获取或设置上一页字。"), Category("分页外观"), DefaultValue("上一页")]
        public String PagePreviousDescription
        {
            get { return ViewState["PagePreviousDescription"] != null ? (String)ViewState["PagePreviousDescription"] : "上一页"; }
            set { ViewState["PagePreviousDescription"] = value; }
        }

        [Browsable(true), Description("获取或设置下一页文字。"), Category("分页外观"), DefaultValue("下一页")]
        public String PageNextDescription
        {
            get { return ViewState["PageNextDescription"] != null ? (String)ViewState["PageNextDescription"] : "下一页"; }
            set { ViewState["PageNextDescription"] = value; }
        }

        [Browsable(true), Description("获取或设置前翻文字。"), Category("分页外观"), DefaultValue("前翻")]
        public String PageUpDescription
        {
            get { return ViewState["PageUpDescription"] != null ? (String)ViewState["PageUpDescription"] : "<"; }
            set { ViewState["PageUpDescription"] = value; }
        }

        [Browsable(true), Description("获取或设置后翻文字。"), Category("分页外观"), DefaultValue("后翻")]
        public String PageDownDescription
        {
            get { return ViewState["PageDownDescription"] != null ? (String)ViewState["PageDownDescription"] : ">"; }
            set { ViewState["PageDownDescription"] = value; }
        }

        #endregion

        #region ======= 默认样式 =======

        [Browsable(true), Description("获取或设置控件的字体。"), Category("分页外观"), DefaultValue("Verdana")]
        public String PagerFontFamily
        {
            get { return ViewState["PagerFontFamily"] != null ? (String)ViewState["PagerFontFamily"] : "Verdana"; }
            set { ViewState["PagerFontFamily"] = value; }
        }

        [Browsable(true), Description("获取或设置控件的字体大小。"), Category("分页外观"), DefaultValue("12px")]
        public String PagerFontSize
        {
            get { return ViewState["PagerFontSize"] != null ? (String)ViewState["PagerFontSize"] : "12px"; }
            set { ViewState["PagerFontSize"] = value; }
        }

        [Browsable(true), Description("获取或设置控件的字体颜色。"), Category("分页外观"), DefaultValue("Black")]
        public String PagerFontColor
        {
            get { return ViewState["PagerFontColor"] != null ? (String)ViewState["PagerFontColor"] : "#000000"; }
            set { ViewState["PagerFontColor"] = value; }
        }

        [Browsable(true), Description("获取或设置位于控件字体左边的符号。"), Category("分页外观"), DefaultValue("")]
        public String PagerLeftText
        {
            get { return ViewState["PagerLeftText"] != null ? (String)ViewState["PagerLeftText"] : String.Empty; }
            set { ViewState["PagerLeftText"] = value; }
        }

        [Browsable(true), Description("获取或设置位于控件字体右边的符号。"), Category("分页外观"), DefaultValue("")]
        public String PagerRightText
        {
            get { return ViewState["PagerRightText"] != null ? (String)ViewState["PagerRightText"] : String.Empty; }
            set { ViewState["PagerRightText"] = value; }
        }

        #endregion

        #region ======= 页码样式 =======

        [Browsable(true), Description("获取或设置页码的颜色。"), Category("分页外观"), DefaultValue("Black")]
        public String PageNumberColor
        {
            get { return ViewState["PageNumberColor"] != null ? (String)ViewState["PageNumberColor"] : "#000000"; }
            set { ViewState["PageNumberColor"] = value; }
        }

        [Browsable(true), Description("获取或设置当前选中页码的颜色。"), Category("分页外观"), DefaultValue("Red")]
        public String SelectedPageNumberColor
        {
            get { return ViewState["SelectedPageNumberColor"] != null ? (String)ViewState["SelectedPageNumberColor"] : "#FF0000"; }
            set { ViewState["SelectedPageNumberColor"] = value; }
        }

        [Browsable(true), Description("获取或设置位于页码左边的符号。"), Category("分页外观"), DefaultValue("")]
        public String TextBeforePageNumber
        {
            get { return ViewState["TextBeforePageNumber"] != null ? (String)ViewState["TextBeforePageNumber"] : String.Empty; }
            set { ViewState["TextBeforePageNumber"] = value; }
        }

        [Browsable(true), Description("获取或设置位于页码右边的符号。"), Category("分页外观"), DefaultValue("")]
        public String TextAfterPageNumber
        {
            get { return ViewState["TextAfterPageNumber"] != null ? (String)ViewState["TextAfterPageNumber"] : String.Empty; }
            set { ViewState["TextAfterPageNumber"] = value; }
        }

        //[Browsable(true), Description("获取或设置分页控件高度。"), Category("分页外观"), DefaultValue(25)]
        //public int Height
        //{
        //    get { return ViewState["Height"] != null ? (int)ViewState["Height"] : 25; }
        //    set { ViewState["Height"] = value; }
        //}

        private PagingMode _pagingMode;
        /// <summary>
        /// 自定义分页的显示模式
        /// </summary>
        [Description("自定义分页的显示模式"),
        Category("分页外观"),
        NotifyParentProperty(true),
        DefaultValue(typeof(PagingMode), "Default")
        ]
        public virtual PagingMode PagingMode
        {
            get { return _pagingMode; }
            set { _pagingMode = value; }
        }

        #endregion

        #region ======= 跳转索引框 =======

        private PageJump pageJump;
        [Browsable(true)]
        [Category("分页外观")]
        [Description("获取或设置跳转索引框的样式。")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public PageJump PageJump
        {
            get
            {
                if (pageJump == null)
                {
                    pageJump = new PageJump();
                    // IsTrackingViewState获取一个值，用于指示服务器控件是否会将更改保存到其视图状态中
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

        #region ======= 分页数据 =======

        [Browsable(true), Description("获取或设置数据记录总数。"), Category("分页数据"), DefaultValue(100)]
        public Int32 RecordCount
        {
            get { return ViewState["RecordCount"] != null ? (Int32)ViewState["RecordCount"] : 100; }
            set { ViewState["RecordCount"] = value; }
        }

        [Browsable(true), Description("获取或设置每页显示的记录数量。"), Category("分页数据"), DefaultValue(10)]
        public Int32 PageSize
        {
            get { return ViewState["PageSize"] != null ? (Int32)ViewState["PageSize"] : 10; }
            set { ViewState["PageSize"] = value; }
        }

        [Browsable(true), Description("获取总页数。"), Category("分页数据"), DefaultValue(10)]
        public Int32 PageCount
        {
            get { return this.PageSize == 0 ? 0 : (this.RecordCount + this.PageSize - 1) / this.PageSize; }
            //set { value = _pageCount; }_pageCount == null ? 10 : _pageCount; }//
        }

        [Browsable(true), Description("获取或设置当前页码。"), Category("分页数据"), DefaultValue(10)]
        public Int32 PageIndex
        {
            get { return ViewState["PageIndex"] != null ? (Int32)ViewState["PageIndex"] : 1; }
            set { ViewState["PageIndex"] = value; }
        }

        [Browsable(true), Description("获取或设置每次显示的页码数量。"), Category("分页数据"), DefaultValue(10)]
        public Int32 ShowPageNumberCount
        {
            get { return ViewState["ShowPageNumberCount"] != null ? (Int32)ViewState["ShowPageNumberCount"] : 6; }
            set { ViewState["ShowPageNumberCount"] = value; }
        }

        [Browsable(true), Description("获取或设置当前父ID。"), Category("父ID"), DefaultValue(10)]
        public Int32 ParentId
        {
            get { return ViewState["ParentId"] != null ? (Int32)ViewState["ParentId"] : 1; }
            set { ViewState["ParentId"] = value; }
        }

        [Browsable(true), Description("获取或设置当前父父ID。"), Category("父父ID"), DefaultValue(10)]
        public Int32 ParentTypeId
        {
            get { return ViewState["ParentTypeId"] != null ? (Int32)ViewState["ParentTypeId"] : 1; }
            set { ViewState["ParentTypeId"] = value; }
        }

        #endregion

    }
}
