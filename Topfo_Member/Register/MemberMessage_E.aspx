<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MemberMessage_E.aspx.cs" Inherits="Register_MemberMessage_E" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>��ҵ��Ա����</title>
<link href="../css/common.css" rel="stylesheet" type="text/css" />
<link href="../css/memberdata.css" rel="stylesheet" type="text/css" />
<link href="/web1.1/css/bottomcss.css" rel="stylesheet" type="text/css" />
</head>

<body>
<form runat="server"> <div style="width:980px;margin:0 auto;text-align:center"><iframe scrolling="no" frameBorder="0" width="100%" height="100px"  src=" http://www.topfo.com/web13/common/header_tfzs.html"></iframe></div>
<div class="clear"></div>
<div class="topbg"></div>
<div class="mainbox">
<div class="titletop">
    <asp:Label ID="lblNickName2" runat="server"></asp:Label>�Ļ�Ա����</div>
<div class="left">
<p> <span class="hui">
<div style="text-align:center">
    <asp:Image ID="imgHead" runat="server" Height="136px" ImageUrl="../images/MemberData/nopic.gif"
        Width="153px" />
</div>
<div style="text-align:left;margin-left:30px;">	
    <asp:Label ID="lbRealName" runat="server"></asp:Label>
    ��<asp:Label ID="lbSex" runat="server"></asp:Label>��<span
        class="font14"></span>&nbsp;
    <asp:Label ID="lbCareer" runat="server"></asp:Label><br />
    ������λ��<asp:Label ID="lbOrganizationName" runat="server" Width="150px" style="word-wrap: break-word; word-break: break-all;"></asp:Label><br />
	<div>
	
	<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="17%" valign="top">��ַ��</td>
    <td width="83%" valign="top"><asp:Label ID="lbtAddress" runat="server" Width="204px"></asp:Label></td>
  </tr>
</table>
</div>
    �绰��<asp:Label ID="lbTel" runat="server" Width="204px" style="word-wrap: break-word; word-break: break-all;"></asp:Label><br />
  �ֻ���<asp:Label ID="lbMoble" runat="server" Width="204px" style="word-wrap: break-word; word-break: break-all;"></asp:Label><br />
  ���棺<asp:Label ID="lbFax" runat="server" Width="204px" style="word-wrap: break-word; word-break: break-all;"></asp:Label><br />

  ��˾��ַ��<asp:Label ID="lbSite" runat="server" Width="150px" style="word-wrap: break-word; word-break: break-all;"></asp:Label>
  </div>
  </span></p>
<h1>��������</h1>
<div class="buttom">
    <asp:HyperLink ID="HyperLink2" Target=_blank runat="server" ImageUrl="../images/MemberData/buttom_fxx.gif">HyperLink</asp:HyperLink><asp:HyperLink
        ID="HyperLink1" runat="server"  Target=_blank ImageUrl="../images/MemberData/buttom_jwhy.gif">HyperLink</asp:HyperLink><strong></strong>&nbsp;</div>
</div>
<!-- -->
<div class="right">
<div class="dottedlline" id="GradeDiv" runat="server">
<h1>�û�Ա���ظ�ͨ��Ա</h1></div>
<ul><li>��Ա�û�����<asp:Label ID="lbLoginName" runat="server"></asp:Label></li><li>�ǳƣ�    
    <asp:Label ID="lbNickName" runat="server"></asp:Label></li><li>��Ա���ͣ�    
    <asp:Label ID="lbManageType" runat="server"></asp:Label></li><li>��Ա����    
    <asp:Label ID="lbRequar" runat="server"></asp:Label></li><li>ע��ʱ�䣺    
    <asp:Label ID="lbRegTime" runat="server"></asp:Label></li><li>��½������<asp:Label ID="lbLoginCount" runat="server"></asp:Label>��</li><li>�ϴε�½ʱ�䣺 
    <asp:Label ID="lbLoginB" runat="server"></asp:Label></li><li> ��Ӫ��Ʒ�����<asp:Label ID="lbMainProduct" runat="server">����</asp:Label><span class="hui"></span></li><li>��Ӫ��ҵ��    
        <asp:Label ID="lbIndustryModels" runat="server">����</asp:Label></li>
</ul>
<div class="blank20"></div>
<div class="dottedlline"></div>
<h1><img src="../images/icon_yb.gif" width="17" height="17" /> ҵ����¼</h1>
<p>�ѷ���������<asp:Label ID="lbPublishCount" runat="server" ForeColor="Red">0</asp:Label>��&nbsp;<br />
  ��ҵչ����
    <asp:Label ID="lbExhibitionHall" runat="server" Text="����"></asp:Label>
</p>
<asp:Panel id="spanRM" runat="server">
<h1><img src="../images/icon_yb.gif" width="17" height="17" /> ��ҵ��֤��Ϣ</h1>
<p>��ҵ�����֤��<asp:Label ID="lbAuditingStatus" runat="server">����</asp:Label>
    <a href="http://www.topfo.com/topfocenter/degreeaffirm/index.shtml" class="lanlink" target="_blank">�˽���ϸ��֤��Ϣ</a><br />
  Ӫҵִ�գ�<asp:Label ID="lbResourceType4" runat="server">����</asp:Label>
    <a href="#" class="lanlink"></a><br />
  ˰��Ǽ�֤��<asp:Label ID="lbResourceType56" runat="server">����</asp:Label>
    <span class="chengcu"></span> <br />
  ����֤���������<asp:Label ID="lbResourceType7" runat="server">����</asp:Label><span class="hui"></span></p>
  </asp:Panel>
    &nbsp;
</div>
<div class="clear"></div>
</div>

</form>
<iframe scrolling="no" frameBorder="0" width="100%"  src="http://www.topfo.com/web13/common/bottom.html"></iframe>
</body>
</html>

