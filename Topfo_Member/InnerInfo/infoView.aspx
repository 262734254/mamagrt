<%@ Page Language="C#" AutoEventWireup="true" ResponseEncoding="GB2312" CodeFile="infoView.aspx.cs"
    MasterPageFile="~/MasterPage.master" Inherits="InnerInfo_infoView" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../css/messagemanage.css" rel="stylesheet" type="text/css" />
    <div id="mainconbox">
        <div class="topzi">
            <div class="left">
                �ҵĶ���Ϣ</div>
            <div class="clear">
            </div>
        </div>
        <div class="handtop">
            <ul>
                <li><a href="SendView.aspx">���Ͷ���Ϣ</a> </li>
                <li class="liwai"><a href="inbox2.aspx">���յ�����Ϣ</a> </li>
                <li><a href="SendBox2.aspx">�ҷ����Ķ���Ϣ</a></li>
                <li><a href="waster2.aspx">����վ</a></li>
            </ul>
        </div>
        <div class=" cshibiank">
            <div class="topreply">
                ���⣺<span class="font14 cu lansen"><asp:HyperLink ID="HlpTopic" runat="server"></asp:HyperLink></span>
                <asp:Label ID="InfoTime" runat="server"></asp:Label><br />
                �����ˣ�<a href="#"><asp:HyperLink ID="HplSendman" runat="server"></asp:HyperLink></a></div>
            <div class="replycon">
                <p>
                    <asp:Literal ID="TBoxInfoText" runat="server"></asp:Literal></p>
                <asp:Button ID="BtnReturn" runat="server" OnClick="BtnReturn_Click" Text="������Ϣ�б�"
                    CssClass="buttomal" /></div>
            <div class="blank20">
            </div>
            <asp:Panel ID="plreply" runat="server">
            <div class="replybox">
                <h1>
                    <img src="../images/MessageManage/biao_01.gif" width="14" height="16" />
                    ��Ϣ�ظ�</h1>
                <div class="dottedlline">
                </div>
                <div class="blank0">
                </div>
                <table width="100%" border="0" cellspacing="0" cellpadding="4">
                    <tr>
                        <td width="11%" align="right">
                            �ռ��ˣ�</td>
                        <td colspan="2">
                            <label>
                                <asp:TextBox ID="TboxReceiveName" runat="server"></asp:TextBox></label></td>
                    </tr>
                    <tr>
                        <td align="right">
                            ���⣺</td>
                        <td colspan="2">
                            <asp:TextBox ID="TBoxResponseTopic" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right">
                            ���ݣ�</td>
                        <td colspan="2">
                            <asp:TextBox ID="TBoxResponseText" runat="server" Height="64px" TextMode="MultiLine"
                                Width="641px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td colspan="2">
                            <p>
                                <asp:CheckBox ID="CheckBoxSaveOther" runat="server" Text="���͵�ͬʱ���浽������" />
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td width="44%" align="left" valign="top">
                            &nbsp;<asp:Button ID="BtnInfoResponse" runat="server" OnClick="BtnInfoResponse_Click"
                                Text="�� ��" CssClass="buttomal" />&nbsp;<asp:Button ID="BtnReset" runat="server" OnClick="BtnReset_Click"
                                    Text="�� ��" CssClass="buttomal" /></td>
                        <td width="45%">
                            &nbsp;</td>
                    </tr>
                </table>
                <div class="blank20">
                </div>
            </div>
            </asp:Panel>
        </div>
    </div>
</asp:Content>
