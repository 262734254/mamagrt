<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" ResponseEncoding="GB2312"
    AutoEventWireup="true" CodeFile="MemberPwdModify.aspx.cs" Inherits="Register_MemberPwdModify" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<style type="text/css">
        body{text-align:center;}
        .content{width:466px;height:300px;background:url(images/search_bg_03.jpg) no-repeat left top;margin:300px auto 0;text-align:center;padding-top:100px;}
        .content p{line-height:30px;        }
        </style>
        <link href="../css/memberdata.css" rel="stylesheet" type="text/css" />
   <link href="../css/memberdata.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function yjhkk() {
          
     
            if (document.getElementById("ctl00_ContentPlaceHolder1_txtOldPwd").value =="") {

                alert('密码不能为空！');
                document.getElementById("ctl00_ContentPlaceHolder1_txtOldPwd").focus();
                 return  false;
            }
            else
            {
            if (document.getElementById("ctl00_ContentPlaceHolder1_txtOldPwd").value.length<6) {

                alert('密码不能少于6位数！');
                document.getElementById("ctl00_ContentPlaceHolder1_txtOldPwd").focus();
                 return  false;
            }
            }

            
           if (document.getElementById("ctl00_ContentPlaceHolder1_txtNewPwd").value=="") {

                alert('请输入新密码！');
                document.getElementById("ctl00_ContentPlaceHolder1_txtNewPwd").focus();
               return  false;
            }
               else
            {
            if (document.getElementById("ctl00_ContentPlaceHolder1_txtNewPwd").value.length<6) {

                alert('新密码不能少于6位数！');
                document.getElementById("ctl00_ContentPlaceHolder1_txtNewPwd").focus();
                 return  false;
            }
            }
            
              if (document.getElementById("ctl00_ContentPlaceHolder1_txtConfirmPwd").value=="") {

                alert('确认密码不能为空！');
                document.getElementById("ctl00_ContentPlaceHolder1_txtConfirmPwd").focus();
              return  false;
            }
               else
            {
            if (document.getElementById("ctl00_ContentPlaceHolder1_txtConfirmPwd").value.length<6) {

                alert('确认密码不能少于6位数！');
                document.getElementById("ctl00_ContentPlaceHolder1_txtConfirmPwd").focus();
                 return  false;
            }
            }
            if (document.getElementById("ctl00_ContentPlaceHolder1_txtNewPwd").value != document.getElementById("ctl00_ContentPlaceHolder1_txtConfirmPwd").value) {
                alert("两次密码不相同,请重新输入!");
                document.getElementById("ctl00_ContentPlaceHolder1_txtNewPwd").focus();
                return  false;
              
            }
                 if (document.getElementById("ctl00_ContentPlaceHolder1_txtOldPwd").value ==document.getElementById("ctl00_ContentPlaceHolder1_txtNewPwd").value)
          
          {
          alert('新密码不能与旧密码相同！');
                document.getElementById("ctl00_ContentPlaceHolder1_txtNewPwd").focus();
                 return  false;
          }
            
            document.getElementById("imgLoding2").style.display = "block";
 

  
            
        }
    </script>
    <div id="mainconbox">
        <div class="titled">
            <div class="left">
                修改密码
            </div>
            <div class="right" style="margin-bottom:13px;">
<img src="http://member.topfo.com/images/hand_1_2.gif" /> <a href="http://www.topfo.com/help/register.shtml#15" target="_blank">如何设置安全密码</a></div>
            <div class="clear">
            </div>
        </div>
       
        <table border="0" cellpadding="0" cellspacing="0" class="tabbiank">
            <tr>
                <td align="right" bgcolor="#F7F7F7" style="width: 163px">
                    <strong>您的旧密码：</strong></td>
                <td>
                    <label>
                        <asp:TextBox ID="txtOldPwd" runat="server" TextMode="Password" Width="175px"></asp:TextBox><asp:RequiredFieldValidator
                            ID="rfvOldPwd" runat="server" ControlToValidate="txtOldPwd" ErrorMessage="密码不能为空"></asp:RequiredFieldValidator><asp:RegularExpressionValidator
                                ID="revOldPwd" runat="server" ControlToValidate="txtOldPwd" ErrorMessage="密码不能少于六位"
                                ValidationExpression="^[a-zA-Z0-9]\w{5,17}$"></asp:RegularExpressionValidator></label></td>
            </tr>
            <tr>
                <td align="right" bgcolor="#F7F7F7" style="width: 163px">
                    <strong>请输入您的新密码：</strong></td>
                <td>
                    <span class="hui">
                        <asp:TextBox ID="txtNewPwd" runat="server" TextMode="Password" Width="178px" MaxLength="20"></asp:TextBox><asp:RequiredFieldValidator
                            ID="rfvNewPwd" runat="server" ControlToValidate="txtNewPwd" ErrorMessage="密码不能为空"></asp:RequiredFieldValidator><asp:RegularExpressionValidator
                                ID="revNewPwd" runat="server" ControlToValidate="txtNewPwd" ErrorMessage="密码不能少于六位"
                                ValidationExpression="^[a-zA-Z0-9]\w{5,17}$"></asp:RegularExpressionValidator><br />
                        6-20位,区分大小写, 不能与用户名相同；建议为英文字母(a-z)和数字(0-9)结合,便于记忆,不易被猜出.</span></td>
            </tr>
            <tr>
                <td align="right" bgcolor="#F7F7F7" style="width: 163px">
                    <strong>确认您的新密码：</strong></td>
                <td>
                    <asp:TextBox ID="txtConfirmPwd" runat="server" TextMode="Password" Width="175px" MaxLength="20"></asp:TextBox><span
                        class="hui">请再输入一遍您的新密码<asp:CompareValidator ID="cpvComfirmPwd" runat="server" ControlToCompare="txtNewPwd"
                            ControlToValidate="txtConfirmPwd" ErrorMessage="两次输入的密码不一致"></asp:CompareValidator><asp:RequiredFieldValidator
                                ID="rfvConfirmPwd" runat="server" ControlToValidate="txtConfirmPwd" ErrorMessage="确认密码不能为空"></asp:RequiredFieldValidator></span></td>
            </tr>
        </table>
        <div class="mbbuttom">
            <p>
                <asp:Button ID="btnModifyPwd" runat="server" Height="22" OnClientClick=" return yjhkk();" OnClick="btnModifyPwd_Click"
                    Style="padding-top: 1px" Text="修改密码" Width="70" />
                &nbsp;<label>
                    <asp:Button ID="btClear" runat="server" Text="重  置" OnClick="btClear_Click" /></label></p>
               
        </div>
    </div>
    <div id="imgLoding2" Style="position: absolute; 
   display:none; background-color: #A9A9A9; 
  top: 0px; left: 0px; width: 100%;
   height:1000px; filter: 
   alpha(opacity=60);">

               <div class="content">
                <p>
                    数据正在提交,请稍候...</p>
                <img src="../images/loading42.gif" alt="Loading" />
                </div>
   </div> 
</asp:Content>
