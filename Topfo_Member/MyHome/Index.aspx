<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="MyHome_Index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>�й�����Ͷ�����������</title>
<meta name="keywords" content="���̣�Ͷ��" />
<meta name="description" content="�й�����Ͷ�����������" />
<link href="css/gray_topfo.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="js/prototype.js"></script>
<%--<base target="_blank">
--%>
<script language="javascript" type="text/javascript">
function GetObj(objName){
if(document.getElementById){
return eval('document.getElementById("' + objName + '")');
}else if(document.layers){
return eval("document.layers['" + objName +"']");
}else
{return eval('document.all.' + objName);}
}
function SetBtn(preFix, idx,uid){

    for(var i=0;i<15;i++)
    {
    
        if(GetObj(preFix+"_btn_"+i)) 
            GetObj(preFix+"_btn_"+i).className = "off";
        if(GetObj(preFix+"_con_"+i))
            GetObj(preFix+"_con_"+i).style.display = "none";
    }
    GetObj(preFix+"_btn_"+idx).className = "on";
    GetObj(preFix+"_con_"+idx).style.display = "block";

    if(idx !=1 & idx!=2)
    {
  new Ajax.Request("AjaxIndex.aspx?cid=1&sc="+uid+"",{method:"get",onComplete:function(response){
  var req = response.responseText;

$("nav_con_"+idx).innerHTML= req;
  }});
  }

}

</script>
</head>

<body>
<!--��괥��Ч��JS-->
<%--<script type="text/javascript" src="js/trigger.js"></script>--%>
<!--�����¼JS-->
<script type="text/javascript" src="js/email.js"></script>


<div style="width:760px; margin:20px auto; overflow:hidden;">

<!--�˵������л�-->
<div class="menu">
	<ul>
		<li class="on" id="nav_btn_1" onclick="SetBtn('nav',1);">�ʼ���ַ</li>
		<li id="nav_btn_2" onclick="SetBtn('nav',2);">���߹���</li>
      
		<%=GetAllType()%> 
	</ul>
</div>
<!--���岿��-->
<div class="date f_date">
	<!--����-->
	<div class="date_l"><script language="javascript" type="text/javascript" src="js/date.js"></script></div>
	<!--����-->
	<div class="date_r"><a href="#" target="_parent">&gt;&gt;�����ҵĿ������</a>&nbsp;&nbsp;<a href="#">&gt;&gt;Ĭ�Ͽ������</a></div>
	<div class="clear"></div>
</div>

<!--�ʼ���ַ-->
<div class="mail" id="nav_con_1">
	<div class="mail_l" ></div>
	<div class="mail_r">
		<form method="post" target="_blank" name="mailForm" onsubmit='return log_submit();'>
				<input type="hidden" name="u" value=""> 
				<input type="hidden" name="user" value=""> 
				<input type="hidden" name="LoginName" value=""> 
				<input type="hidden" name="username" value=""> 
				<input type="hidden" name="UserName" value=""> 
				<input type="hidden" name="login_name" value=""> 
				<input type="hidden" name="login" value=""> 
				<input type="hidden" name="psw" value=""> 
				<input type="hidden" name="language" value=""> 
				<input type="hidden" name="pass" value=""> 
				<input type="hidden" name="passwd" value=""> 
				<input type="hidden" name="password" value=""> 
				<input type="hidden" name="Password" value=""> 
				<input type="hidden" name="login_password" value=""> 
				<input type="hidden" name="url" value=""> 
				<input type="hidden" name="BackURL" value=""> 
		<span class="name">
			��������<input name="mail_name" onfocus="this.select" class="inp_mail">
			<select name="mailSelect"> 
				<option selected>ѡ����������</option> 
				<option value="http://mail.sina.com.cn/cgi-bin/login.cgi">@sina.com</option> 
				<option value="http://reg.163.com/in.jsp?url=http://fm163.163.com/coremail/fcg/ntesdoor2?username=wd.dm.mailForm.name.value">@163.com</option> 
				<option value="http://login.mail.sohu.com/chkpwd.php">@sohu.com</option> 
				<option value="http://login.chinaren.com/zhs/servlet/Login;url;http:/mail.chinaren.com">@ChinaRen.com</option> 
				<option value="http://bjweb.163.net/cgi/163/login_pro.cgi">@163.net</option> 
				<option value="http://bjweb.mail.tom.com/cgi/163/login_pro.cgi">@Tom.com</option> 
				<option value="http://webmail.21cn.com/NULL/NULL/NULL/NULL/NULL/SignIn.gen">@21cn.com</option> 
				<option value="https://edit.bjs.yahoo.com/config/login">@yahoo.com.cn</option> 
				<option value="http://entry.126.com/cgi/login">@126.com</option> 
				<option value="http://g2wm.263.net/xmweb">@263.net</option> 
				<option value="http://freemail.eyou.com/cgi-bin/login">@eyou.com</option> 
				<option value="http://vip.sina.com/cgi-bin/login.cgi">@vip.sina.com</option> 
				<option value="http://vip.163.com/payment/VipLogon.jsp">@vip.163.com</option> 
				<option value="http://paymail.china.com/extend/gb/NULL/NULL/NULL/SignIn.gen">@China.com</option> 
				<option value="http://mw1.elong.com/cgi-bin/weblogon.cgi">@elong.com</option> 
				<option value="http://login.etang.com/servlet/login;BackURL;http:/mail.etang.com/cgi/door">@etang.com</option> 
				<option value="http://www.citiz.net/login.jsp">@citiz.net</option> 
				<option value="http://202.106.186.230/extend/newgb1/NULL/NULL/NULL/SignIn.gen">@email.com.cn</option> 
				
	      	</select><br>
			�ܡ��룺<input type="password" name="mail_password" onfocus="this.select" class="inp_mail"/>
		</span>
		<span class="ent">
			�����������������룬ϵͳ�������ת���벻�ᱻ��¼��<br/>
			<input type="submit" name="" value="" class="btn3"/>
		</span>
		</form> 
	</div>
	<div class="clear"></div>
    <table border="0" cellspacing="0" cellpadding="0" class="tab4">
      <tr>
         <td width="10%"><a href="http://email.163.com/" target="_blank">����163����</a></td>
        <td width="10%"><a href="http://mail.sina.com.cn/" target="_blank">��������</a></td>
        <td width="10%"><a href="http://mail.sohu.com/" target="_blank">�Ѻ�����</a></td>
        <td width="10%"><a href="http://mail.tom.com/" target="_blank">TOM����</a></td>
        <td width="10%"><a href="http://www.126.com/" target="_blank">����126����</a></td>
        <td width="10%"><a href="http://mail.10086.cn/" target="_blank">139�ֻ�����</a></td>
       <td width="10%"><a href="https://mail.qq.com/cgi-bin/loginpage" target="_blank">QQ����</a></td>
       <td width="10%"><a href="http://mail.cn.yahoo.com/" target="_blank">�Ż�����</a></td>
       <td width="10%"><a href="https://www.google.com/accounts/ServiceLogin?service=mail&passive=true&rm=false&continue=http%3A%2F%2Fmail.google.com%2Fmail%2F%3Fui%3Dhtml%26zy%3Dl&bsv=1eic6yu9oa4y3&scc=1&ltmpl=default&ltmplcache=2" target="_blank">Gmail</a></td>
       <td width="10%"><a href="https://login.live.com/login.srf?wa=wsignin1.0&rpsnv=11&ct=1290663860&rver=6.1.6206.0&wp=MBI&wreply=http:%2F%2Fmail.live.com%2Fdefault.aspx&lc=2052&id=64855&mkt=zh-cn&cbcxt=mai&snsc=1" target="_blank">Hotmail</a></td>
      </tr>
      <tr>
        <td><a href="http://www.eyou.com/" target="_blank">����</a></td>
        <td><a href="https://mail.qq.com/cgi-bin/loginpage" target="_blank">QQ����</a></td>
        <td><a href="http://mail.sogou.com/" target="_blank">�ѹ�����</a></td>
        <td><a href="http://webmail15.189.cn/webmail/" target="_blank">189����</a></td>
        <td><a href="http://mail.wo.com.cn/" target="_blank">��ͨ�ֻ�����</a></td>
        <td><a href="http://mail.qq.com/cgi-bin/loginpage?t=fox_loginpage&sid=,2,zh_CN&r=b2ca925e1c42cb7a69532a031ef7a1a9" target="_blank">foxmail</a></td>
        <td><a href="http://www.263.net/" target="_blank">263����</a></td>
         <td><a href="http://mail.21cn.com/" target="_blank">21CN����</a></td>
        <td><a href="http://www.188.com/" target="_blank">188�Ƹ���</a></td>
         <td><a href="http://www.yeah.net/" target="_blank">����Yeah.net</a></td>
      </tr>
    </table>
</div>

<!--���߹���-->
<div class="con" id="nav_con_2" style="display:none;">
  <table border="0" cellspacing="0" cellpadding="0" class="tab2 f_14">
      <tr>
        <td colspan="6" class="col strong">���߹��߿�ݵ���</td>
      </tr>
      <tr>
        <td width="16%" style="text-align:center"><a href="http://chaxun.1616.net/lieche.htm" target="_blank">�г�ʱ�̲�ѯ</a></td>
        <td width="16%" style="text-align:center"><a href="http://www.qunar.com/" target="_blank">�����ѯ</a></td>
        <td width="16%" style="text-align:center"><a href="http://www.13393.com/kuaidi.htm" target="_blank">��ݲ�ѯ</a></td>
        <td width="16%" style="text-align:center"><a href="http://www.8684.cn/" target="_blank">���ڹ�����ѯ</a></td>
        <td width="16%" style="text-align:center"><a href="http://weather.news.sina.com.cn/" target="_blank">����Ԥ��</a></td>
        <td width="16%" style="text-align:center"><a href="http://map.baidu.com/" target="_blank">��ͼ��ѯ</a></td>
      </tr>
      <tr>
        <td style="text-align:center"><a href="http://www.ip138.com/" target="_blank">IP��ַ��ѯ</a></td>
        <td style="text-align:center"><a href="http://quote.eastmoney.com/quote1_1.html" target="_blank">��Ʊ��ѯ</a></td>
        <td style="text-align:center"><a href="http://translate.google.com.hk/#" target="_blank">���߷���</a></td>
        <td style="text-align:center"><a href="http://i.maxthon.cn/tuan/index.htm" target="_blank">�����Ź�</a></td>
        <td style="text-align:center"><a href="http://www.lottery.gov.cn/" target="_blank">������Ʊ</a></td>
        <td style="text-align:center"><a href="http://www.zhcw.com/" target="_blank">������Ʊ</a></td>
      </tr>
    </table>
</div>

<!--�û�����-->
<div class="con" id="nav_con_3" style="display:none;"></div>

<div class="con" id="nav_con_4" style="display:none;"></div>

<div class="con" id="nav_con_5" style="display:none;"></div>
<div class="con" id="nav_con_6" style="display:none;"></div>
<div class="con" id="nav_con_7" style="display:none;"></div>
<div class="con" id="nav_con_8" style="display:none;"></div>
<!--�û�����-->




</div>

</body>
</html>
