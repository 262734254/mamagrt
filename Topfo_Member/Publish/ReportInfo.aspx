<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ReportInfo.aspx.cs" Inherits="Publish_ReportInfo" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellspacing="0" cellpadding="0" border="0" style="100%" class="tab">
        <tbody>
            <tr>
                <td align="center" style="width: 25%;">
                    信息标题:
                </td>
                <td align="left">
                    <asp:Label ID="lbTitle" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center">
                    信息类型:</td>
                <td align="left">
                    <asp:Label ID="lbInfoTypeID" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center">
                    处理时间:
                </td>
                <td align="left">
                    <asp:Label ID="lbCheckTime" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center">
                    处理人:</td>
                <td align="left">
                    <asp:Label ID="lbCheckMan" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center">
                    回复内容:</td>
                <td align="left">
                    <asp:Label ID="lbContent" runat="server"></asp:Label>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
