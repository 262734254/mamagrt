<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodePage="936" ValidateRequest="false" EnableEventValidation="false" CodeFile="ContactInfo.aspx.cs"
    Inherits="Publish_project_ContactInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="/css/common.css" rel="stylesheet" type="text/css">
    <link href="/css/stake.css" rel="stylesheet" type="text/css">
    <style>
    .show{
    border-top-style: none; border-right-style: none;
                                border-left-style: none; border-bottom-style: none; 
                                vertical-align: middle;
                                 
    }
    </style>

    <script language="javascript">
    function txtshow(obj)
    {
        if(obj=="Tel")
        {
            var t="<%=this.txtTelStateCode.ClientID %>";
            var c="<%=this.txtTel.ClientID %>";
            document.getElementById(t).className="";
            document.getElementById(c).disabled="";
        }
        document.getElementById("ctl00_ContentPlaceHolder1_txt"+obj).className="";
        document.getElementById('ctl00_ContentPlaceHolder1_txt'+obj).disabled="";
        document.getElementById('lnk'+obj).innerHTML="";
    }
    </script>

    <script language="javascript">
 function chkpost()
  {
    var CompanyName="<%=this.txtCompanyName.ClientID %>";
   if(document.getElementById(CompanyName).value=="")
   {
    alert("��Ŀ��λ���Ʋ���Ϊ��...");
    txtshow("CompanyName");
    document.getElementById(CompanyName).focus();
    return false;
  }
 
  var LinkMan="<%=this.txtLinkMan.ClientID %>";
  if(document.getElementById(LinkMan).value=="")
  {
    alert("��ϵ�˲���Ϊ��...");
    txtshow("LinkMan");
    document.getElementById(LinkMan).focus();
    return false;
  }
 
  var Tel="<%=this.txtTel.ClientID %>";
  var Mobile="<%=this.txtMobile.ClientID %>";
  var TelStateCode="<%=this.txtTelStateCode.ClientID %>";
  if(document.getElementById(Tel).value==""&&document.getElementById(Mobile).value=="")
  {
         alert("�绰������ֻ���������дһ��...");
         txtshow("Tel");
         document.getElementById(Tel).focus();
         return false;
  }
  if(document.getElementById(Tel).value!="")
  {
      if(isNaN(document.getElementById(Tel).value))
      {
             alert("�绰�����ʽ����");
             txtshow("Tel");
             document.getElementById(Tel).focus();
             return false;
      }
      if(document.getElementById(TelStateCode).value=="")
      {
        alert("���Ų���Ϊ��...");
        txtshow("Tel");
        document.getElementById(TelStateCode).focus();
        return false;
      }
      else
      {
           var filter = /^[0-9]+$/;
           if(!filter.test(document.getElementById(TelStateCode).value))
           {
             alert("���Ŵ���...");
             document.getElementById(TelStateCode).focus();
             return false;
           }
      }
  } 
  if(document.getElementById(Mobile).value!="")
  {
        if(isNaN(document.getElementById(Mobile).value)||document.getElementById(Mobile).value.length!=11)
        {
             alert("�ֻ�λ������ȷ...")
             txtshow("Mobile");
             document.getElementById(Mobile).focus();
              return false;
         }
  }
   var Email="<%=this.txtEmail.ClientID %>";
  if(document.getElementById(Email).value=="")
  {
         alert("�����ʼ�����Ϊ��...");
         txtshow("Email");
    	  document.getElementById(Email).focus();
	      return false;
  }
  else
  {
                var obj = document.getElementById(Email);
    	        var str = obj.value;
    	        var filter = /^[_a-zA-Z0-9\-]+(\.[_a-zA-Z0-9\-]*)*@[a-zA-Z0-9\-]+([\.][a-zA-Z0-9\-]+)+$/;
    	        if(!filter.test(str))
    	        {
    	            alert("�����ʼ���ʽ����...");
    	            txtshow("Email");
    	            document.getElementById(Email).focus();
	                return false;
    	        }

   }
      var WebSite="<%=this.txtWebSite.ClientID %>";
      if(document.getElementById(WebSite).value!="")
      { 
          var obj = document.getElementById(WebSite);
    	  var str = obj.value; 
    	  if(!IsURL(str))
    	  {
    	         alert("��ַ��ʽ����...");
    	         document.getElementById(WebSite).focus();
	             return false;
    	  }
      }
  
 }
 function IsURL(str_url){ 
  var strRegex = "^((https|http|ftp|rtsp|mms)?://)"  
        + "?(([0-9a-z_!~*'().&=+$%-]+: )?[0-9a-z_!~*'().&=+$%-]+@)?" //ftp��user@  
        + "(([0-9]{1,3}\.){3}[0-9]{1,3}" // IP��ʽ��URL- 199.194.52.184  
        + "|" // ����IP��DOMAIN�������� 
        + "([0-9a-z_!~*'()-]+\.)*" // ����- www.  
        + "([0-9a-z][0-9a-z-]{0,61})?[0-9a-z]\." // ��������  
        + "[a-z]{2,6})" // first level domain- .com or .museum  
        + "(:[0-9]{1,4})?" // �˿�- :80  
        + "((/?)|" // a slash isn't required if there is no file name  
        + "(/[0-9a-z_!~*'().;?:@&=+$,%#-]+)+/?)$";  
        var re=new RegExp(strRegex);  
        if (re.test(str_url)){ 
            return (true);  
        }else{  
            return (false);  
        } 
    } 

    </script>

    <div id="right_box">
        <div class="mainconbox">
            <div class="titled">
                <div class="left">
                    �����������󡪡�ȷ����ϵ��Ϣ
                </div>
                <div class="clear">
                </div>
            </div>
            <div>
                <font color="#FF0000">��ȷ��������ϵ��ʽ��ʵ����Ч������Ͷ�ʷ������޷�����ȡ����ϵ��</font></div>
            <div class="dottedlline">
            </div>
            <table class="tabbiank" cellspacing="0" cellpadding="0" border="1">
                <tbody>
                    <tr>
                        <td width="124" align="right" valign="top" bgcolor="#f7f7f7" style="height: 2px">
                            <span class="hong">*</span> ��Ŀ��λ���ƣ�</td>
                        <td valign="top" width="618">
                            <input id="txtCompanyName" class="show" onclick="txtshow('CompanyName')" type="text"
                                value="" style="width: 210px" runat="server" />
                            <a href="javascript:;" id="lnkCompanyName" onclick="txtshow('CompanyName')">�޸�</a></td>
                    </tr>
                    <tr>
                        <td align="right" valign="top" bgcolor="#f7f7f7">
                            <span class="hong">* </span>��ϵ��<b>��</b></td>
                        <td valign="top" width="618">
                            <input id="txtLinkMan" class="show" onclick="txtshow('LinkMan')" type="text" value=""
                                style="width: 210px" runat="server" />
                            <a href="javascript:;" id="lnkLinkMan" onclick="txtshow('LinkMan')">�޸�</a></td>
                    </tr>
                    <tr>
                        <td align="right" valign="top" bgcolor="#f7f7f7" style="height: 5px">
                            ְλ<b>��</b></td>
                        <td valign="top" width="618">
                            <input id="txtCareer" class="show" onclick="txtshow('Career')" type="text" value=""
                                style="width: 210px" runat="server" />
                            <a href="javascript:;" id="lnkCareer" onclick="txtshow('Career')">�޸�</a></td>
                    </tr>
                    <tr>
                        <td valign="top" align="right" bgcolor="#f7f7f7">
                            <span class="hong">*</span>�̶��绰<b>��</b></td>
                        <td valign="top" width="618">
                            <input id="txtTelStateCode" onclick="txtshow('Tel')" runat="server" class="show"
                                style="width: 40px">
                            <input id="txtTel" class="show" onclick="txtshow('Tel')" type="text" value="" style="width: 160px"
                                runat="server" />
                            <a href="javascript:;" id="lnkTel" onclick="txtshow('Tel')">�޸�</a></td>
                    </tr>
                    <tr>
                        <td valign="top" align="right" bgcolor="#f7f7f7">
                            �ֻ���</td>
                        <td class="nonepad" valign="middle">
                            <input id="txtMobile" class="show" onclick="txtshow('Mobile')" type="text" value=""
                                style="width: 210px" runat="server" />
                            <a href="javascript:;" id="lnkMobile" onclick="txtshow('Mobile')">�޸�</a></td>
                    </tr>
                    <tr>
                        <td valign="top" align="right" bgcolor="#f7f7f7">
                            <span class="hong">*</span>�������䣺</td>
                        <td class="nonepad" valign="middle">
                            <input id="txtEmail" class="show" onclick="txtshow('Email')" type="text" value=""
                                style="width: 210px" runat="server" />
                            <a href="javascript:;" id="lnkEmail" onclick="txtshow('Email')">�޸�</a></td>
                    </tr>
                    <tr>
                        <td valign="top" align="right" bgcolor="#f7f7f7">
                            ��Ŀ��λ��ϸ��ַ��</td>
                        <td class="nonepad" valign="middle">
                            <input id="txtAddress" type="text" value="" style="width: 210px" runat="server" /></td>
                    </tr>
                    <tr>
                        <td valign="top" align="right" bgcolor="#f7f7f7">
                            ��Ŀ��λ��ַ��</td>
                        <td class="nonepad" valign="middle">
                            <input id="txtWebSite" type="text" value="" style="width: 210px" runat="server" /></td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center" valign="middle" bgcolor="#FFFFFF">
                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="/images/button3.jpg"
                                OnClick="ImageButton1_Click" /></td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</asp:Content>
