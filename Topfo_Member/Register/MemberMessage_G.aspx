<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MemberMessage_G.aspx.cs" Inherits="Register_MemberMessage_G" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>个人会员资料</title>
    <link href="../css/common.css" rel="stylesheet" type="text/css" />
    <link href="../css/memberdata.css" rel="stylesheet" type="text/css" />
    <link href="/web1.1/css/bottomcss.css" rel="stylesheet" type="text/css" />
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
                        <asp:Label ID="lblNickName2" runat="server"></asp:Label>的会员资料</div>
                    <div class="left">
                        <asp:Image ID="imgHead" runat="server" Height="136px" ImageUrl="../images/MemberData/nopic.gif"
                            Width="153px" />&nbsp;<p>
                            <asp:Label ID="lbRealName" runat="server"></asp:Label><asp:Label ID="lbSex" runat="server"></asp:Label>
                            <asp:Label ID="lbCareer" runat="server"></asp:Label><br />
                            <a href="#" class="lanlink"></a>工作单位：<asp:Label ID="lbOrganizationName" runat="server" Width="150px" style="word-wrap: break-word; word-break: break-all;"></asp:Label><br />
                                地址：<asp:Label ID="lbtAddress" runat="server" Width="170px" style="word-wrap: break-word; word-break: break-all;"></asp:Label><br />
                            电话：<asp:Label ID="lbTel" runat="server" Width="170px" style="word-wrap: break-word; word-break: break-all;"></asp:Label><br />
                            手机：<asp:Label ID="lbMoble" runat="server" Width="170px" style="word-wrap: break-word; word-break: break-all;"></asp:Label><br />
                            传真：<asp:Label ID="lbFax" runat="server" Width="170px" style="word-wrap: break-word; word-break: break-all;"></asp:Label><br />
                            公司网址：<asp:Label ID="lbSite" runat="server" Width="150px" style="word-wrap: break-word; word-break: break-all;"></asp:Label></p>
                        <h1>
                            互动交流</h1>
                        <div class="buttom">
                            &nbsp;<asp:HyperLink ID="HyperLink2" runat="server" ImageUrl="../images/MemberData/buttom_fxx.gif"
                                Target="_blank">HyperLink</asp:HyperLink><asp:HyperLink ID="HyperLink1" runat="server"
                                    ImageUrl="../images/MemberData/buttom_jwhy.gif" Target="_blank">HyperLink</asp:HyperLink><br />
                            <a href="#">
                          </a><a
                                    href="#"></a>&nbsp;</div>
                    </div>
                    <!-- -->
                    <div class="right">
                        <div id="GradeDiv" runat="server">                      
                        <h1>   <img src="../images/icon_yb.gif" width="17" height="17" /> 该会员是拓富通会员</h1>
                        </div>						
                        <ul>
                            <li >会员用户名：
                                <asp:Label ID="lbLoginName" runat="server" Text="Label"></asp:Label></li><li>昵称：
                                    <asp:Label ID="lbNickName" runat="server"></asp:Label></li><li>会员类型：
                                        <asp:Label ID="lbManageType" runat="server"></asp:Label></li><li>会员意向：
                                            <asp:Label ID="lbRequar" runat="server"></asp:Label></li><li>注册时间：
                                                <asp:Label ID="lbRegTime" runat="server"></asp:Label></li><li>登陆次数：<asp:Label ID="lbLoginCount"
                                                    runat="server"></asp:Label>次</li><li>上次登陆时间：
                                                        <asp:Label ID="lbLoginB" runat="server"></asp:Label>
												<div class="clear"></div>
                                                </li>
                        </ul>
                        <div class="blank20">
                        </div>
                        <div class="dottedlline">
                        </div>
                        <h1>
                            <img src="../images/icon_yb.gif" width="17" height="17" />
                            业务活动记录</h1>
                        <p>
                            已发布的需求：
                            <asp:Label ID="lbPublishCount" runat="server" ForeColor="Red">0</asp:Label>
                            条 <br /> 网上展厅：<asp:Label ID="lbExhibitionHall" runat="server" Text="暂无"></asp:Label><br />
                        </p>
                        <div class="dottedlline">
                        </div>
                        <asp:Panel ID="spanRM" runat="server">
                        <h1>
                            <img height="17" src="../images/icon_yb.gif" width="17" />
                            机构认证信息</h1>
                         <p>   企业身份认证：
                           <asp:Label ID="lbAuditingStatus" runat="server">暂无</asp:Label>
                            <a class="lanlink" href="#"><span style="color: #000000">了解详细认证信息</span></a><br />
                            营业执照：
                            <asp:Label ID="lbResourceType4" runat="server">暂无</asp:Label>
                            <a class="lanlink" href="#"></a>&nbsp;<br />
                            其他证书和荣誉：
                             <asp:Label ID="lbResourceType7" runat="server">暂无</asp:Label>
                          </asp:Panel>
                    </div>
                    <div class="clear">
                    </div>
                </div>
			 
</form>
    <iframe scrolling="no" frameBorder="0" width="100%"  src="http://www.topfo.com/web13/common/bottom.html"></iframe>

</body>
</html>
