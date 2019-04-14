<%@ Page Language="C#" EnableEventValidation=false AutoEventWireup="true" CodeFile="VIPMemberRegister.aspx.cs"
    Inherits="Register_TTMemberRegister" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>拓富通会员申请-拓富·中国招商投资网</title>
    <link href="../css/common.css" rel="stylesheet" type="text/css" />
    <link href="../css/application.css" rel="stylesheet" type="text/css" />
	<style type="text/css">
<!--
.hright .shang .liwai2{
	background-color: #FFFFFF;
	color: #FF6600;
	font-size: 16px;
	border-bottom-style: none;
	line-height: 29px;
	margin-top: 0px;
	height: 32px;
	border-left-width: 1px;
	border-left-style: solid;
	border-left-color: #D6D6D6;}
.hright .shang .liwai2 A:link,.hright .shang .liwai2 A:visited,.hright .shang .liwai2 A:active,.hright .shang .liwai2 A:hover {color:#FF6600; text-decoration:none;}
.gtext {
	font-size: 12px;
	color: #25970b;
}
-->
</style>
</head>
<body onload="init()">
    <form runat="server" onsubmit ="return CheckSubmit()">
      <!--#include file="../common/appleft.html"-->
      <div class="blank20">
      </div>
        <div class="processbox">
            <h1>
                <img src="../images/Application/zi_001.gif" alt="拓富通会员申请流程" width="195" height="33" /></h1>
            <div class="right" >
                申请成为拓富通会员，让您成功的机会比普通会员提高<span class="chengcu" style="font-size:25px">12</span>倍！</div>
				<div class="clear"></div>
        </div>
        <div class="blank20">
        </div>
      <div class="suggestbox">
            <h1>
                <img src="../images/icon_yb.gif" width="17" height="17" align="absmiddle" />
                重要提示</h1>
           <p> 1.带 <span class="hong">* </span>为必填项；为了充分保障您的各项权益，请您填写真实完整地信息！<br />
          2.为了保证拓富通会员的权益，中国招商投资网所有拓富通会员都是通过我们认证中心认证通过的会员。<a href="http://www.topfo.com/topfocenter/degreeaffirm/index.shtml" target="_blank" class="lanlink"> 先了解一下拓富通认证服务</a></p>
      </div>
        <div class="blank20">
        </div>
        <div class="fillbox">
            <div class="c" id="cbAcceptbox">
                <div class="trbox">
                    <div class="tdleft">
                        <img src="../images/Application/icon_right.gif" /><span class="hong">*</span> 会员类型：</div>
                    <div class="tdcenter">
                        &nbsp;<input id="radioManageType1" name="ManageType" type="radio" value="2003" runat="server"
                            onclick="changeManageType(2003)"  checked>项目方<input id="radioManageType3" name="ManageType" type="radio" onclick="changeManageType(2001)"
                            value="2001" runat="server" />政府招商机构</div>
                    <div class="clear"></div>
                </div>
                <div class="trbox">
                    <div class="tdleft" style="padding-top: 7px">
                        <img src="../images/Application/icon_right.gif" /><span class="hong">*</span> 购买期限：</div>
                    <div class="tdcenter">
                        <asp:RadioButtonList ID="rblBuyTerm" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Selected="True" Value="1">一年</asp:ListItem>
                            <asp:ListItem Value="2">二年</asp:ListItem>
                            <asp:ListItem Value="3">三年</asp:ListItem>
                        </asp:RadioButtonList></div>
                    <div class="clear">
                    </div>
                </div>
                <div class="trbox" id="divOrgName">
                  <div class="tdleft">
                       
                            <img src="../images/Application/icon_right.gif" id="imgOrgName" style="display: none" /> <span class="hong">*</span>
                        <asp:Label ID="lbOrgName" runat="server" Text="公司名称："></asp:Label>
                  </div>
                    <div class="tdcenter">
                        <asp:TextBox ID="tbOrgName" runat="server" Height="15px" Width="220px" onfocus="changetype1(rem1)"
                            onblur="CheckItem(1,'OrgName',rem1);"></asp:TextBox>
                    </div>
                    <div class="" id="rem1">
                        &nbsp; &nbsp;&nbsp;提醒：请按照公司营业执照上面的全称填写</div>
                    <div class="clear">
                    </div>
                </div>
                <div class="trbox">
                    <div class="tdleft">
                        <img src="../images/Application/icon_right.gif" style="display: none" id="imgRealName" /><span
                            class="hong">*</span> 真实姓名：</div>
                    <div class="tdcenter">
                        <asp:TextBox ID="tbRealName" runat="server" Height="15px" Width="158px" onfocus="changetype1(rem2)"
                            onblur="CheckItem(1,'RealName',rem2);"></asp:TextBox>
                    </div>
                    <div class="" id="rem2">
                        &nbsp; &nbsp;提醒：请填写您的真实姓名</div>
                    <div class="clear">
                    </div>
                </div>
                <div class="trbox">
                    <div class="tdleft" style="padding-top: 7px">
                        <img src="../images/Application/icon_right.gif" /><span class="hong">*</span> 性
                        别：</div>
                    <div class="tdcenter" >
                        <asp:RadioButtonList ID="rblSex" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Selected="True" Value="true">男</asp:ListItem>
                            <asp:ListItem Value="false">女</asp:ListItem>
                        </asp:RadioButtonList></div>
                    <div class="clear">
                    </div>
                </div>
                <div class="trbox" id="divPosition">
                    <div class="tdleft">
                        <img src="../images/Application/icon_right.gif" style="display: none" id="imgPosition" />
                        职务：</div>
                    <div class="tdcenter">
                        <asp:TextBox ID="tbPosition" runat="server" Height="15px" Width="158px" onblur="CheckItem(1,'Position',Div1);"></asp:TextBox>
                    </div>
                    <div class="" id="Div1">
                    </div>
                    <div class="clear">
                    </div>
                </div>
                <div class="trbox">
                    <div class="tdleft" style="padding-top: 27px">
                        <img src="../images/Application/icon_right.gif" id="imgTel" style="display: none" /><span
                            class="hong">*</span> 固定电话：</div>
                    <div class="tdcenter" style="width: 251px">
                        <table width="192" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td valign="bottom" style="line-height: 150%; width: 42px;">
                                    国家</td>
                                <td valign="bottom" style="line-height: 150%; width: 52px;">
                                    城市区号</td>
                                <td width="73" valign="bottom" style="line-height: 150%">
                                    &nbsp;电话号码</td>
                            </tr>
                        </table>
                        <asp:TextBox ID="txtTelCountry" runat="server" Columns="6" MaxLength="4" Width="35px">+86</asp:TextBox>
                        <asp:TextBox ID="txtTelZoneCode" runat="server" Columns="6" MaxLength="4"></asp:TextBox>
                        <asp:TextBox ID="txtTelNumber" runat="server" Columns="15" onblur="CheckItem(1,'Tel',rem3);"></asp:TextBox>&nbsp;
                    </div>
                    <div class="" id="rem3">
                    </div>
                    <div class="clear">
                    </div>
                </div>
                <div class="trbox">
                    <div class="tdleft">
                        <img src="../images/Application/icon_right.gif" id="imgMobile" style="display: none" />手
                        机：</div>
                    <div class="tdcenter">
                        <asp:TextBox ID="txtMobile" runat="server" Width="158px" onblur="CheckItem(1,'Mobile',rem4);"></asp:TextBox></div>
                    <div class="tdrightn" id="rem4">
                    </div>
                    <div class="clear">
                    </div>
                </div>
                <div class="trbox">
                    <div class="tdleft">
                        <img src="../images/Application/icon_right.gif" id="imgEmail" style="display: none" /><span
                            class="hong">*</span> Email ：</div>
                    <div class="tdcenter">
                        <asp:TextBox ID="txtEmail" runat="server" Width="157px" onfocus="changetype1(rem5)"
                            onblur="CheckItem(1,'email',rem5);"></asp:TextBox></div>
                    <div class="" id="rem5">
                        提醒：确保为您能收到中国招商投资网的投送有助<br />
                        于您找到对口对象的信息，请填写您经常使用的电子邮箱<br />
                    </div>
                    <div class="clear">
                        &nbsp;</div>
                </div>
                <br />
            </div>
            <div class="mbbuttom">
                &nbsp;
                <img src="../images/Application/icon_yuan.gif" width="17" height="17" align="bottom" />
            <a href="http://www.topfo.com/ServiceItem/TopfoServiceItem.shtml" target="_blank" class="lanlink">点此阅读拓富通服务协议</a> <a href="http://www.topfo.com/Service/enterprisemember.shtml" target="_blank"><span class="gtext">[查看拓富通会员服务]</span></a><br />
                <br />
                &nbsp;<asp:ImageButton ID="ibOK" runat="server" ImageUrl="../images/Application/buttom_ty.gif"
                    OnClick="ibOK_Click" />
          <input id="hidManageType" style="width: 1px" type="hidden" runat="server" /></div>
      </div>
		<!--#include file="../common/allfooter.html"-->
        <asp:CustomValidator ID="cv" runat="server" ClientValidationFunction="CheckSubmit"
            ErrorMessage=""></asp:CustomValidator>
    </form>
</body>
</html>

<script type="text/javascript">
function init()
{
  var ManageType = document.getElementById("<%= hidManageType.ClientID %>");
  var str=window.location.href; 
  var es1=/ApplyID=/; 
  var typeVaule;
  if(es1.exec(str))//修改
  { 
    typeVaule=RegExp.rightContext; 
    var a =   document.getElementsByName("ManageType");   
   for(var i=0;i<a.length;i++)   
   {   
      if(a[i].value==typeVaule)
      {
        a[i].checked=true;
        break;
      }
   }
    changeManageType(typeVaule);
  }
  else//添加
  { 
    // radioManageType1.checked;
     changeManageType(2003);   
  }
    clearPage();
}
function clearPage()
{
	CheckItem(0,'OrgName',rem1);
    CheckItem(0,'RealName',rem2);
    CheckItem(0,'Tel',rem3);
    CheckItem(0,'Mobile',rem4);
    CheckItem(0,'email',rem5);
}
function changetype1(rem)
{
    rem.className = "tdright";    
}
function changetype2(rem)
{
    rem.className = "";    
}
function changeManageType(type)
{     
    var name = document.getElementById("<%= lbOrgName.ClientID %>");
    var ManageType = document.getElementById("<%= hidManageType.ClientID %>");
    if(type==2002||type==2003)
    {
       divOrgName.style.display = "";
       divPosition.style.display = "none";
       name.innerHTML = "公司名称：";
     }	
     if(type==2001)
     {
        divOrgName.style.display = "";
        divPosition.style.display = "";
        name.innerHTML = "机构名称：";
      }
      ManageType.value = type;
      clearPage();
}

//tag 是否需要验证（0：会员类型的切换，不要验证 ; 1：填写验证）
var isValid= true;
var isValid1=true;
function CheckItem(tag,type,output)
{
   var src = "";
   if(type=="OrgName")
   {
       if(tag==0)
       {
         output.innerHTML = "提醒：请按照公司营业执照上面的全称填写.";
         changetype2(output);
         document.getElementById("imgOrgName").style.display = "none";
         isValid =  false;
         isValid1 =  true;
       }
       else
       {
           src = document.getElementById("tbOrgName").value; 
           if(src =="" || src == null )
          {
             output.innerHTML = "<img src='../images/Application/icon_wrong.gif'/>名称不能为空.";	
             document.getElementById("imgOrgName").style.display = "none";			
             changetype1(output);
            
             return false;
          }	
          else
          {
             output.innerHTML = "提醒：请按照公司营业执照上面的全称填写.";
             changetype2(output);
             document.getElementById("imgOrgName").style.display = "";
             return true;
           }
       }
   }
    if(type=="RealName")
   {
      if(tag==0)
       {
        output.innerHTML = "提醒：请填写您的真实姓名.";
          changetype2(output);
          document.getElementById("imgRealName").style.display = "none";
         isValid =  false;
         isValid1 =  true;          
       }
       else
       {
           src = document.getElementById("tbRealName").value; 
           if(src =="" || src == null )
          {
             output.innerHTML = "<img src='../images/Application/icon_wrong.gif'/>姓名不能为空.";	
             document.getElementById("imgRealName").style.display = "none";			
             changetype1(output);        
            
             return false;
          }	
          else
          {
              output.innerHTML = "提醒：请填写您的真实姓名.";
              changetype2(output);
              document.getElementById("imgRealName").style.display = "";
             return true;
          }
      }
   }
   if(type=="Position")
   {
      if(tag==0)
       {
             output.innerHTML = "";
             changetype2(output);
             document.getElementById("imgPosition").style.display = "none";
             isValid =  false;
             isValid1 =  true;
       }
       else
       {
         var ManageType = document.getElementById("<%= hidManageType.ClientID %>");
         if( ManageType.value ==1004)
         {
             src = document.getElementById("tbPosition").value; 
              if(src =="" || src == null )
              {
//                 output.innerHTML = "<img src='../images/Application/icon_wrong.gif'/>职务不能为空.";	
//                 document.getElementById("imgOrgName").style.display = "none";			
//                 changetype1(output);
//                 isValid =  false;
//                 return false;
              }	
              else
              {
                 output.innerHTML = "";
                 changetype2(output);
                 document.getElementById("imgPosition").style.display = "";
                 isValid =  true;
               }
          }
      }
   }
   if(type=="Tel")
   { 
        var t1 = document.getElementById("txtTelCountry").value; 
		var t2 = document.getElementById("txtTelZoneCode").value; 
		var t3 = document.getElementById("txtTelNumber").value; 
     if(tag==0)
       {
          output.innerHTML = "";
          changetype2(output);
          document.getElementById("imgTel").style.display = "none";
           
       }
       else if(t1==""||t2==""||t3=="" )
		{
		    output.innerHTML = "<img src='../images/Application/icon_wrong.gif'/>电话号码不能为空.";	
             document.getElementById("imgTel").style.display = "none";	
             changetype1(output);	
             return false;
		}
       else 
       {   
          if (!checkTel())
          {
             output.innerHTML = "<img src='../images/Application/icon_wrong.gif'/>电话号码填写错误.";	
             document.getElementById("imgTel").style.display = "none";	
             changetype1(output);	
           
             return false;
          }
          else
          {
              output.innerHTML = "";
              changetype2(output);
              document.getElementById("imgTel").style.display = "";
              return true;
          }
      }
   }
   
     if(type=="Mobile")
   { 
     if(tag==0)
       {
        output.innerHTML = "";
          changetype2(output);
          document.getElementById("imgMobile").style.display = "none";
             isValid =  false;
             isValid1 =  true;
       }
       else
       {
           src = document.getElementById("txtMobile").value;
         
          if(src =="" || src == null ) 
          {
              output.innerHTML = "";
              changetype2(output);
              document.getElementById("imgMobile").style.display = "none";
              
              return true;
          }     
          else if (!checkMobile(src))
          {
             output.innerHTML = "<img src='../images/Application/icon_wrong.gif'/>手机填写错误.";	
             document.getElementById("imgMobile").style.display = "none";	
             changetype1(output);	
            
             return false;
          }	
          else
          {
              output.innerHTML = "";
              changetype2(output);
              document.getElementById("imgMobile").style.display = "";
              
              return true;
          }
      }
    }
   if(type=="email")
   {
   var result;
   if(tag==0)
       {
        output.innerHTML = "请务必填写真实,并确认是您最常用的电子邮件.";
         changetype2(output);
         document.getElementById("imgEmail").style.display = "none";
            result = false;
       }
       else
       {
          src = document.getElementById("txtEmail").value; 
          var objRegExp  = /^[a-z0-9]([a-z0-9_\-\.]*)@([a-z0-9_\-\.]*)(\.[a-z]{2,4}(\.[a-z]{2}){0,2})$/i;
           if(src =="" || src == null )
          {
             output.innerHTML = "<img src='../images/Application/icon_wrong.gif'/>邮箱不能为空.";	
             document.getElementById("imgEmail").style.display = "none";
             changetype1(output);
             
             result = false;
          }	
          else if (!objRegExp.test(src))
          {
	         output.innerHTML = "<img src='../images/Application/icon_wrong.gif'/>电子邮件的格式不对";
	         document.getElementById("imgEmail").style.display = "none";
	         changetype1(output);
	         
	        
	         result = false;
          }
          else
          {
             output.innerHTML = "请务必填写真实,并确认是您最常用的电子邮件.";
             changetype2(output);
             document.getElementById("imgEmail").style.display = "";
             result = true;
           }
       }
       return result;
     }
 } 
 
	function checkTel()
	{
		/*\d 代表一个数字
{7,8} 代表7－8位数字（表示电话号码）
{3,} 代表分机号码
d{2,3} 代表区号
\+]\d{2,3} 代表国际区号*/

        var me = false;
		var t1 = document.getElementById("txtTelCountry").value; 
		var t2 = document.getElementById("txtTelZoneCode").value; 
		var t3 = document.getElementById("txtTelNumber").value; 
		if(t1==""||t2==""||t3=="" )
		{
		    return false;
		}
		else
		{
		    var p1 = /^[0-9-\/]+$/;           
            if (p1.test(t3))  me=true;
            else me = false;
            return me;
	    }
	}
		
 	function checkMobile(strValue)
	{
	/*^13\d{5,9}$/ //130–139。至少5位，最多9位
/^153\d{4,8}$/ //联通153。至少4位，最多8位
/^159\d{4,8}$/ //移动159。至少4位，最多8位 */
        var mobile=strValue;
        var reg0 = /^13\d{5,9}$/;
        var reg1 = /^153\d{4,8}$/;
        var reg2 = /^159\d{4,8}$/;
        var reg3 = /^0\d{10,11}$/;
        var my = false;
        if (reg0.test(mobile))my=true;
        if (reg1.test(mobile))my=true;
        if (reg2.test(mobile))my=true;
        if (reg3.test(mobile))my=true;
              
        return my;	
	}
	function CheckSubmit()
	{
	   var chekVal = true;
	    
	    chekVal &= CheckItem(1,'OrgName',rem1);
        chekVal &= CheckItem(1,'RealName',rem2);
        chekVal &= CheckItem(1,'Tel',rem3);
        chekVal &= CheckItem(1,'Mobile',rem4);
        chekVal &= CheckItem(1,'email',rem5);
      
        return chekVal == 1?true:false;
        
       
	}
</script>

