<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="MyHome_Index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>�й�����Ͷ�����������</title>
<meta name="keywords" content="���̣�Ͷ��" />
<meta name="description" content="�й�����Ͷ�����������" />
<link href="css/gray_topfo.css" rel="stylesheet" type="text/css" />
<%--<base target="_blank">
--%></head>

<body>
<!--��괥��Ч��JS-->
<script type="text/javascript" src="js/trigger.js"></script>
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
	<div class="mail_l"></div>
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
				<option selected>ѡ�������ʾ�</option> 
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
			�ܡ��룺<input type="password" name="mail_password" onfocus="this.select" class="inp_mail">
		</span>
		<span class="ent">
			�����������������룬ϵͳ�������ת���벻�ᱻ��¼��<br>
			<input type="submit" name="" value="" class="btn3">
		</span>
		</form> 
	</div>
	<div class="clear"></div>
    <table border="0" cellspacing="0" cellpadding="0" class="tab4">
      <tr>
        <td width="10%"><a href="#">163����</a></td>
        <td width="10%"><a href="#">��������</a></td>
        <td width="10%">�Ѻ�����</td>
        <td width="10%">Tom����</td>
        <td width="10%">��Ѷ������</td>
        <td width="10%">��������</td>
        <td width="10%">��������</td>
        <td width="10%">��������</td>
        <td width="10%">��������</td>
      </tr>
      <tr>
        <td>126����</td>
        <td>��������</td>
        <td>��������</td>
        <td>��������</td>
        <td>��������</td>
        <td>��������</td>
        <td>��������</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
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
        <td width="16%"><a href="#">�й�����Ͷ����</a></td>
        <td width="16%"><a href="#">�й�����Ͷ����</a></td>
        <td width="16%">�й�����Ͷ����</td>
        <td width="16%">&nbsp;</td>
        <td width="16%">&nbsp;</td>
        <td width="16%">&nbsp;</td>
      </tr>
      <tr>
        <td style="height: 30px"><a href="#">�й�����Ͷ����</a></td>
        <td style="height: 30px">&nbsp;</td>
        <td style="height: 30px">&nbsp;</td>
        <td style="height: 30px">&nbsp;</td>
        <td style="height: 30px">&nbsp;</td>
        <td style="height: 30px">&nbsp;</td>
      </tr>
    </table>
</div>

<!--�û�����-->
<div class="con" id="nav_con_3" style="display:none;">
  <table border="0" cellspacing="0" cellpadding="0" class="tab2 f_14">
      <tr>
        <td colspan="6" class="col strong">
            <asp:Label ID="lblName" runat="server" Text=""></asp:Label></td>
      </tr>
      <tr>
        <td width="16%" style="height: 30px">&nbsp;</td>
        <td width="16%" style="height: 30px">&nbsp;</td>
        <td width="16%" style="height: 30px">&nAAAbsp;</td>
        <td width="16%" style="height: 30px">&nbsp;</td>
        <td width="16%" style="height: 30px">&nbsp;</td>
        <td width="16%" style="height: 30px">&nbsp;</td>
      </tr>
      <tr>
        <td style="height: 30px">AAA</td>
        <td style="height: 30px">&nbsp;</td>
        <td style="height: 30px">&nbsp;</td>
        <td style="height: 30px">&nbsp;</td>
        <td style="height: 30px">&nbsp;</td>
        <td style="height: 30px">&nbsp;</td>
      </tr>
    </table>
</div>

<!--�û�����-->
<div class="con" id="nav_con_4" style="display:none;">
  <table border="0" cellspacing="0" cellpadding="0" class="tab2 f_14">
      <tr>
        <td colspan="6" class="col strong">���޷���</td>
      </tr>
      <tr>
        <td width="16%">&nbsp;</td>
        <td width="16%">&nbsp;</td>
        <td width="16%">&nbsp;</td>
        <td width="16%">&nbsp;</td>
        <td width="16%">&nbsp;</td>
        <td width="16%">&nbsp;</td>
      </tr>
      <tr>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
    </table>
</div> 

<!--�û�����-->
<div class="con" id="nav_con_5" style="display:none;">
  <table border="0" cellspacing="0" cellpadding="0" class="tab2 f_14">
      <tr>
        <td colspan="6" class="col strong">���޷���</td>
      </tr>
      <tr>
        <td width="16%">&nbsp;</td>
        <td width="16%">&nbsp;</td>
        <td width="16%">&nbsp;</td>
        <td width="16%">&nbsp;</td>
        <td width="16%">&nbsp;</td>
        <td width="16%">&nbsp;</td>
      </tr>
      <tr>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
    </table>
</div>

<!--�û�����-->
<div class="con" id="nav_con_6" style="display:none;">
  <table border="0" cellspacing="0" cellpadding="0" class="tab2 f_14">
      <tr>
        <td colspan="6" class="col strong">���޷���</td>
      </tr>
      <tr>
        <td width="16%">&nbsp;</td>
        <td width="16%">&nbsp;</td>
        <td width="16%">&nbsp;</td>
        <td width="16%">&nbsp;</td>
        <td width="16%">&nbsp;</td>
        <td width="16%">&nbsp;</td>
      </tr>
      <tr>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
    </table>
</div>

<!--�û�����-->
<div class="con" id="nav_con_7" style="display:none;">
  <table border="0" cellspacing="0" cellpadding="0" class="tab2 f_14">
      <tr>
        <td colspan="6" class="col strong">���޷���</td>
      </tr>
      <tr>
        <td width="16%">&nbsp;</td>
        <td width="16%">&nbsp;</td>
        <td width="16%">&nbsp;</td>
        <td width="16%">&nbsp;</td>
        <td width="16%">&nbsp;</td>
        <td width="16%">&nbsp;</td>
      </tr>
      <tr>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
    </table>
</div>

<!--�û�����-->
<div class="con" id="nav_con_8" style="display:none;">
  <table border="0" cellspacing="0" cellpadding="0" class="tab2 f_14">
      <tr>
        <td colspan="6" class="col strong">���޷���</td>
      </tr>
      <tr>
        <td width="16%">&nbsp;</td>
        <td width="16%">&nbsp;</td>
        <td width="16%">&nbsp;</td>
        <td width="16%">&nbsp;</td>
        <td width="16%">&nbsp;</td>
        <td width="16%">&nbsp;</td>
      </tr>
      <tr>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
    </table>
</div>

</div>

</body>
</html>
