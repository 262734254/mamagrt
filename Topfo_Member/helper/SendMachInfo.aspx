<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SendMachInfo.aspx.cs" Inherits="helper_SendMachInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <style>
<!--

*{margin:0;padding:0;}
body{font-size: 12px;color: #000000;line-height: 180%; font-family: "宋体";}
table,tr,td{font-family: "宋体";line-height: 180%; vertical-align:top}

p,ul,li,h7,h6,h5,h4,h3,h2,h1{margin:0;padding:0;}
ul,li{ list-style:none;}
img,img a{border:0;}
img a{cursor:hand;}
.clear{clear:both;}


a:link,a:visited,a:active {	color: #000000; text-decoration: none} /* 默认样式 */
a:hover{color: #ff0000;text-decoration: underline;}

a.ablue01:link, a.ablue01:visited,a.ablue01:active{color: #1F1FC0;text-decoration: underline;font-size:12px;}
a.ablue01:hover{color: #ff0000;text-decoration: underline;font-size:12px;}

a.ablue02:link, a.ablue02:visited,a.ablue02:active{color: #1F1FC0;text-decoration: underline;font-size:14px;}
a.ablue02:hover{color: #ff0000;text-decoration: underline;font-size:14px;}

a.ablue03:link, a.ablue03:visited,a.ablue03:active{color: #1F1FC0;text-decoration: underline;font-size:14px;font-weight:bold}
a.ablue03:hover{color: #ff0000;text-decoration: underline;font-size:14px;font-weight:bold}



.bold{font-weight:bold}
.orange{color:#ff6600;font-size:12px;font-weight:bold;}
.orange1{color:#ff6600;font-size:14px;}
.orange2{color:#ff6600;font-size:14px;font-weight:bold;}


.red{color:#FF0000}

.f14{font-size:14px;}
.f12{font-size:12px;}

.container{ width:600px;margin:10px auto;}

.marginR80{margin-right:80px;}
.marginR40{margin-right:21px;}
.marginR30{margin-right:22px;}

.marginL50{margin-left:50px;}

.title1{font-size:25px;line-height:29px;}
.title1 span{color:#ff6600;font-size:28px; font-weight:bolder}

.main{border:5px solid #F7F7F7;margin-top:10px;}



.main .bline{ border:3px solid #FFA500;}
.main .bline td{font-size:14px;}

.main .bline h3{font-size:14px;font-weight:nomarl}

.main .bline p{margin:0 22px;}


.main .bline p.note1{ clear: both;margin-top:54px;}
.main .bline p.note2{ clear: both;font-size:12px;line-height:18px; border-top:1px solid #B9B9B9;margin-top:3px;padding-top:6px;}
.main .bline p.note3{ clear: both;line-height:18px; margin-top:150px; text-align:right;}



.main .center{margin:5px 22px; border:1px dashed #CCCCCC;background:#FFFFED;padding:18px 15px;}
.main .center table{margin-bottom:6px;}
.main .center table td{padding:0;margin:0;font-size:14px;}




-->
</style>
    <link href="http://member.topfo.com/css/messagemanage.css" rel="stylesheet" type="text/css" />
    <link href="http://member.topfo.com/css/common.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <table width="100" border="0" cellpadding="0" cellspacing="0" class="container">
        <tr>
            <td>
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="45%">
                            <a href="http://www.topfo.com" target="_blank">
                                <img src="http://www.topfo.com/Web13/images/logo.jpg" /></a></td>
                        <td width="55%" align="right">
                            <div class="marginR80">
                                <p class="title1">
                                    <span>拓</span>达成功财<span>富</span></p>
                            </div>
                            <div class="marginR40">
                                <p class="title1">
                                    <span>网</span>遍投资商机</p>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <div class="main">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0" class="bline">
                        <tr>
                            <td>
                                <span class="bold">&nbsp; 尊敬的<asp:Label ID="lblNickName" runat="server"></asp:Label>：</span>
                                <br />
                                &nbsp; 您好！<span style="font-family: 宋体">今天又有优秀资源推荐给您：</span>
                                <table width="550px" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td>
                                            <div class="mainconbox">
                                                <div class=" cshibiank" style="padding: 5px">
                                                    <table class="taba" cellspacing="0" width="100%" align="center">
                                                        <tbody>
                                                            <tr class="tabtitle">
                                                                <td width="5%">
                                                                </td>
                                                                <td class="tabtitle" align="left" width="45%">
                                                                    标题</td>
                                                                <td class="tabtitle" align="center" width="30%">
                                                                    发布时间</td>
                                                                <td class="tabtitle" align="center" width="20%">
                                                                    发布人</td>
                                                            </tr>
                                                            <asp:Repeater ID="dgMatching" runat="server">
                                                                <ItemTemplate>
                                                                    <tr>
                                                                        <td width="5%">
                                                                        </td>
                                                                        <td height="25" align="left">
                                                                            <a target="_blank" href="http://www.topfo.com/<%#Eval("HtmlFile") %>">
                                                                                <%#Eval("Title") %>
                                                                            </a>
                                                                        </td>
                                                                        <td height="25" align="center">
                                                                            <%#Eval("PublishT") %>
                                                                        </td>
                                                                        <td height="25" align="center">
                                                                            <%#getNickName(Eval("LoginName"))%>
                                                                        </td>
                                                                    </tr>
                                                                </ItemTemplate>
                                                                <AlternatingItemTemplate>
                                                                    <tr class="tabb">
                                                                        <td width="5%">
                                                                        </td>
                                                                        <td height="25" align="left">
                                                                            <a target="_blank" href="http://www.topfo.com/<%#Eval("HtmlFile") %>">
                                                                                <%#Eval("Title") %>
                                                                            </a>
                                                                        </td>
                                                                        <td height="25" align="center">
                                                                            <%#Eval("PublishT") %>
                                                                        </td>
                                                                        <td height="25" align="center">
                                                                            <%#getNickName(Eval("LoginName"))%>
                                                                        </td>
                                                                    </tr>
                                                                </AlternatingItemTemplate>
                                                            </asp:Repeater>
                                                        </tbody>
                                                    </table>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" height="22px">
                                            <a href="http://member.topfo.com/helper/getPromotion.aspx" target="_blank" class="ablue03">
                                                查看更多&gt;&gt;&gt;&gt;</a>
                                        </td>
                                    </tr>
                                </table>
                                <p class="note1">
                                    感谢您使用拓富·中国招商投资网！</p>
                                <p class="note2">
                                    此邮件由拓富·中国招商投资网系统发出，系统不接收回信，因此请勿直接回复。<br />
                                    如有任何疑问，请 <a href="http://www.topfo.com/Sys/Message.aspx" target="_blank" class="ablue01 f12">
                                        在线反馈</a> 或者致电 <span class="orange2">0755-82210116</span> 寻求帮助。
                                </p>
                                <p class="note3">
                                    拓富·中国招商投资网<br />
                                    <span class="marginR30"><a href="http://www.topfo.com" target="_blank">www.topfo.com</a></span>
                                </p>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
</body>
</html>
