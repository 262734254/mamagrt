<%@ Page Language="C#" EnableEventValidation=false AutoEventWireup="true" CodeFile="VIPMemberRegister.aspx.cs"
    Inherits="Register_TTMemberRegister" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>�ظ�ͨ��Ա����-�ظ����й�����Ͷ����</title>
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
                <img src="../images/Application/zi_001.gif" alt="�ظ�ͨ��Ա��������" width="195" height="33" /></h1>
            <div class="right" >
                �����Ϊ�ظ�ͨ��Ա�������ɹ��Ļ������ͨ��Ա���<span class="chengcu" style="font-size:25px">12</span>����</div>
				<div class="clear"></div>
        </div>
        <div class="blank20">
        </div>
      <div class="suggestbox">
            <h1>
                <img src="../images/icon_yb.gif" width="17" height="17" align="absmiddle" />
                ��Ҫ��ʾ</h1>
           <p> 1.�� <span class="hong">* </span>Ϊ�����Ϊ�˳�ֱ������ĸ���Ȩ�棬������д��ʵ��������Ϣ��<br />
          2.Ϊ�˱�֤�ظ�ͨ��Ա��Ȩ�棬�й�����Ͷ���������ظ�ͨ��Ա����ͨ��������֤������֤ͨ���Ļ�Ա��<a href="http://www.topfo.com/topfocenter/degreeaffirm/index.shtml" target="_blank" class="lanlink"> ���˽�һ���ظ�ͨ��֤����</a></p>
      </div>
        <div class="blank20">
        </div>
        <div class="fillbox">
            <div class="c" id="cbAcceptbox">
                <div class="trbox">
                    <div class="tdleft">
                        <img src="../images/Application/icon_right.gif" /><span class="hong">*</span> ��Ա���ͣ�</div>
                    <div class="tdcenter">
                        &nbsp;<input id="radioManageType1" name="ManageType" type="radio" value="2003" runat="server"
                            onclick="changeManageType(2003)"  checked>��Ŀ��<input id="radioManageType3" name="ManageType" type="radio" onclick="changeManageType(2001)"
                            value="2001" runat="server" />�������̻���</div>
                    <div class="clear"></div>
                </div>
                <div class="trbox">
                    <div class="tdleft" style="padding-top: 7px">
                        <img src="../images/Application/icon_right.gif" /><span class="hong">*</span> �������ޣ�</div>
                    <div class="tdcenter">
                        <asp:RadioButtonList ID="rblBuyTerm" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Selected="True" Value="1">һ��</asp:ListItem>
                            <asp:ListItem Value="2">����</asp:ListItem>
                            <asp:ListItem Value="3">����</asp:ListItem>
                        </asp:RadioButtonList></div>
                    <div class="clear">
                    </div>
                </div>
                <div class="trbox" id="divOrgName">
                  <div class="tdleft">
                       
                            <img src="../images/Application/icon_right.gif" id="imgOrgName" style="display: none" /> <span class="hong">*</span>
                        <asp:Label ID="lbOrgName" runat="server" Text="��˾���ƣ�"></asp:Label>
                  </div>
                    <div class="tdcenter">
                        <asp:TextBox ID="tbOrgName" runat="server" Height="15px" Width="220px" onfocus="changetype1(rem1)"
                            onblur="CheckItem(1,'OrgName',rem1);"></asp:TextBox>
                    </div>
                    <div class="" id="rem1">
                        &nbsp; &nbsp;&nbsp;���ѣ��밴�չ�˾Ӫҵִ�������ȫ����д</div>
                    <div class="clear">
                    </div>
                </div>
                <div class="trbox">
                    <div class="tdleft">
                        <img src="../images/Application/icon_right.gif" style="display: none" id="imgRealName" /><span
                            class="hong">*</span> ��ʵ������</div>
                    <div class="tdcenter">
                        <asp:TextBox ID="tbRealName" runat="server" Height="15px" Width="158px" onfocus="changetype1(rem2)"
                            onblur="CheckItem(1,'RealName',rem2);"></asp:TextBox>
                    </div>
                    <div class="" id="rem2">
                        &nbsp; &nbsp;���ѣ�����д������ʵ����</div>
                    <div class="clear">
                    </div>
                </div>
                <div class="trbox">
                    <div class="tdleft" style="padding-top: 7px">
                        <img src="../images/Application/icon_right.gif" /><span class="hong">*</span> ��
                        ��</div>
                    <div class="tdcenter" >
                        <asp:RadioButtonList ID="rblSex" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Selected="True" Value="true">��</asp:ListItem>
                            <asp:ListItem Value="false">Ů</asp:ListItem>
                        </asp:RadioButtonList></div>
                    <div class="clear">
                    </div>
                </div>
                <div class="trbox" id="divPosition">
                    <div class="tdleft">
                        <img src="../images/Application/icon_right.gif" style="display: none" id="imgPosition" />
                        ְ��</div>
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
                            class="hong">*</span> �̶��绰��</div>
                    <div class="tdcenter" style="width: 251px">
                        <table width="192" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td valign="bottom" style="line-height: 150%; width: 42px;">
                                    ����</td>
                                <td valign="bottom" style="line-height: 150%; width: 52px;">
                                    ��������</td>
                                <td width="73" valign="bottom" style="line-height: 150%">
                                    &nbsp;�绰����</td>
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
                        <img src="../images/Application/icon_right.gif" id="imgMobile" style="display: none" />��
                        ����</div>
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
                            class="hong">*</span> Email ��</div>
                    <div class="tdcenter">
                        <asp:TextBox ID="txtEmail" runat="server" Width="157px" onfocus="changetype1(rem5)"
                            onblur="CheckItem(1,'email',rem5);"></asp:TextBox></div>
                    <div class="" id="rem5">
                        ���ѣ�ȷ��Ϊ�����յ��й�����Ͷ������Ͷ������<br />
                        �����ҵ��Կڶ������Ϣ������д������ʹ�õĵ�������<br />
                    </div>
                    <div class="clear">
                        &nbsp;</div>
                </div>
                <br />
            </div>
            <div class="mbbuttom">
                &nbsp;
                <img src="../images/Application/icon_yuan.gif" width="17" height="17" align="bottom" />
            <a href="http://www.topfo.com/ServiceItem/TopfoServiceItem.shtml" target="_blank" class="lanlink">����Ķ��ظ�ͨ����Э��</a> <a href="http://www.topfo.com/Service/enterprisemember.shtml" target="_blank"><span class="gtext">[�鿴�ظ�ͨ��Ա����]</span></a><br />
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
  if(es1.exec(str))//�޸�
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
  else//���
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
       name.innerHTML = "��˾���ƣ�";
     }	
     if(type==2001)
     {
        divOrgName.style.display = "";
        divPosition.style.display = "";
        name.innerHTML = "�������ƣ�";
      }
      ManageType.value = type;
      clearPage();
}

//tag �Ƿ���Ҫ��֤��0����Ա���͵��л�����Ҫ��֤ ; 1����д��֤��
var isValid= true;
var isValid1=true;
function CheckItem(tag,type,output)
{
   var src = "";
   if(type=="OrgName")
   {
       if(tag==0)
       {
         output.innerHTML = "���ѣ��밴�չ�˾Ӫҵִ�������ȫ����д.";
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
             output.innerHTML = "<img src='../images/Application/icon_wrong.gif'/>���Ʋ���Ϊ��.";	
             document.getElementById("imgOrgName").style.display = "none";			
             changetype1(output);
            
             return false;
          }	
          else
          {
             output.innerHTML = "���ѣ��밴�չ�˾Ӫҵִ�������ȫ����д.";
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
        output.innerHTML = "���ѣ�����д������ʵ����.";
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
             output.innerHTML = "<img src='../images/Application/icon_wrong.gif'/>��������Ϊ��.";	
             document.getElementById("imgRealName").style.display = "none";			
             changetype1(output);        
            
             return false;
          }	
          else
          {
              output.innerHTML = "���ѣ�����д������ʵ����.";
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
//                 output.innerHTML = "<img src='../images/Application/icon_wrong.gif'/>ְ����Ϊ��.";	
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
		    output.innerHTML = "<img src='../images/Application/icon_wrong.gif'/>�绰���벻��Ϊ��.";	
             document.getElementById("imgTel").style.display = "none";	
             changetype1(output);	
             return false;
		}
       else 
       {   
          if (!checkTel())
          {
             output.innerHTML = "<img src='../images/Application/icon_wrong.gif'/>�绰������д����.";	
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
             output.innerHTML = "<img src='../images/Application/icon_wrong.gif'/>�ֻ���д����.";	
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
        output.innerHTML = "�������д��ʵ,��ȷ��������õĵ����ʼ�.";
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
             output.innerHTML = "<img src='../images/Application/icon_wrong.gif'/>���䲻��Ϊ��.";	
             document.getElementById("imgEmail").style.display = "none";
             changetype1(output);
             
             result = false;
          }	
          else if (!objRegExp.test(src))
          {
	         output.innerHTML = "<img src='../images/Application/icon_wrong.gif'/>�����ʼ��ĸ�ʽ����";
	         document.getElementById("imgEmail").style.display = "none";
	         changetype1(output);
	         
	        
	         result = false;
          }
          else
          {
             output.innerHTML = "�������д��ʵ,��ȷ��������õĵ����ʼ�.";
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
		/*\d ����һ������
{7,8} ����7��8λ���֣���ʾ�绰���룩
{3,} ����ֻ�����
d{2,3} ��������
\+]\d{2,3} �����������*/

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
	/*^13\d{5,9}$/ //130�C139������5λ�����9λ
/^153\d{4,8}$/ //��ͨ153������4λ�����8λ
/^159\d{4,8}$/ //�ƶ�159������4λ�����8λ */
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

