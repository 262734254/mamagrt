<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestCreditorsRaised_Update.aspx.cs" Inherits="Publish_project_TestCreditorsRaised_Update" %>
<%@ Register Src="../../Controls/ZoneSelectControl.ascx" TagName="ZoneSelectControl"
    TagPrefix="uc1" %>
<%@ Register Src="../../Controls/SelectIndustryControl.ascx" TagName="SelectIndustryControl"
    TagPrefix="uc2" %>
    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
   <link href="../../css/publish.css" rel="stylesheet" type="text/css" />
 <link href="../../css/publishCaptal.css" rel="stylesheet" type="text/css" />
 <link href="../../css/index_fhy.css" rel="stylesheet" type="text/css" />
 <link href="../../css/common.css" rel="stylesheet" type="text/css" />
 <link href="../../css/right_fhy.css" rel="stylesheet" type="text/css" />
 <link href="../../img/member.css" rel="stylesheet" type="text/css" />
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
   
 
 <script language="javascript" type="text/javascript">

 function Addd()
 {
    var c="ctl00_ContentPlaceHolder1_"; 
 	   if(document.getElementById("txtProjectName").value=="")
	   {
	       alert("请填写项目标题");
	       document.getElementById("txtProjectName").focus();
	       return false;
	   }
	   if(document.getElementById("SelectIndustryControl1_sltIndustryName_Select").options.length==0)
	   {
	        alert("请选择所属行业");
	        document.getElementById("SelectId").focus();
	        return false;
	   }
	   if(document.getElementById("ZoneSelectControl1_hideProvince").value=="")
	   {
	          alert("请选择所属区域");
	          document.getElementById("zoneId").focus();
	          return false;
	   }
	   
	   if(document.getElementById("txtCapitalTotal").value=="")
	   {
	       alert("请填写可接收资本成本上限");
	       document.getElementById("txtCapitalTotal").focus();
	       return false;
	   }
	   
	    var  rdlValiditeTermID="<%=this.rblYqzjdwqk.ClientID %>";
	    if(GetCheckNum(rdlValiditeTermID.replace(/_/g,"$")) <= 0)
        {
           alert("还款保证不能为空！");
           document.getElementById("YqzjdwqkID").focus();
           return false;
        }
	   
	   var  rdlValiditeTermID="<%=this.rblXmyxqxx.ClientID %>";
	    if(GetCheckNum(rdlValiditeTermID.replace(/_/g,"$")) <= 0)
        {
           alert("项目有效期不能为空！");
           document.getElementById("XmyxqxxID").focus();
           return false;
        }
        
        var tb=document.getElementById("tbXmqxms");
         if(!checkByteLength(tb.value,50,1000))
	   {
	       alert("项目介绍字数请控制在50到1000字以内！,请检查！");
	       tb.focus();
	       return false;
	   }
        
        if(document.getElementById("txtCompanyName").value=="")
	   {
	       alert("请填写项目单位名称");
	       document.getElementById("txtCompanyName").focus();
	       return false;
	   }
	   
	   if(document.getElementById("txtLinkMan").value=="")
	   {
	       alert("请填写联系人");
	       document.getElementById("txtLinkMan").focus();
	       return false;
	   }
	   
	   var telzone=document.getElementById("txtTelStateCode") ;
	   var telNumber=document.getElementById("txtTel");
	   var telMobile=document.getElementById("txtMobile");
	    if(telNumber.value.length=="" && telMobile.value.length=="")
        {
            alert("手机和固定电话请至少填写一项");
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
       var email=document.getElementById("txtEmail");
        if(email.value=="")
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
        if(document.getElementById("ImageCode").value=="")
        {
             alert("请输入验证码");
             document.getElementById("ImageCode").focus();
             return false;
        }
         document.getElementById("imgLoding").style.display="block";
           
    } 
   function ChangeValidCode(id)
  {
     document.getElementById(id).src = "../../ValidateNumber.aspx?r="+Math.random();
  }

	function GetCheckNum(checkobjectname)
    {
        var truei2 = 0;
        checkobject = document.getElementsByName(checkobjectname);
        var inum = checkobject.length;
        if (isNaN(inum))
        {
	        inum = 0;
        }
        for(i=0;i<inum;i++){
	        if (checkobject[i].checked == 1){
		        truei2 = truei2 + 1;
	        }
        }
        return truei2;
    }
    //判断多少个汉字,限制汉字
    function checkByteLength(str,minlen,maxlen) 
    {
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
 </script>

   <div id="step1" style="display: block;">

        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td style="padding: 5px 10px;" class="f_14">
                    <span class="f_red strong">项目详细资料</span><span class="f_gray">（以下基本信息均为必填项）</span></td>
            </tr>
        </table>
        <table cellspacing="0" class="mem_tab1">
            <tr>
                <td class="tdbg" style="width: 145px">
                    <span class="f_red">*</span> <strong>项目标题：</strong></td>
                <td>
                    <input id="txtProjectName" style="width: 286px" runat="server"  maxlength="30" />
                    <span class="f_gray">标题最好控制在30个字以内</span></td>
            </tr>
            <tr>
                <td valign="top" class="tdbg" style="width: 145px">
                    <span class="f_red">*</span> <strong>所属行业：</strong></td>
                <td>
                    <span class="f_gray">
                        <uc2:SelectIndustryControl ID="SelectIndustryControl1" runat="server" />
                    </span>
                    <input name="SelectId" type="text" id="SelectId" style="width:0; border-color:#FFFFFF;border:1px solid #FFFFFF" />
                </td>
            </tr>
            <tr>
                <td class="tdbg" style="width: 145px">
                    <span class="f_red">*</span> <strong>所属区域：</strong></td>
                <td>
                    <uc1:ZoneSelectControl ID="ZoneSelectControl1" runat="server" />
                    <input name="ZoneId" type="text" id="zoneId" style="width:0; border-color:#FFFFFF;border:1px solid #FFFFFF" />
                </td>
            </tr>
            <tr>
                <td class="tdbg" style="width: 145px">
                    <span class="f_red">*</span> <strong>可接收资金成本上限：</strong></td>
                <td>
                    
                    <input id="txtCapitalTotal" type="text"  runat="server"  onkeyup="value=value.replace(/[^\d]/g,'') " />
                    万人民币&nbsp;
                </td>
            </tr>
            
            <tr>
                <td class="tdbg" style="width: 145px">
                    <span class="f_red">*</span> <strong>还款保证：</strong></td>
                <td>
                    <asp:RadioButtonList ID="rblYqzjdwqk" RepeatDirection="Horizontal"
                        RepeatLayout="Flow" runat="server">
                        <asp:ListItem Value="1">担保</asp:ListItem>
                        <asp:ListItem Value="2">抵押</asp:ListItem>
                        <asp:ListItem Value="3">信用</asp:ListItem>
                    </asp:RadioButtonList><input name="ZoneId" type="text" id="YqzjdwqkID" style="width:0; border-color:#FFFFFF;border:1px solid #FFFFFF" /></td>
            </tr>
            
            <tr>
                <td class="tdbg" style="width: 145px">
                    <span class="f_red">*</span> <strong>期限：</strong></td>
                <td>
                    发布之日起
                    <asp:RadioButtonList ID="rblXmyxqxx" runat="server" RepeatDirection="Horizontal"
                        RepeatLayout="Flow">
                    </asp:RadioButtonList>
                    <input name="ZoneId" type="text" id="XmyxqxxID" style="width:0; border-color:#FFFFFF;border:1px solid #FFFFFF" />
                    </td>
            </tr>
          
            <tr>
                <td valign="top" class="tdbg" style="width: 145px">
                    <span class="f_red">*</span><strong>项目介绍：</strong></td>
                <td>
                    <textarea id="tbXmqxms" rows="7" style="width: 80%;" runat="server"  ></textarea>
                    <br />
                    <span class="f_gray">项目内容越详细越有利于投资方了解您项目的具体情况，请尽量详尽完善！字数请控制在50到1000字以内！</span></td>
            </tr>
          
        </table>
       
    </div>
    <!--########### 第二步，确认联络方式 #########-->
    <div id="step2" >
        
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td class="f_14 f_red strong" style="padding: 5px 10px;">
                    联系方式确认</td>
            </tr>
        </table>
        <table cellspacing="0" class="mem_tab1">
            <tr>
                <td width="130" class="tdbg">
                    <span class="f_red">*</span> <strong>项目单位名称：</strong></td>
                <td>
                    <input id="txtCompanyName" class="show" type="text" style="width: 210px" runat="server"   maxlength="30" />&nbsp;
                    </td>
            </tr>
            <tr>
                <td class="tdbg">
                    <span class="f_red">*</span> <strong>联系人：</strong></td>
                <td>
                    <input id="txtLinkMan" class="show" type="text" style="width: 210px" runat="server"   maxlength="16" />&nbsp;
                </td>
            </tr>
            <tr>
                <td class="tdbg">
                    <strong>职位：</strong></td>
                <td>
                    <input id="txtCareer" class="show" type="text" style="width: 210px" runat="server"   maxlength="12" />
                </td>
            </tr>
            <tr>
                <td class="tdbg">
                    <span class="f_red"></span><strong>固定电话：</strong></td>
                <td>
                    固话
                    <input id="telArea1" type="text" maxlength="3" size="3" value="+86" runat="server" />
                    <input id="txtTelStateCode" type="text" maxlength="4" size="5" runat="server" />
                    <input id="txtTel" type="text" size="15" maxlength="8" runat="server"  />
                    <input id="telFg" type="text" size="5"  maxlength="5" runat="server" /></td>
            </tr>
            <tr>
                <td class="tdbg">
                    <span class="f_red"></span><strong>手机号码：</strong></td>
                <td>

                    <input id="txtMobile" class="show" maxlength="11" type="text" style="width: 210px"
                        runat="server" />&nbsp;
                    <span class="f_gray">（固定电话或手机至少填写一项）</span></td>
            </tr>
            <tr>
                <td class="tdbg">
                    <span class="f_red">*</span> <strong>电子邮箱：</strong></td>
                <td>
                    <input id="txtEmail" class="show" type="text" style="width: 210px" runat="server"  maxlength="40" />&nbsp;
                </td>
            </tr>
            <tr>
                <td class="tdbg">
                    <strong>详细地址：</strong></td>
                <td>
                    <input id="txtAddress" type="text" value="" style="width: 210px" runat="server"  maxlength="50"  /></td>
            </tr>
            <tr>
                <td class="tdbg">
                    <strong>单位网址：</strong></td>
                <td>
                    <input id="txtWebSite" type="text" value="" style="width: 210px" runat="server" maxlength="40"  /><span class="f_gray">例如：http://www.topfo.com</span>&nbsp;
                    </td>
            </tr>
            <tr>
                <td class="tdbg">
                    <span class="f_red">*</span> <strong>验证码：</strong>
                </td>
                <td>
                    <label>
                        <asp:TextBox ID="ImageCode" runat="server" Width="120px"></asp:TextBox>
                        <img id="validimg" src="../../ValidateNumber.aspx" onclick="this.src='../../ValidateNumber.aspx?temp=' + (new Date())"
                            alt="" />
                        <a href="javascript:" onclick="ChangeValidCode('validimg');return false;">换一张图片</a>
                        </label></td>
            </tr>
        </table>
         <table width="100%" cellspacing="0" style="text-align: center;">
            <tr>
                <td height="40">
                    <input type="checkbox" id="chkReadMe" checked="checked" />
                    我已阅读<span class="f_red"><a href="#">《拓富·中国招商投资网服务协议》</a> </span>
                </td>
            </tr>
        </table>
        <table width="100%" cellspacing="0" style="height: 50px; text-align: center;">
            <tr>
                <td>
                    <asp:Button ID="btnIssueOK" runat="server" Text="确认修改"  OnClientClick="return Addd();" OnClick="btnIssueOK_Click" />
                </td>
            </tr>
        </table>
    </div>
    <!--###########  第二步结束  #########-->
    
     <div id="imgLoding" Style="position: absolute;
            display:none;
            background-color: #A9A9A9; 
            top: 0px; 
            bottom:0px;
            left: 0px; 
            width: 100%; 
            height: 100%; 
            filter: alpha(opacity=60);">
            <div class="content">
                <p>
                    数据正在提交,请稍候...</p>
                <img src="../../img/img-loading.gif" alt="Loading..." /></div>
        </div>
    </form>
</body>
</html>
