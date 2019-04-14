<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MachingMessage.aspx.cs" CodePage="936"
    Inherits="helper_MachingMessage" MasterPageFile="~/MasterPage.master" %>

<%@ Register Assembly="Tz888.Common" Namespace="Tz888.Common.Pager" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../css/messagemanage.css" rel="stylesheet" type="text/css" />
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
        <!-- -->
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
        <div class="blank20">
        </div>
        <div class="handtop">
            <ul>
                <li class="liwai">��������б�</li><li><a href="MatchingInfo.aspx">�ҵĶ���</a></li></ul>
        </div>
        <asp:ScriptManager id="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class=" cshibiank" style="padding: 5px">
            <asp:UpdatePanel id="UpdatePanel1" runat="server">
                <contenttemplate>
<DIV id="ListDiv"><TABLE class="taba" cellSpacing=0 width="100%" align=center><TBODY><TR class="tabtitle">
<TD width="5%"></TD>
<TD class="tabtitle" align=left width="40%">����</TD>
<TD class="tabtitle" align=center width="18%">����ʱ��</TD>
<TD class="tabtitle" align=center width="15%">������</TD>
<TD class="tabtitle" align=center width="8%">��Ա��</TD>
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
                                        �鿴
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
                                        �鿴
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
