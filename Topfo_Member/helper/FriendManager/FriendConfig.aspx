<%@ Page Language="C#"   AutoEventWireup="true" CodeFile="FriendConfig.aspx.cs" MasterPageFile="~/MasterPage.master"  Inherits="helper_FriendManager_FriendConfig" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  <link href="../../css/messagemanage.css" rel="stylesheet" type="text/css" />
    <link href="../../css/index_fhy.css" rel="stylesheet" type="text/css" />
    <link href="../../css/right_fhy.css" rel="stylesheet" type="text/css" />
    <link href="../../img/member.css" rel="stylesheet" type="text/css" />
    <link href="../../css/common.css" rel="stylesheet" type="text/css" />
<div class="mainconbox">
            <div class="topzi">
                <div class="left">
                    �ҵĺ���</div>
                <div class="right">
                    <img src="../../images/AccountInfo/handbiao.gif" width="16" height="10" />
                   <a href="http://www.topfo.com/help/friendmanage.shtml" target="_blank">������/�������</a></div>
                <div class="clear">
                </div>
            </div>
            <div class="blank0">
            </div>
            <div class="handtop">
                <ul>
                   <li><a href="FriendSearch.aspx">��Ӻ���</a></li>
                   <li><a href="FriendList.aspx">�����б�</a></li>
                    <li><a href="InfoView.aspx">�����û���Դ</a></li>
                   <li><a href="FriendBlacklist.aspx">������</a></li>
                   <li class="liwai">��ɧ������</li></ul>
            </div>
            <div class=" cshibiank">
                <div class="blacktopbox">
                    <h1 class="dottedl">
                        <img src="../../images/AccountInfo/biao_yuan.gif" width="15" height="15" align="absmiddle" />
                        <strong>��ʾ��</strong>ֻ���ظ�ͨ��Ա�������÷�ɧ�ŵ�Ȩ�ޣ�  
                        <asp:HyperLink ID="linktopf" runat="server" Visible="False">�����������ظ�ͨ</asp:HyperLink>
                    </h1>
                    <div class="blank0">
                    </div>
                    <table width="680" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td colspan="2" align="center" class="font14">
                                ֻ���������������Ļ�Ա���ܼ���Ϊ���ѣ�</td>
                        </tr>
                        <tr>
                            <td width="338" align="right">
                                ��Ա��ݣ�</td>
                            <td width="342">
                                <p>
                                    <label>
                                        <asp:DropDownList ID="ddlMemberGrade" runat="server">
                                            <asp:ListItem Value="0">����</asp:ListItem>
                                            <asp:ListItem Value="1">�ظ�ͨ��Ա</asp:ListItem>
                                            <asp:ListItem Value="2">��ͨ��Ա</asp:ListItem>
                                        </asp:DropDownList></label>&nbsp;</p>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                ��Ա���ͣ�</td>
                            <td>
                                <asp:DropDownList ID="ddlMemberType" runat="server" OnSelectedIndexChanged="ddlMemberType_SelectedIndexChanged" AutoPostBack="true" Width="83px">
                                    <asp:ListItem Value="0" Selected="True">����</asp:ListItem>
                                    <asp:ListItem Value="1">��������</asp:ListItem>
                                    <asp:ListItem Value="2">��ҵ��λ</asp:ListItem>
                                    <asp:ListItem Value="3">����</asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td align="right">
                                ��Ա����</td>
                            <td>
                                <asp:DropDownList ID="ddlMemberIntent" runat="server" Width="80px">
                                    <asp:ListItem Value="0">����</asp:ListItem>
                                    <asp:ListItem Value="1">��������</asp:ListItem>
                                    <asp:ListItem Value="2">��Ʒ����</asp:ListItem>
                                    <asp:ListItem Value="3">��Ŀ����</asp:ListItem>
                                    <asp:ListItem Value="4">��ĿͶ��</asp:ListItem>
                                    <asp:ListItem Value="5">��ҵ����</asp:ListItem>
                                    <asp:ListItem Value="6">��Ʒ����</asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                          <td height="76" colspan="2" align="center">
                               <asp:Button ID="btnOk" runat="server" Height="25px" Text="ȷ��" OnClick="btnOk_Click" />
                                <asp:Button ID="btnCancel" runat="server" Height="26px" Text="ȡ��" />
                                <br />
								<div class="blank6"></div>
                                <asp:Panel runat="server" ID="panelSet" Width="680" Visible="false">
                                    <asp:Label ID="lbSetText" runat="server" Text="" Width="490px"></asp:Label>
                                </asp:Panel>
								<div class="blank6"></div>
                              <span class="hui">����̫��������Ӱ���������Ϊ���ѵ����� </span>                            </td>
                        </tr>
                    </table>
                    <div class="blank20">
                    </div>
                </div>
            </div>
        </div>
</asp:Content>