
 
String.prototype.trim= function()  
{  
    return this.replace(/(^\s*)|(\s*$)/g, "");  
}
//设置名称为name,值为value的Cookie 		
function Setcookie(name, value) 
{ 
var argc = Setcookie.arguments.length; 
var argv = Setcookie.arguments; 
var path = (argc > 3) ? argv[3] : null; 
var domain = (argc > 4) ? argv[4] : null; 
var secure = (argc > 5) ? argv[5] : false; 
document.cookie = name + "=" + value + 
((path == null) ? "" : ("; path=" + path)) + 
((domain == null) ? "" : ("; domain=" + domain)) + 
((secure == true) ? 
"; secure" : ""); 
} 
//取得名称为name的cookie值 
function GetCookie(name) 
{ 
  
var arg = name + "="; 
var alen = arg.length; 
var clen = document.cookie.length; 
var i = 0; 
while (i < clen) 
{ 
var j = i + alen; 
if (document.cookie.substring(i, j) == arg) 
return getCookieVal (j); 
i = document.cookie.indexOf(" ", i) + 1; 
if (i == 0) break; 
} 
return null; 
} 

function getCookieVal (offset)
{

 
var endstr = document.cookie.indexOf (";", offset);
if (endstr == -1)
endstr = document.cookie.length;
return document.cookie.substring(offset,endstr);
}



var isLogined = false;
var loginInfo = GetCookie("tz888.cn_CKData");

 
if(loginInfo != null)
{
 
	window.onload=GetLoginState;
}
else//未登陆
{
 
	$("member_logout").style.display = "block";
	$("member_login").style.display = "none";
	$("member_login_loading").style.display = "none";
}
	
function  GetLoginState()
{
 
 
	loginInfo = decodeURIComponent(loginInfo);
 
	isLogined = true;	
	$("loginNickname").innerHTML =  loginInfo;	
 
	RequestByGet(serviceUrl,GetLoginInfo);
}


function Logout()
{
  location.href ='/Logout.aspx?url='+location.href;
}
function CheckLogin_mini()
{
 
	if (document.forms["form_mini"].txtLoginName.value.trim().length ==0 || document.forms["form_mini"].txtPassword.value.trim().length ==0)
	{
		alert("请输入用户名或密码!");
		return false;
	}
	else
	{
		
		var actionUrl = '/member/LoginPageR.aspx?';
		if(document.getElementById('isAutoLogin').checked)
			actionUrl +='isAuto=True&';
		actionUrl += 'url='+window.location.href;
		document.forms["form_mini"].action =  actionUrl;
 
		document.forms["form_mini"].submit();
	}
}

function LoginSubmit_mini(event)
{
if (event.keyCode == 13)
{
event.ctrlKey;
document.getElementById("btn_mini_submit").click();
}
}


function $(id)
{
	return document.getElementById(id);
}

function RequestByGet(URL,fcm)
{
 
	var xmlhttp=false;
   try {
			xmlhttp = new ActiveXObject("Msxml2.XMLHTTP");
	   } 
   catch (e) 
	  {
		   try {
					xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
			   } 
			   catch (E) 
			   {
					xmlhttp = false;
			   }
	  }
    if(!xmlhttp && typeof XMLHttpRequest!='undefined') 
    {
      xmlhttp = new XMLHttpRequest();
    }
  
	xmlhttp.open("get",URL, true); 
	xmlhttp.onreadystatechange = function() 
    {
        if(xmlhttp.readyState==4) 
        {
 
	        fcm(xmlhttp);
        }
    }
	xmlhttp.send(null);
} 

function getUserGrade(level)
{
	var rvalStr = "★";
	switch(level)
	{
		case "0":
			rvalStr  = "★";
			break;
		case "1":
			rvalStr  = "★★";
			break;
		case "2":
			rvalStr  = "★★★";
			break;
		case "3":
			rvalStr  = "★★★★";
			break;
		case "4":
			rvalStr  = "★★★★★";
			break;
		default:
			rvalStr = "★";
			break;
	}
	return rvalStr;
}
function getUserClass(level)
{
	var rvalStr = "普通会员";
	switch(level)
	{
		case "1001":
			rvalStr  = "普通会员";
			break;
		case "1002":
			rvalStr  = "VIP融资会员";
			break;
		case "1003":
			rvalStr  = "VIP招商会员";
			break;
		default:
			rvalStr = "普通会员";
			break;
	}
	return rvalStr;
}