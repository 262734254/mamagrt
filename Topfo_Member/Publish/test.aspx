<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="Publish_test" %>

<%@ Register Src="../Controls/ZoneSelectControl.ascx" TagName="ZoneSelectControl"
    TagPrefix="uc1" %>
  <style type="text/css">
        body{text-align:center;}
        .content{width:466px;height:300px;background:url(images/search_bg_03.jpg) no-repeat left top;margin:300px auto 0;text-align:center;padding-top:200px;}
        .content p{line-height:30px;        }
        
    </style>
    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <!--融资发布 -->
    <div class="mainconbox">
        <div class="titled">
            <div class="left">
                修改联系信息
            </div>
            <div class="clear">
            </div>
        </div>
        <!-- -->
        <div class="suggestbox allxian lightc">
            您的联系信息是对口合作方非常关注的，填写的内容务必真实、详细，否则可能失去合作方对您的信任！<br />
            <a href="#"></a>
            <asp:HyperLink ID="HyperLink1" runat="server" Target="_blank">预览您的会员资料</asp:HyperLink></div>
        <div class="blank20">
        </div>
        <!--联系方式 -->
        <table border="1" cellpadding="0" cellspacing="0" class="tabbiank">
            <tr>
                <td colspan="2" style="height:35px;vertical-align:top">&nbsp;&nbsp;<strong style="font-size:large">会员基本信息</strong>&nbsp;<span style="color:#c7c7c7">(不可修改)</span></td>
            </tr>
            <tr>
                <td width="124" align="right" bgcolor="#F7F7F7">
                    <span class="hong">*</span> <strong>用户名：</strong></td>
                <td >
                    <span class="chengcu">
                        <asp:Label ID="lbLoginName" runat="server" Text="uren812131125 "></asp:Label></span></td>
            </tr>
            <tr>
                <td align="right" bgcolor="#F7F7F7">
                    <span class="hong">*</span> <strong>会员身份：</strong></td>
                <td >
                    <span class="chengcu">
                        <asp:Label ID="lbManageType" runat="server">政府招商会员</asp:Label></span></td>
            </tr>
            <tr>
                <td align="right" valign="top" bgcolor="#F7F7F7">
                   <span class="hong">*</span> <strong>昵 称：</strong></td>
                <td>
                    <span class="chengcu">
                        <asp:Label ID="lbNickName" runat="server" ></asp:Label>
                     </span>
                </td>   
            </tr>
            <tr>
                <td colspan="2" style="height:35px;vertical-align:bottom">&nbsp;&nbsp;<strong style="font-size:large">项目方信息</strong>&nbsp;<span style="color:#c7c7c7">(可修改)</span></td>
            </tr>
            <tr>
                <td align="right" bgcolor="#F7F7F7" style="height: 26px">
                    <span class="hong">*</span> <strong>招商机构名称：</strong></td>
                <td style="height: 26px" >
                    <asp:TextBox ID="txtCompany" runat="server" Width="176px"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right" bgcolor="#F7F7F7">
                    <span class="hong">*</span> <strong>所在地：</strong></td>
                <td >
                     <uc1:ZoneSelectControl ID="ZoneSelectControl1" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="right" bgcolor="#F7F7F7">
                    <span class="hong">*</span> <strong>联系人姓名：</strong></td>
                <td>
                    <asp:TextBox ID="txtContactName" runat="server" Width="176px"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right" bgcolor="#F7F7F7" >
                    <span class="hong">*</span> <strong>职位：</strong></td>
                <td valign="top" >
                    <asp:TextBox ID="txtContactTitle" runat="server" Width="176px"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right" bgcolor="#F7F7F7">
                    <span class="hong">*</span> <strong>固定电话：</strong></td>
                <td valign="top" >
                    <ul>
                        <li class="liwai" style="width: 66px;">国家</li><li style="width: 70px;">城市区号</li><li>电话号码</li></ul>
                    <br />
                    <asp:TextBox ID="txtTelCountry" runat="server" size="4">+86</asp:TextBox>
                    <asp:TextBox ID="txtTelZoneCode" runat="server" size="7"></asp:TextBox>
                    <asp:TextBox ID="txtTelNumber" runat="server" size="18"></asp:TextBox>
                    <span class="hui">如果要输入多个号码，请使用&quot;,&quot;分隔；分机号码用&quot;－&quot;分隔</span>&nbsp;<br />
                        </td>
            </tr>
            <tr>
                <td align="right" bgcolor="#F7F7F7" >
                    <strong>手 机：</strong></td>
                <td style="width: 638px; height: 33px;">
                    <asp:TextBox ID="txtMobile" runat="server" Width="176px"></asp:TextBox>
                    </td>
            </tr>
            <tr>
                <td align="right" valign="top" bgcolor="#F7F7F7">
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
                <td align="right" bgcolor="#F7F7F7" >
                    <strong>联系地址：</strong></td>
                <td >
                    <asp:TextBox ID="txtAddress" runat="server" size="18" Width="369px"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right" bgcolor="#F7F7F7" >
                    <strong>邮 编：</strong></td>
                <td >
                    <asp:TextBox ID="txtPostCode" runat="server" size="18" Width="115px"></asp:TextBox>
                    </td>
            </tr>
        </table>
        <div class="blank0">
        </div>
        <div>
            &nbsp;<asp:CheckBox ID="CheckBox1" runat="server" Checked="True" Text="是否愿意接收本站邮件通知" /></div>
        <div class="mbbuttom"><!--
            <img src="../images/Application/icon_yuan.gif" width="17" height="17" style="position:relative;top:3px;" />
            <asp:HyperLink ID="hlView" runat="server" Text="预览我的会员资料" Target="_blank"></asp:HyperLink><br />-->
            <p style="text-align:center">
                &nbsp;<asp:Button ID="btnOk" runat="server" CausesValidation="False" Height="22"
                    Style="padding-top: 1px" Text="确  认" Width="50" OnClick="btnOk_Click" OnClientClick="return CheckForm();" /><label>
                    </label>
            </p>
        </div>
    </div>

    <script type="text/javascript">	
        function $(id)
        {
            return document.getElementById(id);
        }
       
        function CheckForm(){
            if($("txtCompany").value==""){alert('招商机构不能为空.');$("txtCompany").focus();return false;}
            if($("txtContactName").value==""){alert('请输入联系人姓名.');$("txtCompany").focus();return false;}
            if($("txtMobile").value==""){alert('手机号码不能为空.');$("txtCompany").focus();return false;}
            if($("txtEmail").value==""){alert('电子邮箱输入不正确.');$("txtCompany").focus();return false;}
            if($("txtAddress").value==""){alert('联系地址不能为空.');$("txtCompany").focus();return false;}
             var emailStr = document.getElementById("txtEmail").value;
            var emailPat=/^(.+)@(.+)$/;
            var matchArray = emailStr.match(emailPat);
            if (matchArray==null)
            {
                alert("电子邮件的格式不正确！");
                $("txtEmail").focus();
                return false;
            }
            document.getElementById("imgLoding").style.display = "block"; 
          
		}
	
    </script>
       <div id="imgLoding" Style="position: absolute;
            display:none;
            background-color: #A9A9A9; 
            top: 0px; 
            left: 0px; 
            width: 100%; 
            height: 100%; 
            filter: alpha(opacity=60);" style="position:absolute;width:100%;height:100%;display:none;background-

color:silver;">>
            <div class="content">
                <p>
                    数据正在提交,请稍候...</p>
                <img src="images/loading42.gif" alt="Loading" /></div>
        </div>        
    
    </form>
</body>
</html>
