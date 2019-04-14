using System;
using System.Web;
using System.IO;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;



/////////////////////////////////////////////////////////////////////////
////                                                                 ////
////    Name:Pager                                                   ////
////    Model:Server/Ajax                                            ////
////    Support Control:GridView/Repeater/BaseDataList/ListControl   ////
////    Authors:Clandy.lee                                           ////
////    Version:1.0 bate1                                            ////
////    CreateDate:2007-9-15                                         ////
////                                                                 ////
/////////////////////////////////////////////////////////////////////////

//[assembly: System.Web.UI.WebResource("Tz888.Common.Pager.PagerScrpit.js", "text/javascript")]
namespace Tz888.Common.Pager
{
    #region 使用Cache选项
    /// <summary>
    /// 分页缓存设置
    /// </summary>
    public enum PagingMode
    {
        /// <summary>
        /// 需要缓存
        /// </summary>
        Cached,
        /// <summary>
        /// 禁用缓存
        /// </summary>
        NonCached
    }
    #endregion

    #region 页面样式
    /// <summary>
    /// 页面样式设置
    /// </summary>
    public enum PagerStyle
    {
        /// <summary>
        /// 按钮样式为上下页箭头
        /// </summary>
        NextPrev,
        /// <summary>
        /// 按钮样式来下拉框页码
        /// </summary>
        NumericPages,
        /// <summary>
        /// 按钮和下拉框页码一起显示
        /// </summary>
        NextAndNumeric,
        /// <summary>
        /// 自定义样式，可自定文本
        /// </summary>
        CustomStyle,
        /// <summary>
        /// 自定义样式，可自定文本，同时显示下拉页码
        /// </summary>
        CustomAndNumeric,
        /// <summary>
        /// 无刷新箭头式按钮
        /// </summary>
        AjaxNext,
        /// <summary>
        /// 无刷新箭头式按钮加下拉页码
        /// </summary>
        AjaxNextAndNum,
        /// <summary>
        /// 无刷新下拉框按钮
        /// </summary>
        AjaxNumeric,
        /// <summary>
        /// 自定义无刷新分页
        /// </summary>
        AjaxCustomPages,
        /// <summary>
        /// 自定义无刷新和下拉框页码
        /// </summary>
        AjaxCustomAndNumeric
    }
    #endregion

    #region 排序方式
    /// <summary>
    /// 排序方式
    /// </summary>
    public enum SortType
    {
        /// <summary>
        /// 升序
        /// </summary>
        ASC,
        /// <summary>
        /// 降序
        /// </summary>
        DESC
    }
    #endregion

    #region 实际记录数
    /// <summary>
    /// 实际记录数
    /// </summary>
    public class VirtualRecordCount
    {
        /// <summary>
        /// 记录数
        /// </summary>
        public int RecordCount;
        /// <summary>
        /// 页数
        /// </summary>
        public int PageCount;
        /// <summary>
        /// 最后一页的记录数
        /// </summary>
        public int RecordsInLastPage;
    }
    #endregion

    #region 页面跳转事件
    /// <summary>
    /// 页面跳转事件
    /// </summary>
    public class PageChangedEventArgs : EventArgs
    {
        /// <summary>
        /// 当前页面索引
        /// </summary>
        public int OldPageIndex;
        /// <summary>
        /// 新页面索引
        /// </summary>
        public int NewPageIndex;
    }
    #endregion

    #region Pager分页控件
    /// <summary>
    /// Pager分页控件
    /// </summary>
    [DefaultEvent("PageIndexChanged")]
    [ToolboxData("<{0}:Pager runat=\"server\" />")]
    public class Pager : WebControl, INamingContainer
    {
        private PagedDataSource _dataSource;
        private Control _controlToPaginate;
        static private DataSet _customDataSource = null;
        private int _totalCount;//总记录数

        private Tz888.BLL.Conn SqlConn = new Tz888.BLL.Conn();


        private string CacheKeyName
        {
            get { return Page.Request.FilePath + "_" + UniqueID + "_Data"; }
        }

        private string CurrentPageText = "第<font color=#ff0000>{0}</font>页/总<font color=#ff0000>{1}</font>页 [每页<font color=#ff0000>{2}</font>条/共<font color=#ff0000>{3}</font>条记录]";
        //private string CurrentPageText = "第<font color=#ff0000>{0}</font>页/总<font color=#ff0000>{1}</font>页";
        private string NoPageSelectedText = "没有选择页面.";

        #region 构造函数，初始化数据
        /// <summary>
        /// 构造函数，初始化数据
        /// </summary>
        public Pager()
            : base()
        {
            _dataSource = null;
            _controlToPaginate = null;
            Font.Name = "verdana";
            //Font.Size = FontUnit.Point(8);
            BackColor = Color.Gainsboro;
            ForeColor = Color.Black;
            BorderStyle = BorderStyle.Outset;
            BorderWidth = Unit.Parse("1px");
            PagingMode = PagingMode.Cached;
            SortType = SortType.ASC;
            PagerStyle = PagerStyle.NextPrev;
            CurrentPageIndex = 0;
            UseCustomDataSource = false;
            PageSize = 10;
            TotalPages = -1;
            CacheDuration = 60;
            ShowPageCount = true;

            TableViewName = "";
            SelectColumns = "*";
            SortColumn = "";
            StrWhere = "";
            KeyColumn = "";

            FirstButton = "第一页";
            PrveButton = "上一页";
            NextButton = "下一页";
            LastButton = "最后页";

            ControlToAjaxPanel = "";
        }
        #endregion

        #region 公共程序接口，属性
        // ***********************************************************************
        /// <summary>
        /// 清除Cache中所有数据
        /// </summary>
        public void ClearCache()
        {
            if (PagingMode == PagingMode.Cached)
                Page.Cache.Remove(CacheKeyName);
        }
        // ***********************************************************************

        // ***********************************************************************

        /// <summary>
        /// 页面跳转事件，当页面跳转到新页面时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void PageChangedEventHandler(object sender, PageChangedEventArgs e);
        /// <summary>
        /// 页面跳转事件，当页面索引改变时触发
        /// </summary>
        public event PageChangedEventHandler PageIndexChanged;
        /// <summary>
        /// 页面跳转事件，当页面索引改变时触发
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnPageIndexChanged(PageChangedEventArgs e)
        {
            if (PageIndexChanged != null)
                PageIndexChanged(this, e);
        }
        // ***********************************************************************

        // ***********************************************************************

        /// <summary>
        /// 设置数据源的表或视图名
        /// </summary>
        [Description("设置数据源的表或视图名")]
        public string TableViewName
        {
            get { return this.ViewState["TableViewName"].ToString(); }
            set { this.ViewState["TableViewName"] = value; }
        }

        /// <summary>
        /// 设置需要提取的数据字段名，多字段以英文半角逗号","分隔
        /// </summary>
        [Description("设置需要提取的数据字段名，多字段以英文半角" + ", " + "分隔")]
        public string SelectColumns
        {
            get { return this.ViewState["SelectColumns"].ToString(); }
            set { this.ViewState["SelectColumns"] = value; }
        }

        /// <summary>
        /// 表或视图的索引列
        /// </summary>
        [Description("表或视图的索引列")]
        public string KeyColumn
        {
            get { return this.ViewState["KeyColumn"].ToString(); }
            set { this.ViewState["KeyColumn"] = value; }
        }

        /// <summary>
        /// 设置排序关键字
        /// </summary>
        [Description("设置排序关键字，在NonCached模式下使用.")]
        public string SortColumn
        {
            get { return this.ViewState["SortColumn"].ToString(); }
            set { this.ViewState["SortColumn"] = value; }
        }

        /// <summary>
        /// 设置每页显示记录数
        /// </summary>
        [Description("设置每页显示记录数")]
        public int PageSize
        {
            get { return Convert.ToInt32(this.ViewState["PageSize"]); }
            set { this.ViewState["PageSize"] = value; }
        }

        /// <summary>
        /// 设置排序方式，升、降（默认为升序）
        /// </summary>
        [Description("设置排序方式，升、降（默认为升序）")]
        public SortType SortType
        {
            get { return (SortType)ViewState["SortType"]; }
            set { ViewState["SortType"] = value; }
        }
        
        /// <summary>
        /// 设置查询条件
        /// </summary>
        [Description("设置查询条件")]
        public string StrWhere
        {
            get { return this.ViewState["StrWhere"].ToString(); }
            set { this.ViewState["StrWhere"] = value; }
        }

        // ***********************************************************************

        /// <summary>
        /// 第一页的按钮样式
        /// </summary>
        [Description("第一页的按钮样式")]
        public string FirstButton
        {
            get { return ViewState["FirstButton"].ToString(); }
            set { ViewState["FirstButton"] = value; }
        }
        /// <summary>
        /// 上一页的按钮样式
        /// </summary>
        [Description("上一页的按钮样式")]
        public string PrveButton
        {
            get { return ViewState["PrveButton"].ToString(); }
            set { ViewState["PrveButton"] = value; }
        }
        /// <summary>
        /// 下一页的按钮样式
        /// </summary>
        [Description("下一页的按钮样式")]
        public string NextButton
        {
            get { return ViewState["NextButton"].ToString(); }
            set { ViewState["NextButton"] = value; }
        }
        /// <summary>
        /// 最后一页的按钮样式
        /// </summary>
        [Description("最后一页的按钮样式")]
        public string LastButton
        {
            get { return ViewState["LastButton"].ToString(); }
            set { ViewState["LastButton"] = value; }
        }

        /// <summary>
        /// 缓存持续时间
        /// </summary>
        [Description("设置缓存的持续时间")]
        public int CacheDuration
        {
            get { return Convert.ToInt32(ViewState["CacheDuration"]); }
            set { ViewState["CacheDuration"] = value; }
        }
        // ***********************************************************************

        // ***********************************************************************
        /// <summary>
        /// 是否显示统计页数
        /// </summary>
        [Description("是否显示统计页数")]
        public bool ShowPageCount
        {
            get { return Convert.ToBoolean(ViewState["ShowPageCount"]); }
            set { ViewState["ShowPageCount"] = value; }
        }
        // ***********************************************************************

        // ***********************************************************************
        /// <summary>
        /// 是否显示统计记录条数
        /// </summary>
        [Description("是否显示统计记录条数")]
        public bool ShowCount
        {
            get { return Convert.ToBoolean(ViewState["ShowCount"]); }
            set { ViewState["ShowCount"] = value; }
        }
        // ***********************************************************************

        // ***********************************************************************
        /// <summary>
        /// 分页缓存使用设置
        /// </summary>
        [Description("是否启用分页缓存")]
        public PagingMode PagingMode
        {
            get { return (PagingMode)ViewState["PagingMode"]; }
            set { ViewState["PagingMode"] = value; }
        }
        // ***********************************************************************

        // ***********************************************************************
        /// <summary>
        /// 设置一次性获取数据的最大记录数(启用缓存时使用)
        /// </summary>
        [Description("设置一次性获取数据的最大记录数(启用缓存时使用)")]
        public int MaxNoteCount
        {
            get { return Convert.ToInt32(ViewState["MaxNoteCount"]); }
            set { ViewState["MaxNoteCount"] = value; }
        }
        // ***********************************************************************

        // ***********************************************************************
        /// <summary>
        /// 分页样式设置，显示上、下分页还是下拉框页码
        /// </summary>
        [Description("设置分页按钮样式")]
        public PagerStyle PagerStyle
        {
            get { return (PagerStyle)ViewState["PagerStyle"]; }
            set { ViewState["PagerStyle"] = value; }
        }
        // ***********************************************************************

        // ***********************************************************************
        /// <summary>
        /// 设置Ajax分页模式中承载数据显示控件的容器ID(推荐使用DIV)
        /// </summary>
        [Description("设置Ajax分页模式中承载数据显示控件的容器ID(推荐使用DIV)")]
        public string ControlToAjaxPanel
        {
            get { return Convert.ToString(ViewState["ControlToAjaxPanel"]); }
            set { ViewState["ControlToAjaxPanel"] = value; }
        }
        // ***********************************************************************

        // ***********************************************************************
        /// <summary>
        /// 设置关联控件的ID
        /// </summary>
        [Description("设置关联数据列表控件的ID")]
        public string ControlToPaginate
        {
            get { return Convert.ToString(ViewState["ControlToPaginate"]); }
            set { ViewState["ControlToPaginate"] = value; }
        }
        // ***********************************************************************

        // ***********************************************************************
        /// <summary>
        /// 控件所在子容器的ID(母板页子页面使用)
        /// </summary>
        [Description("控件所在子容器的ID(母板页子页面使用)")]
        public string ContentPlaceHolder
        {
            get { return Convert.ToString(ViewState["ContentPlaceHolder"]); }
            set { ViewState["ContentPlaceHolder"] = value; }
        }
        // ***********************************************************************

        // ***********************************************************************
        /// <summary>
        /// 设置当前页面索引
        /// </summary>
        [Description("当前页面索引")]
        public int CurrentPageIndex
        {
            get { return Convert.ToInt32(ViewState["CurrentPageIndex"]); }
            set { ViewState["CurrentPageIndex"] = value; }
        }
        // ***********************************************************************

        // ***********************************************************************
        /// <summary>
        /// 获取页面大小，总共需显示的记录数
        /// </summary>
        [Browsable(false)]
        public int PageCount
        {
            get { return TotalPages; }
        }
        /// <summary>
        /// 是否使用自定义数据源
        /// </summary>
        [Description("是否使用自定义数据源")]
        public bool UseCustomDataSource
        {
            get { return Convert.ToBoolean(ViewState["UseCustomDataSource"]); }
            set { ViewState["UseCustomDataSource"] = value; }
        }

        /// <summary>
        /// 设置自定义数据源
        /// </summary>
        [Browsable(false)]
        public DataSet CustomDataSource
        {
            set { _customDataSource = value; }
        }
        // ***********************************************************************

        // ***********************************************************************
        /// <summary>
        /// 设置获取总页数
        /// </summary>
        public int TotalPages
        {
            get { return Convert.ToInt32(ViewState["TotalPages"]); }
            set { ViewState["TotalPages"] = value; }
        }
        // ***********************************************************************

        // ***********************************************************************
        /// <summary>
        /// 数据绑定，取出并排序数据
        /// </summary>
        public override void DataBind()
        {
            // 开始绑定事件
            base.DataBind();

            // 是否生成子控件　Controls must be recreated after data binding 
            ChildControlsCreated = false;

            // 确保控件存在并且是一个合法的数据容器控件
            if (ControlToPaginate == "")
                return;
            //判断当前页面时候为母板页生成
            if (Page.Master == null)
                _controlToPaginate = Page.FindControl(ControlToPaginate);
            else
            {
                if(!string.IsNullOrEmpty(ContentPlaceHolder))
                    _controlToPaginate = Page.Form.FindControl(ContentPlaceHolder).FindControl(ControlToPaginate);
                else
                    _controlToPaginate = Page.FindControl(ControlToPaginate);
            }

            if (_controlToPaginate == null)
                return;
            if (!(_controlToPaginate is BaseDataList || _controlToPaginate is GridView || _controlToPaginate is ListControl || _controlToPaginate is Repeater))
                return;

            // 确保有查询条件
            if (UseCustomDataSource && _customDataSource == null)
                return;

            if ((this.TableViewName == "" || this.SelectColumns == "" || this.SortColumn == "") && !UseCustomDataSource)
                return;

            //判断查询条件是否改变
            if (!UseCustomDataSource)
            {
                if (ViewState["OldStrWhere"] == null)
                    ViewState["OldStrWhere"] = ViewState["StrWhere"].ToString();
                else
                {
                    if (ViewState["OldStrWhere"].ToString().Trim() != ViewState["StrWhere"].ToString().Trim())
                    {
                        CurrentPageIndex = 0;
                        ViewState["OldStrWhere"] = ViewState["StrWhere"].ToString();
                    }
                }
            }

            // 获取数据
            if (PagingMode == PagingMode.Cached)
                FetchAllData();
            else
            {
                FetchPageData();
            }

            // 向控件绑定数据
            BaseDataList baseDataListControl = null;
            ListControl listControl = null;
            Repeater rp = null;
            GridView gv = null;
            if (_controlToPaginate is BaseDataList)
            {
                baseDataListControl = (BaseDataList)_controlToPaginate;
                baseDataListControl.DataSource = _dataSource;
                baseDataListControl.DataBind();
                return;
            }
            if (_controlToPaginate is ListControl)
            {
                listControl = (ListControl)_controlToPaginate;
                listControl.Items.Clear();
                listControl.DataSource = _dataSource;
                listControl.DataBind();
                return;
            }
            if (_controlToPaginate is Repeater)
            {
                rp = (Repeater)_controlToPaginate;
                rp.DataSource = _dataSource;
                rp.DataBind();
            }
            if (_controlToPaginate is GridView)
            {
                gv = (GridView)_controlToPaginate;
                gv.DataSource = _dataSource;
                gv.DataBind();
            }
        }
        // ***********************************************************************

        // ***********************************************************************
        /// <summary>
        /// 将内容呈现在客户端
        /// </summary>
        /// <param name="output"></param> 
        protected override void Render(HtmlTextWriter output)
        {
            if (Site != null && Site.DesignMode)
                CreateChildControls();

            base.Render(output);
        }
        /// <summary>
        /// 将控件呈现于页面，用于AJAX分页
        /// </summary>
        /// <param name="output"></param>
        public override void RenderControl(HtmlTextWriter output)
        {
            CreateChildControls();
            base.Render(output);
        }
        // ***********************************************************************

        // ***********************************************************************
        /// <summary>
        /// 重写CreateChildControls，输出HTML代码
        /// </summary>
        protected override void CreateChildControls()
        {
            Controls.Clear();
            ClearChildViewState();
            if (PagerStyle == PagerStyle.AjaxCustomPages)
                BuildAjaxControl();
            else
                BuildControlHierarchy();
        }
        // ***********************************************************************
        #endregion

        #region 私有方法
        /// <summary>
        /// 创建分页导航按钮
        /// </summary>
        private void BuildControlHierarchy()
        {
            // 创建一个表 (一行，二列)
            Table t = new Table();
            t.Font.Name = Font.Name;
            t.Font.Size = Font.Size;
            t.BorderStyle = BorderStyle;
            t.BorderWidth = BorderWidth;
            t.BorderColor = BorderColor;
            t.Width = Width;
            t.Height = Height;
            t.BackColor = BackColor;
            t.ForeColor = ForeColor;
            //指定样式名称
            t.CssClass = "PageButton";

            //// 创建空行与列
            //TableRow breakRow = new TableRow();
            //t.Rows.Add(breakRow);
            //TableCell breakCell = new TableCell();
            //breakCell.Height = Unit.Pixel(10);
            //breakRow.Cells.Add(breakCell);


            // 创建行
            TableRow row = new TableRow();
            t.Rows.Add(row);

            // 为页索引创建列
            TableCell cellPageDesc = new TableCell();
            cellPageDesc.HorizontalAlign = HorizontalAlign.Left;
            //cellPageDesc.Width = Unit.Percentage(80);
            BuildCurrentPage(cellPageDesc);
            row.Cells.Add(cellPageDesc);

            // 为导航条创建列
            TableCell cellNavBar = new TableCell();
            cellNavBar.HorizontalAlign = HorizontalAlign.Right;
            switch (PagerStyle)
            {
                case PagerStyle.NextPrev:
                    BuildNextPrevUI(cellNavBar);
                    break;
                case PagerStyle.NumericPages:
                    BuildNumericPagesUI(cellNavBar);
                    break;
                case PagerStyle.NextAndNumeric:
                    BuildNextPrevUI(cellNavBar);
                    cellNavBar.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;&nbsp;选择页："));
                    BuildNumericPagesUI(cellNavBar);
                    break;
                case PagerStyle.CustomStyle:
                    BuildCustomUI(cellNavBar);
                    break;
                case PagerStyle.CustomAndNumeric:
                    BuildCustomUI(cellNavBar);
                    cellNavBar.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;&nbsp;选择页："));
                    BuildNumericPagesUI(cellNavBar);
                    break;
                case PagerStyle.AjaxNext:
                    BuildAjaxNextUI(cellNavBar);
                    break;
                case PagerStyle.AjaxNumeric:
                    BuildAjaxNumericUI(cellNavBar);
                    break;
                case PagerStyle.AjaxCustomPages:
                    BuildAjaxCustomUI(cellNavBar);
                    break;
                case PagerStyle.AjaxCustomAndNumeric:
                    BuildAjaxCustomUI(cellNavBar);
                    cellNavBar.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;&nbsp;选择页："));
                    BuildAjaxNumericUI(cellNavBar);
                    break;
                case PagerStyle.AjaxNextAndNum:
                    BuildAjaxNextUI(cellNavBar);
                    cellNavBar.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;&nbsp;选择页："));
                    BuildAjaxNumericUI(cellNavBar);
                    break;
            }
            row.Cells.Add(cellNavBar);

            // 将表加入到控件树
            Controls.Add(t);
        }
        /// <summary>
        /// 为Ajax创建自定义分页导航按钮
        /// </summary>
        public void BuildAjaxControl()
        {
            // 创建一个表 (一行，二列)
            Table t = new Table();
            t.Font.Name = Font.Name;
            t.Font.Size = Font.Size;
            t.BorderStyle = BorderStyle;
            t.BorderWidth = BorderWidth;
            t.BorderColor = BorderColor;
            t.Width = Width;
            t.Height = Height;
            t.BackColor = BackColor;
            t.ForeColor = ForeColor;
            //指定样式名称
            t.CssClass = "PageButton";

            // 创建空行与列
            TableRow breakRow = new TableRow();
            t.Rows.Add(breakRow);
            TableCell breakCell = new TableCell();
            breakCell.Height = Unit.Pixel(10);
            breakRow.Cells.Add(breakCell);

            // 创建行
            TableRow row = new TableRow();
            t.Rows.Add(row);

            // 为页索引创建列
            TableCell cellPageDesc = new TableCell();
            cellPageDesc.HorizontalAlign = HorizontalAlign.Left;
            BuildCurrentPage(cellPageDesc);
            row.Cells.Add(cellPageDesc);

            // 为导航条创建列
            TableCell cellNavBar = new TableCell();
            cellNavBar.HorizontalAlign = HorizontalAlign.Right;
            switch (PagerStyle)
            {
                case PagerStyle.AjaxNext:
                    BuildAjaxNextUI(cellNavBar);
                    break;
                case PagerStyle.AjaxNumeric:
                    BuildAjaxNumericUI(cellNavBar);
                    break;
                case PagerStyle.AjaxCustomPages:
                    BuildAjaxCustomUI(cellNavBar);
                    break;
                case PagerStyle.AjaxCustomAndNumeric:
                    BuildAjaxCustomUI(cellNavBar);
                    cellNavBar.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;&nbsp;选择页："));
                    BuildAjaxNumericUI(cellNavBar);
                    break;
                case PagerStyle.AjaxNextAndNum:
                    BuildAjaxNextUI(cellNavBar);
                    cellNavBar.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;&nbsp;选择页："));
                    BuildAjaxNumericUI(cellNavBar);
                    break;
            }
            row.Cells.Add(cellNavBar);

            Controls.Add(t);
        }

        #region Ajax无刷新按钮
        /// <summary>
        /// 创建箭头按钮
        /// </summary>
        /// <param name="cell">表格列对象</param>
        private void BuildAjaxNextUI(TableCell cell)
        {
            bool isValidPage = (CurrentPageIndex >= 0 && CurrentPageIndex <= TotalPages - 1);
            bool canMoveBack = (CurrentPageIndex > 0);
            bool canMoveForward = (CurrentPageIndex < TotalPages - 1);

            // 呈现 > 按钮
            LinkButton first = new LinkButton();
            first.ID = "First";
            first.Attributes.Add("onclick", "setPageTo(" + Convert.ToString(0) + ",'" + ControlToAjaxPanel + "');return false;");
            first.Font.Name = "webdings";
            //first.Font.Size = FontUnit.Medium;
            first.ForeColor = ForeColor;
            first.ToolTip = "第一页";
            first.Text = "7";
            first.Enabled = isValidPage && canMoveBack;
            cell.Controls.Add(first);

            // 添加一个空格
            cell.Controls.Add(new LiteralControl("&nbsp;"));

            // 呈现 << 按钮
            LinkButton prev = new LinkButton();
            prev.ID = "Prev";
            prev.Attributes.Add("onclick", "setPageTo(" + Convert.ToString(CurrentPageIndex - 1) + ",'" + ControlToAjaxPanel + "');return false;");
            prev.Font.Name = "webdings";
            //prev.Font.Size = FontUnit.Medium;
            prev.ForeColor = ForeColor;
            prev.ToolTip = "上一页";
            prev.Text = "3";
            prev.Enabled = isValidPage && canMoveBack;
            cell.Controls.Add(prev);

            // 添加一个空格
            cell.Controls.Add(new LiteralControl("&nbsp;"));

            // 呈现 > 按钮
            LinkButton next = new LinkButton();
            next.ID = "Next";
            next.Attributes.Add("onclick", "setPageTo(" + Convert.ToString(CurrentPageIndex + 1) + ",'" + ControlToAjaxPanel + "');return false;");
            next.Font.Name = "webdings";
            //next.Font.Size = FontUnit.Medium;
            next.ForeColor = ForeColor;
            next.ToolTip = "下一页";
            next.Text = "4";
            next.Enabled = isValidPage && canMoveForward;
            cell.Controls.Add(next);

            // 添加一个空格
            cell.Controls.Add(new LiteralControl("&nbsp;"));

            // 呈现 >> 按钮
            LinkButton last = new LinkButton();
            last.ID = "Last";
            last.Attributes.Add("onclick", "setPageTo(" + Convert.ToString(TotalPages - 1) + ",'" + ControlToAjaxPanel + "');return false;");
            last.Font.Name = "webdings";
            //last.Font.Size = FontUnit.Medium;
            last.ForeColor = ForeColor;
            last.ToolTip = "最末页";
            last.Text = "8";
            last.Enabled = isValidPage && canMoveForward;
            cell.Controls.Add(last);
        }
        /// <summary>
        /// 无刷新分页按钮
        /// </summary>
        /// <param name="cell">表格列对象</param>
        private void BuildAjaxCustomUI(TableCell cell)
        {
            bool isValidPage = (CurrentPageIndex >= 0 && CurrentPageIndex <= TotalPages - 1);
            bool canMoveBack = (CurrentPageIndex > 0);
            bool canMoveForward = (CurrentPageIndex < TotalPages - 1);

            LinkButton first = new LinkButton();
            first.ID = "First";
            //first.Click += new EventHandler(first_Click);
            first.Attributes.Add("onclick", "setPageTo(" + Convert.ToString(0) + ",'" + ControlToAjaxPanel + "');return false;");
            //first.Font.Name = "webdings";
            //first.Font.Size = Font.Size;
            first.ForeColor = ForeColor;
            first.ToolTip = "第一页";
            first.Text = FirstButton;
            first.Enabled = isValidPage && canMoveBack;
            cell.Controls.Add(first);

            // 添加一个空格
            cell.Controls.Add(new LiteralControl("&nbsp;"));

            LinkButton prev = new LinkButton();
            prev.ID = "Prev";
            //prev.Click += new EventHandler(prev_Click);
            prev.Attributes.Add("onclick", "setPageTo(" + Convert.ToString(CurrentPageIndex - 1) + ",'" + ControlToAjaxPanel + "');return false;");
            //prev.Font.Name = "webdings";
            //prev.Font.Size = Font.Size;
            prev.ForeColor = ForeColor;
            prev.ToolTip = "上一页";
            prev.Text = PrveButton;
            prev.Enabled = isValidPage && canMoveBack;
            cell.Controls.Add(prev);

            cell.Controls.Add(new LiteralControl("&nbsp;"));

            LinkButton next = new LinkButton();
            next.ID = "Next";
            next.Click += new EventHandler(next_Click);
            next.Attributes.Add("onclick", "setPageTo(" + Convert.ToString(CurrentPageIndex + 1) + ",'" + ControlToAjaxPanel + "');return false;");
            //next.Font.Name = "webdings";
            //next.Font.Size = Font.Size;
            next.ForeColor = ForeColor;
            next.ToolTip = "下一页";
            next.Text = NextButton;
            next.Enabled = isValidPage && canMoveForward;
            cell.Controls.Add(next);

            // 添加一个空格
            cell.Controls.Add(new LiteralControl("&nbsp;"));


            LinkButton last = new LinkButton();
            last.ID = "Last";
            //last.Click += new EventHandler(last_Click);
            last.Attributes.Add("onclick", "setPageTo(" + Convert.ToString(TotalPages - 1) + ",'" + ControlToAjaxPanel + "');return false;");
            //last.Font.Name = "webdings";
            //last.Font.Size = Font.Size;
            last.ForeColor = ForeColor;
            last.ToolTip = "最末页";
            last.Text = LastButton;
            last.Enabled = isValidPage && canMoveForward;
            cell.Controls.Add(last);
        }
        /// <summary>
        /// 无刷新下拉框页码显示
        /// </summary>
        /// <param name="cell">列对象</param>
        private void BuildAjaxNumericUI(TableCell cell)
        {
            // 呈现一个下拉框列表
            DropDownList pageList = new DropDownList();
            pageList.ID = "PageList";
            pageList.AutoPostBack = false;
            //pageList.SelectedIndexChanged += new EventHandler(PageList_Click);
            pageList.Attributes.Add("onchange", "setPageTo(this.value,'" + ControlToAjaxPanel + "');return false;");
            pageList.Font.Name = Font.Name;
            //pageList.Font.Size = Font.Size;
            pageList.ForeColor = ForeColor;

            // 当无分页数据时，设置一个默认值
            if (TotalPages <= 0 || CurrentPageIndex == -1)
            {
                pageList.Items.Add("无分页");
                pageList.Enabled = false;
                pageList.SelectedIndex = 0;
            }
            else // 移动列表
            {
                for (int i = 1; i <= TotalPages; i++)
                {
                    ListItem item = new ListItem(i.ToString(), (i - 1).ToString());
                    pageList.Items.Add(item);
                }
                pageList.SelectedIndex = CurrentPageIndex;
            }
            cell.Controls.Add(pageList);
        }
        #endregion

        #region 服务器后台运行按钮
        /// <summary>
        /// 创建自定义按钮
        /// </summary>
        /// <param name="cell">表格列对象</param>
        private void BuildCustomUI(TableCell cell)
        {
            bool isValidPage = (CurrentPageIndex >= 0 && CurrentPageIndex <= TotalPages - 1);
            bool canMoveBack = (CurrentPageIndex > 0);
            bool canMoveForward = (CurrentPageIndex < TotalPages - 1);

            LinkButton first = new LinkButton();
            first.ID = "First";
            first.Click += new EventHandler(first_Click);
            //first.Font.Name = "webdings";
            //first.Font.Size = Font.Size;
            first.ForeColor = ForeColor;
            first.ToolTip = "第一页";
            first.Text = FirstButton;
            first.Enabled = isValidPage && canMoveBack;
            cell.Controls.Add(first);

            // 添加一个空格
            cell.Controls.Add(new LiteralControl("&nbsp;"));

            LinkButton prev = new LinkButton();
            prev.ID = "Prev";
            prev.Click += new EventHandler(prev_Click);
            //prev.Font.Name = "webdings";
            //prev.Font.Size = Font.Size;
            prev.ForeColor = ForeColor;
            prev.ToolTip = "上一页";
            prev.Text = PrveButton;
            prev.Enabled = isValidPage && canMoveBack;
            cell.Controls.Add(prev);

            cell.Controls.Add(new LiteralControl("&nbsp;"));

            LinkButton next = new LinkButton();
            next.ID = "Next";
            next.Click += new EventHandler(next_Click);
            //next.Font.Name = "webdings";
            //next.Font.Size = Font.Size;
            next.ForeColor = ForeColor;
            next.ToolTip = "下一页";
            next.Text = NextButton;
            next.Enabled = isValidPage && canMoveForward;
            cell.Controls.Add(next);

            // 添加一个空格
            cell.Controls.Add(new LiteralControl("&nbsp;"));


            LinkButton last = new LinkButton();
            last.ID = "Last";
            last.Click += new EventHandler(last_Click);
            //last.Font.Name = "webdings";
            //last.Font.Size = Font.Size;
            last.ForeColor = ForeColor;
            last.ToolTip = "最末页";
            last.Text = LastButton;
            last.Enabled = isValidPage && canMoveForward;
            cell.Controls.Add(last);
        }

        /// <summary>
        /// 创建箭头按钮
        /// </summary>
        /// <param name="cell">表格列对象</param>
        private void BuildNextPrevUI(TableCell cell)
        {
            bool isValidPage = (CurrentPageIndex >= 0 && CurrentPageIndex <= TotalPages - 1);
            bool canMoveBack = (CurrentPageIndex > 0);
            bool canMoveForward = (CurrentPageIndex < TotalPages - 1);

            // 呈现 > 按钮
            LinkButton first = new LinkButton();
            first.ID = "First";
            first.Click += new EventHandler(first_Click);
            first.Font.Name = "webdings";
            //first.Font.Size = FontUnit.Medium;
            first.ForeColor = ForeColor;
            first.ToolTip = "第一页";
            first.Text = "7";
            first.Enabled = isValidPage && canMoveBack;
            cell.Controls.Add(first);

            // 添加一个空格
            cell.Controls.Add(new LiteralControl("&nbsp;"));

            // 呈现 << 按钮
            LinkButton prev = new LinkButton();
            prev.ID = "Prev";
            prev.Click += new EventHandler(prev_Click);
            prev.Font.Name = "webdings";
            //prev.Font.Size = FontUnit.Medium;
            prev.ForeColor = ForeColor;
            prev.ToolTip = "上一页";
            prev.Text = "3";
            prev.Enabled = isValidPage && canMoveBack;
            cell.Controls.Add(prev);

            // 添加一个空格
            cell.Controls.Add(new LiteralControl("&nbsp;"));

            // 呈现 > 按钮
            LinkButton next = new LinkButton();
            next.ID = "Next";
            next.Click += new EventHandler(next_Click);
            next.Font.Name = "webdings";
            //next.Font.Size = FontUnit.Medium;
            next.ForeColor = ForeColor;
            next.ToolTip = "下一页";
            next.Text = "4";
            next.Enabled = isValidPage && canMoveForward;
            cell.Controls.Add(next);

            // 添加一个空格
            cell.Controls.Add(new LiteralControl("&nbsp;"));

            // 呈现 >> 按钮
            LinkButton last = new LinkButton();
            last.ID = "Last";
            last.Click += new EventHandler(last_Click);
            last.Font.Name = "webdings";
            //last.Font.Size = FontUnit.Medium;
            last.ForeColor = ForeColor;
            last.ToolTip = "最末页";
            last.Text = "8";
            last.Enabled = isValidPage && canMoveForward;
            cell.Controls.Add(last);
        }
        // ***********************************************************************

        // ***********************************************************************
        /// <summary>
        /// 创建下拉框页码显示
        /// </summary>
        /// <param name="cell">列对象</param>
        private void BuildNumericPagesUI(TableCell cell)
        {
            // 呈现一个下拉框列表
            DropDownList pageList = new DropDownList();
            pageList.ID = "PageList";
            pageList.AutoPostBack = true;
            pageList.SelectedIndexChanged += new EventHandler(PageList_Click);
            pageList.Font.Name = Font.Name;
            //pageList.Font.Size = Font.Size;
            pageList.ForeColor = ForeColor;

            // 当无分页数据时，设置一个默认值
            if (TotalPages <= 0 || CurrentPageIndex == -1)
            {
                pageList.Items.Add("无分页");
                pageList.Enabled = false;
                pageList.SelectedIndex = 0;
            }
            else // 移动列表
            {
                for (int i = 1; i <= TotalPages; i++)
                {
                    ListItem item = new ListItem(i.ToString(), (i - 1).ToString());
                    pageList.Items.Add(item);
                }
                pageList.SelectedIndex = CurrentPageIndex;
            }
            cell.Controls.Add(pageList);
        }
        #endregion

        /// <summary>
        /// 创建当前页面显示的页码文本
        /// </summary>
        /// <param name="cell">列对象</param>
        private void BuildCurrentPage(TableCell cell)
        {

            // 显示文本的模板：第X页/总Y页
            if (CurrentPageIndex < 0 || CurrentPageIndex >= TotalPages)
            {
                if (ShowPageCount)
                    cell.Text = NoPageSelectedText;
            }
            else
            {
                if (ShowPageCount && ShowCount)
                {
                    CurrentPageText = "第<font color=#ff0000>{0}</font>页/总<font color=#ff0000>{1}</font>页 [每页<font color=#ff0000>{2}</font>条/共<font color=#ff0000>{3}</font>条记录]";
                    cell.Text = String.Format(CurrentPageText, (CurrentPageIndex + 1), TotalPages, PageSize, _totalCount);
                }
                else if (ShowPageCount && (!ShowCount))
                {
                    CurrentPageText = "第<font color=#ff0000>{0}</font>页/总<font color=#ff0000>{1}</font>页";
                    cell.Text = String.Format(CurrentPageText, (CurrentPageIndex + 1), TotalPages);
                }
                else if ((!ShowPageCount) && ShowCount)
                {
                    CurrentPageText = "每页<font color=#ff0000>{0}</font>条/共<font color=#ff0000>{1}</font>条记录";
                    cell.Text = String.Format(CurrentPageText, PageSize, _totalCount);
                }
                else
                    cell.Text = "";
            }
        }


        /// <summary>
        /// 确保当前页面索引为有效的（0,总页数或者-1）
        /// </summary>
        private void ValidatePageIndex()
        {
            if (TotalPages > 0)
            {
                if (!(CurrentPageIndex >= 0 && CurrentPageIndex < TotalPages))
                    CurrentPageIndex = 0;
            }
            else
                CurrentPageIndex = -1;
            return;
        }

        // ***********************************************************************
        /// <summary>
        /// 一次性获取所有数据进行分页，使用了cache
        /// </summary>
        private void FetchAllData()
        {
            // 在缓存里查找数据
            DataTable data;
            data = (DataTable)Page.Cache[CacheKeyName];
            if (data == null)
            {
                string tableName = this.TableViewName;
                string selectColumns = this.SelectColumns;
                string sortColumn = this.SortColumn;
                int pageSize = this.PageSize;
                int sortType = 1;
                if (this.SortType == SortType.ASC)
                    sortType = 0;
                string strWhere = this.StrWhere;

                // 如果缓存过期或者无数据，即从数据库取得
                data = new DataTable();
                if (!UseCustomDataSource)
                    data = SqlConn.GetList(tableName, selectColumns, sortColumn, this.MaxNoteCount, 1, 0, sortType, strWhere);
                else
                    data = _customDataSource.Tables[0];
                Page.Cache.Insert(CacheKeyName, data, null,
                    DateTime.Now.AddSeconds(CacheDuration),
                    System.Web.Caching.Cache.NoSlidingExpiration);
            }

            // 为分页控件配置分页数据源
            if (_dataSource == null)
                _dataSource = new PagedDataSource();
            _dataSource.DataSource = data.DefaultView; // must be IEnumerable!
            _dataSource.AllowPaging = true;
            _dataSource.PageSize = this.PageSize;
            TotalPages = _dataSource.PageCount;
            _totalCount = data.Rows.Count;
            // 确保页索引是有效的
            ValidatePageIndex();
            if (CurrentPageIndex == -1)
            {
                _dataSource = null;
                return;
            }

            // 选择当前页面
            _dataSource.CurrentPageIndex = CurrentPageIndex;
        }
        // ***********************************************************************


        // ***********************************************************************
        /// <summary>
        /// 只获取当前页面所需的记录，不使用cache
        /// </summary>
        private void FetchPageData()
        {
            // 需要经过验证的页面索引来获取数据。  
            // 还需要实际的页数来验证页面索引。
            VirtualRecordCount countInfo = CalculateVirtualRecordCount();
            TotalPages = countInfo.PageCount;
            _totalCount = countInfo.RecordCount;

            // 校验页数（确保当前页面是有效的或者为-1)
            ValidatePageIndex();
            if (CurrentPageIndex == -1)
                return;

            // 填充分页数据
            DataTable data = new DataTable();
            if (!UseCustomDataSource)
                data = FillPageData();
            else
                data = _customDataSource.Tables[0];

            // 为分页控件配置分页数据源
            if (_dataSource == null)
                _dataSource = new PagedDataSource();
            _dataSource.DataSource = data.DefaultView;
            _dataSource.AllowCustomPaging = true;
            _dataSource.AllowPaging = true;
            _dataSource.CurrentPageIndex = 0;
            _dataSource.PageSize = PageSize;
            _dataSource.VirtualCount = countInfo.RecordCount;
            TotalPages = _dataSource.PageCount;
            if (CurrentPageIndex + 1 < TotalPages)
                _dataSource.PageSize = PageSize;
            else
                _dataSource.PageSize = countInfo.RecordsInLastPage;
        }
        // ***********************************************************************

        /// <summary>
        /// 计算有效记录数
        /// </summary>
        /// <returns>记录数</returns>
        private VirtualRecordCount CalculateVirtualRecordCount()
        {
            VirtualRecordCount count = new VirtualRecordCount();

            // 在查询结果中计算实际的记录数
            count.RecordCount = GetQueryVirtualCount();
            count.RecordsInLastPage = PageSize;

            int lastPage = count.RecordCount / PageSize;
            int remainder = count.RecordCount % PageSize;
            if (remainder > 0)
                lastPage++;
            count.PageCount = lastPage;

            // 计算最后一页有记录数
            if (remainder > 0)
                count.RecordsInLastPage = remainder;
            return count;
        }


        /// <summary>
        /// 获取查询的有效记录数量
        /// </summary>
        /// <returns></returns>
        private int GetQueryVirtualCount()
        {
            string tableName = this.TableViewName;
            string strWhere = this.StrWhere;

            int recCount = 0;
            if (!UseCustomDataSource)
            {
                recCount = Convert.ToInt32(SqlConn.GetList(tableName, "", "", 0, 0, 1, 0, strWhere).Rows[0][0]);
            }
            else
                recCount = _customDataSource.Tables[0].Rows.Count;

            return recCount;
        }


        /// <summary>
        /// 填充分页数据
        /// </summary>
        /// <param name="countInfo">实际数量信息</param>
        private DataTable FillPageData()
        {
            string tableName = this.TableViewName;
            string selectColumns = this.SelectColumns;
            string sortColumn = this.SortColumn;
            string keyColumn = this.KeyColumn;
            int pageSize = this.PageSize;
            //string sort = "";
            //if (this.SortType == SortType.ASC)
            //    sort = sortColumn + " ASC";
            //else
            //    sort = sortColumn + " DESC";

            int sort = 0;
            if (this.SortType != SortType.ASC)
                sort = 1;

            long CurrentPage = CurrentPageIndex + 1;
            //long PageCount = 0;

            return SqlConn.GetList(tableName, selectColumns, sortColumn, pageSize, CurrentPageIndex + 1, 0, sort, StrWhere);

            //return SqlConn.GetList(tableName, keyColumn, selectColumns, strWhere, sort, ref CurrentPage, pageSize, ref PageCount);
        }

        // ***********************************************************************
        /// <summary>
        /// 跳转到指定页
        /// </summary>
        /// <param name="pageIndex">页面索引</param>
        public void GoToPage(int pageIndex)
        {
            // 准备事件数据
            PageChangedEventArgs e = new PageChangedEventArgs();
            e.OldPageIndex = CurrentPageIndex;
            e.NewPageIndex = pageIndex;

            // 更新当前页面索引
            CurrentPageIndex = pageIndex;

            // 第一页改变时的事件
            OnPageIndexChanged(e);

            // 绑定新数据
            DataBind();
        }
        // ***********************************************************************
        #region 按钮点击事件
        // ***********************************************************************        
        /// <summary>
        /// 第一页按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param> 
        private void first_Click(object sender, EventArgs e)
        {
            GoToPage(0);
        }
        // ***********************************************************************

        // ***********************************************************************
        /// <summary>
        /// 上一页按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void prev_Click(object sender, EventArgs e)
        {
            GoToPage(CurrentPageIndex - 1);
        }
        // ***********************************************************************

        // ***********************************************************************
        /// <summary>
        /// 下一页按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void next_Click(object sender, EventArgs e)
        {
            GoToPage(CurrentPageIndex + 1);
        }
        // ***********************************************************************

        // ***********************************************************************
        /// <summary>
        /// 最后一页按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void last_Click(object sender, EventArgs e)
        {
            GoToPage(TotalPages - 1);
        }
        // ***********************************************************************
        /// <summary>
        /// 下拉框选择事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PageList_Click(object sender, EventArgs e)
        {
            DropDownList pageList = (DropDownList)sender;
            int pageIndex = Convert.ToInt32(pageList.SelectedItem.Value);
            GoToPage(pageIndex);
        }
        // ***********************************************************************
        #endregion

        #endregion
    }
    #endregion
}
