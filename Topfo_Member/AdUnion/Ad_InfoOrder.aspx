<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" ResponseEncoding="GB2312"
    Title="我的资源的互告跟踪-拓富中心-中国招商投资网" AutoEventWireup="true" CodeFile="Ad_InfoHit.aspx.cs"
    Inherits="AdUnion_Ad_InfoHit" %>

<%@ Register Src="../Controls/PayPageFoot.ascx" TagName="PayPageFoot" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../css/paymanage.css" rel="stylesheet" type="text/css" />
    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <!--我的购物车 -->
    <div class="mainconbox">
        <div class="topzi">
            <div class="left">
                我的资源的点击查看</div>
            <div class="right" style="margin-bottom: 13px;">
                <img src="http://member.topfo.com/images/hand_1_2.gif" />
                <a href="http://www.topfo.com/help/resourceswap.shtml" target="_blank">交易完全教程</a></div>
            <div class="clear">
            </div>
        </div>
        <div class="suggestbox lightc allxian">
            <h1>
                温馨提示：</h1>
            <p>
                我们为您统计了您发布的资源的互告关注度与收益部分，以便您能更好的了解您的资源。<br />
            </p>
        </div>
        <div class="blank20">
        </div>
        <!--我的购物车 -->
        <div class="mycartbox">
            <div class="handtop">
                
            </div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <contenttemplate>
            <div class="con cshibiank">
                <div class="search">
                    <div class="lefts">
                    </div>
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
                        <td width="18%" align="center" class="tabtitle">
                            购买者</td>
                        <td width="30%" align="left" class="tabtitle">
                            购买时间</td>
                        <td width="50%" align="left" class="tabtitle">
                            购买来源网站</td>
                        <td width="1%" align="center" class="tabtitle">
                            </td>
                        <td width="1%" align="center" class="tabtitle">
                            </td>
                        <td width="10%" align="center" class="tabtitle">
                            </td>
                    </tr>
                    <asp:Repeater runat="server" ID="myList">
                        <ItemTemplate>
                            <tr>
                                <td height="25" align="center">
                                    <%#Eval("LoginName")%>
                                </td>
                                <td>
                                    <%#Eval("ConsumeTime", "{0:yyyy-MM-dd}")%>
                                </td>
                                <td>
                                    <a href='<%#Eval("SiteUrl") %>' target="_blank"><%#Eval("SiteName")%></a>
                                </td>
                                <td align="center">&nbsp;
                                </td>
                                <td align="center">&nbsp;
                                </td>
                                <td align="center">
                                    <a href="/Manage/PertinentLink.aspx?infoid=<%#Eval("infoid") %>&type=<%#Eval("InfoTypeID") %>">相关资源</a><a href="#"></a></td>
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr class="tabb">
                                <td height="25" align="center">
                                    <%#Eval("LoginName")%>
                                </td>
                                <td>
                                    <%#Eval("ConsumeTime", "{0:yyyy-MM-dd}")%>
                                </td>
                                <td>
                                    <a href='<%#Eval("SiteUrl") %>' target="_blank"><%#Eval("SiteName")%></a>
                                </td>
                                <td align="center">&nbsp;
                                </td>
                                <td align="center">&nbsp;
                                </td>
                                <td align="center">
                                    <a href="/Manage/PertinentLink.aspx?infoid=<%#Eval("infoid") %>&type=<%#Eval("InfoTypeID") %>">相关资源</a><a href="#"></a></td>
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
                        第<input name="textarea" type="text" id="txtPage" style="width: 36px; height: 15px;"
                            runat="server">
                        页</span>
                    <input type="button" name="button2" id="btnGo" value="GO" style="width: 30px; height: 20px;
                        font-size: 12px;" runat="server" onserverclick="btnGo_ServerClick" />
                </p>
            </div>
            </contenttemplate>
            </asp:UpdatePanel>
            <div class="buttom">
            </div>
        </div>
    </div>
    <div class="blank20">
    </div>
    <!--帮助 -->
    <div class="mainconbox">
        <div class="helpbox">
            <div class="titleh">
                <img src="../images/PayManage/biao_print.gif" />
                <a href="javascript:;" onclick="window.print()">打印该页</a></div>
            <div class="con">
                <h1>
                    <img src="../images/icon_yb.gif" align="absmiddle" />
                    帮助</h1>
                <p>
                    · 如果您提交了订单，点击<a href="trade_info_wait.aspx">我的购物车</a>可以查看订单的明细情况；<br />
                    · 相关资源是指系统根据您选择的资源为您推荐的类似资源；<br />
                </p>
                <dir>
                    <img src="../images/PayManage/hand.gif" width="18" height="12" />
                    <a href="http://www.topfo.com/help/resourceswap.shtml" target="_blank">更多帮助</a></dir></div>
            <div class="bottomzi">
                <uc1:PayPageFoot ID="PayPageFoot1" runat="server" />
                &nbsp;</div>
        </div>
    </div>
</asp:Content>
