<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SetNotice.aspx.cs" Inherits="helper_SetNotice" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
      <script language="JavaScript" src="/js/cmPopWin.js" ></script>
 <link href="http://www.topfo.com/web13/css/base.css" rel="stylesheet" type="text/css" />

</head>
<body>
    <form id="form1" name="form1" runat="server">
    <div>
        <table align="center" border="0" cellpadding="0" cellspacing="0" class="greyguang"
            height="222" width="421">
            <tr>
                <td align="left" valign="top" style="width: 429px; height: 15px;">
                    <table bgcolor="#e9e9e9" border="1" bordercolor="#ffffff" cellpadding="0" cellspacing="0"
                       width="100%">
                        <tr>
                            <td>
                                <font class="cheng" face="宋体"><span style="color: #ff6600"><span
                                    style="color: #000000">接收方式设置</span></span></font></td>
                            <td><div align="right"><img id="btnresend"  onclick="closeit();" src="http://member.topfo.com/images/reg_step/no.gif" />&nbsp;</div></td>
                        </tr>
                    </table>
                    </td>
            </tr>
            <tr style="color: #ff6600">
                <td style="padding-right: 35px; padding-left: 35px; padding-bottom: 15px; padding-top: 25px; width: 429px;">
                    <font face="宋体">
                        <table id="Table1" align="center" border="0" cellpadding="4" cellspacing="2" style="width: 102%; height: 119px">
                            <tr>
                                <td align="middle" bgcolor="#d1d1d1" width="28%" style="height: 26px">
                                    <font face="宋体">接收方式：</font></td>
                                <td align="left" bgcolor="#eaeaea" width="72%" style="height: 26px">
                                    <input id="dzchk2" runat="server" name="dzchk2" type="checkbox" value="2" />电子邮箱<input
                                      onblur="checkMail();"   id="txtEmail" runat="server" name="textarea" style="width: 113px" type="text" />
                                    <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="middle" bgcolor="#d1d1d1">
                                    </td>
                                <td align="left" bgcolor="#eaeaea">
                                    <input id="dzchk1" runat="server" name="checkbox" type="checkbox" value="1" />站内短信</td>
                            </tr>
                            <tr >
                                <td align="middle" bgcolor="#d1d1d1">
                                </td>
                                <td align="left" bgcolor="#eaeaea">
                                    <input id="dzchk3" runat="server" name="checkbox" type="checkbox" value="3" />手机短信<input
                                       onblur="checkMobile()"  id="txtMobile" runat="server" name="textarea" style="width: 119px" type="text" />
                                    <asp:Label ID="Label2" runat="server" ForeColor="Red"></asp:Label></td>
                            </tr>
                            <tr >
                                <td align="middle" bgcolor="#d1d1d1">
                                </td>
                                <td align="left" bgcolor="#eaeaea">                               
                                    <input id="Button1" runat="server" class="buttomal" name="" onserverclick="Button1_ServerClick"
                                        type="button" value="设 置" />
                                    <input class="buttomal" name="Input" onclick="closeit();" type="button" value="关 闭"  /></td>
                            </tr>
                        </table>
                    </font>
                    <input id="Hidden1" type="hidden" runat="server" value="0" /></td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
   <script>
   function closeit()
   {
        var strReturn="";
        var s1 = document.getElementById("dzchk1");
        var s2 = document.getElementById("dzchk2");
        var s3 = document.getElementById("dzchk3");
        var c = document.getElementById("Hidden1").value;//是否要更新
        
        if(s1.checked) strReturn="站内短信、";
        if(s2.checked) strReturn +="电子邮箱、";
        if(s3.checked) strReturn +="手机短信" ; 
        
        parent.HideMessageWin(strReturn,c);
  
   }
   function checkMail()
   {
       var objMail = document.getElementById("txtEmail").value;
       var objLabel1 =document.getElementById("Label1");
       var blMail=true;     
	   if(objMail!="")
		{
		  	var filter = /^[_a-zA-Z0-9\-]+(\.[_a-zA-Z0-9\-]*)*@[a-zA-Z0-9\-]+([\.][a-zA-Z0-9\-]+)+$/;
            if (!filter.test(objMail))
             { 	
                objLabel1.innerHTML="邮箱输入错误";  
                blMail= false;
             }
      	 }
      	 else
      	 {  
      	    objLabel1.innerHTML="";  
            blMail= true;
      	 }
      return blMail;
   }
   
   	function checkMobile()
	{
	/*^13\d{5,9}$/ //130–139。至少5位，最多9位

/^153\d{4,8}$/ //联通153。至少4位，最多8位

/^159\d{4,8}$/ //移动159。至少4位，最多8位 */
        var mobile= document.getElementById("txtMobile").value;
        var my=false;
        if(mobile!="")
        {
            var objLabel2 =document.getElementById("Label2");
            var reg0 = /^13\d{5,9}$/;
            var reg1 = /^153\d{4,8}$/;
            var reg2 = /^159\d{4,8}$/;
            var reg3 = /^0\d{10,11}$/;       
            if (reg0.test(mobile))my=true;
            if (reg1.test(mobile))my=true;
            if (reg2.test(mobile))my=true;
            if (reg3.test(mobile))my=true;
        }
        else   { my=true; objLabel2.innerHTML=""; }   
        if(!my) objLabel2.innerHTML="手机输入错误！";    
        return my;	
	}	
	function chkPost()
	{
	//  if(!checkMail())return false;
	//  if(!checkMobile())return false;
	}
   </script> 
