<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ReportInfoList.aspx.cs" Inherits="Publish_ReportInfo" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<link href="../css/CRM.css"rel="stylesheet" type="text/css" />
    <table border="0" align="center" cellpadding="5" cellspacing="0" width="100%" class="one_table">
        <tr>
            <th align="center"  class="tabtitle" width="10%">
                信息ID
            </th>
            <th align="center" class="tabtitle" width="25%">
                信息标题
            </th>
            <th align="center" class="tabtitle" width="12%">
                信息类型
            </th>
            <th align="center" class="tabtitle" width="13%">
                举报人</th>
            <th align="center" class="tabtitle" width="15%">
                举报时间</th>
            <th align="center" class="tabtitle" width="15%">
                状态</th>
            <th align="center" class="tabtitle" width="10%">
                操作</th>
        </tr>
        <asp:Repeater runat="server" ID="InfoList">
            <ItemTemplate>
                <tr>
                    <td align="center">
                        <%#Eval("InfoID") %>
                    </td>
                    <td>
                        <%#Eval("Title") %>
                    </td>
                    <td align="center">
                        <%#Eval("InfoTypeID") %>
                    </td>
                    <td align="center">
                        <%#Eval("ReportMan").ToString() == "" ? "游客" : Eval("ReportMan").ToString()%>
                        <a href="javascript:;" style="display: none" onclick='chkViw("<%#GetCount(Convert.ToInt64(Eval("InfoID"))) %>")'>
                            <font color="blue">[全部]</font></a>
                    </td>
                    <td align="center">
                        <a href="#" title='<%#Eval("ReportTime")%>'>
                            <%#Eval("ReportTime","{0:yyyy-MM-dd}")%>
                        </a>
                    </td>
                    <td align="center">
                        <%#GetUrl(Eval("isCheck").ToString(),Eval("InfoID").ToString(),Eval("ID").ToString())%>
                    </td>
                    <td align="center">
                        <a href='ReportInfo.aspx?ID=<%#Eval("ID") %>'>查看</a>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
</asp:Content>
