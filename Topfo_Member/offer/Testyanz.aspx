<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Testyanz.aspx.cs" Inherits="offer_Testyanz" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">     
    <title>无标题页</title>
    <script language="javascript">
      function chkpost()
   {  

          var c="ctl00_ContentPlaceHolder1_";
            var kj="";
            var zt="";
            var obj="";
                        
            //标题
            var ProjectName="txtCapitalName";
            if(document.getElementById(ProjectName).value=="")
            {
                alert("项目标题不能为空...");
                document.getElementById(ProjectName).focus();
                return false;
            }
        var inputCode = document.getElementById("validCode").value;   
       if(inputCode.length <=0)   
       {   
           alert("请输入验证码1111！");   
       }   
       else if(inputCode.toUpperCase() != code )   
       {   
          alert("验证码输入错误111！");   
          createCode();//刷新验证码   
       }   
      
     }
    </script>
    <script src="js/yanz.js"></script>
     <link href="css/member.css"rel="stylesheet" type="text/css" />

</head>    
<body >


  
    <form  action="#">  
     <input  type="text"   id="validCode" />  
    <input type="text" onClick="createCode()" readonly="readonly" id="checkCode" class="unchanged" style="width: 80px;cursor:pointer"  /><br /> 
     <input  type="text"   id="txtCapitalName" />  
    <input id="Button1"  onclick="chkpost();" type="button" value="确定" />    
         <script language="javascript">  createCode();</script>
 
</form>
</body>
</html>
