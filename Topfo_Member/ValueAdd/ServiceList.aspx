<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ServiceList.aspx.cs" Inherits="ValueAdd_ServiceList" Title="增值服务定制-定制成功" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="/CSS/style.css" rel="stylesheet" type="text/css" />
    <div class="size">
        <table width="100%" align="center" cellspacing="0" class="taba">
            <tr class="tabtitle">
                <td align="right" class="tabtitle" colspan="7">
                    <div>　　<strong><a href="/ValueAdd/ServiceAdd.aspx">我要定制增值服务</a></strong>　　</div></td>
            </tr>
            <tr class="tabtitle">
                <td width="4%" align="center" class="tabtitle">
                    <a href="javascript:;" onclick="chkAll()">选择</a>
                </td>
                <td width="19%" align="center" class="tabtitle">
                    类别</td>
                <td width="26%" align="left" class="tabtitle">
                    特殊要求</td>
                <td width="15%" align="center" class="tabtitle">
                    价格(元)</td>
                <td width="12%" align="center" class="tabtitle">
                    发布时间</td>
                <td width="12%" align="center" class="tabtitle">
                    状态</td>
                <td width="12%" align="center" class="tabtitle">
                    查看详细</td>
            </tr>
            <asp:Repeater runat="server" ID="Repeater1">
                <ItemTemplate>
                    <tr>
                        <td width="4%" align="center">
                            <input type="checkbox" name="checkbox" value="<%#Eval("ID") %>" /></td>
                        <td width="19%" height="25" align="center">
                            <%#Eval("TypeName")%>
                        </td>
                        <td width="26%">
                            <%#Eval("Remark")%>
                        </td>
                        <td width="15%" align="center">
                            <%#getprice(Eval("Type").ToString().Trim())%>
                        </td>
                        <td width="12%" align="center">
                            <%#Eval("ApplyTime","{0:yyyy-MM-dd}")%>
                        </td>
                        <td width="12%" align="center">
                           <%#Eval("IsDeal").ToString().Trim()=="0"?"未处理":"已处理"%>
                        </td>
                        <td width="12%" align="center">
                            <a href="#"> 查看详情</a></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
</asp:Content>
