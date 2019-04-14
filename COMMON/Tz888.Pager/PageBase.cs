using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Pager
{

        /// <summary>
        /// 分页实体类
        /// </summary>
        public class PageBase
        {
            private string _orderName;

            public string OrderName
            {
                get { return _orderName; }
                set { _orderName = value; }
            }

            private string tblName;

            /// <summary>
            /// 需要查询的表名 仅限单表查询
            /// </summary>
            public string TblName
            {
                get { return tblName; }
                set { tblName = value; }
            }

            private string strGetFields = "*";

            /// <summary>
            /// 显示字段
            /// </summary>
            public string StrGetFields
            {
                get { return strGetFields; }
                set { strGetFields = value; }
            }
            private string fldName;

            /// <summary>
            /// 主键名称
            /// </summary>
            public string FldName
            {
                get { return fldName; }
                set { fldName = value; }
            }

            private int pageSize = 12;
            /// <summary>
            /// 每页显示多少记录数
            /// </summary>
            public int PageSize
            {
                get { return pageSize; }
                set { pageSize = value; }
            }

            private int pageIndex = 1;
            /// <summary>
            /// 当前页数
            /// </summary>
            public int PageIndex
            {
                get { return pageIndex; }
                set { pageIndex = value; }
            }
            private int doCount = 0;
            /// <summary>
            /// 排序类型0显示记录列表，1返回总条数
            /// </summary>
            public int DoCount
            {
                get { return doCount; }
                set { doCount = value; }
            }
            private int orderType = 1;

            /// <summary>
            /// 排序方式0正序、1倒序
            /// </summary>
            public int OrderType
            {
                get { return orderType; }
                set { orderType = value; }
            }
            private string strWhere;

            /// <summary>
            /// SQL语句的条件
            /// </summary>
            public string StrWhere
            {
                get { return strWhere; }
                set { strWhere = value; }
            }
            private string procedureName;
            /// <summary>
            /// 存储过程名称
            /// </summary>
            public string ProcedureName
            {
                get { return procedureName; }
                set { procedureName = value; }
            }
        }
    }

