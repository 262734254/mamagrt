using System;
using System.Collections.Generic;
using System.Text;

namespace OurControl
{
    /// <summary>
    /// 自定义分页的显示模式
    /// </summary>
    public enum PagingMode
    {
        /// <summary>
        /// 首页＋上一页＋下一页＋末页
        /// </summary>
        Default,
        /// <summary>
        /// 首页＋数字＋前后翻Ｎ页
        /// </summary>
        Digit
    }
}
