<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="EnterpriseRegister.aspx.cs" Inherits="Enterprise_Register" %>

<%@ Register Src="Control/ImageUploadControl.ascx" TagName="ImageUploadControl" TagPrefix="uc1" %>
<%@ Register Src="Control/OrgContactControl.ascx" TagName="OrgContactControl" TagPrefix="uc5" %>
<%@ Register Src="../Controls/ImageUploadControl.ascx" TagName="ImageUploadControl"
    TagPrefix="uc2" %>
<%@ Register Src="../Controls/SelectIndustryControl.ascx" TagName="SelectIndustryControl"
    TagPrefix="uc3" %>
<%@ Register Src="../Controls/ZoneSelectControl.ascx" TagName="ZoneSelectControl"
    TagPrefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<style type="text/css">
        body{text-align:center;}
        .content{width:466px;height:300px;background:url(images/search_bg_03.jpg) no-repeat left top;margin:300px auto 0;text-align:center;padding-top:1200px;}
        .content p{line-height:30px;        }
        
    </style>  
<link href="../css/common.css" rel="stylesheet" type="text/css" />
    <link href="../css/publish.css" rel="stylesheet" type="text/css" />
  <script language="javascript" type="text/javascript" src="/Controls/DatePicker/WdatePicker.js"></script>

    <script language="javascript" type="text/javascript">
    function $id(obj)
    {
        document.getElementById("ctl00_ContentPlaceHolder1_"+obj);
    }
    function chkPost()
    { 
      
       if(document.getElementById("ctl00_ContentPlaceHolder1_tbEnterpriseName").value=="")
		{
			alert("招商机构名称不能为空!");
			document.getElementById("ctl00_ContentPlaceHolder1_tbEnterpriseName").focus();
			return false;
		}
		
		if(document.getElementById("ctl00_ContentPlaceHolder1_tbRegisterDate").value=="")
		{
			alert("注册时间不能为空!");
			document.getElementById("ctl00_ContentPlaceHolder1_tbRegisterDate").focus();
			return false;
		}
			var obj = document.getElementById("ctl00_ContentPlaceHolder1_tbRegCapital").value;
		if(obj =="")
		{
		alert("ssssssssssssssssssssss!");
		    alert("注册资本不能为空!");
			document.getElementById("ctl00_ContentPlaceHolder1_tbRegCapital").focus();
			return false;
		}

		if(document.getElementById("ctl00_ContentPlaceHolder1_tbComAbout").value=="")
		{
			alert("公司介绍不能为空!");
			document.getElementById("ctl00_ContentPlaceHolder1_tbComAbout").focus();
			return false;
		}
		var obj = document.getElementById("ctl00_ContentPlaceHolder1_tbComAbout").value;
		if( obj.length<50 || obj.length>2000)
		{
		    alert("请按要求输入公司介绍内容长度(50-2000)!");
			document.getElementById("ctl00_ContentPlaceHolder1_tbComAbout").focus();
			return false;
		}
		if(document.getElementById("ctl00_ContentPlaceHolder1_tbExhibitionHall").value=="")
		{
			alert("我的域名不能为空!");
			document.getElementById("ctl00_ContentPlaceHolder1_tbExhibitionHall").focus();
			return false;
		}
		document.getElementById("imgLoding").style.display = "block";
    }
   
    </script>
<div class="mainconbox">
        <div class="contant_l">
            <div class="titled">
                <div class="left">
                    <h3 class="f14_b2">
                        登记公司信息</h3>
              </div>
                <div class="right">
                    <span>
                        <img src="../images/Company_Manage/biao_01.gif" align="absmiddle" /> </span><span><a href="http://www.topfo.com/help/companyregister.shtml" target="_blank" class="lanlink">公司登记指导</a></span></div>
                <div class="clear">
                </div>
          </div>
            <div class="lightc pad_1 allxian">
                <h3 class="cu cheng font14">
                    重要提示</h3>
                <div>
                    ·您发布的公司请确保真实有效，由于发布虚假信息产生的任何责任，由发布者自行承担！<br />
                    ·登记真实、详细的公司信息将被更多用户认可。</div>
            </div>
            <div >
			 <div class="blank0">        </div>
                带 <span class="hong">* </span>的为必填项</div>
				  <div class='dottedlline'>  </div>
        <div class="blank6">        </div>
            <h3 class="infozi">
                公司基本资料</h3>
            <div class="widthTable">
                <table width="100%" border="0" cellpadding="0" cellspacing="0" class="tabbiank">
                    <tr>
                        <td width="125" align="right" class="ltitles" >
                          <span class="hong">*</span> <strong>公司名称：</strong></td>
                        <td>
                            <div>
                                <asp:TextBox ID="tbEnterpriseName" runat="server" Width="315px">                                </asp:TextBox>&nbsp;
                                <span class="hui"> 请用中文完整填写在工商局注册的公司全称<asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                                    runat="server" ControlToValidate="tbEnterpriseName" ErrorMessage="公司名称不能为空"></asp:RequiredFieldValidator></span></div>                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="ltitles" >
                          <span class="hong">*</span><strong> 企业性质：</strong></td>
                        <td>
                            <asp:DropDownList ID="ddManageType" runat="server" Width="107px">
                                <asp:ListItem Value="1001">私营独资企业</asp:ListItem>
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td align="right" class="ltitles" style="height: 24px" >
                          <span class="hong">* </span><strong>注册时间：</strong></td>
                        <td style="height: 24px">
                            <asp:TextBox ID="tbRegisterDate" runat="server" Width="162px" onfocus="new WdatePicker(this,null,false,'whyGreen')"></asp:TextBox><a href="" class="blueline_2"></a>
                            <asp:HyperLink ID="hlStartCal" runat="server" Visible="False">查看日历</asp:HyperLink>&nbsp;
                            <asp:RequiredFieldValidator ID="reqRegisterDate" runat="server" ControlToValidate="tbRegisterDate"
                                ErrorMessage="注册时间不能为空">                            </asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td align="right" class="ltitles" >
                          <span class="hong"> *</span><strong> 注册地址：</strong></td>
                        <td>
                            <uc4:ZoneSelectControl ID="ZoneSelectControl1" runat="server" />                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="ltitles" style="height: 24px" >
                          <span class="hong">*</span> <strong>注册资本：</strong></td>
                        <td style="height: 24px" ><asp:DropDownList ID="ddlCapitalCurrency" runat="server" Width="76px">
                                <asp:ListItem Selected="True" Value="人民币">人民币</asp:ListItem>
                                <asp:ListItem Value="港币">港币</asp:ListItem>
                                <asp:ListItem Value="美元">美元</asp:ListItem>
                            </asp:DropDownList><asp:TextBox ID="tbRegCapital" runat="server" Width="89px"></asp:TextBox>
                            万
                            <asp:RequiredFieldValidator ID="reqCurrency" runat="server" ControlToValidate="tbRegCapital"
                                ErrorMessage="注册资本不能为空">                            </asp:RequiredFieldValidator></td>
                    </tr>
                    <tr id="behide">
                        <td align="right" valign="top" class="ltitles" >
                          <span class="hong">* </span><strong>主营行业：</strong></td>
                        <td width="610">
                            <uc3:SelectIndustryControl ID="SelectIndustryControl1" runat="server"></uc3:SelectIndustryControl>
                      </td>
                    </tr>
                    <tr>
                        <td align="right" class="ltitles" ><strong>
                          主营产品或服务：</strong></td>
                        <td>
                            <div>
                                <asp:TextBox ID="tbMainProduct1" runat="server" Width="58px">                                </asp:TextBox>
                                <asp:TextBox ID="tbMainProduct2" runat="server" Width="58px">                                </asp:TextBox>
                                <asp:TextBox ID="tbMainProduct3" runat="server" Width="58px">                                </asp:TextBox>
                                <asp:TextBox ID="tbMainProduct4" runat="server" Width="58px">                                </asp:TextBox></div>  
                                                       <div class="hui">
                                每空限填1种产品或服务名称,建议10个字以下,如：房地产</div>                       </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top" class="ltitles" >
                          <span class="hong">*</span> <strong>公司介绍：</strong><br />
                          （50－2000字）<br />

                      (分条显示）</td>
                        <td >
                            <div>
                                <asp:TextBox ID="tbComAbout" runat="server" Height="300px" TextMode="MultiLine"
                                    onkeyup="ShowFontCount(this);" Width="500px"></asp:TextBox>
                                &nbsp;
                                <br />
                                <asp:Label ID="lbMessage" runat="server" ForeColor="Red"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbComAbout"
                                    ErrorMessage="公司介绍不能为空" ></asp:RequiredFieldValidator>
                          </div>  <div class="hui">
                                请用中文介绍贵司发展历史、资产状况、主营业务、品牌服务等优势；如果内容很简单，可能无法通过审核<br />
                                联系方式（电话、传真、手机、电子邮箱等）请在下一步填写，此处重复填写将无法通过审核                            </div>                       </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top" class="ltitles" ><strong>
                          图片上传：</strong></td>
                        <td class="nonepad" style="width: 585px; height: 18px;">
                            <div class="hui">
                                <uc1:ImageUploadControl ID="ImageUploadControl1" runat="server" InfoType="EnterpriseRegister" />
                                &nbsp;</div>                        </td>
                    </tr>
              </table>
            </div>
			<div class="blank6"></div>
            <h3 class="infozi">
                联系方式：</h3>
            <div class="widthTable">
           <uc5:OrgContactControl ID="OrgContactControl1" runat="server" width="100%" />
            </div>
			<div class="blank6"></div>
            <h3 class="infozi">
                申请域名建立我的展厅:</h3>
            <div class="viewbox lightc cshibiank">
            我的展厅是我们推出的一项最新服务，方便用户全面展示自己的公司/机构，获得合作方更多信任。 <a href="http://www.topfo.com/help/setup.shtml" target="_blank">了解更多</a></div>
			<div class="blank0">
        </div>
            <div >
                <span class="hong">*</span> <b>我的域名：<asp:TextBox ID="tbExhibitionHall" runat="server" Width="58px"></asp:TextBox>
                </b><b>.co.topfo.com
                </b><span>只有申请了域名，公司介绍才能上网展示!
                    <input id="Hidden1" type="hidden" runat="server" />
                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                  </span><div id="MessageDiv">
                    </div>
            </div>
            <div class="mbbuttom">
             <p>   <a href="http://www.topfo.com/ServiceItem/ServiceItem.shtml" target="_blank" >点此阅读中国招商投资网服务条款</a>
             <p>
          <asp:ImageButton ID="buSend" runat="server" ImageUrl="../images/Company_Manage/arr_06.gif"
                    OnClick="buSend_Click" OnClientClick="return chkPost(); "   /></div>
        </div>
		
    </div>
 <div id="imgLoding" Style="position: absolute; 
  display:none; background-color: #A9A9A9; 
  top: 0px; left: 0px; width: 100%;
   height:2500px; filter: 
   alpha(opacity=60);">

               <div class="content">
                <p>
                    数据正在提交,请稍候...</p>
                <img src="../images/loading42.gif" alt="Loading" />
                </div>
   </div>
    <script type="text/javascript">  
function ShowFontCount(theControl)
{
	var Descript=document.getElementById("ctl00_ContentPlaceHolder1_tbComAbout");	
    var msg=document.getElementById("ctl00_ContentPlaceHolder1_lbMessage");
    var len=theControl.value.length;
    if( Descript != null )
    {
         msg.innerHTML = "公司介绍字数："+len;       
	}
}	
function CheckDomain(domain,loginName)
{	
    if(domain!="")
    {
        AjaxMethod.CheckDomain(domain,loginName,showMessage);	
    }
}

function showMessage(res)
{
    var ln = document.getElementById("ctl00_ContentPlaceHolder1_Label1");			
    var hid=document.getElementById("ctl00_ContentPlaceHolder1_Hidden1");//ctl00_ContentPlaceHolder1_Hidden1
    hid.value=res.value;
    ln.innerHTML ="<font color='red'>"+res.value+"</font>";
    
   			
}
    </script>

</asp:Content>
