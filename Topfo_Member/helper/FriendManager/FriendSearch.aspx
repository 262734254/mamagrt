<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master"
     CodeFile="FriendSearch.aspx.cs" Inherits="helper_FriendManager_FriendSearch" %>
<%@ Register Src="../../Controls/ZoneSelectControl.ascx" TagName="ZoneSelectControl" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<link href="../../css/index_fhy.css" rel="stylesheet" type="text/css" />
    <link href="../../css/right_fhy.css" rel="stylesheet" type="text/css" />
    <link href="../../img/member.css" rel="stylesheet" type="text/css" />
     <link href="../../css/messagemanage.css" rel="stylesheet" type="text/css" />
     <link href="../../css/common.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
function chk()
{
    if(document.getElementById("ctl00_ContentPlaceHolder1_Radio1").checked)
    {
        document.getElementById("panelExact").style.display="";
        document.getElementById("panelAdvance").style.display="none";
    }
     if(document.getElementById("ctl00_ContentPlaceHolder1_Radio2").checked)
    {
        document.getElementById("panelExact").style.display="none";
        document.getElementById("panelAdvance").style.display="";
    }    
}

    </script>



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
                <li class="liwai">��Ӻ���</li><li><a href="FriendList.aspx">�����б�</a></li>
                    <li><a href="InfoView.aspx">�����û���Դ</a></li>
                    <li><a href="FriendBlacklist.aspx">������</a></li><li><a href="FriendConfig.aspx">
                        ��ɧ������</a></li></ul>
        </div>
        <div class="addbox cshibiank">
            <img src="../../images/MessageManage/buttom_hycx.gif" alt="��Ա��ѯ" align="absmiddle" />
            �������ڴ����þ�ȷ���������һ�Ա��<br />
            <p>
                &nbsp;<input id="Radio1" name="RadioChk" type="radio" onclick="chk()" runat="server" checked/>��ȷ����
                <input id="Radio2" name="RadioChk" type="radio" onclick="chk()" runat="server"  />�߼�����</p>
            <div class="blank20">
            </div>
            <div class="searchbox">
                <table width="100%" id="panelExact" border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td height="21" colspan="2" style="width: 649px">
                            <strong class="font14 cheng">��ȷ������</strong></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="width: 649px; height: 22px;">
                            ��Ա�ǳƣ�&nbsp;<label>
                                <asp:TextBox ID="tboxMemberName" runat="server"></asp:TextBox></label></td>
                    </tr>
                </table>
                <table id="panelAdvance" width="100%" border="0" align="center" cellpadding="0" cellspacing="0" style="display:none">
                    <tr>
                        <td colspan="3" style="height: 25px">
                            <strong class="chengcu font14">�߼����ң�</strong></td>
                    </tr>
                    <tr>
                        <td colspan="3" class="cheng">
                            ��ѡ���Ա��ݣ�</td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:RadioButtonList ID="rblMemberGrade" runat="server" RepeatDirection="Horizontal"
                                RepeatLayout="Flow">
                                <asp:ListItem Value="0" Selected="True">ȫ����Ա</asp:ListItem>
                                <asp:ListItem Value="1">��ͨ��Ա</asp:ListItem>
                                <asp:ListItem Value="2">�ظ�ͨ��Ա</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" class="cheng" style="height: 20px">
                            ��ѡ���Ա���ͣ�</td>
                    </tr>
                    <tr>
                        <td colspan="3" style="height: 30px">
                            <asp:RadioButtonList ID="rblMemberType" runat="server" RepeatDirection="Horizontal"
                                RepeatLayout="Flow">
                                <asp:ListItem Value="0" Selected="True">����</asp:ListItem>
                                <asp:ListItem Value="1">��ҵ</asp:ListItem>
                                <asp:ListItem Value="2">����</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" class="cheng">
                            ��ѡ���Ա���򣺣��ɶ�ѡ��</td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <label>
                                <asp:CheckBoxList runat="server" ID="cklIntent" RepeatDirection="Horizontal" Height="5px"
                                    RepeatLayout="Flow">
                                    <asp:ListItem Value="0">��������</asp:ListItem>
                                    <asp:ListItem Value="1">��ҵ����</asp:ListItem>
                                    <asp:ListItem Value="2">��Ŀ����</asp:ListItem>
                                    <asp:ListItem Value="3">��ҵ����</asp:ListItem>
                                    <asp:ListItem Value="4">��Ʒ����</asp:ListItem>
                                    <asp:ListItem Value="5">��ĿͶ��</asp:ListItem>
                                </asp:CheckBoxList>
                            </label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            &nbsp;
                            ���� &nbsp;&nbsp; &nbsp;
                            <uc1:ZoneSelectControl ID="ZoneSelectControl1" runat="server" />
                        </td>
                    </tr>
                </table>
                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="20%" valign="middle" style="height: 4px">&nbsp;
                            </td>
                        <td width="80%" valign="middle" >
                          
                            <asp:Button ID="btnSearch" runat="server" Text="��ѯ" CssClass="buttomal" OnClick="btnSearch_Click" Width="60px" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
