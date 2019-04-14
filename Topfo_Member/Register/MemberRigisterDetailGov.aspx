<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MemberRigisterDetailGov.aspx.cs" Inherits="Register_MemberRigisterDetailGov"  MasterPageFile="~/MasterPage.master" %>
<%@ Register Src="~/Controls/ZoneSelectControl.ascx" TagName="ZoneSelectControl" TagPrefix="uc1" %>
<%@ Register Src="Control/FileUploader.ascx" TagName="FileUploader" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
 <style type="text/css">
       
        .llll{width:466px;height:300px;background:url(images/search_bg_03.jpg) no-repeat left top;margin:300px auto 0;text-align:center;padding-top:250px;}
  </style>


<div class="publication">
   <h1><span class="fl"><span class="f_14px strong f_cen">修改用户信息</span>(带<span class="hong">*</span>为必填项)</span><span class="fr"></span></h1>
        <!--联系方式 -->
        <table width="100%"  cellpadding="0" cellspacing="0"  class="publica">
            <tr>
                <td>
                    <span class="hong">*</span> <strong>用户名：</strong></td>
                <td >
                    <span class="chengcu">
                        <asp:Label ID="lbLoginName" runat="server" Text="uren812131125 "></asp:Label></span></td>
            </tr>
            <tr>
                <td>
                    <span class="hong">*</span> <strong>会员身份：</strong></td>
                <td >
                    <span class="chengcu">
                        <asp:Label ID="lbManageType" runat="server"></asp:Label></span></td>
            </tr>
            <tr>
                <td>
                   <span class="hong">*</span> <strong>昵 称：</strong></td>
                <td >
                         <input name="txtNickName" type="text" id="txtNickName"  class="input" runat="server"/>&nbsp;<div id="div1" ></div>
                        </td>   
            </tr>
            <tr>
                <td>
                    <span class="hong">&nbsp; </span> <strong><strong>单位名称：</strong></td>
                <td >
                    <asp:TextBox ID="txtCompany" runat="server" Width="176px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <span class="hong">*</span> <strong>所在地：</strong></td>
                <td >
                     <uc1:ZoneSelectControl ID="ZoneSelectControl1" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <span class="hong">*</span> <strong>联系人姓名：</strong></td>
                <td>
                    <asp:TextBox ID="txtContactName" runat="server" Width="176px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <span class="hong">&nbsp;</span> <strong>职位：</strong></td>
                <td>
                    <asp:TextBox ID="txtContactTitle" runat="server" Width="176px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <span class="hong">*</span> <strong>固定电话：</strong></td>
                <td valign="top" >  
                    <asp:TextBox ID="txtTelCountry" runat="server" size="4" onkeyup="value=value.replace(/[^\d]/g,'') " MaxLength="3">+86</asp:TextBox>
                    <asp:TextBox ID="txtTelZoneCode" runat="server" size="7" onkeyup="value=value.replace(/[^\d]/g,'') " MaxLength="5"></asp:TextBox>
                    <asp:TextBox ID="txtTelNumber" runat="server" size="18" onkeyup="value=value.replace(/[^\d]/g,'') " MaxLength="8"></asp:TextBox>
                    <span class="hui">(如：（86-0755-89805588）</span></td>
            </tr>
            <tr>
                <td>
                    <strong>&nbsp; 手 机：</strong></td>
                <td>
                    <asp:TextBox ID="txtMobile" runat="server" Width="176px"></asp:TextBox>
                    （手机号码和电话号码必须填写一个）</td>
            </tr>
            <tr>
                <td>
                    <span class="hong">*</span> <strong>电子邮箱：</strong></td>
              <td >
                    <asp:TextBox ID="txtEmail" runat="server" size="18" Width="176px"></asp:TextBox>
                  &nbsp;
                    <br />
                  <span class="hui">请填写您最常用的电子邮箱。如果您还没有，推荐您使用中国招商投资网的免费邮箱。</span></td>
            </tr>
            <tr>
                <td>
                        <span class="hong">*</span>  <strong>联系地址：</strong></td>
                <td >
                    <asp:TextBox ID="txtAddress" runat="server" size="18" Width="369px"></asp:TextBox></td>
            </tr>
            <tr>
                <td >
                         <span class="hong">&nbsp;</span> <strong>邮 编：</strong></td>
                <td >
                    <asp:TextBox ID="txtPostCode" runat="server" size="18" onkeyup="value=value.replace(/[^\d]/g,'') " Width="115px"></asp:TextBox>
                    </td>
            </tr>
        </table>

        <div class="mbbuttom"><!--
            <img src="../images/Application/icon_yuan.gif" width="17" height="17" style="position:relative;top:3px;" />
            <asp:HyperLink ID="hlView" runat="server" Text="预览我的会员资料" Target="_blank"></asp:HyperLink><br />-->
          <p style="text-align:center">
               <asp:ImageButton ID="IbtnSubmit" OnClientClick=" return CheckForm();"  ImageUrl="http://img2.topfo.com/member/images/member-btn-tj.jpg" runat="server"
                OnClick="IbtnSubmit_Click"  />
            </p>
        </div>
    </div>
                 
<div id="imgLoding" Style="position: absolute; 
  display:none; background-color: #A9A9A9; 
  top: -11px; left: 19px; width: 123%;
   height:1500px; filter: 
   alpha(opacity=60);">

               <div class="llll">
                <p>
                    数据正在提交,请稍候...</p>
                <img src="../images/loading42.gif" alt="Loading" />
                </div>
   </div>

 <script language="javascript" type="text/javascript">
		  function $(id)
        {
            return document.getElementById(id);
        }
	  function CheckForm(){
	   
	      if (document.getElementById("ctl00_ContentPlaceHolder1_txtNickName").value == "") {
                alert('请输入昵称！');
                document.getElementById("ctl00_ContentPlaceHolder1_txtNickName").focus();
                return false;
            }
             if (document.getElementById("ctl00_ContentPlaceHolder1_txtContactName").value == "") {
                alert('请输入联系人姓名！');
                document.getElementById("ctl00_ContentPlaceHolder1_txtContactName").focus();
                return false;
            }
            
           

            //电话号码
            var telzone = document.getElementById("ctl00_ContentPlaceHolder1_txtTelZoneCode");
            var telNumber=document.getElementById("ctl00_ContentPlaceHolder1_txtTelNumber");
           //手机号码
            var telMobile=document.getElementById("ctl00_ContentPlaceHolder1_txtMobile");
           if(telNumber.value=="" && telMobile.value=="")
        
            {
              alert("手机和固定电话请至少填写一项");
                 telMobile.focus();
                return false;
            
            }
          
          if(telMobile.value!="")
          {
                var filtMobile = /^(13|15|18)[0-9]{9}$/;
                if(!filtMobile.test(trim(telMobile.value)))
                {
                    alert("请正确填写手机号码");
                    telMobile.focus();
                    return false;
                }
            }
              if (document.getElementById("ctl00_ContentPlaceHolder1_txtEmail").value == "") {
                alert('请输入电子邮箱！');
                document.getElementById("ctl00_ContentPlaceHolder1_txtEmail").focus();
                return false;
            }
            if (document.getElementById("ctl00_ContentPlaceHolder1_txtAddress").value == "") {
                alert('请输入联系地址！');
                document.getElementById("ctl00_ContentPlaceHolder1_txtAddress").focus();
                return false;
            }

            var emailStr = document.getElementById("ctl00_ContentPlaceHolder1_txtEmail").value;
            if (emailStr!="")
          {
            var emailPat=/^(.+)@(.+)$/;
            if (!emailPat.test(emailStr))
             { 
                alert("邮箱填写不正确!");
			    document.getElementById("ctl00_ContentPlaceHolder1_txtEmail").focus();
                return false;
             }
                
           }

		    document.getElementById("imgLoding").style.display = "block";

      }
  //////////////////////
//去除字符串两边空格的函数
//参数：mystr传入的字符串
//返回：字符串mystr
function trim(mystr){
while ((mystr.indexOf(" ")==0) && (mystr.length>1)){
mystr=mystr.substring(1,mystr.length);
}//去除前面空格
while ((mystr.lastIndexOf(" ")==mystr.length-1)&&(mystr.length>1)){
mystr=mystr.substring(0,mystr.length-1);
}//去除后面空格
if (mystr==" "){
mystr="";
}
return mystr;
}
		
    </script>


</asp:Content>
