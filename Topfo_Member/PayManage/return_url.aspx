<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="return_url.aspx.cs" Inherits="PayManage_return_url" Title="财付通充值-充值成功" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="/css/common.css" rel="stylesheet" type="text/css" />
    <link href="/css/accountinfo.css" rel="stylesheet" type="text/css" />
    <div class="mainconbox">
        <div class="titled">
            <div class="left">
                我要充值&gt;&gt;财付通充值&gt;&gt;充值成功</div>
            <div class="right">
                <img src="http://www.topfo.com/t/images/publish/biao_01.gif" width="14" height="15" />
                <a href="http://www.topfo.com/web13/help/AccountCZ.shtml" target="_blank">充值流程详解</a>
                <a href="http://www.topfo.com/web13/help/AccountInfo.shtml#16" target="_blank">安全交易须知</a></div>
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
                    如果您有任何疑问，请拨打我们的客服电话：0755-82210116 82212980 <a href="http://www.topfo.com/tofocard_buy.aspx"
                        class="bule">立即购买</a> </span>
            </div>
            <div class="blank20">
            </div>
            <table width="737" height="127" border="0" align="center" cellpadding="0" cellspacing="0"
                class="huikuang">
                <tr>
                    <td height="125">
                        <table width="100%" border="0" cellpadding="2" cellspacing="1" bgcolor="#eeeedd"
                            class="baikuang">
                            <tr>
                                <td height="29" align="right" bgcolor="#ebebeb">
                                    充值订单号：</td>
                                <td width="518" align="left" bgcolor="#ffffff">
                                    <asp:Label ID="lab_OrderNo" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td height="29" align="right" bgcolor="#ebebeb">
                                    银行交易号：</td>
                                <td align="left" bgcolor="#ffffff">
                                    <asp:Label ID="lab_TenNo" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td height="35" align="right" bgcolor="#ebebeb">
                                    充值金额：</td>
                                <td align="left" bgcolor="#ffffff" height="35">
                                    <asp:Label ID="lab_Point" runat="server"></asp:Label>元</td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
