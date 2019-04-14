<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" ResponseEncoding="GB2312"
    EnableEventValidation="false" Title="�����ƹ�����-�ظ�����-�й�����Ͷ����" AutoEventWireup="true"
    CodeFile="ReceivedSet.aspx.cs" Inherits="helper_ReceivedSet" %>

<%@ Register Src="../Controls/ZoneMoreSelectControl.ascx" TagName="ZoneMoreSelectControl"
    TagPrefix="uc1" %>
<%@ Register Src="../Controls/SelectIndustryControl.ascx" TagName="SelectIndustryControl"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

  <!--  <link href="/css/promotion.css" rel="stylesheet" type="text/css" />-->

    <script language="javascript" type="text/javascript">
    function showPoint()
    {
        if(document.getElementById("ctl00_ContentPlaceHolder1_isGet").checked)
        {
            document.getElementById("ctl00_ContentPlaceHolder1_isShow").style.display="";
        }
        else
        {
            document.getElementById("ctl00_ContentPlaceHolder1_isShow").style.display="none";
        }
    }
    </script>

    <script>showPoint();</script>

    <div class="mainconbox">
        <div class="topzi">
            <div class="left">
                �����ƹ�</div>
            <div class="right">
                <img src="../images/publish/biao_01.gif" width="14" height="15" align="absmiddle" />
                <a href="http://www.topfo.com/web13/help/directionalextend.shtml#12" target="_blank">
                    ʹ��˵��</a></div>
            <div class="clear">
            </div>
        </div>
        <div class="handtop">
            <ul>
                <li><a href="/helper/myPromotion.aspx">�ƹ��ҵ�����</a></li><li><a href="/helper/getPromotion.aspx">
                    ���յ����Ƽ���Դ</a></li><li class="liwai">��������</li><li><a href="/helper/PromotionServer.aspx">
                        ������</a></li></ul>
        </div>
        <div class="psetbox cshibiank">
            <h1 class="dottedl lightc">
                <img src="/images/icon_tishi.gif" align="absmiddle" />
                <span class="cheng">��ܰ��ʾ��</span>����㲻���յ��������ƹ����ݣ��������˶���������ϸ����������</h1>
            <div class="blank20">
            </div>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td align="right" style="width: 133px">
                        <strong>���������û�����Դ��</strong></td>
                    <td align="left">
                        <asp:RadioButtonList ID="rabGradeID" runat="server" RepeatDirection="Horizontal"
                            RepeatLayout="Flow">
                            <asp:ListItem Value="1002">�ظ�ͨ��Ա</asp:ListItem>
                            <asp:ListItem Value="1001">��ͨ��Ա</asp:ListItem>
                            <asp:ListItem Selected="True" Value="1001,1002">ȫ����Ա</asp:ListItem>
                        </asp:RadioButtonList></td>
                </tr>
            </table>
            <table width="100%" border="0" id="isShow" runat="server" cellspacing="0" cellpadding="0">
                <tr>
                    <td align="right">
                        <span style="font-size: 9pt"><strong>��Դ���ͣ�</strong></span></td>
                    <td width="82%">
                        <asp:CheckBoxList ID="chkNeed" runat="server" RepeatDirection="Horizontal"
                            RepeatLayout="Flow">
                            <asp:ListItem Value="Merchant">������Դ</asp:ListItem>
                            <asp:ListItem Value="Project">������Դ</asp:ListItem>
                            <asp:ListItem Value="Capital">Ͷ����Դ</asp:ListItem>
                        </asp:CheckBoxList>(*�ɶ�ѡ)<asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label><br />
                        </td>
                </tr>
                <tr>
                    <td align="right" valign="top">
                        <strong>��������</strong></td>
                    <td class="local"> <uc1:ZoneMoreSelectControl ID="ZoneControl" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="right" rowspan="2">
                        <strong>���շ�ʽ���ã�</strong>&nbsp;&nbsp;</td>
                    <td style="height: 24px">
                        <span class="hui">
                            <asp:CheckBox ID="cbkEmail" runat="server" Text="վ�ڶ���" /></span></td>
                </tr>
                <tr>
                    <td style="height: 24px">
                        <span class="hui">
                            <asp:CheckBox ID="cbkMobile" runat="server" Text="�ֻ�����" />&nbsp;<input id="txtMobile" type="text" runat="server" />
                            <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtMobile"
                                ErrorMessage="�ֻ������ʽ����" ValidationExpression="^(130|131|132|133|134|135|136|137|138|139|159|158)\d{8}$"></asp:RegularExpressionValidator></span></td>
                </tr>
            </table>
            <p>
                <input type="button" class="buttomal" value="ȷ ��" id="btnEnter" runat="server" onserverclick="btnEnter_ServerClick" />&nbsp;<label>
                </label>
            </p>
        </div>
        <div class="blank20">
        </div>
    </div>
</asp:Content>
