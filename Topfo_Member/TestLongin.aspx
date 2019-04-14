<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestLongin.aspx.cs" Inherits="TestLongin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<script language="javascript" src="http://chat.7k35.com/chat/7k35_1.jsp?eprId=topfo" type="text/jscript"></script>
<script type="text/javascript" src="http://www.topfo.com/AdImg/js/getImage.js"></script>


    <script type="text/javascript"> 
    
function getCookie()//读取cookies函数        
{  
    var loginnameStr="";
    var ckdataStr="";
    
    if(document.cookie!=""&&document.cookie.indexOf(";")!=-1)
    {   
        var cookies = document.cookie.split(';');
        for(var i=0;i<cookies.length;i++)
        {//alert(cookies[i]);
            var co = cookies[i];
            if(co.indexOf("topfo.com")!=-1)
            {
                if(co.indexOf("topfo.com.LoginName")!=-1)
                {
                    loginnameStr=co.split('=')[1];
                }
                if(co.indexOf("topfo.com_CKData")!=-1)
                {
                    ckdataStr=co.split('=')[1];
                }
            } 
        }
    }
    if(loginnameStr =="" || loginnameStr ==null)
    {
        loginnameStr = ckdataStr;
    }
    //alert(loginnameStr);
    //alert(ckdataStr);
    if(loginnameStr!=null&&loginnameStr!="")
    {
        
        document.getElementById("divLogin").innerHTML =" <span class='name' style='height:20px;line-height:20px;text-indent:10px;'>尊敬的用户会员 " + loginnameStr + ",您已经登陆..</span><span class='ser' style='height:20px;line-height:20px;'><a href='http://member8.topfo.com/Publish/publishNavigate.aspx' target='_blank'>[进入拓富中心]</a>&nbsp;&nbsp;<a href='http://member.topfo.com/Logout.aspx' target='_self'>[退出]</a></span>";
       
        
    }
}
   var str ="";
    var messageIndex = 0;
    window.onload = function()
    {
       
        getCookie();
        //消息提示框
         var loginnameStr="";
        var ckdataStr="";
    
        if(document.cookie!=""&&document.cookie.indexOf(";")!=-1)
        {   
            var cookies = document.cookie.split(';');
            for(var i=0;i<cookies.length;i++)
            {//alert(cookies[i]);
                var co = cookies[i];
                if(co.indexOf("topfo.com")!=-1)
                {
                    if(co.indexOf("topfo.com.LoginName")!=-1)
                    {
                        loginnameStr=co.split('=')[1];
                    }
                    if(co.indexOf("topfo.com_CKData")!=-1)
                    {
                        ckdataStr=co.split('=')[1];
                    }
                } 
            }
        }
        if(loginnameStr =="" || loginnameStr ==null)
        {
            loginnameStr = ckdataStr;
        }
        if(loginnameStr !="")
        {
            setInterval("getStrHTML()",15000);
        }
    }
function CheckLogin_mini()
{  
	if (document.getElementById("txtLoginName").value.length ==0)
	{
		alert("请输入用户名!");
		document.getElementById("txtLoginName").focus();
		return;
	}
	if(document.getElementById("txtPassword").value.length ==0)
	{
		alert("请输入密码!");
		document.getElementById("txtPassword").focus();
		return;
	}
	else
	{	
var actionUrl ="http://member8.topfo.com/LoginR.aspx?";
		//if(document.getElementById('isAutoLogin').checked)
			actionUrl +='isAuto=False&';
		actionUrl += 'url='+window.location.href;
		
		document.forms["form_mini"].action = actionUrl;
		document.forms["form_mini"].submit();
	}
}

</script>
<body>
	            <div id="divLogin" class="login_02" style="float: left;">
                <form id="form_mini" method="post" target="_self" action="" defaultbutton="btLogin">
                    <div style="float: left;">
                        用户名
                        <input id="txtLoginName" name="txtLoginName" type="text" style="width: 70px;" />
                        密码:
                        <input id="txtPassword" name="txtPassword" type="password" style="width: 70px;" maxlength="20" />
                    </div>
                    <div style="float: left; padding-left: 8px;">
                        <input id="btLogin" name="" type="submit" class="btn20" onclick="CheckLogin_mini();return false;"
                            value="" />
                    </div>
                    <a href="http://member8.topfo.com/LoginR.aspx">进入拓富中心</a>
                    <div class="login_03">
                        注册会员 忘记密码？</div>
                </form>
                <div class="login_04">
                </div>
                <ul>
                    <li>·成功为江苏省某经济技术开发区基础</li>
                    <li>·成功促进台湾某控股集团在福建</li>
                    <li>·成功为中国某三大产业龙头企业合作</li>
                    <li>·成功为河南省某高速公路项目融资</li>
                </ul>
            </div>

</body>
</html>
