<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master"
    ResponseEncoding="GB2312" Title="我的购物券-拓富中心-中国招商投资网" CodeFile="ticket_exchange_record.aspx.cs"
    Inherits="PayManage_ticket_exchange_record" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="/css/paymanage.css" rel="stylesheet" type="text/css" />
    <!--我的购物车 -->
    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="mainconbox">
        <div class="topzi">
            <div class="left">
                我的购物券
            </div>
            <div class="clear">
            </div>
        </div>
        <!--购物券兑换 -->
        <div class="mycartbox">
            <div class="handtop">
                <ul>
                    <li><a href="ticket_exchange.aspx">购物券兑换</a></li><li class="liwai">兑换记录</li><li><a
                        href="http://pay.topfo.com/cost/project.aspx" target="_blank">购物券资源专区</a> </li>
                </ul>
            </div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <contenttemplate>
            <div class="con cshibiank">
                <div class="titlea">
                  <span class="chengcu">  <asp:Literal ID="lblLoginName" runat="server"></asp:Literal></span>的详细兑换记录</div>
                <div class="titleb cyibank">
                    累计积分<asp:Literal ID="lblJifenCount" runat="server" Text="0"></asp:Literal>分，共兑换<asp:Literal
                        ID="lblVoucherNum" runat="server" Text="0"></asp:Literal>次，累计兑换购物券总额 <font class="chengcu"> <asp:Literal
                            ID="lblBalanceNum" runat="server" Text="0" ></asp:Literal></font>元，已使用<font class="chengcu"><asp:Literal
                                ID="lblUseNum" runat="server" Text="0"></asp:Literal></font>元<span></span>
                </div>
                <table width="757" border="0" cellpadding="0" cellspacing="0"  class="taba">
                    <tr class="tabtitle">
                        <td width="111" align="center" class="tabtitle">
                            编号
                        </td>
                        <td width="126" align="center" class="tabtitle">
                            兑换时间</td> 
                        <td width="120" align="center" class="tabtitle">
                            兑换积分
                        </td>
                        <td width="128" align="center" class="tabtitle">
                            兑换金额(元)</td>
                        <td width="121" align="center" class="tabtitle">
                            剩余积分</td>
                        <td width="151" align="center" class="tabtitle">
                            购物券有效截至日期
                        </td>
                    </tr>
                <asp:Repeater runat="server" ID="myList">
                    <ItemTemplate>
                            <tr>
                                <td width="110" align="center">
                                    <asp:Literal runat="server" ID="lblID"></asp:Literal>
                                </td>
                                <td width="127" align="center">
                                    <%#Eval("ConvertDate") %>
                                </td>
                                <td width="120" align="center">
                                    <%#Eval("ConvertIntegral") %>
                                    分</td>
                                <td width="129" align="center">
                                    <%#Eval("VoucherMaxBalance","{0:N}") %>
                                    元</td>
                                <td width="120" align="center">
                                    <%#Eval("LeftIntegral")%>
                                    分</td>
                                <td width="151" align="center">
                                    <%#Eval("ExpiredDate","{0:yyyy-MM-dd}") %>
                                </td>
                            </tr>
                      
                    </ItemTemplate>
                     <AlternatingItemTemplate>
                     <tr class="tabb">
                                <td width="110" align="center"  class="tabb">
                                    <asp:Literal runat="server" ID="lblID"></asp:Literal>
                                </td>
                                <td width="127" align="center"  class="tabb">
                                    <%#Eval("ConvertDate") %>
                                </td>
                                <td width="120" align="center"  class="tabb">
                                    <%#Eval("ConvertIntegral") %>
                                    分</td>
                                <td width="129" align="center"  class="tabb">
                                    <%#Eval("VoucherMaxBalance","{0:N}") %>
                                    元</td>
                                <td width="120" align="center"  class="tabb">
                                    <%#Eval("LeftIntegral")%>
                                    分</td>
                                <td width="151" align="center"  class="tabb">
                                    <%#Eval("ExpiredDate","{0:yyyy-MM-dd}") %>
                                </td>
                            </tr>
                     </AlternatingItemTemplate>
                </asp:Repeater>
                  </table>
                <div class="bottom">
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
                            font-size: 12px;" runat="server" onserverclick="btnGo_ServerClick" />
                    </p>
                </div>
                <div class="clear">
                </div>
            </div>
            
            </contenttemplate>
            </asp:UpdatePanel>
        </div>
        <!--帮助 -->
    </div>
</asp:Content>
