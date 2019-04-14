<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestEquityRaised_Issue.aspx.cs" Inherits="Publish_project_TestEquityRaised_Issue" %>
<%@ Register Src="../../Controls/FilesUploadControl.ascx" TagName="FilesUploadControl"
    TagPrefix="uc4" %>
<%@ Register Src="../../Controls/ZoneSelectControl.ascx" TagName="ZoneSelectControl"
    TagPrefix="uc1" %>
<%@ Register Src="../../Controls/SelectIndustryControl.ascx" TagName="SelectIndustryControl"
    TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <link href="../../img/member.css" rel="stylesheet" type="text/css" />
    <link href="../../css/index_fhy.css" rel="stylesheet" type="text/css" />
    <link href="../../css/common.css" rel="stylesheet" type="text/css" />
    <link href="../../css/right_fhy.css" rel="stylesheet" type="text/css" />
    
    
<script language="javascript" type="text/javascript">

   function ChangeValidCode(id)
  {
     document.getElementById(id).src = "../../ValidateNumber.aspx?r="+Math.random();
  }



    function chkpost()
   {   
            var c="ctl00_ContentPlaceHolder1_";
            var kj="";
            var zt="";
            var obj="";
            
            //标题
            var ProjectName="txtProjectName";
            if(trim(document.getElementById(ProjectName).value)=="")
            {
                alert("项目标题不能为空...");
                document.getElementById(ProjectName).focus();
                return false;
            }
            
            //行业
     	           if(document.getElementById("SelectIndustryControl1_sltIndustryName_Select").options.length==0)
	           {
	                alert("请选择所属行业");
	                   document.getElementById("SelectIndustryControl1_sltIndustryName_all").focus();
	                return false;
	           }

            //区域
            if(document.getElementById("CountryListCN").value=="CN")
            {
                if(document.getElementById("ZoneSelectControl1_hideProvince").value=="")
                { 
                    alert("请选择省份...");
                    document.getElementById("provinceCN").focus();
                    return false;
                }
                if(document.getElementById("ZoneSelectControl1_hideCapitalCity").value=="")
                {
                    alert("请选择城市...");
                    document.getElementById("capitalCN").focus();
                    return false;
                }
            }
            
	            var  rdlValiditeTermID="<%=this.rblXmyxqxx.ClientID %>";
                if(GetCheckNum(rdlValiditeTermID.replace(/_/g,"$")) <= 0)
                    {
                       alert("项目有效期不能为空！");
                   
                       return false;
                    }
                 var CapitalTotal="txtCapitalTotal"
               if(document.getElementById("txtCapitalTotal").value=="")
	           {
	                  alert("投资总金额不能为空");
	                  document.getElementById("txtCapitalTotal").focus();
	                  return false;
	           }
	          //融资金额 rbtnCapital
            if(!ChkRbl("<%=this.rbtnCapital.ClientID %>","融资金额"))
            {
                return false ;
            }
              //资金使用计划
            var ProIntro="txtProIntro";
            obj=document.getElementById(ProIntro);
            if(!checkByteLength(obj.value,50,1200))
            {
                alert("填写资金使用计划.建议600字以内（不少于50字）");
                document.getElementById(ProIntro).focus();
                document.getElementById(ProIntro).select();
                return false  ;
            }
              
            //项目详细描述
            kj="txtXmqxms";
            obj=document.getElementById(kj);
            if(!checkByteLength(obj.value,50,1000))
            {
                alert("项目详细描述不得超过1000个汉字(不少于50字),请检查！");
                obj.focus();
                obj.select();
                return false;
            }
    if(document.getElementById("txtCompanyName").value=="")
	   {
	       alert("单位名字不能为空");
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
        var objWebSite = document.getElementById("txtWebSite").value;
		if(objWebSite !="")
		{
		    var filter =/^.*(.com|.cn|.com.cn|.org|.net)$/;	
            if (!filter.test(objWebSite))
             { 
                alert("网址填写不正确!");
			    document.getElementById("txtWebSite").focus();
                return false;
             }
		}
           
        if(document.getElementById("ImageCode").value=="")
        {
             alert("请输入验证码");
             document.getElementById("ImageCode").focus();
             return false;
        }

//               document.getElementById("imgLoding").style.display="";
        
  
     }
  function ValidErr()
   {
       
        alert('验证码错误,请重新输入！');
        document.getElementById("ImageCode").focus();
        document.getElementById("ImageCode").select();
   }
   
   function ChangeValidCode(id)
    {
           document.getElementById(id).src = "../../ValidateNumber.aspx?r="+Math.random();
    }
        
      function GetCheckNum(checkobjectname)
    {
	    var truei2 = 0;
	    var checkobject = document.getElementsByName(checkobjectname);
    //	var checkobject = eval("document.all." + checkobjectname + "");
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
    //----------------------END-----------------------------------
   

    //-------------------公用 ，选择checkbox------------------------
    function ChkRbl(kjID,kjName)
    {
        if(GetCheckBoxListCheckNum(kjID)<=0)
        {
            alert("请选择"+kjName);
            document.getElementById(kjID).focus();
            return false;
        }
        else
        {
            return true;
        }
    }
    function GetCheckBoxListCheckNum(checkobjectid)
    {
        var selectedItemCount = 0;
        var liIndex = 0;
        var currentListItem = document.getElementById(checkobjectid + '_' + liIndex.toString());
        while (currentListItem != null)
        {
            if (currentListItem.checked) selectedItemCount++;
            liIndex++;
            currentListItem = document.getElementById(checkobjectid + '_' + liIndex.toString());
        }
        return selectedItemCount;
    }
    //-------------------------------END----------------------------------
    
    
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
    
    
    
//////////////////////
//去除字符串两边空格的函数
//参数：mystr传入的字符串
//返回：字符串mystr
function trim(mystr){
while ((mystr.indexOf(" ")==0) && (mystr.length>1)){
mystr=mystr.substring(1,mystr.length);
}//去除前面空格
while ((mystr.lastIndexOf(" ")==mystr.length-1)&&(mystr.length>1)){
mystr=mystr.substring(0,mystr.length-1);
}//去除后面空格
if (mystr==" "){
mystr="";
}
return mystr;
}


//替换掉字符串空格
function repl(obj)
{
    if(obj.value.length>0)
    {
        obj.value=trim(obj.value);
    }
}
//////////////////////////
   </script>

</head>
<body>
    <form id="form1" runat="server">
    <div id="step1" style="display:block;">
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td style="padding:5px 10px; height: 30px;" class="f_14 strong">
      <asp:RadioButton ID="RadioButton1" GroupName="group1" Text="股权融资" Checked="true" runat="server" AutoPostBack="True" />
      <asp:RadioButton ID="RadioButton2" GroupName="group1" Text="债权融资" runat="server" OnCheckedChanged="RadioButton2_CheckedChanged" AutoPostBack="True" />
      </td>
  </tr>
</table>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td style="padding:5px 10px;" class="f_14"><span class="f_red strong">项目详细资料</span><span class="f_gray">（以下基本信息均为必填项）</span></td>
  </tr>
</table>
<table cellspacing="0" class="mem_tab1">
  <tr>
    <td class="tdbg" style="width: 135px"><span class="f_red">*</span> <strong>项目标题：</strong></td>
    <td><input id="txtProjectName" style="width: 286px" size="15" runat="server" maxlength="30"  onblur="repl(this);"/>
      <span class="f_gray">标题最好控制在30个字以内</span></td>
  </tr>
  <tr>
    <td valign="top" class="tdbg" style="width: 135px"><span class="f_red">*</span> <strong>所属行业：</strong></td>
    <td>
      <span class="f_gray">
          <uc2:SelectIndustryControl ID="SelectIndustryControl1" runat="server" />
          </span></td>
  </tr>
  <tr>
    <td class="tdbg" style="width: 135px"><span class="f_red">*</span> <strong>所属区域：</strong></td>
    <td>
        <uc1:ZoneSelectControl ID="ZoneSelectControl1" runat="server" />
    </td>
  </tr>
  <tr>
    <td class="tdbg" style="width: 135px"><span class="f_red">*</span> <strong>项目投资总额：</strong></td>
    <td>
        <input id="txtCapitalTotal" type="text"  runat="server" maxlength="15"  width="75px"  onblur="repl(this);" onkeyup="value=value.replace(/[^\d]/g,'') "  />
                            万人民币
    </td>
  </tr>
  <tr>
    <td class="tdbg" style="width: 135px"><span class="f_red">*</span> <strong>融资金额：</strong></td>
    <td>
	<asp:RadioButtonList ID="rbtnCapital" runat="server" RepeatDirection="Horizontal"
                                RepeatLayout="Flow">
                            </asp:RadioButtonList> </td>
  </tr>
 
  <tr>
    <td class="tdbg" style="width: 135px"><span class="f_red">*</span> <strong>项目有效期限：</strong></td>
    <td>发布之日起
        <asp:RadioButtonList ID="rblXmyxqxx" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
        </asp:RadioButtonList>
        </td>
  </tr>
  <tr>
    <td valign="top" class="tdbg" style="width: 135px"><span class="f_red">*</span> <strong>资金使用计划：</strong></td>
    <td><textarea id="txtProIntro" runat="server" cols="50" style="width: 558px; height: 153px" onblur="repl(this);" ></textarea><span
                                id="spProIntro"></span>
        <br />
      <span class="f_gray">为吸引投资方的关注，请对项目重点内容进行简单、清晰的描述，建议600字以内（不少于50字）！</span></td>
  </tr>
  <tr>
    <td valign="top" class="tdbg" style="width: 135px"><span class="f_red">*</span> <strong>项目详细描述：</strong></td>
    <td><textarea id="txtXmqxms" runat="server" cols="50" style="width: 558px; height: 149px" onblur="repl(this);"></textarea>
        <br />
    <span class="f_gray">项目内容越详细越有利于投资方了解您项目的具体情况，请尽量详尽完善！建议1000字以内（不少于50字）！</span></td>
  </tr>
 
</table>

<table cellspacing="0" class="mem_tab1">
  
  <tr>
    <td valign="top" class="tdbg"> <strong>管理团队：</strong></td>
    <td><textarea id="txtManageTeamAbout" cols="50"  rows="5" style="width:80%" runat="server" onblur="repl(this);"></textarea>
    <br />
    <span class="f_gray">团队架构、高管人员的从业经历等。建议1000字以内（不少于30字）！</span></td>
  </tr>
  <tr>
    <td valign="top" class="tdbg"><strong>项目资料附件：</strong></td>
    <td>
        <uc4:FilesUploadControl ID="FilesUploadControl1" runat="server" />
    </td>
       <span class="f_gray">
      
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
                    <input id="txtCompanyName" class="show" type="text" style="width: 210px" runat="server" maxlength="30"  onblur="repl(this);" />&nbsp;
                    </td>
            </tr>
            <tr>
                <td class="tdbg">
                    <span class="f_red">*</span> <strong>联系人：</strong></td>
                <td>
                    <input id="txtLinkMan" class="show" type="text" style="width: 210px" runat="server" maxlength="16"  onblur="repl(this);"  />&nbsp;
                </td>
            </tr>
            <tr style="display:none">
                <td class="tdbg">
                    <strong>职位：</strong></td>
                <td>
                    <input id="txtCareer" class="show" type="text" style="width: 210px" runat="server" maxlength="12"   onblur="repl(this);" />
                </td>
            </tr>
            <tr>
                <td class="tdbg">
                    <span class="f_red">*</span> <strong>联系电话：</strong></td>
                <td>
                    固话
                    <input id="telArea1" type="text" size="3" value="+86" runat="server" />
                    区号<input id="txtTelStateCode" maxlength="4" type="text" size="5" runat="server" />
                    电话号码<input id="txtTel" type="text" maxlength="8" size="15" runat="server"  />
                    分机号<input id="telFg" type="text" maxlength="5" size="5" runat="server" />&nbsp;
     <span class="f_gray">（固定电话或手机至少填写一项）</span></td>
            </tr>
            <tr>
                <td class="tdbg">
                    手机：</td>
                <td>
                       <input id="txtMobile" class="show" maxlength="11" type="text" style="width: 210px"
                        runat="server" />&nbsp;</td>
            </tr>
            <tr>
                <td class="tdbg">
                    <span class="f_red">*</span> <strong>电子邮箱：</strong></td>
                <td>
                    <input id="txtEmail" class="show" type="text" style="width: 210px" runat="server" maxlength="40"   onblur="repl(this);" />&nbsp;
                </td>
            </tr>
            <tr>
                <td class="tdbg">
                    <strong>项目单位详细地址：</strong></td>
                <td>
                    <input id="txtAddress" type="text" value="" style="width: 210px" runat="server" maxlength="50"  onblur="repl(this);"  /></td>
            </tr>
            <tr>
                <td class="tdbg">
                    <strong>单位网址：</strong></td>
                <td>
                    <input id="txtWebSite" type="text" value="" style="width: 210px" runat="server" maxlength="40"   onblur="repl(this);" /><span class="f_gray">例如：http://www.topfo.com</span>&nbsp;
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
        <table width="100%" cellspacing="0" style="height: 60px; text-align: center;">
            <tr>
                <td>
                   <%-- <input id="Button1" type="button" value="上一步(修改项目信息)" onclick="disp(2);" />--%>
                    <asp:Button ID="btnIssueOK" runat="server" Text="确认发布" OnClientClick="return chkpost();" OnClick="btnIssueOK_Click" />
                </td>
            </tr>
        </table>
        <table width="100%" cellspacing="0" style="text-align:center;">
  <tr style="display:none">
    <td style="height: 40px">
    <input type="checkbox" id="chkReadMe"  checked="checked" />
    我已阅读<span class="f_red"><a href="#">《拓富·中国招商投资网服务协议》</a></span></td>
  </tr>
  <%--<tr>
    <td>
        <input id="btnNext"  type="button" value="下一步：确认联系方式" onclick="chkpost();" />
        </td>
  </tr>--%>
</table>
<%--    </div>
<div id="imgLoding" Style="position: absolute;
            display:none;
            background-color: #A9A9A9; 
            top: 0px; 
            bottom:0px;
            left: 0px; 
            width: 100%; 
            height: 271%; 
            filter: alpha(opacity=60);">
            <div class="content">
                <p>
                    数据正在提交,请稍候...</p>
                <img src="../../img/img-loading.gif" alt="Loading..." /></div>
        </div>--%>
    </form>
</body>
</html>
