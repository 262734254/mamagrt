using System;
using System.ComponentModel;
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace OurControl
{
    [ParseChildren(true)]
    [PersistChildren(false)]
    [ToolboxData("<{0}:MTCPager runat='server'></{0}:MTCPager>")]
    public partial class MTCPager : CompositeControl
    {
        private string writeHtml;

        protected override void Render(HtmlTextWriter output)
        {
            #region ======= 外层标记 - <SPAN>...</SPAN> =======

            string height = this.Height.ToString() + "pt";
            LiteralControl lc = new LiteralControl();
            lc.Text = "aaaa";
            this.CreateChildControls();

            this.Controls.Add(lc);

            // 外层标记 - <SPAN>...</SPAN>
            output.AddStyleAttribute(HtmlTextWriterStyle.Color, this.PagerFontColor);
            output.AddStyleAttribute(HtmlTextWriterStyle.FontFamily, this.PagerFontFamily);
            output.AddStyleAttribute(HtmlTextWriterStyle.FontSize, this.PagerFontSize);
            output.RenderBeginTag(HtmlTextWriterTag.Span);

            //当前页是否显示
            PageJump pageJump = this.PageJump;
            if (pageJump.CurrentPageVisiable == true)
            {
                writeHtml += this.PageIndex.ToString() + " / " + this.PageCount.ToString() + "&nbsp;页&nbsp;&nbsp;";
            }

            output.Write(writeHtml);

            #endregion

            #region ======= 首页 =======

            // 首页
            if (this.FirstPageDescription.Trim() != "" && this.FirstPageDescription != null && lbFirst != null && this.PageIndex > 1)
            {
                output.AddStyleAttribute(HtmlTextWriterStyle.TextDecoration, "none");
                output.AddStyleAttribute(HtmlTextWriterStyle.Color, this.PagerFontColor);
                output.Write(this.PagerLeftText);
                lbFirst.RenderControl(output);
                output.Write(this.PagerRightText);
                output.Write("&nbsp;&nbsp;");
            }

            #endregion

            #region ======= 上一页 =======

            // 上一页
            if (this.FirstPageDescription.Trim() != "" && this.FirstPageDescription != null && lbPrevious != null && this.PageIndex > 1)
            {
                output.AddStyleAttribute(HtmlTextWriterStyle.TextDecoration, "none");
                output.AddStyleAttribute(HtmlTextWriterStyle.Color, this.PagerFontColor);
                output.Write(this.PagerLeftText);
                lbPrevious.RenderControl(output);
                output.Write(this.PagerRightText);
                output.Write("&nbsp;&nbsp;");
            }

            #endregion

            #region ======= 前翻 =======

            // 如果是前 ShowPageNumberCount 页则不显示“前翻”
            if (this.PageUpDescription.Trim() != "" && this.PageUpDescription != null && lbPreBatch != null && this.PageIndex > this.ShowPageNumberCount)
            {
                output.AddStyleAttribute(HtmlTextWriterStyle.TextDecoration, "none");
                output.AddStyleAttribute(HtmlTextWriterStyle.Color, this.PagerFontColor);
                output.Write(this.PagerLeftText);
                lbPreBatch.RenderControl(output);
                output.Write(this.PagerRightText);
                output.Write("&nbsp;&nbsp;");
            }

            #endregion

            #region ======= 数字页码 =======

            // 呈现页码部分
            this.RenderPageNumber(output);

            #endregion

            #region ======= 后翻 =======

            if (this.PageDownDescription.Trim() != "" && this.PageDownDescription != null && lbNextBatch != null && (this.PageCount >= (this.PageIndex + this.ShowPageNumberCount)))
            {
                output.AddStyleAttribute(HtmlTextWriterStyle.TextDecoration, "none");
                output.AddStyleAttribute(HtmlTextWriterStyle.Color, this.PagerFontColor);
                output.Write(this.PagerLeftText);
                lbNextBatch.RenderControl(output);
                output.Write(this.PagerRightText);
                output.Write("&nbsp;&nbsp;");
            }

            #endregion

            #region ======= 下一页 =======

            if (this.LastPageDescription.Trim() != "" && this.LastPageDescription != null && lbNext != null && this.PageIndex < this.PageCount)
            {
                output.AddStyleAttribute(HtmlTextWriterStyle.TextDecoration, "none");
                output.AddStyleAttribute(HtmlTextWriterStyle.Color, this.PagerFontColor);
                output.Write(this.PagerLeftText);
                lbNext.RenderControl(output);
                output.Write(this.PagerRightText);
                output.Write("&nbsp;&nbsp;");
            }

            #endregion

            #region ======= 末页 =======

            // 末页
            if (this.LastPageDescription.Trim() != "" && this.LastPageDescription != null && lbLast != null && this.PageIndex < this.PageCount)
            {
                output.AddStyleAttribute(HtmlTextWriterStyle.TextDecoration, "none");
                output.AddStyleAttribute(HtmlTextWriterStyle.Color, this.PagerFontColor);
                output.Write(this.PagerLeftText);
                lbLast.RenderControl(output);
                output.Write(this.PagerRightText);
                output.Write("&nbsp;&nbsp;");
            }

            #endregion

            #region ======= 索引跳转 =======

            // 呈现索引跳转            
            this.RenderPageIndexContent(output);

            #endregion

            #region =======每页显示行数跳转=======
            // 呈现每页显示行数跳转            
            this.RenderPageNumJump(output);
            #endregion =======每页显示行数跳转=======

            output.RenderEndTag();
        }

        #region ======= 自定义视图状态 =======

        protected override void LoadViewState(object savedState)
        {
            //Pair p = savedState as Pair;
            //if (p != null)
            //{
            //    base.LoadViewState(p.First);
            //    ((IStateManager)PageJump).LoadViewState(p.Second);
            //    return;
            //}
            base.LoadViewState(savedState);

        }

        protected override object SaveViewState()
        {
            object baseState = base.SaveViewState();
            object thisState = null;

            if (pageJump != null)
            {
                thisState = ((IStateManager)pageJump).SaveViewState();
            }

            if (thisState != null)
            {
                return new Pair(baseState, thisState);
            }
            else
            {
                return baseState;
            }

        }

        protected override void TrackViewState()
        {
            if (pageJump != null)
            {
                ((IStateManager)pageJump).TrackViewState();
            }
            base.TrackViewState();
        }

        #endregion

        #region =======添加页码changed事件=======
        private static readonly object EventKey = new object();
        //添加数据绑定事件
        public event EventHandler PageIndexChanged
        {
            add
            { Events.AddHandler(EventKey, value); }
            remove
            { Events.RemoveHandler(EventKey, value); }
        }

        //实现数据绑定
        protected virtual void OnPageIndexChanged(EventArgs e)
        {
            EventHandler dataBindHandler = (EventHandler)Events[EventKey];

            if (dataBindHandler != null)
            {
                dataBindHandler(this, e);
            }
        }

        // 重写OnBubbleEvent方法，执行事件冒泡，使用事件参数的CommandName成员确定是否需要引发事件处理程序OnPageIndexChanged，并返回true
        protected override bool OnBubbleEvent(object source, EventArgs e)
        {
            bool handled = false;

            if (e is CommandEventArgs)
            {
                CommandEventArgs ce = (CommandEventArgs)e;

                //设置LinkButton的跳转
                if (ce.CommandName == "LinkJump")
                {
                    LinkButton lb = (LinkButton)source;
                    switch (lb.ID)
                    {
                        //首页跳转
                        case "lbFirst":
                            this.PageIndex = 1;
                            break;
                        //末页跳转
                        case "lbLast":
                            this.PageIndex = this.PageCount;
                            break;
                        //上一页跳转
                        case "lbPrevious":
                            if (this.PageIndex > 1)
                                this.PageIndex -= 1;
                            break;
                        //前翻跳转(前翻ShowNumberPages)
                        case "lbPreBatch":
                            if ((this.PageIndex - this.ShowPageNumberCount) > 0)
                                this.PageIndex -= this.ShowPageNumberCount;
                            break;
                        //后翻跳转
                        case "lbNextBatch":
                            if ((this.PageIndex + this.ShowPageNumberCount) <= this.PageCount)
                                this.PageIndex += this.ShowPageNumberCount;
                            break;
                        //下一页跳转
                        case "lbNext":
                            if (this.PageCount > this.PageIndex)
                                this.PageIndex += 1;
                            break;
                        //数字页跳转
                        default:
                            int len = lb.ID.Length;
                            string numOfID = lb.ID.Substring(2, len - 2);
                            try
                            {
                                int numToJump = int.Parse(numOfID);
                                if (numToJump == this.PageIndex)
                                    return false;
                                this.PageIndex = numToJump;
                            }
                            catch
                            {

                            }
                            break;
                    }
                    //响应跳页码变更事件，在此事件中绑定数据
                    OnPageIndexChanged(EventArgs.Empty);
                    handled = true;

                }
                //设置用户输入数字的跳转
                else if (ce.CommandName == "ButtonJump")
                {
                    try
                    {
                        int toJump = int.Parse(tbJumpIndex.Text.Trim());
                        if ((toJump < 1) || (toJump > this.PageCount))
                            return false;
                        this.PageIndex = toJump;
                    }
                    catch
                    {

                    }
                    OnPageIndexChanged(EventArgs.Empty);
                    handled = true;
                }

            }
            base.RaiseBubbleEvent(this, e);
             return handled;
        }

        //索引跳转下拉框事件(由于DropDownList无CommandName属性)
        protected void DropDownList_SelectedIndexChanged(Object sender, EventArgs e)
        {
            try
            {
                int toJump = int.Parse(this.ddlJumpIndex.Items[ddlJumpIndex.SelectedIndex].Value);
                if (toJump >= 1 && toJump <= this.PageCount)
                {
                    this.PageIndex = toJump;

                }
                OnPageIndexChanged(EventArgs.Empty);
            }
            catch
            {

            }
        }

        //索引跳转下拉框事件(由于DropDownList无CommandName属性)
        protected void ShowNum_SelectedIndexChanged(Object sender, EventArgs e)
        {
            try
            {
                int num = int.Parse(this.ddlNumOfPager.Items[ddlNumOfPager.SelectedIndex].Value);

                this.PageSize = num;
                if (this.PageIndex > this.PageCount)
                    this.PageIndex = this.PageCount;
                OnPageIndexChanged(EventArgs.Empty);
            }
            catch
            {

            }
        }

        #endregion 添加页码changed事件
    }
}
