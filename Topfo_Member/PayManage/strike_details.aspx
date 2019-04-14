<%@ Page Language="C#"  MasterPageFile="~/MasterPage.master" ResponseEncoding="GB2312" Title="充值充值管理-拓富中心-中国招商投资网" AutoEventWireup="true" CodeFile="strike_details.aspx.cs" Inherits="PayManage_strike_details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
 <link href="/css/common.css" rel="stylesheet" type="text/css" />
    <link href="/css/paymanage.css" rel="stylesheet" type="text/css" />
    <!--已完成交易 -->
    <div id="mainconbox">
        <div class="topzi">
            <div class="left">
                订单明细</div>
            <div class="clear">
            </div>
        </div>
        <div class="suggestbox">
            <p>
                · 您现在查看的是订单号为

                <asp:Literal ID="lblORDER" runat="server"></asp:Literal>
                的订单明细情况。如果您有任何疑问，请拨打我们的客服电话：<strong>
<!--#include file="../Common/custel.html" --></strong><br />
            </p>
        </div>
        <!--充值订单信息 -->
        <div class="blank20">
        </div>
        <div class="creditsbox">
            <h1 class="cyibank">
                充值订单信息</h1>
            <ul>
                <li>在线充值&nbsp;
                <div class="clear">
                </div>
            </li>
            </ul>
            <ul>
                <li>订单号：<span class="chengcu"></span>
                    <asp:Label ID="lblOrderNo" runat="server"></asp:Label>
                </li>
                <li>生成时间：<asp:Label ID="lblOrderDate" runat="server"></asp:Label><div class="clear">
                </div>
            </li>
            </ul>
            <ul>
                <li>充值金额：<asp:Label ID="lblAmount" runat="server"></asp:Label>元</li>
                <li>充值帐户：<asp:Literal ID="lblLoginName" runat="server"></asp:Literal></li><li>充值状态：<asp:Label
                    ID="lblStatus" runat="server"></asp:Label></li><li>充值方式：<asp:Label ID="lblPayType"
                        runat="server"></asp:Label><div class="clear">
                        </div>
            </li>
            </ul>
        </div>
        <div class="blank20">
        </div>
        
        <div class="closebox">
            <input type="button" class="buttomal"  value="关闭" onclick="javascript:history.go(-1)" />
            <p>
                <img src="../images/PayManage/biao_print.gif" />
                <a href="javascript:;" onclick="window.print()">打印该页</a></p>
        </div>
    </div>
  </asp:Content>
