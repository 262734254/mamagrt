<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EquityRaised_Update.aspx.cs" Inherits="Publish_project_EquityRaised_Update" Title="Untitled Page" %>
<%@ Register Src="../../Controls/FilesUploadControl.ascx" TagName="FilesUploadControl"
    TagPrefix="uc4" %>
<%@ Register Src="../../Controls/ZoneSelectControl.ascx" TagName="ZoneSelectControl"
    TagPrefix="uc1" %>
<%@ Register Src="../../Controls/SelectIndustryControl.ascx" TagName="SelectIndustryControl"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<style type="text/css">
       
        .llll{width:466px;height:300px;background:url(images/search_bg_03.jpg) no-repeat left top;margin:300px auto 0;text-align:center;padding-top:800px;}
       </style>
<script language="javascript" type="text/javascript">
    function chkpost()
   {   
               var c="ctl00_ContentPlaceHolder1_";
            var kj="";
            var zt="";
            var obj="";
            
            //标题
            var ProjectName=c+"txtProjectName";
            if(trim(document.getElementById(ProjectName).value)=="")
            {
                alert("项目标题不能为空...");
                document.getElementById(ProjectName).focus();
                return false;
            }
            
            //行业
     	           if(document.getElementById(c+"SelectIndustryControl1_sltIndustryName_Select").options.length==0)
	           {
	                alert("请选择所属行业");
	                   document.getElementById(c+"SelectIndustryControl1_sltIndustryName_all").focus();
	                return false;
	           }

          
             //区域
            if(document.getElementById("CountryListCN").value=="CN")
            {
                if(document.getElementById(c+"ZoneSelectControl1_hideProvince").value=="")
                { 
                    alert("请选择省份...");
                    document.getElementById("provinceCN").focus();
                    return false;
                }
                if(document.getElementById(c+"ZoneSelectControl1_hideCapitalCity").value=="")
                {
                    alert("请选择城市...");
                    document.getElementById("capitalCN").focus();
                    return false;
                }
            }
            

        //项目有效期限 rblXmyxqxx
          	   var  rdlValiditeTermID="<%=this.rblXmyxqxx.ClientID %>";
	    if(GetCheckNum(rdlValiditeTermID.replace(/_/g,"$")) <= 0)
        {
           alert("项目有效期不能为空！");
       
        document.getElementById("XmyxqxxID").focus();
           return false;
        }
            
                 var CapitalTotal=c+"txtCapitalTotal"
               if(document.getElementById(c+"txtCapitalTotal").value=="")
	           {
	                  alert("投资总金额不能为空");
	                  document.getElementById(c+"txtCapitalTotal").focus();
	                  return false;
	           }
    	   var  rdlValiditeTermID="<%=this.rbtnCapital.ClientID %>";
	        if(GetCheckNum(rdlValiditeTermID.replace(/_/g,"$")) <= 0)
            {
               alert("融资金额不能为空！");
           
            document.getElementById("rzje").focus();
               return false;
            }
              //资金使用计划
          
            if(document.getElementById(c+"txtProIntro").value=="")
            {
                alert("填写资金使用计划.");
                document.getElementById(c+"txtProIntro").focus();
                document.getElementById(c+"txtProIntro").select();
                return false  ;
            }
              
            //项目详细描述

            if(document.getElementById(c+"txtXmqxms").value=="")
            {
                alert("项目详细描述不能为空！");
                 document.getElementById(c+"txtXmqxms").focus();
          
                return false;
            }
    if(document.getElementById(c+"txtCompanyName").value=="")
	   {
	       alert("单位名字不能为空");
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
       document.getElementById("imgLoding").style.display="";
  
     }
  function ValidErr()
   {
       
        alert('验证码错误,请重新输入！');
        document.getElementById(c+"ImageCode").focus();
        document.getElementById(c+"ImageCode").select();
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
   <div class="member-right">
    <div class="publication">
      <h1><span class="fl"><span class="f_14px strong f_cen">融资项目详细资料</span>(带<span class="hong">*</span>为必填项)</span><span class="fr"><img src="http://img2.topfo.com/member/images/biao_01.gif" align="absMiddle"/> <a href="http://www.topfo.com/help/demandrelease.shtml#16" class="publica-fbxq">需求发布规则</a></span></h1>
        <table width="100%"  cellpadding="0" cellspacing="0"  class="publica">
      <tr>
        <td class="publica-td-left" ><span class="hong">*</span>项目标题：</td>
        <td><input id="txtProjectName" style="width: 286px" size="15" runat="server" />
                    <span class="f_gray">标题最好控制在25个字以内</span></td>
      </tr>
      <tr>
        <td class="publica-td-left" ><span class="hong">*</span>所属行业：</td>
        <td>
        <uc2:SelectIndustryControl ID="SelectIndustryControl1" runat="server" />
    </td>
      </tr>
      <tr>
        <td class="publica-td-left" ><span class="hong">*</span>所属区域：</td>
        <td>
        <uc1:ZoneSelectControl ID="ZoneSelectControl1" runat="server" />
    </td>
      </tr>
      <tr>
          <td class="publica-td-left" >
          <span class="hong">*</span>项目投资总额：</td>
                <td><asp:TextBox ID="txtCapitalTotal" MaxLength="15" runat="server" Width="75px" onkeyup="value=value.replace(/[^\d]/g,'') "> </asp:TextBox>
                    万人民币
                     </td>
          </tr>
            <tr>
              <td class="publica-td-left">
              <span class="hong">*</span>融资金额：</td>
                <td><asp:RadioButtonList ID="rbtnCapital" runat="server" RepeatDirection="Horizontal"
                        RepeatLayout="Flow">
                    </asp:RadioButtonList>
                      </td>
            </tr>
            <tr>
             <td class="publica-td-left" >
                    <span class="hong">*</span> 项目有效期限：</td>
                <td width="618">
                    发布之日起
                    <asp:RadioButtonList ID="rblXmyxqxx" runat="server" RepeatDirection="Horizontal"
                        RepeatLayout="Flow">
                    </asp:RadioButtonList>
                    </td>
            </tr>
            <tr>
             <td class="publica-td-left" >
                    <span class="hong">*</span> 资金使用计划：</td>
                <td width="618">
                    <textarea id="txtProIntro" runat="server" rows="5" cols="50" style="width: 558px;
                        height: 215px"></textarea><span id="spProIntro"></span>
                    </td>
            </tr>
            <tr>
             <td class="publica-td-left" >
                    <span class="hong">*</span> 项目详细描述：</td>
                <td width="618">
                    <textarea id="txtXmqxms" runat="server" rows="7" cols="50" style="width: 558px; height: 215px"></textarea>
                    </td>
            </tr>
            <tr>
             <td class="publica-td-left" >
                    <span class="hong">*</span> 管理团队：</td>
                <td width="618">
                    <textarea id="txtManageTeamAbout" cols="50" rows="5" style="width: 80%" runat="server"></textarea>
                    </td>
            </tr>
          <tr>
          <td class="publica-td-left" valign="top" >
            上传图片：</td>
                <td class="nonepad" valign="top" width="618">
                <uc4:FilesUploadControl ID="FilesUploadControl1" runat="server" />
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
            <input id="txtCompanyName"  type="text" style="width: 210px" runat="server" />
            </td>
       </tr>

      <tr>
        <td class="publica-td-left" >
            <span class="hong">*</span>联系人：</td>
        <td >
          
            <input id="txtLinkMan"  type="text" style="width: 210px" runat="server" />
        </td>
      </tr>

    <tr>
        <td class="publica-td-left" >
            <span class="hong">*</span>联系电话：</td>
        <td >
           固话
            <input id="telArea1" type="text" size="3" value="+86" runat="server" />
            <input id="txtTelStateCode" type="text" size="5" runat="server" />
            <input id="txtTel" type="text" size="15" runat="server" />
            <input id="telFg" type="text" size="5" runat="server" visible="false"  />   
             <span class="f_gray">（如：+86-0755-89805588）</span>    
        </td>
    </tr>
    <tr >
        <td class="publica-td-left" >
            手机：</td>
        <td >
            <input id="txtMobile" class="show" maxlength="11" type="text" style="width: 210px"
                        runat="server" />
            <span id="Span1" class="hui">（固定电话或手机至少填写一项）</span> 
        </td>
    </tr>
    <tr >
        <td class="publica-td-left" >
            <span class="hong">*</span> 电子邮箱：</td>
        <td >
            <input id="txtEmail" class="show" type="text" style="width: 210px" runat="server" />
            <span id="spEmail" class="hui">请填写您最常用的电子邮箱</span> 
        </td>
    </tr>
    <tr >
        <td class="publica-td-left" >
            联系地址：</td>
        <td >
             <input id="txtAddress" type="text" value="" style="width: 210px" runat="server" /></td>
    </tr>
    <tr >
        <td class="publica-td-left" >
            单位网址：</td>
        <td >
             <input id="txtWebSite" type="text" value="" style="width: 210px" runat="server" /></td>
    </tr>
    
            <tr>
            <td colspan="2" id="pub-tongyi">

              <asp:ImageButton ID="btnOK"  OnClientClick="return chkpost();" ImageUrl="http://img2.topfo.com/member/images/member-btn-tj.jpg" runat="server"
                OnClick="BtnOk_Click"  />
               </td>
            </tr>
</table>

    </div>
      </div>
       <div id="imgLoding" Style="position: absolute; 
   display:none; background-color: #A9A9A9; 
  top: 0px; left: 0px; width: 100%;
   height:1800px; filter: 
   alpha(opacity=60);">

               <div class="content">
                <p>
                    数据正在提交,请稍候...</p>
                <img src="../../img/img-loading.gif" alt="Loading" />
                </div>
        </div>
</asp:Content>

