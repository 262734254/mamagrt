<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ModifyMaching.aspx.cs" Inherits="helper_ModifyMaching" 
    MasterPageFile="~/MasterPage.master" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

<link href="../css/messagemanage.css" rel="stylesheet" type="text/css" />
<link rel="/css/stylesheet" href="/css/cm.css" type="text/css" >
<div class="mainconbox">
        <div class="topzi">
            <div class="left">
                ��������</div>
            <div class="right">
                <img src="../images/AccountInfo/handbiao.gif" width="16" height="10" />
                <a href="http://www.topfo.com/help/subscribe.shtml#12" target="_blank">��ζ���</a></div>
            <div class="clear">
            </div>
        </div>
        <div class="suggestbox lightc allxian">
            <div id="pt" runat="server">
                �������Ͼ�������ֵ��Ĵ���˺û��ᣬ�������Ѷ������á�<br />
                ��һʱ����ռ�Ȼ�����ǧ�Ƹ���������
                <br />
                �������ӵ�����������Ķ��ģ��� <a href="/Register/VIPMemberRegister_In.aspx">�����ظ�ͨ��Ա</a>
            </div>
            <div id="tft" runat="server">
                �����ظ�ͨ��Ա������������������Ѷ���Ȩ��
            </div>
        </div>
        <!-- -->
        <%--<div class="suggestbox lightc allxian" style="line-height: 23px" id="divMessage" runat="server">
            
        </div>--%>
        <div class="blank20">
        </div>
        <div class="handtop">
            <ul>
                <li><a href="MatchingInfo.aspx">�ҵĶ��� </a></li>
                <li class="liwai">��Ӷ��� </li>
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
                                    �������ĵ�����</td>
                                <td align="left" bgcolor="#FFFFFF">
                                    &nbsp;
                              <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox> 
                              <asp:RequiredFieldValidator
                                        ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitle" ErrorMessage="�������Ʋ���Ϊ��"></asp:RequiredFieldValidator></td>
                            </tr>
                            <tr style="font-family: Arial">
                                <td align="left" bgcolor="#ffffff" height="7" width="130">
                                    <span class="12g"><font face="Arial, Helvetica, sans-serif">�������ڣ� </font></span>
                                    <br />
                                </td>
                                <td align="left" bgcolor="#ffffff" height="7">
                                    <asp:RadioButtonList ID="rblValidateTerm" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="0">һ��</asp:ListItem>
                                        <asp:ListItem Value="1">����</asp:ListItem>
                                        <asp:ListItem Value="2" Selected="True">һ��</asp:ListItem>
                                    </asp:RadioButtonList></td>
                            </tr>
                            <tr>
                                <td align="left" bgcolor="#ffffff" height="33" width="130">
                                    <span class="12g"><font face="Arial, Helvetica, sans-serif">ÿ�η��������� </font></span>
                                </td>
                                <td align="left" bgcolor="#ffffff" height="33">
                                    &nbsp;
                                    <asp:DropDownList ID="ddlItemCount" runat="server">
                                        <asp:ListItem Value="10">10��</asp:ListItem>
                                        <asp:ListItem Value="20">20��</asp:ListItem>
                                        <asp:ListItem Value="30">30��</asp:ListItem>
                                        <asp:ListItem Value="50">50��</asp:ListItem>
                                    </asp:DropDownList></td>
                            </tr>
                            <%--<tr>
                                <td align="left" bgcolor="#ffffff" height="45" width="130">
                                    ֪ͨ���ã�</td>
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
            <asp:Button ID="btnCustom" runat="server"  CssClass="buttomal" Text="���沢����"
                OnClick="btnCustom_Click" />
                
            &nbsp;<div class="clear">
                </div>
        </div>
    </div>
    <script language="JavaScript" src="/js/cmPopWin.js" ></script>
</asp:Content>

