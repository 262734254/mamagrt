using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Pager
{

        /// <summary>
        /// ��ҳʵ����
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
            /// ��Ҫ��ѯ�ı��� ���޵����ѯ
            /// </summary>
            public string TblName
            {
                get { return tblName; }
                set { tblName = value; }
            }

            private string strGetFields = "*";

            /// <summary>
            /// ��ʾ�ֶ�
            /// </summary>
            public string StrGetFields
            {
                get { return strGetFields; }
                set { strGetFields = value; }
            }
            private string fldName;

            /// <summary>
            /// ��������
            /// </summary>
            public string FldName
            {
                get { return fldName; }
                set { fldName = value; }
            }

            private int pageSize = 12;
            /// <summary>
            /// ÿҳ��ʾ���ټ�¼��
            /// </summary>
            public int PageSize
            {
                get { return pageSize; }
                set { pageSize = value; }
            }

            private int pageIndex = 1;
            /// <summary>
            /// ��ǰҳ��
            /// </summary>
            public int PageIndex
            {
                get { return pageIndex; }
                set { pageIndex = value; }
            }
            private int doCount = 0;
            /// <summary>
            /// ��������0��ʾ��¼�б�1����������
            /// </summary>
            public int DoCount
            {
                get { return doCount; }
                set { doCount = value; }
            }
            private int orderType = 1;

            /// <summary>
            /// ����ʽ0����1����
            /// </summary>
            public int OrderType
            {
                get { return orderType; }
                set { orderType = value; }
            }
            private string strWhere;

            /// <summary>
            /// SQL��������
            /// </summary>
            public string StrWhere
            {
                get { return strWhere; }
                set { strWhere = value; }
            }
            private string procedureName;
            /// <summary>
            /// �洢��������
            /// </summary>
            public string ProcedureName
            {
                get { return procedureName; }
                set { procedureName = value; }
            }
        }
    }

