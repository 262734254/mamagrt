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
            #region ======= ����� - <SPAN>...</SPAN> =======

            string height = this.Height.ToString() + "pt";
            LiteralControl lc = new LiteralControl();
            lc.Text = "aaaa";
            this.CreateChildControls();

            this.Controls.Add(lc);

            // ����� - <SPAN>...</SPAN>
            output.AddStyleAttribute(HtmlTextWriterStyle.Color, this.PagerFontColor);
            output.AddStyleAttribute(HtmlTextWriterStyle.FontFamily, this.PagerFontFamily);
            output.AddStyleAttribute(HtmlTextWriterStyle.FontSize, this.PagerFontSize);
            output.RenderBeginTag(HtmlTextWriterTag.Span);

            //��ǰҳ�Ƿ���ʾ
            PageJump pageJump = this.PageJump;
            if (pageJump.CurrentPageVisiable == true)
            {
                writeHtml += this.PageIndex.ToString() + " / " + this.PageCount.ToString() + "&nbsp;ҳ&nbsp;&nbsp;";
            }

            output.Write(writeHtml);

            #endregion

            #region ======= ��ҳ =======

            // ��ҳ
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

            #region ======= ��һҳ =======

            // ��һҳ
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

            #region ======= ǰ�� =======

            // �����ǰ ShowPageNumberCount ҳ����ʾ��ǰ����
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

            #region ======= ����ҳ�� =======

            // ����ҳ�벿��
            this.RenderPageNumber(output);

            #endregion

            #region ======= �� =======

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

            #region ======= ��һҳ =======

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

            #region ======= ĩҳ =======

            // ĩҳ
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

            #region ======= ������ת =======

            // ����������ת            
            this.RenderPageIndexContent(output);

            #endregion

            #region =======ÿҳ��ʾ������ת=======
            // ����ÿҳ��ʾ������ת            
            this.RenderPageNumJump(output);
            #endregion =======ÿҳ��ʾ������ת=======

            output.RenderEndTag();
        }

        #region ======= �Զ�����ͼ״̬ =======

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

        #region =======���ҳ��changed�¼�=======
        private static readonly object EventKey = new object();
        //������ݰ��¼�
        public event EventHandler PageIndexChanged
        {
            add
            { Events.AddHandler(EventKey, value); }
            remove
            { Events.RemoveHandler(EventKey, value); }
        }

        //ʵ�����ݰ�
        protected virtual void OnPageIndexChanged(EventArgs e)
        {
            EventHandler dataBindHandler = (EventHandler)Events[EventKey];

            if (dataBindHandler != null)
            {
                dataBindHandler(this, e);
            }
        }

        // ��дOnBubbleEvent������ִ���¼�ð�ݣ�ʹ���¼�������CommandName��Աȷ���Ƿ���Ҫ�����¼��������OnPageIndexChanged��������true
        protected override bool OnBubbleEvent(object source, EventArgs e)
        {
            bool handled = false;

            if (e is CommandEventArgs)
            {
                CommandEventArgs ce = (CommandEventArgs)e;

                //����LinkButton����ת
                if (ce.CommandName == "LinkJump")
                {
                    LinkButton lb = (LinkButton)source;
                    switch (lb.ID)
                    {
                        //��ҳ��ת
                        case "lbFirst":
                            this.PageIndex = 1;
                            break;
                        //ĩҳ��ת
                        case "lbLast":
                            this.PageIndex = this.PageCount;
                            break;
                        //��һҳ��ת
                        case "lbPrevious":
                            if (this.PageIndex > 1)
                                this.PageIndex -= 1;
                            break;
                        //ǰ����ת(ǰ��ShowNumberPages)
                        case "lbPreBatch":
                            if ((this.PageIndex - this.ShowPageNumberCount) > 0)
                                this.PageIndex -= this.ShowPageNumberCount;
                            break;
                        //����ת
                        case "lbNextBatch":
                            if ((this.PageIndex + this.ShowPageNumberCount) <= this.PageCount)
                                this.PageIndex += this.ShowPageNumberCount;
                            break;
                        //��һҳ��ת
                        case "lbNext":
                            if (this.PageCount > this.PageIndex)
                                this.PageIndex += 1;
                            break;
                        //����ҳ��ת
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
                    //��Ӧ��ҳ�����¼����ڴ��¼��а�����
                    OnPageIndexChanged(EventArgs.Empty);
                    handled = true;

                }
                //�����û��������ֵ���ת
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

        //������ת�������¼�(����DropDownList��CommandName����)
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

        //������ת�������¼�(����DropDownList��CommandName����)
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

        #endregion ���ҳ��changed�¼�
    }
}
