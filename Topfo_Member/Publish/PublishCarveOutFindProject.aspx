<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PublishCarveOutFindProject.aspx.cs" Inherits="Publish_PublishCarveOutFindProject" Title="Untitled Page" %>
<%@ Register Src="../Controls/MerchantInfoAddressInfo1.ascx" TagName="MerchantInfoAddressInfo"
    TagPrefix="uc4" %>
<%@ Register Src="../Controls/FilesUploadControl.ascx" TagName="FilesUploadControl"
    TagPrefix="uc3" %>
<%@ Register Src="../Controls/SelectIndustryControl.ascx" TagName="SelectIndustryControl"
    TagPrefix="uc2" %>
<%@ Register Src="../Controls/ZoneSelectControl.ascx" TagName="ZoneSelectControl"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<style type="text/css">
        body{text-align:center;}
        .content{width:466px;height:300px;background:url(images/search_bg_03.jpg) no-repeat left top;margin:300px auto 0;text-align:center;padding-top:1000px;}
        .content p{line-height:30px;        }
        
    </style>  
     <link href="../css/common.css" rel="stylesheet" type="text/css" />
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
<script language="javascript" type="text/javascript">
      
	function chkBtn()
	{
	   if(document.getElementById("ctl00_ContentPlaceHolder1_txtTitle").value=="")
	   {
	       alert("请填写商机标题");
	       document.getElementById("ctl00_ContentPlaceHolder1_txtTitle").focus();
	       return false;
	   }
	   if(document.getElementById("ctl00_ContentPlaceHolder1_ZoneSelectControl2_hideProvince").value=="")
	   {
	          alert("请选择所属区域");
	          document.getElementById("ZoneId").focus();
	          return false;
	   }

	    var rdlValiditeTermID = "<%=this.rdbtXM.ClientID %>";//项目有效期
	    if(GetCheckNum(rdlValiditeTermID.replace(/_/g,"$")) <= 0)
        {
           alert("项目有效期不能为空！");
           document.getElementById("ctl00_ContentPlaceHolder1_rdlTerm").focus();
           return false;
        }
         if(document.getElementById("ctl00_ContentPlaceHolder1_txtComName").value=="")
	    {
	       alert("请填写公司名称");
	       document.getElementById("ctl00_ContentPlaceHolder1_txtComName").focus();
	       return false;
	    }
        
	    if(document.getElementById("ctl00_ContentPlaceHolder1_txtTelNumber").value.length=="" && document.getElementById("ctl00_ContentPlaceHolder1_txtMobile").value.length=="")
        {
            alert("手机和固定电话请至少填写一项");
             document.getElementById("ctl00_ContentPlaceHolder1_txtMobile").focus();
            return false;
        }else
        {
            var filtMobile = /^(13|15|18)[0-9]{9}$/;
            if(!filtMobile.test(document.getElementById("ctl00_ContentPlaceHolder1_txtMobile").value))
            {
                alert("请正确填写手机号码");
                document.getElementById("ctl00_ContentPlaceHolder1_txtMobile").focus();
                return false;
            }
        }
        if(document.getElementById("ctl00_ContentPlaceHolder1_txtEmail").value=="")
        {
           alert("请输入电子邮箱");
           document.getElementById("ctl00_ContentPlaceHolder1_txtEmail").focus();
           return false;
        } else  
        {
            var filtEmial = /^[_a-zA-Z0-9\-]+(\.[_a-zA-Z0-9\-]*)*@[a-zA-Z0-9\-]+([\.][a-zA-Z0-9\-]+)+$/;
            if(!filtEmial.test(document.getElementById("ctl00_ContentPlaceHolder1_txtEmail").value))
            {
       	         alert("电子邮箱格式不正确，请重新输入");
       	         document.getElementById("ctl00_ContentPlaceHolder1_txtEmail").focus();
       	         return false;
       	     }
        }
         document.getElementById("ctl00_ContentPlaceHolder1_imgLoding").style.display="block";
      
           
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
     

</script>
  <link href="../css/common.css" rel="stylesheet" type="text/css" />
  <div class="mainconbox">
        <div class="titled">
            
            <div class="right">
                <img src="../images/publish/biao_01.gif" align="absmiddle" />
                 <a href="http://www.topfo.com/help/demandrelease.shtml#16" target="_blank">需求发布规则</a>            </div>
            <div class="clear">
            </div>
        </div>
        <div  id="switchtext" style="text-align:left">
            带 <span class="hong">*</span> 的为必填项 </div>
			 <div class='dottedlline'>  </div>
			  <div class="blank6"> </div>
			 <!--这是后来招商信息的div-->
			 <div id="ProjectDiv" style="display:block;" >
			
        <div class="infozi" style="text-align:left">
            发布创业信息</div>
            <!--以下是修改的部分-->
        <table border="1" cellpadding="0" cellspacing="0" class="tabbiank" style="width: 751px">
            <tr>
                <td align="center"bgcolor="#f7f7f7" colspan="2">
                    资金找项目</td>
            </tr>
             <tr>
                <td align="right" bgcolor="#F7F7F7">
                  <span class="hong"> * </span> <strong>创业标题：</strong></td>
                <td align="left">
                    <asp:TextBox ID="txtTitle" onblur="chkTitle()"  runat="server" Width="270px" Height="21px"></asp:TextBox>
                    <span id="spMerchantTopic" style="color:buttonshadow">填写5个字以上</span>
                </td>
            </tr>
            <tr>
                <td align="right" bgcolor="#F7F7F7">
                  <strong>关键字：</strong></td>
                <td align="left">
                    <asp:TextBox id="txtKeyWord"  runat="server" Columns="50" Width="270px" Height="21px"></asp:TextBox>
                    <span id="Span1" style="color:buttonshadow">关键词间必须用逗号分隔 </span>
                </td>
            </tr>
               <tr>
                <td align="right" bgcolor="#F7F7F7">
                  <span class="hong"></span>  <strong>网页描述：</strong></td>
                <td align="left"> 
                    <asp:TextBox id="txtDescript" runat="server" Columns="50" TextMode="MultiLine" Height="78px" Width="418px"></asp:TextBox>
                    <span id="Span2"></span>
                </td>
            </tr>
            <tr>
                <td align="right" bgcolor="#F7F7F7">
                  <span class="hong"></span>  <strong>网页标题：</strong></td>
                <td align="left">
                    <asp:TextBox id="txtDisplayTitle" runat="server" Columns="50" Height="21px"></asp:TextBox>
                    <span id="Span3"></span>
                </td>
            </tr>
            <tr>
                <td align="right" bgcolor="#F7F7F7">
                  <strong>短标题：</strong></td>
                <td align="left">
                    <asp:TextBox id="txtShortTitle" runat="server" Columns="50" Height="21px"></asp:TextBox>
                    <span id="Span4"></span>
                </td>
            </tr>
            <tr>
                <td align="right" bgcolor="#F7F7F7">
                  <strong>短内容：</strong></td>
                <td align="left">
                    <asp:TextBox id="txtShortContent" runat="server" Columns="50" Height="21px"></asp:TextBox>
                    <span id="Span5"></span>
                </td>
            </tr>
            <tr>
                <td align="right" bgcolor="#F7F7F7">
                  <strong>广告语：</strong></td>
                <td align="left">
                    <asp:TextBox id="txtAdTitle" runat="server" Height="21px" Width="275px"></asp:TextBox>
                    <span id="Span6"></span>
                </td>
            </tr>
            <tr>
                <td align="right" bgcolor="#F7F7F7">
                  <span class="hong">* </span>  <strong>所属区域：</strong></td>
                <td align="left">
                   <uc1:ZoneSelectControl ID="ZoneSelectControl2" runat="server" />
                    <span id="Span8"></span>
                    <input name="ZoneId" type="text" id="ZoneId" style="width:0; border-color:#FFFFFF;border:1px solid #FFFFFF" />
                </td>
            </tr>
            <tr>
                <td align="right" bgcolor="#F7F7F7">
                  <span class="hong">* </span>  <strong>所属行业：</strong></td>
                <td align="left">
                <asp:DropDownList id="ddlIndustry" runat="server"></asp:DropDownList>
                    
                </td>
            </tr>
            <tr>
                <td align="right" bgcolor="#f7f7f7">
                <strong><span class="hong">* </span></strong> <strong>所需资金：</strong>
                </td>
                <td align="left">
                    <%--<asp:DropDownList ID="ddlCapital" runat="server" DataTextField="CapitalName" DataValueField="CapitalID">
                    </asp:DropDownList>--%>
                         <asp:DropDownList ID="ddlMerchantCurrency" runat="server" Enabled="False">
                    </asp:DropDownList>&nbsp;<asp:DropDownList ID="ddlMerchantTotal" runat="server">
                    </asp:DropDownList></td>
            </tr>
<%--            <tr>
                <td align="right" bgcolor="#F7F7F7">
                  <span class="hong"> </span>  <strong>创业类别：</strong></td>
                <td align="left">
                   <asp:DropDownList id="ddlOpportunityType" runat="server" Width="80px" DataValueField="OpportunityTypeID" DataTextField="OpportunityTypeName"></asp:DropDownList>
                    <span id="Span7"></span>
                </td>
            </tr>--%>
            <tr>
                <td align="right" bgcolor="#F7F7F7" style="height: 42px">
                  <span class="hong"> </span>  <strong>图片上传：</strong></td>
                <td align="left" style="height: 42px">
      <asp:FileUpload ID="uploadPic" runat="server" Width="235px" />&nbsp;<asp:Button ID="btnUpload2"
            runat="server" OnClick="btnUpload2_Click" Text="上 传" />
        <asp:Label ID="LblMessage2" runat="server" BackColor="White" BorderColor="White" ForeColor="#C00000"></asp:Label><br />
        <span class="hui">图片须为jpg或gif格式，大小不超过100K </span>
                </td>
            </tr>
            <tr>
                <td align="right" bgcolor="#f7f7f7" style="height: 42px">
                <span class="hong"> </span>  <strong>合作对象：</strong>
                </td>
                <td align="left" style="height: 42px">
                    <asp:RadioButtonList ID="rblInvestObject" runat="server" RepeatDirection="Horizontal"
                        RepeatLayout="Flow">
                        <asp:ListItem Value="1">个人</asp:ListItem>
                        <asp:ListItem Value="2">公司</asp:ListItem>
                        <asp:ListItem Selected="True" Value="0">不限制</asp:ListItem>
                    </asp:RadioButtonList></td>
            </tr>
            <tr>
                <td align="right" bgcolor="#F7F7F7">
                  <span class="hong">&nbsp;</span><strong>详细内容：</strong></td>
                <td align="left">
                   <asp:TextBox id="txtContent" runat="server" Columns="60" TextMode="MultiLine" Rows="5" Height="117px"></asp:TextBox>
                    <span id="Span12"></span>
                </td>
            </tr>
            <tr>
                <td align="right" bgcolor="#F7F7F7">
                  <strong>回报形式：</strong></td>
                <td align="left">
                   <asp:TextBox id="txtInvestReturn" runat="server" Columns="60"  TextMode="MultiLine"
																					Rows="5" Height="93px"></asp:TextBox>
                    <span id="Span13"></span>
                </td>
            </tr>
             <tr>
                <td align="right" bgcolor="#F7F7F7">
                  <span class="hong"> </span>  <strong>备    注：</strong></td>
                <td align="left">
                  <asp:TextBox id="txtRemark" runat="server" Columns="60"  TextMode="MultiLine"
																					Rows="5" Height="91px"></asp:TextBox>
                    <span id="Span16"></span>
                </td>
            </tr>
             <tr>
                <td align="right" bgcolor="#F7F7F7">
                  <span class="hong">* </span>  <strong>有效期：</strong></td>
                <td align="left">
                    &nbsp;
                    <asp:RadioButtonList ID="rdbtXM" runat="server" Height="2px" RepeatDirection="Horizontal"
                        RepeatLayout="Flow">
                    </asp:RadioButtonList></td>
            </tr>
<%--            <tr>
                <td align="right" bgcolor="#f7f7f7" style="height: 42px"> <strong>发布时效：</strong>
                </td>
                <td align="left" style="height: 42px">
                    <asp:DropDownList ID="ddlValidateDate" runat="server" DataTextField="ValidateName"
                        DataValueField="ValidateID">
                    </asp:DropDownList></td>
            </tr>--%>
    <%--        <tr>
                <td align="right" bgcolor="#f7f7f7">
                <span class="hong">* </span><strong>开始日期：</strong>
                </td>
                <td align="left">
                    <cc1:DateTimeBox ID="txtValidateStartTime" runat="server"></cc1:DateTimeBox>
                
                </td>
            </tr>--%>
            <tr style="DISPLAY: none">
                <td align="right" bgcolor="#f7f7f7" > <strong>模版号：</strong>
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddlTemplate" runat="server" Width="64px">
                        <asp:ListItem Value="001">001</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>

         
        </table>
        <div class="blank0">
        </div>

        <!--联系方式开始将之隐藏 -->
        <div id="ContactDiv" style="display:block;">
        <div class="infozi" style="text-align:left">
            <strong>联系方式确认</strong></div>
            <!--这里是添加联系方式-->
      <div>
      <table border="1" cellpadding="0" cellspacing="0" class="tabbiank">

    
    <tr>
        <td width="124" align="right" bgcolor="#F7F7F7">
            <span class="hong">*</span> <strong>公司名称：</strong></td>
        <td width="638" align="left">
            <asp:TextBox id="txtComName" runat="server" Columns="40" Height="21px"></asp:TextBox>
            <span id="spCAComName" ></span>
            </td>
    </tr>
    <tr id="tr2" name="trswitchpublish">
        <td width="124" align="right" bgcolor="#F7F7F7">
            <strong>联 系 人：</strong></td>
        <td width="622" align="left">
           <asp:TextBox id="txtLinkMan" runat="server"  Columns="40" Height="21px" ></asp:TextBox></td>
    </tr>

    <tr>
        <td align="right" bgcolor="#F7F7F7">
            <span class="hong"></span> <strong>联系电话：</strong></td>
        <td width="638" valign="top" align="left">
            <asp:TextBox ID="txtTelCountry"  runat="server" size='4' Height="21px">+86</asp:TextBox>
            <asp:TextBox ID="txtTelZoneCode"  runat="server" size='7'  Height="21px"/>
            <asp:TextBox ID="txtTelNumber"  runat="server" size='18' Height="21px" />
            <span id="spTel" ></span>
        </td>
    </tr>
     <tr id="tr1" name="trswitchpublish">
        <td width="124" align="right" bgcolor="#F7F7F7">
            <strong>手机：</strong></td>
        <td width="622" align="left">
           <asp:TextBox id="txtMobile" runat="server"  Columns="40" Height="21px" ></asp:TextBox>
           <span id="Span10" style="color:buttonshadow">为了方便联系，联系电话和手机至少填写一个</span>
           </td>
    </tr>
     <tr id="tr8" name="trswitchpublish">
        <td align="right" bgcolor="#F7F7F7">
            <strong>联系地址：</strong></td>
        <td width="638" align="left">
            <asp:TextBox id="txtAddress" runat="server" Columns="40" Height="21px"></asp:TextBox></td>
    </tr>
     <tr id="tr5" name="trswitchpublish">
        <td width="124" align="right" bgcolor="#F7F7F7">
            <strong>邮编：</strong></td>
        <td width="622" align="left">
           <asp:TextBox id="txtPostCode" runat="server" Columns="15" MaxLength="6" Height="21px"></asp:TextBox></td>
    </tr>
     <tr id="tr6" name="trswitchpublish">
        <td width="124" align="right" bgcolor="#F7F7F7">
            <strong>网址：</strong></td>
        <td width="622" align="left">
           <asp:TextBox id="txtWebSite" runat="server" Columns="40" Height="21px"></asp:TextBox></td>
    </tr>

    <tr id="tr3" name="trswitchpublish">
        <td align="right" bgcolor="#F7F7F7">
            <span class="hong">*</span><strong>电子邮箱：</strong></td>
        <td width="638" align="left">
            <asp:TextBox ID="txtEmail"  onchange="checkEmail();" runat="server" Height="21px" size='18' Width="233px" />
            <span id="spEmail" class="hui">请填写您最常用的电子邮箱</span> 
        </td>
    </tr> 
    <tr>


</table></div>
   <div class="mbbuttom">
            <asp:ImageButton ID="IbtnSubmit" OnClientClick="return chkBtn();"  ImageUrl="../images/publish/buttom_tywftk.gif" runat="server" OnClick="IbtnSubmit_Click" />
        </div>
        
        </div>
          
     </div>
     </div>
      <div id="imgLoding" style="position: absolute; 
  display:none; background-color: #A9A9A9; 
  top: 0px; left: 0px; width: 100%;
   height:2500px; filter: 
   alpha(opacity=60);" runat="server">

               <div class="content">
                <p>
                    数据正在提交,请稍候...</p>
                <img src="../images/loading42.gif" alt="Loading" />
                </div>
   </div> 

</asp:Content>

