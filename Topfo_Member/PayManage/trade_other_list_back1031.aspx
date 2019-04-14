<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" ResponseEncoding="GB2312"
    Title="我的购物车-拓富中心-中国招商投资网" AutoEventWireup="true" CodeFile="trade_other_list.aspx.cs"
    Inherits="PayManage_trade_other_list" %>

<%@ Register Src="../Controls/PayPageFoot.ascx" TagName="PayPageFoot" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="/css/paymanage.css" rel="stylesheet" type="text/css" />
    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <!--我的购物车 -->
    <div class="mainconbox">
        <div class="topzi">
            <div class="left">
                其它交易管理
            </div>
            <div class="right">
                <a href="http://www.topfo.com/help/resourceswap.shtml" target="_blank" class="chenglink">
                    交易完全教程</a></div>
            <div class="clear">
            </div>
        </div>
        <div class="suggestbox allxian">
            <h1>
                温馨提示：</h1>
            <p>
                我们为您开通了多种支付渠道，无论金额大小皆可轻松支付！
                <br />
                如果您的账户余额充足，使用账户余额支付是最快捷的支付方式。您现在的账户余额为<asp:Literal ID="lblUserPoint" runat="server"></asp:Literal>元。
                点此&gt;&gt;<a href="account_cz.aspx">立即充值</a><br />
                为降低您的交易风险，建议您优先选择<a href="http://www.topfo.com/TopfoCenter/Application/superiorityApp.shtml"
                    target="_blank">拓富通会员</a>发布的资源！<br />
            </p>
        </div>
        <div class="blank20">
        </div>
        <!--我的购物车 -->
        <div class="mycartbox">
            <div class="handtop">
                <ul>
                    <li class="liwai">已付款交易</li><li><a href="trade_other_wait.aspx" style="text-decoration: none">
                        未付款交易</a> </li>
                </ul>
            </div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <contenttemplate>
            <div class="con cshibiank">
                <div class="search">
                    <div class="lefts">
                        资源查询：<select id="sDiff" runat="server" name="jumpMenu">
                            <option selected="selected" value="all">---全部---</option>
                            <option value="90">三个月以上</option>
                            <option value="60">最近三个月</option>
                            <option value="30">最近一个月</option>
                            <option value="7">最近一周内</option>
                        </select>
                        <input id="btnSearch" type="button" value="查询" onserverclick="btnSearch_ServerClick"
                            runat="server" /></div>
                    <div class="rights">
                        每页显示：<a href="#"><asp:LinkButton ID="PageSize10" runat="server" OnClick="PageSize10_Click">10</asp:LinkButton></a>条
                        <asp:LinkButton ID="PageSize20" runat="server" OnClick="PageSize20_Click">20</asp:LinkButton>
                        条 <a href="#">
                            <asp:LinkButton ID="PageSize30" runat="server" OnClick="PageSize30_Click">30</asp:LinkButton></a>
                        条</div>
                    <div class="clear">
                    </div>
                </div>
                <table width="100%" align="center" cellspacing="0" class="taba">
                    <tr class="tabtitle">
                        <td width="12%" align="center" class="tabtitle">
                            类别</td>
                        <td width="25%" align="center" class="tabtitle">
                            服务与产品</td>
                        <td width="10%" align="center" class="tabtitle">
                            价格</td>
                        <td width="14%" align="center" class="tabtitle">
                            交易时间</td>
                        <td width="27%" align="center" class="tabtitle">
                            状态</td>
                    </tr>
                    <asp:Repeater runat="server" ID="myList">
                        <ItemTemplate>
                            <tr>
                                <td width="12%" height="25" align="center">
                                    <%#GetType(Eval("buyType"))%>
                                </td>
                                <td width="25%" align="center">
                                    <%#GetTitle(Eval("ConsumeType"),Eval("Quantity"))%>
                                </td>
                                <td width="10%" align="center">
                                    <%#Eval("DicAmount", "{0:N}")%>
                                    元
                                </td>
                                <td width="14%" align="center">
                                    <%#Eval("PayDate")%>
                                </td>
                                <td width="26%" align="center">
                                    已付款 |<a href="trade_detail.aspx?order_no=<%#Eval("orderNo")%>&type=<%#Eval("buyType")%>">明细</a>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr class="tabb">
                                <td width="12%" height="25" align="center" class="tabb">
                                    <%#GetType(Eval("buyType"))%>
                                </td>
                                <td width="25%" align="center" class="tabb">
                                    <%#GetTitle(Eval("ConsumeType"),Eval("Quantity"))%>
                                </td>
                                <td width="10%" align="center" class="tabb">
                                    <%#Eval("DicAmount", "{0:N}")%>
                                    元
                                </td>
                                <td width="14%" align="center" class="tabb">
                                    <%#Eval("PayDate")%>
                                </td>
                                <td width="26%" align="center" class="tabb">
                                    已付款 |<a href="trade_detail.aspx?order_no=<%#Eval("orderNo")%>&type=<%#Eval("buyType")%>">明细</a>
                                </td>
                            </tr>
                        </AlternatingItemTemplate>
                    </asp:Repeater>
                </table>
                <p>
                    共<asp:Literal ID="lblCount" runat="server" Text="0"></asp:Literal>条 页次：<asp:Literal
                        ID="lblCurrPage" runat="server" Text="0"></asp:Literal>/<asp:Literal ID="lblPageCount"
                            runat="server" Text="0"></asp:Literal>页
                    <asp:LinkButton ID="FirstPage" runat="server" OnClick="FirstPage_Click">首页</asp:LinkButton>
                    <asp:LinkButton ID="PerPage" runat="server" OnClick="PerPage_Click">上一页</asp:LinkButton>
                    <asp:LinkButton ID="NextPage" runat="server" OnClick="NextPage_Click">下一页</asp:LinkButton>
                    <asp:LinkButton ID="LastPage" runat="server" OnClick="LastPage_Click">尾页</asp:LinkButton><span>转到
                        第
                        <input name="textarea" type="text" id="txtPage" style="width: 36px; height: 15px;"
                            runat="server">
                        页</span>
                    <input type="button" name="button2" id="btnGo" value="GO" style="width: 30px; height: 20px;
                        font-size: 12px;" runat="server" onserverclick="btnGo_ServerClick" /></p>
            </div>
            </contenttemplate>
            </asp:UpdatePanel>
        </div>
        <div class="blank20">
        </div>
        <!--帮助 -->
        <div class="helpbox">
            <div class="titleh">
                <img src="../images/PayManage/biao_print.gif" />
                <a href="javascript:;" onclick="windows.print()">打印该页</a></div>
            <div class="con">
                <h1>
                    <img src="../images/icon_yb.gif" align="absmiddle" />
                    帮助</h1>
                <p>
                    点击"明细"可以查看订单的详细情况；
                    <br />
                    <uc1:PayPageFoot ID="PayPageFoot1" runat="server" />
                </p>
            </div>
        </div>
        <div class="blank20">
        </div>
    </div>
</asp:Content>
