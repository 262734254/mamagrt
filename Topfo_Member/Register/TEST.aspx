<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TEST.aspx.cs" Inherits="Register_TEST" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

      <link href="../css/memberdata.css" rel="stylesheet" type="text/css" />
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>

    <script type="text/javascript">
        function yjhkk() {
       
        if (document.getElementById("txtOldPwd").value.length<6) {

                alert('密码不能少于6位！');
                document.getElementById("txtOldPwd").focus();
                 return  false;
            }
           
            if (document.getElementById("txtOldPwd").value =="") {

                alert('密码不能为空！');
                document.getElementById("txtOldPwd").focus();
                 return  false;
            }
            
           if (document.getElementById("txtNewPwd").value=="") {

                alert('请输入新密码！');
                document.getElementById("txtNewPwd").focus();
               return  false;
            }
            
              if (document.getElementById("txtConfirmPwd").value=="") {

                alert('确认密码不能为空！');
                document.getElementById("txtConfirmPwd").focus();
              return  false;
            }
            if (document.getElementById("txtNewPwd").value != document.getElementById("txtConfirmPwd").value) {
                alert("两次密码不相同,请重新输入!");
                document.getElementById("txtConfirmPwd").focus();
                return  false;
              
            }
  
            
        }
    </script>
<body>
    <form id="form1" runat="server">
    <div>
   <div id="mainconbox">
     <a href="../Publish/ModifyCarveOutTest.aspx?id=2396982&type=1">修改</a>
    </div>
    </div>
    </form>
</body>
</html>
