<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ServiceList.aspx.cs" Inherits="ValueAdd_ServiceList" Title="��ֵ������-���Ƴɹ�" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="/CSS/style.css" rel="stylesheet" type="text/css" />
    <div class="size">
        <table width="100%" align="center" cellspacing="0" class="taba">
            <tr class="tabtitle">
                <td align="right" class="tabtitle" colspan="7">
                    <div>����<strong><a href="/ValueAdd/ServiceAdd.aspx">��Ҫ������ֵ����</a></strong>����</div></td>
            </tr>
            <tr class="tabtitle">
                <td width="4%" align="center" class="tabtitle">
                    <a href="javascript:;" onclick="chkAll()">ѡ��</a>
                </td>
                <td width="19%" align="center" class="tabtitle">
                    ���</td>
                <td width="26%" align="left" class="tabtitle">
                    ����Ҫ��</td>
                <td width="15%" align="center" class="tabtitle">
                    �۸�(Ԫ)</td>
                <td width="12%" align="center" class="tabtitle">
                    ����ʱ��</td>
                <td width="12%" align="center" class="tabtitle">
                    ״̬</td>
                <td width="12%" align="center" class="tabtitle">
                    �鿴��ϸ</td>
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
                           <%#Eval("IsDeal").ToString().Trim()=="0"?"δ����":"�Ѵ���"%>
                        </td>
                        <td width="12%" align="center">
                            <a href="#"> �鿴����</a></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
</asp:Content>
