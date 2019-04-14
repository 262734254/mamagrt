// JScript 文件

function ches()
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

    }   else{    return true;
    }
    
}
  function sss()
  {
      document.getElementById ("ctl00_ContentPlaceHolder1_imgLoding").style .display ="";
  }