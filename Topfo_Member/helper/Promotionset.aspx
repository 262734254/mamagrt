<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Promotionset.aspx.cs" Inherits="helper_Promotionset" %>

<%@ Register Src="../Controls/SelectIndustryControl.ascx" TagName="SelectIndustryControl"
    TagPrefix="uc3" %>
<%@ Register Src="../Controls/ZoneMoreSelectControl.ascx" TagName="ZoneMoreSelectControl"
    TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>�ƹ�����</title>
    <link href="../css/promotion.css" rel="stylesheet" type="text/css" />
    <link href="../css/common.css" rel="stylesheet" type="text/css" />
   
    <style type="text/css">
<!--
.STYLE1 {
	color: #FF6633;
	font-size: 14px;
	font-weight: bold;
}
-->
    </style>
</head>
<body>
    <form id="form1" runat="server">
      <div class="setbox">
		 <table width="100%" border="1">
                  <tr>
                    <td>
                      <span class="STYLE1">�����ƹ�����</span></td>
                    <td>  
                      <div align="right" class="font14" onclick="window.close();">�ر�</div></td>
                  </tr>
        </table>
				
         
            
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td align="right" style="width: 106px">
                        <strong>�ƹ�Ŀ���û�</strong>��</td>
                    <td>
                        <asp:RadioButtonList ID="rabGradeID" runat="server" RepeatDirection="Horizontal"
                            RepeatLayout="Flow">
                            <asp:ListItem Value="1002">�ظ�ͨ��Ա</asp:ListItem>
                            <asp:ListItem Value="1001">��ͨ��Ա</asp:ListItem>
                            <asp:ListItem Selected="True" Value="1001,1002">ȫ����Ա</asp:ListItem>
                        </asp:RadioButtonList>                    </td>
                </tr>
            <tr>
                <td align="right" style="width: 106px">
                    <strong>�����û����ԣ�</strong></td>
                <td>
                        <asp:CheckBoxList ID="chkType" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            <asp:ListItem Value="2001">�������̻���</asp:ListItem>
                            <asp:ListItem Value="2003">��Ŀ��</asp:ListItem>
                            <asp:ListItem Value="2002">Ͷ�ʷ�</asp:ListItem>
                            <asp:ListItem Value="2004">�н����</asp:ListItem>
                            <asp:ListItem Value="2006">�˲Ż���</asp:ListItem>
                        </asp:CheckBoxList>(*�ɶ�ѡ)<asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label></td>
            </tr>
                <tr>
                    <td align="right" valign="middle"style="width: 106px">
                        <strong>��������</strong></td>
                    <td>
                        <span class="hui"></span><uc2:ZoneMoreSelectControl ID="Zone" runat="server" />
                       </td>
                       
                </tr>
                <tr>
                    <td style="width: 106px; height: 85px;" align="right" class="tdbg">
                        <strong>
                        �ƹ㷽ʽ��������</strong></td>
                    <td style="height: 85px">
                        <table cellpadding="0" cellspacing="0" style="width: 454px; height: 68px">
                            <tr>
                                <td style="width: 87px; height: 31px">
                        <asp:CheckBox ID="cbkShort" runat="server" Text="վ�ڶ��� Email" Width="112px" /></td>
                                <td style="width: 129px; height: 31px">
                                    �ƹ�������<asp:TextBox ID="txtPromotionShortSum"
                            runat="server" Width="36px"></asp:TextBox>��</td>
                                <td style="width: 101px; height: 31px">
                                    �Ʒѣ�1Ԫ/ÿ��</td>
                            </tr>
                            <tr>
                                <td style="width: 87px">
                        <asp:CheckBox ID="cbkPhone" runat="server" Text="�ֻ�����" Width="76px" /></td>
                                <td style="width: 129px">
                                    �ƹ�������<asp:TextBox ID="txtPromotionPhoneSum"
                            runat="server" Width="37px"></asp:TextBox>��</td>
                                <td style="width: 101px">
                                    �Ʒѣ�1Ԫ/ÿ��</td>
                            </tr>
                        </table>
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        &nbsp; &nbsp;&nbsp;
                        <asp:Label id="lblMsg1" runat="server" ForeColor="Red"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="2" align="center"><asp:Button ID="Button1" runat="server" Text="�ύ" CssClass="buttomal" OnClick="Button1_Click" />&nbsp;
                        </td>
                </tr>
            </table>
            
        </div>
    </form>
</body>
</html>
    