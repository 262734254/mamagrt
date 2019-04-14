<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ModifyMaching.aspx.cs" Inherits="helper_ModifyMaching" 
    MasterPageFile="~/MasterPage.master" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

<link href="../css/messagemanage.css" rel="stylesheet" type="text/css" />
<link rel="/css/stylesheet" href="/css/cm.css" type="text/css" >
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
        <!-- -->
        <%--<div class="suggestbox lightc allxian" style="line-height: 23px" id="divMessage" runat="server">
            
        </div>--%>
        <div class="blank20">
        </div>
        <div class="handtop">
            <ul>
                <li><a href="MatchingInfo.aspx">我的订阅 </a></li>
                <li class="liwai">添加订阅 </li>
            </ul>
        </div>       
        <div class="smsconbox cshibiank">          
            <div class="blank20" >
            </div>
            <table id="ff" align="center" border="0" cellpadding="3" cellspacing="0" width="96%">
                <tr>
                    <td align="middle" bgcolor="#ffffff">
                        <table
                            width="96%" border="0" align="center" cellpadding="3" cellspacing="1" bgcolor="#999999" id="f">
                            <tr>
                                <td width="130" align="left" bgcolor="#FFFFFF">
                                    搜索订阅的名称</td>
                                <td align="left" bgcolor="#FFFFFF">
                                    &nbsp;
                              <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox> 
                              <asp:RequiredFieldValidator
                                        ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitle" ErrorMessage="订阅名称不能为空"></asp:RequiredFieldValidator></td>
                            </tr>
                            <tr style="font-family: Arial">
                                <td align="left" bgcolor="#ffffff" height="7" width="130">
                                    <span class="12g"><font face="Arial, Helvetica, sans-serif">订阅周期： </font></span>
                                    <br />
                                </td>
                                <td align="left" bgcolor="#ffffff" height="7">
                                    <asp:RadioButtonList ID="rblValidateTerm" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="0">一天</asp:ListItem>
                                        <asp:ListItem Value="1">三天</asp:ListItem>
                                        <asp:ListItem Value="2" Selected="True">一周</asp:ListItem>
                                    </asp:RadioButtonList></td>
                            </tr>
                            <tr>
                                <td align="left" bgcolor="#ffffff" height="33" width="130">
                                    <span class="12g"><font face="Arial, Helvetica, sans-serif">每次发送数量： </font></span>
                                </td>
                                <td align="left" bgcolor="#ffffff" height="33">
                                    &nbsp;
                                    <asp:DropDownList ID="ddlItemCount" runat="server">
                                        <asp:ListItem Value="10">10条</asp:ListItem>
                                        <asp:ListItem Value="20">20条</asp:ListItem>
                                        <asp:ListItem Value="30">30条</asp:ListItem>
                                        <asp:ListItem Value="50">50条</asp:ListItem>
                                    </asp:DropDownList></td>
                            </tr>
                            <%--<tr>
                                <td align="left" bgcolor="#ffffff" height="45" width="130">
                                    通知设置：</td>
                                <td align="left" bgcolor="#FFFFFF">
                              <asp:Label ID="lbNotice" runat="server"></asp:Label></td>
                            </tr>--%>
                      </table>
                    
					<div class="blank6"></div>
                        <asp:Label ID="lbMobile" runat="server"></asp:Label>
                        <asp:Label ID="labMessage" runat="server" Visible="False"></asp:Label>
                       </td>
                </tr>
            </table>
        </div>
        <div class="pagebox" align="center">
            <asp:Button ID="btnCustom" runat="server"  CssClass="buttomal" Text="保存并搜索"
                OnClick="btnCustom_Click" />
                
            &nbsp;<div class="clear">
                </div>
        </div>
    </div>
    <script language="JavaScript" src="/js/cmPopWin.js" ></script>
</asp:Content>

