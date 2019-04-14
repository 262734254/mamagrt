<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TEST4.aspx.cs" Inherits="offer_TEST4" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<style type="text/css">
        body{text-align:center;}
        .content{width:466px;height:300px;background:url(images/search_bg_03.jpg) no-repeat left top;margin:300px auto 0;text-align:center;padding-top:1000px;}
        .content p{line-height:30px;        }
        
    </style>  
<script type="text/javascript" language="javascript">
function checkByteLength(str,minlen,maxlen) {
	if (str == null) return false;
	var l = str.length;
	var blen = 0;
	for(i=0; i<l; i++) {
		if ((str.charCodeAt(i) & 0xff00) != 0) {
			blen ++;
		}
		blen ++;
	}
	if (blen > maxlen || blen < minlen) {
		return false;
	}
	return true;
} 

function validateArea(obj){
	var str1 = obj.value.trim();
	var str = tot(str1); 
	obj.value = str;
	if(str.length == 0){
    	return -1;
    }
	var patn = /^[\+0-9]+$/;
	if(!patn.test(str)) return 1;
	return 0; 
}

function validateNumber(obj){
	var str1 = obj.value.trim();
	var str = tot(str1); 
	obj.value = str;
	if(str.length == 0){
	    return -1;
	}
	var patn = /^[0-9,-\/]+$/;
	if(!patn.test(str)) return 1;
	return 0;
}
//联系人的检验
function checkLinkMan()
{
   var value = document.getElementById("<%=this.txtLinkMan.ClientID %>").value;
   var LinkID="<%=this.txtLinkMan.ClientID%>";
    if(!checkByteLength(value,1,20)){
        document.getElementById("splinkMan").innerHTML = "&nbsp;&nbsp;&nbsp;联系人姓名必须填写！";
        document.getElementById("splinkMan").className = "noteawoke";
        document.getElementById(LinkID).focus();
        return false;
    }
    else
    {
        document.getElementById("splinkMan").innerHTML = "";
        document.getElementById("splinkMan").className = "";
        return true;
    }   
}
//检查机构名称
function checkGovName()
{
   var value = document.getElementById("<%=this.txtGovName.ClientID %>").value;
    var GovNameID="<%=this.txtGovName.ClientID%>";
    if(!checkByteLength(value,1,30)){
        document.getElementById("SpGovName").innerHTML = "&nbsp;&nbsp;&nbsp;投资机构必须填写！";
        document.getElementById("SpGovName").className = "noteawoke";
        document.getElementById(GovNameID).focus();
        return false;
    }
    else
    {
        document.getElementById("SpGovName").innerHTML = "";
        document.getElementById("SpGovName").className = "";
        return true;
    }   
}
//验证网址
function CheckWeb()
{
  
       var strm1=document.getElementById("<%=this.txtWebSite.ClientID %>").value;
       var MailID1="<%=this.txtWebSite.ClientID %>";
       
       if(!IsURL(strm1)&& strm1 !="")
    	  {
    	document.getElementById("spWeb").innerHTML = "&nbsp;&nbsp;&nbsp;网址格式错误或含有非法字符!";
        document.getElementById("spWeb").className = "noteawoke";
        document.getElementById(MailID1).focus();
        return false;
       //alert("邮箱地址格式错误或含有非法字符!\n请检查！");
        }
      else
      {
         document.getElementById("spWeb").innerHTML = "";
        document.getElementById("spWeb").className = "";
        return true;
    }
    	  
}
//
function IsURL(str_url){ 
  var strRegex = "^((https|http|ftp|rtsp|mms)?://)"  
        + "?(([0-9a-z_!~*'().&=+$%-]+: )?[0-9a-z_!~*'().&=+$%-]+@)?" //ftp的user@  
        + "(([0-9]{1,3}\.){3}[0-9]{1,3}" // IP形式的URL- 199.194.52.184  
        + "|" // 允许IP和DOMAIN（域名） 
        + "([0-9a-z_!~*'()-]+\.)*" // 域名- www.  
        + "([0-9a-z][0-9a-z-]{0,61})?[0-9a-z]\." // 二级域名  
        + "[a-z]{2,6})" // first level domain- .com or .museum  
        + "(:[0-9]{1,4})?" // 端口- :80  
        + "((/?)|" // a slash isn't required if there is no file name  
        + "(/[0-9a-z_!~*'().;?:@&=+$,%#-]+)+/?)$";  
        var re=new RegExp(strRegex);  
        if (re.test(str_url)){ 
            return (true);  
        }else{  
            return (false);  
        } 
    } 

//电话号码
function CheckPhone()
 {
    
      var Mobile=document.getElementById("<%=this.txtTelNumber.ClientID %>").value;
       var MobileID="<%=this.txtTelNumber.ClientID %>";
       if(Mobile !="")
       {
        if( isNaN(Mobile) && Mobile.length !=11)
        {
             
           document.getElementById("spMobile").innerHTML = "格式错误或含有非法字符1";
           document.getElementById("spMobile").className = "noteawoke";
           document.getElementById(MobileID).focus();
            return false;
         }
           else  
         {
           document.getElementById("spMobile").innerHTML = "";
           document.getElementById("spMobile").className = "";
          
           return true;
         }
       }
       else
       {    document.getElementById("spMobile").innerHTML = "不能为空!";
            document.getElementById("spMobile").className = "noteawoke";
           return false;
       }
  }
//区号
function CheckQu()
{     
   var Mobile2=document.getElementById("<%=this.txtTelZoneCode.ClientID %>").value;
       var MobileID2="<%=this.txtTelZoneCode.ClientID %>";
       if(Mobile2 !="")
       {
        if( isNaN(Mobile2) && Mobile2.length !=11)
        {
             
           document.getElementById("spMobile2").innerHTML = "格式错误或含有非法字符2";
           document.getElementById("spMobile2").className = "noteawoke";
           document.getElementById(MobileID2).focus();
            return false;
         }
           else  
         {
           document.getElementById("spMobile2").innerHTML = "";
           document.getElementById("spMobile2").className = "";
          
           return true;
         }
       }
       else
       {
          document.getElementById("spMobile2").innerHTML = "不能为空!";
          document.getElementById("spMobile2").className = "noteawoke";
           return false;
       }
}


//手机
function CheckMobile()
{     
       var Mobile=document.getElementById("<%=this.txtMobile.ClientID %>").value;
       var MobileID="<%=this.txtMobile.ClientID %>";
       if(Mobile !="")
       {
        if( isNaN(Mobile) && Mobile.length !=11)
        {
             
           document.getElementById("spMobile1").innerHTML = "格式错误或含有非法字符3";
           document.getElementById("spMobile1").className = "noteawoke";
           document.getElementById(MobileID).focus();
            return false;
         }
           else  
         {
           document.getElementById("spMobile1").innerHTML = "";
           document.getElementById("spMobile1").className = "";
          
           return true;
         }
       }
       else
       { 
          document.getElementById("spMobile1").innerHTML = "不能为空!";
           document.getElementById("spMobile1").className = "noteawoke";
          return false;
         
       }
}


//邮箱
function CheckEmail()
{
    var strm=document.getElementById("<%=this.txtEmail.ClientID %>").value;
    var MailID="<%=this.txtEmail.ClientID %>";
    var regm = /^[a-zA-Z0-9_-]+@[a-zA-Z0-9_-]+(\.[a-zA-Z0-9_-]+)+$/;//验证Mail的正则表达式,^[a-zA-Z0-9_-]:开头必须为字母,下划线,数字,

   if (!strm.match(regm) && strm !="")

    {
        document.getElementById("spEmail").innerHTML = "&nbsp;&nbsp;&nbsp;邮箱地址格式错误或含有非法字符!";
        document.getElementById("spEmail").className = "noteawoke";
        document.getElementById(MailID).focus();
        return false;
       //alert("邮箱地址格式错误或含有非法字符!\n请检查！");
     }
    else
    {
         document.getElementById("spEmail").innerHTML = "";
        document.getElementById("spEmail").className = "";
        return true;
    }

}
function check()
{
 alert("asdsasda");
 if(document.getElementById("txtGovName").value=="")
	    {
	       alert("机构名称不能为空..");
	       document.getElementById("txtGovName").focus();
	       return false;
	    }
         if(document.getElementById("txtLinkMan").value=="")
	    {
	       alert("联系人不能为空..");
	       document.getElementById("txtLinkMan").focus();
	       return false;
	    }
	    if(document.getElementById("txtMobile").value.length=="" )
        {
            alert("手机号码不能为空");
             document.getElementById("txtMobile").focus();
            return false;
        }else
        {
            var filtMobile = /^(13|15|18)[0-9]{9}$/;
            if(!filtMobile.test(document.getElementById("txtMobile").value))
            {
                alert("请正确填写手机号码");
                document.getElementById("txtMobile").focus();
                return false;
            }
        }
        if(document.getElementById("txtEmail").value=="")
        {
           alert("请输入电子邮箱");
           document.getElementById("txtEmail").focus();
           return false;
        } else  
        {
            var filtEmial = /^[_a-zA-Z0-9\-]+(\.[_a-zA-Z0-9\-]*)*@[a-zA-Z0-9\-]+([\.][a-zA-Z0-9\-]+)+$/;
            if(!filtEmial.test(document.getElementById("txtEmail").value))
            {
       	         alert("电子邮箱格式不正确，请重新输入");
       	         document.getElementById("txtEmail").focus();
       	         return false;
       	     }
        }
           
         document.getElementById("imgLoding").style.display="block";
           
      
}

</script>
<body>
    <form id="form1" runat="server">
    <div class="mainconbox">
        <div class="titled">
            <div class="left">
                发布投资意向</div>
            <div class="right">
            </div>
            <div class="clear">
            </div>
        </div>
        <div class="blank6">
        </div>
        <div class="infozi" id="switchtext">
           <!--<span class="hong">您的投资意向基本资料已填写，接下来请确认联系人信息。</span></div>-->
            
            <table width="100%" height="60" border="0" cellpadding="0" cellspacing="0" style="text-align:center; line-height:20px; margin:15px 0;" class="f_14">
  <tr>
    <td width="130" class="strong">发布资源只需<span class="f_red">2</span>步：</td>
    <td width="125" style="background:url(images/member_bg1_off.gif) no-repeat;" >第一步<br />
      填写项目信息</td>
    <td width="50"><img src="images/member_icon1.gif" /></td>
    <td width="125" style="background:url(images/member_bg1_on.gif) no-repeat;" class="f_red strong">第二步<br />
      确认联系方式</td>
    <td>&nbsp;</td>
  </tr>
</table>


        <table border="0" cellpadding="0" cellspacing="0" class="tabbiank">
          <tr>
                <td align="right" bgcolor="#F7F7F7" style="width: 126px">
                    <span class="hong">*</span> <strong>投资机构名称：</strong></td>
                <td width="638">
                            <asp:TextBox ID='txtGovName' onchange="checkGovName()" Width="246px" runat="server" />
                    <span id="SpGovName"></span>
                </td>
            </tr>
          
            <tr>
                <td align="right" bgcolor="#F7F7F7" style="width: 126px">
                    <span class="hong">*</span> <strong>联系人：</strong></td>
                <td width="638">
                            <asp:TextBox ID='txtLinkMan' onchange="checkLinkMan()" Width="246px" runat="server" />
                    <span id="splinkMan"></span>
                </td>
            </tr>
             <tr>
                <td align="right" bgcolor="#F7F7F7" style="width: 126px">
                     <strong>职位：</strong></td>
                <td width="638">
                            <asp:TextBox ID='txtPosition'  Width="246px" runat="server" />
                    <span id="Span3"></span>
                </td>
            </tr>
            <tr>
                <td align="right" bgcolor="#F7F7F7" style="width:126px">
                    <span class="hong">*</span> <strong>固定电话：</strong></td>
                <td width="638" valign="top">
                    <menu class="menulw">
                        国家</menu>
                    <menu>
                        城市区号</menu>
                    <menu>
                        电话号码</menu>
                    <br />
                    <asp:TextBox ID="txtTelCountry" runat="server" size='4'>+86</asp:TextBox>
                    <asp:TextBox ID="txtTelZoneCode" runat="server" size='8' onchange="CheckQu()" />
                    <asp:TextBox ID="txtTelNumber" runat="server" size='8'  onchange="CheckPhone()" /><br/>
                    
                   
                    <span id="spMobile"></span>
                   
                     <span id="spMobile2"></span>
                    
                     
                </td>
                </tr>
                <tr>
               <td align="right" bgcolor="#F7F7F7" style="width:126px">
                    <span class="hong">*</span> <strong>手机：</strong></td>
                
                <td width="638">
                 <asp:TextBox ID='txtMobile' Width="127px" runat="server"  onchange="CheckMobile()"/>
                <span id="spMobile1"></span>
                </td>
                
            </tr>
            
            <tr id="trswitchpublish" name="trswitchpublish">
                <td align="right" bgcolor="#F7F7F7" style="width: 126px; height: 26px;">
                    <strong>电子邮箱：</strong></td>
                <td width="638" style="height: 26px">
                    <asp:TextBox ID="txtEmail" runat="server" size='18'
                        Width="269px" onchange="CheckEmail()"/>
                    <span id="spEmail" class="hui">请填写您最常用的电子邮箱</span>
                </td>
            </tr>
            <tr id="tr1" name="trswitchpublish">
                <td align="right" bgcolor="#F7F7F7" style="height: 44px; width: 126px;">
                    <strong>投资机构网址：</strong></td>
                <td width="638" style="height: 44px">
                    <asp:TextBox ID="txtWebSite" runat="server" size="18" Width="269px" onchange="CheckWeb()"  />
                    <span id="spWeb" class="hui">请填写您最常用的电子邮箱</span>
                    </td>
            </tr>
          <!--<tr id="tr2" name="trswitchpublish">
                <td align="right" bgcolor="#F7F7F7" style="width: 126px">
                    <strong>传 真</strong><strong>：</strong></td>
                <td width="638">
                    <menu class="menulw">
                        国家</menu>
                    <menu>
                        城市区号</menu>
                    <menu>
                        电话号码</menu>
                    <br />
                    <asp:TextBox ID="txtFaxCountry"  runat="server" size='4'>+86</asp:TextBox>
                    <asp:TextBox ID="txtFaxZoneCode"  runat="server" size='7' />
                    <asp:TextBox ID="txtFaxNumber"  runat="server" size='18' />
                    <span id="spFax"></span>
                </td>
   </tr>-->
              
            <tr id="tr3" name="trswitchpublish3">
                <td align="right" bgcolor="#F7F7F7" style="width: 126px">
                    <strong>投资机构地址：</strong></td>
                <td width="638">
                    <asp:TextBox ID="txtAddress" runat="server" size='18' Width="269px" /></td>
            </tr>
           <!-- <tr id="tr4" name="trswitchpublish">
                <td align="right" bgcolor="#F7F7F7" style="height: 26px; width: 126px;">
                    <strong>邮政编码：</strong></td>
                <td width="638" style="height: 26px">
                    <asp:TextBox ID="txtPostCode" runat="server" size='18' Width="72px" />
                </td>
            </tr>-->
            
   <%--         <tr id="tr5" name="trswitchpublish">
       <td align="right" bgcolor="#F7F7F7" style="height: 26px; width: 126px;">
      验证码：&nbsp;&nbsp;</td>
      <td width="638" style="height: 26px"> 
      <asp:TextBox ID="ImageCode"  runat="server" Width="120px"></asp:TextBox> <img src="../ValidateNumber.aspx"  onclick="this.src='../ValidateNumber.aspx?temp=' + (new Date())" />
       </td>
       </tr>--%>
       
        </table>
        <!--附加信息-->
        <div class="blank0">
        </div>
        <!--联系方式-->
        <div class="mbbuttom">
            <input type="button" value="都填好了，立即发布" class="setup" id="btn" runat="server" onclick=" check();" /></div>
    </div>
    </div>
     <div id="imgLoding" style="position: absolute; 
  display:none; background-color: #A9A9A9; 
  top: 0px; left: 0px; width: 100%;
   height:1000px; filter: 
   alpha(opacity=60);" runat="server">

               <div class="content">
                <p>
                    数据正在提交,请稍候...</p>
                <img src="../images/loading42.gif" alt="Loading" />
                </div>
   </div> >
    </form>
</body>
</html>
