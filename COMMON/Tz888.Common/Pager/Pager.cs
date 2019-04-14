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
    #region ʹ��Cacheѡ��
    /// <summary>
    /// ��ҳ��������
    /// </summary>
    public enum PagingMode
    {
        /// <summary>
        /// ��Ҫ����
        /// </summary>
        Cached,
        /// <summary>
        /// ���û���
        /// </summary>
        NonCached
    }
    #endregion

    #region ҳ����ʽ
    /// <summary>
    /// ҳ����ʽ����
    /// </summary>
    public enum PagerStyle
    {
        /// <summary>
        /// ��ť��ʽΪ����ҳ��ͷ
        /// </summary>
        NextPrev,
        /// <summary>
        /// ��ť��ʽ��������ҳ��
        /// </summary>
        NumericPages,
        /// <summary>
        /// ��ť��������ҳ��һ����ʾ
        /// </summary>
        NextAndNumeric,
        /// <summary>
        /// �Զ�����ʽ�����Զ��ı�
        /// </summary>
        CustomStyle,
        /// <summary>
        /// �Զ�����ʽ�����Զ��ı���ͬʱ��ʾ����ҳ��
        /// </summary>
        CustomAndNumeric,
        /// <summary>
        /// ��ˢ�¼�ͷʽ��ť
        /// </summary>
        AjaxNext,
        /// <summary>
        /// ��ˢ�¼�ͷʽ��ť������ҳ��
        /// </summary>
        AjaxNextAndNum,
        /// <summary>
        /// ��ˢ��������ť
        /// </summary>
        AjaxNumeric,
        /// <summary>
        /// �Զ�����ˢ�·�ҳ
        /// </summary>
        AjaxCustomPages,
        /// <summary>
        /// �Զ�����ˢ�º�������ҳ��
        /// </summary>
        AjaxCustomAndNumeric
    }
    #endregion

    #region ����ʽ
    /// <summary>
    /// ����ʽ
    /// </summary>
    public enum SortType
    {
        /// <summary>
        /// ����
        /// </summary>
        ASC,
        /// <summary>
        /// ����
        /// </summary>
        DESC
    }
    #endregion

    #region ʵ�ʼ�¼��
    /// <summary>
    /// ʵ�ʼ�¼��
    /// </summary>
    public class VirtualRecordCount
    {
        /// <summary>
        /// ��¼��
        /// </summary>
        public int RecordCount;
        /// <summary>
        /// ҳ��
        /// </summary>
        public int PageCount;
        /// <summary>
        /// ���һҳ�ļ�¼��
        /// </summary>
        public int RecordsInLastPage;
    }
    #endregion

    #region ҳ����ת�¼�
    /// <summary>
    /// ҳ����ת�¼�
    /// </summary>
    public class PageChangedEventArgs : EventArgs
    {
        /// <summary>
        /// ��ǰҳ������
        /// </summary>
        public int OldPageIndex;
        /// <summary>
        /// ��ҳ������
        /// </summary>
        public int NewPageIndex;
    }
    #endregion

    #region Pager��ҳ�ؼ�
    /// <summary>
    /// Pager��ҳ�ؼ�
    /// </summary>
    [DefaultEvent("PageIndexChanged")]
    [ToolboxData("<{0}:Pager runat=\"server\" />")]
    public class Pager : WebControl, INamingContainer
    {
        private PagedDataSource _dataSource;
        private Control _controlToPaginate;
        static private DataSet _customDataSource = null;
        private int _totalCount;//�ܼ�¼��

        private Tz888.BLL.Conn SqlConn = new Tz888.BLL.Conn();


        private string CacheKeyName
        {
            get { return Page.Request.FilePath + "_" + UniqueID + "_Data"; }
        }

        private string CurrentPageText = "��<font color=#ff0000>{0}</font>ҳ/��<font color=#ff0000>{1}</font>ҳ [ÿҳ<font color=#ff0000>{2}</font>��/��<font color=#ff0000>{3}</font>����¼]";
        //private string CurrentPageText = "��<font color=#ff0000>{0}</font>ҳ/��<font color=#ff0000>{1}</font>ҳ";
        private string NoPageSelectedText = "û��ѡ��ҳ��.";

        #region ���캯������ʼ������
        /// <summary>
        /// ���캯������ʼ������
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

            FirstButton = "��һҳ";
            PrveButton = "��һҳ";
            NextButton = "��һҳ";
            LastButton = "���ҳ";

            ControlToAjaxPanel = "";
        }
        #endregion

        #region ��������ӿڣ�����
        // ***********************************************************************
        /// <summary>
        /// ���Cache����������
        /// </summary>
        public void ClearCache()
        {
            if (PagingMode == PagingMode.Cached)
                Page.Cache.Remove(CacheKeyName);
        }
        // ***********************************************************************

        // ***********************************************************************

        /// <summary>
        /// ҳ����ת�¼�����ҳ����ת����ҳ��ʱ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void PageChangedEventHandler(object sender, PageChangedEventArgs e);
        /// <summary>
        /// ҳ����ת�¼�����ҳ�������ı�ʱ����
        /// </summary>
        public event PageChangedEventHandler PageIndexChanged;
        /// <summary>
        /// ҳ����ת�¼�����ҳ�������ı�ʱ����
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
        /// ��������Դ�ı����ͼ��
        /// </summary>
        [Description("��������Դ�ı����ͼ��")]
        public string TableViewName
        {
            get { return this.ViewState["TableViewName"].ToString(); }
            set { this.ViewState["TableViewName"] = value; }
        }

        /// <summary>
        /// ������Ҫ��ȡ�������ֶ��������ֶ���Ӣ�İ�Ƕ���","�ָ�
        /// </summary>
        [Description("������Ҫ��ȡ�������ֶ��������ֶ���Ӣ�İ��" + ", " + "�ָ�")]
        public string SelectColumns
        {
            get { return this.ViewState["SelectColumns"].ToString(); }
            set { this.ViewState["SelectColumns"] = value; }
        }

        /// <summary>
        /// �����ͼ��������
        /// </summary>
        [Description("�����ͼ��������")]
        public string KeyColumn
        {
            get { return this.ViewState["KeyColumn"].ToString(); }
            set { this.ViewState["KeyColumn"] = value; }
        }

        /// <summary>
        /// ��������ؼ���
        /// </summary>
        [Description("��������ؼ��֣���NonCachedģʽ��ʹ��.")]
        public string SortColumn
        {
            get { return this.ViewState["SortColumn"].ToString(); }
            set { this.ViewState["SortColumn"] = value; }
        }

        /// <summary>
        /// ����ÿҳ��ʾ��¼��
        /// </summary>
        [Description("����ÿҳ��ʾ��¼��")]
        public int PageSize
        {
            get { return Convert.ToInt32(this.ViewState["PageSize"]); }
            set { this.ViewState["PageSize"] = value; }
        }

        /// <summary>
        /// ��������ʽ����������Ĭ��Ϊ����
        /// </summary>
        [Description("��������ʽ����������Ĭ��Ϊ����")]
        public SortType SortType
        {
            get { return (SortType)ViewState["SortType"]; }
            set { ViewState["SortType"] = value; }
        }
        
        /// <summary>
        /// ���ò�ѯ����
        /// </summary>
        [Description("���ò�ѯ����")]
        public string StrWhere
        {
            get { return this.ViewState["StrWhere"].ToString(); }
            set { this.ViewState["StrWhere"] = value; }
        }

        // ***********************************************************************

        /// <summary>
        /// ��һҳ�İ�ť��ʽ
        /// </summary>
        [Description("��һҳ�İ�ť��ʽ")]
        public string FirstButton
        {
            get { return ViewState["FirstButton"].ToString(); }
            set { ViewState["FirstButton"] = value; }
        }
        /// <summary>
        /// ��һҳ�İ�ť��ʽ
        /// </summary>
        [Description("��һҳ�İ�ť��ʽ")]
        public string PrveButton
        {
            get { return ViewState["PrveButton"].ToString(); }
            set { ViewState["PrveButton"] = value; }
        }
        /// <summary>
        /// ��һҳ�İ�ť��ʽ
        /// </summary>
        [Description("��һҳ�İ�ť��ʽ")]
        public string NextButton
        {
            get { return ViewState["NextButton"].ToString(); }
            set { ViewState["NextButton"] = value; }
        }
        /// <summary>
        /// ���һҳ�İ�ť��ʽ
        /// </summary>
        [Description("���һҳ�İ�ť��ʽ")]
        public string LastButton
        {
            get { return ViewState["LastButton"].ToString(); }
            set { ViewState["LastButton"] = value; }
        }

        /// <summary>
        /// �������ʱ��
        /// </summary>
        [Description("���û���ĳ���ʱ��")]
        public int CacheDuration
        {
            get { return Convert.ToInt32(ViewState["CacheDuration"]); }
            set { ViewState["CacheDuration"] = value; }
        }
        // ***********************************************************************

        // ***********************************************************************
        /// <summary>
        /// �Ƿ���ʾͳ��ҳ��
        /// </summary>
        [Description("�Ƿ���ʾͳ��ҳ��")]
        public bool ShowPageCount
        {
            get { return Convert.ToBoolean(ViewState["ShowPageCount"]); }
            set { ViewState["ShowPageCount"] = value; }
        }
        // ***********************************************************************

        // ***********************************************************************
        /// <summary>
        /// �Ƿ���ʾͳ�Ƽ�¼����
        /// </summary>
        [Description("�Ƿ���ʾͳ�Ƽ�¼����")]
        public bool ShowCount
        {
            get { return Convert.ToBoolean(ViewState["ShowCount"]); }
            set { ViewState["ShowCount"] = value; }
        }
        // ***********************************************************************

        // ***********************************************************************
        /// <summary>
        /// ��ҳ����ʹ������
        /// </summary>
        [Description("�Ƿ����÷�ҳ����")]
        public PagingMode PagingMode
        {
            get { return (PagingMode)ViewState["PagingMode"]; }
            set { ViewState["PagingMode"] = value; }
        }
        // ***********************************************************************

        // ***********************************************************************
        /// <summary>
        /// ����һ���Ի�ȡ���ݵ�����¼��(���û���ʱʹ��)
        /// </summary>
        [Description("����һ���Ի�ȡ���ݵ�����¼��(���û���ʱʹ��)")]
        public int MaxNoteCount
        {
            get { return Convert.ToInt32(ViewState["MaxNoteCount"]); }
            set { ViewState["MaxNoteCount"] = value; }
        }
        // ***********************************************************************

        // ***********************************************************************
        /// <summary>
        /// ��ҳ��ʽ���ã���ʾ�ϡ��·�ҳ����������ҳ��
        /// </summary>
        [Description("���÷�ҳ��ť��ʽ")]
        public PagerStyle PagerStyle
        {
            get { return (PagerStyle)ViewState["PagerStyle"]; }
            set { ViewState["PagerStyle"] = value; }
        }
        // ***********************************************************************

        // ***********************************************************************
        /// <summary>
        /// ����Ajax��ҳģʽ�г���������ʾ�ؼ�������ID(�Ƽ�ʹ��DIV)
        /// </summary>
        [Description("����Ajax��ҳģʽ�г���������ʾ�ؼ�������ID(�Ƽ�ʹ��DIV)")]
        public string ControlToAjaxPanel
        {
            get { return Convert.ToString(ViewState["ControlToAjaxPanel"]); }
            set { ViewState["ControlToAjaxPanel"] = value; }
        }
        // ***********************************************************************

        // ***********************************************************************
        /// <summary>
        /// ���ù����ؼ���ID
        /// </summary>
        [Description("���ù��������б�ؼ���ID")]
        public string ControlToPaginate
        {
            get { return Convert.ToString(ViewState["ControlToPaginate"]); }
            set { ViewState["ControlToPaginate"] = value; }
        }
        // ***********************************************************************

        // ***********************************************************************
        /// <summary>
        /// �ؼ�������������ID(ĸ��ҳ��ҳ��ʹ��)
        /// </summary>
        [Description("�ؼ�������������ID(ĸ��ҳ��ҳ��ʹ��)")]
        public string ContentPlaceHolder
        {
            get { return Convert.ToString(ViewState["ContentPlaceHolder"]); }
            set { ViewState["ContentPlaceHolder"] = value; }
        }
        // ***********************************************************************

        // ***********************************************************************
        /// <summary>
        /// ���õ�ǰҳ������
        /// </summary>
        [Description("��ǰҳ������")]
        public int CurrentPageIndex
        {
            get { return Convert.ToInt32(ViewState["CurrentPageIndex"]); }
            set { ViewState["CurrentPageIndex"] = value; }
        }
        // ***********************************************************************

        // ***********************************************************************
        /// <summary>
        /// ��ȡҳ���С���ܹ�����ʾ�ļ�¼��
        /// </summary>
        [Browsable(false)]
        public int PageCount
        {
            get { return TotalPages; }
        }
        /// <summary>
        /// �Ƿ�ʹ���Զ�������Դ
        /// </summary>
        [Description("�Ƿ�ʹ���Զ�������Դ")]
        public bool UseCustomDataSource
        {
            get { return Convert.ToBoolean(ViewState["UseCustomDataSource"]); }
            set { ViewState["UseCustomDataSource"] = value; }
        }

        /// <summary>
        /// �����Զ�������Դ
        /// </summary>
        [Browsable(false)]
        public DataSet CustomDataSource
        {
            set { _customDataSource = value; }
        }
        // ***********************************************************************

        // ***********************************************************************
        /// <summary>
        /// ���û�ȡ��ҳ��
        /// </summary>
        public int TotalPages
        {
            get { return Convert.ToInt32(ViewState["TotalPages"]); }
            set { ViewState["TotalPages"] = value; }
        }
        // ***********************************************************************

        // ***********************************************************************
        /// <summary>
        /// ���ݰ󶨣�ȡ������������
        /// </summary>
        public override void DataBind()
        {
            // ��ʼ���¼�
            base.DataBind();

            // �Ƿ������ӿؼ���Controls must be recreated after data binding 
            ChildControlsCreated = false;

            // ȷ���ؼ����ڲ�����һ���Ϸ������������ؼ�
            if (ControlToPaginate == "")
                return;
            //�жϵ�ǰҳ��ʱ��Ϊĸ��ҳ����
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

            // ȷ���в�ѯ����
            if (UseCustomDataSource && _customDataSource == null)
                return;

            if ((this.TableViewName == "" || this.SelectColumns == "" || this.SortColumn == "") && !UseCustomDataSource)
                return;

            //�жϲ�ѯ�����Ƿ�ı�
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

            // ��ȡ����
            if (PagingMode == PagingMode.Cached)
                FetchAllData();
            else
            {
                FetchPageData();
            }

            // ��ؼ�������
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
        /// �����ݳ����ڿͻ���
        /// </summary>
        /// <param name="output"></param> 
        protected override void Render(HtmlTextWriter output)
        {
            if (Site != null && Site.DesignMode)
                CreateChildControls();

            base.Render(output);
        }
        /// <summary>
        /// ���ؼ�������ҳ�棬����AJAX��ҳ
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
        /// ��дCreateChildControls�����HTML����
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

        #region ˽�з���
        /// <summary>
        /// ������ҳ������ť
        /// </summary>
        private void BuildControlHierarchy()
        {
            // ����һ���� (һ�У�����)
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
            //ָ����ʽ����
            t.CssClass = "PageButton";

            //// ������������
            //TableRow breakRow = new TableRow();
            //t.Rows.Add(breakRow);
            //TableCell breakCell = new TableCell();
            //breakCell.Height = Unit.Pixel(10);
            //breakRow.Cells.Add(breakCell);


            // ������
            TableRow row = new TableRow();
            t.Rows.Add(row);

            // Ϊҳ����������
            TableCell cellPageDesc = new TableCell();
            cellPageDesc.HorizontalAlign = HorizontalAlign.Left;
            //cellPageDesc.Width = Unit.Percentage(80);
            BuildCurrentPage(cellPageDesc);
            row.Cells.Add(cellPageDesc);

            // Ϊ������������
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
                    cellNavBar.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;&nbsp;ѡ��ҳ��"));
                    BuildNumericPagesUI(cellNavBar);
                    break;
                case PagerStyle.CustomStyle:
                    BuildCustomUI(cellNavBar);
                    break;
                case PagerStyle.CustomAndNumeric:
                    BuildCustomUI(cellNavBar);
                    cellNavBar.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;&nbsp;ѡ��ҳ��"));
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
                    cellNavBar.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;&nbsp;ѡ��ҳ��"));
                    BuildAjaxNumericUI(cellNavBar);
                    break;
                case PagerStyle.AjaxNextAndNum:
                    BuildAjaxNextUI(cellNavBar);
                    cellNavBar.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;&nbsp;ѡ��ҳ��"));
                    BuildAjaxNumericUI(cellNavBar);
                    break;
            }
            row.Cells.Add(cellNavBar);

            // ������뵽�ؼ���
            Controls.Add(t);
        }
        /// <summary>
        /// ΪAjax�����Զ����ҳ������ť
        /// </summary>
        public void BuildAjaxControl()
        {
            // ����һ���� (һ�У�����)
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
            //ָ����ʽ����
            t.CssClass = "PageButton";

            // ������������
            TableRow breakRow = new TableRow();
            t.Rows.Add(breakRow);
            TableCell breakCell = new TableCell();
            breakCell.Height = Unit.Pixel(10);
            breakRow.Cells.Add(breakCell);

            // ������
            TableRow row = new TableRow();
            t.Rows.Add(row);

            // Ϊҳ����������
            TableCell cellPageDesc = new TableCell();
            cellPageDesc.HorizontalAlign = HorizontalAlign.Left;
            BuildCurrentPage(cellPageDesc);
            row.Cells.Add(cellPageDesc);

            // Ϊ������������
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
                    cellNavBar.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;&nbsp;ѡ��ҳ��"));
                    BuildAjaxNumericUI(cellNavBar);
                    break;
                case PagerStyle.AjaxNextAndNum:
                    BuildAjaxNextUI(cellNavBar);
                    cellNavBar.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;&nbsp;ѡ��ҳ��"));
                    BuildAjaxNumericUI(cellNavBar);
                    break;
            }
            row.Cells.Add(cellNavBar);

            Controls.Add(t);
        }

        #region Ajax��ˢ�°�ť
        /// <summary>
        /// ������ͷ��ť
        /// </summary>
        /// <param name="cell">����ж���</param>
        private void BuildAjaxNextUI(TableCell cell)
        {
            bool isValidPage = (CurrentPageIndex >= 0 && CurrentPageIndex <= TotalPages - 1);
            bool canMoveBack = (CurrentPageIndex > 0);
            bool canMoveForward = (CurrentPageIndex < TotalPages - 1);

            // ���� > ��ť
            LinkButton first = new LinkButton();
            first.ID = "First";
            first.Attributes.Add("onclick", "setPageTo(" + Convert.ToString(0) + ",'" + ControlToAjaxPanel + "');return false;");
            first.Font.Name = "webdings";
            //first.Font.Size = FontUnit.Medium;
            first.ForeColor = ForeColor;
            first.ToolTip = "��һҳ";
            first.Text = "7";
            first.Enabled = isValidPage && canMoveBack;
            cell.Controls.Add(first);

            // ���һ���ո�
            cell.Controls.Add(new LiteralControl("&nbsp;"));

            // ���� << ��ť
            LinkButton prev = new LinkButton();
            prev.ID = "Prev";
            prev.Attributes.Add("onclick", "setPageTo(" + Convert.ToString(CurrentPageIndex - 1) + ",'" + ControlToAjaxPanel + "');return false;");
            prev.Font.Name = "webdings";
            //prev.Font.Size = FontUnit.Medium;
            prev.ForeColor = ForeColor;
            prev.ToolTip = "��һҳ";
            prev.Text = "3";
            prev.Enabled = isValidPage && canMoveBack;
            cell.Controls.Add(prev);

            // ���һ���ո�
            cell.Controls.Add(new LiteralControl("&nbsp;"));

            // ���� > ��ť
            LinkButton next = new LinkButton();
            next.ID = "Next";
            next.Attributes.Add("onclick", "setPageTo(" + Convert.ToString(CurrentPageIndex + 1) + ",'" + ControlToAjaxPanel + "');return false;");
            next.Font.Name = "webdings";
            //next.Font.Size = FontUnit.Medium;
            next.ForeColor = ForeColor;
            next.ToolTip = "��һҳ";
            next.Text = "4";
            next.Enabled = isValidPage && canMoveForward;
            cell.Controls.Add(next);

            // ���һ���ո�
            cell.Controls.Add(new LiteralControl("&nbsp;"));

            // ���� >> ��ť
            LinkButton last = new LinkButton();
            last.ID = "Last";
            last.Attributes.Add("onclick", "setPageTo(" + Convert.ToString(TotalPages - 1) + ",'" + ControlToAjaxPanel + "');return false;");
            last.Font.Name = "webdings";
            //last.Font.Size = FontUnit.Medium;
            last.ForeColor = ForeColor;
            last.ToolTip = "��ĩҳ";
            last.Text = "8";
            last.Enabled = isValidPage && canMoveForward;
            cell.Controls.Add(last);
        }
        /// <summary>
        /// ��ˢ�·�ҳ��ť
        /// </summary>
        /// <param name="cell">����ж���</param>
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
            first.ToolTip = "��һҳ";
            first.Text = FirstButton;
            first.Enabled = isValidPage && canMoveBack;
            cell.Controls.Add(first);

            // ���һ���ո�
            cell.Controls.Add(new LiteralControl("&nbsp;"));

            LinkButton prev = new LinkButton();
            prev.ID = "Prev";
            //prev.Click += new EventHandler(prev_Click);
            prev.Attributes.Add("onclick", "setPageTo(" + Convert.ToString(CurrentPageIndex - 1) + ",'" + ControlToAjaxPanel + "');return false;");
            //prev.Font.Name = "webdings";
            //prev.Font.Size = Font.Size;
            prev.ForeColor = ForeColor;
            prev.ToolTip = "��һҳ";
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
            next.ToolTip = "��һҳ";
            next.Text = NextButton;
            next.Enabled = isValidPage && canMoveForward;
            cell.Controls.Add(next);

            // ���һ���ո�
            cell.Controls.Add(new LiteralControl("&nbsp;"));


            LinkButton last = new LinkButton();
            last.ID = "Last";
            //last.Click += new EventHandler(last_Click);
            last.Attributes.Add("onclick", "setPageTo(" + Convert.ToString(TotalPages - 1) + ",'" + ControlToAjaxPanel + "');return false;");
            //last.Font.Name = "webdings";
            //last.Font.Size = Font.Size;
            last.ForeColor = ForeColor;
            last.ToolTip = "��ĩҳ";
            last.Text = LastButton;
            last.Enabled = isValidPage && canMoveForward;
            cell.Controls.Add(last);
        }
        /// <summary>
        /// ��ˢ��������ҳ����ʾ
        /// </summary>
        /// <param name="cell">�ж���</param>
        private void BuildAjaxNumericUI(TableCell cell)
        {
            // ����һ���������б�
            DropDownList pageList = new DropDownList();
            pageList.ID = "PageList";
            pageList.AutoPostBack = false;
            //pageList.SelectedIndexChanged += new EventHandler(PageList_Click);
            pageList.Attributes.Add("onchange", "setPageTo(this.value,'" + ControlToAjaxPanel + "');return false;");
            pageList.Font.Name = Font.Name;
            //pageList.Font.Size = Font.Size;
            pageList.ForeColor = ForeColor;

            // ���޷�ҳ����ʱ������һ��Ĭ��ֵ
            if (TotalPages <= 0 || CurrentPageIndex == -1)
            {
                pageList.Items.Add("�޷�ҳ");
                pageList.Enabled = false;
                pageList.SelectedIndex = 0;
            }
            else // �ƶ��б�
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

        #region ��������̨���а�ť
        /// <summary>
        /// �����Զ��尴ť
        /// </summary>
        /// <param name="cell">����ж���</param>
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
            first.ToolTip = "��һҳ";
            first.Text = FirstButton;
            first.Enabled = isValidPage && canMoveBack;
            cell.Controls.Add(first);

            // ���һ���ո�
            cell.Controls.Add(new LiteralControl("&nbsp;"));

            LinkButton prev = new LinkButton();
            prev.ID = "Prev";
            prev.Click += new EventHandler(prev_Click);
            //prev.Font.Name = "webdings";
            //prev.Font.Size = Font.Size;
            prev.ForeColor = ForeColor;
            prev.ToolTip = "��һҳ";
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
            next.ToolTip = "��һҳ";
            next.Text = NextButton;
            next.Enabled = isValidPage && canMoveForward;
            cell.Controls.Add(next);

            // ���һ���ո�
            cell.Controls.Add(new LiteralControl("&nbsp;"));


            LinkButton last = new LinkButton();
            last.ID = "Last";
            last.Click += new EventHandler(last_Click);
            //last.Font.Name = "webdings";
            //last.Font.Size = Font.Size;
            last.ForeColor = ForeColor;
            last.ToolTip = "��ĩҳ";
            last.Text = LastButton;
            last.Enabled = isValidPage && canMoveForward;
            cell.Controls.Add(last);
        }

        /// <summary>
        /// ������ͷ��ť
        /// </summary>
        /// <param name="cell">����ж���</param>
        private void BuildNextPrevUI(TableCell cell)
        {
            bool isValidPage = (CurrentPageIndex >= 0 && CurrentPageIndex <= TotalPages - 1);
            bool canMoveBack = (CurrentPageIndex > 0);
            bool canMoveForward = (CurrentPageIndex < TotalPages - 1);

            // ���� > ��ť
            LinkButton first = new LinkButton();
            first.ID = "First";
            first.Click += new EventHandler(first_Click);
            first.Font.Name = "webdings";
            //first.Font.Size = FontUnit.Medium;
            first.ForeColor = ForeColor;
            first.ToolTip = "��һҳ";
            first.Text = "7";
            first.Enabled = isValidPage && canMoveBack;
            cell.Controls.Add(first);

            // ���һ���ո�
            cell.Controls.Add(new LiteralControl("&nbsp;"));

            // ���� << ��ť
            LinkButton prev = new LinkButton();
            prev.ID = "Prev";
            prev.Click += new EventHandler(prev_Click);
            prev.Font.Name = "webdings";
            //prev.Font.Size = FontUnit.Medium;
            prev.ForeColor = ForeColor;
            prev.ToolTip = "��һҳ";
            prev.Text = "3";
            prev.Enabled = isValidPage && canMoveBack;
            cell.Controls.Add(prev);

            // ���һ���ո�
            cell.Controls.Add(new LiteralControl("&nbsp;"));

            // ���� > ��ť
            LinkButton next = new LinkButton();
            next.ID = "Next";
            next.Click += new EventHandler(next_Click);
            next.Font.Name = "webdings";
            //next.Font.Size = FontUnit.Medium;
            next.ForeColor = ForeColor;
            next.ToolTip = "��һҳ";
            next.Text = "4";
            next.Enabled = isValidPage && canMoveForward;
            cell.Controls.Add(next);

            // ���һ���ո�
            cell.Controls.Add(new LiteralControl("&nbsp;"));

            // ���� >> ��ť
            LinkButton last = new LinkButton();
            last.ID = "Last";
            last.Click += new EventHandler(last_Click);
            last.Font.Name = "webdings";
            //last.Font.Size = FontUnit.Medium;
            last.ForeColor = ForeColor;
            last.ToolTip = "��ĩҳ";
            last.Text = "8";
            last.Enabled = isValidPage && canMoveForward;
            cell.Controls.Add(last);
        }
        // ***********************************************************************

        // ***********************************************************************
        /// <summary>
        /// ����������ҳ����ʾ
        /// </summary>
        /// <param name="cell">�ж���</param>
        private void BuildNumericPagesUI(TableCell cell)
        {
            // ����һ���������б�
            DropDownList pageList = new DropDownList();
            pageList.ID = "PageList";
            pageList.AutoPostBack = true;
            pageList.SelectedIndexChanged += new EventHandler(PageList_Click);
            pageList.Font.Name = Font.Name;
            //pageList.Font.Size = Font.Size;
            pageList.ForeColor = ForeColor;

            // ���޷�ҳ����ʱ������һ��Ĭ��ֵ
            if (TotalPages <= 0 || CurrentPageIndex == -1)
            {
                pageList.Items.Add("�޷�ҳ");
                pageList.Enabled = false;
                pageList.SelectedIndex = 0;
            }
            else // �ƶ��б�
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
        /// ������ǰҳ����ʾ��ҳ���ı�
        /// </summary>
        /// <param name="cell">�ж���</param>
        private void BuildCurrentPage(TableCell cell)
        {

            // ��ʾ�ı���ģ�壺��Xҳ/��Yҳ
            if (CurrentPageIndex < 0 || CurrentPageIndex >= TotalPages)
            {
                if (ShowPageCount)
                    cell.Text = NoPageSelectedText;
            }
            else
            {
                if (ShowPageCount && ShowCount)
                {
                    CurrentPageText = "��<font color=#ff0000>{0}</font>ҳ/��<font color=#ff0000>{1}</font>ҳ [ÿҳ<font color=#ff0000>{2}</font>��/��<font color=#ff0000>{3}</font>����¼]";
                    cell.Text = String.Format(CurrentPageText, (CurrentPageIndex + 1), TotalPages, PageSize, _totalCount);
                }
                else if (ShowPageCount && (!ShowCount))
                {
                    CurrentPageText = "��<font color=#ff0000>{0}</font>ҳ/��<font color=#ff0000>{1}</font>ҳ";
                    cell.Text = String.Format(CurrentPageText, (CurrentPageIndex + 1), TotalPages);
                }
                else if ((!ShowPageCount) && ShowCount)
                {
                    CurrentPageText = "ÿҳ<font color=#ff0000>{0}</font>��/��<font color=#ff0000>{1}</font>����¼";
                    cell.Text = String.Format(CurrentPageText, PageSize, _totalCount);
                }
                else
                    cell.Text = "";
            }
        }


        /// <summary>
        /// ȷ����ǰҳ������Ϊ��Ч�ģ�0,��ҳ������-1��
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
        /// һ���Ի�ȡ�������ݽ��з�ҳ��ʹ����cache
        /// </summary>
        private void FetchAllData()
        {
            // �ڻ������������
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

                // ���������ڻ��������ݣ��������ݿ�ȡ��
                data = new DataTable();
                if (!UseCustomDataSource)
                    data = SqlConn.GetList(tableName, selectColumns, sortColumn, this.MaxNoteCount, 1, 0, sortType, strWhere);
                else
                    data = _customDataSource.Tables[0];
                Page.Cache.Insert(CacheKeyName, data, null,
                    DateTime.Now.AddSeconds(CacheDuration),
                    System.Web.Caching.Cache.NoSlidingExpiration);
            }

            // Ϊ��ҳ�ؼ����÷�ҳ����Դ
            if (_dataSource == null)
                _dataSource = new PagedDataSource();
            _dataSource.DataSource = data.DefaultView; // must be IEnumerable!
            _dataSource.AllowPaging = true;
            _dataSource.PageSize = this.PageSize;
            TotalPages = _dataSource.PageCount;
            _totalCount = data.Rows.Count;
            // ȷ��ҳ��������Ч��
            ValidatePageIndex();
            if (CurrentPageIndex == -1)
            {
                _dataSource = null;
                return;
            }

            // ѡ��ǰҳ��
            _dataSource.CurrentPageIndex = CurrentPageIndex;
        }
        // ***********************************************************************


        // ***********************************************************************
        /// <summary>
        /// ֻ��ȡ��ǰҳ������ļ�¼����ʹ��cache
        /// </summary>
        private void FetchPageData()
        {
            // ��Ҫ������֤��ҳ����������ȡ���ݡ�  
            // ����Ҫʵ�ʵ�ҳ������֤ҳ��������
            VirtualRecordCount countInfo = CalculateVirtualRecordCount();
            TotalPages = countInfo.PageCount;
            _totalCount = countInfo.RecordCount;

            // У��ҳ����ȷ����ǰҳ������Ч�Ļ���Ϊ-1)
            ValidatePageIndex();
            if (CurrentPageIndex == -1)
                return;

            // ����ҳ����
            DataTable data = new DataTable();
            if (!UseCustomDataSource)
                data = FillPageData();
            else
                data = _customDataSource.Tables[0];

            // Ϊ��ҳ�ؼ����÷�ҳ����Դ
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
        /// ������Ч��¼��
        /// </summary>
        /// <returns>��¼��</returns>
        private VirtualRecordCount CalculateVirtualRecordCount()
        {
            VirtualRecordCount count = new VirtualRecordCount();

            // �ڲ�ѯ����м���ʵ�ʵļ�¼��
            count.RecordCount = GetQueryVirtualCount();
            count.RecordsInLastPage = PageSize;

            int lastPage = count.RecordCount / PageSize;
            int remainder = count.RecordCount % PageSize;
            if (remainder > 0)
                lastPage++;
            count.PageCount = lastPage;

            // �������һҳ�м�¼��
            if (remainder > 0)
                count.RecordsInLastPage = remainder;
            return count;
        }


        /// <summary>
        /// ��ȡ��ѯ����Ч��¼����
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
        /// ����ҳ����
        /// </summary>
        /// <param name="countInfo">ʵ��������Ϣ</param>
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
        /// ��ת��ָ��ҳ
        /// </summary>
        /// <param name="pageIndex">ҳ������</param>
        public void GoToPage(int pageIndex)
        {
            // ׼���¼�����
            PageChangedEventArgs e = new PageChangedEventArgs();
            e.OldPageIndex = CurrentPageIndex;
            e.NewPageIndex = pageIndex;

            // ���µ�ǰҳ������
            CurrentPageIndex = pageIndex;

            // ��һҳ�ı�ʱ���¼�
            OnPageIndexChanged(e);

            // ��������
            DataBind();
        }
        // ***********************************************************************
        #region ��ť����¼�
        // ***********************************************************************        
        /// <summary>
        /// ��һҳ��ť
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
        /// ��һҳ��ť
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
        /// ��һҳ��ť
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
        /// ���һҳ��ť
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void last_Click(object sender, EventArgs e)
        {
            GoToPage(TotalPages - 1);
        }
        // ***********************************************************************
        /// <summary>
        /// ������ѡ���¼�
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
