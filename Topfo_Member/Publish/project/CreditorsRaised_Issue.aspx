<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CreditorsRaised_Issue.aspx.cs" Inherits="Publish_project_CreditorsRaised_Issue" Title="Untitled Page" ValidateRequest="false"%>
<%@ Register Src="../../Controls/ZoneSelectControl.ascx" TagName="ZoneSelectControl"
    TagPrefix="uc1" %>
<%@ Register Src="../../Controls/SelectIndustryControl.ascx" TagName="SelectIndustryControl"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<link href="../../css/publish.css" rel="stylesheet" type="text/css" />
  <link href="../../offer/css/member.css"rel="stylesheet" type="text/css" />
  <script src="../../offer/js/yanz.js"></script>
    <style type="text/css">
       
        .llll{width:466px;height:300px;background:url(images/search_bg_03.jpg) no-repeat left top;margin:300px auto 0;text-align:center;padding-top:800px;}
       </style>
<script language="javascript" type="text/javascript">

  function ChangeValidCode(id)
  {
     document.getElementById(id).src = "../../ValidateNumber.aspx?r="+Math.random();
  }

 function Addd()
 {
    var c="ctl00_ContentPlaceHolder1_"; 
 	   if(document.getElementById(c+"txtProjectName").value=="")
	   {
	       alert("请填写项目标题");
	       document.getElementById(c+"txtProjectName").focus();
	       return false;
	   }

	   if(document.getElementById(c+"SelectIndustryControl1_sltIndustryName_Select").options.length==0)
	   {
	        alert("请选择所属行业");
	           document.getElementById(c+"SelectIndustryControl1_sltIndustryName_all").focus();
	        return false;
	   }
	   if(document.getElementById(c+"ZoneSelectControl1_hideProvince").value=="")
	   {
	          alert("请选择所属区域");
	        document.getElementById(c+"SelectIndustryControl1_sltIndustryName_all").focus();
	          return false;
	   }
	   
	   if(document.getElementById(c+"txtCapitalTotal").value=="")
	   {
	       alert("请填写可接收资本成本上限");
	       document.getElementById(c+"txtCapitalTotal").focus();
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
        
//        var tb=document.getElementById(c+"tbXmqxms");
         if(document.getElementById(c+"tbXmqxms").value=="")
	   {
	       alert("项目介不能为空！");
	       tb.focus();
	       return false;
	   }
        
        if(document.getElementById(c+"txtCompanyName").value=="")
	   {
	       alert("请填写项目单位名称");
	       document.getElementById(c+"txtCompanyName").focus();
	       return false;
	   }
	   
	   if(document.getElementById(c+"txtLinkMan").value=="")
	   {
	       alert("请填写联系人");
	       document.getElementById(c+"txtLinkMan").focus();
	       return false;
	   }
	   
	   var telzone=document.getElementById(c+"txtTelStateCode") ;
	   var telNumber=document.getElementById(c+"txtTel");
	   var telMobile=document.getElementById(c+"txtMobile");
	    if(telNumber.value.length=="" && telMobile.value.length=="")
        {
            alert("手机和固定电话请至少填写一项");
             document.getElementById(c+"txtMobile").focus();
            return false;
        }
        if(document.getElementById(c+"txtMobile").value.length!="")
        {
           var filtMobile = /^(13|15|18)[0-9]{9}$/;
            if(!filtMobile.test(trim(document.getElementById(c+"txtMobile").value)))
            {
                alert("请正确填写手机号码");
                document.getElementById(c+"txtMobile").focus();
                return false;
            }
        }
        var email=document.getElementById(c+"txtEmail");
        if(email.value=="")
        {
           alert("请输入电子邮箱");
           document.getElementById(c+"txtEmail").focus();
           return false;
        } else  
        {
            var filtEmial = /^[_a-zA-Z0-9\-]+(\.[_a-zA-Z0-9\-]*)*@[a-zA-Z0-9\-]+([\.][a-zA-Z0-9\-]+)+$/;
            if(!filtEmial.test(trim(document.getElementById(c+"txtEmail").value)))
            {
       	         alert("电子邮箱格式不正确，请重新输入");
       	         document.getElementById(c+"txtEmail").focus();
       	         return false;
       	     }
        }
               var objWebSite = document.getElementById(c+"txtWebSite").value;
		if(objWebSite !="")
		{
		    var filter =/^.*(.com|.cn|.com.cn|.org|.net)$/;	
            if (!filter.test(trim(objWebSite)))
             { 
                alert("网址填写不正确!");
			    document.getElementById(c+"txtWebSite").focus();
                return false;
             }
		}
          var inputCode = document.getElementById("validCode").value;   
       if(inputCode.length <=0)   
       {   
           alert("请输入验证码！"); 
            document.getElementById("validCode").focus();
       	         return false;  
       }   
       else if(inputCode.toUpperCase() != code )   
       {   
          alert("验证码输入错误！");   
          createCode();//刷新验证码   
           document.getElementById("validCode").focus();
       	         return false;
       }   
               
//       if(document.getElementById(c+"ImageCode").value !='<%=Session["valationNo"] %>')

//    {  
//          alert('验证码错误,请重新输入11111111！');
//          return false
////        document.getElementById(c+"ImageCode").focus();
////        document.getElementById(c+"ImageCode").select();
//    }
        document.getElementById(c+"imgLoding").style.display="";
           
    } 
      function ValidErr()
   {
       
        alert('验证码错误,请重新输入！');
        document.getElementById(c+"ImageCode").focus();
        document.getElementById(c+"ImageCode").select();
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
 </script>
 <div class="member-right">
    <div class="publication">
      <h1><span class="fl"><span class="f_14px strong f_cen">发布债权融资需求</span>(带<span class="hong">*</span>为必填项)</span><span class="fr"><img src="http://img2.topfo.com/member/images/biao_01.gif" align="absMiddle"/> <a href="http://www.topfo.com/help/demandrelease.shtml#16" class="publica-fbxq">需求发布规则</a></span></h1>
        <table width="100%"  cellpadding="0" cellspacing="0"  class="publica">
        <tr>
            <td style="text-align:left; font-size:14px; color:#333" colspan="2">
                <asp:RadioButton ID="RadioButton1" GroupName="group1" Text="股权融资" runat="server"
                    OnCheckedChanged="RadioButton1_CheckedChanged" AutoPostBack="True" />
                <asp:RadioButton ID="RadioButton2" GroupName="group1" Text="债权融资" Checked="true"
                    runat="server" /></td>
            </tr>
      <tr>
        <td class="publica-td-left" ><span class="hong">*</span>项目标题：</td>
        <td>
        <input id="txtProjectName" style="width: 286px" runat="server"  maxlength="30" />
                    <span class="f_gray">标题最好控制在30个字以内</span>
        </td>
      </tr>
      <tr>
        <td class="publica-td-left" ><span class="hong">*</span>所属行业：</td>
        <td style="height: 22px">
           <uc2:SelectIndustryControl ID="SelectIndustryControl1" runat="server" />
           <input name="SelectId" type="text" id="SelectId" style="width:0; border-color:#FFFFFF;border:1px solid #FFFFFF" />
    </td>
      </tr>
      <tr>
        <td class="publica-td-left" ><span class="hong">*</span>所属区域：</td>
        <td>
        <uc1:ZoneSelectControl ID="ZoneSelectControl1" runat="server" />
        <input name="ZoneId" type="text" id="zoneId" style="width:0; border-color:#FFFFFF;border:1px solid #FFFFFF" />
    </td>
      </tr>
      <tr>
          <td class="publica-td-left" >
          <span class="hong">*</span>可接收资金成本上限：</td>
                <td> 
                <input id="txtCapitalTotal" type="text"  runat="server"  onkeyup="value=value.replace(/[^\d]/g,'') " />
                    万人民币
                </td>
          </tr>
            <tr>
              <td class="publica-td-left">
              <span class="hong">*</span>还款保证：</td>
                <td><asp:RadioButtonList ID="rblYqzjdwqk" RepeatDirection="Horizontal"
                        RepeatLayout="Flow" runat="server">
                        <asp:ListItem Value="1">担保</asp:ListItem>
                        <asp:ListItem Value="2">抵押</asp:ListItem>
                        <asp:ListItem Value="3">信用</asp:ListItem>
                    </asp:RadioButtonList><input name="ZoneId" type="text" id="YqzjdwqkID" style="width:0; border-color:#FFFFFF;border:1px solid #FFFFFF" />
                      </td>
            </tr>
            <tr>
                <td class="publica-td-left">
                    <span class="hong">*</span>期限：</td>
                <td>
                    发布之日起
                    <asp:RadioButtonList ID="rblXmyxqxx" runat="server" RepeatDirection="Horizontal"
                        RepeatLayout="Flow">
                    </asp:RadioButtonList>
                    <input name="ZoneId" type="text" id="XmyxqxxID" style="width:0; border-color:#FFFFFF;border:1px solid #FFFFFF" />
                    </td>
            </tr>
            <tr>
             <td class="publica-td-left" >
                    <span class="hong">*</span> 项目介绍：</td>
                <td width="618">
                    <textarea id="tbXmqxms" style="width: 80%; height: 142px;" runat="server"  ></textarea>
                    </td>
            </tr>

            <tr>
            <td colspan="2">
            <span class="f_14px strong f_cen">联系人详细信息</span>
            </td>
            </tr>
            
       <tr>
        <td class="publica-td-left" >
            <span class="hong">*</span> 项目单位名称：</td>
        <td >
            <input id="txtCompanyName" type="text" style="width: 210px" runat="server"   maxlength="30" />
            </td>
       </tr>
      <tr>
        <td class="publica-td-left" >
            <span class="hong">*</span>联系人：</td>
        <td >
            <input id="txtLinkMan" type="text" style="width: 210px" runat="server"   maxlength="16" />
        </td>
      </tr>
     
    <tr>
        <td class="publica-td-left" >
            <span class="hong">*</span>联系电话：</td>
        <td >
           固话
            <input id="telArea1" type="text" maxlength="3" size="3" value="+86" runat="server"  />
            <input id="txtTelStateCode" type="text" maxlength="4" size="5" onkeyup="value=value.replace(/[^\d]/g,'') " runat="server" />
            <input id="txtTel" type="text" size="15" maxlength="8" onkeyup="value=value.replace(/[^\d]/g,'') " runat="server"  />
            <input id="telFg" type="text" size="5"  maxlength="5"  runat="server" visible="false" /><span class="f_gray">（如：+86-0755-89805588）</span>  
        </td>
    </tr>
    <tr >
        <td class="publica-td-left" >
            手机：</td>
        <td >
            <input id="txtMobile" class="show" maxlength="11" type="text" style="width: 210px"
                       onkeyup="value=value.replace(/[^\d]/g,'') " runat="server" />
            <span id="Span1" class="hui">（固定电话或手机至少填写一项）</span> 
        </td>
    </tr>
    <tr >
        <td class="publica-td-left" >
           <span class="hong">*</span> 电子邮箱：</td>
        <td >
            <input id="txtEmail" type="text" style="width: 210px" runat="server"  maxlength="40" />
            <span id="spEmail" class="hui">请填写您最常用的电子邮箱</span> 
        </td>
    </tr>
    <tr >
        <td class="publica-td-left" >
            联系地址：</td>
        <td >
            <input id="txtAddress" type="text" value="" style="width: 210px" runat="server"  maxlength="50"  /></td>
    </tr>
     <tr>
       <td class="publica-td-left" >
         单位网址：
       </td>
     
      <td><input id="txtWebSite" type="text" value="" style="width: 210px" runat="server" maxlength="40"  />
      </td>
      </tr>
    <tr>
       <td class="publica-td-left">
      验证码：</td>
      <td>
      <input  type="text"   id="validCode" /> 
                   <input type="text" onClick="createCode()" readonly="readonly" id="checkCode" class="unchanged" style="width: 80px;cursor:pointer"  />
       </td>
       
       </tr>
            <tr>
            <td colspan="2" id="pub-tongyi">
             <input name="" type="checkbox" value="" checked />
             <a href="http://www.topfo.com/ServiceItem/ServiceItem.shtml" class="publica-fbxq" >我已阅读并同意《拓富中国招商投资网服务协议》</a>  <br />
              <asp:ImageButton ID="btnIssueOK"  OnClientClick="return Addd();" ImageUrl="http://img2.topfo.com/member/images/member-btn-tj.jpg" runat="server"
                OnClick="btnIssueOK_Click"  />
               </td>
            </tr>
</table>

    </div>
      </div>
            <div id="imgLoding" style="position: absolute; 
  display:none; background-color: #A9A9A9; 
  top: 0px; left: 0px; width: 100%;
   height:2500px; filter: 
   alpha(opacity=60);" runat="server">

               <div class="llll">
                <p>
                    数据正在提交,请稍候...</p>
                <img src="http://member.topfo.com/images/loading42.gif" alt="Loading" />
                </div>
   </div> 
      <script language="javascript">  createCode();</script>
</asp:Content>

