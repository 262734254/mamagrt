<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Test2.aspx.cs" Inherits="Register_Test2" %>

<%@ Register Src="~/Controls/ZoneSelectControl.ascx" TagName="ZoneSelectControl" TagPrefix="uc1" %>
<%@ Register Src="Control/FileUploader.ascx" TagName="FileUploader" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<link href="http://img2.topfo.com/member/css/common.css" rel="stylesheet" type="text/css" />
<link href="http://img2.topfo.com/member/css/frist-page.css" rel="stylesheet" type="text/css" />
<link href="http://img2.topfo.com/member/css/payment.css" rel="stylesheet" type="text/css" />
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="mainconbox">

        <!--联系方式 -->
        <table width="100%"  cellpadding="0" cellspacing="0"  class="publica">
            <tr>
                <td colspan="2" style="height:35px;vertical-align:top">&nbsp;&nbsp;<strong style="font-size:large">会员基本信息</strong>&nbsp;<span style="color:#c7c7c7">(不可修改)</span></td>
            </tr>
            <tr>
                <td style="width: 141px">
                    <span class="hong">*</span> <strong>用户名：</strong></td>
                <td >
                    <span class="chengcu">
                        <asp:Label ID="lbLoginName" runat="server" Text="uren812131125 "></asp:Label></span></td>
            </tr>
            <tr>
                <td style="width: 141px">
                    <span class="hong">*</span> <strong>会员身份：</strong></td>
                <td >
                    <span class="chengcu">
                        <asp:Label ID="lbManageType" runat="server"></asp:Label></span></td>
            </tr>
            <tr>
                <td style="width: 141px" >
                   <span class="hong">*</span> <strong>昵 称：</strong></td>
                <td >
                    <span>
                        <asp:TextBox ID="txtNickName" runat="server"></asp:TextBox></span></td>   
            </tr>
            <tr>
                <td style="width: 141px" >
                    <span class="hong">*</span> <strong>公司名称：</strong></td>
                <td style="height: 26px" >
                    <asp:TextBox ID="txtCompany" runat="server" Width="176px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 141px">
                    <span class="hong">*</span> <strong>所在地：</strong></td>
                <td >
                     <uc1:ZoneSelectControl ID="ZoneSelectControl1" runat="server" />
                </td>
            </tr>
            <tr>
                <td style="width: 141px">
                    <span class="hong">*</span> <strong>联系人姓名：</strong></td>
                <td>
                    <asp:TextBox ID="txtContactName" runat="server" Width="176px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 141px">
                    <span class="hong">*</span> <strong>职位：</strong></td>
                <td>
                    <asp:TextBox ID="txtContactTitle" runat="server" Width="176px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 141px">
                    <span class="hong">*</span> <strong>固定电话：</strong></td>
                <td valign="top" >  
                    <asp:TextBox ID="txtTelCountry" runat="server" size="4">+86</asp:TextBox>
                    <asp:TextBox ID="txtTelZoneCode" runat="server" size="7"></asp:TextBox>
                    <asp:TextBox ID="txtTelNumber" runat="server" size="18"></asp:TextBox>
                    <span class="hui">(如：（86-0755-82210116）</span></td>
            </tr>
            <tr>
                <td style="height: 40px; width: 141px;">
                    <strong>手 机：</strong></td>
                <td style="height: 40px" >
                    <asp:TextBox ID="txtMobile" runat="server" Width="176px"></asp:TextBox>
                    </td>
            </tr>
            <tr>
                <td style="width: 141px">
                    <span class="hong">*</span> <strong>电子邮箱：</strong></td>
              <td >
                    <asp:TextBox ID="txtEmail" runat="server" size="18" Width="176px"></asp:TextBox>
                  &nbsp;
                    <br />
                  <span class="hui">请填写您最常用的电子邮箱。如果您还没有，推荐您使用中国招商投资网的免费邮箱。</span></td>
            </tr><!--
            <tr>
                <td align="right" bgcolor="#F7F7F7" style="height: 52px">
                    <strong>传 真：</strong></td>
                <td valign="top" style="width: 638px; height: 52px">
                    <ul>
                        <li class="liwai" style="width: 66px;">国家</li><li style="width: 70px;">城市区号</li><li>电话号码</li></ul>
                    <br />
                    <asp:TextBox ID="txtFaxCountry" runat="server" size="4">+86</asp:TextBox>
                    <asp:TextBox ID="txtFaxZoneCode" runat="server" size="7"></asp:TextBox>
                    <asp:TextBox ID="txtFaxNumber" runat="server" size="18"></asp:TextBox></td>
            </tr>-->
            <tr>
                <td style="width: 141px">
                        <span class="hong">*</span>  <strong>联系地址：</strong></td>
                <td >
                    <asp:TextBox ID="txtAddress" runat="server" size="18" Width="369px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 141px" >
                        <span class="hong">*</span>  <strong>邮 编：</strong></td>
                <td >
                    <asp:TextBox ID="txtPostCode" runat="server" size="18" Width="115px"></asp:TextBox>
                    </td>
            </tr>
        </table>

        <div class="mbbuttom"><!--
            <img src="../images/Application/icon_yuan.gif" width="17" height="17" style="position:relative;top:3px;" />
            <asp:HyperLink ID="hlView" runat="server" Text="预览我的会员资料" Target="_blank"></asp:HyperLink><br />-->
          <p style="text-align:center">
               <asp:ImageButton ID="IbtnSubmit"  ImageUrl="http://img2.topfo.com/member/images/member-btn-tj.jpg" runat="server"
                OnClick="IbtnSubmit_Click"  />
            </p>
        </div>
    </div>
                 
 <%-- <div id="imgLoding" Style="position: absolute; 
  display:none; background-color: #A9A9A9; 
  top: 0px; left: 0px; width: 100%;
   height:1500px; filter: 
   alpha(opacity=60);">

               <div class="content">
                <p>
                    数据正在提交,请稍候...</p>
                <img src="../images/loading42.gif" alt="Loading" />
                </div>
   </div>   --%>

 <script language="javascript" type="text/javascript">
		  function $(id)
        {
            return document.getElementById(id);
        }
	  function CheckForm(){
	   
//	      if (document.getElementById("ctl00_ContentPlaceHolder1_txtCompany").value == "") {
//                alert('请输入招商机构名称！');
//                document.getElementById("ctl00_ContentPlaceHolder1_txtCompany").focus();
//                return false;
//            }
             if (document.getElementById("ctl00_ContentPlaceHolder1_txtContactName").value == "") {
                alert('请输入联系人姓名！');
                document.getElementById("ctl00_ContentPlaceHolder1_txtContactName").focus();
                return false;
            }
             if (document.getElementById("ctl00_ContentPlaceHolder1_txtContactTitle").value == "") {
                alert('请输入职位名称！');
                document.getElementById("ctl00_ContentPlaceHolder1_txtContactTitle").focus();
                return false;
            }
//             if (document.getElementById("ctl00_ContentPlaceHolder1_txtCompany").value == "") {
//                alert('请输入招商机构名称！');
//                document.getElementById("ctl00_ContentPlaceHolder1_txtCompany").focus();
//                return false;
//            }
             if (document.getElementById("ctl00_ContentPlaceHolder1_txtMobile").value =="") {
                alert('请输入手机号码！');
                document.getElementById("ctl00_ContentPlaceHolder1_txtMobile").focus();
                return false;
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
		
    </script>
    </form>
</body>
</html>
