<%@ Page Language="C#" AutoEventWireup="true" CodeFile="return_pnr.aspx.cs" Inherits="PayManage_return_pnr" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
    <title>操作成功</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312">
    <link href="../css/czsuccess.css" rel="stylesheet" type="text/css">
    <script language="javascript" src="../js/xhttp.js"></script>
    <link href="../css/common.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
<!--
.mainbox{
	width:948px;
	magin:0 auto;
	margin: 0 auto;
}
#header {
	width: 948px;
	margin: 0 auto;
	background-image: url(/images/bankimg/topbg.gif);
	border-bottom-width: 4px;
	border-bottom-style: solid;
	border-bottom-color: #FF7200;
}
#header img {
}
#header .ka {
	width: 380px;
	display: block;
	float: left;
	background-image: url(http://www.topfo.com/pay/images/bankimg/topka.gif);
	background-repeat: no-repeat;
	background-position: 150px bottom;
	height: 92px;
}
#header .left {
	width: 220px;
	float: left;
	margin: 15px 0 0 0;
	text-align: right;
}
#header .right {
	width: 300px;
	float: right;
	text-align: right;
	line-height: 250%;
	padding: 10px 10px 0 0;
}
#header .right h1 {
	font-size: 14px;
	font-weight: normal;
	color: #FF7200;
	margin: 22px 0 0 0;
}
-->
    </style>
</head>
<body>
    <div id="header">
        <div class="left">
            <a href="http://www.tz888.cn" target="_blank">
                <img src="http://www.topfo.com/web13/images/logo.gif" border="0"></a></div>
        <div class="ka">
        </div>
        <div class="right">
            <a href="http://www.tz888.cn" target="_blank">首页</a> | <a href="/capital/" target="_blank">
                投资</a> | <a href="/project/" target="_blank">融资</a> | <a href="/merchant/" target="_blank">
                    招商</a> | <a href="/agent/" target="_blank">分站</a> | <a href="/news/" target="_blank">
                        资讯</a> | <a href="http://bbs.tz888.cn" target="_blank">论坛</a><br>
            <h1>
                <img height="15" src="http://www.topfo.com/pay/images/bankimg/memberbiao.gif" width="14">
                <asp:Label ID="lblNickName" runat="server"></asp:Label></h1>
        </div>
        <div class="clear">
            <font face="宋体"></font>
        </div>
    </div>
    <div class="blank6">
    </div>
    <div class="mainbox">
        <div class="topyj">
        </div>
        <div id="contentcz">
            <div class="top">
                <h1>
                </h1>
                <p>
                   <a href="account_info.aspx">查看帐户信息</a>
                </p>
            </div>
            <div class="xia">
                <table width="737" height="127" border="0" align="center" cellpadding="0" cellspacing="0"
                    class="huikuang">
                    <tr>
                        <td height="125">
                            <table width="100%" border="0" cellpadding="2" cellspacing="1" bgcolor="#eeeedd"
                                class="baikuang">
                                <tr>
                                    <td height="29" align="right" bgcolor="#ebebeb">
                                        充值订单号：</td>
                                    <td width="518" align="left" bgcolor="#ffffff">
                                        <asp:Label ID="lblPnr" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td height="29" align="right" bgcolor="#ebebeb">
                                        银行交易号：</td>
                                    <td align="left" bgcolor="#ffffff">
                                        <asp:Label ID="lblSys" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td height="35" align="right" bgcolor="#ebebeb">
                                        充值金额：</td>
                                    <td align="left" bgcolor="#ffffff" height="35">
                                        <asp:Label ID="lblPoint" runat="server"></asp:Label>元</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="clear">
            </div>
        </div>
        <div class="bottomyj">
        </div>
        <div class="clear">
        </div>
    </div>
    <!--#include file="../Common/bottom.html" -->
</body>
</html>
