<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" Title="֪ͨ����-�ظ�����-�й�����Ͷ����"
    AutoEventWireup="true" CodeFile="Notice.aspx.cs" Inherits="helper_Notice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
function chkAll(m)
{
    for(j=0;j<chkTab.rows.length;j++)
    {
        var a = chkTab.rows.item(j).cells.item(m).getElementsByTagName("input"); 
			for (var i=0; i<a.length; i++) 
				if (a[i].type == "checkbox") 
				a[i].checked =!a[i].checked; 
    } 
}
    </script>

    <link href="/css/messagemanage.css" rel="stylesheet" type="text/css" />
    <div class="mainconbox">
        <div class="topzi">
            <div class="left">
                ֪ͨ����</div>
            <div class="clear">
            </div>
        </div>
        <div class="blank6">
        </div>
        <div class="suggestbox lightc allxian">
            ������������ʹ��վ�ڶ��š������ʼ����ֻ����ŵȷ�ʽ���ո���֪ͨ��<br />
            ��<a href="http://www.topfo.com/TopfoCenter/Application/superiorityApp.shtml" target="_blank">�ظ�ͨ��Ա</a>������500������ֻ����ŷ���
            <br />
            ����ͨ��Ա����ʹ���ֻ����ŷ�������<a href="buysms.aspx" style="text-decoration: none">�����������</a>��ÿ������0.1Ԫ��</div>
        <div class="blank20">
        </div>
        <div class="handtop">
            <ul>
                <li class="liwai">֪ͨ���� </li>
                <li><a href="buysms.aspx" style="text-decoration: none">�������</a></li></ul>
        </div>
        <div class="smsnotbox cshibiank">
            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" id="chkTab">
                <tr>
                    <td width="4%" align="left" class="tabtitle">
                        &nbsp;
                    </td>
                    <td width="36%" align="left" class="tabtitle" style="padding-left: 50px">
                        ֪ͨ��Ŀ</td>
                    <td width="24%" align="center" class="tabtitle">
                        <a href="javascript:void(0)" onclick="chkAll(2)">վ�ڶ���</a></td>
                    <td width="18%" align="center" class="tabtitle">
                        <a href="javascript:void(0)" onclick="chkAll(3)">�����ʼ�</a></td>
                    <td width="18%" align="center" class="tabtitle">
                        <a href="javascript:void(0)" onclick="chkAll(4)">�ֻ�����</a></td>
                </tr>
                <tr>
                    <td class="taba">
                        &nbsp;
                    </td>
                    <td class="taba">
                        �� ���󷢲�������֪ͨ</td>
                    <td align="center" class="taba">
                        <input type="checkbox" name="softtype" value="1" id="infocheck1" runat="server" />
                    </td>
                    <td align="center" class="taba">
                        <input type="checkbox" name="softtype" value="2" id="infocheck2" runat="server" /></td>
                    <td align="center" class="taba">
                        <input type="checkbox" name="softtype" value="3" id="infocheck3" runat="server" /></td>
                </tr>
                <tr>
                    <td class="tabb" style="height: 20px">
                        &nbsp;
                    </td>
                    <td class="tabb" style="height: 20px">
                        �� ������Դ�µ�֪ͨ</td>
                    <td align="center" class="tabb" style="height: 20px">
                        <input type="checkbox" name="checkbox" value="1" id="dzchk1" runat="server" /></td>
                    <td align="center" class="tabb" style="height: 20px">
                        <input type="checkbox" name="checkbox" value="2" id="dzchk2" runat="server" checked="CHECKED" /></td>
                    <td align="center" class="tabb" style="height: 20px">
                        <input type="checkbox" name="checkbox" value="3" id="dzchk3" runat="server" checked="CHECKED" /></td>
                </tr>
                <tr>
                    <td class="taba" style="height: 20px">
                        &nbsp;
                    </td>
                    <td class="taba" style="height: 20px">
                        �� ��Դ��Ч�ڼ�������֪ͨ</td>
                    <td align="center" class="taba" style="height: 20px">
                        <input type="checkbox" name="checkbox" value="1" id="InfoValiChk1" runat="server" /></td>
                    <td align="center" class="taba" style="height: 20px">
                        <input type="checkbox" name="checkbox" value="2" id="InfoValiChk2" runat="server" /></td>
                    <td align="center" class="taba" style="height: 20px">
                        <input type="checkbox" name="checkbox" value="3" id="InfoValiChk3" runat="server" /></td>
                </tr>
                <tr>
                    <td class="tabb" style="height: 20px">
                        &nbsp;
                    </td>
                    <td class="tabb" style="height: 20px">
                        �� �ظ�ͨ��Ա��������֪ͨ</td>
                    <td align="center" class="tabb" style="height: 20px">
                        <input type="checkbox" name="checkbox" value="1" id="memberValiChk1" runat="server" /></td>
                    <td align="center" class="tabb" style="height: 20px">
                        <input type="checkbox" name="checkbox" value="2" id="memberValiChk2" runat="server" /></td>
                    <td align="center" class="tabb" style="height: 20px">
                        <input type="checkbox" name="checkbox" value="3" id="memberValiChk3" runat="server" /></td>
                </tr>
                <tr>
                    <td class="taba">
                        &nbsp;
                    </td>
                    <td class="taba">
                        �� �������֪ͨ</td>
                    <td align="center" class="taba">
                        <input type="checkbox" name="checkbox" value="1" id="addfriendchk1" runat="server" /></td>
                    <td align="center" class="taba">
                        <input type="checkbox" name="checkbox" value="2" id="addfriendchk2" runat="server" /></td>
                    <td align="center" class="taba">
                        <input type="checkbox" name="checkbox" value="3" id="addfriendchk3" runat="server" /></td>
                </tr>
                <tr>
                    <td class="tabb" style="height: 20px">
                        &nbsp;
                    </td>
                    <td class="tabb" style="height: 20px">
                        �� ��Դ����֪ͨ</td>
                    <td align="center" class="tabb" style="height: 20px">
                        <input type="checkbox" name="checkbox" value="1" id="commentchk1" runat="server" /></td>
                    <td align="center" class="tabb" style="height: 20px">
                        <input type="checkbox" name="checkbox" value="2" id="commentchk2" runat="server" /></td>
                    <td align="center" class="tabb" style="height: 20px">
                        <input type="checkbox" name="checkbox" value="3" id="commentchk3" runat="server" /></td>
                </tr>
                <tr>
                    <td class="tabb" style="height: 20px">
                        &nbsp;
                    </td>
                    <td class="tabb" style="height: 20px">
                        �� ���Իظ�֪ͨ</td>
                    <td align="center" class="tabb" style="height: 20px">
                        <input type="checkbox" name="checkbox" value="1" id="rebackchk1" runat="server" /></td>
                    <td align="center" class="tabb" style="height: 20px">
                        <input type="checkbox" name="checkbox" value="2" id="rebackchk2" runat="server" /></td>
                    <td align="center" class="tabb" style="height: 20px">
                        <input type="checkbox" name="checkbox" value="3" id="rebackchk3" runat="server" /></td>
                </tr>
                <tr>
                    <td class="taba" style="height: 20px">
                        &nbsp;
                    </td>
                    <td class="taba" style="height: 20px">
                        �� ƥ����Դ֪ͨ</td>
                    <td align="center" class="taba" style="height: 20px">
                        <input type="checkbox" name="checkbox" value="1" id="ppchk1" runat="server" /></td>
                    <td align="center" class="taba" style="height: 20px">
                        <input type="checkbox" name="checkbox" value="2" id="ppchk2" runat="server" /></td>
                    <td align="center" class="taba" style="height: 20px">
                        <input type="checkbox" name="checkbox" value="3" id="ppchk3" runat="server" /></td>
                </tr>
                <tr>
                    <td class="tabb" style="height: 20px">
                        &nbsp;
                    </td>
                    <td class="tabb" style="height: 20px">
                        �� �ɹ�������Դ֪ͨ</td>
                    <td align="center" class="tabb" style="height: 20px">
                        <input type="checkbox" name="checkbox" value="1" id="buychk1" runat="server" /></td>
                    <td align="center" class="tabb" style="height: 20px">
                        <input type="checkbox" name="checkbox" value="2" id="buychk2" runat="server" /></td>
                    <td align="center" class="tabb" style="height: 20px">
                        <input type="checkbox" name="checkbox" value="3" id="buychk3" runat="server" /></td>
                </tr>
                <tr>
                    <td class="taba">
                        &nbsp;
                    </td>
                    <td class="taba">
                        �� �ɹ���ֵ֪ͨ</td>
                    <td align="center" class="taba">
                        <input type="checkbox" name="checkbox" value="1" id="czchk1" runat="server" /></td>
                    <td align="center" class="taba">
                        <input type="checkbox" name="checkbox" value="2" id="czchk2" runat="server" /></td>
                    <td align="center" class="taba">
                        <input type="checkbox" name="checkbox" value="3" id="czchk3" runat="server" /></td>
                </tr>
            </table>
            <div class="fill">
                �����ʼ����ã�
                <input name="textarea" type="text" size="30" id="txtEmail" runat="server" />
                <font class="hui">����ѡ������ʼ�����ʱ����ͨ�����������֪ͨ�� </font><span>�����ֻ����ã�
                    <input name="textarea2" type="text" size="30" id="txtMobile" runat="server" />
                    <font class="hui">����ѡ���ֻ�����ʱ����ͨ�����ֻ��������֪ͨ�� </font></span>
                <p>
                    <b class="cheng">��ܰ��ʾ</b>�������ڻ����Խ���<b class="cheng"><asp:Literal ID="lblNoticeCount"
                        runat="server" Text="0"></asp:Literal></b>���ֻ����š�</p>
            </div>
            <div class="buttom">
                <input name="" type="button" class="buttomal" value="��  ��" id="Button1" onserverclick="Button1_ServerClick"
                    runat="server" />
                <input name="Input" type="reset" class="buttomal" value="��  ��" />
            </div>
        </div>
    </div>
</asp:Content>
