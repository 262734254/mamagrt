<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="payInfo.aspx.cs" Inherits="PayManage_payInfo" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<asp:Literal ID="Literal1" runat="server" Text="<link href=../css/paymanage.css rel='stylesheet' type='text/css' />"></asp:Literal>
    <div id="mainconbox">
        <div class="topzi">
            <div class="left">
                交易明细</div>
            <div class="clear">
            </div>
        </div>
        <div class="suggestbox">
            <p>
                · 您现在查看的是订单号为 <font class="chengcu">10175101</font> 的订单明细情况。如果您有任何疑问，请拨打我们的客服电话：<strong>0755-89805588</strong><br />
            </p>
        </div>
        <!--充值订单信息 -->
        <div class="blank20">
        </div>
        <div class="creditsbox">
            <h1>
                充值订单信息</h1>
            <ul>
                <li>订单号：<span class="chengcu">10175101</span> </li>
                <li>交易完成时间：2007-8-13</li></ul>
            <ul>
                <li>应付金额：100.00 元 </li>
                <li>实付金额：100.00 元</li></ul>
            <ul>
                <li>应付金额：100.00 元 </li>
                <li>支付方式：邮局汇款</li></ul>
        </div>
        <div class="blank20">
        </div>
        <div class="creditsbox">
            <h1>
                购买用户信息</h1>
            <ul>
                <li>用户昵称：vince1125 </li>
                <li>姓名：刘晓飞<br />
                </li>
            </ul>
            <ul>
                <li>固定电话：0755-88599899 <span class="chengcu"></span></li>
                <li>手机：</li></ul>
            <ul>
                <li>电子邮箱：lxfei@tz888.cn</li></ul>
        </div>
        <div class="closebox">
            <input type="button" value="关闭" />
            <p>
                <img src="/Member/images/PayManage/biao_print.gif" />
                打印该页</p>
        </div>
    </div>
</asp:Content>
