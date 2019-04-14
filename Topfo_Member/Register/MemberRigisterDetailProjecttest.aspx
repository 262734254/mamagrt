<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MemberRigisterDetailProjecttest.aspx.cs" Inherits="Register_MemberRigisterDetailProjecttest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="~/Controls/ZoneSelectControl.ascx" TagName="ZoneSelectControl" TagPrefix="uc1" %>
<%@ Register Src="Control/FileUploader.ascx" TagName="FileUploader" TagPrefix="uc3" %>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
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
                <td align="right" valign="top" bgcolor="#F7F7F7" style="height: 33px">
                   <span class="hong">*</span> <strong>昵 称：</strong></td>
                <td style="height: 33px">
                    <span class="chengcu">
                        <asp:TextBox ID="txtNickName" onfocus="checkother('showNick')" onblur="checkotherout('txtNickName','showNick')" runat="server"></asp:TextBox>&nbsp;<div id="showNick" style ="display:none; color:Red ; font-size:16px ">*</div>
                        </span></td>   
            </tr>
            <tr>
                <td colspan="2" style="height:35px;vertical-align:bottom">&nbsp;&nbsp;<strong style="font-size:large">项目方信息</strong>&nbsp;<span style="color:#c7c7c7">(可修改)</span></td>
            </tr>
           <tr>
                <td align="right" bgcolor="#F7F7F7" style="height: 26px">
                    <span class="hong">*</span> <strong>项目方类型：</strong></td>
                <td style="height: 26px" >
                    <asp:RadioButtonList ID="radiotype" runat="server" AutoPostBack ="true" RepeatDirection="Horizontal">
                        <asp:ListItem Value="0">融资企业</asp:ListItem>
                        <asp:ListItem Value="1">个人创业</asp:ListItem>
                    </asp:RadioButtonList>
                    </td>
            </tr>
            <tr>
                <td align="right" bgcolor="#F7F7F7" style="height: 26px">
                    <span class="hong">*</span> <strong>公司名称：</strong></td>
                <td style="height: 26px" >
                    <asp:TextBox ID="txtCompany" runat="server" onfocus="checkother('showcompany')" onblur="checkotherout('txtCompany','showcompany')" Width="176px"></asp:TextBox>&nbsp;<div id="showcompany" style ="display:none; color:Red ; font-size:16px ">*</div>
                    </td>
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
                    <asp:TextBox ID="txtContactName" runat="server" onfocus="checkother('showcontactName')" onblur="checkotherout('txtContactName','showcontactName')" Width="176px"></asp:TextBox>&nbsp;<div id="showcontactName" style ="display:none; color:Red ; font-size:16px ">*</div>
                    </td>
            </tr>
            <tr>
                <td align="right" bgcolor="#F7F7F7" >
                    <span class="hong"></span> <strong>职位：</strong></td>
                <td valign="top" >
                    <asp:TextBox ID="txtContactTitle" runat="server" Width="176px"></asp:TextBox>
                    </td>
            </tr>
            <tr>
                <td align="right" bgcolor="#F7F7F7" style="height: 143px">
                    <span class="hong">*</span> <strong>固定电话：</strong></td>
                <td valign="top" style="height: 143px" >
                  <ul>
                        <li class="liwai" style="width: 66px;">国家</li><li style="width: 70px;">城市区号</li><li>电话号码</li></ul>
                    <br />
                    <asp:TextBox ID="txtTelCountry" runat="server" size="4">+86</asp:TextBox>
                    <asp:TextBox ID="txtTelZoneCode" runat="server" size="7" onblur="checkdiv(4,'txtTelZoneCode','showTelZoneCode')" onkeydown="return checkinput(this,3,'showTelZoneCode')"   onkeyup ="return checkinput(this,3,'showTelZoneCode')" ></asp:TextBox>
                    <asp:TextBox ID="txtTelNumber" runat="server" size="18"  onblur="checkdiv(8,'txtTelNumber','showTelZoneCode')" onkeydown="return checkinput(this,7,'showTelZoneCode')"   onkeyup ="return checkinput(this,7,'showTelZoneCode')" ></asp:TextBox>&nbsp;<div id="showTelZoneCode" style ="display:none; color:Red ; font-size:16px ">请输入数字</div>
                    &nbsp;&nbsp;
                    <br />
                    <span class="hui">如果要输入多个号码，请使用&quot;,&quot;分隔；分机号码用&quot;－&quot;分隔</span>&nbsp;<br />
                        </td>
            </tr>
            <tr>
                <td align="right" bgcolor="#F7F7F7" >
                    <strong>手 机：</strong></td>
                <td style="width: 638px; height: 33px;">
                    <asp:TextBox ID="txtMobile" onblur="checkdiv(11,'txtMobile','showMobile')" onkeydown="return checkinput(this,10,'showMobile')"   onkeyup ="return checkinput(this,10,'showMobile')"  runat="server" Width="176px"></asp:TextBox>&nbsp;<div id="showMobile" style ="display:none; color:Red ; font-size:16px">请输入数字</div>
                    </td>
            </tr>
            <tr>
                <td align="right" valign="top" bgcolor="#F7F7F7">
                    <span class="hong">*</span> <strong>电子邮箱：</strong></td>
              <td >
                    <asp:TextBox ID="txtEmail" onfocus="checkother('showemil')" onblur="checkotherout('txtEmail','showemil')" runat="server" size="18" Width="176px"></asp:TextBox>&nbsp;&nbsp;<div id="showemil" style ="display:none; color:Red ; font-size:16px ">*</div>
                  <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtEmail"
                      ErrorMessage="请填写正确的邮箱地址！" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
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
                        <span class="hong">*</span>  <strong>联系地址：</strong></td>
                <td >
                    <asp:TextBox ID="txtAddress" onfocus="checkother('showaddress')" onblur="checkotherout('txtAddress','showaddress')" runat="server" size="18" Width="369px"></asp:TextBox>&nbsp;<div id="showaddress" style ="display:none; color:Red ; font-size:16px ">*</div>
                    </td>
            </tr>
            <tr>
                <td align="right" bgcolor="#F7F7F7" style="height: 86px" >
                        <span class="hong">*</span>  <strong>邮 编：</strong></td>
                <td style="height: 86px" >
                    <asp:TextBox ID="txtPostCode" runat="server" onblur="checkdiv(6,'txtPostCode','showPostCode')"  onkeydown="return checkinput(this,5,'showPostCode')"   onkeyup ="return checkinput(this,5,'showPostCode')" size="18" Width="115px"></asp:TextBox>&nbsp;<div id="showPostCode" style ="display:none; color:Red ; font-size:16px">请输入数字</div>
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
                &nbsp;<asp:Button ID="btnOk" runat="server"  CausesValidation="true" Height="22"
                    Style="padding-top: 1px" Text="确  认" Width="50" OnClick="btnOk_Click"  OnClientClick ="return checkall()"/><label>
                    </label>
            </p>
        </div>
    </div>


    <script type="text/javascript">
   function changFocus()
   {
	 if(event.keyCode==13&&event.srcElement.type!='button'
	 &&event.srcElement.type!='submit'
	 &&event.srcElement.type!='textarea'
	 &&event.srcElement.type!='')
	 { 
	   event.keyCode=9;
	 } 
   }
    document.onkeydown=changFocus;
    
     function checkother(ithis)
    {
    document.getElementById (ithis).style .display ="none";
    }
    function checkotherout(ithis,ithiss)
    {
     if(document.getElementById (ithis).value.length==0)
     {
      document.getElementById (ithiss).style .display ="inline";
     }
    }
    function checkinput(ithis,counts,divid)
    {
     var s=event.keyCode;
     if(s==13){}
     else
     {
      if(s!=8)
      {
                if(ithis.value.length >counts)
                {
                  return false;
                }
                if(ithis.value.length <counts)
                {
                     if(s>=48&&s<=57||s>=96&&s<=105)
                     {
                     document .getElementById (divid).style.display ="none";
                     return true;
                     }
                     else
                     {
                     document.getElementById (divid).innerHTML="请输入数字";
                     document .getElementById (divid).style.display ="inline";
                     return false ;
                     }
                }
                if(ithis.value.length==counts)
                {
                     if(s>=48&&s<=57||s>=96&&s<=105)
                     {
                     document .getElementById (divid).style.display ="none";
                     return true;
                     }
                     else
                     {
                     document.getElementById (divid).innerHTML="请输入数字";
                     document .getElementById (divid).style.display ="inline";
                     return false ;
                     }
                }
        
       }
      else if(s==8)
       {
          document .getElementById (divid).style.display ="none";
          return true ;
       }
    }
  }
  
  function checkdiv(counts,ithis,ithisdiv)
  {
      document .getElementById (ithisdiv).style.display ="none";
       var coun=counts-1;
       if(ithis=="txtTelNumber")
       {
         if( document .getElementById (ithis).value.length!=coun&&document .getElementById (ithis).value.length!=counts)
         {
            if(document .getElementById (ithis).value.length!=0)
            {
            document.getElementById (ithisdiv).innerHTML="输入不正确";
            document.getElementById(ithisdiv).style .display ="inline";
            }
             if(document .getElementById (ithis).value.length==0)
            {
            document.getElementById (ithisdiv).innerHTML="*";
            document.getElementById(ithisdiv).style .display ="inline";
            }
         }

       }
       else
       {
         if( document .getElementById (ithis).value.length!=counts&&document .getElementById (ithis).value.length!=0)
         {
          document.getElementById (ithisdiv).innerHTML="输入不正确";
          document.getElementById(ithisdiv).style .display ="inline";
         }
          if(document .getElementById (ithis).value.length==0)
          {
            if(ithis!="txtMobile")
             {
               document.getElementById (ithisdiv).innerHTML="*";
               document.getElementById(ithisdiv).style .display ="inline";
             }
          }
          if(document.getElementById (ithis).value.length==counts)
          {
          document.getElementById (ithisdiv).innerHTML="";
          document.getElementById(ithisdiv).style .display ="none";
          }
         
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
        var reg3 = /^158\d{4,8}$/;
        var reg4 = /^157\d{4,8}$/;
        var reg5 = /^0\d{10,11}$/;
        var my = false;
        if (reg0.test(mobile))my=true;
        if (reg1.test(mobile))my=true;
        if (reg2.test(mobile))my=true;
        if (reg3.test(mobile))my=true;
        if (reg4.test(mobile))my=true;
        if (reg5.test(mobile))my=true;
              
        return my;	
	}	
  function checkall()
  {  
      if(document .getElementById ("txtNickName").value.length==0)
      {
       document.getElementById ("showNick").style .display ="inline";
       return false;
      }
       if(document .getElementById ("txtCompany").value.length==0)
      {
       document.getElementById ("showcompany").style .display ="inline";
       return false;
      }
       if(document .getElementById ("txtContactName").value.length==0)
      {
       document.getElementById ("showcontactName").style .display ="inline";
       return false;
      }
       if(document .getElementById ("txtContactTitle").value.length==0)
      {
       document.getElementById ("showcontactContactTitle").style .display ="inline";
       return false;
      }
      if(document .getElementById ("txtTelZoneCode").value.length!=4)
      {
       document.getElementById ("showTelZoneCode").innerHTML="输入不正确";
       if(document .getElementById ("txtTelZoneCode").value.length==0)
       {
       document.getElementById ("showTelZoneCode").innerHTML="*";
       }
       document .getElementById ("showTelZoneCode").style.display ="inline";
       return false;
      }
       if(document .getElementById ("txtTelNumber").value.length!=7&&document .getElementById ("txtTelNumber").value.length!=8)
      {
       document.getElementById ("showTelZoneCode").innerHTML="输入不正确";
       if(document .getElementById ("txtTelNumber").value.length==0)
       {
        document.getElementById ("showTelZoneCode").innerHTML="*";
       }
       document .getElementById ("showTelZoneCode").style.display ="inline";
       return false;
      }
       if(document .getElementById ("txtMobile").value.length!=11&&document .getElementById ("txtMobile").value.length!=0)
      {
       document.getElementById ("showMobile").innerHTML="输入不正确";
       if(document .getElementById ("txtMobile").value.length==0)
       {
        document.getElementById ("showMobile").innerHTML="";
       }
       document .getElementById ("showMobile").style.display ="inline";
       
      return false;
      }

       if(document .getElementById ("txtEmail").value.length==0)
      {
       document.getElementById ("showemil").style .display ="inline";
       return false;
      }
      if(document .getElementById ("txtAddress").value.length==0)
      {
       document.getElementById ("showaddress").style .display ="inline";
       return false;
      }
       if(document .getElementById ("txtPostCode").value.length!=6)
      {
       document.getElementById ("showPostCode").innerHTML="输入不正确";
       if(document .getElementById ("txtPostCode").value.length==0)
       {
            document.getElementById ("showPostCode").innerHTML="*";
       }
       document .getElementById ("showPostCode").style.display ="inline";
       return false;
      }
      else
      {
       return true;
      }  
    }
    </script>
    
    </form>
</body>
</html>
