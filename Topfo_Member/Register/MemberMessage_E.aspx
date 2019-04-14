<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MemberMessage_E.aspx.cs" Inherits="Register_MemberMessage_E" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>企业会员资料</title>
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
    <asp:Label ID="lblNickName2" runat="server"></asp:Label>的会员资料</div>
<div class="left">
<p> <span class="hui">
<div style="text-align:center">
    <asp:Image ID="imgHead" runat="server" Height="136px" ImageUrl="../images/MemberData/nopic.gif"
        Width="153px" />
</div>
<div style="text-align:left;margin-left:30px;">	
    <asp:Label ID="lbRealName" runat="server"></asp:Label>
    （<asp:Label ID="lbSex" runat="server"></asp:Label>）<span
        class="font14"></span>&nbsp;
    <asp:Label ID="lbCareer" runat="server"></asp:Label><br />
    工作单位：<asp:Label ID="lbOrganizationName" runat="server" Width="150px" style="word-wrap: break-word; word-break: break-all;"></asp:Label><br />
	<div>
	
	<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="17%" valign="top">地址：</td>
    <td width="83%" valign="top"><asp:Label ID="lbtAddress" runat="server" Width="204px"></asp:Label></td>
  </tr>
</table>
</div>
    电话：<asp:Label ID="lbTel" runat="server" Width="204px" style="word-wrap: break-word; word-break: break-all;"></asp:Label><br />
  手机：<asp:Label ID="lbMoble" runat="server" Width="204px" style="word-wrap: break-word; word-break: break-all;"></asp:Label><br />
  传真：<asp:Label ID="lbFax" runat="server" Width="204px" style="word-wrap: break-word; word-break: break-all;"></asp:Label><br />

  公司网址：<asp:Label ID="lbSite" runat="server" Width="150px" style="word-wrap: break-word; word-break: break-all;"></asp:Label>
  </div>
  </span></p>
<h1>互动交流</h1>
<div class="buttom">
    <asp:HyperLink ID="HyperLink2" Target=_blank runat="server" ImageUrl="../images/MemberData/buttom_fxx.gif">HyperLink</asp:HyperLink><asp:HyperLink
        ID="HyperLink1" runat="server"  Target=_blank ImageUrl="../images/MemberData/buttom_jwhy.gif">HyperLink</asp:HyperLink><strong></strong>&nbsp;</div>
</div>
<!-- -->
<div class="right">
<div class="dottedlline" id="GradeDiv" runat="server">
<h1>该会员是拓富通会员</h1></div>
<ul><li>会员用户名：<asp:Label ID="lbLoginName" runat="server"></asp:Label></li><li>昵称：    
    <asp:Label ID="lbNickName" runat="server"></asp:Label></li><li>会员类型：    
    <asp:Label ID="lbManageType" runat="server"></asp:Label></li><li>会员意向：    
    <asp:Label ID="lbRequar" runat="server"></asp:Label></li><li>注册时间：    
    <asp:Label ID="lbRegTime" runat="server"></asp:Label></li><li>登陆次数：<asp:Label ID="lbLoginCount" runat="server"></asp:Label>次</li><li>上次登陆时间： 
    <asp:Label ID="lbLoginB" runat="server"></asp:Label></li><li> 主营产品或服务：<asp:Label ID="lbMainProduct" runat="server">暂无</asp:Label><span class="hui"></span></li><li>主营行业：    
        <asp:Label ID="lbIndustryModels" runat="server">暂无</asp:Label></li>
</ul>
<div class="blank20"></div>
<div class="dottedlline"></div>
<h1><img src="../images/icon_yb.gif" width="17" height="17" /> 业务活动记录</h1>
<p>已发布的需求：<asp:Label ID="lbPublishCount" runat="server" ForeColor="Red">0</asp:Label>条&nbsp;<br />
  企业展厅：
    <asp:Label ID="lbExhibitionHall" runat="server" Text="暂无"></asp:Label>
</p>
<asp:Panel id="spanRM" runat="server">
<h1><img src="../images/icon_yb.gif" width="17" height="17" /> 企业认证信息</h1>
<p>企业身份认证：<asp:Label ID="lbAuditingStatus" runat="server">暂无</asp:Label>
    <a href="http://www.topfo.com/topfocenter/degreeaffirm/index.shtml" class="lanlink" target="_blank">了解详细认证信息</a><br />
  营业执照：<asp:Label ID="lbResourceType4" runat="server">暂无</asp:Label>
    <a href="#" class="lanlink"></a><br />
  税务登记证：<asp:Label ID="lbResourceType56" runat="server">暂无</asp:Label>
    <span class="chengcu"></span> <br />
  其他证书和荣誉：<asp:Label ID="lbResourceType7" runat="server">暂无</asp:Label><span class="hui"></span></p>
  </asp:Panel>
    &nbsp;
</div>
<div class="clear"></div>
</div>

</form>
<iframe scrolling="no" frameBorder="0" width="100%"  src="http://www.topfo.com/web13/common/bottom.html"></iframe>
</body>
</html>

