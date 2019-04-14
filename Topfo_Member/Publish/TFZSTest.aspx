<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TFZSTest.aspx.cs" Inherits="Publish_TFZSTest" %>

<%@ Register Src="../Controls/TFZSEvaluateGQ.ascx" TagName="TFZSEvaluateGQ" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>拓富指数</title>
    <link href="http://www.topfo.com/TopfoCenter/css/exponent.css" rel="stylesheet" type="text/css" />
    <link href="/css/publish.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
<!--
.tishitz {
	border:1px solid #FF9933;
	background-color:#FFFAF7;
	width: 800px;
	text-align: left;
	margin-bottom: 7px;
}
.tishitz h1{
	font-weight: bold;
	color: #FF0000;
	padding: 7px 0 0 15px;
}
.tishitz p{
	padding: 5px 0 10px 15px;
	text-align: left;
	width: 600px;
	margin: 0;
}
-->
    </style>
</head>
<body>
    <form runat="server">
        <!--#include file="../common/top.html"-->
        <div class="advantabox" style="padding-top:0;">
            <div id="divSysIntro" style="width: 760px">
			<div class="tishitz"><h1>温馨提示：</h1>
<P>· 您只有在发布项目信息时，才能参与项目投资价值评估，得到拓富指数；<br />

· 拓富指数最高得分为100，最低为0，得分越高说明该项目投资价值越大；<br />
· 投资机构在甄选项目时，非常重视拓富指数，您的指数越高，被投资方选中的机会就越大。</P>
</div>
                <uc1:TFZSEvaluateGQ ID="TFZSEvaluateGQ1" runat="server" />
            </div>
            <div class="blank0">
            </div>
        </div>
        <!--#include file="../common/allfooter.html"-->
    </form>
</body>
</html>
