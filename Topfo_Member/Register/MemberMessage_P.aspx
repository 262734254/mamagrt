<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MemberMessage_P.aspx.cs" enableEventValidation="false"
    Inherits="Register_MemberMessage_P" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>��ҵ��Ա����</title>
    <link href="../css/common.css" rel="stylesheet" type="text/css" />
    <link href="../css/memberdata.css" rel="stylesheet" type="text/css" />
    <link href="../css/bottomcss.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form runat="server">
        <div style="width:980px;margin:0 auto;text-align:center"><iframe scrolling="no" frameBorder="0" width="100%" height="100px"  src=" http://www.topfo.com/web13/common/header_tfzs.html"></iframe></div>
        <div class="clear">
        </div>
        <div class="topbg">
        </div>
        <div class="mainbox">
            <div class="titletop">
                <asp:Label ID="lblNickName2" runat="server"></asp:Label>�Ļ�Ա����</div>
            <div class="left">
                <asp:Image ID="imgHead" runat="server" Height="136px" ImageUrl="../images/MemberData/nopic.gif"
                    Width="153px" />&nbsp;<p>
                        <b></b><span class="hui">
                            <asp:Label ID="lbRealName" runat="server"></asp:Label>
                            <asp:Label ID="lbSex" runat="server"></asp:Label>
                            <asp:Label ID="lbCareer" runat="server"></asp:Label><br />
                            ������λ��<asp:Label ID="lbOrganizationName" runat="server" style="word-wrap: break-word; word-break: break-all;" Width="150px"></asp:Label><br />
                            ��ַ��<asp:Label ID="lbtAddress" runat="server" style="word-wrap: break-word; word-break: break-all;" Width="170px"></asp:Label><br />
                            �绰��<asp:Label ID="lbTel" runat="server" style="word-wrap: break-word; word-break: break-all;" Width="170px"></asp:Label><br />
                            �ֻ���<asp:Label ID="lbMoble" runat="server" style="word-wrap: break-word; word-break: break-all;" Width="170px"></asp:Label><br />
                            ���棺<asp:Label ID="lbFax" runat="server" style="word-wrap: break-word; word-break: break-all;" Width="170px"></asp:Label><br />��˾��ַ��<asp:Label ID="lbSite" runat="server" Width="150px"></asp:Label></span></p>
                <h1>
                    ��������</h1>
                <div class="buttom">
                    <div id="divOnlineTalk" runat="server"></div> 
                    <asp:HyperLink ID="HyperLink2" runat="server" ImageUrl="../images/MemberData/buttom_fxx.gif"
                        Target="_blank">HyperLink</asp:HyperLink><asp:HyperLink ID="HyperLink1" runat="server"
                            ImageUrl="../images/MemberData/buttom_jwhy.gif" Target="_blank">HyperLink</asp:HyperLink><a href="#"></a></div>
            </div>
            <!-- -->
            <div class="right">
                <div  id="GradeDiv" runat="server">
                    <h1>   <img src="../images/icon_yb.gif" width="17" height="17" /> �û�Ա���ظ�ͨ��Ա</h1>

                </div>
                <ul>
                    <li>��Ա�û�����<asp:Label ID="lbLoginName" runat="server"></asp:Label></li><li>�ǳƣ�
                        <asp:Label ID="lbNickName" runat="server"></asp:Label></li><li>��Ա���ͣ�
                            <asp:Label ID="lbManageType" runat="server"></asp:Label></li><li>��Ա����
                                <asp:Label ID="lbRequar" runat="server"></asp:Label></li><li>ע��ʱ�䣺
                                    <asp:Label ID="lbRegTime" runat="server"></asp:Label></li><li>��½������<asp:Label ID="lbLoginCount"
                                        runat="server"></asp:Label>��</li><li>�ϴε�½ʱ�䣺
                                            <asp:Label ID="lbLoginB" runat="server"></asp:Label><div class="clear"></div>
                </li>
                </ul>
                <div class="blank20">
                </div>
                <div class="dottedlline">
                </div>
                <h1>
                    <img src="../images/icon_yb.gif" width="17" height="17" />
                    ҵ����¼</h1>
                <p>
                    �ѷ���������<asp:Label ID="lbPublishCount" runat="server" ForeColor="Red">0</asp:Label>��
                
                <asp:Repeater ID="RepeaterPublish" runat="server">
                        <ItemTemplate>
                            <table align="center" cellspacing="0" height="26" width="41%">
                                <tr>
                                    <td>
                                        ��</td>
                                    <td>
                                        <a href='<%#Eval("HtmlFile")%>' target="_blank">
                                            <%#Eval("Title")%>
                                        </a>
                                    </td>
                                    <td>
                                        <%#Eval("PublishT")%>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
              </asp:Repeater>
                    &nbsp;&nbsp;<br />
                    ��ҵչ����
                    <asp:Label ID="lbExhibitionHall" runat="server" Text="����"></asp:Label>
                </p>
            </div>
            <div class="clear">
            </div>
        </div> 
    </form>
    <iframe scrolling="no" frameBorder="0" width="100%"  src="http://www.topfo.com/web13/common/bottom.html"></iframe>

</body>
</html>
