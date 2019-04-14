<%@ Control Language="C#" AutoEventWireup="true" CodeFile="IndexTFZS.ascx.cs" Inherits="Controls_IndexTFZS" %>
<table border="0" cellpadding="0" cellspacing="0" width="192">
    <asp:Repeater runat="Server" ID="myList">
        <ItemTemplate>
            <tr>
                <td align="middle" width="13">
                    <asp:Label runat="server" ID="lblID"></asp:Label></td>
                <td width="172">
                    <a href="http://www.topfo.com/<%#Eval("HtmlFile") %>" target="_blank">
                        <%#GetStr(Eval("Title"))%>
                    </a>
                </td>
                <td align="middle" width="15">
                    <%#Eval("TopValue")%>
                </td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
</table>
