<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MachingMessage.aspx.cs" CodePage="936"
    Inherits="helper_MachingMessage" MasterPageFile="~/MasterPage.master" %>

<%@ Register Assembly="Tz888.Common" Namespace="Tz888.Common.Pager" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../css/messagemanage.css" rel="stylesheet" type="text/css" />
    <div class="mainconbox">
        <div class="topzi">
            <div class="left">
                搜索订阅</div>
            <div class="right">
                <img src="../images/AccountInfo/handbiao.gif" width="16" height="10" />
                <a href="http://www.topfo.com/help/subscribe.shtml#12" target="_blank">如何订阅</a></div>
            <div class="clear">
            </div>
        </div>
        <!-- -->
        <div class="suggestbox lightc allxian">
            <div id="pt" runat="server">
                如果您无暇上网，又担心错过了好机会，请进行免费订阅设置。<br />
                第一时间抢占先机，万千财富滚滚来！
                <br />
                如果你想拥有无限数量的订阅，请 <a href="/Register/VIPMemberRegister_In.aspx">申请拓富通会员</a>
            </div>
            <div id="tft" runat="server">
                您是拓富通会员，享有无限数量的免费订阅权限
            </div>
        </div>
        <div class="blank20">
        </div>
        <div class="handtop">
            <ul>
                <li class="liwai">搜索结果列表</li><li><a href="MatchingInfo.aspx">我的订阅</a></li></ul>
        </div>
        <asp:ScriptManager id="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class=" cshibiank" style="padding: 5px">
            <asp:UpdatePanel id="UpdatePanel1" runat="server">
                <contenttemplate>
<DIV id="ListDiv"><TABLE class="taba" cellSpacing=0 width="100%" align=center><TBODY><TR class="tabtitle">
<TD width="5%"></TD>
<TD class="tabtitle" align=left width="40%">标题</TD>
<TD class="tabtitle" align=center width="18%">发布时间</TD>
<TD class="tabtitle" align=center width="15%">发布人</TD>
<TD class="tabtitle" align=center width="8%">会员价</TD>
<TD class="tabtitle" align=center width="5%"></TD>
<TD class="tabtitle" align=center width="13%"></TD>
</TR><asp:Repeater id="dgMatching" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td width="5%">
                                </td>
                                <td height="9" align="left">
                                    <a target="_blank" href="http://www.topfo.com/<%#Eval("HtmlFile") %>">
                                        <%#Eval("Title") %>
                                    </a>
                                </td>
                                <td height="9" align="center">
                                    <%#Eval("PublishT") %>
                                </td>
                                <td height="9" align="center">
                                   <%#getNickName(Eval("LoginName"))%>                                       
                                </td>
                                <td height="9" align="center" style="color:Red;">
                                   <%# isMianFei(Eval("MainPointCount"), "num", Eval("InfoID"))%> 
                                </td>
                                <td height="9" align="center">
                                    <a style="text-decoration:none;" target="_blank" href="http://www.topfo.com/<%#Eval("HtmlFile") %>">
                                        查看
                                    </a>
                                </td>
                                <td height="9" align="center">
                                    
                                        <%# isMianFei(Eval("MainPointCount"), "a",Eval("InfoID"))%>
                                    
                                </td>
                                
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr class="tabb">
                                <td width="5%">
                                </td>
                                <td height="9" align="left">
                                    <a target="_blank" href="http://www.topfo.com/<%#Eval("HtmlFile") %>">
                                        <%#Eval("Title") %>
                                    </a>
                                </td>
                                <td height="9" align="center">
                                    <%#Eval("PublishT") %>
                                </td>
                                <td height="9" align="center">
                                     <%#getNickName(Eval("LoginName"))%>            
                                </td>
                                <td height="9" align="center" style="color:Red;">
                                   <%# isMianFei(Eval("MainPointCount"), "num", Eval("InfoID"))%>
                                                                
                                </td>
                                <td height="9" align="center">
                                    <a style="text-decoration:none;" target="_blank" href="http://www.topfo.com/<%#Eval("HtmlFile") %>">
                                        查看
                                    </a>
                                </td>
                                <td height="9" align="center">
                                    <%# isMianFei(Eval("MainPointCount"), "a",Eval("InfoID"))%>
                                </td>
                            </tr>
                        </AlternatingItemTemplate>
                    </asp:Repeater></TBODY></TABLE><TABLE cellSpacing=0 cellPadding=0 width="100%" align=center border=0><TBODY>
                    <TR><TD align=center colSpan=5><cc1:Pager id="Pager1" runat="server" BorderStyle="None" Width="679px" SortType="DESC"
                     PagingMode="NonCached" KeyColumn="InfoID" ControlToAjaxPanel="ListDiv" SortColumn="InfoID" 
                     ShowCount="True" PagerStyle="CustomAndNumeric" ControlToPaginate="dgMatching"
                      ContentPlaceHolder="ContentPlaceHolder1" BackColor="White"></cc1:Pager> </TD></TR></TBODY></TABLE>
                      </DIV>
</contenttemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
