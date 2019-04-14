<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" ValidateRequest="false"
    CodeFile="ModifyMerchant20110331.aspx.cs" Inherits="Manage_ModifyMerchant" Title="Untitled Page" %>

<%@ Register Src="../Controls/MerchantInfoAddressInfo1.ascx" TagName="MerchantInfoAddressInfo1"
    TagPrefix="uc4" %>
<%@ Register Src="~/Controls/FilesUploadControl.ascx" TagName="FilesUploadControl"
    TagPrefix="uc3" %>
<%@ Register Src="../Controls/SelectIndustryControl.ascx" TagName="SelectIndustryControl"
    TagPrefix="uc2" %>
<%@ Register Src="../Controls/ZoneSelectControl.ascx" TagName="ZoneSelectControl"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   <style type="text/css">
        body{text-align:center;}
        .content{width:466px;height:300px;background:url(../images/search_bg_03.jpg) no-repeat left top;margin:300px auto 0;text-align:center;padding-top:500px;}
        .content p{line-height:30px;        }
        </style>
        
  
 <link href="../css/publish.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
.trnone{
    display:none;
    }
.note
{
	float:left;
	text-align:left;
	font-size:12px;
	color:#999999;
	padding:3px;
	line-height:130%;
	background:#ffffff;
	border:#ffffff 1px solid;
}
.infomsg{

    padding-left:20px;
    padding-right:20px;
    fong-size:12px;
    color:#777777;
    background:#83BDC0;
}
.notetrue
{
	float:left;
	text-align:left;
	font-size:12px;
	padding:3px;
	line-height:130%;
	color:#485E00;
	background:#F7FFDD;
	border:#485E00 1px solid;
}
.noteawoke
{
	float:left;
	text-align:left;
	padding:3px;
	line-height:130%;
	background:#fff5d8;
	border:#ff7300 1px solid;
	background-image:url("http://member.topfo.com/images/icon_noteawake_16x16.gif");
	background-repeat:no-repeat;
	background-position:2 3px;
}
</style>


  <script type="text/javascript" language="javascript">

function checkIndustry()
{
    var id = "<%=this.SelectIndustryControl1.ClientID %>";
    return eval(id+"_SelectIndustry.check()"); 
}

    </script>

    <script type="text/javascript" language="javascript">
    
  function ValidErr()
   {
        var c="ctl00_ContentPlaceHolder1_";
        alert('验证码错误,请重新输入！');
        document.getElementById(c+"ImageCode").focus();
        document.getElementById(c+"ImageCode").select();
   }

  function ChangeValidCode(id)
  {
     document.getElementById(id).src = "../../ValidateNumber.aspx?r="+Math.random();
  }
  
        function switchPublish()
        {
            var tag = document.getElementById("hdswitchpublish").value;
            var objs = document.getElementsByName("trswitchpublish");
            if(objs == null)
                return;
            var style = "";
            if(tag == 1){
                style = "trnone";  
                document.getElementById("hdswitchpublish").value = 0;
                document.getElementById("switchtext").innerHTML = '带 <span class="hong">*</span> 的为必填项 （您可以<a href="javascript:switchPublish();" class="lanlink">切换到完整发布</a>）</span>';
            }
            else{
                document.getElementById("hdswitchpublish").value = 1;
                document.getElementById("switchtext").innerHTML = '带 <span class="hong">*</span> 的为必填项 （您可以<a href="javascript:switchPublish();" class="lanlink">切换到快速发布</a>）';
            }
            //alert(objs.length);
            for(var i=0; i <objs.length; i++)
            {
                objs[i].className = style;
            }
        }
     
        function TopFo()
        {
          var c="ctl00_ContentPlaceHolder1_";

           var ZoneId= "<%=this.ZoneId.ClientID %>";//所属区域
           var Zone = document.getElementById(ZoneId);
           var txtZoneAbout = "<%=this.txtZoneAbout.ClientID %>";//招商项目介绍
           var zone=document.getElementById(txtZoneAbout);  
           var IndustryId= "<%=this.IndustryId.ClientID %>";//所属行业
           var Industry = document.getElementById(IndustryId);
           var rdlTerm= "<%=this.rdlTerm.ClientID %>";//有效期隐藏域
           var Term = document.getElementById(rdlTerm);
           var rdlValiditeTermID = "<%=this.rdlValiditeTerm.ClientID %>";//项目有效期
          if(GetCheckNum(rdlValiditeTermID.replace(/_/g,"$")) <= 0)
            {
               alert("项目有效期不能为空！");
               Term.focus();
               return false;
            }
         if(document.getElementById("ctl00_ContentPlaceHolder1_ZoneSelectControl1_hideProvince").value=="")
	        {
	          alert("请选择所属区域");
	          Zone.focus();
	          return false;
	        }
	       if(document.getElementById("ctl00_ContentPlaceHolder1_SelectIndustryControl1_sltIndustryName_Select").options.length==0)
	        {
	         alert("请选择所属行业");
	         Industry.focus();
	         return false;
	        }
         //投资额
           var Cap = document.getElementById("ctl00_ContentPlaceHolder1_txtCapitalTotal"); 
             if(Cap.value!="")
            {
                var filter = /^\d+(\.\d+)*$/;
                if( !filter.test(Cap.value))
                {
                   alert("总投资额必须为数字，请正确填写！");
                   Cap.focus();
                   return false;
                }
            }
            if(Cap.value=="")
            {
             alert("总投资额不能为空！");
               Cap.focus();
               return false;
            }    
          //招商标题
           var Merchan=document.getElementById("ctl00_ContentPlaceHolder1_txtMerchantTopic");
             if(Merchan.value=="")
   	        {
   	           alert("请输入招商标题");
   	           Merchan.focus();
   	           return false;
   	        }
   	         if(zone.value=="")
            {
                 alert("招商项目介绍不能为空");
                 zone.focus();
                 return false;
            } 
         //电子邮箱
           var email = document.getElementById("ctl00_ContentPlaceHolder1_txtEmail");
   	        if(email.value=="")
   	        {
   	           alert("请输入电子邮箱");
   	           email.focus();
   	           return false;
   	        } 
   	        else  
   	        {
   	         
   	            var filtEmial = /^[_a-zA-Z0-9\-]+(\.[_a-zA-Z0-9\-]*)*@[a-zA-Z0-9\-]+([\.][a-zA-Z0-9\-]+)+$/;
   	            if(!filtEmial.test(trim(email.value)))
   	            {
           	         alert("电子邮箱格式不正确，请重新输入");
           	         email.focus();
           	         return false;
           	     }
           	    
   	        }
   	          var CompanyName = document.getElementById("ctl00_ContentPlaceHolder1_txtCompanyName");
   	        if(CompanyName.value=="")
   	        {
   	           alert("请输入招商机构名称");
   	           CompanyName.focus();
   	           return false;
   	        } 
   	           var Name = document.getElementById("ctl00_ContentPlaceHolder1_txtName");
   	        if(Name.value=="")
   	        {
   	           alert("请输入联系人");
   	           Name.focus();
   	           return false;
   	        } 
   	       
   	        

                //电话号码
            var telzone = document.getElementById("ctl00_ContentPlaceHolder1_txtTelZoneCode");
            var telNumber=document.getElementById("ctl00_ContentPlaceHolder1_txtTelNumber");
           //手机号码
            var telMobile=document.getElementById("ctl00_ContentPlaceHolder1_txtMobile");
           if(telNumber.value=="" && telMobile.value=="")
        
            {
              alert("手机和固定电话请至少填写一项");
                 telMobile.focus();
                return false;
            
            }
          
          if(telMobile.value!="")
          {
                var filtMobile = /^(13|15|18)[0-9]{9}$/;
                if(!filtMobile.test(trim(telMobile.value)))
                {
                    alert("请正确填写手机号码");
                    telMobile.focus();
                    return false;
                }
            }
       
        document.getElementById("imgLoding").style.display="";


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

   <link href="../css/common.css" rel="stylesheet" type="text/css" />
    <input type="hidden" id="hdswitchpublish" value="1" />
    <div class="mainconbox">
        <div class="titled">
            <div class="left">
                修改政府招商需求

            </div>
            
            <div class="right">
                <img src="../images/publish/biao_01.gif" align="absMiddle" />
                 <a href="http://www.topfo.com/help/demandrelease.shtml#16" target="_blank">需求发布规则</a>            </div>
            <div class="clear">
            </div>
        </div>
        <asp:Panel ID="plTitle" runat='server'>
        <div class='stepsbox' style="display:none">
            <ul>
                <li>第1步 登记招商机构 </li>
                <li class="liimg">
                    <img src='../images/publish/projectbg.gif' align='left' /></li>
                <li class='liwai'>第2步 填写招商项目信息</li>
                <li class='liimg'>
                    <img src='../images/publish/projectbg.gif' align='left' /></li>
                <li class='lishort'>第3步 发布成功</li>
            </ul>
            <div class='clear'>
            </div>
            <div class='blank0'>
            </div>
            <div class='suggestbox lightc'>
                "招商机构已经登记，接下来请您填写招商项目信息</div>
        </div>
        </asp:Panel>
        <div  id="switchtext">
            带 <span class="hong">*</span> 的为必填项</div>  <!--（您可以<a href="javascript:switchPublish();" class="lanlink">切换到快速发布</a>）-->
			 <div class='dottedlline'>  </div>
			  <div class="blank6"> </div>
			 <!--这是后来招商信息的div-->
			 <div id="ProjectDiv" style="display:block;" >
			
        <div class="infozi">
            修改招商项目信息</div>
            <!--以下是修改的部分-->
        <table border="1" cellpadding="0" cellspacing="0" class="tabbiank">
             <tr>
                <td align="right" bgcolor="#f7f7f7">
                  <span class="hong">* </span>  <strong>项目标题：</strong></td>
                <td>
                    <asp:TextBox ID="txtMerchantTopic"   runat="server" Width="270px"></asp:TextBox>
                    <span id="spMerchantTopic"></span>
                </td>
            </tr>

            <tr>
                <td align="right" bgcolor="#f7f7f7">
                    <span class="hong">*</span> <strong>所属区域：</strong></td>
                <td width="618">
                    <uc1:ZoneSelectControl ID="ZoneSelectControl1" runat="server" />
                    <input type="text" runat="server" id="ZoneId" style="width:0; border-color:#FFFFFF;border:1px solid #FFFFFF" />
                </td>
            </tr>
            <tr>
                <td width="124" align="right" valign="top" bgcolor="#f7f7f7">
                    <span class="hong">*</span> <strong>所属行业：</strong></td>
                <td width="630">
                <input type="text" runat="server" id="IndustryId" style="width:0; border-color:#FFFFFF;border:1px solid #FFFFFF; height:2px;" />
                    <uc2:SelectIndustryControl ID="SelectIndustryControl1" runat="server" />
                </td>
            </tr>
            <tr id="trswitchpublish1" name="trswitchpublish">
                <td width="124" align="right" bgcolor="#f7f7f7">
                  <span class="hong">*</span>   <strong>总投资：</strong></td>
                <td width="630">
                    <asp:DropDownList ID="ddlCapitalCurrency" runat="server">
                    </asp:DropDownList>
                    <asp:TextBox ID="txtCapitalTotal"   runat="server"
                        Width="75px"></asp:TextBox>
                    万元 <span id="spCapitalTotal"></span>
                </td>
            </tr>
              <tr>
                <td width="124" align="right" bgcolor="#f7f7f7">
                    <span class="hong">*</span> <strong>项目有效期：</strong></td>
                <td width="630">
                <input id="Vaildite" type="hidden" name="Vaildite" visible="false" />
                     <asp:RadioButtonList ID="rdlValiditeTerm" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                      </asp:RadioButtonList>
                      <input type="text" runat="server" id="rdlTerm" style="width:0; border-color:#FFFFFF;border:1px solid #FFFFFF" />
                     <span id="spValiditeTerm"></span>
                          
             </td>
            </tr>
            <tr>
                <td align="right" valign="top" bgcolor="#f7f7f7">
                    <span class="hong">*</span> <strong>招商项目简介：</strong>
                    <br /></td>
                <td width="618" valign="top">
                    <textarea id="txtZoneAbout"   runat="server" cols="50"
                        rows="10" style="width: 558px; height:100px"></textarea><span id="spZoneAboutB"></span>
                           
                </td>
            </tr>
            <!--以下是要添加的部分-->
            <!--结束处-->
            <tr id="tr1" name="trswitchpublish">
                <td align="right" valign="top" bgcolor="#f7f7f7">
                    <strong>上传图片：</strong></td>
                <td width="618" valign="top" class="nonepad">
                    <uc3:FilesUploadControl ID="FilesUploadControl1" InfoType="Merchant"
                        runat="server" />
                </td>
            </tr>

        </table>
        <div class="blank0">
        </div>

        <div id="ContactDiv" style="display:block;">
        <div class="infozi">
            <strong>联系方式确认</strong></div>
            <!--这里是添加联系方式-->
      <div>
      <table border="1" cellpadding="0" cellspacing="0" class="tabbiank">

    
    <tr>
        <td width="124" align="right" bgcolor="#f7f7f7">
            <span class="hong">*</span> <strong>招商机构名称：</strong></td>
        <td width="638">
            <asp:TextBox ID="txtCompanyName"   runat="server" Width="324px" />
            <span id="spCAComName" ></span>
            </td>
    </tr>
    <tr>
        <td align="right" bgcolor="#f7f7f7">
            <span class="hong">*</span> <strong>联系人：</strong></td>
        <td width="638">
          
            <asp:TextBox id="txtName"  width="127px" runat="server" />
        </td>
    </tr>
    <tr>
        <td align="right" bgcolor="#f7f7f7">
             <strong>联系电话：</strong></td>
        <td width="638" valign="top">
   <asp:TextBox ID="txtTelCountry" runat="server" size='4'>+86</asp:TextBox>
            <asp:TextBox ID="txtTelZoneCode"  runat="server" size='7' />
            <asp:TextBox ID="txtTelNumber" runat="server" size='18' />
             <span class="f_gray">（如：+86-0755-89805588）</span>
            <span id="spTel" ></span>
          <%--  手机<asp:TextBox id="txtMobile"  width="127px" runat="server" /><span>（固定电话或手机至少填写一项）</span>       --%>
        </td>
    </tr>
      <tr id="tr2" name="trswitchpublish">
        <td align="right" bgcolor="#f7f7f7">
            <span class="hong">*</span><strong >手机号码：</strong></td>
        <td width="638">
            <asp:TextBox id="txtMobile"  width="127px" runat="server" /><span>（固定电话或手机至少填写一项）</span>  
        </td>
    </tr>
    <tr id="tr3" name="trswitchpublish">
        <td align="right" bgcolor="#f7f7f7">
           <span class="hong">*</span> <strong >电子邮箱：</strong></td>
        <td width="638">
            <asp:TextBox ID="txtEmail"  runat="server" size='18' Width="269px" />
            <span id="spEmail" class="hui">请填写您最常用的电子邮箱</span> 
        </td>
    </tr>
   
    
    <tr id="tr4" name="trswitchpublish">
        <td align="right" bgcolor="#f7f7f7">
            <strong >联系地址：</strong></td>
        <td width="638">
            <asp:TextBox ID="txtAddress" runat="server" size='18' Width="269px" />
          
            </td>
            
    </tr>
          <tr name="trswitchpublish">
              <td align="center"  colspan="2">
          <asp:Button ID="btnUpdate" runat="server" Width="144px" Text="修改" OnClientClick="return TopFo();"  OnClick="btnUpdate_Click" /></td>
          </tr>
          <%--<tr >
               <td align="right" bgcolor="#F7F7F7">
            <strong>单位网址：</strong></td>
        <td width="638">
                <input id="txtWebSite" type="text" value="" style="width: 210px" runat="server" maxlength="40"   onblur="repl(this);" />
            <asp:TextBox ID="txtWebSite1" runat="server" size='18' Width="269px" /></td>
          </tr>--%>
           
  
    
</table></div>
          <!--这里是添加验证码的地方-->
       
        
        <!--申请域名 建立我的展厅 -->
   
          
     </div>
   </div>
   <div id="imgLoding" Style="position: absolute; 
   display:none; background-color: #A9A9A9; 
  top: -3px; left: 0px; width: 100%;
   height:1500px; filter: 
   alpha(opacity=60);">

               <div class="content">
                <p>
                    数据正在提交,请稍候...</p>
                <img src="../images/loading42.gif"  alt="Loading" />
                </div>
        </div>
   
</asp:Content>