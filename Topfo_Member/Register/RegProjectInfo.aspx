<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RegProjectInfo.aspx.cs" Inherits="Register_RegProjectInfo" %>

<%@ Register Src="../Controls/ZoneSelectControl.ascx" TagName="ZoneSelectControl"
    TagPrefix="uc3" %>
<%@ Register Src="Control/Header.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="Control/Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>填写基本信息－－个人会员</title>
    <link href="../css/jiben.css" rel="stylesheet" type="text/css" />
    
</head>

<body>
    <uc1:Header ID="Header1" runat="server" />
    <div class="mainnav">
        <ul>
            <li>1．选择会员身份</li>
            <li class="up">2．填写基本信息</li>
            <li>3．注册成功 </li>
        </ul>
    </div>
    <form id="frm" method="post" runat="server" action="RegProjectInfo.aspx">
    <input type="hidden" id="showId" runat="server" name="showId" />
        <div class="content">
            <div class="content_top">
                <div class="clew">
                    <h4>
                        您选择的会员身份是<font color="#FF6600">项目方</font>！</h4>
                    <br />
                    注册后您可以发布项目融资需求/产品供求信息、加入公司黄页、查询投资资源等。 <a href="Register.aspx">重新选择会员类型</a>
                </div>
            </div>
            <div class="line_text">
                <div class="ltxt">
                    帐户基本信息</div>
                <div class="rtxt">
                    以下内容全为必填项</div>
            </div>
            <table width="0" border="0" cellpadding="0" cellspacing="0" class="inputtable">
                <tr>
                    <td class="t_title">
                        会员登录名：</td>
                    <td align="left">
                        <input name="usrname" maxlength="16" id="usrname" type="text" runat="server" /></td>
                    <td align="left">
                        <div class="commonly" id="nameinfo">
                            会员登陆名由4-16个英文字母、数字、下划线组成，不区分大小写。登录名不能修改，请谨慎填写。</div>
                    </td>
                </tr>
                <tr>
                    <td class="t_title">
                        昵称：</td>
                    <td align="left">
                        <input name="nikename" id="nikename" maxlength="14" type="text" /></td>
                    <td align="left">
                        <div class="commonly" id="nikeinfo">
                            昵称可填写中文，不超过14个字符，请使用您的单位名作为您的昵称，如“中国招商投资网”</div>
                    </td>
                </tr>
                <tr>
                    <td class="t_title">
                        密码：</td>
                    <td align="left">
                        <input name="pwd" id="pwd" type="password" /></td>
                    <td align="left">
                        <div class="commonly" id="pwdinfo">
                            由6-20个英文字母或数字组成</div>
                    </td>
                </tr>
                <tr>
                    <td class="t_title">
                        重复输入密码：</td>
                    <td align="left">
                        <input name="repwd" id="repwd" type="password" /></td>
                    <td align="left">
                        <div class="commonly" id="repwdinfo">
                            请再输入一遍您上面填写的密码</div>
                    </td>
                </tr>
            </table>
            <div class="line_text">
                <div class="ltxt">
                    项目方信息</div>
                <div class="rtxt">
                    手机和固定电话请至少填写一项</div>
            </div>
            <div class="fon_t">
                <table width="742" border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td class="t_title">
                            项目方类型：</td>
                        <td align="left">
                            <input type="radio" checked="checked" name="propertyid" value="0" />
                            融资企业
                            <input type="radio" name="propertyid" value="1" />
                            个人创业者</td>
                    </tr>
                </table>
            </div>
            <table width="748" border="0" cellpadding="0" cellspacing="0" class="inputtable noborder">
                <tr>
                    <td width="115" align="right" class="t_title">
                        贵公司名称：</td>
                    <td width="250" align="left">
                        <input id="company" name="company" type="text" /></td>
                    <td width="383" align="left">
                        <div class="commonly" id="companyinfo">
                            请填写工商局注册的企业完整名称</div>
                    </td>
                </tr>
                <tr>
                    <td class="t_title">
                        公司所在地：</td>
                    <td colspan="2" align="left">
                        <uc3:ZoneSelectControl ID="ZoneSelectControl1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="t_title">
                        联系人真实姓名：</td>
                    <td align="left" style="width: 250px">
                        <input id="contactname" name="contactname" type="text" />
                    </td>
                    <td align="left">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="t_title">
                        联系人职位：</td>
                    <td align="left" style="width: 250px">
                        <input id="contacttitle" name="contacttitle" type="text" />
                    </td>
                    <td align="left">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="t_title">
                        固定电话：</td>
                    <td align="left" style="width: 250px;">
                        <menu class="menulw">
                            国家</menu>
                        <menu>
                            城市区号</menu>
                        <menu class="menulw3">
                            电话号码</menu>
                        <br />
                        <input name="country" id="country" type="text" value="86" size="4" class="country" />
                        <input name="zone" id="zone" type="text" size="7" class="area">
                        <input name="phone" id="phone" type="text" size="18" class="phone" />
                    </td>
                    <td align="left">
                        <div class="commonly" id="phoneinfo">
                            如果要输入多个电话号码,请使用“/”分隔，分机号码用“-”分隔。</div>
                        <span id="zoneinfo"></span>
                    </td>
                </tr>
                <tr>
                    <td class="t_title">
                        手机：</td>
                    <td align="left" style="width: 250px">
                        <input name="mobile" id="mobile" type="text" />
                    </td>
                    <td align="left">
                        <div class="commonly" id="mobileinfo">
                            手机和固定电话请至少填写一项</div>
                    </td>
                </tr>
            </table>
            <table width="0" border="0" cellpadding="0" cellspacing="0" class="inputtable noborder">
                <tr>
                    <td class="t_title">
                        电子邮箱：</td>
                    <td align="left">
                        <input name="email" id="email" type="text" /></td>
                    <td align="left">
                        <div class="commonly" id="emailinfo">
                            请填写您最常用的邮箱，这是客户联系您的重要方式。 如果您没有邮箱，<a href="http://mail.163.com" target="_blank">注册网易邮箱</a>
                            <a href="http://mail.yahoo.com.cn" target="_blank">注册雅虎邮箱</a></div>
                    </td>
                </tr>
                <tr>
                    <td class="t_title">
                        邀请人：</td>
                    <td align="left">
                        <input name="invite" id="invite" value="<%=introStr %>" /></td>
                    <td align="left">
                        <div class="commonly" id="inviteinfo">
                            填写邀请您注册的朋友昵称，如果没有则可不填</div>
                    </td>
                </tr>
                <tr>
                    <td class="t_title">
                        验证码：</td>
                    <td align="left">
                        <input name="vercode" maxlength="5" id="vercode" runat="server" type="text" /></td>
                    <td align="left">
                        <div class="commonly">
                            验证码不区分大小写<br />
                            <img alt="验证码" src="../ValidateNumber.aspx" width="73" height="25" align="middle"
                                id="validimg" />
                            <a href="javascript:" onclick="ChangeValidCode('validimg');return false;">换一张图片</a><span
                                style="padding-right: 1px" id="vercodeinfo"></span><span id="spanID" ></span></div>
                    </td>
                </tr>
            </table>
            <div class="submit">
                <p align="left">
                    <input name="checkbox" checked="checked" type="checkbox" id="protocal" value="checkbox" />
                    我已阅读并同意<a href="http://www.topfo.com/Register/AgreeMent.shtml" target="_blank">《中国招商投资网服务协议》</a><span
                        id="protocalinfo"></span></p>
                <p align="left">
                    <input name="checkbox" type="checkbox" value="checkbox" checked="checked" />
                    我愿意接收来自中国招商投资网的通知和消息（包括《中国招商投资网·电子杂志》等）</p>
                <%--<asp:ImageButton ID="ImageButton1" ImageUrl="../images/btn_tijiao.gif" runat="server"
                    OnClick="ImageButton1_Click" />--%>
                    <input type="image" name="ImageButton1" id="ImageButton1" src="/images/btn_tijiao.gif" onclick="return chkPost();" style="border-width:0px;" />
                <uc2:Footer ID="Footer1" runat="server" />
            </div>
        </div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript">

function $id(obj)
        {
           return document.getElementById(obj);
        }
        function chkPost()
        {
            if($id("usrname").value==""){alert("请填写账户名称.");$id("usrname").focus();return false;}
            if($id("nikename").value==""){alert("请填写昵称.");$id("nikename").focus();return false;}
            if($id("pwd").value==""){alert("请填写密码.");$id("pwd").focus();return false;}
            if($id("repwd").value !=$id("pwd").value)
            {
               alert("两次密码输入不一致");
               $id("repwd").focus();
               return false;
            }
            if(($id("zone").value=="" & $id("phone").value=="") & $id("mobile").value=="" )
            {
                alert("手机和固定电话请至少填写一项");
                 $id("mobile").focus();
                return false;
            }
            if($id("email").value=="")
            {
            alert('请填写电子邮箱.');
            $id("email").focus();
            return false;
            }else
            {
               var filter = /^[_a-zA-Z0-9\-]+(\.[_a-zA-Z0-9\-]*)*@[a-zA-Z0-9\-]+([\.][a-zA-Z0-9\-]+)+$/;
               if(!filter.test($id("email").value))
               {
                 alert("电子邮件格式不正确，请输入正确的电子邮件地址！");
                 $id("email").focus();
                 return false;
               }
            }
            if($id("vercode").value==""){alert('请填写验证码.');$id("vercode").focus();return false;}
        }
        
    function cc()
    {
//    alert("sssssssssss");
        var show=document.getElementById("showId").value;
        var ver=document.getElementById("vercode").value;
        alert(show);
        alert(ver);
        if(show !=ver)
        {
            document.getElementById("spanID").innerHTML="请输入正确的验证码";
            document.getElementById("vercode").focus();
        }else
        {
            document.getElementById("spanID").innerHTML="";
        }
    }
    
         
        </script>

<script src="../js/commonReg.js" language="javascript" type="text/javascript"></script>

<script src="../js/Ajax.js" language="javascript" type="text/javascript"></script>

