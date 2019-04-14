<%@ Page Language="C#" AutoEventWireup="true" CodeFile="wasterView.aspx.cs" Inherits="InnerInfo_wasterView" MasterPageFile="~/MasterPage.master" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../css/messagemanage.css" rel="stylesheet" type="text/css" />
    <div id="mainconbox">
        <div class="topzi">
            <div class="left">
                我的短消息</div>
            <div class="clear">
            </div>
        </div>
        <div class="handtop">
            <ul>
                <li><a href="SendView.aspx">发送短消息</a> </li>
                <li ><a href="inbox2.aspx">我收到的消息</a> </li>
                <li><a href="SendBox2.aspx">我发出的短消息</a></li>
                <li class="liwai"><a href="waster2.aspx">回收站</a></li>
            </ul>
        </div>
        <div class=" cshibiank">
            <div class="topreply">
                标题：<span class="font14 cu lansen"><asp:HyperLink ID="HlpTopic" runat="server"></asp:HyperLink></span>
                <br />
                发件人：<a href="#"><asp:HyperLink ID="HplSendman" runat="server"></asp:HyperLink></a><br />
                收件人：<a href="#"><asp:HyperLink ID="HplReceiveman" runat="server"></asp:HyperLink></a></div>
            <div class="replycon">
                <p>
                    <asp:Literal ID="TBoxInfoText" runat="server"></asp:Literal></p>
            <div class="blank20">
            </div>
        </div>
    </div>
</asp:Content>