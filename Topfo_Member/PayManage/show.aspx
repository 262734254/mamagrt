<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="show.aspx.cs" Inherits="PayManage_show" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="/css/accountinfo.css" rel="stylesheet" type="text/css" />
    
    <div class="mainconbox">
        <div class="titled">
            <div class="left">
                我要充值&gt;&gt;财付通充值</div>
            <div class="right">
                <img src="../images/publish/biao_01.gif" width="14" height="15" />
                <a href="http://www.topfo.com/web13/help/AccountCZ.shtml" target="_blank">充值流程详解</a>
                <a href="http://www.topfo.com/web13/help/AccountInfo.shtml#16" target="_blank">安全交易须知</a>
            </div>
            <div class="clear">
            </div>
        </div>
        <div class="szxczbox">
            <div class="suggestbox lightc allxian ">
                <h1>
                    温馨提示</h1>
                <span class="tishiwb">拓富充值卡可以快速对指定账户进行充值，完成资源购买和其他消费行为。 <a href="http://www.topfo.com/help/AccountCZ.shtml"
                    target="_blank">了解更多</a>
                    <br>
                    我们准备了多种购买渠道供您选择，方便、快捷！
                    <br />
                    如果您有任何疑问，请拨打我们的客服电话：0755-82210116 82212980 <a href="tofocard_buy.aspx" class="bule">立即购买</a> </span>
            </div>
            <div class="blank20">
            </div>
            <%=showStr %>
        </div>
    </div>
</asp:Content>
