<%@ Page Language="C#" AutoEventWireup="true" CodeFile="VIPMemberRegister_In.aspx.cs"
    MasterPageFile="~/MasterPage.master" Inherits="Register_VIPMemberRegister_In" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<link href="../css/VipReg.css" rel="stylesheet" type="text/css">  
<link href="../css/application.css" rel="stylesheet" type="text/css" />
<div class="mainconbox">
                              <div class="reg_channel">
                    �����Ϊ�ظ�ͨ��Ա�������ɹ��Ļ������<span>12</span>����
                </div>
                <div class="clear">
                </div>
                <div class="vrtopbg">
                    <div class="vip_box">
                        <div class="vntop">
                            <div class="vnbot">
                                <div class="vnimg">
                                    <h3>
                                        ��ܰ��ʾ��</h3>
                                    <p>
                                        1����*Ϊ�����Ϊ�˳�ֱ������ĸ���Ȩ�棬������д��ʵ��������Ϣ��</p>
                                    <p>
                                        2��Ϊ�˱�֤�ظ�ͨ��Ա��Ȩ�棬�й�����Ͷ���������ظ�ͨ��Ա����ͨ��������֤������֤ͨ���Ļ�Ա��</p>
                                    <div class="vnimgr" style="padding-top:8px;">
                                        <img src="../images/vip_reg/icon_yb.gif" align="absmiddle" />
                                        <a href="http://www.topfo.com/help/TopfoServer.shtml#a2" target="_blank" class="lanlink">���˽�һ���ظ�ͨ��֤����</a></div>
                                </div>
                            </div>
                        </div>
                        <div class="fillboxm" >
                            <div class="c" id="cbAcceptbox">
                                <div class="trbox">
                                    <div class="tdleft">
                                        <img src="../images/Application/icon_right.gif" /><span class="hong">*</span> ��Ա���ͣ�</div>
                                    <div class="tdcenter" style="display:none">
                                        &nbsp;<input id="radioManageType1" name="ManageType" type="radio" value="1003" runat="server"
                                            onclick="changeManageType(1003)" readonly="true" />��ҵ<input id="radioManageType2"
                                                name="ManageType" type="radio" onclick="changeManageType(1001)" value="1001"
                                                runat="server" readonly="true" />
                                        ����<input id="radioManageType3" name="ManageType" type="radio" onclick="changeManageType(1004)"
                                            value="1004" runat="server" readonly="true" />����</div>
                                  
                                        <asp:Label runat="server" ID="managetype"></asp:Label>
                                </div>
                                <div class="trbox">
                                    <div class="tdleft">
                                        <img src="../images/Application/icon_right.gif" /><span class="hong">*</span> �������ޣ�</div>
                                    <div class="tdcenter" style="position:relative;top:-8px;">
                                        <asp:RadioButtonList ID="rblBuyTerm" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Selected="True" Value="1">3����</asp:ListItem>
                                            <asp:ListItem Value="2">����</asp:ListItem>
                                            <asp:ListItem Value="3">һ��</asp:ListItem>
                                        </asp:RadioButtonList></div>                                  
                                </div>
                                <div class="trbox" id="divOrgName">                                  
                                    <div class="tdleft">
                                        <span class="hong">
                                            <img src="../images/Application/icon_right.gif" id="imgOrgName" style="display: none" />*</span>
                                        <asp:Label ID="lbOrgName" runat="server" Text="��˾���ƣ�"></asp:Label>
                                    </div>
                                    <div class="tdcenter">
                                        <asp:TextBox ID="tbOrgName" runat="server" Height="15px" Width="220px" onfocus="changetype1(rem1)"
                                            onblur="CheckItem(1,'OrgName',rem1);"></asp:TextBox>
                                    </div>
                                    <div class="" id="rem1" style="font-size:12px;color:#666666;">���ѣ��밴�չ�˾Ӫҵִ�������ȫ����д</div>
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
                                    <div class="" id="rem2" style="font-size:12px;color:#666666;">���ѣ�����д������ʵ����</div>
                                    <div class="clear">
                                    </div>
                                </div>
                                <div class="trbox">
                                    <div class="tdleft">
                                        <img src="../images/Application/icon_right.gif" /><span class="hong">*</span> ��
                                        ��</div>
                                    <div class="tdcenter" style="position:relative;top:-8px;">
                                        <asp:RadioButtonList ID="rblSex" runat="server" RepeatDirection="Horizontal" Enabled="false">
                                            <asp:ListItem Value="true">��</asp:ListItem>
                                            <asp:ListItem Value="false">Ů</asp:ListItem>
                                        </asp:RadioButtonList></div>
                                  
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
                                    <div class="tdleft" style="padding-top: 20px">
                                        <img src="../images/Application/icon_right.gif" id="imgTel" style="display: none" /><span
                                            class="hong">*</span> �̶��绰��</div>
                                    <div class="tdcenter" style="width: 251px">
                                        <table width="192" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td valign="bottom" style="line-height: 150%; width: 42px;" >
                                                    ����</td>
                                                <td valign="bottom" style="line-height: 150%; width: 58px;">
                                                    ��������</td>
                                                <td width="73" valign="bottom" style="line-height: 150%">
                                                    &nbsp;�绰����</td>
                                            </tr>
                                        </table>
                                        <asp:TextBox ID="txtTelCountry"  runat="server" Columns="6" MaxLength="4" Width="35px">+86</asp:TextBox>
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
                                            onblur="CheckItem(1,'email',rem5);"></asp:TextBox>
                                  </div>
                                    <div class="" id="rem5" style="font-size:12px;color:#666666;">
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
                                <img src="../images/Application/icon_yuan.gif" width="17" height="17" style="position:relative;top:3px;"/>
                                <a href="http://www.topfo.com/ServiceItem/TopfoServiceItem.shtml" target="_blank" class="lanlink">����Ķ��ظ�ͨ����Э��</a><br />
                                <br />
                                &nbsp;<asp:ImageButton ID="ibOK" runat="server" ImageUrl="../images/Application/buttom_ty.gif"
                                    OnClick="ibOK_Click" />
                          <input id="hidManageType" style="width: 1px" type="hidden" runat="server" /></div>
                       
                        <div class="clear">
                        </div>
                    </div>
                </div>
               <div class="clear">
                </div>
</div>
</div>
    <script type="text/javascript">
init();
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
    //changeManageType(typeVaule);
  }
  else//���
  { 
     //var r=document.getElementById("radioManageType1");
    // r.checked;    
     changeManageType(1003);   
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
    if(type==1003)
    {
       divOrgName.style.display = "";
       divPosition.style.display = "none";
       name.innerHTML = "��˾���ƣ�";
     }		
    if(type==1001)    
    {
        divOrgName.style.display = "none"; 
        divPosition.style.display = "none";
    }
     if(type==1004)
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
           src = document.getElementById("ctl00_ContentPlaceHolder1_tbOrgName").value;           
           if(src =="" || src == null )
          { 
             output.innerHTML = "<img src='../images/Application/icon_wrong.gif' style='position:relative;top:2px;margin-right:2px;'/>���Ʋ���Ϊ��.";	
             document.getElementById("imgOrgName").style.display = "none";			
             changetype1(output);
             isValid =  false;
             return false; 
          }	
          else
          {  
             output.innerHTML = "���ѣ��밴�չ�˾Ӫҵִ�������ȫ����д.";
             changetype2(output);
             document.getElementById("imgOrgName").style.display = "";
             isValid =  true;
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
           src = document.getElementById("ctl00_ContentPlaceHolder1_tbRealName").value; 
           if(src =="" || src == null )
          {
             output.innerHTML = "<img src='../images/Application/icon_wrong.gif' style='position:relative;top:2px;margin-right:2px;'/>��������Ϊ��.";	
             document.getElementById("imgRealName").style.display = "none";			
             changetype1(output);        
             isValid = false;
             return false;
          }	
          else
          {
              output.innerHTML = "���ѣ�����д������ʵ����.";
              changetype2(output);
              document.getElementById("imgRealName").style.display = "";
              isValid = true;
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
             src = document.getElementById("ctl00_ContentPlaceHolder1_tbPosition").value; 
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
     if(tag==0)
       {
         output.innerHTML = "";
          changetype2(output);
          document.getElementById("imgTel").style.display = "none";
             isValid =  false;
             isValid1 =  true;
       }
       else
       {
          var t1 = document.getElementById("ctl00_ContentPlaceHolder1_txtTelCountry").value; 
		  var t2 = document.getElementById("ctl00_ContentPlaceHolder1_txtTelZoneCode").value; 
		  var t3 = document.getElementById("ctl00_ContentPlaceHolder1_txtTelNumber").value; 	
          if(t1==""||t2==""||t3=="" )
		  {
		    output.innerHTML = "<img src='../images/Application/icon_wrong.gif' style='position:relative;top:2px;margin-right:2px;'/>�绰���벻��Ϊ��.";	
             document.getElementById("imgTel").style.display = "none";	
             changetype1(output);	
             return false;
		  }
          else  if (!checkTel())
          {
             output.innerHTML = "<img src='../images/Application/icon_wrong.gif' style='position:relative;top:2px;margin-right:2px;'/>�绰������д����.��ȷ����д�������ʵ��";	
             document.getElementById("imgTel").style.display = "none";	
             changetype1(output);	
           
             isValid =  false;
             return false;
          }
          else
          {
              output.innerHTML = "";
              changetype2(output);
              document.getElementById("imgTel").style.display = "";
              isValid = true;
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
           src = document.getElementById("ctl00_ContentPlaceHolder1_txtMobile").value;
         
          if(src =="" || src == null ) 
          {
              output.innerHTML = "";
              changetype2(output);
              document.getElementById("imgMobile").style.display = "none";
              isValid = true;
          }     
          else if (!checkMobile(src))
          {
             output.innerHTML = "<img src='../images/Application/icon_wrong.gif' style='position:relative;top:2px;margin-right:2px;'/>�ֻ���д����,����д��ʵ�ĺ���!";	
             document.getElementById("imgMobile").style.display = "none";	
             changetype1(output);	
             isValid = false;	
             return false;
          }	
          else
          {
              output.innerHTML = "";
              changetype2(output);
              document.getElementById("imgMobile").style.display = "";
              isValid = true;
          }
      }
    }
   if(type=="email")
   {
   if(tag==0)
       {
        output.innerHTML = "�������д��ʵ,��ȷ��������õĵ�����.";
         changetype2(output);
         document.getElementById("imgEmail").style.display = "none";
             isValid =  false;
             isValid1 =  true;
       }
       else
       {
          src = document.getElementById("ctl00_ContentPlaceHolder1_txtEmail").value; 
          var objRegExp  = /^[a-z0-9]([a-z0-9_\-\.]*)@([a-z0-9_\-\.]*)(\.[a-z]{2,4}(\.[a-z]{2}){0,2})$/i;
           if(src =="" || src == null )
          {
             output.innerHTML = "<img src='../images/Application/icon_wrong.gif' style='position:relative;top:2px;margin-right:2px;'/>���䲻��Ϊ��.";	
             document.getElementById("imgEmail").style.display = "none";
             changetype1(output);
              isValid = false;
             return false;
          }	
          else if (!objRegExp.test(src))
          {
	         output.innerHTML = "<img src='../images/Application/icon_wrong.gif' style='position:relative;top:2px;margin-right:2px;'/>�����ʼ��ĸ�ʽ����";
	         document.getElementById("imgEmail").style.display = "none";
	         changetype1(output);
	          isValid =  false;
	        
	         return false;
          }
          else
          {
             output.innerHTML = "�������д��ʵ,��ȷ��������õĵ�����.";
             changetype2(output);
             document.getElementById("imgEmail").style.display = "";
             isValid = true;
           }
       }
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
		var t1 = document.getElementById("ctl00_ContentPlaceHolder1_txtTelCountry").value; 
		var t2 = document.getElementById("ctl00_ContentPlaceHolder1_txtTelZoneCode").value; 
		var t3 = document.getElementById("ctl00_ContentPlaceHolder1_txtTelNumber").value; 		
	    var p1 = /^[0-9-\/]+$/;           
        if (p1.test(t3))  me=true;
        else me = false;
        return me;
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
        if (!my){       
            my = false;
        }        
        return my;	
	}
	function CheckSubmit(source,arg)
	{
	    CheckItem(1,'OrgName',rem1);
        CheckItem(1,'RealName',rem2);
        CheckItem(1,'Tel',rem3);
        CheckItem(1,'Mobile',rem4);
        CheckItem(1,'email',rem5);
    
       return  arg.IsValid=isValid & isValid1 ;        
	}
    </script>

</asp:Content>
