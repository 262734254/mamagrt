﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TEST2.aspx.cs" Inherits="offer_TEST2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
<head>

<title></title>
<style type="text/css">
* {margin:0px;padding:0px;}
html,body {height:100%;}
body {font-size:14px; line-height:24px;}
#tip {position: absolute;right: 0px;bottom: 0px;height: 0px;width: 280px;border: 1px solid #CCCCCC;background-color: #eeeeee;padding: 1px;overflow:hidden;display:none;font-size:12px;z-index:10;}
#tip p {padding:6px;}
#tip h1,#detail h1 {font-size:14px;height:25px;line-height:25px;background-color:#33FF00;color:#FF0000;padding:0px 3px 0px 3px;}
#tip h1 a,#detail h1 a {float:right;text-decoration:none;color:#FFFFFF;}
#shadow {position:absolute;width:100%;height:100%;background:#CCCCCC;-moz-opacity:0.5;filter:Alpha(Opacity=50);opacity: 0.8;z-index:11;display:none;overflow:hidden;}
#detail {width:500px;height:200px;border:3px double #ccc;background-color:#FFFFFF;position:absolute;z-index:30;display:none;left:30%;top:30%}
</style>
<script type="text/javascript">
var handle;
function start()
{
var obj = document.getElementById("tip");
if (parseInt(obj.style.height)==0)
{ obj.style.display="block";
handle = setInterval("changeH('up')",2);
}else
{
     handle = setInterval("changeH('down')",2) 
} 
}
function changeH(str)
{
var obj = document.getElementById("tip");
if(str=="up")
{
if (parseInt(obj.style.height)>200)
   clearInterval(handle);
else
   obj.style.height=(parseInt(obj.style.height)+8).toString()+"px";
}
if(str=="down")
{
if (parseInt(obj.style.height)<8)
{ clearInterval(handle);
   obj.style.display="none";
}
else 
   obj.style.height=(parseInt(obj.style.height)-8).toString()+"px"; 
}
}
function showwin()
{
document.getElementsByTagName("html")[0].style.overflow = "hidden";
start();
document.getElementById("shadow").style.display="block";
document.getElementById("detail").style.display="block"; 
}
function recover()
{
document.getElementsByTagName("html")[0].style.overflow = "auto";
document.getElementById("shadow").style.display="none";
document.getElementById("detail").style.display="none"; 
}
</script>
</head>

<body onload="document.getElementById('tip').style.height='0px'">

<div id="shadow"> </div>

<div id="detail"><h1><a href="javascript:void(0)" onclick="recover()">×</a>测试测试</h1>测试测试<a href="http://www.topfo.com">baishonglin</a></div>

<div id="tip"><h1><a href="javascript:void(0)" onclick="start()"">×</a>测试测试测试。</h1><p><a href="javascript:void(0)" onclick="showwin()">测试</a></p></div>
<div align="center"><a href="javascript:void(0)" onclick="start()">点击这里测试</a>
</p>

</div>
</body>
</html>
