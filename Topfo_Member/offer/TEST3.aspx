<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TEST3.aspx.cs" Inherits="offer_TEST3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>右下角弹出消息</title>
    <style type="text/css">

    body,th,td    {font-size:12px;font-family:Tahoma,Helvetica,Arial,'\5b8b\4f53','\5FAE\8F6F\96C5\9ED1',sans-serif;}
    body,th,td,ol,ul,li,dl,dt,dd,h1,h2,h3,h4,h5,h6,pre,form,fieldset,legend,input,button,textarea,p  {margin:0;padding:0;}
    fieldset,img { border:none; }
    a  	{color:#3366CC; text-decoration:none;outline:none;}
    a:hover 	{color:#FF6600;text-decoration:underline;}


    .msg { width:240px;display:none; }

    .pink .top,.pink .top .title,.pink .top span,.pink .bottom,.pink .bottom a {background:transparent url(images/msg_bg_pink.gif) no-repeat 0px 0px;}
    .pink .center {background:url(images/center_bg_pink.gif) repeat-y;}
    
    .blue .top,.blue .top .title,.blue .top span,.blue .bottom,.blue .bottom a {background:transparent url(images/msg_bg_blue.gif) no-repeat 0px 0px;}
    .blue .center {background:url(images/center_bg_blue.gif) repeat-y;}
    
    .msg .top{width:240px;height:25px;position:relative;}
    .msg .top .title {background-position:-195px -70px;padding-left:30px;line-height:22px;width:100px;height:25px;}
    .msg .top span {background-position:0px -70px;width:36px; height:17px;position:absolute;top:1px;left:198px;cursor:pointer;}
    .msg .top span:hover {background-position:-43px -71px;}

    .msg .center { width:240px;height:115px;}
    .msg .center h3{color:#0c4e7c;text-align:center;line-height:23px;font-size:13px;}
    .msg .center p{color: #0c4e7c;margin:0px 10px;line-height:20px;}

    .msg .bottom {height:29px;background-position:0px -32px;}
    .msg .bottom a {background-position:-120px -75px;padding-left:20px;margin:7px 10px;float:right;width:30px;height:20px;}


    .test dd { line-height:30px;}

    </style>
</head>
<body>
	<div id="div1" style="width:2000px;height:2000px">
	<div class="test" style="position:fixed;top:260px;left:200px;_position:absolute;display:none;">
	<dl>

		<dd>style: <input type="radio" value="pink" name="style" id="pink" checked="checked" /><label for="pink">pink</label><input type="radio" value="blue" name="style" id="blue" /><label for="blue">blue</label></dd>
		<dd>showDeplay:<input type="text" value="2" readonly="readonly"/></dd>
		<dd>autoHide:<input type="text" id="txtAutoHide" value="30"/><input value="Set" type="button" id="btnSet"/><span id="info" style="color:#FF0000"></span></dd>
		<dd><input type="button" id="btnControl" value="Show"/></dd>
	</dl>
	</div>
	
	<div class="msg pink" id="msgbox">
		<div class="top">
		    <div class="title">
                测试</div>
		    <span title="close" id="msgclose"></span>
		</div>
		 <div class="center">
			<h3>右下角消息提示测试</h3>
			<p>showDalay:设置页面加载后显示时间延迟;<br />autoHide:显示后自动隐藏的时间，默认30秒，设置为0表示不自动隐藏;</p>
		</div>
		<div class="bottom"><a target="_blank" href="http://www.topfo.com">查看</a>
		</div>
	</div>
	<!--sheyMsg end-->
	</div>
</body>
<script type="text/javascript" src="js/sheyMsg.js"></script>
<script type="text/javascript">
var g=function(id){return document.getElementById(id)};
var msg=new sheyMsg("msgbox",{
    showDelay:2,//
	onHide:function(){
		btn.value="Show";
	},
	onShow:function() {
		btn.value="Hide";
	}
});

g("pink").onclick=g("blue").onclick=function() {
    g("msgbox").className="msg "+this.value;
}
var btn=g("btnControl");
btn.onclick=function() {
	if(this.value=="Show")
		msg.show();
	else
		msg.hide();
}
g("btnSet").onclick=function() {
	var v=g("txtAutoHide").value;
	if(!isNaN(v)) {
		msg.options.autoHide=v-0;
		g("info").innerHTML="隐藏时间已设置,下一次显示时生效";
		setTimeout("g('info').innerHTML='';",3000);
	}
}
g("msgclose").onclick=function() {
	msg.hide();
}
</script>
</html>

