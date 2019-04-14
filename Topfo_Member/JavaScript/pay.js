//全选与反选
function chkAll() 
{ 
    var a = document.getElementsByTagName("input"); 
	for (var i=0; i<a.length; i++) 
	 if (a[i].type == "checkbox") 
		a[i].checked =!a[i].checked; 
}
//刷新验证码
function refreshVerifyCode()
{
	var f = document.getElementById('imgVali');
	if (f)
	{
		var src =f.src+"?tmpId="+Math.random();
		f.src =src;
				
	}
}
//验证帐户
function valiLoginName()
	{
	    var u=document.getElementById("txtLoginName1");
	    AjaxMethod.ValiLoginName(u.value,backres);
	}
	function backres(res)
	{
	   if(!res.value)
	   {
	        document.getElementById("divmsg").innerHTML="<font color='red'>输入的帐户不存在!<font>";
	        document.getElementById("txtLoginName1").value="";
	   }
	   else
	   {
	        document.getElementById("divmsg").innerHTML="";
	   }
	}
 function $id(obj)
	{
	     return document.getElementById("ctl00_ContentPlaceHolder1_"+obj);
	}
	function chkInPutMoney()
	{
	   
		if($id("txtLoginName1").value=="")
		{
			alert("请填写需要充值的帐户!");
			$id("txtLoginName1").focus();
			return false;
		}
		if($id("txtLoginName2").value=="")
		{
			alert("请填写需要充值的帐户!");
			$id("txtLoginName2").focus();
			return false;
		}
		if($id("txtLoginName1").value!=$id("txtLoginName2").value)
		{
			alert("两次输入的帐号不一致!");
			$id("txtLoginName2").focus();
			return false;
		}
		if($id("txtMoney").value=="")
		{
			alert("充值金额不能为空!");
			$id("txtMoney").focus();
			return false;
		}
		if(parseInt($id("txtMoney").value)>100000000)
		{
			alert("充值金额太大会出现意外的错误!请使用小额多充值几次!");
			$id("txtMoney").focus();
			return false;
		}
		if(isNaN($id("txtMoney").value))
		{
			alert("请输入正确的充值金额!");
			$id("txtMoney").focus();
			return false;
		}
		if($id("txtValiNo").value=="")
		{
			alert("验证不能为空!");
			$id("txtValiNo").focus();
			return false;
		}
		
	}
	function valiLoginName()
	{
	    var u=$id("txtLoginName1");
	    AjaxMethod.ValiLoginName(u.value,backres);
	}
	function backres(res)
	{
	   if(!res.value)
	   {
	        document.getElementById("divmsg").innerHTML="<font color='red'>输入的帐户不存在!<font>";
	        $id("txtLoginName1").value="";
	   }
	   else
	   {
	        document.getElementById("divmsg").innerHTML="";
	   }
	}
	
function ShowMessageWin()
{     
   
     if($id("eadd_bgdiv") && $id("eadd_windiv"))  
        return ;
        
        var h;
        if(document.body.scrollHeight > document.body.offsetHeight)
                h = document.body.scrollHeight;
        else
                h = document.body.offsetHeight;
        
        //底层
        var bgdiv = document.createElement("div");
        bgdiv.id = "eadd_bgdiv";
        bgdiv.style.left = 0;                                
        bgdiv.style.top = 0;        
        bgdiv.style.width = document.body.scrollWidth;
        bgdiv.style.height = h;
        bgdiv.style.position = "absolute";
        bgdiv.style.filter = "alpha(opacity=60)";        
        bgdiv.style.backgroundColor = "#999999";
        bgdiv.style.zIndex = 99;
        
        //上层
        var windiv = document.createElement("div");
        windiv.id = "eadd_windiv";
        windiv.style.left = (document.body.offsetWidth-436)/2;                                
        windiv.style.top = 200;
        windiv.style.width = "400px";
        windiv.style.position = "absolute";
        windiv.style.filter = "alpha(opacity=100)";
        windiv.style.zIndex = 100;

        //修改邮箱
        var clewframe ='width:436px; height:110px;border:3px solid #ff8400; text-align:left; background:white; padding:50px';
        var content = '<div id="send">';
	    content += '<div style="'+clewframe +'">';
	    content += '<h4>更换新的邮箱：</h4>';
		content += '<table width="0" border="0">';
		content += '<tr>';
		content += 	    '<td><input class="email_input nomargin" type="text" id="semail" /></td>';
		content += 	    '<td><img name="" id="submit" src="../images/reg_step/validate_fa.gif" /></td>';
		content += '</tr>';
		content += '</table>';
	    content +=  '<h6>(请确保新邮箱是您本人常用的)</h6>';
	    content += '</div></div>';
        
        windiv.innerHTML = content;  
      
}