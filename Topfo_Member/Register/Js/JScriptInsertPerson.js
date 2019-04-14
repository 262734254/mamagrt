// JScript 文件
 //验证码验证
      var code ; //在全局 定义验证码   
     function createCode()   
     {    
       code = "";   
       var codeLength = 6;//验证码的长度   
       var checkCode = document.getElementById("checkCode");   
       var selectChar = new Array(0,1,2,3,4,5,6,7,8,9,'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z');//所有候选组成验证码的字符，当然也可以用中文的      
       for(var i=0;i<codeLength;i++)   
       {   
        var charIndex = Math.floor(Math.random()*36);   
        code +=selectChar[charIndex];   
       }    
       if(checkCode)   
       {   
         checkCode.className="code";   
         checkCode.value = code;
         checkCode.blur();   
       }        
     }  
      function checkinsert()
   {
   if(document.getElementById ("ctl00_ContentPlaceHolder1_txtCapitalTitle").value.length==0)
   {
     document.getElementById ("showtitle").innerHTML="*";
     document.getElementById ("showtitle").style .display ="inline";
     document.getElementById ("ctl00_ContentPlaceHolder1_txtCapitalTitle").focus();
     return false;
   }
   	   if(document.getElementById("ctl00_ContentPlaceHolder1_ZoneSelectControl1_hideProvince").value=="")
	   {
	          
	       document.getElementById ("showdiyu").innerHTML="*";
           document.getElementById ("showdiyu").style .display ="inline";
	       document.getElementById("ctl00_ContentPlaceHolder1_ZoneId").focus();
	       return false;
	   }
   if(document.getElementById ("ctl00_ContentPlaceHolder1_txtCapitalMoney").value.length==0)
   {
     document.getElementById ("showmoney").innerHTML="*";
     document.getElementById ("showmoney").style .display ="inline";
     document.getElementById ("ctl00_ContentPlaceHolder1_txtCapitalMoney").focus();
     return false;
   }
       if(document.getElementById ("ctl00_ContentPlaceHolder1_txtCapitalMoney").value.substring(0,1)=="0"&&document.getElementById ("ctl00_ContentPlaceHolder1_txtCapitalMoney").value.length>0)
   {
      document.getElementById ("showmoney").innerHTML="无效的数据";
     document.getElementById ("showmoney").style .display ="inline";
     document.getElementById ("ctl00_ContentPlaceHolder1_txtCapitalMoney").focus();
     return false;

   }
      if(document.getElementById ("ctl00_ContentPlaceHolder1_txtCapitalIntent").value.length==0)
   {
     document.getElementById ("showdescript").innerHTML="*";
     document.getElementById ("showdescript").style .display ="inline";
     document.getElementById ("ctl00_ContentPlaceHolder1_txtCapitalIntent").focus();
     return false;
   }
   if(document.getElementById ("ctl00_ContentPlaceHolder1_txtcontactsName").value.length==0)
   {
     document.getElementById ("showname").innerHTML="*";
     document.getElementById ("showname").style .display ="inline";
     document.getElementById ("ctl00_ContentPlaceHolder1_txtcontactsName").focus();
     return false;
   }
   if(document.getElementById ("ctl00_ContentPlaceHolder1_txtcontactsphone").value.length==0&&document.getElementById ("ctl00_ContentPlaceHolder1_txtcontactsTel").value.length==0)
   {
     document.getElementById ("showtel").innerHTML="*";
     document.getElementById ("showtel").style .display ="inline";
      document.getElementById ("ctl00_ContentPlaceHolder1_txtcontactsTel").focus();
     return false;
   }
      if(document.getElementById ("ctl00_ContentPlaceHolder1_txtcontactsphone").value.length==0&&document.getElementById ("ctl00_ContentPlaceHolder1_txttel1").value.length==0)
   {
     document.getElementById ("showtel").innerHTML="*";
     document.getElementById ("showtel").style .display ="inline";
      document.getElementById ("ctl00_ContentPlaceHolder1_txttel1").focus();
     return false;
   }
      if(document.getElementById ("ctl00_ContentPlaceHolder1_txtcontactsphone").value.length==0&&document.getElementById ("ctl00_ContentPlaceHolder1_txttel2").value.length==0)
   {
     document.getElementById ("showtel").innerHTML="*";
     document.getElementById ("showtel").style .display ="inline";
      document.getElementById ("ctl00_ContentPlaceHolder1_txttel2").focus();
     return false;
   }
      if(document.getElementById ("ctl00_ContentPlaceHolder1_txtcontactsphone").value.length>0&&document.getElementById ("ctl00_ContentPlaceHolder1_txtcontactsphone").value.length<11)
   {
     document.getElementById ("showMoblie").innerHTML="手机号码填写不正确";
     document.getElementById ("showMoblie").style .display ="inline";
     document.getElementById ("ctl00_ContentPlaceHolder1_txtcontactsphone").focus();
     return false;
   }

       var s=document.getElementById("ctl00_ContentPlaceHolder1_txtcontactsemail").value;      	   if((s.charAt(0)=="@")||(s.charAt(0)=="."))	   { 	   	document.getElementById ("showemail").innerHTML="电子邮件的格式不能以@或者.开头!";
        document .getElementById ("showemail").style.display ="inline";        document.getElementById ("ctl00_ContentPlaceHolder1_txtcontactsemail").focus();		return false;	   }	  if(s.length==0)         {		 document.getElementById ("showemail").innerHTML="*";
          document .getElementById ("showemail").style.display ="inline";          document.getElementById ("ctl00_ContentPlaceHolder1_txtcontactsemail").focus();		 return false;		 }	  if(s.indexOf("@",0)==-1)	     {
	      document.getElementById ("showemail").innerHTML="电子邮件格式不正确\n必须包含@符号!";
          document .getElementById ("showemail").style.display ="inline";          document.getElementById ("ctl00_ContentPlaceHolder1_txtcontactsemail").focus();		  return false;	     }	if(s.indexOf(".",0)==-1)	  {	  document.getElementById ("showemail").innerHTML="电子邮件格式不正确\n必须包含.符号!";
      document .getElementById ("showemail").style.display ="inline";      document.getElementById ("ctl00_ContentPlaceHolder1_txtcontactsemail").focus();	  return false;	  }	if(escape(s).indexOf("%u")!=-1)
      {
      document.getElementById ("showemail").innerHTML="邮件中不能包含汉字";
      document .getElementById ("showemail").style.display ="inline";
      document.getElementById ("ctl00_ContentPlaceHolder1_txtcontactsemail").focus();
      return false ;

    }
    if(document.getElementById ("txtyanzheng").value.length==0)
   {
    document.getElementById ("showpostcode").innerHTML="*";
     document.getElementById ("showpostcode").style .display ="inline";
     document.getElementById ("txtyanzheng").focus();
     return false;
   }      if(document.getElementById("txtyanzheng").value.toUpperCase()!=document.getElementById("checkCode").value)
     {
     document.getElementById ("showpostcode").innerHTML ="验证码错误";
     document.getElementById ("showpostcode").style .display ="inline";
     document.getElementById ("txtyanzheng").focus();
     createCode()  ;
     return false;
     }   else{    return true;
    }

   }
     function s()
  {
      document.getElementById ("ctl00_ContentPlaceHolder1_imgLoding").style .display ="";
  }
   
