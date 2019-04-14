// JavaScript Document Email
<!-- 
function log_submit(){ 
var User = document.mailForm.mail_name.value; 
var ProNo = document.mailForm.mailSelect.value; 
var mail_action = ProNo.split(";"); 
if(mail_action.length > 1) 
{ 
if(mail_action[1]=="suffix") 
User += "@"+mail_action[2]; 
else 
eval("document.mailForm."+mail_action[1]+".value = '"+mail_action[2]+"';"); 
} 
var Passwd = document.mailForm.mail_password.value; 
var Formobj = document.mailForm; 
function checkUserPass(){ 
if (User == ""){ 
alert("ÇëÌîÐ´ÓÃ»§Ãû"); 
document.mailForm.mail_name.focus(); 
return false; 
} 
else if (Passwd == ""){ 
alert("ÇëÌîÐ´ÃÜÂë"); 
document.mailForm.mail_password.focus(); 
return false; 
} 
else { 
return true; 
} 
} 
if (checkUserPass()){ 
document.mailForm.action = mail_action[0]; 
document.mailForm.u.value = User; 
document.mailForm.user.value = User; 
document.mailForm.LoginName.value = User; 
document.mailForm.username.value = User; 
document.mailForm.UserName.value = User; 
document.mailForm.login_name.value = User; 
document.mailForm.login.value = User; 
document.mailForm.psw.value = Passwd; 
document.mailForm.pass.value = Passwd; 
document.mailForm.passwd.value = Passwd; 
document.mailForm.password.value = Passwd; 
document.mailForm.Password.value = Passwd; 
document.mailForm.login_password.value = Passwd; 
document.mailForm.submit(); 
document.mailForm.mail_password.value = ""; 
} 
return false; 
} 
//--> 