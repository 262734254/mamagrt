<%@ Page Language="C#" AutoEventWireup="true" CodeFile="wasterView.aspx.cs" Inherits="InnerInfo_wasterView" MasterPageFile="~/MasterPage.master" %>



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
                <li ><a href="inbox2.aspx">���յ�����Ϣ</a> </li>
                <li><a href="SendBox2.aspx">�ҷ����Ķ���Ϣ</a></li>
                <li class="liwai"><a href="waster2.aspx">����վ</a></li>
            </ul>
        </div>
        <div class=" cshibiank">
            <div class="topreply">
                ���⣺<span class="font14 cu lansen"><asp:HyperLink ID="HlpTopic" runat="server"></asp:HyperLink></span>
                <br />
                �����ˣ�<a href="#"><asp:HyperLink ID="HplSendman" runat="server"></asp:HyperLink></a><br />
                �ռ��ˣ�<a href="#"><asp:HyperLink ID="HplReceiveman" runat="server"></asp:HyperLink></a></div>
            <div class="replycon">
                <p>
                    <asp:Literal ID="TBoxInfoText" runat="server"></asp:Literal></p>
            <div class="blank20">
            </div>
        </div>
    </div>
</asp:Content>